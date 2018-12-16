using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IService service;
        private readonly IService<string> genericStringService;
        private readonly IEnumerable<IService> services;

        // Default injection
        public ValuesController(IService service)
        {
            this.service = service;
        }

        // Default injection
        //public ValuesController(IService<string> genericStringService)
        //{
        //    this.genericStringService = genericStringService;
        //}

        // Delegate injection
        //public ValuesController(Func<ServiceEnum, IService> serviceResolver)
        //{
        //    this.service = serviceResolver(ServiceEnum.C);
        //}

        // Default injection with IEnumerable
        //public ValuesController(IEnumerable<IService> services)
        //{
        //    this.services = services;
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
