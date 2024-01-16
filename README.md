# C# 콘솔 스파르타 던전 배틀 (Text 게임) 만들기

5개의 직업! 총 10개의 스킬과 33개의 아이템! 19종의 몬스터와 6단계의 던전까지!

![image](https://github.com/rtanunity3/textdungeon/assets/88172590/22f0a9b5-5185-4210-aafd-ca4b73b8b1b4)


## 캐릭터 클래스
![image](https://github.com/rtanunity3/textdungeon/assets/88172590/e3511b71-c778-4a11-8776-6f49c99fadbb)

### 전사

- 비교적 높은 공격력과 체력을 가졌으나 가난하다.
- 스킬
  - 강격 : (단일공격) 마나 5를 사용하여 공격력의 120%의 데미지를 준다.
  - 이중타격 : (단일공격) 마나 15를 사용하여 공격력의 180%의 데미지를 준다.

### 마법사

- 육체적으론 나약하나 풍부한 마나를 가지고 적을 학살한다.
- 마법사들은 대체적으로 골드가 많다.
- 스킬
  - 불화살 : (단일공격) 마나 5를 사용하여 공격력의 130%의 데미지를 준다.
  - 블리자드 : (전체공격) 마나 20을 사용하여 적 전체에게 공격력의 180%의 데미지를 준다.

### 궁수

- 평균치의 평범한 능력을 지녔으나 저격을 통한 단일 딜량은 무시하지 못한다.
- 스킬
  - 연사 : (전체공격) 마나 10을 사용하여 적 전체에게 공격력의 90%의 데미지를 준다.
  - 저격 : (단일공격) 마나 20를 사용하여 공격력의 220%의 데미지를 준다.

### 도적

- 법사만큼 낮은 체력을 지녔지만 효율 좋은 기습공격을 통해 적을 학살한다.
- 스킬
  - 기습 : (단일타겟) 마나 10을 사용하여 공격력의 150%의 데미지를 준다.
  - 함정 : (단일타겟) 마나 15를 사용하여 공격력의 200%의 데미지를 준다.

### 성직자

- 성실한 신앙과 재단의 지원으로 튼튼해졌다.
- 재단의 지원으로 골드가 많다.
- 스킬
  - 신성타격 : (단일타겟) 마나 10을 사용하여 공격력의 150%의 데미지를 준다.
  - 치료 : (단일타겟) 마나 10을 사용하여 공격력의 150%만큼 자신의 체력을 회복한다.

## 마을
![image](https://github.com/rtanunity3/textdungeon/assets/88172590/e8e57159-50e8-4754-970d-9bc0641fc567)

1. 상태보기 : 현재 레벨 및 능력치 상태 등을 확인 가능하다.
![image](https://github.com/rtanunity3/textdungeon/assets/88172590/1a5443dd-b37e-4514-9d16-a728cf5fca51)

2. 인벤토리 : 소지하고 있는 장비를 확인 가능하며, 소모품은 여기에서 사용이 가능하다.
3. 상점 : 장비 및 소모품을 골드를 지불하여 수급할 수 있으며, 필요없는 장비는 적당한 가격에 팔 수 있다.
![image](https://github.com/rtanunity3/textdungeon/assets/88172590/f633bfed-9107-4bee-8ea0-15164dd574b1)

4. 던전입장 : 적을 물리치는 모험을 떠난다.
5. 휴식하기 : 500G를 사용하여 휴식을 취하고 체력과 마나를 회복한다.
6. 퀘스트 : 퀘스트를 받아 수행하고 진행 상황을 파악할 수 있으며, 완료 시 보상을 받을 수 있다.
![image](https://github.com/rtanunity3/textdungeon/assets/88172590/c244bf24-1ebe-4c8a-b38d-f615cd787af4)

## 장비

- 투구류 : 머리에 착용하는 방어구로 직업에 따라 투구와 후드가 있다.
- 갑옷류 : 몸에 착용하는 방어구로 직업에 따라 갑옷과 로브가 있다.
- 무기류 : 손에 착용하는 장비로 검, 활, 도끼, 창 등 다양한 무기종류가 있다.
- 방패류 : 손에 착용하는 장비로 숙련도가 높으면 공격과 방어 모두에 활용 가능하다.
- 소모품 : 체력과 마나를 회복시켜주며, 돈만 있으면 체질도 개선해준다.

## 던전 & 등장 몬스터 목록

던전에 진입 시 최대 3마리까지 적이 등장하며, 전투 도중 도망이 가능합니다.

![image](https://github.com/rtanunity3/textdungeon/assets/88172590/4c3d7df9-7d79-45da-92b6-6e54da4cf3ae)

1. 고블린 소굴

   - 코볼트
   - 고블린
   - 홉고블린

2. 저주받은 지하묘지

   - 좀비
   - 고스트
   - 구울
   - 밴시
   - 스켈레톤

3. 분노한 정령의숲

   - 운디네
   - 실프
   - 살라만드라
   - 노움

4. 유니콘 둥지

   - 트롤
   - 오크
   - 오우거
   - 오우거메이지
   - 유니콘

5. 타이탄의 연무장

   - 타이탄

6. 드래곤 레어
   - 드래곤

## 영상

[![Video Label](http://img.youtube.com/vi/4Tx0n6-yWxM/0.jpg)](https://www.youtube.com/watch?v=4Tx0n6-yWxM)

# 개발팀 소개

## 개발 인원

권순성  
문정현  
박희태  
정지엽  

## 개발 기간

2024.01.09(Fork) ~ 2024.01.16

## 개발 환경

Visual Studio 2022 community  
.NET 6.0

## 치트키

게임 중 gold 입력시 +5000골드
