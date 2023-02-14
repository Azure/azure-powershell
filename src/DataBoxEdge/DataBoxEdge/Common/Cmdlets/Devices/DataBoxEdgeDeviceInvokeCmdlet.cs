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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeDevice;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsLifecycle.Invoke, Constants.Device, DefaultParameterSetName = InvokeScanForUpdateParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(bool)),
    ]
    public class DataBoxEdgeDeviceInvokeCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string InvokeScanForUpdateParameterSet = "InvokeScanForUpdateParameterSet";

        private const string InvokeScanForUpdateByResourceIdParameterSet =
            "InvokeScanForUpdateByResourceIdParameterSet";

        private const string InvokeScanForUpdateByDeviceObjectParameterSet =
            "InvokeScanForUpdateByDeviceObjectParameterSet";

        private const string InvokeFetchUpdateParameterSet = "InvokeFetchUpdateParameterSet";
        private const string InvokeFetchUpdatesByResourceIdParameterSet = "InvokeFetchUpdatesByResourceIdParameterSet";

        private const string InvokeFetchUpdatesByDeviceObjectParameterSet =
            "InvokeFetchUpdatesByDeviceObjectParameterSet";

        private const string InvokeInstallUpdateParameterSet = "InvokeInstallUpdateParameterSet";

        private const string InvokeInstallUpdatesByResourceIdParameterSet =
            "InvokeInstallUpdatesByResourceIdParameterSet";

        private const string InvokeInstallUpdatesByDeviceObjectParameterSet =
            "InvokeInstallUpdatesByDeviceObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdatesByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdatesByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ResourceIdCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdateParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdateParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdateParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdateParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdatesByDeviceObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateByDeviceObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdatesByDeviceObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSResourceModel DeviceObject { get; set; }


        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdateParameterSet,
            HelpMessage = HelpMessageDevice.FetchUpdateUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdatesByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.FetchUpdateUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeFetchUpdatesByDeviceObjectParameterSet,
            HelpMessage = HelpMessageDevice.FetchUpdateUpdateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter FetchUpdate { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateParameterSet,
            HelpMessage = HelpMessageDevice.ScanUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.ScanUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeScanForUpdateByDeviceObjectParameterSet,
            HelpMessage = HelpMessageDevice.ScanUpdateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ScanForUpdate { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdateParameterSet,
            HelpMessage = HelpMessageDevice.InstallUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdatesByResourceIdParameterSet,
            HelpMessage = HelpMessageDevice.InstallUpdateHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeInstallUpdatesByDeviceObjectParameterSet,
            HelpMessage = HelpMessageDevice.InstallUpdateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter InstallUpdate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru;


        private bool ScanForUpdates()
        {
            DevicesOperationsExtensions.ScanForUpdates(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        private bool DownloadUpdates()
        {
            DevicesOperationsExtensions.DownloadUpdates(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        private bool InstallUpdates()
        {
            DevicesOperationsExtensions.InstallUpdates(
                this.DataBoxEdgeManagementClient.Devices,
                this.Name,
                this.ResourceGroupName);
            return true;
        }

        public override void ExecuteCmdlet()
        {
            var result = false;
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (this.IsParameterBound(c => c.DeviceObject))
            {
                this.ResourceGroupName = DeviceObject.ResourceGroupName;
                this.Name = DeviceObject.Name;
            }

            if (this.ScanForUpdate.IsPresent)
            {
                result = ScanForUpdates();
            }
            else if (this.FetchUpdate.IsPresent)
            {
                result = DownloadUpdates();
            }
            else if (this.InstallUpdate.IsPresent)
            {
                result = InstallUpdates();
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(result);
            }
        }
    }
}