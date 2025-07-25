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

using Microsoft.Azure.Storage.Shared.Protocol;
using XTable = Microsoft.Azure.Cosmos.Table;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using System;
using Azure.Data.Tables.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Remove all azure storage CORS rules
    /// </summary>
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageCORSRule"), OutputType(typeof(void))]
    public class RemoveAzureStorageCORSRuleCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

        public RemoveAzureStorageCORSRuleCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (ServiceType != StorageServiceType.Table)
            {
                ServiceProperties currentServiceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);
                ServiceProperties serviceProperties = new ServiceProperties();
                serviceProperties.Clean();
                serviceProperties.Cors = currentServiceProperties.Cors;
                serviceProperties.Cors.CorsRules.Clear();

                Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                    GetRequestOptions(ServiceType), OperationContext);
            }
            else //Table use old XSCL
            {
                StorageTableManagement tableChannel = new StorageTableManagement(Channel.StorageContext);

                if (!tableChannel.IsTokenCredential)
                {
                    XTable.ServiceProperties currentServiceProperties = tableChannel.GetStorageTableServiceProperties(GetTableRequestOptions(), TableOperationContext);
                    XTable.ServiceProperties serviceProperties = new XTable.ServiceProperties();
                    serviceProperties.Clean();
                    serviceProperties.Cors = currentServiceProperties.Cors;
                    serviceProperties.Cors.CorsRules.Clear();

                    tableChannel.SetStorageTableServiceProperties(serviceProperties,
                        GetTableRequestOptions(), TableOperationContext);
                }
                else
                {
                    TableServiceProperties serviceProperties = tableChannel.GetProperties(this.CmdletCancellationToken);
                    serviceProperties.Cors.Clear();

                    tableChannel.SetProperties(serviceProperties, this.CmdletCancellationToken);
                }
            }
        }
    }
}
