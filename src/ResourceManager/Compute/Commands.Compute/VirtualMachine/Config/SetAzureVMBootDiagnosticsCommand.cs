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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.BootDiagnostics),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMBootDiagnosticsCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        private const string EnableParameterSet = "EnableBootDiagnostics";
        private const string DisableParameterSet = "DisableBootDiagnostics";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = EnableParameterSet,
            HelpMessage = HelpMessages.VMBootDiagnosticsEnable)]
        public SwitchParameter Enable { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = DisableParameterSet,
            HelpMessage = HelpMessages.VMBootDiagnosticsDisable)]
        public SwitchParameter Disable { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = EnableParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMBootDiagnosticsResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ParameterSetName = EnableParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMBootDiagnosticsStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            var diagnosticsProfile = this.VM.DiagnosticsProfile;

            diagnosticsProfile = diagnosticsProfile ?? new DiagnosticsProfile();

            diagnosticsProfile.BootDiagnostics = diagnosticsProfile.BootDiagnostics ?? new BootDiagnostics();

            diagnosticsProfile.BootDiagnostics.Enabled = this.Enable.IsPresent;

            if (this.Enable.IsPresent)
            {
                if (string.IsNullOrEmpty(this.StorageAccountName))
                {
                    if (diagnosticsProfile.BootDiagnostics.StorageUri == null)
                    {
                        ThrowNoStorageAccount();
                    }
                }
                else
                {
                    var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);
                    var storageAccount = storageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.StorageAccountName);

                    if (storageAccount.AccountType.Equals(AccountType.PremiumLRS))
                    {
                        ThrowPremiumStorageError(this.StorageAccountName);
                    }

                    diagnosticsProfile.BootDiagnostics.StorageUri = storageAccount.PrimaryEndpoints.Blob.ToString();
                }
            }

            this.VM.DiagnosticsProfile = diagnosticsProfile;

            WriteObject(this.VM);
        }

        private void ThrowPremiumStorageError(string storageAccountName)
        {
            ThrowTerminatingError
                (new ErrorRecord(
                    new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        Properties.Resources.PremiumStorageAccountForBootDiagnostics, storageAccountName)),
                    string.Empty,
                    ErrorCategory.InvalidData,
                    null));
        }

        private void ThrowNoStorageAccount()
        {
            ThrowTerminatingError
                (new ErrorRecord(
                    new InvalidOperationException(Properties.Resources.BootDiagnosticsNoStorageAccountError),
                    string.Empty,
                    ErrorCategory.InvalidData,
                    null));
        }
    }
}
