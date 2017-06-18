using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;

namespace NFTB.Mobile.Logic.DataManagers
{
    public class AttendanceManager
    {

        public async Task<List<AttendanceSummary>> GetAttendances()
        {
            BaseAPI<List<AttendanceSummary>> api = new BaseAPI<List<AttendanceSummary>>();
            api.RelativeUrl = "attendance/attendancelist";
            var result = await api.GetAsync();
            return result;
        }



        public async Task DeleteAttendance(int attendanceID)
        {
            BaseAPI<Task> api = new BaseAPI<Task>();
            api.RelativeUrl = "attendance/deleteattendance";
            api.RelativeUrl += "?attendanceID=" + attendanceID;
            await api.GetAsync();
        }
    }
}
