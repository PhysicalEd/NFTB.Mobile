using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendanceEditor : ContentPage
    {
        public AttendanceEditor(AttendanceSummary attendance)
        {
            InitializeComponent();
            this.BindingContext = new AttendanceEditorModel(this, attendance);
        }

        public void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
