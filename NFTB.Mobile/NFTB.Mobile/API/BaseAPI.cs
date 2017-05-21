using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NFTB.Mobile.API
{
    public class BaseAPI<T>
    {
        private const string _baseAPIUrl = "http://192.168.1.150/api/person/";
        private MediaTypeHeaderValue _applicationJson = new MediaTypeHeaderValue("application/json");

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(_baseAPIUrl);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = _applicationJson;
            var result = await httpClient.PostAsync(_baseAPIUrl, httpContent);
            return result.IsSuccessStatusCode;
        }
    }
}
