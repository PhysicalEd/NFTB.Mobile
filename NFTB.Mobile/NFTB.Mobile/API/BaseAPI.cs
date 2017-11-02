using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NFTB.Mobile.Data.Entities;

namespace NFTB.Mobile.API
{
    public class BaseAPI<T>
    {
        private string _BaseAPIUrl = "http://192.168.1.10/api/";

        private string FullUrl
        {
            get { return GetBaseAPIUrl + RelativeUrl + ParameterString; }
        }

        public string RelativeUrl { get; set; } = "";

        public Dictionary<string,string> ParameterDictionary { get; set; } = new Dictionary<string, string>();

        private string ParameterString
        {
            get
            {
                var str = "?";
                foreach (var param in this.ParameterDictionary)
                {
                    str += param.Key + "=" + param.Value + "&";
                }

                return this.ParameterDictionary.Count > 0 ? str: "";
            }
        }


        private MediaTypeHeaderValue _ApplicationJson = new MediaTypeHeaderValue("application/json");
        public string GetBaseAPIUrl { get { return _BaseAPIUrl; } }

        public async Task<T> GetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(FullUrl);
            var taskModels = JsonConvert.DeserializeObject<T>(json);
            return taskModels;
        }


        public async Task<T> PostAsync(Object t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(FullUrl, httpContent);
            // Read result content as string
            var resultString =  result.Content.ReadAsStringAsync();
            // Deserialize the string into the object it's sending back
            var jsonResult = JsonConvert.DeserializeObject<T>(resultString.Result);
            return jsonResult;
        }
    }
}
