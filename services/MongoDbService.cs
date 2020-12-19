using System.Threading.Tasks;
using petshop.api.model;
using MongoDB.Driver;

namespace services
{
    public class MongoDbService
    {

        private IMongoCollection<Animal> AnimalColletion {get; set;}

        public MongoDbService(string database, string collection, string databaseUrl)

        {

            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(database);
            AnimalColletion = mongoDatabase.GetCollection<Animal>(collection);

        }

        //operacoes INSERIR, UPDATE, LER E DELETAR

        //Recupera do Mongo registro buscando pelo id

        public Animal Get (string id) => 
        AnimalColletion.Find<Animal>(Animal => 
        Animal.Id == id).FirstOrDefault();


        public async Task insere(Animal animal) => await AnimalColletion.InsertOneAsync(animal);
    }
}