namespace LIBRERUMTEST.Datos
{
    public class Conexion
    {

        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value; // Lee el archivo y almacena en cadenaSQL
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
