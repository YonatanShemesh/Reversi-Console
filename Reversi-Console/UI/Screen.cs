using System;


namespace Ui
{
    public class Screen
    {
        protected static string m_Head = @" _______  _______  __   __  _______  ___      _______ 
|       ||       ||  | |  ||       ||   |    |       |
|   _   ||_     _||  |_|  ||    ___||   |    |   _   |
|  | |  |  |   |  |       ||   |___ |   |    |  | |  |
|  |_|  |  |   |  |       ||    ___||   |___ |  |_|  |
|       |  |   |  |   _   ||   |___ |       ||       |
|_______|  |___|  |__| |__||_______||_______||_______|
";

        internal static void PrintStartUpMenuScreen()
        {
            System.Console.WriteLine(m_Head);
            System.Console.Write("Please Enter Your Name: ");
        }
        internal static void PrintSelectGameModeMenuScreen(string i_Player1Name)
        {
            string output = string.Format(@"
{0} Please Select Game Mode:

1. Player VS Player
2. Player VS Coumputer
3. Coumputer VS Coumputer", i_Player1Name);
            System.Console.Clear();
            System.Console.Write(m_Head);
            System.Console.WriteLine(output);
        }
        internal static void PrintPlayerVsPlayerMenuScreen(string i_Player1Name)
        {
            string output = string.Format(@" 
{0}  Please Enter player 2 Name:", i_Player1Name);
            System.Console.Clear();
            System.Console.Write(m_Head);
            System.Console.WriteLine(output);
        }
        internal static void PrintSelectMatrixSizeMenuScreen(string i_Player1Name)
        {
            string output = string.Format(@"
{0}  Please Select Matrix Size
1.  6 X 6
2.  8 X 8", i_Player1Name);
            System.Console.Clear();
            System.Console.Write(m_Head);
            System.Console.WriteLine(output);
        }
        internal static void PrintSyntactError()
        {
            System.Console.WriteLine("This Squere doesnt exists Please Choose Again");
        }

        internal static void PrintBoard(int i_MatrixSize, GameUi.ePlayers[,] i_Board, string i_Player1Name, string i_Player2Name, GameUi.ePlayers i_PlayerTurn, int i_Player1Score, int i_Player2Score)
        {
            System.Console.Clear();
            string gameBoardOutput = string.Empty;
            string playerTurnsName;
            int i = 0;
            int j = 0;

            if (i_PlayerTurn == GameUi.ePlayers.FirstPlayer)
            {
                playerTurnsName = "Its: " + i_Player1Name + " Turn put  " + (char)i_PlayerTurn;
            }
            else if (i_PlayerTurn == GameUi.ePlayers.SecondPlayer)
            {
                playerTurnsName = "Its: " + i_Player2Name + " Turn put  " + (char)i_PlayerTurn;
            }
            else
            {
                string gameOver = string.Format(@"    
   __ _  __ _ _ __ ___   ___    _____   _____ _ __ 
  / _` |/ _` | '_ ` _ \ / _ \  / _ \ \ / / _ \ '__|
 | (_| | (_| | | | | | |  __/ | (_) \ V /  __/ |   
  \__, |\__,_|_| |_| |_|\___|  \___/ \_/ \___|_|   
   __/ |                                           
  |___/                                            ");
                if (i_Player1Score > i_Player2Score)
                {
                    playerTurnsName = gameOver + i_Player1Name + " Wins";
                }
                else if (i_Player1Score < i_Player2Score)
                {
                    playerTurnsName = gameOver + i_Player2Name + " Wins";
                }
                else
                {
                    playerTurnsName = gameOver + "Its A Tie";
                }
            }

            if (i_MatrixSize == 6)
            {
                gameBoardOutput = string.Format(@"
            A   B   C   D   E   F  
          =========================
        1 | {0} | {1} | {2} | {3} | {4} | {5} |
          =========================
        2 | {6} | {7} | {8} | {9} | {10} | {11} |
          =========================
        3 | {12} | {13} | {14} | {15} | {16} | {17} |   {36}:{37}
          =========================
        4 | {18} | {19} | {20} | {21} | {22} | {23} |   {38}:{39}
          =========================
        5 | {24} | {25} | {26} | {27} | {28} | {29} |
          =========================
        6 | {30} | {31} | {32} | {33} | {34} | {35} |
          =========================
          {40}",
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i, j++ % 6], (char)i_Board[i++, j++ % 6],
      i_Player1Name, i_Player1Score.ToString(), i_Player2Name, i_Player2Score.ToString(), playerTurnsName);
            }
            else
            {
                gameBoardOutput = string.Format(@"
            A   B   C   D   E   F   G   H   
          =================================
        1 | {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} |
          =================================
        2 | {8} | {9} | {10} | {11} | {12} | {13} | {14} | {15} |
          =================================
        3 | {16} | {17} | {18} | {19} | {20} | {21} | {22} | {23} |
          =================================
        4 | {24} | {25} | {26} | {27} | {28} | {29} | {30} | {31} |  {64}:{65}
          =================================
        5 | {32} | {33} | {34} | {35} | {36} | {37} | {38} | {39} |  {66}:{67}
          =================================
        6 | {40} | {41} | {42} | {43} | {44} | {45} | {46} | {47} |  
          =================================
        7 | {48} | {49} | {50} | {51} | {52} | {53} | {54} | {55} |
          =================================
        8 | {56} | {57} | {58} | {59} | {60} | {61} | {62} | {63} |
          =================================
          {68}",
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i, j++ % 8], (char)i_Board[i++, j++ % 8],
       i_Player1Name, i_Player1Score.ToString(), i_Player2Name, i_Player2Score.ToString(), playerTurnsName);
            }

            System.Console.Write(m_Head);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(gameBoardOutput);
        }

        internal static void PrintWrongSquereMsg()
        {
            string errorMsg = "You Have CHoosen A wrong Squere choose Again";
            System.Console.WriteLine(errorMsg);
        }
    }
}
