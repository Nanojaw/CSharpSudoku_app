using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sudoku;

namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> _sudoku;

        public MainWindow()
        {
            InitializeComponent();
            _sudoku = Backend.GenerateSudoku(0.5).GetRange(0, 81);
            FillGrid();
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            ((Button) sender).KeyUp += SetNumber;
        }

        private void SetNumber(object sender, KeyEventArgs e)
        {
            if (e.Key is not (>= Key.D1 and <= Key.D9 or >= Key.NumPad1 and <= Key.NumPad9 or Key.Back)) return;

            var cell = (Button) sender;

            var key = new KeyConverter().ConvertToString(e.Key) ?? "";

            // Removing a number
            if (e.Key == Key.Back)
            {
                cell.Content = "";
                _sudoku[MainBoard.Children.IndexOf(cell)] = -1;
                cell.KeyUp -= SetNumber;
                return;
            }

            // Only insert number if it fits
            if (Backend.Fits(_sudoku, int.Parse(key), MainBoard.Children.IndexOf(cell)))
            {
                cell.Content = key;
                _sudoku[MainBoard.Children.IndexOf(cell)] = int.Parse(key);
                cell.KeyUp -= SetNumber;
            }
            else // Otherwise play an animation
            {
                cell.Background = new SolidColorBrush(((SolidColorBrush)cell.Background).Color);
                var anim = new ColorAnimation()
                {
                    From = ((SolidColorBrush)cell.Background).Color,
                    To = Colors.Red,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                    AutoReverse = true
                };
                cell.Background.BeginAnimation(SolidColorBrush.ColorProperty, anim);
            }
        }

        private void FillGrid()
        {
            for (var i = 0; i < MainBoard.Children.Count; i++)
            {
                var cell = (Button) MainBoard.Children[i];
                cell.Content = _sudoku[i].ToString();
            }
        }
    }
}
