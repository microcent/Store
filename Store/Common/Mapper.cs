using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Store.Common
{
    public class Mapper
    {
        private static volatile ISqlMapper mapper = null;

        public static void Configure(object obj)
        {
            mapper = (ISqlMapper)obj;
        }

        public static void InitMapper()
        {
            ConfigureHandler hanlder = new ConfigureHandler(Configure);

            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("Config/sqlmap.config", hanlder);
        }

        public static ISqlMapper GetMapper
        {
            get
            {
                if (mapper == null)
                {
                    lock (typeof(ISqlMapper))
                    {
                        if (mapper == null)
                        {
                            InitMapper();
                        }
                    }
                }
                return mapper;
            }
        }
    }
}