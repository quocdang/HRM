using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BUS;
using DTO;
using System.Windows.Media;

namespace HRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> _mdiChildren = new Dictionary<string, string>();
        private Dictionary<UserControl, string> TabActive = new Dictionary<UserControl, string>();
        public MainWindow()
        {
            
            InitializeComponent();
            Create();
        }

        public void Create() // create a dyamic tab from data
        {
            StackPanel stack = new StackPanel();
            stack.Name = "StackExpander";
            MenuGrid.Children.Add(stack);

            var lstMenuCha = BUS.BUS.GetMenuCha(0);
            for (int i = 0; i < lstMenuCha.Count; i++)
            {
                Expander expand = new Expander(); // create expander
                expand.Name = (string)lstMenuCha[i].NameEN;
                expand.Header = (string)lstMenuCha[i].Name;
                expand.Style = (Style)FindResource("OutlookStyleExpanderStyle"); // set style for expander;
                stack.Children.Add(expand); // grid add expander.
                ListBox lstbox = new ListBox(); // create listbox
                lstbox.ItemContainerStyle = (Style)FindResource("ExpanderMenuListitemStyle"); //set style for listbox
                expand.Content = lstbox; // add listbox into expander
                List<DTO.SYS_MENU> lstMenuCon = BUS.BUS.GetMenuCha(lstMenuCha[i].ID);
                for (int j = 0; j < lstMenuCon.Count; j++)
                {
                    ListBoxItem lstboxItem = new ListBoxItem(); // create listboxItem
                    lstboxItem.Name = (string)lstMenuCon[j].NameEN;
                    lstboxItem.Content = (string)lstMenuCon[j].Name;
                    lstbox.Items.Add(lstboxItem); // add listboxitem into listbox
                    lstboxItem.MouseDoubleClick += ListBoxItem_MouseDoubleClick; // event click to show usercontrol on the right content.

                }
            }
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem LstboxItem = sender as ListBoxItem;
            string LstboxItemName = LstboxItem.Name;

            Type UserControlType = typeof(UserControl);// get form type
            var s = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()) // get all class of winform
                if (type.Name == LstboxItemName)//fill all of class is form type
                {
                    UserControl UCname = (UserControl)Activator.CreateInstance(type); // create form => form is active                    
                    WPFTabbedMDI d = (WPFTabbedMDI)UCname;
                    AddTab(d);
                }
        }

        public UserControl GetActiveUC()
        {
            // Returns null for an MDI app
            UserControl activeUserControl = new UserControl();

            //foreach (var item in ActiveChild)
            //{
            //    if ( item.Value == true )
            //    {
                    
            //        activeUserControl = item.Key;
            //    }
            //}
            foreach (var Item in TabActive)
            {
                if (Item.Value == RightGrid.SelectedItem.ToString())
                {

                    activeUserControl = Item.Key;
                }
            }
            return activeUserControl;
        }

        private void AddTab(WPFTabbedMDI mdiChild)
        {
            //Check if the user control is already opened
            if (_mdiChildren.ContainsKey(mdiChild.UniqueTabName))
            {
                //user control is already opened in tab. 
                //So set focus to the tab item where the control hosted
                foreach (object item in RightGrid.Items)
                {
                    TabItem ti = (TabItem)item;
                    if (ti.Name == mdiChild.UniqueTabName)
                    {
                        ti.Focus();
                        break;
                    }
                }
            }
            else
            {
                //the control is not open in the tab item
                RightGrid.Visibility = Visibility.Visible;
                RightGrid.Width = this.ActualWidth;
                RightGrid.Height = this.ActualHeight;
                
                //create a new tab item
                TabItem ti = new TabItem();
                //set the tab item's name to mdi child's unique name
                ti.Name = ((WPFTabbedMDI)mdiChild).UniqueTabName;
                //set the tab item's title to mdi child's title
                ti.Header = ((WPFTabbedMDI)mdiChild).Title;
                //set the content property of the tab item to mdi child
                ti.Content = mdiChild;

                ScrollViewer scroll = new ScrollViewer();
                scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                //add the tab item to tab control
                RightGrid.Items.Add(ti);
                //set this tab as selected
                RightGrid.SelectedItem = ti;
                //add the mdi child's unique name in the open children's name list
                _mdiChildren.Add(((WPFTabbedMDI)mdiChild).UniqueTabName, ((WPFTabbedMDI)mdiChild).Title);
                TabActive.Add(((WPFTabbedMDI)mdiChild).CurrType, RightGrid.SelectedItem.ToString());
            }
            
        }
        
        private void tabItemCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = sender as DependencyObject;
            while (!(obj is TabItem))
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            TabItem tabItem = obj as TabItem;
            string key = tabItem.Header.ToString();
            RightGrid.Items.Remove(obj);
            _mdiChildren.Remove(key);
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            UserControl activeUC = GetActiveUC();
            var uc = activeUC;
            if (activeUC == null) return;
            var medEdit = activeUC as WPFTabbedMDI;
            medEdit.Save();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            UserControl activeUC = GetActiveUC();
            var uc = activeUC;
            if (activeUC == null) return;
            var medEdit = activeUC as WPFTabbedMDI;
            medEdit.Delete();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
