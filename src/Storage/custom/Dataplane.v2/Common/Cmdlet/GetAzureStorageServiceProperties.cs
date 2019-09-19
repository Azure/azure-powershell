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

namespace Microsoft.Azure.Commands.Storage.Common.Cmdlet
{
    using Microsoft.Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Storage.Model.ResourceModel;
    using Microsoft.Azure.Commands.Storage.Model.Contract;

    /// <summary>
    /// Show Azure Storage service properties
    /// </summary>
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile("latest-2019-04-30")]
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageServiceProperty!V2"),OutputType(typeof(PSSeriviceProperties))]
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
