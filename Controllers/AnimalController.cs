using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using petshop.api.model;
using services;

namespace Controllers.AnimalController
{


    [Route("api/[controller]")]

    [ApiController]
    public class AnimalController : Controller

    {
        public readonly  MongoDbService _mongoDbservice;


    [HttpPost]
        public async Task Cadastrar([FromBody] Animal animal){

            await _mongoDbservice.insere(animal);
            
            }

            

        public AnimalController (){

        _mongoDbservice = new MongoDbService("AnimalDatabase","Animal","mongodb:\\localhost:27017");
        
        

        }

    [HttpGet]

    public async Task <JsonResult> PegarTodosAnimais(){

        var todosAnimais = await _mongoDbservice.GetAllAnimals();
        return Json(todosAnimais);

        }  


    [HttpGet("{id}", Name =  "PegarAnimal")]
         public ActionResult<Animal> PegarAnimalPorID(string id){

var animal = _mongoDbservice.Get(id);
if (animal == null){

    return NotFound();

}
return animal;
    }  

    }

   

}