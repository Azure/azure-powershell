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



namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    class HelpMessageDevice
    {
        internal const string ObjectName = "Device";
        internal const string LocationHelpMessage = "Location of the device";
        internal const string SkuHelpMessage = "Available Skus are Edge, Gateway";
        internal const string ScanUpdateHelpMessage = "Scans for updates on a data box edge/gateway device.";
        internal const string FetchUpdateUpdateHelpMessage = "Downloads the updates on a data box edge/gateway device";
        internal const string InstallUpdateHelpMessage = "Installs the updates on the data box edge/gateway device";
        internal const string AlertHelpMessage = "Fetch the alerts on the data box edge/gateway device";

        internal const string NetworkSettingHelpMessage = "Gets the network settings of the specified Data Box Edge/Data Box Gateway device";
        internal const string ExtendedInfoHelpMessage = "Gets additional information for the specified Data Box Edge/Data Box Gateway device";
        internal const string UpdateSummaryHelpMessage = "Gets information about the availability of updates based on the last scan of the device. It also gets information about any ongoing download or install jobs on the device.";
    }
}