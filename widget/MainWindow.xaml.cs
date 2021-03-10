using System;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace widget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String Url;
        public MainWindow()
        {
            
                try
                {
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    Assembly curAssembly = Assembly.GetExecutingAssembly();
                    key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
                }
                catch { }
            
            ShowInTaskbar = false;

            Window form1 = new Window();

            
            form1.ShowInTaskbar = false;
            form1.Show();
            form1.Visibility = Visibility.Hidden;
            form1.WindowStyle = WindowStyle.ToolWindow;
            Owner = form1;
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = SystemParameters.PrimaryScreenWidth / 2 - 400;
            Top = SystemParameters.PrimaryScreenHeight - 400;
            InitializeComponent();
            this.ShowInTaskbar = false;
            Focusable = false;
            
        }
        
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            Hint.Visibility = Visibility.Visible;
            FocusManager.SetFocusedElement(this, null);
            txtSearchBox.Text = "";
            

        }
       


        private void txtSearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Hint.Visibility = Visibility.Hidden;
            Console.WriteLine("WARWEAQRW");
        }

        private void txtSearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
                
                
               
                System.Diagnostics.Process.Start("https://google.com/search?q=" + txtSearchBox.Text);

                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(txtSearchBox), null);

                txtSearchBox.Text = "";
                
                
                Hint.Visibility = Visibility.Visible;
            }

        }
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            this.WindowState = WindowState.Normal;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
         
            
        }

        private void txtSearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Hint.Visibility = Visibility.Visible;
            txtSearchBox.Text = "";
        }
    }
}
