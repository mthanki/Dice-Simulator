using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dice_Simulator
{
    class VM : INotifyPropertyChanged
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

        public enum DiceSounds
        {
            ONE = 1,
            TWO,
            THREE
        }

        const int MIN_ROLL_LIMIT = 1;
        const int MAX_ROLL_LIMIT_SIX_SIDE = 7;
        const int MAX_ROLL_LIMIT_TWENTY_SIDE = 21;

        readonly System.Random r = new Random();

        #region Properties
        private bool twentySideDice = false;
        public bool TwentySideDice
        {
            get { return twentySideDice; }
            set { twentySideDice = value; notifyChange(); updateBoard(); }
        }

        private bool sound = false;
        public bool Sound
        {
            get { return sound; }
            set { sound = value; notifyChange(); }
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
