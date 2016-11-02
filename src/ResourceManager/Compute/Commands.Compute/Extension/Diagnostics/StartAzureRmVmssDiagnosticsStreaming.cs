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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.VisualStudio.EtwListener.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsLifecycle.Start,
        ProfileNouns.VirtualMachineScaleSetDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSEtwEvent))]
    public class StartAzureRmVmssDiagnosticsStreaming : EtwStreamingVmssCmdletBase
    {
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
            HelpMessage = "The virtual machine scale set name.")]
        [ValidateNotNullOrEmpty]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The instance id of virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of ETW providers.")]
        [ValidateNotNullOrEmpty]
        public string[] EtwProviders { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this.virtualMachineScaleSet = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, this.VMScaleSetName);
                FlushMessageWhileWait(Task.Run(() => StartStreaming()));
            });
        }

        private void StartStreaming()
        {
            VirtualMachineScaleSetVM vm = this.ComputeClient.ComputeManagementClient.VirtualMachineScaleSetVMs.Get(this.ResourceGroupName, this.VMScaleSetName, this.InstanceId);

            var extension = vm.Resources.FirstOrDefault(EtwStreamingHelper.IsEtwListenerExtension);
            if (extension == null || extension.TypeHandlerVersion != EtwListenerConstants.CurrentVersion)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.ExtensionNotFound, vm.Id));
            }

            EtwListenerExtensionPublicSettings settings = (extension.Settings as JObject).ToObject<EtwListenerExtensionPublicSettings>();

            EtwStreamingHelper.EnrollCertificateFromKeyVault(KeyVaultClient, settings.ClientCertificateUrl, settings.ClientCertificateThumbprint).GetAwaiter().GetResult();

            IList<NetworkInterfaceReference> networkInterfaces = vm.NetworkProfile.NetworkInterfaces;
            NetworkInterfaceReference primaryNetworkInterface = networkInterfaces.Count > 1 ? networkInterfaces.FirstOrDefault(v => v.Primary == true) : networkInterfaces.FirstOrDefault();

            if (primaryNetworkInterface == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.PrimaryNetworkInterfaceNotFound, vm.Id));
            }

            var rid = new ResourceIdentifier(primaryNetworkInterface.Id);
            NetworkInterface networkInterface = this.NetworkInterfaceClient.GetVirtualMachineScaleSetNetworkInterface(this.ResourceGroupName, this.VMScaleSetName, this.InstanceId, rid.ResourceName);

            IPEndPoint endpoint = EtwStreamingHelper.GetEtwConnectionInfo(networkInterface, this.NetworkClient);

            var connectionInfo = new ListenerConnectionInfo(this.virtualMachineScaleSet.Name, endpoint.Address.ToString(), endpoint.Port, settings.ServerCertificateThumbprint, settings.ClientCertificateThumbprint);
            EtwStreamingHelper.StartListening(this, connectionInfo, this.EtwProviders);
        }
    }
}
