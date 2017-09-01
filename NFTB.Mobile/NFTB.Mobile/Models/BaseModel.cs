using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using NFTB.Mobile.Contracts;

namespace NFTB.Mobile.Models
{

    public abstract class BaseModel : INotifyPropertyChanged
    {
        protected IContentPage UI;
        
        private bool HasLoadedPage { get; set; } = false;

        protected BaseModel(IContentPage ui)
        {
            this.UI = ui;

            ui.BindingContextChanged += (obj, args) =>
            {

            };

            ui.Appearing += async (obj, args) =>
            {
                // There is no 'loaded' event, so we fake one here
                if (!this.HasLoadedPage)
                {
                    this.HasLoadedPage = true;
                    await this.OnLoad();
                }
                await this.Appear();
            };

        }

        /// <summary>
        /// Executes every time the page appears
        /// </summary>
        /// <returns></returns>
        private async Task Appear()
        {
            await this.OnAppearing();
        }

        /// <summary>
        /// Fires when the view appears
        /// </summary>
        protected virtual async Task OnAppearing()
        {
            
        }

        /// <summary>
        /// On load, runs once each time the page is created
        /// </summary>
        protected virtual async Task OnLoad()
        {

        }

        public virtual bool IsModalPage => false;

        protected async Task GoToPage(IContentPage page)
        {
            //await this.Try(async () =>
            //{
            //    await this.UI.Navigation.PushAsync(page as Page);
            //});
            await this.UI.Navigation.PushAsync(page as Page);
        }

        protected async Task ClosePage()
        {
            //await this.Try(async () =>
            //{
            //    await this.UI.Navigation.PopAsync();
            //});
            await this.UI.Navigation.PopAsync();
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
