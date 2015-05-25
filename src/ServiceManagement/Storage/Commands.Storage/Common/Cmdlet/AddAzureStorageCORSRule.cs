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

using System;
using System.Management.Automation;
using System.Security.Permissions;
using System.Globalization;
using SharedProtocol = Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Add azure storage CORS rule
    /// </summary>
    [Cmdlet(VerbsCommon.Add, StorageNouns.StorageCORSRule),
        OutputType(typeof(CorsProperties))]
    public class AddAzureStorageCORSRuleCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(HelpMessage = "Allowed Headers")]
        public string[] AllowedHeaders { get; set; }

        [Parameter(HelpMessage = "Allowed Methods")]
        [ValidateSet(CorsHttpMethods.Get, 
            CorsHttpMethods.Head,
            CorsHttpMethods.Post,
            CorsHttpMethods.Put,
            CorsHttpMethods.Delete,
            CorsHttpMethods.Trace,
            CorsHttpMethods.Options,
            CorsHttpMethods.Connect,
            CorsHttpMethods.Merge, 
            IgnoreCase = true)]
        public string[] AllowedMethods { get; set; }

        [Parameter(HelpMessage = "Allowed origins")]
        public string[] AllowedOrigins { get; set; }
        
        [Parameter(HelpMessage = "Exposed Headers")]
        public string[] ExposedHeaders { get; set; }

        [Parameter(HelpMessage = "Max age")]
        public int MaxAgeInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        public AddAzureStorageCORSRuleCommand()
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

            CorsRule corsRule = new CorsRule();
            corsRule.AllowedHeaders = this.AllowedHeaders;
            corsRule.AllowedOrigins = this.AllowedOrigins;
            corsRule.ExposedHeaders = this.ExposedHeaders;

            this.SetAllowedMethods(corsRule);

            serviceProperties.Cors = currentServiceProperties.Cors;
            currentServiceProperties.Cors.CorsRules.Add(corsRule);

            Channel.SetStorageServiceProperties(ServiceType, currentServiceProperties,
                GetRequestOptions(ServiceType), OperationContext);

            if (PassThru)
            {
                WriteObject(currentServiceProperties.Cors);
            }
        }

        private void SetAllowedMethods(CorsRule corsRule)
        {
            corsRule.AllowedMethods = SharedProtocol.CorsHttpMethods.None;

            foreach (var method in this.AllowedMethods)
            {
                SharedProtocol.CorsHttpMethods allowedCorsMethod = SharedProtocol.CorsHttpMethods.None;
                if (Enum.TryParse<SharedProtocol.CorsHttpMethods>(method, true, out allowedCorsMethod))
                {
                    corsRule.AllowedMethods |= allowedCorsMethod;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidHTTPMethod, method));
                }
            }
        }
    }
}
