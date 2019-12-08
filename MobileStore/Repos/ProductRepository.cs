using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileStore.Data;
using MobileStore.DataModels;

namespace MobileStore.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContent appDBContent;
        public ProductRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Product> GetAll()
        {
            return this.appDBContent.MobileProduct;
        }

        public IEnumerable<Product> GetBy<T>(T args)
        {
            throw new NotImplementedException();
        }
    }
}
