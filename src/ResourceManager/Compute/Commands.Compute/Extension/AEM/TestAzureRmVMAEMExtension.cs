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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        "Test",
        ProfileNouns.VirtualMachineAEMExtension)]
    [OutputType(typeof(AEMTestResult))]
    public class TestAzureRmVMAEMExtension : VirtualMachineExtensionBaseCmdlet
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
                HelpMessage = "Operating System Type of the virtual machines. Possible values: Windows | Linux")]
        public string OSType { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 3,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Time that should be waited for the Strorage Metrics or Diagnostics data to be available in minutes. Default is 15 minutes")]
        public int WaitTimeInMinutes { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 4,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Disables the test for table content")]
        public SwitchParameter SkipStorageCheck { get; set; }

        public TestAzureRmVMAEMExtension()
        {
            this.WaitTimeInMinutes = 15;
        }

        public override void ExecuteCmdlet()
        {
            this._Helper = new AEMHelper((err) => this.WriteError(err), (msg) => this.WriteVerbose(msg), (msg) => this.WriteWarning(msg),
                this.CommandRuntime.Host.UI,
                AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager),
                this.DefaultContext.Subscription);

            this._Helper.WriteVerbose("Starting TestAzureRmVMAEMExtension");

            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                AEMTestResult rootResult = new AEMTestResult();
                rootResult.TestName = "Azure Enhanced Monitoring Test";

                //#################################################
                //# Check if VM exists
                //#################################################
                this._Helper.WriteHost("VM Existance check for {0} ...", false, this.VMName);
                var selectedVM = this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                var selectedVMStatus = this.ComputeClient.ComputeManagementClient.VirtualMachines.GetWithInstanceView(this.ResourceGroupName, this.VMName).Body.InstanceView;


                if (selectedVM == null)
                {
                    rootResult.PartialResults.Add(new AEMTestResult("VM Existance check for {0}", false, this.VMName));
                    this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                    return;
                }
                else
                {
                    rootResult.PartialResults.Add(new AEMTestResult("VM Existance check for {0}", true, this.VMName));
                    this._Helper.WriteHost("OK ", ConsoleColor.Green);

                }
                //#################################################    
                //#################################################
                var osdisk = selectedVM.StorageProfile.OsDisk;
                if (String.IsNullOrEmpty(this.OSType))
                {
                    this.OSType = osdisk.OsType.ToString();
                }
                if (String.IsNullOrEmpty(this.OSType))
                {
                    this._Helper.WriteError("Could not determine Operating System of the VM. Please provide the Operating System type ({0} or {1}) via parameter OSType", AEMExtensionConstants.OSTypeWindows, AEMExtensionConstants.OSTypeLinux);
                    return;
                }
                //#################################################
                //# Check for Guest Agent
                //#################################################
                this._Helper.WriteHost("VM Guest Agent check...", false);
                var vmAgentStatus = false;

                //# It is not possible to detect if VM Agent is installed on ARM
                vmAgentStatus = true;
                if (!vmAgentStatus)
                {
                    rootResult.PartialResults.Add(new AEMTestResult("VM Guest Agent check", false));
                    this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                    this._Helper.WriteWarning(AEMExtensionConstants.MissingGuestAgentWarning);
                    return;
                }
                else
                {
                    rootResult.PartialResults.Add(new AEMTestResult("VM Guest Agent check", true));
                    this._Helper.WriteHost("OK ", ConsoleColor.Green);
                }
                //#################################################    
                //#################################################


                //#################################################
                //# Check for Azure Enhanced Monitoring Extension for SAP
                //#################################################
                this._Helper.WriteHost("Azure Enhanced Monitoring Extension for SAP Installation check...", false);

                string monPublicConfig = null;
                var monExtension = this._Helper.GetExtension(selectedVM, AEMExtensionConstants.AEMExtensionType[this.OSType], AEMExtensionConstants.AEMExtensionPublisher[this.OSType]);
                if (monExtension != null)
                {
                    monPublicConfig = monExtension.Settings.ToString();
                }

                if (monExtension == null || String.IsNullOrEmpty(monPublicConfig))
                {
                    rootResult.PartialResults.Add(new AEMTestResult("Azure Enhanced Monitoring Extension for SAP Installation check", false));
                    this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                }
                else
                {
                    rootResult.PartialResults.Add(new AEMTestResult("Azure Enhanced Monitoring Extension for SAP Installation check", true));
                    this._Helper.WriteHost("OK ", ConsoleColor.Green);
                }
                //#################################################    
                //#################################################

                var accounts = new List<string>();
                //var osdisk = selectedVM.StorageProfile.OsDisk;

                var dataDisks = selectedVM.StorageProfile.DataDisks;
                var accountName = this._Helper.GetStorageAccountFromUri(osdisk.Vhd.Uri);
                var osaccountName = accountName;
                accounts.Add(accountName);
                foreach (var disk in dataDisks)
                {
                    accountName = this._Helper.GetStorageAccountFromUri(disk.Vhd.Uri);
                    if (!accounts.Contains(accountName))
                    {
                        accounts.Add(accountName);
                    }
                }

                //#################################################
                //# Check storage metrics
                //#################################################
                this._Helper.WriteHost("Storage Metrics check...");
                var metricsResult = new AEMTestResult("Storage Metrics check");
                rootResult.PartialResults.Add(metricsResult);
                if (!this.SkipStorageCheck.IsPresent)
                {
                    foreach (var account in accounts)
                    {
                        var accountResult = new AEMTestResult("Storage Metrics check for {0}", account);
                        metricsResult.PartialResults.Add(accountResult);

                        this._Helper.WriteHost("\tStorage Metrics check for {0}...", account);
                        var storage = this._Helper.GetStorageAccountFromCache(account);

                        if (!this._Helper.IsPremiumStorageAccount(storage))
                        {
                            this._Helper.WriteHost("\t\tStorage Metrics configuration check for {0}...", false, account);
                            var currentConfig = this._Helper.GetStorageAnalytics(account);

                            bool storageConfigOk = false;
                            if (!this._Helper.CheckStorageAnalytics(account, currentConfig))
                            {
                                accountResult.PartialResults.Add(new AEMTestResult("Storage Metrics configuration check for {0}", false, account));
                                this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);

                            }
                            else
                            {
                                accountResult.PartialResults.Add(new AEMTestResult("Storage Metrics configuration check for {0}", true, account));
                                this._Helper.WriteHost("OK ", ConsoleColor.Green);
                                storageConfigOk = true;
                            }

                            this._Helper.WriteHost("\t\tStorage Metrics data check for {0}...", false, account);
                            var filterMinute = Microsoft.WindowsAzure.Storage.Table.TableQuery.
                                GenerateFilterConditionForDate("Timestamp", "gt", DateTime.Now.AddMinutes(AEMExtensionConstants.ContentAgeInMinutes * -1));

                            if (storageConfigOk && this._Helper.CheckTableAndContent(account, "$MetricsMinutePrimaryTransactionsBlob", filterMinute, ".", false, this.WaitTimeInMinutes))

                            {
                                this._Helper.WriteHost("OK ", ConsoleColor.Green);
                                accountResult.PartialResults.Add(new AEMTestResult("Storage Metrics data check for {0}", true, account));
                            }
                            else
                            {
                                accountResult.PartialResults.Add(new AEMTestResult("Storage Metrics data check for {0}", false, account));
                                this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            accountResult.PartialResults.Add(new AEMTestResult("Storage Metrics not available for Premium Storage account {0}", true, account));
                            this._Helper.WriteHost("\t\tStorage Metrics not available for Premium Storage account {0}...", false, account);
                            this._Helper.WriteHost("OK ", ConsoleColor.Green);
                        }
                    }
                }
                else
                {
                    metricsResult.Result = true;
                    this._Helper.WriteHost("Skipped ", ConsoleColor.Yellow);
                }
                //################################################# 
                //#################################################    


                //#################################################
                //# Check Azure Enhanced Monitoring Extension for SAP Configuration
                //#################################################
                this._Helper.WriteHost("Azure Enhanced Monitoring Extension for SAP public configuration check...", false);
                var aemConfigResult = new AEMTestResult("Azure Enhanced Monitoring Extension for SAP public configuration check");
                rootResult.PartialResults.Add(aemConfigResult);

                JObject sapmonPublicConfig = null;
                if (monExtension != null)
                {
                    this._Helper.WriteHost(""); //New Line

                    sapmonPublicConfig = JsonConvert.DeserializeObject(monPublicConfig) as JObject;

                    var storage = this._Helper.GetStorageAccountFromCache(osaccountName);
                    var osaccountIsPremium = this._Helper.IsPremiumStorageAccount(osaccountName);

                    var vmSize = selectedVM.HardwareProfile.VmSize;
                    this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Size", "vmsize", sapmonPublicConfig, vmSize, aemConfigResult);
                    this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Memory", "vm.memory.isovercommitted", sapmonPublicConfig, 0, aemConfigResult);
                    this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM CPU", "vm.cpu.isovercommitted", sapmonPublicConfig, 0, aemConfigResult);
                    this._Helper.MonitoringPropertyExists("Azure Enhanced Monitoring Extension for SAP public configuration check: Script Version", "script.version", sapmonPublicConfig, aemConfigResult);

                    var vmSLA = this._Helper.GetVMSLA(selectedVM);
                    if (vmSLA.HasSLA)
                    {
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM SLA IOPS", "vm.sla.iops", sapmonPublicConfig, vmSLA.IOPS, aemConfigResult);
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM SLA Throughput", "vm.sla.throughput", sapmonPublicConfig, vmSLA.TP, aemConfigResult);
                    }

                    int wadEnabled;
                    if (this._Helper.GetMonPropertyValue("wad.isenabled", sapmonPublicConfig, out wadEnabled))
                    {
                        if (wadEnabled == 1)
                        {
                            this._Helper.MonitoringPropertyExists("Azure Enhanced Monitoring Extension for SAP public configuration check: WAD name", "wad.name", sapmonPublicConfig, aemConfigResult);
                            this._Helper.MonitoringPropertyExists("Azure Enhanced Monitoring Extension for SAP public configuration check: WAD URI", "wad.uri", sapmonPublicConfig, aemConfigResult);
                        }
                        else
                        {
                            this._Helper.MonitoringPropertyExists("Azure Enhanced Monitoring Extension for SAP public configuration check: WAD name", "wad.name", sapmonPublicConfig, aemConfigResult, false);
                            this._Helper.MonitoringPropertyExists("Azure Enhanced Monitoring Extension for SAP public configuration check: WAD URI", "wad.uri", sapmonPublicConfig, aemConfigResult, false);
                        }
                    }
                    else
                    {
                        string message = "Azure Enhanced Monitoring Extension for SAP public configuration check:";
                        aemConfigResult.PartialResults.Add(new AEMTestResult(message, false));
                        this._Helper.WriteHost(message + "...", false);
                        this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                    }

                    if (!osaccountIsPremium)
                    {
                        var endpoint = this._Helper.GetAzureSAPTableEndpoint(storage);
                        var minuteUri = endpoint + "$MetricsMinutePrimaryTransactionsBlob";

                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS disk URI Key", "osdisk.connminute", sapmonPublicConfig, osaccountName + ".minute", aemConfigResult);
                        //# TODO: check uri config
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS disk URI Value", osaccountName + ".minute.uri", sapmonPublicConfig, minuteUri, aemConfigResult);
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS disk URI Name", osaccountName + ".minute.name", sapmonPublicConfig, osaccountName, aemConfigResult);
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS Disk Type", "osdisk.type", sapmonPublicConfig, AEMExtensionConstants.DISK_TYPE_STANDARD, aemConfigResult);

                    }
                    else
                    {
                        var sla = this._Helper.GetDiskSLA(osdisk);

                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS Disk Type", "osdisk.type", sapmonPublicConfig, AEMExtensionConstants.DISK_TYPE_PREMIUM, aemConfigResult);
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS Disk SLA IOPS", "osdisk.sla.throughput", sapmonPublicConfig, sla.TP, aemConfigResult);
                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS Disk SLA Throughput", "osdisk.sla.iops", sapmonPublicConfig, sla.IOPS, aemConfigResult);

                    }
                    this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM OS disk name", "osdisk.name", sapmonPublicConfig, this._Helper.GetDiskName(osdisk.Vhd.Uri), aemConfigResult);


                    var diskNumber = 1;
                    foreach (var disk in dataDisks)
                    {
                        accountName = this._Helper.GetStorageAccountFromUri(disk.Vhd.Uri);
                        storage = this._Helper.GetStorageAccountFromCache(accountName);
                        var accountIsPremium = this._Helper.IsPremiumStorageAccount(storage);

                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " LUN", "disk.lun." + diskNumber, sapmonPublicConfig, disk.Lun, aemConfigResult);
                        if (!accountIsPremium)
                        {
                            var endpoint = this._Helper.GetAzureSAPTableEndpoint(storage);
                            var minuteUri = endpoint + "$MetricsMinutePrimaryTransactionsBlob";

                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " URI Key", "disk.connminute." + diskNumber, sapmonPublicConfig, accountName + ".minute", aemConfigResult);
                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " URI Value", accountName + ".minute.uri", sapmonPublicConfig, minuteUri, aemConfigResult);
                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " URI Name", accountName + ".minute.name", sapmonPublicConfig, accountName, aemConfigResult);
                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " Type", "disk.type." + diskNumber, sapmonPublicConfig, AEMExtensionConstants.DISK_TYPE_STANDARD, aemConfigResult);

                        }
                        else
                        {
                            var sla = this._Helper.GetDiskSLA(disk);

                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " Type", "disk.type." + diskNumber, sapmonPublicConfig, AEMExtensionConstants.DISK_TYPE_PREMIUM, aemConfigResult);
                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " SLA IOPS", "disk.sla.throughput." + diskNumber, sapmonPublicConfig, sla.TP, aemConfigResult);
                            this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " SLA Throughput", "disk.sla.iops." + diskNumber, sapmonPublicConfig, sla.IOPS, aemConfigResult);
                        }

                        this._Helper.CheckMonitoringProperty("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disk " + diskNumber + " name", "disk.name." + diskNumber, sapmonPublicConfig, this._Helper.GetDiskName(disk.Vhd.Uri), aemConfigResult);

                        diskNumber += 1;
                    }
                    if (dataDisks.Count == 0)
                    {
                        aemConfigResult.PartialResults.Add(new AEMTestResult("Azure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disks", true));
                        this._Helper.WriteHost("\tAzure Enhanced Monitoring Extension for SAP public configuration check: VM Data Disks ", false);
                        this._Helper.WriteHost("OK ", ConsoleColor.Green);
                    }
                }
                else
                {
                    aemConfigResult.Result = false;
                    this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                }
                //################################################# 
                //#################################################    


                //#################################################
                //# Check WAD Configuration
                //#################################################
                int iswadEnabled;
                if (this._Helper.GetMonPropertyValue("wad.isenabled", sapmonPublicConfig, out iswadEnabled) && iswadEnabled == 1)
                {
                    var wadConfigResult = new AEMTestResult("IaaSDiagnostics check");
                    rootResult.PartialResults.Add(wadConfigResult);

                    string wadPublicConfig = null;
                    var wadExtension = this._Helper.GetExtension(selectedVM, AEMExtensionConstants.WADExtensionType[this.OSType], AEMExtensionConstants.WADExtensionPublisher[this.OSType]);
                    if (wadExtension != null)
                    {
                        wadPublicConfig = wadExtension.Settings.ToString();
                    }

                    this._Helper.WriteHost("IaaSDiagnostics check...", false);
                    if (wadExtension != null)
                    {
                        this._Helper.WriteHost(""); //New Line
                        this._Helper.WriteHost("\tIaaSDiagnostics configuration check...", false);

                        var currentJSONConfig = JsonConvert.DeserializeObject(wadPublicConfig) as Newtonsoft.Json.Linq.JObject;
                        var base64 = currentJSONConfig["xmlCfg"] as Newtonsoft.Json.Linq.JValue;
                        System.Xml.XmlDocument currentConfig = new System.Xml.XmlDocument();
                        currentConfig.LoadXml(Encoding.UTF8.GetString(System.Convert.FromBase64String(base64.Value.ToString())));


                        if (!this._Helper.CheckWADConfiguration(currentConfig))
                        {
                            wadConfigResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics configuration check", false));
                            this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                        }
                        else
                        {
                            wadConfigResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics configuration check", true));
                            this._Helper.WriteHost("OK ", ConsoleColor.Green);
                        }

                        this._Helper.WriteHost("\tIaaSDiagnostics performance counters check...");
                        var wadPerfCountersResult = new AEMTestResult("IaaSDiagnostics performance counters check");
                        wadConfigResult.PartialResults.Add(wadPerfCountersResult);

                        foreach (var perfCounter in AEMExtensionConstants.PerformanceCounters[this.OSType])
                        {
                            this._Helper.WriteHost("\t\tIaaSDiagnostics performance counters " + (perfCounter.counterSpecifier) + "check...", false);
                            var currentCounter = currentConfig.SelectSingleNode("/WadCfg/DiagnosticMonitorConfiguration/PerformanceCounters/PerformanceCounterConfiguration[@counterSpecifier = '" + perfCounter.counterSpecifier + "']");
                            if (currentCounter != null)
                            {
                                wadPerfCountersResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics performance counters " + (perfCounter.counterSpecifier) + "check...", true));
                                this._Helper.WriteHost("OK ", ConsoleColor.Green);
                            }
                            else
                            {
                                wadPerfCountersResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics performance counters " + (perfCounter.counterSpecifier) + "check...", false));
                                this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                            }
                        }

                        string wadstorage;
                        if (!this._Helper.GetMonPropertyValue<string>("wad.name", sapmonPublicConfig, out wadstorage))
                        {
                            wadstorage = null;
                        }

                        this._Helper.WriteHost("\tIaaSDiagnostics data check...", false);

                        var deploymentId = String.Empty;
                        var roleName = String.Empty;

                        var extStatuses = this._Helper.GetExtension(selectedVM, selectedVMStatus, AEMExtensionConstants.AEMExtensionType[this.OSType], AEMExtensionConstants.AEMExtensionPublisher[this.OSType]);
                        InstanceViewStatus aemStatus = null;
                        if (extStatuses != null && extStatuses.Statuses != null)
                        {
                            aemStatus = extStatuses.Statuses.FirstOrDefault(stat => Regex.Match(stat.Message, "deploymentId=(\\S*) roleInstance=(\\S*)").Success);
                        }

                        if (aemStatus != null)
                        {
                            var match = Regex.Match(aemStatus.Message, "deploymentId=(\\S*) roleInstance=(\\S*)");
                            deploymentId = match.Groups[1].Value;
                            roleName = match.Groups[2].Value;
                        }
                        else
                        {
                            this._Helper.WriteWarning("DeploymentId and RoleInstanceName could not be parsed from extension status");
                        }


                        var ok = false;
                        if (!this.SkipStorageCheck.IsPresent && (!String.IsNullOrEmpty(deploymentId)) && (!String.IsNullOrEmpty(roleName)) && (!String.IsNullOrEmpty(wadstorage)))
                        {

                            if (this.OSType.Equals(AEMExtensionConstants.OSTypeLinux, StringComparison.InvariantCultureIgnoreCase))
                            {
                                ok = this._Helper.CheckDiagnosticsTable(wadstorage, deploymentId,
                                    selectedVM.OsProfile.ComputerName, ".", this.OSType, this.WaitTimeInMinutes);
                            }
                            else
                            {
                                string filterMinute = "Role eq '" + AEMExtensionConstants.ROLECONTENT + "' and DeploymentId eq '"
                                    + deploymentId + "' and RoleInstance eq '" + roleName + "' and PartitionKey gt '0"
                                    + DateTime.UtcNow.AddMinutes(AEMExtensionConstants.ContentAgeInMinutes * -1).Ticks + "'";
                                ok = this._Helper.CheckTableAndContent(wadstorage, AEMExtensionConstants.WadTableName,
                                    filterMinute, ".", false, this.WaitTimeInMinutes);
                            }


                        }
                        if (ok && !this.SkipStorageCheck.IsPresent)
                        {
                            wadConfigResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics data check", true));
                            this._Helper.WriteHost("OK ", ConsoleColor.Green);
                        }
                        else if (!this.SkipStorageCheck.IsPresent)
                        {
                            wadConfigResult.PartialResults.Add(new AEMTestResult("IaaSDiagnostics data check", false));
                            this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                        }
                        else
                        {
                            this._Helper.WriteHost("Skipped ", ConsoleColor.Yellow);
                        }
                    }
                    else
                    {
                        wadConfigResult.Result = false;
                        this._Helper.WriteHost("NOT OK ", ConsoleColor.Red);
                    }
                }
                //################################################# 
                //#################################################

                if (!rootResult.Result)
                {
                    this._Helper.WriteHost("The script found some configuration issues. Please run the Set-AzureRmVMExtension commandlet to update the configuration of the virtual machine!");
                }

                this._Helper.WriteVerbose("TestAzureRmVMAEMExtension Done (" + rootResult.Result + ")");

                var result = Mapper.Map<AEMTestResult>(rootResult);
                WriteObject(result);
            });
        }
    }
}

