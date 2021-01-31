using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodCompany.Data.Services
{
    public interface IComputerTypeService
    {
        public Task<string> Add(string name);
        public Task<string> Get(string name);
        Task<List<string>> GetAll();
    }
}
