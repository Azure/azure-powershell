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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Extension.AEM
{
    internal class AEMHelper
    {
        private Action<ErrorRecord> _ErrorAction = null;
        private Action<string> _VerboseAction = null;
        private Action<string> _WarningAction = null;
        private PSHostUserInterface _UI = null;
        private Dictionary<string, StorageAccount> _StorageCache = new Dictionary<string, StorageAccount>(StringComparer.InvariantCultureIgnoreCase);
        private Dictionary<string, string> _StorageKeyCache = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        private StorageManagementClient _StorageClient;
        private IAzureSubscription _Subscription;

        public AEMHelper(Action<ErrorRecord> errorAction, Action<string> verboseAction, Action<string> warningAction,
            PSHostUserInterface ui, StorageManagementClient storageClient, IAzureSubscription subscription)
        {
            this._ErrorAction = errorAction;
            this._VerboseAction = verboseAction;
            this._WarningAction = warningAction;
            this._UI = ui;
            this._StorageClient = storageClient;
            this._Subscription = subscription;
        }

        internal string GetStorageAccountFromUri(string uri)
        {
            var match = Regex.Match(new Uri(uri).Host, "(.*?)\\..*");
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                WriteError("Could not determine storage account for OS disk. Please contact support");
                throw new ArgumentException("Could not determine storage account for OS disk. Please contact support");
            }
        }

        internal StorageAccount GetStorageAccountFromCache(string accountName)
        {
            if (_StorageCache.ContainsKey(accountName))
            {
                return _StorageCache[accountName];
            }

            var listResponse = this._StorageClient.StorageAccounts.List();
            var account = listResponse.First(accTemp => accTemp.Name.Equals(accountName, StringComparison.InvariantCultureIgnoreCase));

            _StorageCache.Add(account.Name, account);

            return account;
        }
        internal string GetResourceGroupFromId(string id)
        {
            var matcher = new Regex("/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/(\\w+)");
            var result = matcher.Match(id);
            if (!result.Success || result.Groups == null || result.Groups.Count < 3)
            {
                throw new InvalidOperationException(string.Format("Cannot find resource group name and storage account name from resource identity {0}", id));
            }

            return result.Groups[2].Value;
        }

        internal string GetResourceNameFromId(string id)
        {
            var matcher = new Regex("/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/([^/]+)/([^/]+)/([^/]+)(/\\w+)?");
            var result = matcher.Match(id);
            if (!result.Success || result.Groups == null || result.Groups.Count < 3)
            {
                throw new InvalidOperationException(string.Format("Cannot find resource group name and storage account name from resource identity {0}", id));
            }

            return result.Groups[5].Value;
        }

        internal bool IsPremiumStorageAccount(string accountName)
        {
            return IsPremiumStorageAccount(this.GetStorageAccountFromCache(accountName));
        }

        internal int? GetDiskSizeGbFromBlobUri(string sBlobUri)
        {
            if (String.IsNullOrEmpty(sBlobUri))
            {
                return null;
            }

            var blobMatch = Regex.Match(sBlobUri, "https?://(\\S*?)\\..*?/(.*)");
            if (!blobMatch.Success)
            {
                WriteError("Blob URI of disk does not match known pattern {0}", sBlobUri);
                throw new ArgumentException("Blob URI of disk does not match known pattern");
            }
            var accountName = blobMatch.Groups[1].Value;

            BlobUri blobUri;
            if (BlobUri.TryParseUri(new Uri(sBlobUri), out blobUri))
            {
                try
                {
                    var account = this.GetStorageAccountFromCache(accountName);
                    var resGroupName = this.GetResourceGroupFromId(account.Id);
                    StorageCredentialsFactory storageCredentialsFactory = new StorageCredentialsFactory(resGroupName,
                        this._StorageClient, this._Subscription);
                    StorageCredentials sc = storageCredentialsFactory.Create(blobUri);
                    CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(sc, true);
                    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobUri.BlobContainerName);
                    var cloudBlob = blobContainer.GetPageBlobReference(blobUri.BlobName);
                    var sasToken = cloudBlob.GetSharedAccessSignature(
                        new SharedAccessBlobPolicy()
                        {
                            SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24.0),
                            Permissions = SharedAccessBlobPermissions.Read
                        });
                    cloudBlob.FetchAttributesAsync()
                             .ConfigureAwait(false).GetAwaiter().GetResult();

                    return (int?)(cloudBlob.Properties.Length / (1024 * 1024 * 1024));
                }
                catch (Exception)
                {
                    this.WriteWarning("Could not determine OS Disk size.");
                }
            }

            return null;
        }

        internal AzureSLA GetVMSLA(VirtualMachine virtualMachine)
        {
            var result = new AzureSLA();
            result.HasSLA = false;
            switch (virtualMachine.HardwareProfile.VmSize)
            {
                case "Standard_DS1":
                    result.HasSLA = true;
                    result.IOPS = 3200;
                    result.TP = 32;
                    break;
                case "Standard_DS1_v2":
                    result.HasSLA = true;
                    result.IOPS = 3200;
                    result.TP = 48;
                    break;
                case "Standard_DS2":
                    result.HasSLA = true;
                    result.IOPS = 6400;
                    result.TP = 64;
                    break;
                case "Standard_DS2_v2":
                    result.HasSLA = true;
                    result.IOPS = 6400;
                    result.TP = 96;
                    break;
                case "Standard_DS3":
                    result.HasSLA = true;
                    result.IOPS = 12800;
                    result.TP = 128;
                    break;
                case "Standard_DS3_v2":
                    result.HasSLA = true;
                    result.IOPS = 12800;
                    result.TP = 192;
                    break;
                case "Standard_DS4":
                    result.HasSLA = true;
                    result.IOPS = 25600;
                    result.TP = 256;
                    break;
                case "Standard_DS4_v2":
                    result.HasSLA = true;
                    result.IOPS = 25600;
                    result.TP = 384;
                    break;
                case "Standard_DS5_v2":
                    result.HasSLA = true;
                    result.IOPS = 51200;
                    result.TP = 768;
                    break;
                case "Standard_DS11":
                    result.HasSLA = true;
                    result.IOPS = 6400;
                    result.TP = 64;
                    break;
                case "Standard_DS11_v2":
                    result.HasSLA = true;
                    result.IOPS = 6400;
                    result.TP = 96;
                    break;
                case "Standard_DS12":
                    result.HasSLA = true;
                    result.IOPS = 12800;
                    result.TP = 128;
                    break;
                case "Standard_DS12_v2":
                    result.HasSLA = true;
                    result.IOPS = 12800;
                    result.TP = 192;
                    break;
                case "Standard_DS13":
                    result.HasSLA = true;
                    result.IOPS = 25600;
                    result.TP = 256;
                    break;
                case "Standard_DS13_v2":
                    result.HasSLA = true;
                    result.IOPS = 25600;
                    result.TP = 384;
                    break;
                case "Standard_DS14":
                    result.HasSLA = true;
                    result.IOPS = 51200;
                    result.TP = 512;
                    break;
                case "Standard_DS14_v2":
                    result.HasSLA = true;
                    result.IOPS = 51200;
                    result.TP = 768;
                    break;
                case "Standard_DS15_v2":
                    result.HasSLA = true;
                    result.IOPS = 64000;
                    result.TP = 960;
                    break;
                case "Standard_GS1":
                    result.HasSLA = true;
                    result.IOPS = 5000;
                    result.TP = 125;
                    break;
                case "Standard_GS2":
                    result.HasSLA = true;
                    result.IOPS = 10000;
                    result.TP = 250;
                    break;
                case "Standard_GS3":
                    result.HasSLA = true;
                    result.IOPS = 20000;
                    result.TP = 500;
                    break;
                case "Standard_GS4":
                    result.HasSLA = true;
                    result.IOPS = 40000;
                    result.TP = 1000;
                    break;
                case "Standard_GS5":
                    result.HasSLA = true;
                    result.IOPS = 80000;
                    result.TP = 2000;
                    break;
                case "Standard_M64ms":
                    result.HasSLA = true;
                    result.IOPS = 40000;
                    result.TP = 1000;
                    break;
                case "Standard_M128s":
                    result.HasSLA = true;
                    result.IOPS = 80000;
                    result.TP = 2000;
                    break;
                default:
                    break;
            }

            return result;
        }

        internal string GetAzureStorageKeyFromCache(string accountName)
        {
            if (_StorageKeyCache.ContainsKey(accountName))
            {
                return _StorageKeyCache[accountName];
            }

            var account = this.GetStorageAccountFromCache(accountName);
            var resourceGroup = this.GetResourceGroupFromId(account.Id);
            var keys = this._StorageClient.StorageAccounts.ListKeys(resourceGroup, account.Name);

            _StorageKeyCache.Add(account.Name, keys.GetKey1());

            return keys.GetKey1();
        }

        internal string GetCoreEndpoint(string storageAccountName)
        {
            try
            {
                var storage = this.GetStorageAccountFromCache(storageAccountName);
                var blobendpoint = storage.PrimaryEndpoints.Blob;
                var blobUri = new Uri(blobendpoint);

                var blobMatch = Regex.Match(blobUri.Host, ".*?\\.blob\\.(.*)");
                if (blobMatch.Success)
                {
                    return blobMatch.Groups[1].Value;
                }
            }
            catch (Exception ex)
            {
                WriteWarning("Could not extract endpoint information from Azure Storage Account ({0}). Using default {1}", ex.Message, AEMExtensionConstants.AzureEndpoint);
            }

            WriteWarning("Could not extract endpoint information from Azure Storage Account. Using default {0}", AEMExtensionConstants.AzureEndpoint);
            return AEMExtensionConstants.AzureEndpoint;
        }

        internal string GetAzureSAPTableEndpoint(StorageAccount storage)
        {
            return storage.PrimaryEndpoints.Table.ToString();
        }

        internal bool IsPremiumStorageAccount(StorageAccount account)
        {
            if (account.Sku() != null)
            {
                return account.IsPremiumLrs();
            }

            WriteError("No AccountType for storage account {0} found", account.Name);
            throw new ArgumentException("No AccountType for storage account found");
        }

        internal AzureSLA GetDiskSLA(OSDisk osdisk)
        {
            return this.GetDiskSLA(osdisk.DiskSizeGB, osdisk.Vhd);
        }

        internal AzureSLA GetDiskSLA(DataDisk datadisk)
        {
            return this.GetDiskSLA(datadisk.DiskSizeGB, datadisk.Vhd);
        }

        internal AzureSLA GetDiskSLA(int? diskSize, VirtualHardDisk vhd)
        {
            if (!diskSize.HasValue && vhd != null)
            {
                diskSize = this.GetDiskSizeGbFromBlobUri(vhd.Uri);
            }
            if (!diskSize.HasValue)
            {
                this.WriteWarning("OS Disk size is empty and could not be determined. Assuming P10.");
                diskSize = 127;
            }

            AzureSLA sla = new AzureSLA();
            if (diskSize > 0 && diskSize <= 32)
            {
                // P4
                sla.IOPS = 120;
                sla.TP = 125;
            }
            else if (diskSize > 0 && diskSize <= 64)
            {
                // P6
                sla.IOPS = 240;
                sla.TP = 50;
            }
            else if (diskSize > 0 && diskSize <= 128)
            {
                // P10
                sla.IOPS = 500;
                sla.TP = 100;
            }
            else if (diskSize > 0 && diskSize <= 512)
            {
                // P20
                sla.IOPS = 2300;
                sla.TP = 150;
            }
            else if (diskSize > 0 && diskSize <= 1024)
            {
                // P30
                sla.IOPS = 5000;
                sla.TP = 200;
            }
            else if (diskSize > 0 && diskSize <= 2048)
            {
                // P40
                sla.IOPS = 7500;
                sla.TP = 250;
            }
            else if (diskSize > 0 && diskSize <= 4095)
            {
                // P50
                sla.IOPS = 7500;
                sla.TP = 250;
            }
            else
            {
                WriteError("Unkown disk size for Premium Storage - {0}", diskSize);
                throw new ArgumentException("Unkown disk size for Premium Storage");
            }

            return sla;
        }

        internal void WriteHost(string message, params string[] args)
        {
            this.WriteHost(message, newLine: true, foregroundColor: null, args: args);
        }

        internal void WriteHost(string message, bool newLine)
        {
            this.WriteHost(message, newLine: newLine, foregroundColor: null);
        }
        internal void WriteHost(string message, bool newLine, params string[] args)
        {
            this.WriteHost(message, newLine: newLine, foregroundColor: null, args: args);
        }

        internal void WriteHost(string message, ConsoleColor foregroundColor)
        {
            this.WriteHost(message, newLine: true, foregroundColor: foregroundColor);
        }

        internal void WriteHost(string message, bool newLine, ConsoleColor? foregroundColor, params string[] args)
        {
            Trace.WriteLine("WriteHost:" + String.Format(message, args));

            try
            {
                this.WriteVerbose(message, args);
                var fColor = foregroundColor != null ? foregroundColor.Value : this._UI.RawUI.ForegroundColor;
                var bgColor = this._UI.RawUI.BackgroundColor;

                if (newLine)
                {
                    this._UI.WriteLine(fColor, bgColor, String.Format(message, args));
                }
                else
                {
                    this._UI.Write(fColor, bgColor, String.Format(message, args));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception while trying to write to UI: " + ex.Message);
            }
        }

        internal void WriteVerbose(string message, params object[] args)
        {
            Trace.WriteLine("WriteVerbose:" + String.Format(message, args));

            try
            {
                this._VerboseAction(String.Format(message, args));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception while trying to write to UI: " + ex.Message);
            }
        }

        internal void WriteError(string message, params object[] args)
        {
            Trace.WriteLine("WriteError:" + String.Format(message, args));

            try
            {
                this._ErrorAction(new ErrorRecord(new Exception(String.Format(message, args)), "Error", ErrorCategory.NotSpecified, null));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception while trying to write to UI: " + ex.Message);
            }
        }

        internal void WriteWarning(string message, params object[] args)
        {
            Trace.WriteLine("WriteWarning:" + String.Format(message, args));

            try
            {
                this._WarningAction(String.Format(message, args));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception while trying to write to UI: " + ex.Message);
            }
        }

        internal string GetDiskName(string diskPath)
        {
            Uri diskPathUri;
            if (Uri.TryCreate(diskPath, UriKind.Absolute, out diskPathUri))
            {
                string fileName = diskPathUri.Segments[diskPathUri.Segments.Length - 1];
                fileName = Uri.UnescapeDataString(fileName);

                return fileName;
            }

            return "UKNOWN";
        }

        internal VirtualMachineExtension GetExtension(VirtualMachine vm, string type, string publisher)
        {
            if (vm.Resources != null)
            {
                return vm.Resources.FirstOrDefault(ext =>
                   ext.VirtualMachineExtensionType.Equals(type)
                   && ext.Publisher.Equals(publisher));
            }
            return null;
        }

        internal Version GetExtensionVersion(VirtualMachine vm, VirtualMachineInstanceView vmStatus, string osType, string type, string publisher)
        {
            Version version = new Version();
            if (AEMExtensionConstants.AEMExtensionPublisher[osType].Equals(publisher, StringComparison.InvariantCultureIgnoreCase)
                && AEMExtensionConstants.AEMExtensionType[osType].Equals(type, StringComparison.InvariantCultureIgnoreCase))
            {
                version = AEMExtensionConstants.AEMExtensionVersion[osType];
            }
            else if (AEMExtensionConstants.WADExtensionPublisher[osType].Equals(publisher, StringComparison.InvariantCultureIgnoreCase)
                && AEMExtensionConstants.WADExtensionType[osType].Equals(type, StringComparison.InvariantCultureIgnoreCase))
            {
                version = AEMExtensionConstants.WADExtensionVersion[osType];
            }

            if (vm.Resources != null && vmStatus.Extensions != null)
            {
                var extension = vm.Resources.FirstOrDefault(ext =>
                   ext.VirtualMachineExtensionType.Equals(type)
                   && ext.Publisher.Equals(publisher));

                if (extension != null)
                {
                    var extensionStatus = vmStatus.Extensions.FirstOrDefault(ext => ext.Name.Equals(extension.Name));

                    if (extensionStatus != null)
                    {
                        string strExtVersion = extensionStatus.TypeHandlerVersion;
                        Version extVersion;
                        if (Version.TryParse(strExtVersion, out extVersion) && extVersion > version)
                        {
                            version = extVersion;
                        }
                    }
                }
            }
            return version;
        }

        internal VirtualMachineExtensionInstanceView GetExtension(VirtualMachine vm, VirtualMachineInstanceView vmStatus, string type, string publisher)
        {
            var ext = this.GetExtension(vm, type, publisher);
            if (ext == null)
            {
                return null;
            }

            if (vmStatus.Extensions == null)
            {
                return null;
            }
            return vmStatus.Extensions.FirstOrDefault(extSt => extSt.Name.Equals(ext.Name));
        }

        internal void MonitoringPropertyExists(string CheckMessage, string PropertyName, JObject Properties, AEMTestResult parentResult, bool expectedResult = true)
        {
            bool result = false;

            WriteHost(CheckMessage + "...", false);
            if (Properties != null && Properties["cfg"] != null)
            {
                var set = Properties["cfg"].FirstOrDefault((tok) =>
                {
                    JValue jval = (tok["key"] as JValue);
                    if (jval != null && jval.Value != null)
                    {
                        return jval.Value.Equals(PropertyName);
                    }

                    return false;
                });

                if (set != null && set["value"] != null && (set["value"] as JValue) != null)
                {
                    result = true;

                }
            }

            if (result == expectedResult)
            {
                parentResult.PartialResults.Add(new AEMTestResult(CheckMessage, true));
                WriteHost("OK ", ConsoleColor.Green);
            }
            else
            {
                parentResult.PartialResults.Add(new AEMTestResult(CheckMessage, false));
                WriteHost("NOT OK ", ConsoleColor.Red);
            }
        }

        internal void CheckMonitoringProperty<T>(string CheckMessage, string PropertyName, JObject Properties, T expectedValue, AEMTestResult parentResult)
        {
            WriteHost(CheckMessage + "...", false);

            T value;
            if (GetMonPropertyValue<T>(PropertyName, Properties, out value))
            {
                if (value != null && value.Equals(expectedValue))
                {
                    parentResult.PartialResults.Add(new AEMTestResult(CheckMessage, true));
                    WriteHost("OK ", ConsoleColor.Green);
                }
                else
                {
                    parentResult.PartialResults.Add(new AEMTestResult(CheckMessage, false));
                    WriteHost("NOT OK ", ConsoleColor.Red);
                }
            }
            else
            {
                parentResult.PartialResults.Add(new AEMTestResult(CheckMessage, false));
                WriteHost("NOT OK ", ConsoleColor.Red);
            }
        }

        internal bool GetMonPropertyValue<T>(string PropertyName, JObject Properties, out T result)
        {
            result = default(T);

            if (Properties == null || Properties["cfg"] == null)
            {
                return false;
            }

            var set = Properties["cfg"].FirstOrDefault((tok) =>
            {
                JValue jvaltok = (tok["key"] as JValue);
                if (jvaltok != null && jvaltok.Value != null)
                {
                    return jvaltok.Value.Equals(PropertyName);
                }

                return false;
            });

            if (set == null || set["value"] == null)
            {
                return false;
            }

            JValue jval = (set["value"] as JValue);
            if (jval != null && jval.Value != null)
            {
                result = (set["value"] as JValue).Value<T>();
                return true;
            }

            return false;
        }

        internal bool CheckWADConfiguration(System.Xml.XmlDocument CurrentConfig)
        {
            if ((CurrentConfig == null)
            || (CurrentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration") == null)
            || (int.Parse(CurrentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/@overallQuotaInMB").Value) < 4096)
            || (CurrentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters") == null)
            || (!CurrentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters/@scheduledTransferPeriod").
                    Value.Equals("PT1M", StringComparison.InvariantCultureIgnoreCase))
            || (CurrentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters/PerformanceCounterConfiguration") == null))
            {
                return false;
            }

            return true;
        }

        internal ServiceProperties GetStorageAnalytics(string storageAccountName)
        {
            var key = this.GetAzureStorageKeyFromCache(storageAccountName);
            var credentials = new StorageCredentials(storageAccountName, key);
            var cloudStorageAccount = new CloudStorageAccount(credentials, true);
            return cloudStorageAccount.CreateCloudBlobClient().GetServicePropertiesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        internal bool CheckStorageAnalytics(string storageAccountName, ServiceProperties currentConfig)
        {
            if ((currentConfig == null)
                || (currentConfig.Logging == null)
                || ((currentConfig.Logging.LoggingOperations & LoggingOperations.All) != LoggingOperations.All)
                || (currentConfig.MinuteMetrics == null)
                || (currentConfig.MinuteMetrics.MetricsLevel <= 0)
                || (currentConfig.MinuteMetrics.RetentionDays < 0))
            {
                WriteVerbose("Storage account {0} does not have the required metrics enabled", storageAccountName);
                return false;
            }

            WriteVerbose("Storage account {0} has required metrics enabled", storageAccountName);
            return true;
        }

        internal bool CheckTableAndContent(string StorageAccountName, string TableName, string FilterString, string WaitChar, bool UseNewTableNames, int TimeoutinMinutes = 15)
        {
            var tableExists = false;
            StorageAccount account = null;
            if (!String.IsNullOrEmpty(StorageAccountName))
            {
                account = this.GetStorageAccountFromCache(StorageAccountName);
            }
            if (account != null)
            {
                var endpoint = this.GetCoreEndpoint(StorageAccountName);
                var key = this.GetAzureStorageKeyFromCache(StorageAccountName);
                var credentials = new StorageCredentials(StorageAccountName, key);
                var cloudStorageAccount = new CloudStorageAccount(credentials, endpoint, true);
                var tableClient = cloudStorageAccount.CreateCloudTableClient();
                var checkStart = DateTime.Now;
                var wait = true;
                CloudTable table = null;
                if (UseNewTableNames)
                {
                    try
                    {
                        table = tableClient.ListTablesSegmentedAsync(currentToken: null)
                            .ConfigureAwait(false).GetAwaiter().GetResult()
                            .FirstOrDefault(tab => tab.Name.StartsWith("WADMetricsPT1M"));
                    }
                    catch { } //#table name should be sorted 
                }
                else
                {
                    try
                    {
                        table = tableClient.GetTableReference(TableName);
                    }
                    catch { }
                }

                while (wait)
                {
                    if (table != null && table.ExistsAsync().ConfigureAwait(false).GetAwaiter().GetResult())
                    {
                        TableQuery query = new TableQuery();
                        query.FilterString = FilterString;
                        var results = table.ExecuteQuerySegmentedAsync(query, token: null)
                            .ConfigureAwait(false).GetAwaiter().GetResult();
                        if (results.Count() > 0)
                        {
                            tableExists = true;
                            break;
                        }
                    }

                    WriteHost(WaitChar, newLine: false);
                    TestMockSupport.Delay(5000);
                    if (UseNewTableNames)
                    {
                        try
                        {
                            table = tableClient.ListTablesSegmentedAsync(currentToken: null)
                                .ConfigureAwait(false).GetAwaiter().GetResult().FirstOrDefault(tab => tab.Name.StartsWith("WADMetricsPT1M"));
                        }
                        catch { } //#table name should be sorted 
                    }
                    else
                    {
                        try
                        {
                            table = tableClient.GetTableReference(TableName);
                        }
                        catch { }
                    }

                    wait = ((DateTime.Now) - checkStart).TotalMinutes < TimeoutinMinutes;
                }
            }
            return tableExists;
        }

        internal bool CheckDiagnosticsTable(string storageAccountName, string resId, string host, string waitChar, string osType, int TimeoutinMinutes = 15)
        {
            var tableExists = true;
            StorageAccount account = null;
            if (!String.IsNullOrEmpty(storageAccountName))
            {
                account = this.GetStorageAccountFromCache(storageAccountName);
            }
            if (account != null)
            {
                var endpoint = this.GetCoreEndpoint(storageAccountName);
                var key = this.GetAzureStorageKeyFromCache(storageAccountName);
                var credentials = new StorageCredentials(storageAccountName, key);
                var cloudStorageAccount = new CloudStorageAccount(credentials, endpoint, true);
                var tableClient = cloudStorageAccount.CreateCloudTableClient();
                var checkStart = DateTime.Now;
                var searchTime = DateTime.UtcNow.AddMinutes(-5);

                foreach (var tableName in AEMExtensionConstants.WADTablesV2[osType])
                {
                    var query = TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("DeploymentId", QueryComparisons.Equal, resId),
                        TableOperators.And,
                        TableQuery.CombineFilters(
                            TableQuery.GenerateFilterCondition("Host", QueryComparisons.Equal, host),
                            TableOperators.And,
                            TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, searchTime)));


                    var perfCounterTable = tableClient.GetTableReference(tableName);

                    bool wait = true;
                    while (wait)
                    {
                        var results = perfCounterTable.ExecuteQuerySegmentedAsync(new TableQuery() { FilterString = query }, token: null)
                            .ConfigureAwait(false).GetAwaiter().GetResult();
                        if (results.Count() > 0)
                        {
                            tableExists &= true;
                            break;
                        }
                        else
                        {
                            WriteHost(waitChar, newLine: false);
                            TestMockSupport.Delay(5000);
                        }
                        wait = ((DateTime.Now) - checkStart).TotalMinutes < TimeoutinMinutes;
                    }
                    if (!wait)
                    {
                        WriteVerbose("PerfCounter Table " + tableName + " not found");
                        tableExists = false;
                        break;
                    }
                }
            }
            return tableExists;
        }
    }
}