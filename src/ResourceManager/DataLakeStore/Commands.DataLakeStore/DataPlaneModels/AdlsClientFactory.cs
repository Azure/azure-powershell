using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.DataLake.Store;
using System.Text.RegularExpressions;
using Microsoft.Azure.DataLake.Store.MockAdlsFileSystem;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class AdlsClientFactory
    {
        private static readonly Dictionary<string, AdlsClient> ClientFactory=new Dictionary<string, AdlsClient>();
        /// <summary>
        /// For unit testing this is set as true
        /// </summary>
        public static bool IsTest = false;
        /// <summary>
        /// Mock client credentials used for testing, this is set for record
        /// </summary>
        public static ServiceClientCredentials MockCredentials = null;
        private static string HandleAccntName(string accnt,IAzureContext context)
        {
            if (Regex.IsMatch(accnt, @"^[a-zA-Z0-9]+$"))
            {
                return $"{accnt}.{context.Environment.GetEndpoint(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix)}";
            }
            return accnt;
        }
        internal static AdlsClient GetAdlsClient(string accntNm, IAzureContext context)
        {
            accntNm = HandleAccntName(accntNm,context);
            lock (ClientFactory)
            {
                if (ClientFactory.ContainsKey(accntNm))
                {
                    return ClientFactory[accntNm];
                }
                ServiceClientCredentials creds;
                if (IsTest)
                {
                    if (MockCredentials != null)
                    {
                        creds = MockCredentials;
                    }
                    else
                    {
                        ClientFactory.Add(accntNm, MockAdlsClient.GetMockClient());
                        return ClientFactory[accntNm];
                    }
                }
                else
                {
                    creds = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context,
                        AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix);
                }
                var client=AdlsClient.CreateClient(accntNm,creds);
                client.AddUserAgentSuffix(AzurePowerShell.UserAgentValue.ToString());
                ClientFactory.Add(accntNm,client);
                return client;
            }
        }
    }
}
