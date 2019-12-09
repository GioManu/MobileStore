using MobileStore.DataModels;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Helpers
{
    public class ProductListHelper
    {
        public IEnumerable<Product> prods { get; set; }
        public PageParametersViewModel parameters { get; set; }

        public int MaxPageSize { get; set; }
        public ProductListHelper(IEnumerable<Product> prods, ref PageParametersViewModel parameters, int MaxPageSize)
        {
            this.prods = prods;
            this.parameters = parameters;
            this.MaxPageSize = MaxPageSize;
        }

        public int TotalPages()
        {
            int TotalPages = (int)Math.Ceiling((double)this.prods.Count() / (double)this.MaxPageSize);

            return TotalPages;
        }
        public IEnumerable<Product> GetProdsBySearch()
        {
            if (parameters.price_from <= 0) { parameters.price_from = 0; }
            if (parameters.price_to <= 0) { parameters.price_to = 0; }
            
            if(parameters.price_from > parameters.price_to && parameters.price_to > 0)
            {
                decimal swp = parameters.price_from;
                parameters.price_from = parameters.price_to;
                parameters.price_to = swp;
            }

            if (!string.IsNullOrEmpty(parameters.name))
            {
                this.prods = this.prods.Where((e) => e.Name.Equals(parameters.name));
            }
            if (parameters.manufacturer > 0)
            {
                this.prods = this.prods.Where((e) => e.Manufacturer.ManufaturerID.Equals(parameters.manufacturer));
            }
            if (parameters.price_from >= 0)
            {
                this.prods = this.prods.Where((e) => e.Price >= parameters.price_from);
            }
            if (parameters.price_to > 0)
            {
                this.prods = this.prods.Where((e) => e.Price <= parameters.price_to);
            }

            if (parameters.page <= 1) { parameters.page = 1; }
            if (parameters.page >= this.TotalPages()) { parameters.page = this.TotalPages();}

            return this.prods.Skip((this.parameters.page - 1) * this.MaxPageSize).Take(this.MaxPageSize);
        }
    }
}
