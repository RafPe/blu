using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Blu.core.common;
using Blu.core.enums;
using Blu.core.contracts;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.OpenSsl;


namespace Blu.api.chef
{
    public class ChefRequest: IChefRequest
    {

        private readonly string _timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        private readonly IChefConfig _chefConfig;
        public ChefRequestMethod ChefRequestMethod { get; set; }

        public ChefRequest(IChefConfig chefConfig, ChefRequestMethod chefRequestMethod)
        {
            _chefConfig = chefConfig;
            ChefRequestMethod = chefRequestMethod;
        }


        public Dictionary<string, string> CreateXopsMessage(string body, string resourceUri)
        {

            string contentHashBody = body.ToBase64EncodedSha1String();

            Dictionary<string, string> xopsHeaders = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"X-Ops-Sign", "algorithm=sha1;version=1.0"},
                {"X-Ops-UserId", _chefConfig.ClientName},
                {"X-Ops-Timestamp", _timestamp},
                {"X-Ops-Content-Hash",contentHashBody },
                {"Host", $"{_chefConfig.OrganizationUri.Host}:{_chefConfig.OrganizationUri.Port}"},
                {"X-Chef-Version", "11.4.0"}
            };


            //if (_chefRequestMethod != ChefRequestMethod.GET && _chefRequestMethod != ChefRequestMethod.DELETE)
            //{
            //    httpRequestMessage.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(_body));
            //    httpRequestMessage.Content.Headers.Add("Content-Type", "application/json");
            //}

            var i = 1;
            //TODO: FIND OUT WHAT IS THAT CLIENT PRIVATE KEY!
            foreach (var line in SignMessage(ChefRequestMethod, _chefConfig, "", contentHashBody).Split(60))
            {
                xopsHeaders.Add($"X-Ops-Authorization-{i++}", line);
            }

            return xopsHeaders;
        }

        

        public string SignMessage(ChefRequestMethod chefRequestMethod, IChefConfig chefConfig, string privateKey, string bodyContentHash)
        {
            string canonicalHeader = $"Method:{chefRequestMethod}\nHashed Path:{chefConfig.OrganizationUri.AbsolutePath.ToBase64EncodedSha1String()}\nX-Ops-Content-Hash:{bodyContentHash}\nX-Ops-Timestamp:{_timestamp}\nX-Ops-UserId:{chefConfig.ClientName}";

            byte[] input = Encoding.UTF8.GetBytes(canonicalHeader);

            TextReader pemStream;

            //TODO: This needs to be checked if we can use ICHef config property or this private key is something else :O 
            //if (privateKey.Contains("UNSET") && ChefConfig.ValidationKey != "UNSET")
            //{
            //    ChefConfig.ValidationKey = ChefConfig.ValidationKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "-----BEGIN RSA PRIVATE KEY-----\n");
            //    ChefConfig.ValidationKey = ChefConfig.ValidationKey.Replace("-----END RSA PRIVATE KEY-----", "\n-----END RSA PRIVATE KEY-----");
            //    pemStream = new StringReader(ChefConfig.ValidationKey);
            //}
            //else
            //{
            //    pemStream = File.OpenText(privateKey);
            //}

            pemStream = File.OpenText(privateKey);

            var pemReader = new PemReader(pemStream);

            AsymmetricKeyParameter key = ((AsymmetricCipherKeyPair)pemReader.ReadObject()).Private;

            ISigner signer = new RsaDigestSigner(new NullDigest());
            signer.Init(true, key);
            signer.BlockUpdate(input, 0, input.Length);

            return Convert.ToBase64String(signer.GenerateSignature());

        }

        //public string Get(string restClient, string restNode)
        //{
        //    try
        //    {
        //        return RequestData("GET", restClient, restNode, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Unable to GET data, Error: " + ex.Message;
        //    }
        //}

        //public string Post(string restClient, string restNode, string body)
        //{
        //    try
        //    {
        //        return RequestData("POST", restClient, restNode, body);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Unable to POST data, Error: " + ex.Message;
        //    }
        //}

        //public string Put(string restClient, string restNode, string body)
        //{
        //    try
        //    {
        //        return RequestData("PUT", restClient, restNode, body);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Unable to PUT data, Error: " + ex.Message;
        //    }
        //}

        //public string Delete(string restClient, string restNode)
        //{
        //    try
        //    {
        //        return RequestData("DELETE", restClient, restNode, String.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Unable to DELETE " + restNode + " Error: " + ex.Message;
        //    }
        //}

        //private static string RequestData_old(string method, string client, string resource, string body)
        //{
        //    Uri organizationUri = ChefConfig.OrganizationUri;
        //    string pemPath = ChefConfig.ClientPem;
        //    var chefApi = new ChefApi(organizationUri);

        //    switch (method)
        //    {
        //        // Method GET
        //        case "GET":
        //            var getUri = new Uri(organizationUri + "/" + resource);
        //            var xOpsGet = new XOpsProtocol(client, getUri);

        //            Logger.log("api", "Method : GET");
        //            Logger.log("api", "Client : " + client);
        //            Logger.log("api", "organizationUri : " + organizationUri);
        //            Logger.log("api", "resource : " + resource);
        //            Logger.log("api", "getUri : " + getUri);
        //            Logger.log("api", "XOpsProtocol(" + client + ", " + getUri + ");");

        //            try
        //            {
        //                xOpsGet.SignMessage(pemPath);
        //                return chefApi.SendRest(xOpsGet);
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.log("api", "API request GET Error " + getUri + ": " + ex.Message);
        //                return "API request GET Error " + getUri + ": " + ex.Message;
        //            }

        //        // Method POST
        //        case "POST":
        //            HttpMethod postMethod = new HttpMethod("POST");
        //            var postUri = new Uri(organizationUri + "/" + resource);
        //            var xOpsPost = new XOpsProtocol(client, postUri, postMethod, body);

        //            Logger.log("api", "Method : " + postMethod);
        //            Logger.log("api", "Client : " + client);
        //            Logger.log("api", "organizationUri : " + organizationUri);
        //            Logger.log("api", "resource : " + resource);
        //            Logger.log("api", "postUri : " + postUri);
        //            Logger.log("api", "XOpsProtocol(" + client + ", " + postUri + ", " + postMethod + ", <body>)");

        //            try
        //            {
        //                xOpsPost.SignMessage(pemPath);
        //                return chefApi.SendRest(xOpsPost);
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.log("api", "API request POST Error " + postUri + ": " + ex.Message);
        //                return "API request POST Error " + postUri + ": " + ex.Message;
        //            }

        //        // Method PUT
        //        case "PUT":
        //            HttpMethod putMethod = new HttpMethod("PUT");
        //            var putUri = new Uri(organizationUri + "/" + resource);
        //            var xOpsPut = new XOpsProtocol(client, putUri, putMethod, body);

        //            Logger.log("api", "Method : " + putMethod);
        //            Logger.log("api", "Client : " + client);
        //            Logger.log("api", "organizationUri : " + organizationUri);
        //            Logger.log("api", "resource : " + resource);
        //            Logger.log("api", "putUri : " + putUri);
        //            Logger.log("api", "XOpsProtocol(" + client + ", " + putUri + ", " + putMethod + ", <body>)");

        //            try
        //            {
        //                xOpsPut.SignMessage(pemPath);
        //                return chefApi.SendRest(xOpsPut); 
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.log("api", "API request PUT Error " + putUri + ": " + ex.Message);
        //                return "API request PUT Error " + putUri + ": " + ex.Message;
        //            }

        //        // Method DELETE
        //        case "DELETE":
        //            HttpMethod deleteMethod = new HttpMethod("DELETE");
        //            var deleteUri = new Uri(organizationUri + "/" + resource);
        //            var xOpsDelete = new XOpsProtocol(client, deleteUri, deleteMethod, String.Empty);

        //            Logger.log("api", "Method : DELETE");
        //            Logger.log("api", "Client : " + client);
        //            Logger.log("api", "organizationUri : " + organizationUri);
        //            Logger.log("api", "resource : " + resource);
        //            Logger.log("api", "deleteUri : " + deleteUri);
        //            Logger.log("api", "XOpsProtocol(" + client + ", " + deleteUri + ");");

        //            try
        //            {
        //                xOpsDelete.SignMessage(pemPath);
        //                return chefApi.SendRest(xOpsDelete);
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.log("api", "API request DELETE Error " + deleteUri + ": " + ex.Message);
        //                return "API request DELETE Error " + deleteUri + ": " + ex.Message;
        //            }

        //        default:
        //            Logger.log("api", "Method " + method + " is not recognized.");
        //            return "Method " + method + " is not supported.";
        //    }
        //}


    }
}
