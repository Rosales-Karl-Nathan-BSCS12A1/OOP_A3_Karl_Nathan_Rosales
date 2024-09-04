using System;
using System.Collections.Generic;

public class MenuService : IMenuService
{
    private List<string> menuItems = new List<string>();
    private List<decimal> menuPrices = new List<decimal>();
    private List<string> orderedItems = new List<string>();
    private List<decimal> orderedPrices = new List<decimal>();

    public void AddMenuItem(string item, decimal price)
    {
        menuItems.Add(item);
        menuPrices.Add(price);
        Console.WriteLine($"{item} has been added to the menu at {price} peso(s)");
    }

    public void ViewMenu()
    {
        Console.Clear();
        if (menuItems.Count > 0)
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]} - {menuPrices[i]} peso(s)");
            }
        }
        else
        {
            Console.WriteLine("The menu is empty.");
        }
        PromptToContinue();
    }

    public void PlaceOrder()
    {
        if (menuItems.Count > 0)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the item you want to order (or type 'done' to finish):");
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {menuItems[i]} - {menuPrices[i]} peso(s)");
                }

                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

                int itemNumber;
                if (int.TryParse(input, out itemNumber) && itemNumber > 0 && itemNumber <= menuItems.Count)
                {
                    orderedItems.Add(menuItems[itemNumber - 1]);
                    orderedPrices.Add(menuPrices[itemNumber - 1]);
                    Console.WriteLine($"{menuItems[itemNumber - 1]} has been added to your order.");
                    PromptToContinue();
                }
                else
                {
                    Console.WriteLine("Invalid item number.");
                    PromptToContinue();
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("The menu is empty. Add items to the menu first.");
            PromptToContinue();
        }
    }

    public void ViewOrder()
    {
        Console.Clear();
        if (orderedItems.Count > 0)
        {
            Console.WriteLine("Your Order:");
            for (int i = 0; i < orderedItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {orderedItems[i]} - {orderedPrices[i]} peso(s)");
            }
        }
        else
        {
            Console.WriteLine("You haven't ordered anything yet.");
        }
        PromptToContinue();
    }

    public void CalculateTotal()
    {
        Console.Clear();
        if (orderedPrices.Count > 0)
        {
            decimal total = 0;
            Console.WriteLine("Order Summary:");
            for (int i = 0; i < orderedItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {orderedItems[i]} - {orderedPrices[i]} peso(s)");
                total += orderedPrices[i];
            }
            Console.WriteLine($"Total amount due: {total} peso(s)");

            // Handling payment
            Console.Write("Enter payment amount: ");
            decimal amountPaid;
            while (!decimal.TryParse(Console.ReadLine(), out amountPaid) || amountPaid < total)
            {
                Console.WriteLine($"The amount entered is insufficient. The total amount due is {total} peso(s). \nPlease enter a valid amount: ");
            }

            decimal change = amountPaid - total;
            Console.WriteLine($"Payment successful! Your change is {change} peso(s).");

            // Clear the orders after payment
            orderedItems.Clear();
            orderedPrices.Clear();
            Console.WriteLine("All orders have been cleared.");
        }
        else
        {
            Console.WriteLine("No items ordered.");
        }
        PromptToContinue();
    }

    private void PromptToContinue()
    {
        Console.WriteLine(" ");
        Console.Write("Press enter to continue...");
        Console.ReadLine();
    }
}
