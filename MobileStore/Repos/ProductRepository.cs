using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return this.appDBContent.MobileProduct
                .Include((e) => e.Manufacturer)
                .Include((e) => e.Images);
        }

        public Product GetByID(int prodID)
        {
            return this.appDBContent.MobileProduct
                .Where((e) => e.MobileProductID.Equals(prodID))
                .Include((el) => el.Manufacturer)
                .Include((img) => img.Images).FirstOrDefault();
        }
    }
}
