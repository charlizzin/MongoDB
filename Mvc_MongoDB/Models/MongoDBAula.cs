using MongoDB.Driver;
using System;
using System.Configuration;

namespace Mvc_MongoDB.Models
{
    public class MongoDBAula
    {
        public MongoDatabase Database;
        public String DataBaseName = "AulaMongoDB";
        string conexaoMongoDB = "";

        public MongoDBAula()
        {
            conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString;
            var cliente = new MongoClient(conexaoMongoDB);
            var server = cliente.GetServer();

            Database = server.GetDatabase(DataBaseName);
        }
        public MongoCollection<Cliente> Clientes
        {
            get
            {
                var Clientes = Database.GetCollection<Cliente>("Cliente");
                return Clientes;
            }
        }
        public MongoCollection<Pais> Paises
        {
            get
            {
                var Paises = Database.GetCollection<Pais>("Paises");
                return Paises;
            }
        }
        public MongoCollection<Produto> Produtos
        {
            get
            {
                var Produtos = Database.GetCollection<Produto>("Produtos");
                return Produtos;
            }
        }
    }
}