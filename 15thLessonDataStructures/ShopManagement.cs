using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    public class ShopManagement
    {
       
        internal static void AddProduct(Product product, List<Product> Products)
        {
            if (product != null)
            {
               Products.Add(product);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        

        internal static void ReduceQuantityOfProduct(Product product, int quantity, List<Product> productList)
        {
            if (product.Quantity - quantity == 0)
            {
                RemoveProductIfNoneLeft(productList, product);
            }
            else
            {
                product.Quantity -= quantity;
            }
        }

        internal static void RestockProduct(Product product, int quantity)
        {
            product.Quantity += quantity;
        }

        internal static void RemoveProductIfNoneLeft(List<Product> products, Product product)
        {
            products.Remove(product);
        }

        internal static void AddToCart(List<Product> productList, Product product)
        {
            productList.Add(product);
        }

        internal static Product GetProductByName(string productName, List<Product> productList)
        {
            Product match = productList.Find(product => product.Name.ToLower().Contains(productName.ToLower()));
            return match == null ? throw new NullReferenceException() : match;
        }

        internal static User GetUserByName(string userName, List<User> userList)
        {
            User match = userList.Find(user => user.Name.ToLower().Contains(userName.ToLower()));
            return match == null ? throw new NullReferenceException() : match;
        }
        internal static User CreateNewUser(string name)
        {
            return new User(name);
        }

        internal static void AddUserToList(User user, List<User> userList)
        {
            userList.Add(user);
        }

        internal static void SwitchCurrentUser(User user, User currentUser)
        {
            if (user != null)
            {
                currentUser = user;
            }
            else
            {
                throw new NullReferenceException();
            }
        }


    }
}
