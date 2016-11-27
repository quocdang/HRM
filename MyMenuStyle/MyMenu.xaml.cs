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

namespace HRM
{
    /// <summary>
    /// Interaction logic for MyMenu.xaml
    /// </summary>
    /// [ContentProperty("Child")]
    public partial class MyMenu : UserControl
    {
        public static readonly DependencyProperty ChildProperty =
                DependencyProperty.Register("Child", typeof(UIElement), typeof(MyMenu), new UIPropertyMetadata(null));
        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }
        public MyMenu()
        {
            InitializeComponent();
        }
    }
}
