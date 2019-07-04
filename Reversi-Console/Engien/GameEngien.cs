using System;
using System.Collections.Generic;
using Ui;

namespace Engien
{
    public class GameEngien
    {
        private AI m_PcAi = new AI();
        public void StartGame()
        {
            bool restartGame = true;
            while (restartGame)
            {
                GameUi gameUi = new GameUi();
                gameUi.LaunchMenu();
                GameBoard gameBoard = new GameBoard((int)gameUi.MatrixSize);
                Point userCordInput;
                GameUi.ePlayers currentPlayer = GameUi.ePlayers.FirstPlayer;
                bool continueGame = true;
                int gameItrator = 0;
                int thereNoOptionsForXPlayers = 0;
                List<Point> moveOptions = null;
                bool isLastTurnWasOk = true;
                int player1Score = 0, player2Score = 0;
                while (continueGame)
                {
                    if (gameBoard.IsThereOptionsToPlay(currentPlayer, ref moveOptions))
                    {
                        if ((gameUi.GameMode == GameUi.eGameMode.PVc && currentPlayer == GameUi.ePlayers.SecondPlayer) || gameUi.GameMode == GameUi.eGameMode.CVc)
                        {
                            userCordInput = m_PcAi.AiTurn(gameBoard, currentPlayer);
                        }
                        else
                        {
                            gameBoard.CalcPlayersScore(out player1Score, out player2Score);
                            userCordInput = gameUi.NextTurn(gameBoard.CreatePrintingBoard(moveOptions), currentPlayer, isLastTurnWasOk, player1Score, player2Score);
                        }

                        if (gameBoard.TryAddDiscToLocation(userCordInput.x, userCordInput.y, (Disc.eColors)currentPlayer))
                        {
                            gameItrator++;
                            isLastTurnWasOk = true;
                        }
                        else
                        {
                            isLastTurnWasOk = false;
                        }

                        thereNoOptionsForXPlayers = 0;
                    }
                    else
                    {
                        thereNoOptionsForXPlayers++;
                        gameItrator++;
                    }

                    if (gameItrator % 2 == 0)
                    {
                        currentPlayer = GameUi.ePlayers.FirstPlayer;
                    }
                    else
                    {
                        currentPlayer = GameUi.ePlayers.SecondPlayer;
                    }

                    continueGame = thereNoOptionsForXPlayers < 2;
                }

                gameBoard.CalcPlayersScore(out player1Score, out player2Score);
                gameUi.GameOver(gameBoard.CreatePrintingBoard(moveOptions), player1Score, player2Score, ref restartGame);
            }
        }

        private Point makePcMove(List<Point> i_PcOptions)
        {
            Random randMove = new Random();
            int index = randMove.Next(1, i_PcOptions.Count) - 1;
            return i_PcOptions[index];
        }
    }
}

