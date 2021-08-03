using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using IntelitraderMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private User _selectedItem;
        public ObservableCollection<User> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<User> ItemTapped { get; }

        APIUserService _userAPIService;

        public ItemsViewModel()
        {
            Title = "Users";
            Items = new ObservableCollection<User>();

            _userAPIService = new APIUserService();

            ExecuteLoadItemsCommand();

            ItemTapped = new Command<User>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        public async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _userAPIService.GetUsers();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.id}");
        }
    }
}