using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    internal class ShopInterface
    {
        private Shop _shop;
        public ShopInterface(Shop shop) 
        {
            _shop = shop;
        }

        public Shop Shop => _shop;

        public void ShopMenu(ref bool isExit)
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add new product");
            Console.WriteLine("3. Restock existing product (increase quantity)");
            Console.WriteLine("4. Add a product to your cart");
            Console.WriteLine("5. Show your cart");
            Console.WriteLine("6. Proceed to checkout");
            Console.WriteLine("7. Print all receipts");
            Console.WriteLine("8. Create and switch to a new user (default is John)");
            Console.WriteLine("9. Switch to existing user");
            Console.WriteLine("10. Exit the program");
            Console.WriteLine("\n");
            Console.Write("Please choose an option: ");
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
                    Shop.ListAllProducts(Shop.Products);
                    break;

                case 2:
                    ShopManagement.AddProduct(ShopInterface.ReadProductFromConsole(), Shop.Products);
                    break;
                case 3:
                    Console.Write("Enter name of the product that needs restocking: ");
                    string productName = Console.ReadLine();
                    try
                    {
                        Product foundProduct = ShopManagement.GetProductByName(productName, Shop.Products);
                        Console.Write("Enter amount to be added: ");
                        int quantityToRestock = int.Parse(Console.ReadLine());
                        ShopManagement.RestockProduct(foundProduct, quantityToRestock);
                        Console.WriteLine($"{foundProduct.Name} has been restocked!");
                    }
                    catch
                    {
                        Console.WriteLine($"No such product in our shop or quantity is invalid, try again");
                    }
                    break;
                case 4:
                    Console.Write("Enter name of the product you'd like to add your cart: ");
                    productName = Console.ReadLine();
                    try
                    {
                        Product foundProduct = ShopManagement.GetProductByName(productName, Shop.Products);
                        ShopManagement.AddToCart(Shop.ProductCart, foundProduct);
                        Console.WriteLine($"{foundProduct.Name} added to your cart, thanks for trusting us!");
                    }
                    catch
                    {
                        Console.WriteLine($"No such product in our shop, try again");
                    }
                    break;
                case 5:
                    Shop.ListProductCart(Shop.ProductCart);
                    break;
                case 6:
                    Shop.Checkout(Shop.ProductCart, Shop.Products);
                    break;
                case 7:
                    foreach (var receipt in Shop.Receipts)
                    {
                        Receipt.PrintReceipt(receipt);
                    }
                    break;
                case 8:
                    Console.Write($"Enter new user's name or nickname: ");
                    string newUserName = Console.ReadLine().Trim();
                    ShopManagement.SwitchCurrentUser(ShopManagement.CreateNewUser(newUserName), Shop.CurrentUser);
                    ShopManagement.AddUserToList(Shop.CurrentUser, Shop.UserList);
                    break;
                case 9:
                    Console.WriteLine("Current list of user is: ");
                    foreach (var user in Shop.UserList)
                    {
                        Console.WriteLine($"{user.Name}");
                    }
                    Console.Write($"Enter user name you want to switch to: ");
                    newUserName = Console.ReadLine().Trim();
                    try
                    {
                        User foundUser = ShopManagement.GetUserByName(newUserName, Shop.UserList);
                        ShopManagement.SwitchCurrentUser(foundUser, Shop.CurrentUser);
                        Console.WriteLine($"Switched to {Shop.CurrentUser.Name}");
                    }
                    catch
                    {
                        Console.WriteLine($"No such user registered, try again");
                    }
                    break;
                case 10:
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
    }
}
