using System.Windows;
using System.Windows.Controls;

namespace DesktopApplication.GeneralControl.PaginationControl
{
    public partial class MVVMPaginator : UserControl
    {
        public MVVMPaginator()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty PaginationTextProperty = DependencyProperty.Register("PaginationText", typeof(string), typeof(MVVMPaginator), new PropertyMetadata(null));

        public string PaginationText
        {
            get { return (string)GetValue(PaginationTextProperty); }
            set { SetValue(PaginationTextProperty, value); }
        }

        public static readonly DependencyProperty PageListProperty = DependencyProperty.Register("PageList", typeof(object), typeof(MVVMPaginator), new PropertyMetadata(null));

        public object PageList
        {
            get { return GetValue(PageListProperty); }
            set { SetValue(PageListProperty, value); }
        }

        public static readonly DependencyProperty SelectedPageIndexProperty = DependencyProperty.Register("SelectedPageIndex", typeof(object), typeof(MVVMPaginator), new PropertyMetadata(null));

        public object SelectedPageIndex
        {
            get { return GetValue(SelectedPageIndexProperty); }
            set { SetValue(SelectedPageIndexProperty, value); }
        }
    }
}
