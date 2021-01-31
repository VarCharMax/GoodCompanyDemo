using GoodCompany.Data.Models;
using GoodCompany.Data.Services;
using GoodCompanyDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
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
            //ComputerTypeService cs = new ComputerTypeService();

            //await cs.Add("Desktop");
            //await cs.Add("Laptop");

            PCComputer pc = new PCComputer { Brand = "Dell", ProcessorName = "Pentium" , Quantity = 1, RamSlots = 2, UsbPorts = 2 };

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

            LaptopComputer lt = new LaptopComputer { Brand = "Dell", ProcessorName = "Pentium" };

            ActionResult<ComputerModel> result = await cp.PostComputer(lt);

            var res = result.Value as LaptopComputer;

            Assert.Equal(lt, res);
        }

        [Fact]
        public async void Test_PC_Storing_And_Update()
        {
            ComputerController cp = new ComputerController(new ComputerService());

            PCComputer pc = new PCComputer { Brand = "Dell", ProcessorName = "Pentium", Quantity = 1, RamSlots = 2, UsbPorts = 2 };

            ActionResult<ComputerModel> result = await cp.PostComputer(pc);

            var res = result.Value as PCComputer;

            res.UsbPorts = 4;

            ActionResult<ComputerModel> result2 = await cp.PutComputer(res.Id, res);

            var res2 = result2.Value as PCComputer;

            Assert.Equal(pc, res); //New PC and inserted PC are identical.
            Assert.Equal(res.UsbPorts, res2.UsbPorts); //Updated PC has correct number of slots.
        }

        [Fact]
        public async void Test_Laptop_Storing_And_Update()
        {
            ComputerController cp = new ComputerController(new ComputerService());

            LaptopComputer lt = new LaptopComputer { Brand = "Dell", ProcessorName = "Pentium", Quantity = 1, ScreenSize = 13 };

            ActionResult<ComputerModel> result = await cp.PostComputer(lt);

            var res = result.Value as LaptopComputer;

            res.ScreenSize = 15;

            ActionResult<ComputerModel> result2 = await cp.PutComputer(res.Id, res);

            var res2 = result2.Value as LaptopComputer;

            Assert.Equal(lt, res); //New Laptop and inserted Laptop are identical.
            Assert.Equal(res.ScreenSize, res2.ScreenSize); //Updated laptop has correct screen size.
        }
    }
}
