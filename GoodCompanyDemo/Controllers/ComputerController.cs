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
    public class ComputerController : Controller
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

            switch (existingComputer.TypeName.Name)
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

        public async Task<ActionResult<ComputerModel>> PostComputer(ComputerModel computer)
        {
            if (computer == null)
            {
                return BadRequest();
            }

            ComputerModel cp;

            switch (computer.TypeName.Name)
            {
                case "Desktop":
                    PCComputer newPC = computer as PCComputer;
                    newPC = new PCComputer {
                        Id = newPC.Id,
                        Brand = newPC.Brand,
                        ProcessorName = newPC.ProcessorName,
                        Quantity = newPC.Quantity,
                        RamSlots = newPC.RamSlots,
                        UsbPorts = newPC.UsbPorts
                    };
                    cp = newPC;
                    break;
                case "Laptop":
                    LaptopComputer newLP = computer as LaptopComputer;
                    newLP = new LaptopComputer {
                        Id = newLP.Id,
                        Brand = newLP.Brand,
                        ProcessorName = newLP.ProcessorName,
                        ScreenSize = newLP.ScreenSize
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
