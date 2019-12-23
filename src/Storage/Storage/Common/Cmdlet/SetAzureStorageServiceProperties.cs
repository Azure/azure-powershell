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
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using StorageClient = WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;

    /// <summary>
    /// Modify Azure Storage service properties
    /// </summary>
    [Cmdlet(VerbsData.Update, StorageNouns.StorageServiceProperty, SupportsShouldProcess = true), OutputType(typeof(PSSeriviceProperties))]
    public class UpdateAzureStorageServicePropertyCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Default Service Version to Set")]
        [ValidateNotNullOrEmpty]
        public string DefaultServiceVersion { get; set; }        

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public UpdateAzureStorageServicePropertyCommand()
        {
            EnableMultiThread = false;
        }       

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("ServiceProperties", VerbsCommon.Set))
            {
                StorageClient.ServiceProperties serviceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);

                serviceProperties.DefaultServiceVersion = this.DefaultServiceVersion;

                Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                    GetRequestOptions(ServiceType), OperationContext);

                if (PassThru)
                {
                    WriteObject(new PSSeriviceProperties(serviceProperties));
                }
            }
        }
    }
}
