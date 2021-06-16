using AppWebApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AController : ControllerBase
    {
        // GET: api/<AController>
        [HttpGet]
        public ResponseModel Get()
        {
            return new AModel().GetAll();
        }


        // GET api/<AController>/5
        [HttpGet("{id}")]
        public ResponseModel Get(int ID)
        {
            return new AModel().GetByID(ID);
        }

        
        // POST api/<AController>
        [HttpPost]
        public ResponseModel Post([FromBody] AModel a)
        {
            return a.Insert();
        }

        
        // PUT api/<AController>/5
        [HttpPut]
        public ResponseModel Put([FromBody] AModel a)
        {
            return a.Update();
        }

        
        // DELETE api/<AController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int ID)
        {
            return new AModel().Delete(ID);
        }
        
    }
}
