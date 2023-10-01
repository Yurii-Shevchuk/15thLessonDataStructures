namespace _15thLessonDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            Shop shop = new Shop();
            while(!isExit)
            {
                shop.ShopMenu(ref isExit);
            }
        }
    }
}