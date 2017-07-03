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
    public class PlayerManager
    {

        public async Task<List<PlayerSummary>> GetPlayers()
        {
            BaseAPI<List<PlayerSummary>> api = new BaseAPI<List<PlayerSummary>>();
            api.RelativeUrl = "player/playerlist";
            var result = await api.GetAsync();
            return result;
        }

        public async Task<List<TermPlayerSummary>> GetTermPlayers()
        {
            BaseAPI<List<TermPlayerSummary>> api = new BaseAPI<List<TermPlayerSummary>>();
            api.RelativeUrl = "player/termplayerlist";
            var result = await api.GetAsync();
            return result;
        }
    }
}
