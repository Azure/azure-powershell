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
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Shared.Protocol;
using XTable = Microsoft.Azure.Cosmos.Table;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using SharedProtocol = Microsoft.Azure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Azure.Data.Tables.Models;
using Azure;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// Define cmdlet to set azure storage CORS rules to service, it will overwrite all of the CORS rules in the service.
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageCORSRule"),OutputType(typeof(PSCorsRule))]
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

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

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
            if (ServiceType != StorageServiceType.Table)
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
                        (string.Equals(InvalidXMLNodeValueError, se.RequestInformation.ErrorCode, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(InvalidXMLDocError, se.RequestInformation.ErrorCode, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException(Resources.CORSRuleError);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else //Table use old XSCL
            {
                StorageTableManagement tableChannel = new StorageTableManagement(Channel.StorageContext);

                if (!tableChannel.IsTokenCredential)
                {
                    XTable.ServiceProperties serviceProperties = new XTable.ServiceProperties();
                    serviceProperties.Clean();
                    serviceProperties.Cors = new XTable.CorsProperties();

                    foreach (var corsRuleObject in this.CorsRules)
                    {
                        XTable.CorsRule corsRule = new XTable.CorsRule();
                        corsRule.AllowedHeaders = corsRuleObject.AllowedHeaders;
                        corsRule.AllowedOrigins = corsRuleObject.AllowedOrigins;
                        corsRule.ExposedHeaders = corsRuleObject.ExposedHeaders;
                        corsRule.MaxAgeInSeconds = corsRuleObject.MaxAgeInSeconds;
                        this.SetAllowedMethods(corsRule, corsRuleObject.AllowedMethods);
                        serviceProperties.Cors.CorsRules.Add(corsRule);
                    }

                    try
                    {
                        tableChannel.SetStorageTableServiceProperties(serviceProperties,
                            GetTableRequestOptions(), TableOperationContext);
                    }
                    catch (XTable.StorageException se)
                    {
                        if ((null != se.RequestInformation) &&
                            ((int)HttpStatusCode.BadRequest == se.RequestInformation.HttpStatusCode) &&
                            (null != se.RequestInformation.ExtendedErrorInformation) &&
                            (string.Equals(InvalidXMLNodeValueError, se.RequestInformation.ErrorCode, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(InvalidXMLDocError, se.RequestInformation.ErrorCode, StringComparison.OrdinalIgnoreCase)))
                        {
                            throw new InvalidOperationException(Resources.CORSRuleError);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    TableServiceProperties serviceProperties = tableChannel.GetProperties(this.CmdletCancellationToken);
                    serviceProperties.Cors.Clear();

                    foreach (PSCorsRule corsRule in this.CorsRules)
                    {
                        serviceProperties.Cors.Add(new TableCorsRule(
                            corsRule.AllowedOrigins == null ? string.Empty : string.Join(",", corsRule.AllowedOrigins),
                            this.CheckAndJoinAllowedMethods(corsRule.AllowedMethods),
                            corsRule.AllowedHeaders == null ? string.Empty : string.Join(",", corsRule.AllowedHeaders),
                            corsRule.ExposedHeaders == null ? string.Empty : string.Join(",", corsRule.ExposedHeaders),
                            corsRule.MaxAgeInSeconds));
                    }

                    try
                    {
                        tableChannel.SetProperties(serviceProperties, this.CmdletCancellationToken);
                    }
                    catch (RequestFailedException ex)
                    {
                        this.WriteExceptionError(ex);
                        throw new InvalidOperationException(Resources.CORSRuleError);
                    }
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

        private void SetAllowedMethods(XTable.CorsRule corsRule, string[] allowedMethods)
        {
            corsRule.AllowedMethods = XTable.CorsHttpMethods.None;

            if (null != allowedMethods)
            {
                foreach (var method in allowedMethods)
                {
                    XTable.CorsHttpMethods allowedCorsMethod = XTable.CorsHttpMethods.None;
                    if (Enum.TryParse<XTable.CorsHttpMethods>(method, true, out allowedCorsMethod))
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

        private string CheckAndJoinAllowedMethods(string[] allowedMethods)
        {
            if (allowedMethods == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var method in allowedMethods)
            {
                if (sb.Length > 0)
                {
                    sb.Append(',');
                }

                XTable.CorsHttpMethods allowedCorsMethod = XTable.CorsHttpMethods.None;
                if (Enum.TryParse<XTable.CorsHttpMethods>(method, ignoreCase: true, out allowedCorsMethod))
                {
                    sb.Append(allowedCorsMethod);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidHTTPMethod, method));
                }
            }

            return sb.ToString().ToUpperInvariant();
        }
    }
}
