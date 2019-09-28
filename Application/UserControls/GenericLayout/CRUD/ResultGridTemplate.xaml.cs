using System.Windows;
using System.Windows.Controls;

namespace DesktopApplication.UserControls.GenericLayout.CRUD
{
    /// <summary>
    /// Interaction logic for ResultGridTemplate.xaml
    /// </summary>
    public partial class ResultGridTemplate : UserControl
    {
        public static readonly DependencyProperty ResultDataGridProperty = DependencyProperty.Register("ResultDataGrid", typeof(object), typeof(MainTemplate), new PropertyMetadata(null));
        public object ResultDataGrid
        {
            get { return GetValue(ResultDataGridProperty); }
            set { SetValue(ResultDataGridProperty, value); }
        }
        public ResultGridTemplate()
        {
            InitializeComponent();
        }
    }
}
