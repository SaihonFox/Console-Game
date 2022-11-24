using Console_Game;

class Inventory
{
    List<Items> items = new List<Items>();

    public Inventory() {}

    public void addItem(Items item)
    {
        items.Add(item);
    }

    public void removeAllItem()
    {

    }

    public void openInventory()
    {
        Console.Clear();
        Console.WriteLine("");
    }

    public void closeInventory()
    {

    }
}