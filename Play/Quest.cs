using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Quest
    {
        public int QuestId { get; }
        public string QuestName { get; }
        public string QuestDesc { get; }
        public int RequiredLevel { get; } // 요구레벨
        public QuestState State { get; set; }

        // 퀘스트 목적
        public QuestType Type { get; } // 몬스터잡기, 장비착용, 레벨업
        public int GoalId { get; } // 목표 대상 ID
        public int GoalCount { get; } // 목표 갯수
        public int CurGoalCount { get; } // 현재

        // 보상
        public Item[] RewardItem { get; set; }
        public int RewardGold { get; set; }


        public Quest() { }

        //


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
        public ResponseCode QuestProgress()
        {


            return ResponseCode.BADREQUEST;
        }

        // 보상받기는 임무목표 달성 확인
        // 완료처리는 완료조건(임무 목표, 보상 받았는지 확인) 필요 => 보상받을때 통합 처리
        public ResponseCode QuestComplete()
        {


            return ResponseCode.BADREQUEST;
        }

        // 어느시점에 퀘스트들을 상태 확인할 것인가?
        // 메세지 처리를 어떻게 할것인가?
    }
}
