using Store.Models;
using System.Collections.Generic;

namespace Store.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> FindAll()
        {
            return (List<Product>)Common.Mapper.GetMapper.QueryForList<Product>("FindAll", null);
        }
    }
}