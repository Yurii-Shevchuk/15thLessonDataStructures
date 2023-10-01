using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    internal class Receipt
    {
        private string _buyerName;
        private string _productName;
        private decimal _price;
        private int _quantity;
        private Guid _purchaseId;
        private DateTime _purchaseTime;
        public Receipt(User user, Product product, int quantityBought) 
        {
            _buyerName = user.Name;
            _productName = product.Name;
            _price = product.Price;
            _quantity = quantityBought;
            _purchaseId = Guid.NewGuid();
            _purchaseTime = DateTime.Now;
        }
        public override string ToString()
        {
            return @$"===== Receipt =====
Buyer: {_buyerName}.
Product: {_productName}.
Price: {_price:C2} each.
Quantity: {_quantity}.
Total: {_price * _quantity:C2}.
Purchase Time: {_purchaseTime.ToString("f")}.
Purchase ID: {_purchaseId}.
====================";
        }
    }
}
