using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.IO;

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
            SIX
        }

        public enum DiceSounds
        {
            ONE = 1,
            TWO,
            THREE,
            FOUR
        }

        readonly System.Random r = new Random();

        #region Properties
        private bool twentySideDice = false;
        public bool TwentySideDice
        {
            get { return twentySideDice; }
            set { twentySideDice = value; notifyChange(); }
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
        #endregion

        public void RollDice()
        {
            int die1 = r.Next(1, 7);
            int die2 = r.Next(1, 7);

            FirstDiceImageCode = (DieImageCodes)die1;
            SecondDiceImageCode = (DieImageCodes)die2;

            //string rollSound = Environment.CurrentDirectory + $"..\\..\\..\\Sounds\\4.wav";
            //SoundPlayer s = new SoundPlayer();
            //s.SoundLocation = testrollSound;
            //s.Load();
            //s.Play();
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
