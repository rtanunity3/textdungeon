using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Skill
    {
        public SkillType SkillType { get; } // 스킬타입. 회피확률, 단일/복수타겟 판단
        public string Name { get; } // 스킬명
        public float DamagePercentage { get; } // 데미지 %
        public int Mana { get; } // 사용 마나

        public Skill(string name, float damagePercentage, int mana, SkillType skillType)
        {
            Name = name;
            DamagePercentage = damagePercentage;
            Mana = mana;
            SkillType = skillType;
        }

        /*
        전사 
            강격 : 딜*120%  마나 5
            이중타격 : 딜*180% 마나 15
        마법사
            불화살 : 딜*130% 마나 5
            블리자드 : 딜*120% 전체공격 마나 20
        궁수
            연사 : 딜*90% 전체공격 마나 10
            저격 : 딜*220% 마나 20
        도적
            기습 : 딜*150% 마나 10
            함정 : 딜*200% 마나 15
        성직자
            신성타격 : 딜*150% 마나 10
            치료 : 딜*150% 마나 10
        */
    }
}