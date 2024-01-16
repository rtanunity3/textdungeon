using System.Text;

namespace textdungeon.Screen
{
    public static class Printing
    {
        /*
        location : darkyellow
        tabletitle : darkgray
        gold : yellow
        select : green
        warning: red
        Equip : cyan
        */
        public static void HighlightText(string text, ConsoleColor textColor)
        {
            HighlightText(text, textColor, ConsoleColor.Black);
        }

        public static void HighlightText(string text, ConsoleColor textColor, ConsoleColor bgColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void SelectWriteLine(int num, string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{num}. ");
            Console.ResetColor();
            Console.WriteLine(content);
        }
        public static void SelectWrite(int num, string content)
        {
            //SelectWrite(num, content, 0);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{num}. ");
            Console.ResetColor();
            Console.Write(content);
        }

        //public static void SelectWrite(int num, string content, int padright)
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write($"{num}. ");
        //    Console.ResetColor();
        //    Console.Write(Util.PadRightMixedText($"{content}", padright));
        //}

        public static void StartScreen()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            DrawFrame();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            /*
            Console.WriteLine("    :::    ::: :::::::::: :::::::::   :::::::: ::::::::::: ::::::::  :::       ::: ::::    :::");
            Console.WriteLine("    :+:    :+: :+:        :+:    :+: :+:    :+:    :+:    :+:    :+: :+:       :+: :+:+:   :+:");
            Console.WriteLine("    +:+    +:+ +:+        +:+    +:+ +:+    +:+    +:+    +:+    +:+ +:+       +:+ :+:+:+  +:+");
            Console.WriteLine("    +#++:++#++ +#++:++#   +#++:++#:  +#+    +:+    +#+    +#+    +:+ +#+  +:+  +#+ +#+ +:+ +#+");
            Console.WriteLine("    +#+    +#+ +#+        +#+    +#+ +#+    +#+    +#+    +#+    +#+ +#+ +#+#+ +#+ +#+  +#+#+#");
            Console.WriteLine("    #+#    #+# #+#        #+#    #+# #+#    #+#    #+#    #+#    #+#  #+#+# #+#+#  #+#   #+#+#");
            Console.WriteLine("    ###    ### ########## ###    ###  ########     ###     ########    ###   ###   ###    ####");
            */
            string[] s = {
                "      ██████  ██▓███   ▄▄▄       ██▀███  ▄▄▄█████▓ ▄▄▄             ",
                "    ▒██    ▒ ▓██░  ██▒▒████▄    ▓██ ▒ ██▒▓  ██▒ ▓▒▒████▄           ",
                "    ░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▓██ ░▄█ ▒▒ ▓██░ ▒░▒██  ▀█▄         ",
                "      ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒██▀▀█▄  ░ ▓██▓ ░ ░██▄▄▄▄██        ",
                "    ▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒░██▓ ▒██▒  ▒██▒ ░  ▓█   ▓██▒       ",
                "    ▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ▒▓ ░▒▓░  ▒ ░░    ▒▒   ▓▒█░       ",
                "    ░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░▒ ░ ▒░    ░      ▒   ▒▒ ░       ",
                "    ░  ░  ░  ░░         ░   ▒     ░░   ░   ░        ░   ▒          ",
                "          ░                 ░  ░   ░                    ░  ░       ",
                "▓█████▄  █    ██  ███▄    █   ▄████ ▓█████  ▒█████   ███▄    █ ",
                "▒██▀ ██▌ ██  ▓██▒ ██ ▀█   █  ██▒ ▀█▒▓█   ▀ ▒██▒  ██▒ ██ ▀█   █ ",
                "░██   █▌▓██  ▒██░▓██  ▀█ ██▒▒██░▄▄▄░▒███   ▒██░  ██▒▓██  ▀█ ██▒",
                "░▓█▄   ▌▓▓█  ░██░▓██▒  ▐▌██▒░▓█  ██▓▒▓█  ▄ ▒██   ██░▓██▒  ▐▌██▒",
                "░▒████▓ ▒▒█████▓ ▒██░   ▓██░░▒▓███▀▒░▒████▒░ ████▓▒░▒██░   ▓██░",
                " ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒  ░▒   ▒ ░░ ▒░ ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ",
                " ░ ▒  ▒ ░░▒░ ░ ░ ░ ░░   ░ ▒░  ░   ░  ░ ░  ░  ░ ▒ ▒░ ░ ░░   ░ ▒░",
                " ░ ░  ░  ░░░ ░ ░    ░   ░ ░ ░ ░   ░    ░   ░ ░ ░ ▒     ░   ░ ░ ",
                "   ░       ░              ░       ░    ░  ░    ░ ░           ░ ",
                " ░                                                             "
            };
            Console.SetCursorPosition(28, 3);
            foreach (var str in s)
            {
                Console.SetCursorPosition(28, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
            Console.ResetColor();
            int i = 0;
            Console.SetCursorPosition(50, 26 + i);
            SelectWrite(1, "새로운 시작");
            if (File.Exists("save.json"))
            {
                ++i;
                Console.SetCursorPosition(50, 26 + i);
                SelectWrite(2, "이어서하기");
            }
            ++i;
            Console.SetCursorPosition(50, 26 + i);
            SelectWrite(0, "게임 종료");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void DrawFrame(bool useSideFrame = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string s = "████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████";
            Console.WriteLine(s);

            for (int i = 0; i < 37; i++)
            {
                Console.Write("██");
                if (useSideFrame)
                {
                    Console.SetCursorPosition(118, Console.GetCursorPosition().Top);
                    Console.WriteLine("██");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void DrawKnight()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = {
                @"      _,.",
                @"    ,` -.)",
                @"   ( _/-\\-._",
                @"  /,|`--._,-^|            ,",
                @"  \_| |`-._/||          ,'|",
                @"    |  `-, / |         /  /",
                @"    |     || |        /  /",
                @"     `r-._||/   __   /  /",
                @" __,-<_     )`-/  `./  /",
                @"'  \   `---'   \   /  /",
                @"    |           |./  /",
                @"    /           //  /",
                @"\_/' \         |/  /",
                @" |    |   _,^-'/  /",
                @" |    , ``  (\/  /_",
                @"  \,.->._    \X-=/^",
                @"  (  /   `-._//^` ",
                @"   `Y-.____(__}",
                @"    |     { __)",
                @"          ()"
            };

            foreach(var str in  s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void DrawSkeleton()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = {
                @"                           ,--.",
                @"                          {    }",
                @"                          K,   }",
                @"                         /  `Y`",
                @"                    _   /   /",
                @"                   {_'-K.__/",
                @"                     `/-.__L._",
                @"                     /  ' /`\_}",
                @"                    /  ' /",
                @"            ____   /  ' /",
                @"     ,-'~~~~    ~~/  ' /_",
                @"   ,'             ``~~~%%',",
                @"  (                     %  Y",
                @" {                      %% I",
                @"{      -                 %  `.",
                @"|       ',                %  )",
                @"|        |   ,..__      __. Y",
                @"|    .,_./  Y ' / ^Y   J   )|",
                @"\           |' /   |   |   ||",
                @" \          L_/    . _ (_,.'(",
                @"  \,   ,      ^^""' / |      )",
                @"    \_  \          /,L]     /",
                @"      '-_`-,       ` `   ./`",
                @"         `-(_            )",
                @"             ^^\..___,.--`"
            };

            foreach (var str in s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void DrawVillage()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = {
                @"            ~         ~~          __",
                @"       _T      .,,.    ~--~ ^^",
                @" ^^   // \                    ~",
                @"      ][O]    ^^      ,-~ ~",
                @"   /''-I_I         _II____",
                @"__/_  /   \ ______/ ''   /'\_,__",
                @"  | II--'''' \,--:--..,_/,.-{ },",
                @"; '/__\,.--';|   |[] .-.| O{ _ }",
                @":' |  | []  -|   ''--:.;[,.'\,/",
                @"'  |[]|,.--'' '',   ''-,.    |",
                @"  ..    ..-''    ;       ''. '"
            };

            foreach (var str in s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void DrawSign(bool isExtend = false)
        {
            int left = Console.GetCursorPosition().Left;
            int height = 16;
            int pad = 50;
            Console.ForegroundColor = ConsoleColor.Gray;
            string s = "████████████████████████████████████████████████████";
            if (isExtend)
            {
                s += "████████████████████";
                height = 19;
                pad += 20;
            }
            Console.WriteLine(s);

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.Write("██");
                Console.SetCursorPosition(left + pad, Console.GetCursorPosition().Top);
                Console.WriteLine("██");
            }
            Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void DrawShield()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = { 
                @"          <>          ",
                @"        .::::.        ",
                @"    @\\/W\/\/W\//@    ",
                @"     \\/^\/\/^\//     ",
                @"      \_O_<>_O_/      ",
                @" ____________________ ",
                @"|<><><>  |  |  <><><>|",
                @"|<>      |  |      <>|",
                @"|<>      |  |      <>|",
                @"|<>   .--------.   <>|",
                @"|     |   ()   |     |",
                @"|_____| (O\/O) |_____|",
                @"|     \   /\   /     |",
                @"|------\  \/  /------|",
                @"|       '.__.'       |",
                @"|        |  |        |",
                @":        |  |        :",
                @" \<>     |  |     <>/ ",
                @"  \<>    |  |    <>/  ",
                @"   \<>   |  |   <>/   ",
                @"    `\<> |  | <>/'    ",
                @"      `-.|  |.-`      ",
                @"         '--'         ",
            };

            foreach (var str in s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void DrawSword()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = {
                @"      .-.      ",
                @"     {{@}}     ",
                @"      8@8      ",
                @"      888      ",
                @"      8@8      ",
                @" _    )8(    _ ",
                @"(@)__/8@8\__(@)",
                 " `~\"-=):(=-\"~` ",
                @"      |.|      ",
                @"      |S|      ",
                @"      |'|      ",
                @"      |.|      ",
                @"      |P|      ",
                @"      |'|      ",
                @"      |.|      ",
                @"      |U|      ",
                @"      |'|      ",
                @"      |.|      ",
                @"      |N|      ",
                @"      |'|      ",
                @"      |.|      ",
                @"      |K|      ",
                @"      |'|      ",
                @"      \ /      ",
                @"       ^       "
            };

            foreach (var str in s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void DrawSkeletonDoor()
        {
            int left = Console.GetCursorPosition().Left;
            string[] s = {
                @"              .7",
                @"            .'/ ",
                @"           / /  ",
                @"          / /   ",
                @"         / /    ",
                @"        / /     ",
                @"       / /      ",
                @"      / /       ",
                @"     / /        ",
                @"    / /         ",
                @"  __|/          ",
                @",-\__\          ",
                 "|f-\"Y\\|         ",
                @"\()7L/          ",
                @" cgD                            __ _    ",
                @" |\(                          .'  Y '>, ",
                @"  \ \                        / _   _   \",
                @"   \\\                       )(_) (_)(|}",
                @"    \\\                      {  4A   } /",
                @"     \\\                      \uLuJJ/\l ",
                @"      \\\                     |3    p)/ ",
                @"       \\\___ __________      /nnm_n//  ",
                 "       c7___-__,__-)\\,__)(\".  \\_>-<_/D  ",
                 "                  //V     \\_\"-._.__G G_c__.-__<\"/ ( \\",
                 "                         <\"-._>__-,G_.___)\\   \\7\\",
                 "                        (\"-.__.| \\\"<.__.-\" )   \\ \\",
                 "                        |\"-.__\"\\  |\"-.__.-\".\\   \\ \\",
                 "                        (\"-.__\"\". \\\"-.__.-\".|    \\_\\",
                 "                        \\\"-.__\"\"|!|\"-.__.-\".)     \\ \\",
                 "                         \"-.__\"\"\\_|\"-.__.-\"./      \\ l",
                 "                          \".__\"\"\">G>-.__.-\">       .--,_",
                 "                              \"\"  G                     ",
            };
            foreach (var str in s)
            {
                Console.SetCursorPosition(left, Console.GetCursorPosition().Top);
                Console.WriteLine(str);
            }
        }

        public static void GameOverScreen()
        {
            // 아직 쓰는곳 없음. 필요하면 수정해서 쓰는 방향으로
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ::::::::      :::       :::   :::   :::::::::: ::::::::  :::     ::: :::::::::: ::::::::: ");
            Console.WriteLine("      :+:    :+:   :+: :+:    :+:+: :+:+:  :+:       :+:    :+: :+:     :+: :+:        :+:    :+: ");
            Console.WriteLine("     +:+         +:+   +:+  +:+ +:+:+ +:+ +:+       +:+    +:+ +:+     +:+ +:+        +:+    +:+  ");
            Console.WriteLine("    :#:        +#++:++#++: +#+  +:+  +#+ +#++:++#  +#+    +:+ +#+     +:+ +#++:++#   +#++:++#:    ");
            Console.WriteLine("   +#+   +#+# +#+     +#+ +#+       +#+ +#+       +#+    +#+  +#+   +#+  +#+        +#+    +#+    ");
            Console.WriteLine("  #+#    #+# #+#     #+# #+#       #+# #+#       #+#    #+#   #+#+#+#   #+#        #+#    #+#     ");
            Console.WriteLine("  ########  ###     ### ###       ### ########## ########      ###     ########## ###    ###      ");

            Console.ResetColor();
            int i = 0;
            Console.SetCursorPosition(40, 13 + i);
            SelectWrite(1, "새로운 시작");
            if (File.Exists("save.json"))
            {
                ++i;
                Console.SetCursorPosition(40, 13 + i);
                SelectWrite(2, "이어서하기");
            }
            ++i;
            Console.SetCursorPosition(40, 13 + i);
            SelectWrite(0, "게임 종료");
            Console.WriteLine();
        }


        public static void VillageScreen()
        {
            Console.Clear();
            DrawFrame();
            Console.SetCursorPosition(15, 10);
            DrawVillage();
            Console.SetCursorPosition(60, 10);
            Console.WriteLine("마을에 오신 여러분 환영합니다.");
            Console.SetCursorPosition(60, 12);
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            for (int i = 1; i < Menu.VillageMenu.Length; i++)
            {
                Console.SetCursorPosition(60, Console.GetCursorPosition().Top);
                SelectWriteLine(i, Menu.VillageMenu[i]);
            }
            Console.SetCursorPosition(60, Console.GetCursorPosition().Top);
            SelectWriteLine(0, "게임 저장 후 종료");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void StoreItemInfoTableTitle(int[] itemTableColWidth, int itemInfoTableTop)
        {
            Console.SetCursorPosition(7, Console.GetCursorPosition().Top);
            HighlightText("아이템 이름", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[0], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("공격력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[1], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("방어력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[2], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("아이템 설명", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[3], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("가격", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[4], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("수량", ConsoleColor.DarkGray);
            Console.WriteLine();
        }

        public static void ItemInfoTableTitle(int[] itemTableColWidth, int itemInfoTableTop)
        {
            Console.SetCursorPosition(7, itemInfoTableTop);
            HighlightText("아이템 이름", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[0], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("공격력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[1], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("방어력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[2], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("아이템 설명", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[3], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("수량", ConsoleColor.DarkGray);
            Console.WriteLine();
        }

        public static void SkillInfoTableTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(31, Console.GetCursorPosition().Top);
            Console.Write(Util.PadRightMixedText("스킬명", 10));
            Console.Write(Util.PadRightMixedText("대상범위", 10));
            Console.Write(Util.PadRightMixedText("소모마나", 10));
            Console.Write(Util.PadRightMixedText("데미지", 15));
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void SelectClassScene()
        {
            Console.Clear();
            DrawFrame();
            Console.SetCursorPosition(12, 14);
            Printing.DrawKnight();
            Console.SetCursorPosition(70, 10);
            Printing.DrawSkeleton();
            Console.SetCursorPosition(44, 5);
            Console.WriteLine("선택할 수 있는 직업 목록입니다.\n");
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(1, EnumHandler.GetjobKr(CharacterClass.Warrior));
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(2, EnumHandler.GetjobKr(CharacterClass.Mage));
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(3, EnumHandler.GetjobKr(CharacterClass.Archer));
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(4, EnumHandler.GetjobKr(CharacterClass.Thief));
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(5, EnumHandler.GetjobKr(CharacterClass.Cleric));
            Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
            SelectWriteLine(0, "시작화면으로 나가기");
            Console.WriteLine();
        }
    }
}
