namespace textdungeon.Screen
{
    public enum GameState
    {
        Intro,
        ClassSelect,
        Quit,
        Village,
        Status,
        Inventory,
        Equipment,
        Store,
        StoreSale,
        StoreSell,
        DungeonGate,
        DungeonResult,
        Inn,
        Quest,
        QuestDetail,
    }

    public enum CharacterClass
    {
        None,
        Warrior,
        Mage,
        Archer,
        Thief,
        Cleric
    }

    public enum SkillType
    {
        Normal,
        Single,
        Multiple,
        Self,
    }

    public enum ResponseCode
    {
        // Blue
        SUCCESS = 0,
        BOUGHTCOMPLETE,
        SELLCOMPLETE,

        EQUIP,
        UNEQUIP,
        CONSUME,

        REST,

        QUESTSTART,
        QUESTINPROGRESS,
        QUESTUPDATE,
        QUESTDONE,

        // Red
        BADREQUEST = 200,
        ALREADYBOUGHT,
        NOTENOUGHGOLD,
    }

    public enum EquipmentType
    {
        None,
        Head,
        Body,
        Weapon,
        Shield,
        Consumable,
    }


    public enum DungeonType
    {
        None,
        Easy,
        Normal,
        Hard,
    }

    // 퀘스트의 진행상황
    public enum QuestState
    {
        NotStarted,         // 퀘스트 수락 전
        InProgress,         // 진행중
        ObjectiveCompleted, // 목표 완료
        //RewardsClaimed,     // 보상 획득
        Completed,          // 완료
    }

    // 퀘스트 타입
    public enum QuestType
    {
        None,
        MonsterHunt,        // 몬스터 사냥
        EquipItem,          // 장비 착용
        LevelUp,            // 레벨업
    }


    public static class EnumHandler
    {
        public static string GetMessage(ResponseCode responseCode)
        {
            switch (responseCode)
            {
                case ResponseCode.SUCCESS:
                    return "\n";
                case ResponseCode.BOUGHTCOMPLETE:
                    return "구매를 완료했습니다.\n";
                case ResponseCode.SELLCOMPLETE:
                    return "판매를 완료했습니다.\n";

                case ResponseCode.EQUIP:
                    return "아이템을 장착했습니다.\n";
                case ResponseCode.UNEQUIP:
                    return "장착을 해제했습니다.\n";
                case ResponseCode.REST:
                    return "휴식을 완료했습니다.\n";
                case ResponseCode.CONSUME:
                    return "아이템을 소모했습니다.\n";

                case ResponseCode.QUESTSTART:
                    return "퀘스트를 받았습니다.\n";
                case ResponseCode.QUESTINPROGRESS:
                    return "퀘스트 진행중입니다.\n";
                case ResponseCode.QUESTUPDATE:
                    return "퀘스트내용이 업데이트 되었습니다.\n";
                case ResponseCode.QUESTDONE:
                    return "퀘스트 완료했습니다.\n";

                case ResponseCode.BADREQUEST:
                    return "잘못된 입력입니다.\n";
                case ResponseCode.ALREADYBOUGHT:
                    return "이미 구매한 아이템입니다.\n";
                case ResponseCode.NOTENOUGHGOLD:
                    return "골드가 부족합니다.\n";
                default:
                    return responseCode.ToString();
            }
        }

        public static string GetjobKr(CharacterClass job)
        {
            switch (job)
            {
                case CharacterClass.Warrior:
                    return "전사";
                case CharacterClass.Mage:
                    return "마법사";
                case CharacterClass.Archer:
                    return "궁수";
                case CharacterClass.Thief:
                    return "도적";
                case CharacterClass.Cleric:
                    return "성직자";
                default:
                    return "";
            }
        }

        public static string GetSkillTypeKr(SkillType skillType)
        {
            switch (skillType)
            {
                case SkillType.Single:
                    return "단일공격";
                case SkillType.Multiple:
                    return "전체공격";
                case SkillType.Self:
                    return "본인대상";
                default:
                    return "일반공격";
            }
        }

        public static EquipmentType GetEquipmentType(int itemId)
        {
            /*
            itemId
            1001~2000 : 머리
            2001~3000 : 갑옷
            3001~4000 : 무기
            4001~5000 : 방패
            5001~6000 : 소모품
            */
            if (itemId > 1000 && itemId <= 2000)
            {
                return EquipmentType.Head;
            }
            else if (itemId > 2000 && itemId <= 3000)
            {
                return EquipmentType.Body;
            }
            else if (itemId > 3000 && itemId <= 4000)
            {
                return EquipmentType.Weapon;
            }
            else if (itemId > 4000 && itemId <= 5000)
            {
                return EquipmentType.Shield;
            }
            else if (itemId > 5000 && itemId <= 6000)
            {
                return EquipmentType.Consumable;
            }
            else
            {
                return EquipmentType.None;
            }
        }
    }

    public static class Menu
    {
        public static string[] VillageMenu = { "", "상태보기", "인벤토리", "상점", "던전입장", "휴식하기", "퀘스트" };

    }


    public static class Util
    {
        public static float GenRandomFloat()
        {
            Random random = new Random();
            return random.NextSingle();
        }

        public static int GenRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string PadRightMixedText(string text, int padLength)
        {
            int curLength = CalculateLength(text);
            int padding = padLength - curLength;
            return text.PadRight(text.Length + padding);
        }
        public static int CalculateLength(string text)
        {
            int length = 0;
            foreach (char c in text)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;
                }
                else
                {
                    length += 1;
                }
            }
            return length;
        }
    }
}
