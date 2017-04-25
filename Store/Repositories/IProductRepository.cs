using IBatisNet.DataMapper;
using Store.Common;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Repositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
    }
}