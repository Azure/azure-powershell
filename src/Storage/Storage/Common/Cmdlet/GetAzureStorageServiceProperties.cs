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

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;

    /// <summary>
    /// Show Azure Storage service properties
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageServiceProperty"),OutputType(typeof(PSSeriviceProperties))]
    public class GetAzureStorageServicePropertyCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public GetAzureStorageServicePropertyCommand()
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
                ServiceProperties serviceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);
                WriteObject(new PSSeriviceProperties(serviceProperties));
            }
            else //Table use old XSCL
            {
                StorageTableManagement tableChannel = new StorageTableManagement(Channel.StorageContext);
                XTable.ServiceProperties serviceProperties = tableChannel.GetStorageTableServiceProperties(GetTableRequestOptions(), TableOperationContext);
                WriteObject(new PSSeriviceProperties(serviceProperties));
            }
        }
    }
}
