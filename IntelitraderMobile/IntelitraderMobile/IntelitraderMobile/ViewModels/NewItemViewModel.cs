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

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(FirstName)
                && !String.IsNullOrWhiteSpace(SurName)
                && Age > 1 && Age < 120
                && !String.IsNullOrWhiteSpace(Age.ToString());
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
            await Shell.Current.GoToAsync("..");
        }
    }
}
