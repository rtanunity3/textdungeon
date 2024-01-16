namespace textdungeon.Play
{
    internal class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (Item item in items)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

    }
}
