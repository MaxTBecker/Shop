using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(ProductSpecParams productParams)
        : base(x=> 
        (string.IsNullOrEmpty(productParams.Search)|| x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            
            AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(x=>x.Name);
                    break;
            }

        }

        public ProductsWithTypeAndBrandsSpecification(int id) 
            : base(x=>x.Id == id)
        {
            AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);
        }
    }
}