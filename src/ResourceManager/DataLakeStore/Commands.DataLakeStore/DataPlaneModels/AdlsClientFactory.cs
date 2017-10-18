using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.DataLake.Store;
using System.Text.RegularExpressions;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class AdlsClientFactory
    {
        private static readonly Dictionary<string, AdlsClient> ClientFactory=new Dictionary<string, AdlsClient>();
        /// <summary>
        /// Mock client credentials used for testing
        /// </summary>
        public static ServiceClientCredentials MockCredentials;
        private static string HandleAccntName(string accnt)
        {
            if (Regex.IsMatch(accnt, @"^[a-zA-Z0-9]+$"))
            {
                return accnt + ".azuredatalakestore.net";
            }
            return accnt;
        }
        internal static AdlsClient GetAdlsClient(string accntNm, IAzureContext context)
        {
            accntNm = HandleAccntName(accntNm);
            lock (ClientFactory)
            {
                if (ClientFactory.ContainsKey(accntNm))
                {
                    return ClientFactory[accntNm];
                }
                ServiceClientCredentials creds;
                if (MockCredentials != null)
                {
                    creds = MockCredentials;
                }
                else
                {
                    creds = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context,
                        AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix);
                }
                var client=AdlsClient.CreateClient(accntNm,creds);
                ClientFactory.Add(accntNm,client);
                return client;
            }
        }
    }
}
