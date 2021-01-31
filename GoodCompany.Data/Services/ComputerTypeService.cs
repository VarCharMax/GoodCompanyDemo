using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompany.Data.Services
{
    public class DuplicateTypeException : Exception
    {
        public DuplicateTypeException()
        {

        }
    }

    public class ComputerTypeService : IComputerTypeService
    {
        private static ConcurrentBag<string> _computerTypes;

        public ComputerTypeService()
        {
            _computerTypes = new ConcurrentBag<string>();
        }

        public Task<string> Add(string name)
        {
            string ec = null;

            try
            {
                ec = _computerTypes.FirstOrDefault(x => x == name);
            }
            catch(Exception)
            {
                throw;
            }

            if (ec != null)
            {
                throw new DuplicateTypeException();
            }

            _computerTypes.Add(ec);

            return Task.FromResult(ec);
        }

        public Task<string> Get(string name)
        {
            return Task.FromResult(_computerTypes.FirstOrDefault(x => x == name));
        }

        public Task<List<string>> GetAll()
        {
            return Task.FromResult(_computerTypes.ToList());
        }
    }
}
