using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;

namespace NFTB.Mobile.Logic.DataManagers
{
    public class PersonManager
    {

        public async Task<List<Person>> GetPlayers()
        {
            BaseAPI<Person> api = new BaseAPI<Person>();
            api.RelativeUrl = "person/";
            var result = await api.GetAsync();
            return result;
        }
    }
}
