using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lexiday.Resources;
using Lexiday.ViewModels;

using Parse;

namespace Lexiday
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (NavigationService.CanGoBack)//Removes back entries so users cant go back without logout
            {
                NavigationService.RemoveBackEntry();
            }

            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            //if (MainLongListSelector.SelectedItem == null)
            //    return;

            //// Navigate to the new page
            //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            //// Reset selected item to null (no selection)
            //MainLongListSelector.SelectedItem = null;
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem logoutButton = new ApplicationBarMenuItem("log out");
            ApplicationBar.MenuItems.Add(logoutButton);
            logoutButton.Click += logoutButton_Click;
            
        }

        /// <summary>
        /// Event handler for logout clicl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logoutButton_Click(object sender, EventArgs e)
        {
            ParseUser.LogOut();
            var currentUser = ParseUser.CurrentUser; // this will now be null
            NavigationService.Navigate(new Uri("/LandingPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}