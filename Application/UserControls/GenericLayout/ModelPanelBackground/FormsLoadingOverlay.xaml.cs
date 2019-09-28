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

namespace DesktopApplication.UserControls.ModelPanelBackground
{
    /// <summary>
    /// Interaction logic for FormsLoadingOverlay.xaml
    /// </summary>
    public partial class FormsLoadingOverlay : UserControl
    {
        public FormsLoadingOverlay()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty LoadingTextProperty = DependencyProperty.Register("LoadingText", typeof(object), typeof(FormsLoadingOverlay), new PropertyMetadata(null));

        public object LoadingText
        {
            get { return GetValue(LoadingTextProperty); }
            set { SetValue(LoadingTextProperty, value); }
        }

    }
}
