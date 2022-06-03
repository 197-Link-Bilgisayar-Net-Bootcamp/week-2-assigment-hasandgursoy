using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class Create_Product_Dto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
    }
}
