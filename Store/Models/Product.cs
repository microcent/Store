using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Store.Models
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}