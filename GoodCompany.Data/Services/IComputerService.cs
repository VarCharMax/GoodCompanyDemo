using GoodCompany.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodCompany.Data.Services
{
    public interface IComputerService
    {
        Task<ComputerModel> Add(ComputerModel computerModel);
        Task<ComputerModel> Get(Guid id);
        Task<List<ComputerModel>> GetAll();
        Task Update(ComputerModel computerModel);
    }
}
