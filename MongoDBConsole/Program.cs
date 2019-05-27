using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //O exemplo a seguir insere um novo documento na inventoyCollection. Se o documento nao especificar um _idField,
            //o driver c# adicionara o _idField com um valor ObjectId
            //conecta ao MongoDB database server
            var cliente = new MongoClient("mongodb://localhost:27017");
            //Nome do banco de dados
            var database = cliente.GetDatabase("Aula");
            //nome documento a ser criar, no sql normal seria a tabela
            var colletion = database.GetCollection<BsonDocument>("Aluno");

            #region INSERT SOMENTE UM REGISTRO
            //registros a ser inserido
            var doc = new BsonDocument
            {
                { "Nome", "Aluno1" },
                { "Idade", 22 },
                { "Materias", new BsonArray {{ "Informatica"}, { "Matematica"} } },
                { "Notas", new BsonDocument { { "Informatica", 28}, { "Matematica", 35.5}} }
            };
            colletion.InsertOne(doc);

            #endregion
            #region INSERT VARIOS REGISTROS
            //O exemplo a seguir insere três novos documentos na inventorycoleção.
            //Se os documentos não especificarem um _idField, o driver adicionará o _idField com um valor ObjectId a cada documento
            var docs = new BsonDocument[]
            {
                new BsonDocument
                {
                    { "Nome", "Aluno2" },
                    { "Idade", 22 },
                    { "Materias", new BsonArray {{ "Informatica"}, { "Matematica"} } },
                    { "Notas", new BsonDocument { { "Informatica", 15}, { "Matematica", 45.5}} }
                },
                new BsonDocument
                {
                    { "Nome", "Aluno3" },
                    { "Idade", 22 },
                    { "Materias", new BsonArray {{ "Informatica"}, { "Matematica"} } },
                    { "Notas", new BsonDocument { { "Informatica", 20}, { "Matematica", 35.5}} }
                },
                new BsonDocument
                {
                    { "Nome", "Aluno4" },
                    { "Idade", 23 },
                    { "Materias", new BsonArray {{ "Informatica"}, { "Matematica"} } },
                    { "Notas", new BsonDocument { { "Informatica", 25}, { "Matematica", 25.5}} }
                },
            };
            colletion.InsertMany(docs);
            #endregion
            #region PESQUISA APOS INSERCAO
            //Para recuperar o documento que voce inseriu basta consultar a colecao.
            //Eq("chave", "valor")
            var filter = Builders<BsonDocument>.Filter.Eq("Nome", "Aluno3");
            var resul = colletion.Find(filter).ToList();
            foreach (var item in resul)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            #endregion

            #region UPDATE SOMENTE UM REGISTRO
            //Para alterar um valor de campo, o MongoDB fornece operadores de atualização para modificar valores.
            //Alguns operadores de atualização, inclusive, criarão o campo especificado se o campo não existir no documento.
            //A seguinte operação atualiza o primeiro documento com item igual a paper. A operação usa:
            var filterUpdate = Builders<BsonDocument>.Filter.Eq("Nome", "Aluno4");
            var update = Builders<BsonDocument>.Update.Set("Idade", 65);
            var result = colletion.UpdateOne(filterUpdate, update);
            #endregion
            #region UPDATE VARIOS REGISTROS
            //A seguinte operação atualiza todos os documentos com quantity valor menor que 50.
            var filterMany = Builders<BsonDocument>.Filter.Eq("Idade", 22);
            var updateMany = Builders<BsonDocument>.Update.Set("Idade", 50);
            var resultMany = colletion.UpdateOne(filterMany, updateMany);
            #endregion
            #region PESQUISA POS UPDATE
            var filterUpdateMany = Builders<BsonDocument>.Filter.Lt("Idade", 50);
            var resultManyMany = colletion.Find(filterUpdateMany).ToList();
            foreach (var item in resultManyMany)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            #endregion

            #region DELETE SOMENTE UM REGISTRO
            var filterDelete = Builders<BsonDocument>.Filter.Eq("Nome", "Aluno1");
            var resultDelete = colletion.DeleteOne(filterDelete);
            #endregion
            #region DELETE VARIOS REGISTROS
            var filterDeleteMany = Builders<BsonDocument>.Filter.Eq("Idade", 50);
            var resultDeleteMany = colletion.DeleteMany(filterDeleteMany);
            #endregion
            Console.ReadKey();
        }
    }
}
