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
        private Guid _purchaseId;
        private DateTime _purchaseTime;
        private List<Product> _boughtProductList;
        private int[] _boughtProductQuantity;
        public Receipt(User user, List<Product> productList, int[] quantityBought) 
        {
            _buyerName = user.Name;
            _boughtProductList = productList;
            _boughtProductQuantity = quantityBought;
            _purchaseId = Guid.NewGuid();
            _purchaseTime = DateTime.Now;
        }

        public int[] BoughtProductQuantity => _boughtProductQuantity;
        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0;
                int i = 0;
                foreach(var item in _boughtProductList)
                {
                    sum += item.Price * BoughtProductQuantity[i];
                    i++;
                }
                return sum;
            }
        }
        public static Receipt GenerateReceipt(User user, List<Product> productList, int[] quantityBought)
        {
            return new Receipt(user, productList, quantityBought);
        }

        public static void PrintReceipt(Receipt receipt)
        {
            int i = 0;
            Console.WriteLine($@"===== Receipt =====
Buyer: {receipt._buyerName}.");
            foreach(var product in receipt._boughtProductList)
            {
                Console.WriteLine($@"Product: {product.Name} x{receipt.BoughtProductQuantity[i]}
{product.Price:C2} for each");
                i++;
            }
            Console.WriteLine($@"
Total: {receipt.TotalPrice:C2}
Purchase Time: {receipt._purchaseTime.ToString("f")}.
Purchase ID: {receipt._purchaseId}.
====================");
        }
    }
}
