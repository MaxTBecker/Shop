using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification()
        {
            AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);
        }

        public ProductsWithTypeAndBrandsSpecification(int id) 
            : base(x=>x.Id == id)
        {
            AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);
        }
    }
}