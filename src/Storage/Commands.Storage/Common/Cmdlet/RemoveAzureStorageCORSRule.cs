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

using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Remove all azure storage CORS rules
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, StorageNouns.StorageCORSRule)]
    public class RemoveAzureStorageCORSRuleCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

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
            ServiceProperties currentServiceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);
            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Clean();
            serviceProperties.Cors = currentServiceProperties.Cors;
            serviceProperties.Cors.CorsRules.Clear();

            Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                GetRequestOptions(ServiceType), OperationContext);
        }
    }
}
