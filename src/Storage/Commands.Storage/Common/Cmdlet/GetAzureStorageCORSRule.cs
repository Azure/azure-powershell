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

using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Show azure storage CORS rule properties
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageNouns.StorageCORSRule),
        OutputType(typeof(PSCorsRule))]
    public class GetAzureStorageCORSRuleCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        public GetAzureStorageCORSRuleCommand()
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
            List<PSCorsRule> ruleList = new List<PSCorsRule>();

            foreach (var corsRule in currentServiceProperties.Cors.CorsRules)
            {
                PSCorsRule psCorsRule = new PSCorsRule();
                psCorsRule.AllowedOrigins = this.ListToArray(corsRule.AllowedOrigins);
                psCorsRule.AllowedHeaders = this.ListToArray(corsRule.AllowedHeaders);
                psCorsRule.ExposedHeaders = this.ListToArray(corsRule.ExposedHeaders);
                psCorsRule.AllowedMethods = this.ConvertCorsHttpMethodToString(corsRule.AllowedMethods);
                psCorsRule.MaxAgeInSeconds = corsRule.MaxAgeInSeconds;
                ruleList.Add(psCorsRule);
            }

            WriteObject(ruleList.ToArray());
        }

        private string[] ConvertCorsHttpMethodToString(CorsHttpMethods methods)
        {
            List<string> methodList = new List<string>();

            foreach (CorsHttpMethods methodValue in Enum.GetValues(typeof(CorsHttpMethods)).Cast<CorsHttpMethods>())
            {
                if (methodValue != CorsHttpMethods.None && (methods & methodValue) != 0)
                {
                    methodList.Add(methodValue.ToString());
                }
            }

            return methodList.ToArray();
        }

        private string[] ListToArray(IList<string> stringList)
        {
            if (null == stringList)
            {
                return null;
            }

            string[] stringArray = new string[stringList.Count];
            stringList.CopyTo(stringArray, 0);
            return stringArray;
        }
    }
}
