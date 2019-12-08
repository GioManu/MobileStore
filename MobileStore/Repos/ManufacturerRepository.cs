using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileStore.Data;
using MobileStore.DataModels;

namespace MobileStore.Repos
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContent appDBContent;
        public ManufacturerRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Manufacturer> GetAll()
        {
            return this.appDBContent.Manufacturer;
        }

        public Manufacturer GetByID(int ManuID)
        {
            return this.appDBContent.Manufacturer.FirstOrDefault((e) => e.ManufaturerID.Equals(ManuID));
        }
    }
}
