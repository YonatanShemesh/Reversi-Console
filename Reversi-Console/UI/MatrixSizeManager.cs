namespace Ui
{
    public class MatrixSizeManager
    {
        private GameUi.eMatrixSize m_MatrixSize;

        public MatrixSizeManager()
        {
            m_MatrixSize = GameUi.eMatrixSize.WrongChoise;
        }
        internal void SelectMatrixSize()
        {
            bool isInputValid;
            string matrixSizeStr = System.Console.ReadLine();

            isInputValid = checkMatrixSizeInput(matrixSizeStr); 
                                                               
            while (!isInputValid)
            {
                writeErrorGameModeMsg();
                matrixSizeStr = System.Console.ReadLine();
                isInputValid = checkMatrixSizeInput(matrixSizeStr);
            }

            MatrixSize = parse(matrixSizeStr);
        }
        private GameUi.eMatrixSize parse(string i_MatrixSizeStr)
        {
            bool isIntParseCompleted = true;
            GameUi.eMatrixSize matrixSize = GameUi.eMatrixSize.WrongChoise;

            isIntParseCompleted = int.TryParse(i_MatrixSizeStr, out int paresInt);
            if (isIntParseCompleted)
            {
                if (paresInt == 1)
                {
                    matrixSize = GameUi.eMatrixSize.SixBySix;
                }
                else if (paresInt == 2)
                {
                    matrixSize = GameUi.eMatrixSize.EightByEight;
                }
                else
                {
                    matrixSize = GameUi.eMatrixSize.WrongChoise;
                }
            }

            return matrixSize;
        }
        internal GameUi.eMatrixSize MatrixSize
        {
            get { return m_MatrixSize; }

            set { m_MatrixSize = value; }
        }
        private bool checkMatrixSizeInput(string i_MatrixSizeStr)
        {
            bool isValidInput = true;
            GameUi.eMatrixSize gameModeVal = parse(i_MatrixSizeStr);

            if (gameModeVal != GameUi.eMatrixSize.EightByEight && gameModeVal != GameUi.eMatrixSize.SixBySix)
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

