using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NCBlog.Helpers
{
    public static class NCBlogHttpClient
    {
        private const string ContentType = "application/json";
        private static readonly List<HttpClient> Clients = new List<HttpClient>();

        private static HttpClient GetClient(string baseAddress, string token = null)
        {

            var client = Clients.FirstOrDefault(c => c.BaseAddress.AbsoluteUri == baseAddress);
            if (client == null)
            {
                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,

                    UseDefaultCredentials = true
                };
                client = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) };
            }
            return client;
        }


        public static async Task<T> GetAsync<T>(string baseAddress, string prmsUrl, HttpRequest request, bool autoDispose = false)
        {
            return await GetAsync<T>(baseAddress, prmsUrl, GetToken(request), autoDispose);
        }

        public static async Task<T> GetAsync<T>(string baseAddress, string prmsUrl, string token, bool autoDispose = false, bool cache = false)
        {
            T output;
            var key = string.Empty;


            var client = GetClient(baseAddress, token);

            var response = await client.GetAsync(prmsUrl);
            output = response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<T>() : default(T);
            if (autoDispose)
            {
                Clients.Remove(client);
                client.Dispose();
            }

            return output;
        }

        public static async Task<HttpResponseMessage> GetAsync(string baseAddress, string prmsUrl, HttpRequest request, bool autoDispose = false)
        {
            var client = GetClient(baseAddress, GetToken(request));
            var response = await client.GetAsync(prmsUrl);
            if (autoDispose)
            {
                Clients.Remove(client);
                client.Dispose();
            }
            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync(string baseAddress, string extraUrl, object obj, HttpRequest request, bool autoDispose = false)
        {
            var client = GetClient(baseAddress, GetToken(request));
            var response = await client.PostAsync(extraUrl, new StringContent(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, ContentType));
            //WriteToLog(await GetResponseText(response, $"{baseAddress}{extraUrl}", "HTTP POST"));
            if (autoDispose)
            {
                Clients.Remove(client);
                client.Dispose();
            }
            return response;
        }


        public static async Task<HttpResponseMessage> PostAsync(string baseAddress, string extraUrl, IDictionary<string, string> obj, HttpRequest request, bool autoDispose = false)
        {
            var client = GetClient(baseAddress, GetToken(request));
            var response = await client.PostAsync(extraUrl, new FormUrlEncodedContent(obj));
            //WriteToLog(await GetResponseText(response, $"{baseAddress}{extraUrl}", "HTTP POST"));
            if (autoDispose)
            {
                Clients.Remove(client);
                client.Dispose();
            }
            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync(string baseAddress, string extraUrl, MultipartFormDataContent obj, HttpRequest request, bool autoDispose = false)
        {
            var client = GetClient(baseAddress, GetToken(request));
            var res = await client.PostAsync(extraUrl, obj);
            //WriteToLog(await GetResponseText(res, $"{baseAddress}{extraUrl}", "HTTP POST"));
            if (autoDispose)
            {
                Clients.Remove(client);
                client.Dispose();
            }
            return res;
        }



        private static string GetToken(HttpRequest request)
        {
            string token = "NCUser";
            return token;
        }

    }
}
