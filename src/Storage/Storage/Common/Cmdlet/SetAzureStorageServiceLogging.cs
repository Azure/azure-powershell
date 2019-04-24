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
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Shared.Protocol;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;
    using StorageClient = Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;

    /// <summary>
    /// Show azure storage service properties
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageServiceLoggingProperty"),OutputType(typeof(StorageClient.LoggingProperties))]
    public class SetAzureStorageServiceLoggingCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(HelpMessage = "Logging version")]
        public double? Version { get; set; }

        [Parameter(HelpMessage = "Logging retention days. -1 means disable Logging retention policy, otherwise enable.")]
        [ValidateRange(-1, 365)]
        public int? RetentionDays { get; set; }

        public const string LoggingOperationHelpMessage =
            "Logging operations. (All, None, combinations of Read, Write, Delete that are seperated by semicolon.)";
        [Parameter(HelpMessage = LoggingOperationHelpMessage)]
        public StorageClient.LoggingOperations[] LoggingOperations { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public SetAzureStorageServiceLoggingCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Update the specified service properties according to the input
        /// </summary>
        /// <param name="logging">Service properties</param>
        internal void UpdateServiceProperties(StorageClient.LoggingProperties logging)
        {
            if (Version != null)
            {
                logging.Version = Version.ToString();
            }

            if (RetentionDays != null)
            {
                if (RetentionDays == -1)
                {
                    //Disable logging retention policy
                    logging.RetentionDays = null;
                }
                else if (RetentionDays < 1 || RetentionDays > 365)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidRetentionDay, RetentionDays));
                }
                else
                {
                    logging.RetentionDays = RetentionDays;
                }
            }

            if (LoggingOperations != null && LoggingOperations.Length > 0)
            {
                StorageClient.LoggingOperations logOperations = default(StorageClient.LoggingOperations);

                for (int i = 0; i < LoggingOperations.Length; i++)
                {
                    if (LoggingOperations[i] == StorageClient.LoggingOperations.None
                        || LoggingOperations[i] == StorageClient.LoggingOperations.All)
                    {
                        if (LoggingOperations.Length > 1)
                        {
                            throw new ArgumentException(Resources.NoneAndAllOperationShouldBeAlone);
                        }
                    }

                    logOperations |= LoggingOperations[i];
                }

                logging.LoggingOperations = logOperations;
                // Set default logging version
                if (string.IsNullOrEmpty(logging.Version))
                {
                    string defaultLoggingVersion = StorageNouns.DefaultLoggingVersion;
                    logging.Version = defaultLoggingVersion;
                }
            }
        }

        /// <summary>
        /// Update the Table service properties according to the input
        /// </summary>
        /// <param name="logging">Service properties</param>
        internal void UpdateTableServiceProperties(XTable.LoggingProperties logging)
        {
            if (Version != null)
            {
                logging.Version = Version.ToString();
            }

            if (RetentionDays != null)
            {
                if (RetentionDays == -1)
                {
                    //Disable logging retention policy
                    logging.RetentionDays = null;
                }
                else if (RetentionDays < 1 || RetentionDays > 365)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidRetentionDay, RetentionDays));
                }
                else
                {
                    logging.RetentionDays = RetentionDays;
                }
            }

            if (LoggingOperations != null && LoggingOperations.Length > 0)
            {
                XTable.LoggingOperations logOperations = default(XTable.LoggingOperations);

                for (int i = 0; i < LoggingOperations.Length; i++)
                {
                    if (LoggingOperations[i] == StorageClient.LoggingOperations.None
                        || LoggingOperations[i] == StorageClient.LoggingOperations.All)
                    {
                        if (LoggingOperations.Length > 1)
                        {
                            throw new ArgumentException(Resources.NoneAndAllOperationShouldBeAlone);
                        }
                    }

                    logOperations |= (XTable.LoggingOperations)Enum.Parse(typeof(XTable.LoggingOperations), LoggingOperations[i].ToString(), true);

                }

                logging.LoggingOperations = logOperations;
                // Set default logging version
                if (string.IsNullOrEmpty(logging.Version))
                {
                    string defaultLoggingVersion = StorageNouns.DefaultLoggingVersion;
                    logging.Version = defaultLoggingVersion;
                }
            }
        }

        /// <summary>
        /// Get logging operations
        /// </summary>
        /// <param name="LoggingOperations">The string type of Logging operations</param>
        /// <example>GetLoggingOperations("all"), GetLoggingOperations("read, write")</example>
        /// <returns>LoggingOperations object</returns>
        internal StorageClient.LoggingOperations GetLoggingOperations(string LoggingOperations)
        {
            LoggingOperations = LoggingOperations.ToLower();
            if (LoggingOperations.IndexOf("all") != -1)
            {
                if (LoggingOperations == "all")
                {
                    return StorageClient.LoggingOperations.All;
                }
                else
                {
                    throw new ArgumentException(LoggingOperationHelpMessage);
                }
            }
            else if (LoggingOperations.IndexOf("none") != -1)
            {
                if (LoggingOperations == "none")
                {
                    return StorageClient.LoggingOperations.None;
                }
                else
                {
                    throw new ArgumentException(LoggingOperationHelpMessage);
                }
            }
            else
            {
                try
                {
                    return (StorageClient.LoggingOperations)Enum.Parse(typeof(StorageClient.LoggingOperations),
                        LoggingOperations, true);
                }
                catch
                {
                    throw new ArgumentException(String.Format(Resources.InvalidEnumName, LoggingOperations));
                }
            }
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (StorageServiceType.File == ServiceType)
            {
                throw new PSInvalidOperationException(Resources.FileNotSupportLogging);
            }

            if (ServiceType != StorageServiceType.Table)
            {
                StorageClient.ServiceProperties currentServiceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);

                // Premium Account not support classic metrics and logging
                if (currentServiceProperties.Logging == null)
                {
                    AccountProperties accountProperties = Channel.GetAccountProperties();
                    if (accountProperties.SkuName.Contains("Premium"))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "This Storage account doesn't support Classic Logging, since it’s a Premium Storage account: {0}", Channel.StorageContext.StorageAccountName));
                    }
                }

                StorageClient.ServiceProperties serviceProperties = new StorageClient.ServiceProperties();
                serviceProperties.Clean();
                serviceProperties.Logging = currentServiceProperties.Logging;

                UpdateServiceProperties(serviceProperties.Logging);

                Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                    GetRequestOptions(ServiceType), OperationContext);

                if (PassThru)
                {
                    WriteObject(serviceProperties.Logging);
                }
            }
            else //Table use old XSCL
            {
                StorageTableManagement tableChannel = new StorageTableManagement(Channel.StorageContext);
                XTable.ServiceProperties currentServiceProperties = tableChannel.GetStorageTableServiceProperties(GetTableRequestOptions(), TableOperationContext);

                // Premium Account not support classic metrics and logging
                if (currentServiceProperties.Logging == null)
                {
                    AccountProperties accountProperties = Channel.GetAccountProperties();
                    if (accountProperties.SkuName.Contains("Premium"))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "This Storage account doesn't support Classic Logging, since it’s a Premium Storage account: {0}", Channel.StorageContext.StorageAccountName));
                    }
                }

                XTable.ServiceProperties serviceProperties = new XTable.ServiceProperties();
                serviceProperties.Clean();
                serviceProperties.Logging = currentServiceProperties.Logging;

                UpdateTableServiceProperties(serviceProperties.Logging);

                tableChannel.SetStorageTableServiceProperties(serviceProperties,
                    GetTableRequestOptions(), TableOperationContext);

                if (PassThru)
                {
                    WriteObject(serviceProperties.Logging);
                }
            }
        }
    }
}
