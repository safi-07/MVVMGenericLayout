using DesktopApplication.UserControls.Branches;
using DesktopApplication.UserControls.Shelves;
using System.Windows;

namespace DesktopApplication
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

        private void BranchBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Children.Clear();
            ContentArea.Children.Add(new SearchBranch());
        }
        private void ShelfBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Children.Clear();
            ContentArea.Children.Add(new SearchShelf());
        }

        private void ClearAllContentAreaChildrens()
        {
            ContentArea.Children.Clear();
        }
    }
}
