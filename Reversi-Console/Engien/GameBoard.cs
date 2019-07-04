using System.Collections.Generic;
using Ui;


namespace Engien
{
    public class GameBoard
    {
        private int m_Size;
        private Disc[,] m_BoardMatrix;

        public GameBoard(int i_BoardSize)
        {
            m_Size = i_BoardSize;
            m_BoardMatrix = new Disc[m_Size, m_Size];
            m_BoardMatrix[(m_Size / 2) - 1, (m_Size / 2) - 1] = new Disc(Disc.eColors.White, new Point((m_Size / 2) - 1, (m_Size / 2) - 1));
            m_BoardMatrix[m_Size / 2, (m_Size / 2) - 1] = new Disc(Disc.eColors.Black, new Point(m_Size / 2, (m_Size / 2) - 1));
            m_BoardMatrix[(m_Size / 2) - 1, m_Size / 2] = new Disc(Disc.eColors.Black, new Point((m_Size / 2) - 1, m_Size / 2));
            m_BoardMatrix[m_Size / 2, m_Size / 2] = new Disc(Disc.eColors.White, new Point(m_Size / 2, m_Size / 2));
        }

        public int Size
        {
            get { return m_Size; }

            set { m_Size = value; }
        }

        public Disc[,] BoardMatrix
        {
            get { return m_BoardMatrix; }

            set { m_BoardMatrix = value; }
        }

        private bool isCellEmpty(int i_X, int i_Y)
        {
            return m_BoardMatrix[i_Y, i_X] == null;
        }

        private bool isMoveLeagle(int i_X, int i_Y, Disc.eColors i_Color, List<eDirections> io_DirectionsToFlip)
        {
            int numOfOptions = 0;
            List<eDirections> OponentLocation = inWhatCellsNextToDiscLocationThereIsOponentDiscs(i_X, i_Y, i_Color);

            if (OponentLocation.Count != 0)
            {
                foreach (eDirections diraction in OponentLocation)
                {
                    if (scanForAnotherDiscInDirection(diraction, i_X, i_Y, i_Color))
                    {
                        numOfOptions++;
                        io_DirectionsToFlip.Add(diraction);
                    }
                }
            }

            return numOfOptions != 0;
        }

        private bool scanForAnotherDiscInDirection(eDirections i_Direction, int i_X, int i_Y, Disc.eColors i_Color)
        {
            bool IsMoveLeagle = false;

            switch (i_Direction)
            {
                case eDirections.Up:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y - j, i_X];

                        while (CurrentDisc != null && i_Y - j >= 0)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y - j >= 0)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y - j, i_X];
                            }
                        }

                        break;
                    }

                case eDirections.Down:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y + j, i_X];

                        while (CurrentDisc != null && i_Y + j < m_Size)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y + j < m_Size)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y + j, i_X];
                            }
                        }

                        break;
                    }

                case eDirections.Left:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y, i_X - j];

                        while (CurrentDisc != null && i_X - j >= 0)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_X - j >= 0)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y, i_X - j];
                            }
                        }

                        break;
                    }

                case eDirections.Right:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y, i_X + j];

                        while (CurrentDisc != null && i_X + j < m_Size)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_X + j < m_Size)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y, i_X + j];
                            }
                        }

                        break;
                    }

                case eDirections.UpLeft:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y - j, i_X - j];

                        while (CurrentDisc != null && i_Y - j >= 0 && i_X - j >= 0)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y - j >= 0 && i_X - j >= 0)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y - j, i_X - j];
                            }
                        }

                        break;
                    }

                case eDirections.UpRight:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y - j, i_X + j];

                        while (CurrentDisc != null && i_Y - j >= 0 && i_X + j < m_Size)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y - j >= 0 && i_X + j < m_Size)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y - j, i_X + j];
                            }
                        }

                        break;
                    }

                case eDirections.DownLeft:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y + j, i_X - j];

                        while (CurrentDisc != null && i_Y + j < m_Size && i_X - j >= 0)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y + j < m_Size && i_X - j >= 0)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y + j, i_X - j];
                            }
                        }

                        break;
                    }

                case eDirections.DownRight:
                    {
                        int j = 1;
                        Disc CurrentDisc = m_BoardMatrix[i_Y + j, i_X + j];

                        while (CurrentDisc != null && i_Y + j < m_Size && i_X + j < m_Size)
                        {
                            if (CurrentDisc.Color == i_Color)
                            {
                                IsMoveLeagle = true;
                            }

                            j++;
                            if (i_Y + j < m_Size && i_X + j < m_Size)
                            {
                                CurrentDisc = m_BoardMatrix[i_Y + j, i_X + j];
                            }
                        }

                        break;
                    }
            }

            return IsMoveLeagle;
        }

        private void flipRelevantDiscs(Disc i_CorrentDisc, List<eDirections> i_DirectionsToFlip)
        {
            int xCordToMove = 0, yCordToMove = 0;
            int xCord = 0, yCord = 0;

            foreach (eDirections currentDiractionToFlip in i_DirectionsToFlip)
            {
                switch (currentDiractionToFlip)
                {
                    case eDirections.Up:
                        {
                            xCordToMove = 0;
                            yCordToMove = -1;

                            break;
                        }

                    case eDirections.Down:
                        {
                            xCordToMove = 0;
                            yCordToMove = 1;

                            break;
                        }

                    case eDirections.Left:
                        {
                            xCordToMove = -1;
                            yCordToMove = 0;

                            break;
                        }

                    case eDirections.Right:
                        {
                            xCordToMove = 1;
                            yCordToMove = 0;

                            break;
                        }

                    case eDirections.UpLeft:
                        {
                            xCordToMove = -1;
                            yCordToMove = -1;

                            break;
                        }

                    case eDirections.UpRight:
                        {
                            xCordToMove = 1;
                            yCordToMove = -1;

                            break;
                        }

                    case eDirections.DownLeft:
                        {
                            xCordToMove = -1;
                            yCordToMove = 1;

                            break;
                        }

                    case eDirections.DownRight:
                        {
                            xCordToMove = 1;
                            yCordToMove = 1;

                            break;
                        }
                }

                xCord = i_CorrentDisc.Xargument + xCordToMove;
                yCord = i_CorrentDisc.Yargument + yCordToMove;

                Disc CurrentDisc = m_BoardMatrix[yCord, xCord];

                while (CurrentDisc != null && CurrentDisc.Color != i_CorrentDisc.Color && isCordInsideBorders(i_CorrentDisc.Xargument, i_CorrentDisc.Yargument))
                {
                    CurrentDisc.Flip();
                    xCord += xCordToMove;
                    yCord += yCordToMove;

                    CurrentDisc = m_BoardMatrix[yCord, xCord];
                }
            }
        }

        private bool isCordInsideBorders(int i_XCordToCheck, int i_YCordToCheck)
        {
            bool isCordInsideTheBorders = true;

            if (i_XCordToCheck >= m_Size || i_XCordToCheck < 0 || i_YCordToCheck >= m_Size || i_YCordToCheck < 0)
            {
                isCordInsideTheBorders = false;
            }

            return isCordInsideTheBorders;
        }
        private List<eDirections> inWhatCellsNextToDiscLocationThereIsOponentDiscs(int i_X, int i_Y, Disc.eColors i_Color)
        {
            List<eDirections> DiractionList = new List<eDirections>();

            if ((i_Y + 1 < m_Size && m_BoardMatrix[i_Y + 1, i_X] != null) && (m_BoardMatrix[i_Y + 1, i_X].Color != i_Color))
            {
                DiractionList.Add(eDirections.Down);
            }

            if ((i_Y - 1 >= 0 && m_BoardMatrix[i_Y - 1, i_X] != null) && (m_BoardMatrix[i_Y - 1, i_X].Color != i_Color))
            {
                DiractionList.Add(eDirections.Up);
            }

            if (i_X + 1 < m_Size && m_BoardMatrix[i_Y, i_X + 1] != null && m_BoardMatrix[i_Y, i_X + 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.Right);
            }

            if (i_X - 1 >= 0 && m_BoardMatrix[i_Y, i_X - 1] != null && m_BoardMatrix[i_Y, i_X - 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.Left);
            }

            if (i_X + 1 < m_Size && i_Y + 1 < m_Size && m_BoardMatrix[i_Y + 1, i_X + 1] != null && m_BoardMatrix[i_Y + 1, i_X + 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.DownRight);
            }

            if (i_Y + 1 < m_Size && i_X - 1 >= 0 && m_BoardMatrix[i_Y + 1, i_X - 1] != null && m_BoardMatrix[i_Y + 1, i_X - 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.DownLeft);
            }

            if (i_Y - 1 >= 0 && i_X + 1 < m_Size && m_BoardMatrix[i_Y - 1, i_X + 1] != null && m_BoardMatrix[i_Y - 1, i_X + 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.UpRight);
            }

            if (i_Y - 1 >= 0 && i_X - 1 >= 0 && m_BoardMatrix[i_Y - 1, i_X - 1] != null && m_BoardMatrix[i_Y - 1, i_X - 1].Color != i_Color)
            {
                DiractionList.Add(eDirections.UpLeft);
            }

            return DiractionList;
        }
        public bool TryAddDiscToLocation(int i_X, int i_Y, Disc.eColors i_Color)
        {
            List<eDirections> directionsToFlip = new List<eDirections>();
            bool leagalMove = isCellEmpty(i_X, i_Y) && isMoveLeagle(i_X, i_Y, i_Color, directionsToFlip);

            if (leagalMove)
            {
                BoardMatrix[i_Y, i_X] = new Disc(i_Color, new Point(i_X, i_Y));
                flipRelevantDiscs(BoardMatrix[i_Y, i_X], directionsToFlip);
            }

            return leagalMove;
        }
        public bool IsThereOptionsToPlay(GameUi.ePlayers i_Player, ref List<Point> io_OptionalMoveToPlaye)
        {
            io_OptionalMoveToPlaye = null;
            bool thereIsOption = false;
            List<eDirections> whereToMove = new List<eDirections>();

            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (m_BoardMatrix[i, j] == null && isMoveLeagle(j, i, (Disc.eColors)i_Player, whereToMove))
                    {
                        if (io_OptionalMoveToPlaye == null)
                        {
                            io_OptionalMoveToPlaye = new List<Point>();
                        }

                        thereIsOption = true;
                        io_OptionalMoveToPlaye.Add(new Point(j, i));
                    }
                }
            }

            return thereIsOption;
        }
        public GameUi.ePlayers[,] CreatePrintingBoard(List<Point> i_OptionsToMove)
        {
            bool didntFoundPossibleMove = true;
            GameUi.ePlayers[,] boardToPrint = new GameUi.ePlayers[m_Size, m_Size];

            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (m_BoardMatrix[i, j] != null)
                    {
                        boardToPrint[i, j] = (GameUi.ePlayers)m_BoardMatrix[i, j].Color;
                    }
                    else
                    {
                        if (i_OptionsToMove != null)
                        {
                            foreach (Point CurrentPointInArry in i_OptionsToMove)
                            {
                                if (i == CurrentPointInArry.y && j == CurrentPointInArry.x)
                                {
                                    boardToPrint[i, j] = GameUi.ePlayers.PossibleMove;
                                    didntFoundPossibleMove = false;
                                }
                            }
                        }

                        if (didntFoundPossibleMove)
                        {
                            boardToPrint[i, j] = GameUi.ePlayers.Empty;
                        }
                    }
                }
            }

            return boardToPrint;
        }
        public void CalcPlayersScore(out int o_Player1Score, out int o_Player2Score)
        {
            o_Player1Score = o_Player2Score = 0;

            foreach (Disc CurrentCell in m_BoardMatrix)
            {
                if (CurrentCell != null)
                {
                    if (CurrentCell.Color == Disc.eColors.Black)
                    {
                        o_Player1Score++;
                    }
                    else
                    {
                        o_Player2Score++;
                    }
                }
            }
        }

        private enum eDirections
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }
        public GameBoard BoardDuplicatewithNewPoint(GameBoard i_OldGameBoard, Point i_pointToAdd, GameUi.ePlayers i_player)
        {
            GameBoard newBoard = new GameBoard(i_OldGameBoard.Size);

            for (int i = 0; i < i_OldGameBoard.Size; i++)
            {
                for (int j = 0; j < i_OldGameBoard.Size; j++)
                {
                    newBoard.m_BoardMatrix[i, j] = i_OldGameBoard.m_BoardMatrix[i, j];
                }
            }

            newBoard.m_BoardMatrix[i_pointToAdd.y, i_pointToAdd.x] = new Disc((Disc.eColors)i_player, i_pointToAdd);

            return newBoard;
        }
    }
}