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
    /// <summary>
    ///     IHttpService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IHttpService
    {
        /// <summary>IService GetAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<TResponse> GetAsync<TResponse, TRequest>(string url, TRequest request);

        /// <summary>IService PostAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TBody">The type of the body.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<TResponse> PostAsync<TResponse, TBody>(string url, TBody content);

        /// <summary>IService PostAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TBody">The type of the body.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<TResponse> PutAsync<TResponse, TBody>(string url, TBody content);

        /// <summary>IService DeleteAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<TResponse> DeleteAsync<TResponse, TRequest>(string url, TRequest request);
    }
    #endregion

    #region Define các service sử dụng, implement interface
    /// <summary>
    ///     HttpService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class HttpService : IHttpService
    {
        #region Khai báo HttpClient và constructor
        private readonly HttpClient httpClient;

        /// <summary>Khởi tạo constructor của HttpService</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public HttpService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.1.11.102:6001/") 
            };
        }
        #endregion

        #region Define các service sử dụng
        /// <summary>Service GetAsync.</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service PostAsync.</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TBody">The type of the body.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service PutAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TBody">The type of the body.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service DeleteAsync</summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
