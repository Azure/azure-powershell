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

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Extension.AEM;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineAEMExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureRmVMAEMExtension : VirtualMachineExtensionBaseCmdlet
    {
        private AEMHelper _Helper = null;

        [Parameter(
                Mandatory = true,
                Position = 0,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 2,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "If this parameter is provided, the commandlet will not enable Windows Azure Diagnostics for this virtual machine.")]
        public SwitchParameter DisableWAD { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 3,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Name of the storage account that should be used to store analytics data.")]
        public string WADStorageAccountName { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 4,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Operating System Type of the virtual machines. Possible values: Windows | Linux")]
        public string OSType { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 5,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Disables the settings for table content")]
        public SwitchParameter SkipStorage { get; set; }

        public SetAzureRmVMAEMExtension()
        {
        }

        public override void ExecuteCmdlet()
        {
            this._Helper = new AEMHelper((err) => this.WriteError(err), (msg) => this.WriteVerbose(msg), (msg) => this.WriteWarning(msg),
                this.CommandRuntime.Host.UI, AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager), this.DefaultContext.Subscription);

            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this._Helper.WriteVerbose("Retrieving VM...");

                var selectedVM = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                var selectedVMStatus = ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(this.ResourceGroupName, this.VMName).Body.InstanceView;

                if (selectedVM == null)
                {
                    var subscriptionId = this.DefaultContext.Subscription.Id;
                    this._Helper.WriteError("No virtual machine with name {0} in resource group {1} in subscription {2} found", this.VMName, this.ResourceGroupName, subscriptionId);
                    return;
                }

                var osdisk = selectedVM.StorageProfile.OsDisk;

                if (String.IsNullOrEmpty(this.OSType))
                {
                    this.OSType = osdisk.OsType.ToString();
                }
                if (String.IsNullOrEmpty(this.OSType))
                {
                    this._Helper.WriteError("Could not determine Operating System of the VM. Please provide the Operating System type ({0} or {1}) via parameter OSType",
                        AEMExtensionConstants.OSTypeWindows, AEMExtensionConstants.OSTypeLinux);
                    return;
                }

                var disks = selectedVM.StorageProfile.DataDisks;

                var sapmonPublicConfig = new List<KeyValuePair>();
                var sapmonPrivateConfig = new List<KeyValuePair>();
                var cpuOvercommit = 0;
                var memOvercommit = 0;
                var vmsize = selectedVM.HardwareProfile.VmSize;
                switch (vmsize)
                {
                    case AEMExtensionConstants.VMSizeExtraSmall:
                    case AEMExtensionConstants.VMSizeStandard_A0:
                    case AEMExtensionConstants.VMSizeBasic_A0:
                        vmsize = "ExtraSmall (A0)";
                        WriteVerbose("VM Size is ExtraSmall - setting overcommitted setting");
                        cpuOvercommit = 1;
                        break;
                    case "Small":
                        vmsize = "Small (A1)";
                        break;
                    case "Medium":
                        vmsize = "Medium (A2)";
                        break;
                    case "Large":
                        vmsize = "Large (A3)";
                        break;
                    case "ExtraLarge":
                        vmsize = "ExtraLarge (A4)";
                        break;
                }
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "vmsize", Value = vmsize });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "vm.role", Value = "IaaS" });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "vm.memory.isovercommitted", Value = memOvercommit });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "vm.cpu.isovercommitted", Value = cpuOvercommit });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "script.version", Value = AEMExtensionConstants.CurrentScriptVersion });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "verbose", Value = "0" });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "href", Value = "http://aka.ms/sapaem" });

                var vmSLA = this._Helper.GetVMSLA(selectedVM);
                if (vmSLA.HasSLA)
                {
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "vm.sla.throughput", Value = vmSLA.TP });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "vm.sla.iops", Value = vmSLA.IOPS });
                }

                // Get Disks
                var accounts = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                var accountName = this._Helper.GetStorageAccountFromUri(osdisk.Vhd.Uri);
                var storageKey = this._Helper.GetAzureStorageKeyFromCache(accountName);
                accounts.Add(accountName, storageKey);

                this._Helper.WriteHost("[INFO] Adding configuration for OS disk");

                var caching = osdisk.Caching;
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.name", Value = this._Helper.GetDiskName(osdisk.Vhd.Uri) });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.caching", Value = caching });
                sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.account", Value = accountName });
                if (this._Helper.IsPremiumStorageAccount(accountName))
                {
                    WriteVerbose("OS Disk Storage Account is a premium account - adding SLAs for OS disk");
                    var sla = this._Helper.GetDiskSLA(osdisk);
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.type", Value = AEMExtensionConstants.DISK_TYPE_PREMIUM });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.sla.throughput", Value = sla.TP });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.sla.iops", Value = sla.IOPS });
                }
                else
                {
                    WriteVerbose("OS Disk Storage Account is a standard account");
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.type", Value = AEMExtensionConstants.DISK_TYPE_STANDARD });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.connminute", Value = (accountName + ".minute") });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "osdisk.connhour", Value = (accountName + ".hour") });
                }

                // Get Storage accounts from disks
                var diskNumber = 1;
                foreach (var disk in disks)
                {
                    accountName = this._Helper.GetStorageAccountFromUri(disk.Vhd.Uri);
                    if (!accounts.ContainsKey(accountName))
                    {
                        storageKey = this._Helper.GetAzureStorageKeyFromCache(accountName);
                        accounts.Add(accountName, storageKey);
                    }

                    this._Helper.WriteHost("[INFO] Adding configuration for data disk {0}", disk.Name);
                    caching = disk.Caching;
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.lun." + diskNumber, Value = disk.Lun });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.name." + diskNumber, Value = this._Helper.GetDiskName(disk.Vhd.Uri) });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.caching." + diskNumber, Value = caching });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.account." + diskNumber, Value = accountName });

                    if (this._Helper.IsPremiumStorageAccount(accountName))
                    {
                        this._Helper.WriteVerbose("Data Disk {0} Storage Account is a premium account - adding SLAs for disk", diskNumber.ToString());
                        var sla = this._Helper.GetDiskSLA(disk);
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.type." + diskNumber, Value = AEMExtensionConstants.DISK_TYPE_PREMIUM });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.sla.throughput." + diskNumber, Value = sla.TP });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.sla.iops." + diskNumber, Value = sla.IOPS });
                        this._Helper.WriteVerbose("Done - Data Disk {0} Storage Account is a premium account - adding SLAs for disk", diskNumber.ToString());

                    }
                    else
                    {
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.type." + diskNumber, Value = AEMExtensionConstants.DISK_TYPE_STANDARD });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.connminute." + diskNumber, Value = (accountName + ".minute") });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = "disk.connhour." + diskNumber, Value = (accountName + ".hour") });
                    }

                    diskNumber += 1;
                }

                //Check storage accounts for analytics
                foreach (var account in accounts)
                {
                    this._Helper.WriteVerbose("Testing Storage Metrics for {0}", account.Key);

                    var storage = this._Helper.GetStorageAccountFromCache(account.Key);

                    if (!this._Helper.IsPremiumStorageAccount(storage))
                    {
                        if (!this.SkipStorage.IsPresent)
                        {
                            var currentConfig = this._Helper.GetStorageAnalytics(storage.Name);

                            if (!this._Helper.CheckStorageAnalytics(storage.Name, currentConfig))
                            {
                                this._Helper.WriteHost("[INFO] Enabling Storage Account Metrics for storage account {0}", storage.Name);

                                // Enable analytics on storage accounts
                                this.SetStorageAnalytics(storage.Name);
                            }
                        }

                        var endpoint = this._Helper.GetAzureSAPTableEndpoint(storage);
                        var hourUri = endpoint + "$MetricsHourPrimaryTransactionsBlob";
                        var minuteUri = endpoint + "$MetricsMinutePrimaryTransactionsBlob";

                        this._Helper.WriteHost("[INFO] Adding Storage Account Metric information for storage account {0}", storage.Name);

                        sapmonPrivateConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".hour.key"), Value = account.Value });
                        sapmonPrivateConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".minute.key"), Value = account.Value });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".hour.uri"), Value = hourUri });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".minute.uri"), Value = minuteUri });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".hour.name"), Value = storage.Name });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".minute.name"), Value = storage.Name });
                    }
                    else
                    {
                        this._Helper.WriteHost("[INFO] {0} is of type {1} - Storage Account Metrics are not available for Premium Type Storage.", storage.Name, storage.AccountType.Value.ToString());
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".hour.ispremium"), Value = 1 });
                        sapmonPublicConfig.Add(new KeyValuePair() { Key = ((storage.Name) + ".minute.ispremium"), Value = 1 });
                    }
                }

                WriteVerbose("Chechking if WAD needs to be configured");
                // Enable VM Diagnostics
                if (!this.DisableWAD.IsPresent)
                {
                    this._Helper.WriteHost("[INFO] Enabling IaaSDiagnostics for VM {0}", selectedVM.Name);
                    KeyValuePair wadstorage = null;
                    if (String.IsNullOrEmpty(this.WADStorageAccountName))
                    {
                        KeyValuePair<string, string>? wadstorageTemp = accounts.Cast<KeyValuePair<string, string>?>().
                            FirstOrDefault(accTemp => !this._Helper.IsPremiumStorageAccount(accTemp.Value.Key));
                        if (wadstorageTemp.HasValue)
                        {
                            wadstorage = new KeyValuePair(wadstorageTemp.Value.Key, wadstorageTemp.Value.Value);
                        }
                    }
                    else
                    {
                        wadstorage = new KeyValuePair(this.WADStorageAccountName, this._Helper.GetAzureStorageKeyFromCache(WADStorageAccountName));
                    }

                    if (wadstorage == null)
                    {
                        this._Helper.WriteError("A Standard Storage Account is required.");
                        return;
                    }

                    selectedVM = SetAzureVMDiagnosticsExtensionC(selectedVM, selectedVMStatus, wadstorage.Key, wadstorage.Value as string);

                    var storage = this._Helper.GetStorageAccountFromCache(wadstorage.Key);
                    var endpoint = this._Helper.GetAzureSAPTableEndpoint(storage);
                    var wadUri = endpoint + AEMExtensionConstants.WadTableName;

                    sapmonPrivateConfig.Add(new KeyValuePair() { Key = "wad.key", Value = wadstorage.Value });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "wad.name", Value = wadstorage.Key });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "wad.isenabled", Value = 1 });
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "wad.uri", Value = wadUri });
                }
                else
                {
                    sapmonPublicConfig.Add(new KeyValuePair() { Key = "wad.isenabled", Value = 0 });
                }

                ExtensionConfig jsonPublicConfig = new ExtensionConfig();
                jsonPublicConfig.Config = sapmonPublicConfig;

                ExtensionConfig jsonPrivateConfig = new ExtensionConfig();
                jsonPrivateConfig.Config = sapmonPrivateConfig;

                this._Helper.WriteHost("[INFO] Updating Azure Enhanced Monitoring Extension for SAP configuration - Please wait...");

                WriteVerbose("Installing AEM extension");

                Version aemVersion = this._Helper.GetExtensionVersion(selectedVM, selectedVMStatus, OSType, AEMExtensionConstants.AEMExtensionType[OSType], AEMExtensionConstants.AEMExtensionPublisher[OSType]);

                var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName, this.VMName, AEMExtensionConstants.AEMExtensionDefaultName[OSType],
                    new VirtualMachineExtension()
                    {
                        Publisher = AEMExtensionConstants.AEMExtensionPublisher[OSType],
                        VirtualMachineExtensionType = AEMExtensionConstants.AEMExtensionType[OSType],
                        TypeHandlerVersion = aemVersion.ToString(2),
                        Settings = jsonPublicConfig,
                        ProtectedSettings = jsonPrivateConfig,
                        Location = selectedVM.Location,
                        AutoUpgradeMinorVersion = true,
                        ForceUpdateTag = DateTime.Now.Ticks.ToString()
                    }).GetAwaiter().GetResult();

                this._Helper.WriteHost("[INFO] Azure Enhanced Monitoring Extension for SAP configuration updated. It can take up to 15 Minutes for the monitoring data to appear in the SAP system.");
                this._Helper.WriteHost("[INFO] You can check the configuration of a virtual machine by calling the Test-AzureRmVMAEMExtension commandlet.");

                var result = Mapper.Map<PSAzureOperationResponse>(op);
                WriteObject(result);
            });
        }

        private VirtualMachine SetAzureVMDiagnosticsExtensionC(VirtualMachine vm, VirtualMachineInstanceView vmStatus, string storageAccountName, string storageAccountKey)
        {
            System.Xml.XmlDocument xpublicConfig = null;

            var extensionName = AEMExtensionConstants.WADExtensionDefaultName[this.OSType];

            var extTemp = this._Helper.GetExtension(vm,
                AEMExtensionConstants.WADExtensionType[this.OSType], AEMExtensionConstants.WADExtensionPublisher[OSType]);
            object publicConf = null;
            if (extTemp != null)
            {
                publicConf = extTemp.Settings;
                extensionName = extTemp.Name;
            }

            if (publicConf != null)
            {
                var jpublicConf = publicConf as Newtonsoft.Json.Linq.JObject;
                if (jpublicConf == null)
                {
                    throw new ArgumentException();
                }

                var base64 = jpublicConf["xmlCfg"] as Newtonsoft.Json.Linq.JValue;
                if (base64 == null)
                {
                    throw new ArgumentException();
                }

                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                xDoc.LoadXml(Encoding.UTF8.GetString(System.Convert.FromBase64String(base64.Value.ToString())));

                if (xDoc.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters") != null)
                {
                    xDoc.SelectSingleNode("WadCfg/DiagnosticMonitorConfiguration").Attributes["overallQuotaInMB"].Value = "4096";
                    xDoc.SelectSingleNode("WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters").Attributes["scheduledTransferPeriod"].Value = "PT1M";

                    xpublicConfig = xDoc;
                }
            }

            if (xpublicConfig == null)
            {
                xpublicConfig = new System.Xml.XmlDocument();
                xpublicConfig.LoadXml(AEMExtensionConstants.WADConfigXML);
            }

            foreach (var perfCounter in AEMExtensionConstants.PerformanceCounters[OSType])
            {
                var currentCounter = xpublicConfig.
                            SelectSingleNode("WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters/PerformanceCounterConfiguration[@counterSpecifier = '" + perfCounter.counterSpecifier + "']");
                if (currentCounter == null)
                {
                    var node = xpublicConfig.CreateElement("PerformanceCounterConfiguration");
                    xpublicConfig.SelectSingleNode("WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters").AppendChild(node);
                    node.SetAttribute("counterSpecifier", perfCounter.counterSpecifier);
                    node.SetAttribute("sampleRate", perfCounter.sampleRate);
                }
            }

            var endpoint = this._Helper.GetCoreEndpoint(storageAccountName);
            endpoint = "https://" + endpoint;

            Newtonsoft.Json.Linq.JObject jPublicConfig = new Newtonsoft.Json.Linq.JObject();
            jPublicConfig.Add("xmlCfg", new Newtonsoft.Json.Linq.JValue(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xpublicConfig.InnerXml))));

            Newtonsoft.Json.Linq.JObject jPrivateConfig = new Newtonsoft.Json.Linq.JObject();
            jPrivateConfig.Add("storageAccountName", new Newtonsoft.Json.Linq.JValue(storageAccountName));
            jPrivateConfig.Add("storageAccountKey", new Newtonsoft.Json.Linq.JValue(storageAccountKey));
            jPrivateConfig.Add("storageAccountEndPoint", new Newtonsoft.Json.Linq.JValue(endpoint));

            WriteVerbose("Installing WAD extension");

            Version wadVersion = this._Helper.GetExtensionVersion(vm, vmStatus, OSType,
                AEMExtensionConstants.WADExtensionType[this.OSType], AEMExtensionConstants.WADExtensionPublisher[this.OSType]);

            VirtualMachineExtension vmExtParameters = new VirtualMachineExtension();

            vmExtParameters.Publisher = AEMExtensionConstants.WADExtensionPublisher[this.OSType];
            vmExtParameters.VirtualMachineExtensionType = AEMExtensionConstants.WADExtensionType[this.OSType];
            vmExtParameters.TypeHandlerVersion = wadVersion.ToString(2);
            vmExtParameters.Settings = jPublicConfig;
            vmExtParameters.ProtectedSettings = jPrivateConfig;
            vmExtParameters.Location = vm.Location;
            vmExtParameters.AutoUpgradeMinorVersion = true;
            vmExtParameters.ForceUpdateTag = DateTime.Now.Ticks.ToString();

            this.VirtualMachineExtensionClient.CreateOrUpdate(ResourceGroupName, vm.Name, extensionName, vmExtParameters);

            return this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(ResourceGroupName, vm.Name);
        }

        private void SetStorageAnalytics(string storageAccountName)
        {
            ServiceProperties props = this._Helper.GetStorageAnalytics(storageAccountName);

            int retentionDays = 13;

            if (props.Logging == null)
            {
                props.Logging = new LoggingProperties();
            }
            props.Logging.LoggingOperations = LoggingOperations.All;
            props.Logging.RetentionDays = retentionDays;

            if (props.MinuteMetrics == null)
            {
                props.MinuteMetrics = new MetricsProperties();
            }
            props.MinuteMetrics.RetentionDays = retentionDays;
            props.MinuteMetrics.MetricsLevel = MetricsLevel.ServiceAndApi;

            if (props.HourMetrics != null && props.HourMetrics.RetentionDays != null)
            {
                props.HourMetrics.RetentionDays = retentionDays;
            }

            var key = this._Helper.GetAzureStorageKeyFromCache(storageAccountName);
            var credentials = new StorageCredentials(storageAccountName, key);
            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            cloudStorageAccount.CreateCloudBlobClient().SetServiceProperties(props);
        }
    }
}