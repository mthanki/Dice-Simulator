using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dice_Simulator
{
    public enum DieImageCodes
    {
        NONE = 0,
        ONE = 1,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        TWENTY_SIDE
    }

    class VM : INotifyPropertyChanged
    {
        const string FILENAME = "output.txt";
        const string RESULT_FOLDER_NAME = "DiceSim";

        readonly StringBuilder output = new StringBuilder();
        string fullName;

        string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), RESULT_FOLDER_NAME);

        public void CreateDirectory()
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            fullName = System.IO.Path.Combine(filePath, FILENAME);

            File.AppendAllText(fullName, $"Dice Rolls from {DateTime.Now:MMMM dd, yyyy HH:mm:ss}{Environment.NewLine}");
        }

        const int MIN_ROLL_LIMIT = 1;
        const int MAX_ROLL_LIMIT_SIX_SIDE = 7;
        const int MAX_ROLL_LIMIT_TWENTY_SIDE = 21;
        const string TWENTY_SIDE_FILE_LABEL = "Twenty Side";
        const string SIX_SIDE_FILE_LABEL = "Six Side";

        readonly System.Random r = new Random();

        #region Properties
        private bool twentySideDice = false;
        public bool TwentySideDice
        {
            get { return twentySideDice; }
            set { twentySideDice = value; notifyChange(); updateBoard(); }
        }

        private DieImageCodes firstDiceImageCode = DieImageCodes.NONE;
        public DieImageCodes FirstDiceImageCode
        {
            get { return firstDiceImageCode; }
            set { firstDiceImageCode = value; notifyChange(); }
        }

        private DieImageCodes secondDiceImageCode = DieImageCodes.NONE;
        public DieImageCodes SecondDiceImageCode
        {
            get { return secondDiceImageCode; }
            set { secondDiceImageCode = value; notifyChange(); }
        }

        private int firstTwentyDice = 0;
        public int FirstTwentyDice
        {
            get { return firstTwentyDice; }
            set { firstTwentyDice = value; notifyChange(); }
        }

        private int secondTwentyDice = 0;
        public int SecondTwentyDice
        {
            get { return secondTwentyDice; }
            set { secondTwentyDice = value; notifyChange(); }
        }
        #endregion

        public void RollDice()
        {
            int die1 = r.Next(MIN_ROLL_LIMIT, TwentySideDice ? MAX_ROLL_LIMIT_TWENTY_SIDE : MAX_ROLL_LIMIT_SIX_SIDE);
            int die2 = r.Next(MIN_ROLL_LIMIT, TwentySideDice ? MAX_ROLL_LIMIT_TWENTY_SIDE : MAX_ROLL_LIMIT_SIX_SIDE);

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), RESULT_FOLDER_NAME);
            fullName = Path.Combine(filePath, FILENAME);

            output.Append($"Dice Type: {(TwentySideDice ? TWENTY_SIDE_FILE_LABEL : SIX_SIDE_FILE_LABEL)}{Environment.NewLine}");
            output.Append($"First Die: {(die1.ToString().PadLeft(2))}, Second Die: {(die2.ToString().PadLeft(2))}");
            output.AppendLine();

            File.AppendAllText(fullName, output.ToString());

            FirstDiceImageCode = (DieImageCodes)die1;
            SecondDiceImageCode = (DieImageCodes)die2;

            if (TwentySideDice)
            {
                FirstDiceImageCode = SecondDiceImageCode = DieImageCodes.TWENTY_SIDE;
                FirstTwentyDice = die1;
                SecondTwentyDice = die2;
            }
        }

        public void updateBoard()
        {
            if (TwentySideDice)
                FirstDiceImageCode = SecondDiceImageCode = DieImageCodes.TWENTY_SIDE;
            else
                FirstDiceImageCode = SecondDiceImageCode = DieImageCodes.NONE;
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyChange([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
