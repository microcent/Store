using Autofac;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Common
{
    public class ContainerManager
    {
        public static IContainer Container { get; set; }

        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        static ContainerManager()
        {
            RegisterRepository();
            Container = Builder.Build();
        }

        private static void RegisterRepository()
        {
            Builder.RegisterType<ProductRepository>().As<IProductRepository>();
        }
    }
}