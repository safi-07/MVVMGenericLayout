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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApplication.UserControls.GenericLayout.CRUD
{
    /// <summary>
    /// Interaction logic for FilterLayout.xaml
    /// </summary>
    public partial class FilterLayoutTemplate : UserControl
    {
        public FilterLayoutTemplate()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty FilterPanelContentProperty = DependencyProperty.Register("FilterPanelContent", typeof(object), typeof(FilterLayoutTemplate), new PropertyMetadata(null));

        public object FilterPanelContent
        {
            get { return GetValue(FilterPanelContentProperty); }
            set { SetValue(FilterPanelContentProperty, value); }
        }
    }
}
