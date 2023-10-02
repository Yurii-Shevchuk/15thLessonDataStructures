using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    internal class Shop
    {
        private List<Product> _products;
        private List<Receipt> _receipts;
        private List<Product> _productCart;
        private List<User> _users;

        private User _currentUser;
        public Shop() 
        {
            _products = new List<Product>();
            _receipts = new List<Receipt>();
            _productCart = new List<Product>();
            _users = new List<User>();
            _currentUser = new User();
        }
        public List<Product> Products => _products;

        public List<Product> ProductCart => _productCart;

        public List<Receipt> Receipts => _receipts;

        public User CurrentUser
        {
            get => _currentUser; 
            private set => _currentUser = value;
        }
        public List<User> UserList
        {
            get => _users;
            private set => _users = value;
        }





        public bool Checkout(List<Product> productCart, List<Product> allProducts)
        {
            int[] boughtQuantity = new int[productCart.Count];
            int i = 0;
            int quantity = 0;
            if (productCart.Count == 0)
            {
                Console.WriteLine("Your shopping cart is currently empty, come back when you choose something!");
                return false;
            }
            foreach (Product product in productCart)
            {
                do
                {
                    try
                    {
                        Console.WriteLine($"Please enter number of {product.Name} you'd like to buy, we have {product.Quantity} in stock, each costs {product.Price:C2}");
                        quantity = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("You made a mistake, enter a number");
                    }
                } while (quantity > product.Quantity);
                boughtQuantity[i] = quantity;
                i++;
                ShopManagement.ReduceQuantityOfProduct(product, quantity, Products);
            }
            Receipt purchaseReceipt = Receipt.GenerateReceipt(CurrentUser, ProductCart, boughtQuantity);
            AddReceiptToList(purchaseReceipt);
            Console.WriteLine("Thanks for the purchase, please come again");
            return true;
        }


        public void ListAllProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void ListProductCart(List<Product> productCart) 
        {
            foreach(var product in productCart)
            {
                Console.WriteLine($"{product.Name}, {product.Price:C2} each");
            }
        }

        private void AddReceiptToList(Receipt receipt)
        {
            Receipts.Add(receipt);
        }

    }
}
