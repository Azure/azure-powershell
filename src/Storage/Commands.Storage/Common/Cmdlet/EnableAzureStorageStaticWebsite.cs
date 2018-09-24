﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// Enable azure storage service StaticWebsite, currently only enabled on Blob service
    /// </summary>
    public class EnableAzureStorageServiceStaticWebsiteCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The name of the index document in each directory.")]
        public string IndexDocument { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "the path to the error document that should be shown when a 404 is issued (meaning, when a browser requests a page that does not exist.)")]
        public string ErrorDocument404Path { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public EnableAzureStorageServiceStaticWebsiteCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Update the specified StaticWebsite Properties according to the input
        /// </summary>
        /// <param name="policy">StaticWebsite Properties</param>
        internal void EnableStaticWebsiteProperties(ServiceProperties serviceProperties)
        {
            if (serviceProperties.StaticWebsite == null)
            {
                serviceProperties.StaticWebsite = new StaticWebsiteProperties();
            }
            serviceProperties.StaticWebsite.Enabled = true;
            serviceProperties.StaticWebsite.IndexDocument = this.IndexDocument;
            serviceProperties.StaticWebsite.ErrorDocument404Path = this.ErrorDocument404Path;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            StorageServiceType serviceType = StorageServiceType.Blob;

            if (ShouldProcess(serviceType.ToString(), "Enable Static Website"))
            {
                ServiceProperties serviceProperties = Channel.GetStorageServiceProperties(serviceType, GetRequestOptions(serviceType), OperationContext);

                EnableStaticWebsiteProperties(serviceProperties);

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
