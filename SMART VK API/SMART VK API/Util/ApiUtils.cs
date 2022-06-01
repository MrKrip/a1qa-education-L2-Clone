using Aquality.Selenium.Browsers;
using RestSharp;
using RestSharp.Authenticators;
using SMART_VK_API.Models;

namespace SMART_VK_API.Util
{
    public static class ApiUtils
    {
        private static RestClient Client;

        public static void SetClient(string Url)
        {
            AqualityServices.Logger.Info("Setting client");
            Client = new RestClient(Url);
        }

        public static void SetHttpAuth(UserModel user)
        {
            AqualityServices.Logger.Info("Setting Http Basic Authenticator");
            Client.Authenticator = new HttpBasicAuthenticator(user.Login, user.Password);
        }

        public static (T, string) GetRequest<T>(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' GET request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Get(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' GET respond");
            return (ParseJSON.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl, object Json)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl).AddJsonBody(Json);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (ParseJSON.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (ParseJSON.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }
    }
}
