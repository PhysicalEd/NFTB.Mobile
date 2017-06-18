using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendanceEditor : ContentPage
    {
        public AttendanceEditor()
        {
            InitializeComponent();
            this.BindingContext = new PlayerListModel(this);
        }

        public void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
