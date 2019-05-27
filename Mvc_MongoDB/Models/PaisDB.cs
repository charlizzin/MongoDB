using MongoDB.Driver;
using System;
using System.Configuration;

namespace Mvc_MongoDB.Models
{
    public class PaisDB
    {
        public MongoDatabase Database;
        public String DataBaseName = "PaisDB";
        string conexaoMongoDB = "";

        public PaisDB ()
	    {

            conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString;
            var cliente = new MongoClient(conexaoMongoDB);
            var server = cliente.GetServer();

            Database = server.GetDatabase(DataBaseName);
	    }

        public MongoCollection<Pais> Paises
        {
            get
            {
                var Paises = Database.GetCollection<Pais>("Paises");
                return Paises;
            }
        }
    }
}