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
using NFTB.Mobile.Models;

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

        //public async Task<AttendanceEditorModel> EditAttendance()
        //{
        //    //BaseAPI<List<AttendanceSummary>> api = new BaseAPI<List<AttendanceSummary>>();
        //    //api.RelativeUrl = "attendance/attendancelist";
        //    //var result = await api.GetAsync();
        //    //return result;
        //    return null;
        //}

        public async Task DeleteAttendance(int attendanceID)
        {
            BaseAPI<Task> api = new BaseAPI<Task>();
            api.RelativeUrl = "attendance/deleteattendance";
            api.RelativeUrl += "?attendanceID=" + attendanceID;
            await api.GetAsync();
        }

        public async Task<AttendanceEditorModelResult> GetAttendanceEditorModel(AttendanceSummary attendance)
        {
            BaseAPI<AttendanceEditorModelResult> api = new BaseAPI<AttendanceEditorModelResult>();
            api.RelativeUrl = "attendance/attendanceeditor";
            api.ParameterDictionary.Add("AttendanceID", attendance.AttendanceID.ToString());
            // EO TODO Need to get the active term
            api.ParameterDictionary.Add("TermID", "1");
            try
            {
                var result = await api.GetAsync();
                return result;

            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public async Task<AttendanceSummary> SaveAttendance(AttendanceSummary attendance)
        {
            BaseAPI<AttendanceSummary> api = new BaseAPI<AttendanceSummary>();
            api.RelativeUrl = "attendance/saveattendance";
            return await api.PostAsync(attendance);
        }
    }
}
