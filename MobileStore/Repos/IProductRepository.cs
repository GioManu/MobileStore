using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Repos
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetByID(int prodID);
    }
}
