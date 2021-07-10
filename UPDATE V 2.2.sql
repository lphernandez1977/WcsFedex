
DROP TABLE TB_Produccion_Distribucion_Jornadas

GO

CREATE TABLE TB_Produccion_Distribucion_Jornadas(
	[Cod] [int] IDENTITY(1,1) NOT NULL,
	[Depot_From] [varchar](3) NULL,
	[Depot_To] [varchar](3) NULL,
	[Zona] [varchar](4) NULL,
	[Producto] [varchar](2) NULL,
	[Anden_Destino] [int] NOT NULL,
	[Descripcion_Destino] [varchar](100) NOT NULL,
	[Jornada] [char](2) NOT NULL,
	[Observacion] [varchar](100) NULL,
	[Empresa_Origen] [varchar](20) NOT NULL,
	[Fecha_Crea] [datetime] NOT NULL,
	[Usuario_Crea] [varchar](50) NOT NULL,
	[Usuario_Mod] [varchar](50) NULL,
	[Fecha_Mod] [datetime] NULL,
	[CorrJornada] [int] NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE TB_Jornada_Asignada(
Cod_Jornada int NOT NULL,
Fecha_Asignacion datetime NOT NULL,
Usuario_Asignacion varchar(50) NOT NULL,
Tipo_Jornada varchar(100) NOT NULL
)

GO

CREATE PROC SP_INSERTA_XML_JORNADAS_FEDEX
@PgDocXml AS XML,
@Pgi_Salida INT OUTPUT,
@pMensaje_Error VARCHAR(200) OUTPUT
AS

DECLARE @IdDocXML INT,
		@loc_CorrJor INT

--***********************************************************************
--Funcion Correlativo Ciclo
--***********************************************************************
SET @loc_CorrJor = (SELECT MAX(CorrJornada) from TB_Produccion_Distribucion_Jornadas)

IF @loc_CorrJor IS NULL
	BEGIN
		SET @loc_CorrJor = 1
	END
ELSE
	BEGIN
		SET @loc_CorrJor = @loc_CorrJor + 1
	END

BEGIN 
	BEGIN TRY
		BEGIN DISTRIBUTED TRANSACTION
		--Preparamos el document XML en base al texto XML 
		EXECUTE sp_xml_preparedocument @IdDocXML OUTPUT, @PgDocXml
		--lectura preparando un xml
		--*****************************************************************************												
				SELECT 
				CASE WHEN Destino = 'VINA DEL MAR' THEN 'VIÑA DEL MAR' ELSE Destino END Destino,
				Jornada,
				Usuario
				INTO #TB_PASO
				FROM 				
				OPENXML(@IdDocXML,'/Destino/CabeceraDistribucionJornadas/DetalleDistribucionJornadas/Detalle',1)
				WITH (
				   Destino VARCHAR(100) 'Destino', 
                   Jornada VARCHAR(2) 'Jornada',
				   Usuario VARCHAR(50) 'Usuario'
				   )
			       					   				
			-- Removemos la representación interna del documento
			EXECUTE sp_xml_removedocument @IdDocXML
			
			INSERT INTO TB_Produccion_Distribucion_Jornadas(	
				Depot_From,
				Depot_To,
				Zona,
				Producto,
				Anden_Destino,
				Descripcion_Destino,
				Jornada,
				Observacion,
				Empresa_Origen,
				Fecha_Crea,
				Usuario_Crea,			
				CorrJornada				
			)
			SELECT 
				B.Depot_From,
				B.Depot_To,
				B.Zona,
				B.Producto,
				B.Anden_Destino,
				A.Destino,
				A.Jornada,
				'Distribucion Jornada ' + A.Jornada 'Observacion',
				A.Usuario,
				GETDATE(),
				A.Usuario,
				@loc_CorrJor
			FROM #TB_PASO A INNER JOIN TB_Distribucion_Fedex B ON (A.Destino = B.Desc_Destino) 

			-- executamos transaccion distribuida
			COMMIT TRANSACTION									
		
		DROP TABLE #TB_PASO
				SET @Pgi_Salida = 1
				SET @pMensaje_Error = 'Operación Finalizada en forma correcta'				
				
		END TRY
		BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @Pgi_Salida = 0
				SET @pMensaje_Error = ERROR_MESSAGE()
		END CATCH
END

GO

CREATE PROC SP_Listado_Jornadas_Disponibles
AS
SELECT   
A.CorrJornada,  
A.Jornada,   
A.Observacion + ' Correlativo N°' + CONVERT(VARCHAR,A.CorrJornada) + ' con ' + CONVERT(VARCHAR,COUNT(*)) + ' destinos asignados' 'Observacion',
CASE WHEN B.Cod_Jornada IS NULL THEN 'Creada' ELSE 'En Producción' END Estado
FROM TB_Produccion_Distribucion_Jornadas A
LEFT JOIN TB_Jornada_Asignada B ON A.CorrJornada = B.Cod_Jornada
GROUP BY   
A.CorrJornada,  
B.Cod_Jornada,
A.Jornada,  
A.Observacion  

GO

CREATE PROC SP_Listado_Jornadas_En_Produccion
AS
SELECT 
A.Cod_Jornada,
B.Observacion + ' Correlativo N°' + CONVERT(VARCHAR,B.CorrJornada) + ' con ' + CONVERT(VARCHAR,COUNT(*)) + ' destinos asignados' 'Observacion',
CASE WHEN B.Usuario_Crea = 'AUTOMATICO' THEN 'Automatica' ELSE 'Manual' END 'Tipo Jornada' 
FROM TB_Jornada_Asignada A
LEFT JOIN TB_Produccion_Distribucion_Jornadas B ON A.Cod_Jornada = B.CorrJornada
GROUP BY
A.Cod_Jornada,
B.CorrJornada,
B.Observacion,
B.Usuario_Crea

GO

CREATE PROC SP_Detalle_Jornadas
@in_CorrJornada INT
AS
SELECT
Anden_Destino,
Descripcion_Destino,
Jornada
FROM TB_Produccion_Distribucion_Jornadas
WHERE
CorrJornada = @in_CorrJornada
ORDER BY Anden_Destino ASC

GO

CREATE PROC SP_EJECUTA_JORNADAS_PRODUCCION
@in_CorrJornada INT, 
@in_Usuario VARCHAR(50),
@out_Mensaje_Operacion INT OUTPUT,
@out_Mensaje_ErrorSql VARCHAR(255) OUTPUT
AS
BEGIN TRY
	BEGIN TRAN
		IF NOT EXISTS(SELECT * FROM TB_Jornada_Asignada WHERE Cod_Jornada = @in_CorrJornada)
			BEGIN
				INSERT INTO TB_Jornada_Asignada 
				SELECT CorrJornada,GETDATE(),@in_Usuario,'Manual' 
				FROM TB_Produccion_Distribucion_Jornadas WHERE CorrJornada = @in_CorrJornada
				GROUP BY 
				CorrJornada

				DELETE TB_Jornada_Asignada WHERE Cod_Jornada <> @in_CorrJornada	
			END
	COMMIT TRAN
	SET @out_Mensaje_Operacion = 1
	SET @out_Mensaje_ErrorSql  = 'Operacion realizada en forma correcta'
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	SET @out_Mensaje_Operacion = 0
	SET @out_Mensaje_ErrorSql  = ERROR_MESSAGE()
END CATCH

GO

CREATE PROC SP_CREAR_JORNADAS_AUTOMATICAS
@out_Mensaje_Operacion INT OUTPUT,
@out_Mensaje_ErrorSql VARCHAR(255) OUTPUT
AS

DECLARE @loc_CorrJor INT

--***********************************************************************
--Funcion Correlativo Ciclo
--***********************************************************************
SET @loc_CorrJor = (SELECT MAX(CorrJornada) from TB_Produccion_Distribucion_Jornadas)

IF @loc_CorrJor IS NULL
	BEGIN
		SET @loc_CorrJor = 1
	END
ELSE
	BEGIN
		SET @loc_CorrJor = @loc_CorrJor + 1
	END
--***********************************************************************

BEGIN TRY
	BEGIN TRAN
		INSERT INTO TB_Produccion_Distribucion_Jornadas(	
		Depot_From,
		Depot_To,
		Zona,
		Producto,
		Anden_Destino,
		Descripcion_Destino,
		Jornada,
		Observacion,
		Empresa_Origen,
		Fecha_Crea,
		Usuario_Crea,			
		CorrJornada				
		)
		SELECT			
		Depot_From,
		Depot_To,
		Zona,
		Producto,
		Anden_Destino,
		Desc_Destino,
		'AU',
		'Distribucion Jornada Auomatica' 'Observacion',
		'Fedex',
		GETDATE(),
		'AUTOMATICO',
		@loc_CorrJor
		FROM TB_Distribucion_Fedex 

		IF NOT EXISTS(SELECT * FROM TB_Jornada_Asignada WHERE Cod_Jornada = @loc_CorrJor)
					BEGIN
						INSERT INTO TB_Jornada_Asignada 
						SELECT CorrJornada,GETDATE(),Usuario_Crea,Usuario_Crea
						FROM TB_Produccion_Distribucion_Jornadas 
						WHERE CorrJornada = @loc_CorrJor
						GROUP BY 
						CorrJornada,
						Usuario_Crea
				
					END
	COMMIT TRAN
	SET @out_Mensaje_Operacion = 1
	SET @out_Mensaje_ErrorSql = 'Operacion Realizada en forma correcta'

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	SET @out_Mensaje_Operacion = 0
	SET @out_Mensaje_ErrorSql = ERROR_MESSAGE();
END CATCH




