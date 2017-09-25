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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    public abstract class AdminCmdletDefaultFarm : AdminCmdlet
    {
        private const string AzureStackStorageAdminNameSpace = "Microsoft.Storage.Admin";
        private const string AzureStackStorageAdminDefaultResourceGroupPrefix = "System.";

        /// <summary>
        /// Farm identifier, no more a parameter
        /// </summary>
        protected string FarmName { get; set; }

        /// <summary>
        /// Resource group name used for URI
        /// </summary>
        protected string ResourceGroupName { get; set; }

        protected override void ProcessRecord()
        {
            GetDefaultResourceGroup();
            GetDefaultFarmName();
            base.ProcessRecord();
        }

        /// <summary>
        /// Get the default resource group for stoarge admin.
        /// This is consturcted as "System." + Location
        /// </summary>
        protected void GetDefaultResourceGroup()
        {
            WriteVerbose("Fetching default Resource Group");
            ResourceManagerSdkClient resourcesSdkClient = new ResourceManagerSdkClient(DefaultContext)
            {
                VerboseLogger = WriteVerboseWithTimestamp,
                ErrorLogger = WriteErrorWithTimestamp,
                WarningLogger = WriteWarningWithTimestamp
            };

            PSResourceProvider[] providers = resourcesSdkClient.ListResourceProviders(providerName: AzureStackStorageAdminNameSpace)
                                                               .Select( provider => provider.ToPSResourceProvider()).ToArray();

            if (null == providers || null == providers.FirstOrDefault() ||
                null == providers.FirstOrDefault().Locations || String.IsNullOrEmpty(providers.FirstOrDefault().Locations.FirstOrDefault()))
            {
                WriteErrorWithTimestamp(String.Format("Failed to get Resource Provider {0}", AzureStackStorageAdminNameSpace));
                WriteErrorWithTimestamp("Failed to Obtain Default location");
                throw new InvalidOperationException("Failed to Obtain Default location");
            }
            else
            {
                this.ResourceGroupName = AzureStackStorageAdminDefaultResourceGroupPrefix + providers.First().Locations.First();
                WriteVerbose(String.Format("Obtained Default Resource Group {0}", this.ResourceGroupName));
            }
        }
        /// <summary>
        /// Given a resourcegroupname the method fetches and returns the first farm
        /// For V1 there is only one farm, so this one would always fetch the one and only right farm
        /// </summary>
        /// <returns></returns>
        protected void GetDefaultFarmName()
        {
            if (null == this.FarmName)
            {
                WriteVerbose("Fetching default Farm Name");
                FarmListResponse response = Client.Farms.List(this.ResourceGroupName);
                FarmResponse defaultFarm = new FarmResponse(response.Farms[0]);
                this.FarmName = defaultFarm.FarmName;
                WriteVerbose(String.Format("Obtained Default Farm {0}", this.FarmName));
            }
        }
        protected void ExtractOperationIdFromLocationUri(string operationUri, out string operationId)
        {
            WriteVerbose(String.Format("Operation URI = {0}", operationUri));
            
            const string operationresults = "operationresults/";
            const int operationResultLength = 36; // Guid lenght
            int indexOfOperationResultStart = operationUri.IndexOf(operationresults, StringComparison.InvariantCultureIgnoreCase);

            operationId = operationUri.Substring(indexOfOperationResultStart + operationresults.Length, operationResultLength);
            WriteVerbose(String.Format("Operation Result Id = {0}", operationId));
        }
    }
}
