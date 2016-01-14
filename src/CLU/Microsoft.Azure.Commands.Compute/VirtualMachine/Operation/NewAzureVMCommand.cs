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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    [CliCommandAlias("vm;create")]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("VMProfile")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Hashtable[] Tags { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (this.VM.DiagnosticsProfile == null)
            {
                var storageUri = GetOrCreateStorageAccountForBootDiagnostics();

                if (storageUri != null)
                {
                    this.VM.DiagnosticsProfile = new DiagnosticsProfile
                    {
                        BootDiagnostics = new BootDiagnostics
                        {
                            Enabled = true,
                            StorageUri = storageUri.ToString(),
                        }
                    };
                }
            }

            ExecuteClientAction(() =>
            {
                var parameters = new VirtualMachine
                {
                    DiagnosticsProfile       = this.VM.DiagnosticsProfile,
                    HardwareProfile          = this.VM.HardwareProfile,
                    StorageProfile           = this.VM.StorageProfile,
                    NetworkProfile           = this.VM.NetworkProfile,
                    OsProfile                = this.VM.OSProfile,
                    Plan                     = this.VM.Plan,
                    AvailabilitySet          = this.VM.AvailabilitySetReference,
                    Location                 = !string.IsNullOrEmpty(this.Location) ? this.Location : this.VM.Location,
                    Tags                     = this.Tags != null ? this.Tags.ToDictionary() : this.VM.Tags
                };

                var op = this.VirtualMachineClient.CreateOrUpdate(this.ResourceGroupName, this.VM.Name, parameters);
                // TODO: CLU
                var result = op;
                //var result = Mapper.Map<PSComputeLongRunningOperation>(op);
                WriteObject(result);
            });
        }

        private Uri GetOrCreateStorageAccountForBootDiagnostics()
        {                        
            var storageAccountName = GetStorageAccountNameFromStorageProfile();
            var storageClient =
                    ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context,
                        AzureEnvironment.Endpoint.ResourceManager);

            if (!string.IsNullOrEmpty(storageAccountName))
            {
                try
                {
                    var storageAccountResponse = storageClient.StorageAccounts.GetProperties(this.ResourceGroupName,
                        storageAccountName);
                    if (!storageAccountResponse.AccountType.Equals(AccountType.PremiumLRS))
                    {
                        return new Uri(storageAccountResponse.PrimaryEndpoints.Blob);
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("ResourceNotFound"))
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.StorageAccountNotFoundForBootDiagnostics, storageAccountName));
                    }
                    else
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringGettingStorageAccountForBootDiagnostics, storageAccountName, e.Message));
                    }
                }
            }

            var storageAccount = TryToChooseExistingStandardStorageAccount(storageClient);

            if (storageAccount == null)
            {
                return CreateStandardStorageAccount(storageClient);
            }

            WriteWarning(string.Format(Properties.Resources.UsingExistingStorageAccountForBootDiagnostics, storageAccount.Name));

            return new Uri(storageAccount.PrimaryEndpoints.Blob);
        }

        private string GetStorageAccountNameFromStorageProfile()
        {
            if (this.VM == null
                || this.VM.StorageProfile == null
                || this.VM.StorageProfile.OsDisk == null
                || this.VM.StorageProfile.OsDisk.Vhd == null
                || this.VM.StorageProfile.OsDisk.Vhd.Uri == null)
            {
                return null;
            }

            return GetStorageAccountNameFromUriString(this.VM.StorageProfile.OsDisk.Vhd.Uri);
        }

        private StorageAccount TryToChooseExistingStandardStorageAccount(StorageManagementClient client)
        {
            var storageAccountList = client.StorageAccounts.ListByResourceGroup(this.ResourceGroupName);
            if (storageAccountList == null)
            {
                return null;
            }

            try
            {
                return storageAccountList.First(
                e => e.AccountType.HasValue && !e.AccountType.Value.Equals(AccountType.PremiumLRS));
            }
            catch (InvalidOperationException e)
            {
                if (e.Message.Contains("Sequence contains no matching element"))
                {
                    return null;
                }
                throw;
            }
        }
        
        private Uri CreateStandardStorageAccount(StorageManagementClient client)
        {
            string storageAccountName;

            var i = 0;
            bool? nameAvailable = null;
            do
            {
                storageAccountName = GetRandomStorageAccountName(i);
                i++;

                nameAvailable = client.StorageAccounts.CheckNameAvailability(storageAccountName).NameAvailable;
            }
            while (i < 10 && nameAvailable.HasValue && nameAvailable.Value);

            var storaeAccountParameter = new StorageAccountCreateParameters
            {
                AccountType = AccountType.StandardGRS,
                Location = this.Location ?? this.VM.Location,
            };

            try
            {
                client.StorageAccounts.Create(this.ResourceGroupName, storageAccountName, storaeAccountParameter);
                var getresponse = client.StorageAccounts.GetProperties(this.ResourceGroupName, storageAccountName);
                WriteWarning(string.Format(Resources.CreatingStorageAccountForBootDiagnostics, storageAccountName));

                return new Uri(getresponse.PrimaryEndpoints.Blob);
            }
            catch (Exception e)
            {
                // Failed to create a storage account for boot diagnostics.
                WriteWarning(string.Format(Properties.Resources.ErrorDuringCreatingStorageAccountForBootDiagnostics, e));
                return null;
            }
        }

        private string GetRandomStorageAccountName(int interation)
        {
            const int maxSubLength = 5;
            const int maxResLength = 6;
            const int maxVMLength = 4;

            var subscriptionName = VirtualMachineCmdletHelper.GetTruncatedStr(this.DefaultContext.Subscription.Name, maxSubLength);
            var resourcename = VirtualMachineCmdletHelper.GetTruncatedStr(this.ResourceGroupName, maxResLength);
            var vmname = VirtualMachineCmdletHelper.GetTruncatedStr(this.VM.Name, maxVMLength);
            var datetimestr = DateTime.Now.ToString("MMddHHmm");

            var output = subscriptionName + resourcename + vmname + datetimestr + interation;

            output = new string((from c in output where char.IsLetterOrDigit(c) select c).ToArray());

            return output.ToLowerInvariant();
        }

        private static string GetStorageAccountNameFromUriString(string uriStr)
        {
            Uri uri;

            if (!Uri.TryCreate(uriStr, UriKind.RelativeOrAbsolute, out uri))
            {
                return null;
            }

            var storageUri = uri.Authority;
            var index = storageUri.IndexOf('.');
            return storageUri.Substring(0, index);
        }
    }
}
