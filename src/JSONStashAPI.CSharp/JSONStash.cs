using JSONStashAPI.CSharp.Interfaces;
using JSONStashAPI.CSharp.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace JSONStashAPI.CSharp
{
    public class JSONStash : IJSONStash
    {
        private readonly Uri _host;
        private readonly int? _port;

        /// <summary>
        /// Takes what the JSONStash api returns in JSON, and converts it to C# objects for easy interaction with in C# projects.
        /// </summary>
        /// <param name="host"></param>
        /// /// <param name="port"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UriFormatException"></exception>
        public JSONStash(string host, int? port = null)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException($"Value cannot be null. Parameter name: \"host\"");

            Regex regex = new(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            bool isValidUrl = regex.IsMatch(host);


            bool isValidUri = (Uri.TryCreate(host, UriKind.Absolute, out _host) 
                                || Uri.TryCreate("http://" + host, UriKind.RelativeOrAbsolute, out _host)) 
                                && (_host.Scheme == Uri.UriSchemeHttp || _host.Scheme == Uri.UriSchemeHttps);

            if (port != null && isValidUri)
            {
                UriBuilder builder = new(_host) {  Port = port.Value};
                _host = builder.Uri;
            }

            if (!isValidUri || !isValidUrl)
                throw new UriFormatException("The provided host is not properly formatted.");
        }

        public async Task<StashResponse> GetStashDataAsync(string key, string stashId)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(stashId))
                throw new ArgumentNullException($"Value cannot be null. Parameter names: [\"key\", \"stashId\"]");

            using HttpClient client = new();

            client.BaseAddress = _host;
            client.DefaultRequestHeaders.Add("x-api-key", key);

            HttpResponseMessage response = await client.GetAsync($"s/{stashId}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StashResponse>(json);
            }

            return null;
        }

        public async Task<StashResponse> UpdateStashDataAsync(string key, string stashId, string data)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(stashId) && string.IsNullOrEmpty(data))
                throw new ArgumentNullException($"Value cannot be null. Parameter names: [\"key\", \"stashId\", \"data\"]");

            using HttpClient client = new();

            StringContent content = new(data, Encoding.UTF8, "application/json");

            client.BaseAddress = _host;
            client.DefaultRequestHeaders.Add("x-api-key", key);

            HttpResponseMessage response = await client.PutAsync($"s/{stashId}", content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<StashResponse>(json);
            }

            return null;
        }
    }
}
