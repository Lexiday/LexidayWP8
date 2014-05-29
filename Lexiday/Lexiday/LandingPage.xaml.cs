using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Parse;

namespace Lexiday
{
    public partial class LandingPage : PhoneApplicationPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
            if (ParseUser.CurrentUser != null)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                
            }
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ParseUser.LogInAsync(userNameBox.Text, passwordBox.Password);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch (Exception exe)
            {
                MessageBox.Show("Login failed");
                // The login failed. Check the error to see why.
            }
        }

        private async void signupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = new ParseUser()
                {
                    Username = userNameBox.Text,
                    Password = passwordBox.Password,
                    Email = userNameBox.Text
                };

                // other fields can be set just like with ParseObject


                await user.SignUpAsync();
                MessageBox.Show("Sign Up was Successful");
            }
            catch
            {
                MessageBox.Show("Sign Up Failed");
            }
        }
    }
}