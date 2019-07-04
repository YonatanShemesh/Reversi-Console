namespace Ui
{
    public class GameMode
    {
        private GameUi.eGameMode m_GameMode;

        internal GameMode()
        {
            m_GameMode = GameUi.eGameMode.WrongChoise;
        }
        internal void SelectGameMode()
        {
            bool isInputValid = true;
            string gameModeStr = System.Console.ReadLine();

            isInputValid = checkGameModeInput(gameModeStr);
            while (!isInputValid)
            {
                writeErrorGameModeMsg();
                gameModeStr = System.Console.ReadLine();
                isInputValid = checkGameModeInput(gameModeStr);
            }

            setGameMode(gameModeStr);
        }
        private GameUi.eGameMode parse(string i_gameModeStr)
        {
            GameUi.eGameMode parsed = GameUi.eGameMode.WrongChoise;
            bool isValidInput = int.TryParse(i_gameModeStr, out int res);

            if (isValidInput)
            {
                parsed = (GameUi.eGameMode)res;
            }

            return parsed;
        }
        private void setGameMode(string i_gameModeStr)
        {
            m_GameMode = parse(i_gameModeStr);
        }
        internal GameUi.eGameMode GetGameMode()
        {
            return m_GameMode;
        }

        private bool checkGameModeInput(string i_gameModeStr)
        {
            bool isValidInput = true;

            GameUi.eGameMode gameModeVal = parse(i_gameModeStr);
            if (gameModeVal != GameUi.eGameMode.PVp && gameModeVal != GameUi.eGameMode.PVc && gameModeVal != GameUi.eGameMode.CVc)
            {
                isValidInput = false;
            }

            return isValidInput;
        }
        private void writeErrorGameModeMsg()
        {
            System.Console.WriteLine("You Have Selected Wrong Key - Please Select Again");
        }
    }
}

