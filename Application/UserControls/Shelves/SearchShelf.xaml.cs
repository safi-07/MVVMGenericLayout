using DesktopApplication.ViewModels.Branch;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApplication.UserControls.Shelves
{
    public partial class SearchShelf : UserControl
    {
        #region[Contructor]
        public SearchShelf()
        {
            InitializeComponent();
            Loaded += SearchShelf_Loaded;
        }
        private void SearchShelf_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ShelfViewModel();
        }
        #endregion
    }
}
