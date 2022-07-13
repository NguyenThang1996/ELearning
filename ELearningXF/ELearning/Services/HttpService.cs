using ELearning.Extensions;
using ELearning.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    #region Khai báo interface các service sử dụng
    public interface IHttpService
    {
        // IService GetAsync
        ValueTask<TResponse> GetAsync<TResponse, TRequest>(string url, TRequest request);
        // IService PostAsync
        ValueTask<TResponse> PostAsync<TResponse, TBody>(string url, TBody content);
        // IService PutAsync
        ValueTask<TResponse> PutAsync<TResponse, TBody>(string url, TBody content);
        // IService DeleteAsync
        ValueTask<TResponse> DeleteAsync<TResponse, TRequest>(string url, TRequest request);
    }
    #endregion
    #region Define các service sử dụng, implement interface
    public class HttpService : IHttpService
    {
        #region Khai báo HttpClient và constructor
        private readonly HttpClient httpClient;

        public HttpService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.1.11.102:6001/") 
            };
        }
        #endregion
        #region Define các service sử dụng
        // Service GetAsync
        public async ValueTask<TResponse> GetAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                var query = request?.ToQueryString();
                if (!string.IsNullOrWhiteSpace(query))
                {
                    url += $"?{query}";
                }
                var httpResponseMessage = await httpClient.GetAsync(url);
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        // Service PostAsync
        public async ValueTask<TResponse> PostAsync<TResponse, TBody>(string url, TBody content)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                var httpResponseMessage = await httpClient.PostAsync(url, stringContent);
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        // Service PutAsync
        public async ValueTask<TResponse> PutAsync<TResponse, TBody>(string url, TBody content)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                var httpResponseMessage = await httpClient.PutAsync(url, stringContent);
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        // Service DeleteAsync
        public async ValueTask<TResponse> DeleteAsync<TResponse, TRequest>(string url, TRequest request)
        {
            try
            {
                var query = request?.ToQueryString();
                if (!string.IsNullOrWhiteSpace(query))
                {
                    url += $"?{query}";
                }
                var httpResponseMessage = await httpClient.DeleteAsync(url);
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        #endregion
    }
    #endregion
}
