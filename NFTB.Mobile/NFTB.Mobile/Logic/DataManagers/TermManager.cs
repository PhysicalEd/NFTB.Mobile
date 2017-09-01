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

        public async Task SaveTerm(TermSummary term)
        {
            BaseAPI<Task> api = new BaseAPI<Task>();
            api.RelativeUrl = "term/saveterm";
            api.ParameterDictionary.Add("TermID", term.TermID.ToString());
            api.ParameterDictionary.Add("TermName", term.Name);
            api.ParameterDictionary.Add("TermStart", term.TermStart.ToString());
            api.ParameterDictionary.Add("TermEnd", term.TermEnd.ToString());
            api.ParameterDictionary.Add("BondAmount", term.BondAmount.ToString());
            api.ParameterDictionary.Add("CasualRate", term.CasualRate.ToString());
            api.ParameterDictionary.Add("IncludeOrganizer", term.IncludeOrganizer.ToString());
            api.ParameterDictionary.Add("IsDeleted", false.ToString());
            api.ParameterDictionary.Add("IsActive", false.ToString());
            api.ParameterDictionary.Add("IsInvoiced", term.IsInvoiced.ToString());
            await api.GetAsync();
        }
    }
}
