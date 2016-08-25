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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using SharedProtocol = Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Define cmdlet to set azure storage CORS rules to service, it will overwrite all of the CORS rules in the service.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageNouns.StorageCORSRule),
        OutputType(typeof(PSCorsRule))]
    public class SetAzureStorageCORSRuleCommand : StorageCloudBlobCmdletBase
    {
        private const string InvalidXMLNodeValueError = "InvalidXmlNodeValue";
        private const string InvalidXMLDocError = "InvalidXmlDocument";

        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "CorsRule instances to represent rules to be set.")]
        [ValidateNotNull]
        public PSCorsRule[] CorsRules { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        public SetAzureStorageCORSRuleCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Clean();
            serviceProperties.Cors = new CorsProperties();

            foreach (var corsRuleObject in this.CorsRules)
            {
                CorsRule corsRule = new CorsRule();
                corsRule.AllowedHeaders = corsRuleObject.AllowedHeaders;
                corsRule.AllowedOrigins = corsRuleObject.AllowedOrigins;
                corsRule.ExposedHeaders = corsRuleObject.ExposedHeaders;
                corsRule.MaxAgeInSeconds = corsRuleObject.MaxAgeInSeconds;
                this.SetAllowedMethods(corsRule, corsRuleObject.AllowedMethods);
                serviceProperties.Cors.CorsRules.Add(corsRule);
            }

            try
            {
                Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                    GetRequestOptions(ServiceType), OperationContext);
            }
            catch (StorageException se)
            {
                if ((null != se.RequestInformation) &&
                    ((int)HttpStatusCode.BadRequest == se.RequestInformation.HttpStatusCode) &&
                    (null != se.RequestInformation.ExtendedErrorInformation) &&
                    (string.Equals(InvalidXMLNodeValueError, se.RequestInformation.ExtendedErrorInformation.ErrorCode, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(InvalidXMLDocError, se.RequestInformation.ExtendedErrorInformation.ErrorCode, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException(Resources.CORSRuleError);
                }
                else
                {
                    throw;
                }
            }

            if (PassThru)
            {
                WriteObject(this.CorsRules);
            }
        }

        private void SetAllowedMethods(CorsRule corsRule, string[] allowedMethods)
        {
            corsRule.AllowedMethods = SharedProtocol.CorsHttpMethods.None;

            if (null != allowedMethods)
            {
                foreach (var method in allowedMethods)
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
}
