using System.Collections.Generic;
using Shop.Core;
using Shop.Data.DTO;

namespace Shop.Data
{
    internal class Categorization
    {
        public List<ProductDto> AddCategoryForWhatProduct(List<ProductDto> allProducts)
        {
            allProducts.ForEach(p =>
            {
                if (p.Grill != null) p.CategoryId = (int)Category.Microwaves;
                if (p.Filter != null) p.CategoryId = (int)Category.VacuumCleanrs;
                if (p.Material != null) p.CategoryId = (int)Category.ElectricKettles;
            });
            return allProducts;
        }
    }
}
