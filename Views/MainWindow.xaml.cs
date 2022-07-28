using System.Collections.ObjectModel;
using System.Windows;

namespace SportsCoderForVolleyball.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dataGrid.UnselectAllCells();
            dataGrid.UnselectAll();
        }
    }
}
