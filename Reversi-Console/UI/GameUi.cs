namespace Ui
{
    public class GameUi
    {
        private string m_P1Name;
        private string m_P2Name; 
        private GameMode m_GameMode;
        private MatrixSizeManager m_MatrixSize;

        public GameUi()
        {
            m_P1Name = null;
            m_P2Name = "Computer";
            m_GameMode = new GameMode();
            m_MatrixSize = new MatrixSizeManager();
        }
        private string getName()
        {
            return System.Console.ReadLine();
        }
        public void LaunchMenu()
        {
            System.Console.Clear();
            Screen.PrintStartUpMenuScreen();
            m_P1Name = getName();
            Screen.PrintSelectGameModeMenuScreen(m_P1Name);
            m_GameMode.SelectGameMode();
            if ((int)m_GameMode.GetGameMode() == (int)eGameMode.PVp)
            {
                Screen.PrintPlayerVsPlayerMenuScreen(m_P1Name);
                m_P2Name = getName();
            }

            Screen.PrintSelectMatrixSizeMenuScreen(m_P1Name);
            m_MatrixSize.SelectMatrixSize();
            if ((int)m_GameMode.GetGameMode() == (int)eGameMode.CVc)
            {
                m_P1Name = "computer1";
            }
        }
        public Point NextTurn(ePlayers[,] i_Board, ePlayers i_PlayerTurn, bool i_IsLastTurnLegal, int i_Player1Score, int i_Player2Score)
        {
            string userSelectedMoveStr;
            Point playersMove = new Point(-1, -1);

            Screen.PrintBoard((int)m_MatrixSize.MatrixSize, i_Board, Player1Name, Player2Name, i_PlayerTurn, i_Player1Score, i_Player2Score);
            if (!i_IsLastTurnLegal)
            {
                Screen.PrintWrongSquereMsg();
            }

            userSelectedMoveStr = System.Console.ReadLine();
            checkSyntactMoveInput(ref userSelectedMoveStr, m_MatrixSize);
            if (userSelectedMoveStr[0] == 'Q')
            {
                System.Environment.Exit(1);
            }

            boardCordParse(userSelectedMoveStr, playersMove);

            return playersMove;
        }
        public void GameOver(ePlayers[,] i_Board, int i_Player1Score, int i_Player2Score, ref bool io_RestartGame)
        {
            string isRestartNeedeStr;
            Screen.PrintBoard((int)m_MatrixSize.MatrixSize, i_Board, Player1Name, Player2Name, ePlayers.GameOver, i_Player1Score, i_Player2Score);
            System.Console.WriteLine(@"

To play Again press Y else Press Any key to Quit");
            isRestartNeedeStr = System.Console.ReadLine();
            isRestartNeedeStr = isRestartNeedeStr.ToUpper();
            if (isRestartNeedeStr.Length == 1 && isRestartNeedeStr[0] == 'Y')
            {
                io_RestartGame = true;
            }
            else
            {
                io_RestartGame = false;
            }
        }
        private void boardCordParse(string i_userSelectedMoveStr, Point io_PlayersMove)
        {
            char colChar = i_userSelectedMoveStr[0];
            char rowChar = i_userSelectedMoveStr[1];

            io_PlayersMove.x = colChar - 'A';
            io_PlayersMove.y = rowChar - '1';
        }
        private void checkSyntactMoveInput(ref string io_userSelectedMoveStr, MatrixSizeManager m_MatrixSize)
        {
            bool isSyntactLegal = true;
            isSyntactLegal = isMoveSyntacticLegal(ref io_userSelectedMoveStr);
            while (!isSyntactLegal)
            {
                Screen.PrintSyntactError();
                io_userSelectedMoveStr = System.Console.ReadLine();
                isSyntactLegal = isMoveSyntacticLegal(ref io_userSelectedMoveStr);
            }
        }
        private bool isMoveSyntacticLegal(ref string io_UserSelectedMoveStr)
        {
            bool isInputValid = true;

            io_UserSelectedMoveStr = io_UserSelectedMoveStr.ToUpper();
            if (io_UserSelectedMoveStr.Length == 2)
            {
                if (MatrixSize == eMatrixSize.SixBySix)
                {
                    if (io_UserSelectedMoveStr[0] < 'A' || io_UserSelectedMoveStr[0] > 'F')
                    {
                        isInputValid = false;
                    }

                    if (io_UserSelectedMoveStr[1] < '0' || io_UserSelectedMoveStr[1] > '6')
                    {
                        isInputValid = false;
                    }
                }
                else
                {
                    if (io_UserSelectedMoveStr[0] < 'A' || io_UserSelectedMoveStr[0] > 'H')
                    {
                        isInputValid = false;
                    }

                    if (io_UserSelectedMoveStr[1] < '0' || io_UserSelectedMoveStr[1] > '8')
                    {
                        isInputValid = false;
                    }
                }
            }
            else if (io_UserSelectedMoveStr.Length == 1)
            {
                if (io_UserSelectedMoveStr[0] != 'Q')
                {
                    isInputValid = false;
                }
            }
            else
            {
                isInputValid = false;
            }

            return isInputValid;
        }
        public string Player1Name
        {
            get { return m_P1Name; }
            set { m_P1Name = value; }
        }
        public string Player2Name
        {
            get { return m_P2Name; }
            set { m_P2Name = value; }
        }
        public eGameMode GameMode
        {
            get { return m_GameMode.GetGameMode(); }
        }
        public eMatrixSize MatrixSize
        {
            get { return m_MatrixSize.MatrixSize; }
        }
        public enum eMatrixSize
        {
            WrongChoise = 0,
            SixBySix = 6,
            EightByEight = 8,
        }
        public enum eGameMode
        {
            WrongChoise = 0,
            PVp = 1,
            PVc = 2, 
            CVc = 3, 
        }
        public enum ePlayers
        {
            FirstPlayer = 'x',
            SecondPlayer = 'o',
            Empty = ' ',
            PossibleMove = '.',
            GameOver = -1
        }
    }
}

