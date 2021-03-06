﻿using System;
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

        public async Task<List<PlayerSummary>> GetPlayers(int? termID)
        {
            BaseAPI<List<PlayerSummary>> api = new BaseAPI<List<PlayerSummary>>();
            api.RelativeUrl = "player/playerlist";
            // EO todo
            if (!termID.HasValue) termID = 1;
            api.ParameterDictionary.Add("TermID", termID.ToString());
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

        public async Task<PlayerSummary> SavePlayer(PlayerSummary player)
        {
            BaseAPI<PlayerSummary> api = new BaseAPI<PlayerSummary>();
            api.RelativeUrl = "player/saveplayer";
            api.ParameterDictionary.Add("PlayerID", player.PlayerID.ToString());
            api.ParameterDictionary.Add("FirstName", player.FirstName);
            api.ParameterDictionary.Add("LastName", player.LastName);
            api.ParameterDictionary.Add("Email", player.Email);
            api.ParameterDictionary.Add("Phone", player.Phone);
            api.ParameterDictionary.Add("IsDeleted", false.ToString());
            var result = await api.GetAsync();
            return result;
        }

        public async Task<List<Person>> GetPeople()
        {
            BaseAPI<List<Person>> api = new BaseAPI<List<Person>>();
            api.RelativeUrl = "person/peoplelist";
            //api.ParameterDictionary.Add("PlayerID", player.PlayerID.ToString());
            //api.ParameterDictionary.Add("FirstName", player.FirstName);
            //api.ParameterDictionary.Add("LastName", player.LastName);
            //api.ParameterDictionary.Add("Email", player.Email);
            //api.ParameterDictionary.Add("Phone", player.Phone);
            //api.ParameterDictionary.Add("IsDeleted", false.ToString());
            var result = await api.GetAsync();
            return result;
        }
    }
}
