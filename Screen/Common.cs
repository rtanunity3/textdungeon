namespace textdungeon.Screen
{
    public enum GameState
    {
        Intro,
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
        BattleGround,
        BattleAttack,
        BattleAttackEnd,
        BattleSkillList,
        BattleSkillAttack,
        BattleEnemiesAttack
    }

    public enum ResponseCode
    {
        // Blue
        SUCCESS = 0,
        BOUGHTCOMPLETE,
        SELLCOMPLETE,

        EQUIP,
        UNEQUIP,

        REST,

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
    }


    public enum DungeonType
    {
        None,
        Easy,
        Normal,
        Hard,
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

        public static EquipmentType GetEquipmentType(int itemId)
        {
            /*
            itemId
            1001~2000 : 머리
            2001~3000 : 갑옷
            3001~4000 : 무기
            4001~5000 : 방패
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
            else
            {
                return EquipmentType.None;
            }
        }
    }
    public static class Util
    {
        public static int GenRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
