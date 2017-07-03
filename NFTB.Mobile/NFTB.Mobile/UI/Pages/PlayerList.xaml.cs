﻿using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerList : ContentPage
    {
        public PlayerList()
        {
            InitializeComponent();
            var bindingContext = new PlayerListModel(this);
            bindingContext.FilterPicker = this.PlayerListFilter;
            this.BindingContext = bindingContext;
        }

        public new virtual void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
