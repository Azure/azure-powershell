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

using Microsoft.Azure.Commands.Compute.Extension.AEM;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute
{
    public static class AEMExtensionConstants
    {
        public const string VirtualMachineExtensionResourceType = "Microsoft.Compute/virtualMachines/extensions";
        public static Dictionary<string, string> AEMExtensionDefaultName = new Dictionary<string, string>() { { OSTypeWindows, "AzureCATExtensionHandler" }, { OSTypeLinux, "AzureEnhancedMonitorForLinux" } };
        public static Dictionary<string, string> AEMExtensionPublisher = new Dictionary<string, string>() { { OSTypeWindows, "Microsoft.AzureCAT.AzureEnhancedMonitoring" }, { OSTypeLinux, "Microsoft.OSTCExtensions" } };
        public static Dictionary<string, string> AEMExtensionType = new Dictionary<string, string>() { { OSTypeWindows, "AzureCATExtensionHandler" }, { OSTypeLinux, "AzureEnhancedMonitorForLinux" } };
        public static Dictionary<string, Version> AEMExtensionVersion = new Dictionary<string, Version>() { { OSTypeWindows, new Version(2, 2) }, { OSTypeLinux, new Version(3, 0) } };

        public static Dictionary<string, string> WADExtensionDefaultName = new Dictionary<string, string>() { { OSTypeWindows, "IaaSDiagnostics" }, { OSTypeLinux, "LinuxDiagnostic" } };
        public static Dictionary<string, string> WADExtensionPublisher = new Dictionary<string, string>() { { OSTypeWindows, "Microsoft.Azure.Diagnostics" }, { OSTypeLinux, "Microsoft.OSTCExtensions" } };
        public static Dictionary<string, string> WADExtensionType = new Dictionary<string, string>() { { OSTypeWindows, "IaaSDiagnostics" }, { OSTypeLinux, "LinuxDiagnostic" } };
        public static Dictionary<string, Version> WADExtensionVersion = new Dictionary<string, Version>() { { OSTypeWindows, new Version(1, 5) }, { OSTypeLinux, new Version(2, 3) } };

        public const string OSTypeWindows = "Windows";
        public const string OSTypeLinux = "Linux";
        public const string VMSizeExtraSmall = "ExtraSmall";
        public const string VMSizeStandard_A0 = "Standard_A0";
        public const string VMSizeBasic_A0 = "Basic_A0";
        public const string CurrentScriptVersion = "3.0.0.0";

        public const string DISK_TYPE_STANDARD = "Standard";
        public const string DISK_TYPE_PREMIUM = "Premium";
        public const string WadTableName = "WADPerformanceCountersTable";
        public const string AzureEndpoint = "core.windows.net";
        public const int ContentAgeInMinutes = 5;
        public const string MissingGuestAgentWarning = "Provision Guest Agent is not installed on this Azure Virtual Machine. Please read the documentation on how to download and install the Provision Guest Agent. After you have installed the Provision Guest Agent, enable it with the Enable-ProvisionGuestAgent_GUI commandlet that is part of this Powershell Module.";
        public const string ROLECONTENT = "IaaS";
        public const string SchemasTable = "SchemasTable";
        public const string SchemasTablePhysicalTableName = "PhysicalTableName";
        public const string WADConfigXML = "<WadCfg><DiagnosticMonitorConfiguration overallQuotaInMB=\"4096\"><PerformanceCounters scheduledTransferPeriod=\"PT1M\" ></PerformanceCounters></DiagnosticMonitorConfiguration></WadCfg>";
        public static Dictionary<string, List<string>> WADTablesV2 = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase)
        {
            { OSTypeLinux, new List<string>() { "LinuxCpuVer2v0", "LinuxDiskVer2v0", "LinuxMemoryVer2v0" } },
            { OSTypeWindows, new List<string>() { } }
        };

        public static Dictionary<string, List<PerformanceCounter>> PerformanceCounters = new Dictionary<string, List<PerformanceCounter>>()
        {
            {
                OSTypeWindows,  new List<PerformanceCounter>()
                {
                    new PerformanceCounter() { counterSpecifier="\\Processor(_Total)\\% Processor Time", sampleRate = "PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\Processor Information(_Total)\\Processor Frequency",sampleRate="PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\Available Bytes",sampleRate="PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\TCPv6\\Segments Retransmitted/sec",sampleRate="PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\TCPv4\\Segments Retransmitted/sec",sampleRate="PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\Network Interface(*)\\Bytes Sent/sec",sampleRate="PT1M"},
                    new PerformanceCounter() { counterSpecifier="\\Network Interface(*)\\Bytes Received/sec",sampleRate="PT1M"}
                }
            },
            {
                OSTypeLinux,  new List<PerformanceCounter>()
                {
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentProcessorTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentIdleTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentPrivilegedTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentInterruptTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentDPCTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentUserTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentNiceTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Processor\\PercentIOWaitTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PercentUsedMemory",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\UsedMemory",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PercentAvailableMemory",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\AvailableMemory",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PercentUsedByCache",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PercentUsedSwap",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\UsedSwap",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\AvailableSwap",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PagesPerSec",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PagesReadPerSec",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\Memory\\PagesWrittenPerSec",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\AverageTransferTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\AverageReadTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\AverageWriteTime",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\TransfersPerSecond",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\ReadsPerSecond",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\WritesPerSecond",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\BytesPerSecond",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\WriteBytesPerSecond",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\PhysicalDisk\\AverageDiskQueueLength",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\BytesTotal",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\BytesTransmitted",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\BytesReceived",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\PacketsTransmitted",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\PacketsReceived",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\TotalRxErrors",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\TotalTxErrors",sampleRate = "PT15S"},
                    new PerformanceCounter() { counterSpecifier="\\NetworkInterface\\TotalCollisions",sampleRate = "PT15S"},
                }
            }
        };
    }
}
