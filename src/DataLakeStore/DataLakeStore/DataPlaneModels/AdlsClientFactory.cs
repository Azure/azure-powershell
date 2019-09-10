using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.DataLake.Store;
using System.Text.RegularExpressions;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using System.Net.Http;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class AdlsClientFactory
    {
        private static readonly Dictionary<string, AdlsClient> ClientFactory=new Dictionary<string, AdlsClient>();
        /// <summary>
        /// For unit testing this is set as true
        /// </summary>
        internal static bool IsTest = false;
        public static DelegatingHandler[] CustomDelegatingHAndler;
        /// <summary>
        /// Mock client credentials used for testing, this is set for record
        /// </summary>
        internal static ServiceClientCredentials MockCredentials = null;
        private static string HandleAccntName(string accnt,IAzureContext context)
        {
            if (Regex.IsMatch(accnt, @"^[a-zA-Z0-9]+$"))
            {
                string domain = context.Environment.GetEndpoint(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix);
                if (domain.EndsWith("/"))
                {
                    domain = domain.Substring(0, domain.Length - 1);
                }

                return $"{accnt}.{domain}";
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
                AdlsClient client = null;
                if (IsTest)
                {
                    client = AdlsClient.CreateClient(accntNm, MockCredentials, DataLakeStoreFileSystemClient.ImportExportMaxThreads, CustomDelegatingHAndler);
                }
                else
                {
                    client = AdlsClient.CreateClient(accntNm, AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context,
                        AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix), DataLakeStoreFileSystemClient.ImportExportMaxThreads);
                }
                client.AddUserAgentSuffix(AzurePowerShell.UserAgentValue.ToString());
                ClientFactory.Add(accntNm,client);
                return client;
            }
        }
    }
}
