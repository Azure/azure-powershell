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
    using Microsoft.Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;

    /// <summary>
    /// Show azure storage service properties
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageServiceMetricsProperty"),OutputType(typeof(MetricsProperties))]
    public class GetAzureStorageServiceMetricsCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Azure storage service metrics type(Hour, Minute).")]
        public ServiceMetricsType MetricsType { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public GetAzureStorageServiceMetricsCommand()
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

                // Premium Account not support classic metrics and logging
                if ((MetricsType == ServiceMetricsType.Hour && serviceProperties.HourMetrics == null)
                    || (MetricsType == ServiceMetricsType.Minute && serviceProperties.MinuteMetrics == null))
                {
                    AccountProperties accountProperties = Channel.GetAccountProperties();
                    if (accountProperties.SkuName.Contains("Premium"))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "This Storage account doesn't support Classic Metrics, since it’s a Premium Storage account: {0}", Channel.StorageContext.StorageAccountName));
                    }
                }

                switch (MetricsType)
                {
                    case ServiceMetricsType.Hour:
                        WriteObject(serviceProperties.HourMetrics);
                        break;
                    case ServiceMetricsType.Minute:
                    default:
                        WriteObject(serviceProperties.MinuteMetrics);
                        break;
                }
            }
            else //Table use old XSCL
            {
                StorageTableManagement tableChannel = new StorageTableManagement(Channel.StorageContext);
                XTable.ServiceProperties serviceProperties = tableChannel.GetStorageTableServiceProperties(GetTableRequestOptions(), TableOperationContext);

                // Premium Account not support classic metrics and logging
                if ((MetricsType == ServiceMetricsType.Hour && serviceProperties.HourMetrics == null)
                    || (MetricsType == ServiceMetricsType.Minute && serviceProperties.MinuteMetrics == null))
                {
                    AccountProperties accountProperties = Channel.GetAccountProperties();
                    if (accountProperties.SkuName.Contains("Premium"))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "This Storage account doesn't support Classic Metrics, since it’s a Premium Storage account: {0}", Channel.StorageContext.StorageAccountName));
                    }
                }

                switch (MetricsType)
                {
                    case ServiceMetricsType.Hour:
                        WriteObject(serviceProperties.HourMetrics);
                        break;
                    case ServiceMetricsType.Minute:
                    default:
                        WriteObject(serviceProperties.MinuteMetrics);
                        break;
                }
            }
        }
    }
}
