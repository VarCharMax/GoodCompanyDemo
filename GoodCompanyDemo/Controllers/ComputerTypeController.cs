using GoodCompany.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodCompanyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerTypeController : Controller
    {
        private readonly IComputerTypeService _computerTypeService;

        public ComputerTypeController(IComputerTypeService computerTypeService)
        {
            _computerTypeService = computerTypeService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostComputerType(string name)
        {
            string cm;

            try
            {
                cm = await _computerTypeService.Add(name);
            }
            catch(DuplicateTypeException)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return BadRequest();
            }

            return cm;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetComputerTypes()
        {
            var computerTypes = await _computerTypeService.GetAll();

            return computerTypes;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<string>> GetComputerType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var computerType = await _computerTypeService.Get(name);

            if (computerType == null)
            {
                return NotFound();
            }

            return computerType;
        }
    }
}
