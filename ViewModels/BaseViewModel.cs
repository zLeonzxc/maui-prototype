﻿using System.ComponentModel;
using System.Windows.Input;
using ess_prototype.Pages;

namespace ess_prototype.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand LogoutCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BaseViewModel()
        {
            LogoutCommand = new Command(OnLogout);
        }

        private void OnLogout()
        {
            if (Application.Current?.MainPage != null)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}