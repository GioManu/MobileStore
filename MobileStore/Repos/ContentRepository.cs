using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileStore.Data;
using MobileStore.DataModels;

namespace MobileStore.Repos
{
    public class ContentRepository : IContentRepository
    {
        private readonly AppDbContent appDBContent;
        public ContentRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<ProductImage> GetAll()
        {
            return this.appDBContent.Image;
        }

        public IEnumerable<ProductImage> GetByProductID(int ProductID)
        {
            return this.appDBContent.Image.Where((e) => e.ProductID.Equals(ProductID));
        }
    }
}
