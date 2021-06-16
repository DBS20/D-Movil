using AppWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BOfficeController : ControllerBase
    {
        // GET: api/<BOfficeController>
        [HttpGet]
        public ResponseModel Get()
        {
            return new BranchOfficeModel().GetAll();
        }

        // GET api/<BOfficeController>/5
        [HttpGet("{id}")]
        public ResponseModel Get(int ID)
        {
            return new BranchOfficeModel().GetByID(ID);
        }

        // POST api/<BOfficeController>
        [HttpPost]
        public ResponseModel Post([FromBody] BranchOfficeModel a)
        {
            return a.Insert();
        }

        // PUT api/<BOfficeController>/5
        [HttpPut]
        public ResponseModel Put([FromBody] BranchOfficeModel a)
        {
            return a.Update();
        }

        // DELETE api/<BOfficeController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int ID)
        {
            return new BranchOfficeModel().Delete(ID);
        }
    }
}
