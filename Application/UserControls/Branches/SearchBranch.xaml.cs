using DesktopApplication.ViewModels.Branch;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApplication.UserControls.Branches
{
    public partial class SearchBranch : UserControl
    {
        #region[Contructor]
        public SearchBranch()
        {
            InitializeComponent();
            Loaded += SearchBranch_Loaded;
        }
        private void SearchBranch_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext= new BranchViewModel();
        }
        #endregion
    }
}
