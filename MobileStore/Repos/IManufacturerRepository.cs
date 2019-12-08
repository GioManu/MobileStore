using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Repos
{
    public interface IManufacturerRepository
    {
        public IEnumerable<Manufacturer> GetAll();
        public Manufacturer GetByID(int ManuID);

    }
}
