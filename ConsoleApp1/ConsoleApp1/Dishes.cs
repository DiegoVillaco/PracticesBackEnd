using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    

    internal enum Product
    {

        Spaguetti = 1,
        Lasagna,
        Pizza,
        Calzone,
        Soda,
        Wine,
        Beer,
        Unkown

    }
    struct Order
    {

        public Product Product;
        public double Quantity;
        public double Subtotal;
    }
}
    
