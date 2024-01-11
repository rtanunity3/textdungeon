namespace textdungeon.Play
{
    // 가중치 저장을 위한 DropItem
    public class DropItem
    {
        public Item Item { get; }
        public int Weight { get; }

        public DropItem(Item item, int weight)
        {
            Item = item;
            Weight = weight;
        }
    }

    public class ItemDropTable
    {
        // 아이템과 가중치를 저장하기 위한 테이블.
        public List<DropItem> ItemTable;
        // Drop하는 아이템 갯수.
        public int Amount { get; }
        // 총합 가중치.
        public int TotalWeight { get; private set; }

        public ItemDropTable(int amount)
        {
            ItemTable = new List<DropItem>();
            Amount = amount;
            TotalWeight = 0;
        }

        public void AddItem(Item item, int weight)
        {
            ItemTable.Add(new DropItem(item, weight));
            TotalWeight += weight;
        }

        // 가중치를 사용하여 랜덤 드랍.
        public Item PickItem()
        {
            // 총합 가중치를 이용하여 random으로 아이템 드랍.
            var random = new Random().Next(0, TotalWeight);

            foreach(var dropItem in ItemTable)
            {
                if (dropItem.Weight > random)
                {
                    return dropItem.Item;
                }
                else
                {
                    random -= dropItem.Weight;
                }
            }
            //NOTE TotalWeight 안에서 random을 돌리므로 null이 return되지는 않음.
            //NOTE 만약 ItemDropTable을 만들고, AddItem을 하지 않는다면 null이 반환 될 수 있음.
            return null;
        }

        public List<Item> ItemDrop()
        {
            var dropList = new List<Item>();
            
            // Amount만큼 아이템 drop.
            for(int i = 0; i < Amount; i++)
            {
                dropList.Add(PickItem());
            }

            return dropList;
        }
    }
}
