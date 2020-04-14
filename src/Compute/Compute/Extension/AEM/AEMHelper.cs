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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.Storage.Version2017_10_01.Models;
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
using System.Security.Cryptography;
using System.Text;
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
        private string _StorageEndpoint;

        public AEMHelper(Action<ErrorRecord> errorAction, Action<string> verboseAction, Action<string> warningAction,
            PSHostUserInterface ui, StorageManagementClient storageClient, IAzureSubscription subscription, String storageEndpoint)
        {
            this._ErrorAction = errorAction;
            this._VerboseAction = verboseAction;
            this._WarningAction = warningAction;
            this._UI = ui;
            this._StorageClient = storageClient;
            this._Subscription = subscription;
            this._StorageEndpoint = storageEndpoint;
        }

        internal static VirtualMachineExtension GetAEMExtension(VirtualMachine virtualMachine, string osType)
        {
            var aemExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisher[osType], 
                                    StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionType[osType], 
                                    StringComparison.InvariantCultureIgnoreCase))
                            : null;

            var aemExtensionv2 = virtualMachine.Resources != null
                    ? virtualMachine.Resources.FirstOrDefault(extension =>
                        extension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisherv2[osType], 
                            StringComparison.InvariantCultureIgnoreCase) &&
                        extension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionTypev2[osType], 
                            StringComparison.InvariantCultureIgnoreCase))
                    : null;

            return aemExtension != null ? aemExtension : aemExtensionv2;
        }

        internal static VirtualMachineExtension GetWADExtension(VirtualMachine virtualMachine, string osType)
        {
            var aemExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(AEMExtensionConstants.WADExtensionPublisher[osType],
                                    StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.WADExtensionType[osType],
                                    StringComparison.InvariantCultureIgnoreCase))
                            : null;

            return aemExtension;
        }
        internal static VirtualMachineExtensionInstanceView GetAEMExtensionStatus(VirtualMachine virtualMachine, VirtualMachineInstanceView vmStatus, string osType)
        {
            var aemExtension = GetAEMExtension(virtualMachine, osType);
            if (aemExtension == null)
            {
                return null;
            }

            if (vmStatus.Extensions == null)
            {
                return null;
            }
            return vmStatus.Extensions.FirstOrDefault(extSt => extSt.Name.Equals(aemExtension.Name));
        }

        public static bool CheckScopePermissions(bool? groupOK, bool? resourceOK,
            string scopeResourceGroup, string scopeResource, string roleDefinitionId, VirtualMachine vm,
            HashSet<string> testedScopeOK, HashSet<string> testedScopeNOK,
            Func<string, string, VirtualMachine, bool> scopeCheck)
        {
            bool checkOk = false;

            // | Permissions for RG | Permission for Resource | Result                                         | Checked with |
            // |         Y          |           Y             |   Y                                            | 1
            // |         Y          |           N             |   Y                                            | 1
            // |         Y          |           ?             |   Y                                            | 1
            // |         N          |           Y             |   Y                                            | 1
            // |         N          |           N             |   N                                            | 2
            // |         N          |           ?             | check resource                                 | 4
            // |         ?          |           Y             |   Y                                            | 1
            // |         ?          |           N             | check resource group                           | 3
            // |         ?          |           ?             | check resource group, if no, check resource    | 3 and 4

            if (groupOK == true || resourceOK == true) // 1
            {
                checkOk = true;
            }
            else if (groupOK == false && resourceOK == false) //2
            {
                checkOk = false;
            }

            if (!checkOk && groupOK == null) //3
            {
                var result = scopeCheck(scopeResourceGroup, roleDefinitionId, vm);
                if (result)
                {
                    checkOk = true;
                    testedScopeOK.Add(scopeResourceGroup);
                }
                else
                {
                    testedScopeNOK.Add(scopeResourceGroup);
                }
            }

            if (!checkOk && resourceOK == null) //4
            {
                var result = scopeCheck(scopeResource, roleDefinitionId, vm);
                if (result)
                {
                    checkOk = true;
                    testedScopeOK.Add(scopeResource);
                }
                else
                {
                    testedScopeNOK.Add(scopeResource);
                }
            }

            return checkOk;
        }

        internal static bool IsOldExtension(VirtualMachineExtension aemExtension, string osType)
        {
            return aemExtension != null 
                && aemExtension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisher[osType],
                                    StringComparison.InvariantCultureIgnoreCase)
                && aemExtension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionType[osType],
                                    StringComparison.InvariantCultureIgnoreCase);
        }
        internal static bool IsNewExtension(VirtualMachineExtension aemExtension, string osType)
        {
            return aemExtension != null
                && aemExtension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisherv2[osType],
                                    StringComparison.InvariantCultureIgnoreCase)
                && aemExtension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionTypev2[osType],
                                    StringComparison.InvariantCultureIgnoreCase);
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

                    var resGroupName = new ResourceIdentifier(account.Id).ResourceGroupName;
                    StorageCredentialsFactory storageCredentialsFactory = new StorageCredentialsFactory(resGroupName,
                        this._StorageClient, this._Subscription);
                    StorageCredentials sc = storageCredentialsFactory.Create(blobUri);
                    CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(sc,  this._StorageEndpoint, true);
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
                case "Standard_D2s_v3":
                case "Standard_E2s_v3":
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
                case "Standard_D4s_v3":
                case "Standard_E4s_v3":
                case "Standard_E4-2s_v3":
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
                case "Standard_D8s_v3":
                case "Standard_E8s_v3":
                case "Standard_E8-2s_v3":
                case "Standard_E8-4s_v3":
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
                case "Standard_D16s_v3":
                case "Standard_E16s_v3":
                case "Standard_E16-4s_v3":
                case "Standard_E16-8s_v3":
                    result.HasSLA = true;
                    result.IOPS = 25600;
                    result.TP = 384;
                    break;
                case "Standard_DS5_v2":
                case "Standard_D32s_v3":
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
                case "Standard_E32s_v3":
                case "Standard_E32-8s_v3":
                case "Standard_E32-16s_v3":
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
                case "Standard_M8-2ms":
                case "Standard_M8-4ms":
                case "Standard_M8ms":
                    result.HasSLA = true;
                    result.IOPS = 5000;
                    result.TP = 125;
                    break;
                case "Standard_M16-4ms":
                case "Standard_M16-8ms":
                case "Standard_M16ms":
                    result.HasSLA = true;
                    result.IOPS = 10000;
                    result.TP = 250;
                    break;
                case "Standard_M32-8ms":
                case "Standard_M32-16ms":
                case "Standard_M32ms":
                case "Standard_M32ls":
                case "Standard_M32ts":
                    result.HasSLA = true;
                    result.IOPS = 20000;
                    result.TP = 500;
                    break;
                case "Standard_M64ms":
                case "Standard_M64s":
                case "Standard_M64ls":
                case "Standard_M64-16ms":
                case "Standard_M64-32ms":
                    result.HasSLA = true;
                    result.IOPS = 40000;
                    result.TP = 1000;
                    break;
                case "Standard_M128s":
                case "Standard_M128ms":
                case "Standard_M128-32ms":
                case "Standard_M128-64ms":
                    result.HasSLA = true;
                    result.IOPS = 80000;
                    result.TP = 2000;
                    break;
                case "Standard_E64s_v3":
                case "Standard_D64s_v3":
                case "Standard_E64-16s_v3":
                case "Standard_E64-32s_v3":
                case "Standard_E64is_v3":
                    result.HasSLA = true;
                    result.IOPS = 80000;
                    result.TP = 1200;
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
            var resourceGroup = new ResourceIdentifier(account.Id).ResourceGroupName;
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
                sla.TP = 25;
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
            else if (diskSize > 0 && diskSize <= (4 * 1024))
            {
                // P50
                sla.IOPS = 7500;
                sla.TP = 250;
            }
            else if (diskSize > 0 && diskSize <= (8 * 1024))
            {
                // P60
                sla.IOPS = 12500;
                sla.TP = 480;
            }
            else if (diskSize > 0 && diskSize <= (16 * 1024))
            {
                // P70
                sla.IOPS = 15000;
                sla.TP = 750;
            }
            else if (diskSize > 0 && diskSize <= (32 * 1024))
            {
                // P80
                sla.IOPS = 20000;
                sla.TP = 750;
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
            var cloudStorageAccount = new CloudStorageAccount(credentials, this._StorageEndpoint, true);
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

        /// <summary>
        /// https://stackoverflow.com/a/41622689
        /// Generates Guid based on String. Key assumption for this algorithm is that name is unique (across where it it's being used)
        /// and if name byte length is less than 16 - it will be fetched directly into guid, if over 16 bytes - then we compute sha-1
        /// hash from string and then pass it to guid.
        /// </summary>
        /// <param name="name">Unique name which is unique across where this guid will be used.</param>
        /// <returns>For example "{706C7567-696E-7300-0000-000000000000}" for "plugins"</returns>
        static public String GenerateGuid(String name)
        {
            byte[] buf = Encoding.UTF8.GetBytes(name);
            byte[] guid = new byte[16];
            if (buf.Length < 16)
            {
                Array.Copy(buf, guid, buf.Length);
            }
            else
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash = sha1.ComputeHash(buf);
                    // Hash is 20 bytes, but we need 16. We loose some of "uniqueness", but I doubt it will be fatal
                    Array.Copy(hash, guid, 16);
                }
            }

            // Don't use Guid constructor, it tends to swap bytes. We want to preserve original string as hex dump.
            String guidS = String.Format("{0:X2}{1:X2}{2:X2}{3:X2}-{4:X2}{5:X2}-{6:X2}{7:X2}-{8:X2}{9:X2}-{10:X2}{11:X2}{12:X2}{13:X2}{14:X2}{15:X2}",
                guid[0], guid[1], guid[2], guid[3], guid[4], guid[5], guid[6], guid[7], guid[8], guid[9], guid[10], guid[11], guid[12], guid[13], guid[14], guid[15]);

            return guidS;
        }
    }
}