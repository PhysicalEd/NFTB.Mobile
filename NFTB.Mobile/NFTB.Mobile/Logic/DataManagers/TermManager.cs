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
    public class TermManager
    {

        public async Task<List<TermSummary>> GetTerms(bool? includeDeleted)
        {
            BaseAPI<List<TermSummary>> api = new BaseAPI<List<TermSummary>>();
            api.RelativeUrl = "term/termlist";
            api.ParameterDictionary.Add("IncludeDeleted", includeDeleted.ToString());
            var result = await api.GetAsync();
            return result;
        }

        public async Task DeleteTerm(int? termID)
        {
            BaseAPI<Task> api = new BaseAPI<Task>();
            api.RelativeUrl = "term/deleteterm";
            api.ParameterDictionary.Add("TermID", termID.ToString());
            await api.GetAsync();
        }
    }
}
