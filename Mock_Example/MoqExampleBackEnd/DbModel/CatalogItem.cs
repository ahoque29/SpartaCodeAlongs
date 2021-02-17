using System;
using System.Collections.Generic;
using System.Text;

namespace MoqExampleBackEnd.DbModel
{
    public class CatalogItem
    {
        public int CatalogItemId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Brand} {Name} £{Price:f2}";
        }
    }
}
