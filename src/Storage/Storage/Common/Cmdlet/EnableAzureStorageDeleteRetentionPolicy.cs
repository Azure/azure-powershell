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
    /// Enable azure storage service DeleteRetentionPolicy, currently only enabled on Blob service
    /// </summary>
    [Cmdlet("Enable", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageDeleteRetentionPolicy", SupportsShouldProcess = true),OutputType(typeof(PSDeleteRetentionPolicy))]
    [Alias("Enable-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix+ "StorageSoftDelete")]
    public class EnableAzureStorageServiceDeleteRetentionPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Sets the number of retention days for the DeleteRetentionPolicy.")]
        [Alias("Days")]
        public int RetentionDays { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display DeleteRetentionPolicyProperties")]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        public override string TagCondition { get; set; }

        public EnableAzureStorageServiceDeleteRetentionPolicyCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Update the specified DeleteRetentionPolicyProperties according to the input
        /// </summary>
        /// <param name="serviceProperties">Service properties</param>
        internal void EnableDeleteRetentionProperties(ServiceProperties serviceProperties)
        {
            if (serviceProperties.DeleteRetentionPolicy == null)
            {
                serviceProperties.DeleteRetentionPolicy = new DeleteRetentionPolicy();
            }
            serviceProperties.DeleteRetentionPolicy.Enabled = true;
            serviceProperties.DeleteRetentionPolicy.RetentionDays = this.RetentionDays;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            StorageServiceType serviceType = StorageServiceType.Blob;

            if (ShouldProcess(serviceType.ToString(), "Enable Delete Retention Policy"))
            {
                ServiceProperties serviceProperties = Channel.GetStorageServiceProperties(serviceType, GetRequestOptions(serviceType), OperationContext);

                EnableDeleteRetentionProperties(serviceProperties);

                Channel.SetStorageServiceProperties(serviceType, serviceProperties,
                    GetRequestOptions(serviceType), OperationContext);

                if (PassThru)
                {
                    WriteObject(PSDeleteRetentionPolicy.ParsePSDeleteRetentionPolicy(serviceProperties.DeleteRetentionPolicy));
                }
            }
        }
    }
}
