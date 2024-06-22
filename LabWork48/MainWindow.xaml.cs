using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace LabWork48
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != null || surnameTextBox.Text != null || countryTextBox.Text != null)
            {
                try
                {
                    DataAccessLayer.AddAuthor(nameTextBox.Text, surnameTextBox.Text, countryTextBox.Text);
                    MessageBox.Show($"{nameTextBox.Text} {surnameTextBox.Text} успешно добавлен в БД");

                }
                catch
                {
                    MessageBox.Show("Не удалось выполнить запрос");
                }
            }
            else
            {
                MessageBox.Show("Заполните данные");
            }
        }

        private void AddAuthorIdButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (surnameTextBox.Text != null || nameTextBox.Text != null || countryTextBox.Text != null)
                {
                    MessageBox.Show($"{DataAccessLayer.GetAuthorId(nameTextBox.Text, surnameTextBox.Text, countryTextBox.Text)} {nameTextBox.Text} {surnameTextBox.Text} успешно добавлен в БД");
                }
                else
                {
                    MessageBox.Show("Заполните данные");
                }
               
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить запрос");
            }
        }
    }
}