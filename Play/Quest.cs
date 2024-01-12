using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string QuestName { get; set; }
        public string QuestDesc
        {
            get; set;
        }
        public int ReqLevel { get; set; } // 요구레벨
        public QuestState State { get; set; }

        // 퀘스트 목적
        public QuestType Type { get; set; } // 몬스터잡기, 장비착용, 레벨업
        public int GoalId { get; set; } // 목표 대상 ID
        public int GoalCount { get; set; } // 목표 갯수
        public int CurGoalCount { get; set; } // 현재

        // 보상
        public Item[] RewardItem { get; set; }
        public int RewardGold { get; set; }
        public int RewardExp { get; set; }


        public Quest() { }

        public Quest(int questId, string questName, string questDesc, int reqLevel, QuestState state, QuestType type, int goalId, int goalCount, Item[] items, int rewardGold, int rewardExp, int curGoalCount = 0)
        {
            QuestId = questId;
            QuestName = questName;
            QuestDesc = questDesc;
            ReqLevel = reqLevel;
            State = state;
            Type = type;
            GoalId = goalId;
            GoalCount = goalCount;
            RewardItem = items;
            RewardGold = rewardGold;
            RewardExp = rewardExp;
            CurGoalCount = curGoalCount;
        }

        // 시작은 시작할수 있는 조건 확인
        public ResponseCode QuestStart()
        {
            if (State == QuestState.NotStarted)
            {
                State = QuestState.InProgress;
                return ResponseCode.QUESTSTART;
            }
            else
            {
                return ResponseCode.BADREQUEST;
            }
        }

        // 임무목표 갱신. 진행중인 퀘스트인지 확인. 갱신할때마다 목표 완료했는지 확인
        /// <summary>
        /// 퀘스트 진행도 업데이트
        /// 
        /// 특정 몬스터를 잡는 경우 QuestProgress(몬스터ID, 잡은 수량)
        /// </summary>
        /// <param name="goalId">몬스터/장비/아이템 ID. 0이면 무조건</param>
        /// <param name="incCnt">GoalCount 증가량.</param>
        /// <returns></returns>
        public ResponseCode QuestProgress(int goalId, int incCnt)
        {
            if (State == QuestState.InProgress)
            {
                if (GoalId == goalId)
                {
                    CurGoalCount = Math.Min(CurGoalCount + incCnt, GoalCount);
                    if (CurGoalCount >= GoalCount)
                    {
                        // 퀘스트 완료처리
                        State = QuestState.ObjectiveCompleted;
                    }
                    return ResponseCode.SUCCESS;
                }
            }
            return ResponseCode.BADREQUEST;
        }

        // 보상받기는 임무목표 달성 확인
        // 완료처리는 완료조건(임무 목표, 보상 받았는지 확인) 필요 => 보상받을때 통합 처리
        public ResponseCode QuestComplete(Player player)
        {
            if (State == QuestState.ObjectiveCompleted)
            {
                // 보상이 있으면 지급
                foreach (var item in RewardItem)
                {
                    player.AddItem(item);
                }

                // 보상 골드 지급.
                // FIXME : 시간되면 골드 컨트롤도 메소드로 처리하도록 변경
                if (RewardGold > 0)
                    player.Gold += RewardGold;
                if (RewardExp > 0)
                    player.AddExp(RewardExp);

                // 완료 처리
                State = QuestState.Completed;
                return ResponseCode.QUESTDONE;
            }

            return ResponseCode.BADREQUEST;
        }

        // 어느시점에 퀘스트들을 상태 확인할 것인가?
        // 메세지 처리를 어떻게 할것인가?



        // 목록 출력시 사용
        public void ShowQuestInfo(int i)
        {
            // 퀘스트 출력
            Printing.SelectWrite(i, QuestName);
            Console.Write(" - ");
            Printing.HighlightText(EnumHandler.GetQuestStateKr(State), ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // 세부 퀘스트 내용
        public void ShowQuestDetail()
        {
            // 퀘스트 디테일한 내용 출력
            Console.WriteLine();
            Console.WriteLine(QuestName);
            Console.WriteLine();
            Console.WriteLine(QuestDesc);
            Console.WriteLine();

            switch (Type)
            {
                case QuestType.MonsterHunt:
                    Console.WriteLine($"- 몬스터 잡기 : //FIXME{GoalId} ({CurGoalCount}/{GoalCount})");
                    break;
                case QuestType.EquipItem:
                    Console.WriteLine("- 장비 착용하기");
                    break;
                case QuestType.LevelUp:
                    Console.WriteLine("- 레벨업하기");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("- 보상");

            foreach (Item item in RewardItem)
            {
                Console.WriteLine($"{item.Name} x {item.Quantity}");
            }
            Console.WriteLine($"{RewardGold} G");
            Console.WriteLine($"{RewardExp} Exp");
            Console.WriteLine();


            switch (State)
            {
                case QuestState.NotStarted:
                    Printing.SelectWriteLine(1, "수락");
                    Printing.SelectWriteLine(0, "거절");
                    break;
                case QuestState.InProgress:
                    Printing.HighlightText(EnumHandler.GetQuestStateKr(QuestState.InProgress), ConsoleColor.Cyan);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "나가기");
                    break;
                case QuestState.ObjectiveCompleted:
                    Printing.SelectWriteLine(1, "보상받기");
                    Printing.SelectWriteLine(0, "나가기");
                    break;
                case QuestState.Completed:
                    Printing.HighlightText(EnumHandler.GetQuestStateKr(QuestState.Completed), ConsoleColor.Cyan);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "나가기");
                    break;
            }

        }
    }
}
