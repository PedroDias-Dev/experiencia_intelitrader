using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string firstName;
        private string surName;
        private int age;

        APIUserService _userAPIService;

        public NewItemViewModel()
        {
            _userAPIService = new APIUserService();

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(surName)
                && !String.IsNullOrWhiteSpace(age.ToString());
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string SurName
        {
            get => surName;
            set
            {
                surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            User newItem = new User()
            {
                firstName = FirstName,
                surName = SurName,
                age = Age,
            };
            Console.WriteLine(newItem);

            await _userAPIService.AddUser(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
