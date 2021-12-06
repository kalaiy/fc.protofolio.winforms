using Fc.Protofolio.Winforms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Fc.Protofolio.Winforms.Services
{

    public class ProtofolioAPIClient : IProtofolioAPIClient
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProtofolioAPIClient));
        private HttpClient _httpClient;

        public ProtofolioAPIClient()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                return true;
            };
            _httpClient = new HttpClient(httpClientHandler);
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseUrl"]);
            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(  "ProtofolioAPIClient");

        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings =>
            new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };



        public async Task<T> GetAsync<T>(string url) where T : class
        {
            logger.Info("Trace:In url" + url);
            var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();
                //logger.LogDebug("Trace:In response" + response);
                if (typeof(T) == typeof(string))
                    return data as T;
                return JsonConvert.DeserializeObject<T>(data);
            }
            throw new HttpRequestException($"Error: {response.StatusCode} " + url);
        }

        public async Task<T> GetAsyncWithCancellation<T>(string url,CancellationToken token) where T : class
        {
            logger.Info("Trace:In url" + url);
            var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();
                //logger.LogDebug("Trace:In response" + response);
                if (typeof(T) == typeof(string))
                    return data as T;
                return JsonConvert.DeserializeObject<T>(data);
            }
            throw new HttpRequestException($"Error: {response.StatusCode} " + url);
        }




        /// <summary>
        ///     Common method for making POST calls
        /// </summary>
        public async Task<T> PostAsync<T>(string url, T content)
        {
            var json = "";
            var stringContent = CreateHttpContent(content, ref json);

            var response = await _httpClient.PostAsync(url, stringContent);
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpRequestException(response.ToString());
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }


        public async Task<T1> PostAsync<T1, T2>(string url, T2 content)
        {
            var json = "";
            var stringContent = CreateHttpContent(content, ref json);
            logger.Info($"Trace Post URL: {url} {JsonConvert.SerializeObject(content)}");

          
            var response = await _httpClient.PostAsync(url, stringContent);

            if (response.StatusCode != HttpStatusCode.OK) throw new HttpRequestException(response.ToString());
            var data = await response.Content.ReadAsStringAsync();
            logger.Debug($"Trace Post Response {data}");
            return JsonConvert.DeserializeObject<T1>(data);
        }




        private HttpContent CreateHttpContent<T>(T content, ref string json)
        {
          
            json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
