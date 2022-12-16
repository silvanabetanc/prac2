namespace srbetancBBDDSQl.Entity
{
    public class EConstantes
    {
        #region TAGS DE CATALGOS
        /// <summary>
        /// 
        /// </summary>
        public const string TagBackendOpenShift = "OPENSHIFT";

        /// <summary>
        /// 
        /// </summary>
        public const string Recurso001 = "ConsultarServicioInstancia01";

        /// <summary>
        /// 
        /// </summary>
        public const string Recurso002 = "CrearServicioInstancia01";

        /// <summary>
        ///     Código que representa el header nulo.
        /// </summary>
        public const string HeaderInNullCode = "0001";

        /// <summary>
        ///     Descripción que representa el header vacio.
        /// </summary>
        public const string HeaderInNullDescription = "LA CABECERA ES NULA O NO EXISTE";

        /// <summary>
        ///     Código que representa el body nulo.
        /// </summary>
        public const string BodyNullCode = "0017";

        /// <summary>
        ///     Descripción que representa el body vacio.
        /// </summary>
        public const string BodyNullDescription = "EL CUERPO DEL SERVICIO ES NULO O NO EXISTE";

        /// <summary>
        /// Device Hash takes it from claims
        /// </summary>
        public const string DispositivoNullCode = "0002";

        /// <summary>
        /// Device Hash takes it from claims
        /// </summary>
        public const string DispositivoNullDescription = "DISPOSITIVO NULO O VACÍO";

        /// <summary>
        /// Company code 0010 by default
        /// </summary>
        public const string EmpresaNullCode = "0003";

        /// <summary>
        /// Company code 0010 by default
        /// </summary>
        public const string EmpresaNullDescription = "EMPRESA NULA O VACÍA";

        /// <summary>
        /// Code channel defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string CanalNullCode = "0004";

        /// <summary>
        /// Code channel defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string CanalNullDescription = "CANAL NULO O VACÍO";

        /// <summary>
        /// Medium code defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string MedioNullCode = "0005";

        /// <summary>
        /// Medium code defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string MedioNullDescription = "MEDIO NULO O VACÍO";

        /// <summary>
        /// Application code defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string AplicacionNullCode = "0006";

        /// <summary>
        /// Application code defined by business architecture WSO2 will send in the Claim
        /// </summary>
        public const string AplicacionNullDescription = "APLICACIÓN NULA O VACÍA";

        /// <summary>
        /// Application code defined by enterprise architecture each application must place this value is the transactional log transaction type.
        /// </summary>
        public const string TipoTransaccionNullCode = "0008";

        /// <summary>
        /// Application code defined by enterprise architecture each application must place this value is the transactional log transaction type.
        /// </summary>
        public const string TipoTransaccionNullDescription = "TIPO TRANSACCION NULA O VACÍA";

        /// <summary>
        /// Field describes the geolocation
        /// </summary>
        public const string GeolocalizacionNullCode = "0009";

        /// <summary>
        /// Field describes the geolocation
        /// </summary>
        public const string GeolocalizacionNullDescription = "GEOLOCALIZACION NULA O VACÍA";

        /// <summary>
        /// generic user of the default transaction
        /// </summary>
        public const string UsuarioNullCode = "0010";

        /// <summary>
        /// generic user of the default transaction
        /// </summary>
        public const string UsuarioNullDescription = "USUARIO NULO O VACÍO";

        /// <summary>
        /// HASH of the transaction component is generated with the uniqueness component
        /// </summary>
        public const string UnicidadNullCode = "0011";

        /// <summary>
        /// HASH of the transaction component is generated with the uniqueness component
        /// </summary>
        public const string UnicidadNullDescription = "UNICIDAD NULA O VACÍA";

        /// <summary>
        /// Unique identifier of the transaction
        /// </summary>
        public const string GuidNullCode = "0012";

        /// <summary>
        /// Unique identifier of the transaction
        /// </summary>
        public const string GuidNullDescription = "GUID NULO O VACÍO";

        /// <summary>
        /// date and time of transaction yyyyMMddhhmmssSSSS
        /// </summary>
        public const string FechaHoraNullCode = "0013";

        /// <summary>
        /// date and time of transaction yyyyMMddhhmmssSSSS
        /// </summary>
        public const string FechaHoraNullDescription = "FECHA-HORA NULA O VACÍA";

        /// <summary>
        /// Language WSO2 will send on the Claim
        /// </summary>
        public const string IdiomaNullCode = "0014";

        /// <summary>
        /// Language WSO2 will send on the Claim
        /// </summary>
        public const string IdiomaNullDescription = "IDIOMA NULO O VACÍO";

        /// <summary>
        /// Session generated in WSO2 is sent in the claim
        /// </summary>
        public const string SesionNullCode = "0015";

        /// <summary>
        /// Session generated in WSO2 is sent in the claim
        /// </summary>
        public const string SesionNullDescription = "SESION NULA O VACÍA";

        /// <summary>
        /// Client IP address
        /// </summary>
        public const string IpNullCode = "0016";

        /// <summary>
        /// Client IP address
        /// </summary>
        public const string IpNullDescription = "IP NULA O VACÍA";

        /// <summary>
        /// Client IP address
        /// </summary>
        public const string FillerNullCode = "0017";

        /// <summary>
        /// Client IP address
        /// </summary>
        public const string FillerNullDescription = "FILLER NULO O VACÍO";

        /// <summary>
        ///     Descripción que representa el Identificacion nulo
        /// </summary>
        public const string IdentificacionDescription = "El campo identificacion es nulo o vacio";

        /// <summary>
        ///     Descripción que representa el TipoIdentificacion nulo
        /// </summary>
        public const string TipoIdentificacionDescription = "El campo tipoIdentificacion es nulo o vacio";

        /// <summary>
        ///     Código que representa los campos Identificacion, TipoIdentificacion o Numero nulo
        /// </summary>
        public const string NuloVacioCode = "1";

        /// <summary>
        ///     Descripción que representa el campo Identificacion con longitud incorrecta
        /// </summary>
        public const string IdentificacionLengthDescription = "La longitud del campo identificacion es invalida";

        /// <summary>
        ///     Descripción que representa el campo TipoIdentificacion con longitud incorrecta
        /// </summary>
        public const string TipoIdentificacionLengthDescription = "La longitud del campo tipoIdentificacion es invalida";

        /// <summary>
        /// 
        /// </summary>
        public const string IdentificacionRegex = @"^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ_0-9\r\s\n\{\}\/\-\?\:\(\)\.\,\'\+\&\\]*$";

        /// <summary>
        ///     Descripción que representa el campo Identificacion con caracteres especiales o no permitidos
        /// </summary>
        public const string IdentificacionRegexDescription = "El campo identificacion no debe contener caracteres especiales";

        /// <summary>
        ///     Código que representa los campos Identificacion, TipoIdentificacion o Numero con longitud incorrecta
        /// </summary>
        public const string LongitudInvalidaCode = "2";

        /// <summary>
        ///     Descripción que representa el campo TipoIdentificacion con caracteres especiales o no permitidos
        /// </summary>
        public const string TipoIdentificacionRegexDescription = "El campo tipoIdentificacion no debe contener caracteres especiales";

        /// <summary>
        /// 
        /// </summary>
        public const string TipoIdentificacionRegex = @"^(000)[1-3]$";

        /// <summary>
        ///     Código que representa los campos Identificacion, TipoIdentificacion con caracteres especiales o no permitidos
        /// </summary>
        public const string RegexErrorCode = "4";
        #endregion

        #region BACKENDS
        public const string BackendOpenShift = "BACKEND_OPENSHIFT";
        public const string BackendBddRepositorioSql = "BDD_REPOSITORIO_SQL";
        /// <summary>
        /// Propiedad que obtiene nombre de método.
        /// </summary>
        public const string Recurso201 = "GenerarMensaje201";
        #endregion

        #region Comun

        public const string Ok = "OK";
        public const string CodOk = "0";
        public const string ValExpCodigo = "9999";
        /// <summary>
        /// Coma
        /// </summary>
        public const string Coma = ",";

        #endregion

        public const string TagSpConexion = "ConexionBddInstancia";
        public const string TagConexionInstanciaSql = "Server=10.50.8.67,11413;Database=FirmaElectronica;user id=firmaelectronca;password=j8SEUi1Or/sd08MzrP1YXC4bQODd4/xP+88XHXG82dE=";
        public const int Zero = 0;

        public const string URLBASEDATOSSFI = "Server=10.50.8.88,11418;Database=CREDIFE;user id=usrcredife;password=Pichincha1";

        public const string COD_ERROR_CADENA_CONEXION = "9999";
        public const string DES_ERROR_CADENA_CONEXION = "error conexion sql";
        public const string TAGBACKEND_CONFIGURACION = "TAGBACKEND_CONFIGURACION";

        public const string RECURSO_001 = "ConsultarProductosReferidos01";
    }
}
