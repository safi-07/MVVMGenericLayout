using System.Windows;
using System.Windows.Controls;

namespace DesktopApplication.UserControls.GenericLayout.CRUD
{
    /// <summary>
    /// Interaction logic for MainTemplate.xaml
    /// </summary>
    public partial class MainTemplate : UserControl
    {
        public MainTemplate()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(MainTemplate), new PropertyMetadata(null));

        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty FilterPanelProperty = DependencyProperty.Register("FilterPanel", typeof(object), typeof(MainTemplate), new PropertyMetadata(null));

        public object FilterPanel
        {
            get { return GetValue(FilterPanelProperty); }
            set { SetValue(FilterPanelProperty, value); }
        }

        public static readonly DependencyProperty ResultPanelProperty = DependencyProperty.Register("ResultPanel", typeof(object), typeof(MainTemplate), new PropertyMetadata(null));

        public object ResultPanel
        {
            get { return GetValue(ResultPanelProperty); }
            set { SetValue(ResultPanelProperty, value); }
        }

        public static readonly DependencyProperty UpdatePanelProperty = DependencyProperty.Register("UpdatePanel", typeof(object), typeof(MainTemplate), new PropertyMetadata(null));

        public object UpdatePanel
        {
            get { return GetValue(UpdatePanelProperty); }
            set { SetValue(UpdatePanelProperty, value); }
        }
        
    }
}
