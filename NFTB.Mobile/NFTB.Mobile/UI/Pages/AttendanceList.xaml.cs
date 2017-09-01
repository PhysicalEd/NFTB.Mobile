using NFTB.Mobile.Contracts;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendanceList : IContentPage<AttendanceListModel>
    {
        public AttendanceList()
        {
            InitializeComponent();
            var bindingContext = new AttendanceListModel(this);
            //bindingContext.FilterPicker = this.PlayerListFilter;
            this.BindingContext = bindingContext;
        }


        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.AttendanceListView.SelectedItem = null;
        }
    }
}
