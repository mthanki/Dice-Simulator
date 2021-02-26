using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Dice_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm = new VM();

        const string FILENAME = "output.txt";
        const string RESULT_FOLDER_NAME = "DiceSim";

        readonly StringBuilder output = new StringBuilder();
        readonly string fullName;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.RollDice();
        }
    }
}
