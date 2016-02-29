// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Net.Security;
using System.Runtime.Caching;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Management.Scheduler.Models;


namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        private CloudServiceManagementClient cloudServicesClient;

        public string ClientRequestId;
        
        private ObjectCache Resourcecache = MemoryCache.Default;

        private CacheItemPolicy ResourceCachetimeoutPolicy = new CacheItemPolicy();

        /// <summary>
        /// Azure profile
        /// </summary>
        public AzureSMProfile Profile { get; set; }

        public StorSimpleClient(AzureSMProfile AzureSMProfile, AzureSubscription currentSubscription)  
        {
            // Temp code to be able to test internal env.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };//IgnoreCertificateErrorHandler;//delegate { return true; };
            
            this.Profile = AzureSMProfile;

            this.cloudServicesClient = AzureSession.ClientFactory.CreateClient<CloudServiceManagementClient>(AzureSMProfile, currentSubscription, AzureEnvironment.Endpoint.ServiceManagement);
            
            ResourceCachetimeoutPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1.0d);
        }

        public CloudServiceListResponse GetAzureCloudServicesSyncInt()
        {
            return this.cloudServicesClient.CloudServices.List();
        }

        private StorSimpleManagementClient GetStorSimpleClient()
        {
            var storSimpleClient =
                AzureSession.ClientFactory.CreateCustomClient<StorSimpleManagementClient>(
                    StorSimpleContext.CloudServiceName,
                    StorSimpleContext.ResourceName, StorSimpleContext.ResourceId,
                    StorSimpleContext.ResourceProviderNameSpace, this.cloudServicesClient.Credentials,
                    Profile.Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement));
            
            if (storSimpleClient == null)
            {
                throw new InvalidOperationException();
            }

            return storSimpleClient;

        }

        public void ThrowCloudExceptionDetails(CloudException cloudException)
        {
            Error error = null;
            try
            {
                using (Stream stream = new MemoryStream())
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(cloudException.Error.Message);
                    stream.Write(data, 0, data.Length);
                    stream.Position = 0;

                    var deserializer = new DataContractSerializer(typeof(Error));
                    error = (Error)deserializer.ReadObject(stream);
                }
            }
            catch (XmlException)
            {
                throw new XmlException(cloudException.Error.Message);
            }
            catch (SerializationException)
            {
                throw new SerializationException(cloudException.Error.Message);
            }

            throw new InvalidOperationException(
                string.Format(error.Message,"\n",error.HttpCode,"\n",error.ExtendedCode));
        }
        
        private CustomRequestHeaders GetCustomRequestHeaders()
        {
            var hdrs = new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request to StorSimple .
                // It is useful when diagnosing failures in API calls.
                ClientRequestId = this.ClientRequestId,
                Language = "en-US"
            };

            return hdrs;
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        
    }
}
