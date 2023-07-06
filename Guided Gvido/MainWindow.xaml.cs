using System.Windows;
using System.Windows.Input;

namespace Guided_Gvido
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OPEN WIDOW UI_REGISTERED_USER
            UI_REGISTERED_USER UI_REGISTERED_USER = new UI_REGISTERED_USER();
            UI_REGISTERED_USER.Show();
            this.Close();
        }

        private void Language_Click(object sender, RoutedEventArgs e)
        {
            LBOX.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LVMadmin lVMadmin = new LVMadmin();
            lVMadmin.Show();
        }

        private void LT_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LVMADMIN.Content = "LVM Administrators";
            Language.Content = "Valoda";
            Register.Content = "Reģistrēties";
            LBOX.Visibility = Visibility.Hidden;
        }

        private void RU_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LVMADMIN.Content = "LVM Администратор";
            Language.Content = "Язык";
            Register.Content = "регистр";
            LBOX.Visibility = Visibility.Hidden;
        }

        private void EN_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LVMADMIN.Content = "LVM Admin";
            Language.Content = "Language";
            Register.Content = "Reģistrēties";
            LBOX.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login_window LGWINDOW = new Login_window();
            LGWINDOW.Show();
        }

        private void LVM_admin_click(object sender, RoutedEventArgs e)
        {
        }
    }
}