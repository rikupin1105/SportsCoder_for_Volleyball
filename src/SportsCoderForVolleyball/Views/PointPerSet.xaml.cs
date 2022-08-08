using System.Windows.Controls;

namespace SportsCoderForVolleyball.Views
{
    /// <summary>
    /// Interaction logic for PointPerSet
    /// </summary>
    public partial class PointPerSet : UserControl
    {
        public PointPerSet()
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
