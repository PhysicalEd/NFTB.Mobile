﻿using System;
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
            BaseAPI<List<Person>> api = new BaseAPI<List<Person>>();
            api.RelativeUrl = "person/peoplelist";
            var result = await api.GetAsync();
            return result;
        }
    }
}
