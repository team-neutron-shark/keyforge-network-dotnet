using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Text;

namespace KeyforgeNetwork
{
    public class VaultCredentials
    {
        [JsonProperty(PropertyName = "id_token")]
        public string IDToken { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "nonce")]
        public string Nonce { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
    }

    public class VaultUserResultJSON 
    {
        [JsonProperty(PropertyName = "data")]
        public VaultUserResult Result { get; set; }
    }

    public class VaultUserResult
    {
        [JsonProperty(PropertyName = "user")]
        public VaultUser User { get; set; }
    }

    public class VaultUser
    {
        private string id;
        private string userName;
        private string email;
        private string avatar;
        private string location;
        private string qrCode;
        private string accountUrl;
        private string language;
        private int amberShards;
        private int amberShardsCollected;
        private int keys;
        private string token;

        [JsonProperty(PropertyName = "id")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "username")]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        [JsonProperty(PropertyName = "location")]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [JsonProperty(PropertyName = "qr_code")]
        public string QRCode
        {
            get { return qrCode; }
            set { qrCode = value; }
        }

        [JsonProperty(PropertyName = "account_url")]
        public string AccountURL
        {
            get { return accountUrl; }
            set { accountUrl = value; }
        }

        [JsonProperty(PropertyName = "language")]
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        [JsonProperty(PropertyName = "amber_shards")]
        public int AmberShards
        {
            get { return amberShards; }
            set { amberShards = value; }
        }

        [JsonProperty(PropertyName = "amber_shards_collected")]
        public int AmberShardsCollected
        {
            get { return amberShardsCollected; }
            set { amberShardsCollected = value; }
        }

        [JsonProperty(PropertyName = "keys")]
        public int Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        [JsonProperty(PropertyName = "token")]
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }

    public class Vault
    {
        private static HttpClient client; 
        private HttpClientHandler clientHandler; 

        public Vault() 
        {
            clientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };

            client = new HttpClient(clientHandler);
        }

        public async Task Login(string username, string password) 
        {
            Dictionary<string, string> loginParameters;
            Dictionary<string, string> urlParameters = new Dictionary<string, string>
            {
                { "display", "popup" },
                { "scope", "openid profile email" },
                { "response_type", "id_token token" },
                { "client_id", "keyforge-web-portal" },
                { "state", "/" },
                { "redirect_uri", "https://www.keyforgegame.com/authorize" },
                { "nonce", "4HM~Z5f8" }
            };

            FormUrlEncodedContent encodedUrlParameters = new FormUrlEncodedContent(urlParameters);

            loginParameters = new Dictionary<string, string>(urlParameters)
            {
                { "login", username },
                { "password", password }
            };

            FormUrlEncodedContent encodedLoginParameters = new FormUrlEncodedContent(loginParameters);

            string parameterString = await encodedUrlParameters.ReadAsStringAsync();
            string urlPath = string.Format("https://account.asmodee.net/en/signin?{0}", parameterString);

            HttpResponseMessage response = client.PostAsync(urlPath, encodedLoginParameters).Result;

            string query = response.Headers.Location.ToString().Split('#')[1];
            NameValueCollection collection = System.Web.HttpUtility.ParseQueryString(query);

            VaultCredentials credentials = new VaultCredentials
            {
                IDToken = collection["id_token"],
                AccessToken = collection["access_token"],
                Nonce = "4HM~Z5f8"
            };

            string jsonString = JsonConvert.SerializeObject(credentials, Formatting.None);
            StringContent jsonSubmit = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = client.PostAsync("https://www.keyforgegame.com/api/users/login/asmodee/", jsonSubmit).Result;
            string body = response.Content.ReadAsStringAsync().Result;

            VaultUserResultJSON returnJSON = JsonConvert.DeserializeObject<VaultUserResultJSON>(body);

            Console.WriteLine(JsonConvert.SerializeObject(returnJSON));
        }
    }
}
