using GoodCompany.Data.Models;
using GoodCompany.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodCompanyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComputerModel>>> GetComputers()
        {
            var computers = await _computerService.GetAll();
            
            return computers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerModel>> GetComputer(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var computer = await _computerService.Get(id);

            if (computer == null)
            {
                return NotFound();
            }

            return computer;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ComputerModel>> PutComputer(Guid id, ComputerModel computer)
        {
            if (id != computer.Id)
            {
                return BadRequest();
            }

            var existingComputer = await _computerService.Get(id);

            if (existingComputer == null)
            {
                return NotFound();
            }

            ComputerModel updatedComputer;

            switch (existingComputer.TypeName)
            {
                case "Desktop":
                    PCComputer pcComputerToUpdate = computer as PCComputer;
                    pcComputerToUpdate = new PCComputer {
                        Id = pcComputerToUpdate.Id,
                        Brand = pcComputerToUpdate.Brand,
                        ProcessorName = pcComputerToUpdate.ProcessorName,
                        Quantity = pcComputerToUpdate.Quantity,
                        RamSlots = pcComputerToUpdate.RamSlots,
                        UsbPorts = pcComputerToUpdate.UsbPorts
                    };
                    updatedComputer = pcComputerToUpdate;
                    break;
                case "Laptop":
                    LaptopComputer lpComputerToUpdate = computer as LaptopComputer;
                    lpComputerToUpdate = new LaptopComputer {
                        Id = lpComputerToUpdate.Id,
                        Brand = lpComputerToUpdate.Brand,
                        ProcessorName = lpComputerToUpdate.ProcessorName,
                        ScreenSize = lpComputerToUpdate.ScreenSize
                    };
                    updatedComputer = lpComputerToUpdate;
                    break;
                default:
                    return BadRequest();
            }

            await _computerService.Update(updatedComputer);

            return existingComputer;
        }

        [HttpPost]
        public async Task<ActionResult<ComputerModel>> PostComputer(GenericComputer computer)
        {
            if (computer == null)
            {
                return BadRequest();
            }

            ComputerModel cp;

            switch (computer.TypeName)
            {
                case "Desktop":
                    PCComputer newPC = new PCComputer {
                        Id = Guid.NewGuid(),
                        TypeName = computer.TypeName,
                        Brand = computer.Brand,
                        ProcessorName = computer.ProcessorName,
                        Quantity = computer.Quantity,
                        UsbPorts = computer.UsbPorts,
                        RamSlots = computer.RamSlots,
                        ImageUrl = computer.ImageUrl,

                    };
                    cp = newPC;
                    break;
                case "Laptop":
                    LaptopComputer newLP = new LaptopComputer {
                        Id = Guid.NewGuid(),
                        TypeName = computer.TypeName,
                        Brand = computer.Brand,
                        ProcessorName = computer.ProcessorName,
                        Quantity = computer.Quantity,
                        ImageUrl = computer.ImageUrl,
                        ScreenSize = computer.ScreenSize
                    };
                    cp = newLP;
                    break;
                default:
                    return BadRequest();
            }

            await _computerService.Add(cp);

            return cp;
        }
    }
}
