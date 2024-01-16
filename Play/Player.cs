using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Equipment
    {
        public int Head { get; set; }
        public int Body { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
    }

    public class Player : ICharacter
    {
        public string Name { get; set; }
        public CharacterClass Job { get; set; }
        public int AttPow { get; set; }
        public int ItemAttPow { get; set; }
        public int DefPow { get; set; }
        public int ItemDefPow { get; set; }
        public int MaxHealth { get; set; } // 차후 아이템 사용시 체크를 위해 Max 값을 넣음
        public int Health { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; } // 누적경험치 입니다.
        public int DisplayExp { get; set; } // 화면상에 보여질 경험치
        public bool IsDead => Health <= 0; // IsDead가 호출될때 작동
        public int NormalDamage => AttPow + ItemAttPow; // 기본공격시 대미지

        public List<Skill> Skill { get; set; } = new List<Skill>() { new Skill("", 1f, 0, SkillType.Self) };
        public Equipment Equipped { get; set; }
        public List<Item> Items { get; set; } = new List<Item>() { new Item(false, false, 0, 0, 0, "", "", 0) };
        public List<Quest> QuestList { get; set; }

        public JsonElement ClassBaseInfo;
        int[] itemTableColWidth = { 24, 37, 50, 103, 113 };
        int itemInfoTableTop = 4;

        public Player() { }
        public Player(string name, CharacterClass select)
        {
            Name = name;
            Job = select;
            SetStats(); // 집업별 스탯 세팅

            Level = 1;
            Exp = 0;
            DisplayExp = 0;

            ItemAttPow = 0;
            ItemDefPow = 0;

            Equipped = new Equipment();
        }

        public void LoadClassInfo()
        {
            string jsonFilePath = "data/Class.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            JsonDocument ClassObj = JsonDocument.Parse(jsonContent);

            ClassBaseInfo = ClassObj.RootElement.GetProperty("CharacterClass").GetProperty(Job.ToString());
        }

        private void SetStats()
        {
            LoadClassInfo();
            //Debug.WriteLine(jobObj.ToString());
            AttPow = ClassBaseInfo.GetProperty("AttPow").GetInt32();
            DefPow = ClassBaseInfo.GetProperty("DefPow").GetInt32();
            MaxHealth = ClassBaseInfo.GetProperty("MaxHealth").GetInt32();
            Health = ClassBaseInfo.GetProperty("Health").GetInt32();
            MaxMana = ClassBaseInfo.GetProperty("MaxMana").GetInt32();
            Mana = ClassBaseInfo.GetProperty("Mana").GetInt32();
            Gold = ClassBaseInfo.GetProperty("Gold").GetInt32();

            for (int i = 0; i < ClassBaseInfo.GetProperty("Skill").GetArrayLength(); i++)
            {
                JsonElement skill = ClassBaseInfo.GetProperty("Skill")[i];
                if (Enum.TryParse<SkillType>(skill.GetProperty("SkillType").GetString(), out SkillType thisType))
                {
                    Skill.Add(new Skill(
                        skill.GetProperty("Name").GetString(),
                        skill.GetProperty("DamagePercentage").GetSingle(),
                        skill.GetProperty("Mana").GetInt32(),
                        thisType
                    ));
                }
            }


            // !HACK : 아이템을 생성하는게 아닌 아이템 ID만 넣어 놓고
            //        보상 받을때 ItemID를 통해서 해당아이템을 새로 생성해서 넣어줘야함.
            //        개발편의를 위해 지금처럼 진행하겠음.
            //        퀘스트 레벨제한 미구현
            QuestList = new List<Quest>()
            {
                new Quest(0, "", "", 9999, QuestState.Completed, QuestType.None, 0, 0, Array.Empty<Item>(), 0, 0),
                new Quest(1, "마을을 위협하는 적 처치", "이봐! 마을 근처에 적들이 너무 많아졌다고 생각하지 않나?\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!"
                    , 1, QuestState.NotStarted, QuestType.MonsterHunt, 0, 5, new Item[]{ ItemManager.GetLowTierShield(), new HealingPotion(1) }, 500, 5),
                new Quest(2, "장비를 장착해보자", "전투에서 사용할 장비를 구매 후 장착해보자!"
                    , 1, QuestState.NotStarted, QuestType.EquipItem, 0, 1, new Item[]{ ItemManager.GetLowTierHelmet(Job) }, 500, 1),
                new Quest(3, "더욱 더 강해지기!", "레벨업을 하면 더욱 강해집니다!"
                    , 1, QuestState.NotStarted, QuestType.LevelUp, 0, 1, new Item[]{ ItemManager.GetLowTierArmor(Job), new HealingPotion(1), new ManaPotion(1) }, 1500, 0),
                new Quest(4, "고블린슬레이어", "고블린 100마리의 목을 쳐라!"
                    , 1, QuestState.NotStarted, QuestType.MonsterHunt, 2, 100, new Item[]{ ItemManager.GetMediumTierArmor(Job), new HealingPotion(5) }, 2000, 0),
                new Quest(5, "드래곤슬레이어", "드래곤을 잡고 이세계의 신이 됩니다."
                    , 1, QuestState.NotStarted, QuestType.MonsterHunt, 23, 1, new Item[]{ ItemManager.GetHighTierArmor(Job), new HealingPotion(5) }, 2000, 0),
            };
        }

        public Player GetPlayer()
        {
            return this;
        }

        public int ItemCount()
        {
            return Items.Count;
        }

        public void DisplayCharacterStatus()
        {
            CalcItemStat();

            Console.Clear();

            Console.SetCursorPosition(30, 3);
            Printing.HighlightText("착용장비", ConsoleColor.DarkYellow);
            Console.SetCursorPosition(30, 4);
            Console.WriteLine($"투구 : {GetItemName(Equipped.Head)}");
            Console.SetCursorPosition(30, 5);
            Console.WriteLine($"갑옷 : {GetItemName(Equipped.Body)}");
            Console.SetCursorPosition(30, 6);
            Console.WriteLine($"무기 : {GetItemName(Equipped.Weapon)}");
            Console.SetCursorPosition(30, 7);
            Console.WriteLine($"방패 : {GetItemName(Equipped.Shield)}");
            Console.SetCursorPosition(0, 0);

            Printing.HighlightText("상태 보기", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            //필요경험치 = Level * Level , 추후 변경해야함
            // Level ^ 2 + Level * 3
            Console.WriteLine($"Lv.: {Level:D2} (Exp:{DisplayExp}/{Math.Pow(Level, 2) + Level * 3})");
            Printing.HighlightText($"{Name} ({EnumHandler.GetjobKr(Job)})\n", ConsoleColor.White);

            //
            Console.Write("HP : ");
            Printing.HighlightText($"{Health,3}/{MaxHealth}\n", ConsoleColor.Red);
            Console.Write("MP : ");
            Printing.HighlightText($"{Mana,3}/{MaxMana}\n", ConsoleColor.Blue);

            //
            Console.Write($"공격력 : {AttPow + ItemAttPow,2}");
            if (ItemAttPow > 0) { Printing.HighlightText($" (+{ItemAttPow,2})", ConsoleColor.Cyan); }
            Console.WriteLine();
            Console.Write($"방어력 : {DefPow + ItemDefPow,2}");
            if (ItemDefPow > 0) { Printing.HighlightText($" (+{ItemDefPow,2})", ConsoleColor.Cyan); }
            Console.WriteLine();

            //
            Console.Write("Gold : ");
            Printing.HighlightText($"{Gold} G\n", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine();


            Printing.HighlightText("스킬\n", ConsoleColor.DarkYellow);
            Printing.SkillInfoTableTitle();

            for (int i = 1; i < Skill.Count; i++)
            {
                Console.Write($"[{i}] : {Util.PadRightMixedText(Skill[i].Name, 10)}");
                Console.Write($"{Util.PadRightMixedText(EnumHandler.GetSkillTypeKr(Skill[i].SkillType), 10)}");
                Printing.HighlightText($"{Skill[i].Mana}".PadRight(10), ConsoleColor.Blue);
                Console.Write($"{Skill[i].DamagePercentage * 100:F0}%");
                double skillDmg = (AttPow + ItemAttPow) * Skill[i].DamagePercentage;
                Printing.HighlightText($" [{Math.Floor(skillDmg * 0.9):F0}-{Math.Ceiling(skillDmg * 1.1):F0}]", ConsoleColor.Red);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void DisplayInventory()
        {
            Console.Clear();
            Printing.HighlightText("인벤토리", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.ItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);
            for (int i = 1; i < Items.Count; i++)
            {
                Items[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, false, false);
            }
            Console.WriteLine();
            Printing.SelectWriteLine(1, "장착 관리");
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void EquipmentManager()
        {
            Console.Clear();
            Printing.HighlightText("인벤토리 - 장착관리", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.ItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);
            for (int i = 1; i < Items.Count; i++)
            {
                Items[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, true, false);
            }
            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public ResponseCode Equipment(int select)
        {
            EquipmentType type = EnumHandler.GetEquipmentType(Items[select].ItemId);

            if (select > 0 && select < Items.Count)
            {
                // 소모품 사용. 소모품의 경우 다운캐스팅을 사용해 UseItem Method를 호출.
                if (type == EquipmentType.Consumable)
                {
                    var item = (ConsumableItem)Items[select];
                    if (item.UseItem(this))
                        RemoveItem(item);

                    return ResponseCode.CONSUME;
                }
                else if (Items[select].IsEquipped == true)
                {
                    // 이미 장착한 아이템이면 해제
                    Items[select].IsEquipped = false;
                    switch (type)
                    {
                        case EquipmentType.Head: Equipped.Head = 0; break;
                        case EquipmentType.Body: Equipped.Body = 0; break;
                        case EquipmentType.Weapon: Equipped.Weapon = 0; break;
                        case EquipmentType.Shield: Equipped.Shield = 0; break;
                    }
                    CalcItemStat();
                    return ResponseCode.UNEQUIP;
                }
                else
                {
                    // 착용중인 아이템 해제하고 장착 || 그냥 장착
                    UnEquipTypeItem(type);
                    Items[select].IsEquipped = true;
                    switch (type)
                    {
                        case EquipmentType.Head:
                            Equipped.Head = Items[select].ItemId; break;
                        case EquipmentType.Body:
                            Equipped.Body = Items[select].ItemId; break;
                        case EquipmentType.Weapon:
                            Equipped.Weapon = Items[select].ItemId; break;
                        case EquipmentType.Shield:
                            Equipped.Shield = Items[select].ItemId; break;
                    }
                    CalcItemStat();

                    UpdateQuestProgress(QuestType.EquipItem, 0, 1);
                    // 메세지 만들어서 리턴
                    return ResponseCode.EQUIP;
                }
            }
            CalcItemStat();
            return ResponseCode.BADREQUEST;
        }

        public void EquipItemAll()
        {
            foreach (var item in Items)
            {
                if (item.IsEquipped == true)
                {
                    EquipmentType type = EnumHandler.GetEquipmentType(item.ItemId);
                    UnEquipTypeItem(type);
                    item.IsEquipped = true;
                    switch (type)
                    {
                        case EquipmentType.Head:
                            Equipped.Head = item.ItemId; break;
                        case EquipmentType.Body:
                            Equipped.Body = item.ItemId; break;
                        case EquipmentType.Weapon:
                            Equipped.Weapon = item.ItemId; break;
                        case EquipmentType.Shield:
                            Equipped.Shield = item.ItemId; break;
                    }
                }
            }
            CalcItemStat();
        }

        public void UnEquipItem(int itemId)
        {
            foreach (var item in Items)
            {
                if (item.ItemId == itemId)
                {
                    item.IsEquipped = false;
                }
            }
            if (Equipped.Head == itemId)
            {
                Equipped.Head = 0;
            }
            else if (Equipped.Body == itemId)
            {
                Equipped.Body = 0;
            }
            else if (Equipped.Weapon == itemId)
            {
                Equipped.Weapon = 0;
            }
            else if (Equipped.Shield == itemId)
            {
                Equipped.Shield = 0;
            }
        }

        public void UnEquipTypeItem(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Head:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 1000 && item.ItemId <= 2000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Body:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 2000 && item.ItemId <= 3000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Weapon:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 3000 && item.ItemId <= 4000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Shield:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 4000 && item.ItemId <= 5000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
            }
        }

        public string GetItemName(int itemId)
        {
            foreach (var item in Items)
            {
                if (item.ItemId == itemId)
                {
                    return item.Name;
                }
            }
            return " - ";
        }

        public void CalcItemStat()
        {
            ItemAttPow = 0;
            ItemDefPow = 0;

            foreach (var item in Items)
            {
                if (item.IsEquipped)
                {
                    ItemAttPow += item.ItemAttPow;
                    ItemDefPow += item.ItemDefPow;
                }
            }
        }

        public void CalcLevel()
        {
            //레벨업
            int maxExp = (int)Math.Pow(Level, 2) + Level * 3;

            while (maxExp <= Exp)
            {
                Level++;
                Exp -= maxExp;
                maxExp = (int)Math.Pow(Level, 2) + Level * 3;
                Console.WriteLine($"축하합니다. {Name}의 레벨이 {Level - 1}에서 {Level}로 상승했습니다");
                UpdateQuestProgress(QuestType.LevelUp, 0, 1);


                // TODO : 레벨 기준 공방 업데이트
                AttPow += (int)((Level - 1) * 0.5); // 소수점은 버림
                DefPow += (Level - 1);
                MaxHealth += (Level - 1) * 20;
                MaxMana += (Level - 1) * 10;
                Health = MaxHealth; //Math.Min(Health + ((Level - 1) * 20), MaxHealth);
                Mana = MaxMana; //Math.Min(Mana + (Level - 1) * 10, MaxMana);
            }
            DisplayExp = Exp;

        }

        public void AddExp(int exp)
        {
            Exp += exp;
            CalcLevel();
        }

        public void AddItem(Item item)
        {
            // 가지고 있는 아이템이면 수량 추가.
            var existItem = Items.Find(x => x.ItemId == item.ItemId);
            if (existItem != null)
            {
                existItem.Quantity += 1;
            }
            else
            {
                // 객체를 그대로 가져오면 상점과 공유하게 되니 ShallowCopy 통해 추가.
                Items.Add((Item)item.ShallowCopy());
                Items.Sort(new ItemIdComparer());
                //Items.OrderByDescending(item => item.ItemId).ToList();
            }


        }

        // ItemDropTable이 list로 item들을 return하여 list로 아이템을 받는 Method추가.
        public void AddItem(List<Item> list)
        {
            foreach (var item in list)
            {
                // 가지고 있는 아이템이면 수량 추가.
                var existItem = Items.Find(x => x.ItemId == item.ItemId);
                if (existItem != null)
                {
                    existItem.Quantity += 1;
                }
                else
                {
                    // 객체 공유를 피하기 위한 ShallowCopy.
                    Items.Add((Item)item.ShallowCopy());
                    Items.Sort(new ItemIdComparer());
                }
            }
        }

        public void RemoveItem(Item item)
        {
            // 아이템의 수량이 여러개일 경우 판정.
            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
            }
            else
            {
                Items.Remove(item);
            }
        }

        public void ShowSkillList(int skillNo = 0)
        {
            if (skillNo > 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append($"{Skill[skillNo].Name} - MP {Skill[skillNo].Mana}\n   공격력 * {Skill[skillNo].DamagePercentage} 로 ");
                switch (Skill[skillNo].SkillType)
                {
                    case SkillType.Single:
                        str.Append($"하나의 적을 공격합니다.");
                        break;
                    case SkillType.Multiple:
                        str.Append($"적 전체를 공격합니다.");
                        break;
                    case SkillType.Self:
                        str.Append($"자신에게 주문을 겁니다.");
                        break;
                }

                Console.WriteLine("[선택된 스킬]");
                Console.WriteLine(str.ToString());
                return;
            }

            for (int i = 1; i < Skill.Count; i++)
            {
                StringBuilder str = new StringBuilder();
                str.Append($"{Skill[i].Name} - MP {Skill[i].Mana}\n   공격력 * {Skill[i].DamagePercentage} 로 ");
                switch (Skill[i].SkillType)
                {
                    case SkillType.Single:
                        str.Append($"하나의 적을 공격합니다.");
                        break;
                    case SkillType.Multiple:
                        str.Append($"적 전체를 공격합니다.");
                        break;
                    case SkillType.Self:
                        str.Append($"자신에게 주문을 겁니다.");
                        break;
                }

                Printing.SelectWriteLine(i, str.ToString());
            }
        }

        public SkillType GetSkillType(int select)
        {
            return Skill[select].SkillType;
        }


        /// <summary>
        /// 저장/불러오기
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            return JsonSerializer.Serialize(this, options);
        }

        public static Player Deserialize(string jsonData)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            // TODO : 케릭터 데이터가 변하는 경우 호환성을 위한 체크를 해줘야함. 이번 과제에서는 다루지 않겠음.
            return JsonSerializer.Deserialize<Player>(jsonData, options);
        }




        //////////////////////////////////////////////////////////////////
        //// XXX : 퀘스트 받는곳을 따로 만드려 했으나 시간관계상 생략.
        //// 이하 퀘스트 관련
        //////////////////////////////////////////////////////////////////

        public int GetAllQuestCount()
        {
            return QuestList.Count;
        }

        // 진행중이거나 목표 완수한 퀘스트 개수
        public int GetShowableQuestCount()
        {
            return QuestList.Count(q => q.State != QuestState.Completed);
        }


        public void ShowAllQuestInfo()
        {
            Console.Clear();
            Printing.HighlightText("Quest!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine();

            //Debug.WriteLine($"QuestList.Count : {QuestList.Count}");
            for (int i = 1; i < QuestList.Count; i++)
            {
                QuestList[i].ShowQuestInfo(i);
            }
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void ShowQuestDetail(int select)
        {
            Console.Clear();
            Printing.HighlightText("Quest!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine();
            QuestList[select].ShowQuestDetail();
        }

        public ResponseCode UpdateQuest(int questId)
        {
            if (QuestList[questId].State == QuestState.NotStarted)
            {
                return QuestList[questId].QuestStart();
            }
            else if (QuestList[questId].State == QuestState.ObjectiveCompleted)
            {
                return QuestList[questId].QuestComplete(this);
            }
            return ResponseCode.BADREQUEST;
        }

        public QuestState GetQuestState(int questId)
        {
            return QuestList[questId].State;
        }


        public void UpdateQuestProgress(QuestType type, int goalId, int count)
        {
            foreach (Quest quest in QuestList)
            {
                if (quest.Type == type && quest.State == QuestState.InProgress)
                {
                    quest.QuestProgress(goalId, count);
                }
            }
        }
    }
}
