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
    /// Interaction logic for UpdateLayoutTemplate.xaml
    /// </summary>
    public partial class UpdateLayoutTemplate : UserControl
    {
        public UpdateLayoutTemplate()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty UpdateTitleProperty = DependencyProperty.Register("UpdateTitle", typeof(object), typeof(UpdateLayoutTemplate), new PropertyMetadata(null));

        public object UpdateTitle
        {
            get { return GetValue(UpdateTitleProperty); }
            set { SetValue(UpdateTitleProperty, value); }
        }

        public static readonly DependencyProperty InputControlsProperty = DependencyProperty.Register("InputControls", typeof(object), typeof(UpdateLayoutTemplate), new PropertyMetadata(null));

        public object InputControls
        {
            get { return GetValue(InputControlsProperty); }
            set { SetValue(InputControlsProperty, value); }
        }
    }
}
