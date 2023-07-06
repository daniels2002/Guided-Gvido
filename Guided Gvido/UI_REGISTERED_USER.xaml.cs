using Npgsql;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Guided_Gvido
{
    /// <summary>
    /// Interaction logic for UI_REGISTERED_USER.xaml
    /// </summary>

    //Important:
    //This is the code for the UI_REGISTERED_USER window.
    //The code is used to check if the user has entered valid data.
    //The code is also used to check if the user has entered a unique email,username,password,surname,name,phone number.

    //Latvian University of Life Sciences and Technologies (LBTU)
    //Faculty of Computer Science and Information Technology (FCSIT)
    //Team leader: Daniels Rafaels
    //Izstrādātāji:Gvido Vītols un Daniels Rafaels (daniels.rafaels2002@gmail.com)
    //Kurss: 2. kurss
    //Grupa: a2. grupa
    // Testēts: Datums: 2023. gada 2. Aprīli

    public partial class UI_REGISTERED_USER : Window
    {
        /*Globla variables are used to check if the user has entered a unique

         * email,
         * username,
         * password,
         * surname,
         * name,
         * phone number.

         */
        public int t_count;
        public int f_count;
        public bool validation = true;
        public bool validation1 = true;
        public bool passw = true;
        public bool epasts = true;

        public UI_REGISTERED_USER()
        {
            InitializeComponent();

            var connectionString = "Host=localhost;Username=postgres;Password=students;Database=postgres";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        }

        //1) The function Text_BoxNameChanged is used to check if the name entered by the user is valid.

        private void TextBox_NameChanged(object sender, TextChangedEventArgs e)
        {
            var regex = @"^([A-Z]{1})\w+$";
            Match match = Regex.Match(User_name.Text, regex);
            Validation(match, User_name);
            if (match.Success)
            {
                validation1 = true;
            }
            else
            {
                validation1 = false;
            }
        }

        //2) The function Text_BoxSurnameChanged is used to check if the surname entered by the user is valid.
        private void Texbox_SurnameChanged(object sender, TextChangedEventArgs e)
        {
            var regex = @"^([A-Z]{1})\w+$";
            Match match = Regex.Match(User_surname.Text, regex);
            Validation(match, User_surname);
            if (match.Success)
            {
                validation = true;
            }
            else
            {
                validation = false;
            }
        }

        //3) The function Text_BoxEmailChanged is used to check if the email entered by the user is valid.
        private void TextBox_EmailChanged(object sender, TextChangedEventArgs e)
        {
            var regex = @"\S+@\S+\.\S+";
            Match match = Regex.Match(User_email.Text, regex);
            Validation(match, User_email);
            if (match.Success)
            {
                epasts = true;
            }
            else
            {
                epasts = false;
            }
        }

        //4) The function Text_BoxPasswordChanged is used to check if the password entered by the user is valid.
        private void User_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            //The regex is used to check if the password is valid.
            var regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            //The Match class reprezents the results of a single regular expression match.
            Match match = Regex.Match(User_password.Text, regex);
            Validation(match, User_password);
            if (match.Success)
            {
                passw = true;
            }
            else
            {
                passw = false;
            }
        }

        //The function Validate_fields is used to check if all the fields are valid.
        private void Validate_fields(object sender, RoutedEventArgs e)
        {
            if (validation == false || validation1 == false || epasts == false || passw == false)
            {
                MessageBox.Show("Dati ievadīti nepareizi", "Kļuda", MessageBoxButton.OK);
            }
            else if (User_name.Text == "" && User_surname.Text == "" && User_email.Text == " ")
            {
                MessageBox.Show("Lūdzu ievadiet datus");
            }
            else
            {
                MessageBox.Show("Dati ievadīti pareizi", "Lauki aizpildīti parezi", MessageBoxButton.OK);
            }
        }

        //The function Validation is used to check if the fields are valid.

        public void Validation(Match match, TextBox text)
        {
            //There are two variables t and f. If the field is valid t is increased by 1 and if the field is not valid f is increased by 1.
            t_count = 0;
            f_count = 0;
            if (match.Success)
            {
                text.BorderBrush = Brushes.Black;
                text.Foreground = Brushes.Black;
                t_count = t_count + 1;
            }
            else
            {
                text.BorderBrush = Brushes.Red;
                text.Foreground = Brushes.Red;
                f_count = f_count + 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
    }
}