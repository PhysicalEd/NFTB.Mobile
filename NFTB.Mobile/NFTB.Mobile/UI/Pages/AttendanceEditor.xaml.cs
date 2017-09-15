using System;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendanceEditor : IContentPage<AttendanceEditorModel>
    {
        public AttendanceEditor(AttendanceSummary attendance)
        {
            InitializeComponent();
            this.BindingContext = new AttendanceEditorModel(this, attendance);
        }
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
        public void OnEditContextAction(object sender, EventArgs e)
        {
        }
    }
}
