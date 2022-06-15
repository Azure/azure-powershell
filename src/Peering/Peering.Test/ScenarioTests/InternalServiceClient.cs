using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Peering.Test.ScenarioTests
{
    public class InternalServiceClient 
    {
        private const string LocalEdgeRpUri = "https://secrets.wanrr-test.radar.core.azure-test.net";

        public InternalServiceClient()
        {
            this.SyncWithKusto();
        }

        public void RunDirectProvisioningManager(string location)
        {
            var url = $"runProvisioningManager?skuFamily=Direct&peeringLocation={location}";
            CreateAndSendRequest(url, "Post");
        }

        public void ApprovePeerAsn(string subscriptionId, string name)
        {
            RegisterSubscription(subscriptionId);
            var url = $"subscriptions?subscriptionId={subscriptionId}&peerAsnName={name}&api-version=2020-01-01-preview&validationState=Approved";
            var patch = CreateAndSendRequest(url, "PATCH");
        }

        public void ApproveConnection(string resourceId, string connectionId)
        {
            var resource = new ResourceIdentifier(resourceId);
            var url = $"updateConnectionState?subscriptionId={resource.Subscription}&resourceGroupName={resource.ResourceGroupName}&peeringName={resource.ResourceName}&connectionIdentifier={connectionId}&connectionState=Active";
            CreateAndSendRequest(url, "Patch");
        }
        public void FetchProvidersFromCosmos()
        {
            var url = "fetchPeeringServiceProviderCosmosDb";
            CreateAndSendRequest(url, "Post");
        }

        public void SyncWithKusto()
        {
            var url = "syncWithKusto";
            var patch = CreateAndSendRequest(url, "POST");
            patch = CreateAndSendRequest("fetchDataFromEdp?peeringLocation=Amsterdam", "POST");
            patch = CreateAndSendRequest("fetchDataFromEdp?peeringLocation=Seattle", "POST");
            patch = CreateAndSendRequest("fetchDataFromEdp?peeringLocation=Chicago", "POST");
        }

        private static void RegisterSubscription(string subscriptionId)
        {
            try
            {
                var cert = GetClientCertificate();
                var url = new Uri($"{LocalEdgeRpUri}/api/v1/subscriptions/{subscriptionId}?api-version=2.0");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;

                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(cert);

                var client = new HttpClient(handler);

                var request = new HttpRequestMessage(HttpMethod.Put, url.AbsoluteUri)
                {
                    Content = new StringContent(@"{
                                'state': 'Registered',
                                'registrationDate': '2020-03-23T23:57:05.644Z',
                                'properties': {
                                    'tenantId': 'string',
                                    'locationPlacementId': 'string',
                                    'quotaId': 'string',
                                    'registeredFeatures': [
                                        {
                                        'name': 'Microsoft.Peering/AllowExchangePeering',
                                        'state': 'Registered'
                                        },
                                        {
                                        'name': 'Microsoft.Peering/AllowDirectPeering',
                                        'state': 'Registered'
                                        },
                                        {
                                        'name': 'Microsoft.Peering/AllowPeeringService',
                                        'state': 'Registered'
                                        }
                                    ]
                                }
                            }",
                        Encoding.UTF8,
                        "application/json")
                };

                var response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public string CreateAndSendRequest(string urlString, string operation)
        {
            try
            {
                var cert = GetClientCertificate();
                var url = new Uri(LocalEdgeRpUri + "/api/v1/" + urlString);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = operation;
                request.ClientCertificates = new X509Certificate2Collection(cert);
                request.ServerCertificateValidationCallback = (a, b, c, d) => true;
                request.ContentLength = 0;

                var responseString = string.Empty;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                responseString = sr.ReadToEnd();
                                sr.Close();
                            }
                        }
                    }
                }
                return responseString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Run as administrator", ex.Message);
                    return null;
                }
            }
        }

        public static X509Certificate2 GetClientCertificate()
        {
            try
            {
                var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                foreach (var storeCertificate in store.Certificates)
                {
                    if (storeCertificate.Thumbprint != null)
                    {
                        if (storeCertificate.Thumbprint.Equals(
                            "ebd2bcdaedccaa360e7eb98ac128c7c1ceb34719",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            return storeCertificate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return null;
        }

        public string CreateAndSendRequestRoute(string urlString, string operation, string body = null)
        {
            try
            {
                var cert = GetClientCertificate();
                var url = new Uri("http://localhost:8769/" + urlString);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = operation;
                request.ClientCertificates = new X509Certificate2Collection(cert);
                request.ServerCertificateValidationCallback = (a, b, c, d) => true;
                request.ContentLength = 0;

                if (body != null)
                {
                    var data = Encoding.UTF8.GetBytes(body);
                    request.ContentType = "application/json";
                    request.ContentLength = data.Length;
                    request.GetRequestStream().Write(data, 0, data.Length);
                }

                var responseString = string.Empty;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                responseString = sr.ReadToEnd();
                                sr.Close();
                            }
                        }
                    }
                }

                return responseString;
            }
            catch
            {
                return null;
            }
        }

        public bool AddRoute(string prefix, string asn)
        {
            var body = @"[  {
                            'prefix': 'LITTLEPREFIX',
                            'nextHop': '206.126.237.239',
                            'asPath': 'MXEMX',
                            'localPref': '100',
                            'multiExitDisc': '40',
                            'communities': '8075:34 8075:1007 8075:2840 8075:4061 8075:24100 8075:34000 8075:38100 8075:8007',
                            'origin': 'MXEMX',
                            'routerIp': '10.3.151.25',
                            'routerName': 'wst-96cbe-1a',
                            'peerAddress': '206.126.237.239',
                            'peerAsNum': 'MXEMX',
                            'localAddress': '206.126.236.17',
                            'localAsNum': '8075',
                            'postPolicy': 'false',
                            'withdrawn': 'false',
                            'timestamp': 'timex'
                          },
                          {
                            'prefix': 'BIGPREFIX',
                            'nextHop': '206.126.237.239',
                            'asPath': 'MXEMX',
                            'localPref': '100',
                            'multiExitDisc': '40',
                            'communities': '8075:34 8075:1007 8075:2840 8075:4061 8075:24100 8075:34000 8075:38100 8075:8007',
                            'origin': 'MXEMX',
                            'routerIp': '10.3.151.25',
                            'routerName': 'wst-96cbe-1a',
                            'peerAddress': '206.126.237.239',
                            'peerAsNum': 'MXEMX',
                            'localAddress': '206.126.236.17',
                            'localAsNum': '8075',
                            'postPolicy': 'false',
                            'withdrawn': 'false',
                            'timestamp': 'timex'
                          }
                        ]";

            body = body.Replace("MXEMX", asn).Replace("BIGPREFIX", prefix).Replace("LITTLEPREFIX", this.SliceSubnet(prefix, 32)).Replace("timex", DateTime.UtcNow.ToString());
            var response = CreateAndSendRequestRoute("addroutes", "Post", body);
            if (response != null)
                return true;
            return false;
        }

        public string SliceSubnet(string prefix, int newSubnetMask)
        {
            var split = prefix.Split('/');
            if (split.Length == 2)
            {
                return $"{split[0]}/{newSubnetMask}";
            }
            throw new Exception($"Prefix:{prefix} invalid");
        }
    }
    public class CertificateCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// The Microsoft Azure Service Management API use mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </summary>
        private X509Certificate2 ManagementCertificate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateCredentials"/>
        /// class with the given 'Bearer' token.
        /// </summary>
        public CertificateCredentials(X509Certificate2 managementCertificate)
        {
            this.ManagementCertificate = managementCertificate ?? throw new ArgumentNullException(nameof(managementCertificate));
        }
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (!(client.HttpMessageHandlers.FirstOrDefault(h => h is HttpClientHandler) is HttpClientHandler handler))
            {
                throw new PlatformNotSupportedException();
            }

            handler.ClientCertificates.Add(this.ManagementCertificate);
        }
    }
}
