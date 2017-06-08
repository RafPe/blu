using Blu.core.contracts;
using Blu.core.enums;
using RestSharp;

namespace Blu.api.chef
{
    public class ChefApi : IChefApi
    {
        private IChefConfig _chefConfig;
        private RestClient _restClient;

        public ChefApi()
        {
            
        }

        public ChefApi(IChefConfig chefConfig)
        {
            _chefConfig = chefConfig;
        }

        ///// <summary>
        ///// Sends a REST API request to Chef server
        ///// </summary>
        ///// <param name="xOpsProtocol">An instance of the X-Ops Protocol</param>
        ///// <returns>result of the API request as async string</returns>
        //public string SendRest(XOpsProtocol xOpsProtocol)
        //{
        //    using (var restClient = new HttpClient())
        //    {
        //        restClient.BaseAddress = _chefServer;
        //        var payload = xOpsProtocol.CreateMessage();
        //        var result = restClient.SendAsync(payload).Result;
        //        result.EnsureSuccessStatusCode();
        //        return result.Content.ReadAsStringAsync().Result;
        //    }
        //}

        public string Execute(IChefRequest req)
        {
            switch (req.ChefRequestMethod)
            {
                case ChefRequestMethod.get: break;
                case ChefRequestMethod.post: break;
                case ChefRequestMethod.put: break;
                case ChefRequestMethod.delete: break;
            }

            return null;
        }
    }
}
