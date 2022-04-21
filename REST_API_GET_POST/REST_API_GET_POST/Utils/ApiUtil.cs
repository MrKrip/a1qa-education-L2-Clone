using RestSharp;
using RestSharp.Authenticators;

namespace REST_API_GET_POST.Utils
{
    public static class ApiUtil
    {
        private static RestClient Client;

        public static void SetClient(string Url)
        {
            Client = new RestClient(Url);
        }

        public static void SetHttpAuth(string UserName,string Password)
        {
            Client.Authenticator = new HttpBasicAuthenticator(UserName, Password);
        }

        public static (T,string) GetRequest<T>(string RequestUrl)
        {
            var request = new RestRequest(RequestUrl);
            var response = Client.Get(request);
            return (ParseJSON.ModelFromJson<T>(response.Content),response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl,object Json)
        {
            var request = new RestRequest(RequestUrl).AddJsonBody(Json);
            var response = Client.Post(request);
            return (ParseJSON.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }


    }
}
