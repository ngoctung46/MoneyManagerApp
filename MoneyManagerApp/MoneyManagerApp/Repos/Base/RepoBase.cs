using MoneyManagerApp.Interfaces;
using MoneyManagerApp.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerApp.Repos.Base
{
    public abstract class RepoBase<T> : IRepo<T> where T : ModelBase, new()
    {
        private readonly HttpClient httpClient;
        private readonly string baseAddress = @"https://buget-manager-api.herokuapp.com/api";
        private readonly string url;

        protected RepoBase()
        {
            url = $"{baseAddress}/{typeof(T).Name.Trim().ToLower()}";
            httpClient = CreateHttpClient();
        }

        public async Task<T> DeleteAsync(string id)
        {
            var url = $"{this.url}/{id}";
            var res = await httpClient.DeleteAsync(url);
            return JsonConvert.DeserializeObject<T>(HandleResponseMessage(res));
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            var res = await httpClient.GetAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(HandleResponseMessage(res));
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var url = $"{this.url}/{id}";
            var res = await httpClient.GetAsync(url);
            return JsonConvert.DeserializeObject<T>(HandleResponseMessage(res));
        }

        public async Task<T> PostAsync(T entity)
        {
            var posContent = CreateStringContent(entity);
            var res = await httpClient.PostAsync(url, posContent);
            return JsonConvert.DeserializeObject<T>(HandleResponseMessage(res));
        }

        public async Task<T> PutAsync(T entity)
        {
            var url = $"{this.url}/{entity.Id}";
            var putContent = CreateStringContent(entity);
            var res = await httpClient.PutAsync(url, putContent);
            return JsonConvert.DeserializeObject<T>(HandleResponseMessage(res));
        }

        internal HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        internal StringContent CreateStringContent(object obj)
        {
            var jObject = JsonConvert.SerializeObject(
                obj, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return new StringContent(jObject, Encoding.UTF8, "application/json");
        }

        internal string HandleResponseMessage(HttpResponseMessage res, bool isArray = false)
        {
            if (!res.IsSuccessStatusCode) return string.Empty;
            return res.Content.ReadAsStringAsync().Result;
        }
    }
}