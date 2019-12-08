using MobileStore.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Repos
{
    public interface IContentRepository
    {
        public IEnumerable<ProductImage> GetAll();
        public IEnumerable<ProductImage> GetByProductID(int ProductID);
    }
}
