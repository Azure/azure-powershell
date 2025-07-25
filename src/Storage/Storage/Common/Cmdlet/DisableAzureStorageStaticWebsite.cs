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
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using Microsoft.Azure.Storage.Shared.Protocol;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// Disable azure storage service StaticWebsite, currently only available on Blob service
    /// </summary>
    [Cmdlet("Disable", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageStaticWebsite", SupportsShouldProcess = true), 
        OutputType(typeof(PSStaticWebsiteProperties))]
    public class DisableAzureStorageServiceStaticWebsiteCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        public override string TagCondition { get; set; }

        public DisableAzureStorageServiceStaticWebsiteCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Update the specified StaticWebsite Properties according to the input
        /// </summary>
        /// <param name="serviceProperties">Service properties</param>
        internal void DisableStaticWebsiteProperties(ServiceProperties serviceProperties)
        {
            if (serviceProperties.StaticWebsite == null)
            {
                serviceProperties.StaticWebsite = new StaticWebsiteProperties();
            }

            serviceProperties.StaticWebsite.Enabled = false;
            serviceProperties.StaticWebsite.IndexDocument = null;
            serviceProperties.StaticWebsite.ErrorDocument404Path = null;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            StorageServiceType serviceType = StorageServiceType.Blob;

            if (ShouldProcess(serviceType.ToString(), "Disable Static Website"))
            {
                ServiceProperties serviceProperties = Channel.GetStorageServiceProperties(serviceType, GetRequestOptions(serviceType), OperationContext);

                DisableStaticWebsiteProperties(serviceProperties);

                Channel.SetStorageServiceProperties(serviceType, serviceProperties,
                    GetRequestOptions(serviceType), OperationContext);

                if (PassThru)
                {
                    WriteObject(PSStaticWebsiteProperties.ParsePSStaticWebsiteProperties(serviceProperties.StaticWebsite));
                }
            }
        }
    }
}
