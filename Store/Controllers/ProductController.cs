using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Store.Models;
using Store.Attributes;
using Store.Common;
using Store.Repositories;
using Autofac;

namespace Store.Controllers
{
    [ApiAuthorize]
    [RoutePrefix("api/product")]
    public class ProductController : BaseController
    {

        private readonly IProductRepository _repository= ContainerManager.Container.Resolve<IProductRepository>();

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        /// <summary>
        /// 获取单个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:int}")]
        public ResponseEntity GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product != null)
            {
                return ResponseEntity.success(product);
            }
            else
            {
                return new ResponseEntity(ResponseStatus.NOT_FOUND);
            }
        }

        /// <summary>
        /// 产品分页数据获取
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet, Route("list/{pageNo:int}/{pageSize:int}")]
        public ResponseEntity GetList(int pageNo, int pageSize)
        {
            int recordCount = 100;
            List<Product> list = _repository.FindAll();
            Page<Product> page = new Page<Product>(pageNo, pageSize, recordCount, list);
            return ResponseEntity.success(page);
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResponseEntity AddProduct([FromBody] Product product)
        {
            return ResponseEntity.success(product);
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResponseEntity UpdateProduct([FromBody] Product product)
        {
            return ResponseEntity.success(product);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("del/{id:int}")]
        public ResponseEntity DeleteProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product != null)
            {
                return ResponseEntity.success("del:" + id);
            }
            else
            {
                return new ResponseEntity(ResponseStatus.NOT_FOUND);
            }
        }
    }
}