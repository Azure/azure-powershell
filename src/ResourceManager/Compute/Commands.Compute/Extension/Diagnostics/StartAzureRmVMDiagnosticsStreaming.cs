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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.VisualStudio.EtwListener.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    [Cmdlet(
        VerbsLifecycle.Start,
        ProfileNouns.VirtualMachineDiagnosticsStreaming,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSEtwEvent))]
    public class StartAzureRmVMDiagnosticsStreaming : EtwStreamingVMCmdletBase
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
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of ETW providers.")]
        [ValidateNotNullOrEmpty]
        public string[] EtwProviders { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                this.virtualMachine = this.ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                FlushMessageWhileWait(Task.Run(() => StartStreaming()));
            });
        }

        private async Task StartStreaming()
        {
            VirtualMachineExtension extension = this.virtualMachine.Resources == null? null: this.virtualMachine.Resources.FirstOrDefault(EtwStreamingHelper.IsEtwListenerExtension);
            if (extension == null || extension.TypeHandlerVersion != EtwListenerConstants.CurrentVersion)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.ExtensionNotFound, this.virtualMachine.Id));
            }

            EtwListenerExtensionPublicSettings settings = (extension.Settings as JObject).ToObject<EtwListenerExtensionPublicSettings>();
            if (settings == null || string.IsNullOrEmpty(settings.ClientCertificateThumbprint) || string.IsNullOrEmpty(settings.ServerCertificateThumbprint) || string.IsNullOrEmpty(settings.ClientCertificateUrl))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.InvalidEtwListenerSettings));
            }

            await EtwStreamingHelper.EnrollCertificateFromKeyVault(KeyVaultClient, settings.ClientCertificateUrl, settings.ClientCertificateThumbprint);

            // Get public address and etw listener port
            NetworkInterface networkInterface = GetPrimaryNetworkInterface();
            IPEndPoint endpoint = EtwStreamingHelper.GetEtwConnectionInfo(networkInterface, this.NetworkClient);

            var connectionInfo = new ListenerConnectionInfo(this.virtualMachine.Name, endpoint.Address.ToString(), endpoint.Port, settings.ServerCertificateThumbprint, settings.ClientCertificateThumbprint);
            EtwStreamingHelper.StartListening(this, connectionInfo, this.EtwProviders);
        }
    }
}
