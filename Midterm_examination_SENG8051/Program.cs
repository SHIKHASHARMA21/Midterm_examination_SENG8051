using System;
using System.Collections.Generic;

public class InventoryItem
{
    public string Name { get; set; }
    public int ID { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public InventoryItem(string name, int id, double price, int quantity)
    {
        Name = name;
        ID = id;
        Price = price;
        Quantity = quantity;
    }

    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
        Console.WriteLine($"Price updated for {Name} (ID: {ID}) to {Price:C}");
    }

    public void RestockItem(int additionalQuantity)
    {
        Quantity += additionalQuantity;
        Console.WriteLine($"{additionalQuantity} {Name}(s) (ID: {ID}) added to the stock. New quantity: {Quantity}");
    }

    public void SellItem(int quantitySold)
    {
        if (quantitySold <= Quantity)
        {
            Quantity -= quantitySold;
            Console.WriteLine($"{quantitySold} {Name}(s) (ID: {ID}) sold. Remaining quantity: {Quantity}");
        }
        else
        {
            Console.WriteLine($"Error: Not enough {Name}(s) (ID: {ID}) in stock to sell {quantitySold}");
        }
    }

    public bool IsInStock()
    {
        return Quantity > 0;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Item Details:\nName: {Name}\nID: {ID}\nPrice: {Price:C}\nQuantity: {Quantity}\n");
    }
}

class Program
{
    static void Main()
    {
        List<InventoryItem> inventory = new List<InventoryItem>();


        inventory.Add(new InventoryItem("Laptop", 101, 999.99, 10));
        inventory.Add(new InventoryItem("Phone", 102, 499.99, 5));

        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Add Item to Inventory");
            Console.WriteLine("3. Update Item Price");
            Console.WriteLine("4. Restock Item");
            Console.WriteLine("5. Sell Item");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Display Inventory
                    Console.WriteLine("\nCurrent Inventory:");
                    foreach (var item in inventory)
                    {
                        item.PrintDetails();
                    }
                    break;

                case 2:
                    // Add Item to Inventory
                    Console.Write("\nEnter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter item ID: ");
                    int itemId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter item price: ");
                    double itemPrice = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter initial quantity: ");
                    int initialQuantity = Convert.ToInt32(Console.ReadLine());

                    inventory.Add(new InventoryItem(itemName, itemId, itemPrice, initialQuantity));
                    Console.WriteLine($"{itemName} added to the inventory.\n");
                    break;

                case 3:
                    // Update Item Price
                    Console.Write("\nEnter the item ID to update price: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    InventoryItem itemToUpdate = inventory.Find(item => item.ID == updateId);

                    if (itemToUpdate != null)
                    {
                        Console.Write("Enter the new price: ");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        itemToUpdate.UpdatePrice(newPrice);
                    }
                    else
                    {
                        Console.WriteLine("Item not found in the inventory.\n");
                    }
                    break;

                case 4:
                    // Restock Item
                    Console.Write("\nEnter the item ID to restock: ");
                    int restockId = Convert.ToInt32(Console.ReadLine());
                    InventoryItem itemToRestock = inventory.Find(item => item.ID == restockId);

                    if (itemToRestock != null)
                    {
                        Console.Write("Enter the quantity to restock: ");
                        int restockQuantity = Convert.ToInt32(Console.ReadLine());
                        itemToRestock.RestockItem(restockQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Item not found in the inventory.\n");
                    }
                    break;

                case 5:
                    // Sell Item
                    Console.Write("\nEnter the item ID to sell: ");
                    int sellId = Convert.ToInt32(Console.ReadLine());
                    InventoryItem itemToSell = inventory.Find(item => item.ID == sellId);

                    if (itemToSell != null)
                    {
                        Console.Write("Enter the quantity to sell: ");
                        int sellQuantity = Convert.ToInt32(Console.ReadLine());
                        itemToSell.SellItem(sellQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Item not found in the inventory.\n");
                    }
                    break;

                case 6:
                    // Exit
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.\n");
                    break;
            }
        }
    }
}
