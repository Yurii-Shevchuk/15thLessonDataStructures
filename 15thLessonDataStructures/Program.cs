namespace _15thLessonDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            Shop shop = new Shop();
            ShopInterface shopUI = new ShopInterface(shop);
            while(!isExit)
            {
                shopUI.ShopMenu(ref isExit);
            }
        }
    }
}