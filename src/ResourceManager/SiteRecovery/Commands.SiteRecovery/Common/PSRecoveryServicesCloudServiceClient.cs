//// ----------------------------------------------------------------------------------
////
//// Copyright Microsoft Corporation
//// Licensed under the Apache License, Version 2.0 (the "License");
//// you may not use this file except in compliance with the License.
//// You may obtain a copy of the License at
//// http://www.apache.org/licenses/LICENSE-2.0
//// Unless required by applicable law or agreed to in writing, software
//// distributed under the License is distributed on an "AS IS" BASIS,
//// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//// See the License for the specific language governing permissions and
//// limitations under the License.
//// ----------------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//// using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
//using Microsoft.WindowsAzure.Management.RecoveryServices;
//using Microsoft.WindowsAzure.Management.RecoveryServices.Models;
//using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

//namespace Microsoft.Azure.Commands.RecoveryServices
//{
//    /// <summary>
//    /// Recovery services convenience client.
//    /// </summary>
//    public partial class PSRecoveryServicesClient
//    {
//        /// <summary>
//        /// Method to retrieve cloud services list for the current subscription
//        /// </summary>
//        /// <returns>list of cloud services.</returns>
//        public IEnumerable<CloudService> GetCloudServices()
//        {
//            CloudServiceListResponse response = this.GetRecoveryServicesClient.CloudServices.List();

//            return response.CloudServices;
//        }

//        /// <summary>
//        /// Method to get Cloud Service object for a given vault
//        /// </summary>
//        /// <param name="vault">vault object</param>
//        /// <returns>cloud service object.</returns>
//        public CloudService GetCloudServiceForVault(ASRVault vault)
//        {
//            IEnumerable<CloudService> cloudServiceList = this.GetCloudServices();

//            foreach (var cloudService in cloudServiceList)
//            {
//                Vault selectedVault = null;
//                if (cloudService.GeoRegion.Equals(vault.Location, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    foreach (var resource in cloudService.Resources)
//                    {
//                        if (resource.Name.Equals(vault.Name, StringComparison.InvariantCultureIgnoreCase))
//                        {
//                            selectedVault = resource;
//                            return cloudService;
//                        }
//                    }
//                }
//            }

//            throw new ArgumentException(
//                string.Format(
//                Properties.Resources.InCorrectVaultInformation,
//                vault.Name,
//                vault.Location));
//        }

//        /// <summary>
//        /// Method to Either find or create the cloud service.
//        /// </summary>
//        /// <param name="cloudServiceName">name of the cloud service to be created</param>
//        /// <param name="cloudServiceInput">cloud service input to create the service.</param>
//        public void FindOrCreateCloudService(string cloudServiceName, CloudServiceCreateArgs cloudServiceInput)
//        {
//            bool cloudServicePresent = this.DoesCloudServiceExits(cloudServiceName);

//            if (!cloudServicePresent)
//            {
//                this.GetRecoveryServicesClient.CloudServices.Create(cloudServiceName, cloudServiceInput);
//            }
//        }

//        /// <summary>
//        /// Checks whether a cloud service is present or not.
//        /// </summary>
//        /// <param name="cloudServiceName">name of the cloud service to be created</param>
//        /// <returns>returns true in case the cloud service exits and false otherwise.</returns>
//        private bool DoesCloudServiceExits(string cloudServiceName)
//        {
//            IEnumerable<CloudService> cloudServiceList = this.GetCloudServices();
//            bool cloudServicePresent = false;

//            foreach (var cloudService in cloudServiceList)
//            {
//                if (cloudServiceName.Equals(cloudService.Name, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    cloudServicePresent = true;
//                    break;
//                }
//            }

//            return cloudServicePresent;
//        }
//    }
//}
