using System;

class Program
{
    static void Main()
    {
        IMenuService menuService = new MenuService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 - Add Menu Item");
            Console.WriteLine("2 - View Menu");
            Console.WriteLine("3 - Place Order");
            Console.WriteLine("4 - View Order");
            Console.WriteLine("5 - Calculate Total");
            Console.WriteLine("6 - Exit");
            Console.Write("Enter a command: ");
            string command = Console.ReadLine();

            if (command == "1")
            {
                Console.Clear();
                Console.Write("Enter new menu item: ");
                string newItem = Console.ReadLine();
                Console.Write("Enter price of the item: ");
                decimal newPrice;
                while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
                {
                    Console.Write("Invalid price. Please enter a valid price: ");
                }
                menuService.AddMenuItem(newItem, newPrice);
            }
            else if (command == "2")
            {
                menuService.ViewMenu();
            }
            else if (command == "3")
            {
                menuService.PlaceOrder();
            }
            else if (command == "4")
            {
                menuService.ViewOrder();
            }
            else if (command == "5")
            {
                menuService.CalculateTotal();
            }
            else if (command == "6")
            {
                Console.WriteLine("Exiting the application.");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid command. Please try again.");
                Console.Write("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
