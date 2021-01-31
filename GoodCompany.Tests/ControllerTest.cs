using GoodCompany.Data.Models;
using GoodCompany.Data.Services;
using GoodCompanyDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace GoodCompany.Tests
{
    public class ControllerTest
    {
        [Fact]
        public async void Test_PC_Storing_And_Unboxing()
        {
            //Test that when we store a PC object via its parent class, we can unbox the return value to an
            //instance of the PC class and we don't just get a truncated parent class. 

            ComputerController cp = new ComputerController(new ComputerService());

            PCComputer pc = new PCComputer { Brand = "Dell", ProcessorName = new ProcessorType { Name = "Pentium" } , Quantity = 1, RamSlots = 2, UsbPorts = 2 };

            ActionResult<ComputerModel> result = await cp.PostComputer(pc);

            var res = result.Value as PCComputer;
            
           Assert.Equal(pc, res); 
        }
        
        [Fact]
        public async void Test_Laptop_Storing_And_Unboxing()
        {
            //Test that when we store a Laptop object via its parent class, we can unbox the return value to an
            //instance of the Laptop class and we don't just get a truncated parent class. 

            ComputerController cp = new ComputerController(new ComputerService());

            LaptopComputer lt = new LaptopComputer { Brand = "Dell", ProcessorName = new ProcessorType { Name = "Pentium" } };

            ActionResult<ComputerModel> result = await cp.PostComputer(lt);

            var res = result.Value as LaptopComputer;

            Assert.Equal(lt, res);
        }
    }
}
