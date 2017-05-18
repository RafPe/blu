﻿using System;
using System.Net.Http;
using Blu.core.contracts;
using Blu.core.enums;

namespace Blu.api.chef
{
    public class ChefApi : IChefApi
    {
        private readonly Uri _chefServer;

        public ChefApi(Uri chefServer)
        {
            _chefServer = chefServer;
        }

        /// <summary>
        /// Sends a REST API request to Chef server
        /// </summary>
        /// <param name="xOpsProtocol">An instance of the X-Ops Protocol</param>
        /// <returns>result of the API request as async string</returns>
        public string SendRest(XOpsProtocol xOpsProtocol)
        {
            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = _chefServer;
                var payload = xOpsProtocol.CreateMessage();
                var result = restClient.SendAsync(payload).Result;
                result.EnsureSuccessStatusCode();
                return result.Content.ReadAsStringAsync().Result;
            }
        }


        public string Execute(ChefRequestMethod method, string client, string resource, string body)
        {


            switch (method)
            {
                case ChefRequestMethod.get: break;
                case ChefRequestMethod.post: break;
                case ChefRequestMethod.put: break;
                case ChefRequestMethod.delete: break;
            }

            return null;


            //throw new NotImplementedException();
        }
    }
}
