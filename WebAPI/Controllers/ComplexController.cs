using System;

using Microsoft.AspNetCore.Mvc;

using SwaggerDemo.WebAPI.Models;

namespace SwaggerDemo.WebAPI.Controllers
{
    [Route("api/complex")]
    public class ComplexController
    {
        [HttpPost]
        public void Create([FromBody] Complex model)
        {
        }

        [HttpPut, Obsolete, ApiExplorerSettings(IgnoreApi = true)]
        public void WrongCreate(Complex model)
        {
        }
    }
}