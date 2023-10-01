using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    internal class Product
    {
        private string _name;
        private decimal _price;
        private int _quantity;

        public Product(string name, decimal price = 0m, int quantity = 0) 
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        }

        public string Name => _name;
        public decimal Price => _price;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value > 0 ? value : 0; }
        }

        public override string ToString()
        {
            return $"{Name}, costs only {Price:C2}, we've got {Quantity} left";
        }

    }
}
