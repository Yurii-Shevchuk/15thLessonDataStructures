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
        public Shop() 
        {
            _products = new List<Product>();
            _receipts = new List<Receipt>();
            _productCart = new List<Product>();
        }
        public List<Product> Products => _products;

        public List<Product> ProductCart => _productCart;

        public List<Receipt> Receipts => _receipts;

        public void ShopMenu(ref bool isExit)
        {
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add new product");
            Console.WriteLine("3. Add a product to your cart");
            Console.WriteLine("4. Show your cart");
            Console.WriteLine("5. Proceed to checkout");
            Console.WriteLine("6. Print all receipts");
            Console.WriteLine("7. Exit the program");
            int input;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input was incorrect, please try again");
                ShopMenu(ref isExit);
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("There is no possible way this program could have THIS many functions, try better");
                ShopMenu(ref isExit);
                return;
            }
            switch (input)
            {
                case 1:
                    ListAllProducts(Products);
                    break;

                case 2:
                    AddProduct(Shop.ReadProductFromConsole());
                    break;
                case 3:
                    Console.Write("Enter name of the product you'd like to add your cart: ");
                    string productName = Console.ReadLine();
                    try
                    {
                        Product foundProduct = GetProductByName(productName);
                        AddToCart(foundProduct);
                        Console.WriteLine($"{foundProduct.Name} added to your cart, thanks for trusting us!");
                    }
                    catch 
                    {
                        Console.WriteLine($"No such product in our shop, try again");
                    }
                    break;
                case 4:
                    ListProductCart(ProductCart);
                    break;
                case 5:
                    Checkout(ProductCart);
                    break;
                case 6:
                    foreach(var receipt in Receipts)
                    {
                        Console.WriteLine(receipt);
                    }
                    break;
                case 7:
                    isExit = true;
                    return;
                default:
                    Console.WriteLine("No such operation.");
                    break;

            }
        }

        static Product ReadProductFromConsole()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine().Trim();

            Console.Write("Enter product price: ");
            decimal productPrice = Decimal.Parse(Console.ReadLine().Trim());

            Console.Write("Enter number of products in stock: ");
            int productQuantity = int.Parse(Console.ReadLine());

            return new Product(productName, productPrice, productQuantity);
        }
        private bool AddProduct(Product product)
        {
            try
            {
                Products.Add(product);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private bool Checkout(List<Product> productCart) 
        {
            int quantity = 0;
            if(productCart.Count == 0) 
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
                        Console.WriteLine($"Please enter number of {product.Name} you'd like to buy, we have {product.Quantity} in stock, each costs {product.Price}");
                        quantity = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("You made a mistake, enter a number");
                    }
                } while (quantity > product.Quantity);
                ReduceQuantityOfProduct(product, quantity);
                Receipt purchaseReceipt = GenerateReceipt(new User(), product, quantity);
                AddReceiptToList(purchaseReceipt);
            }
            Console.WriteLine("Thanks for the purchase, please come again");
            return true;
        }
        private void ReduceQuantityOfProduct(Product product, int quantity)
        {
            if(product.Quantity - quantity == 0) 
            {
                RemoveProductIfNoneLeft(Products, product);
            }
            else
            { 
                product.Quantity -= quantity; 
            }
        }

        private void RemoveProductIfNoneLeft(List<Product> products, Product product)
        {
            products.Remove(product);
        }
        private void ListAllProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        private void ListProductCart(List<Product> productCart) 
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
        private Receipt GenerateReceipt(User user, Product product, int quantity)
        {
            return new Receipt(user, product, quantity);
        }
        private void AddToCart(Product product)
        {
            ProductCart.Add(product);
        }

        private Product GetProductByName(string productName)
        {
                Product match = Products.Find(product => product.Name.ToLower().Contains(productName.ToLower()));
                return match;
        }

    }
}
