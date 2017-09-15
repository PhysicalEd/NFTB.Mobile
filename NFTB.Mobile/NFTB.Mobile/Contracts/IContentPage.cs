using System;
using NFTB.Mobile.Models;
using Xamarin.Forms;

namespace NFTB.Mobile.Contracts
{
    public interface IContentPage
    {
        INavigation Navigation { get; }
        string Title { set; }
        event EventHandler BindingContextChanged;
        event EventHandler Appearing;
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e);
        void OnEditContextAction(object sender, EventArgs e);
    }

    public interface IContentPage<T> : IContentPage where T : BaseModel
    {
        object BindingContext { get; }
    }

    public interface IContentMultiPage<T> : IContentPage<T> where T : BaseModel
    {
        Page Detail { get; set; }
        void CloseMenu();
    }
}