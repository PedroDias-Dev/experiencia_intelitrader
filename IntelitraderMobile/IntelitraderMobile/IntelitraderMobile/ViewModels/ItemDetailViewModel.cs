using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string firstName;
        private string surName;
        private int age;
        private bool _isPlaceHolderVisible;
        public Guid id { get; set; }

        APIUserService _userAPIService;

        public ItemDetailViewModel()
        {
            _userAPIService = new APIUserService();

            DeleteItemCommand = new Command(DeleteItemId);
            EditItemCommand = new Command(EditItemId);
        }

        public bool IsPlaceHolderVisible
        {
            get => _isPlaceHolderVisible;
            set
            {
                _isPlaceHolderVisible = value;
            }
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await _userAPIService.GetUser(itemId);

                id = item.id;
                FirstName = item.firstName;
                SurName = item.surName;
                Age = item.age;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void DeleteItemId()
        {
            try
            {
                await _userAPIService.DeleteUser(itemId);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void EditItemId()
        {
            User newItem = new User()
            {
                firstName = FirstName,
                surName = SurName,
                age = Age,
            };

            await _userAPIService.UpdateUser(itemId, newItem);

            await Shell.Current.GoToAsync("..");
        }

        public Command DeleteItemCommand { get; }
        public Command EditItemCommand { get; }
    }
}
