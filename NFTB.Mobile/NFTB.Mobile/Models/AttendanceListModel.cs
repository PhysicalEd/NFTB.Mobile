using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class AttendanceListModel : BaseModel
    {
        public ObservableCollection<AttendanceSummary> AttendanceList { get; set; } = new ObservableCollection<AttendanceSummary>();

        public ICommand OnAddAttendance
        {
            get
            {
                return new Command(() =>
                {
                    this.SelectedAttendance = null;
                });
            }
        }

        public AttendanceSummary _SelectedAttendance { get; set; }
        public AttendanceSummary SelectedAttendance
        {
            get { return this._SelectedAttendance; }
            set
            {
                this._SelectedAttendance = value;
                this.EditAttendance();
            }
        }

        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get { return this._IsBusy; }
            set
            {
                if (this._IsBusy == value) return;
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        public AttendanceListModel(ContentPage ui) : base(ui)
        {
            this.GetAttendances();
        }

        public async Task EditAttendance()
        {
            var attendanceEditor = new AttendanceEditor(this.SelectedAttendance);
            await this.UI.Navigation.PushAsync(attendanceEditor);
        }

        public async Task GetAttendances()
        {
            this.AttendanceList.Clear();
            var attendanceMgr = new AttendanceManager();
            var attendances = await attendanceMgr.GetAttendances();
            foreach (var attendance in attendances)
            {
                this.AttendanceList.Add(attendance);
            }
            this.IsBusy = false;
        }
    }
}
