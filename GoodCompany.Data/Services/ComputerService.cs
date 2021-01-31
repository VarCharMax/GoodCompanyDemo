using GoodCompany.Data.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompany.Data.Services
{
    public class ComputerService : IComputerService
    {
        private static ConcurrentBag<ComputerModel> _computers;

        public ComputerService()
        {
            _computers = new ConcurrentBag<ComputerModel>();

            PopulateServices();
        }

        private async void PopulateServices()
        {
            ComputerTypeService svc = new ComputerTypeService();

            string mdDesk = await svc.Add("Desktop");
            string mdLT = await svc.Add("Laptop");

            _computers.Add(new PCComputer { Brand = "Dell", ProcessorName = "Pentium", Quantity = 3, RamSlots = 2, UsbPorts = 4, TypeName = mdDesk });
            _computers.Add(new LaptopComputer { Brand = "Lenovo", ProcessorName = "Pentium", Quantity = 2, ScreenSize = 15, TypeName = mdLT });
        }

        public Task<ComputerModel> Add(ComputerModel computerModel)
        {
            _computers.Add(computerModel);

            return Task.FromResult(computerModel);
        }

        public Task Update(ComputerModel computerModel)
        {
            _computers = new ConcurrentBag<ComputerModel>(_computers.Where(x => x.Id != computerModel.Id)) { computerModel };

            return Task.CompletedTask;
        }

        public Task<ComputerModel> Get(Guid id)
        {
            return Task.FromResult(_computers.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<ComputerModel>> GetAll()
        {
            return Task.FromResult(_computers.ToList());
        }
    }
}
