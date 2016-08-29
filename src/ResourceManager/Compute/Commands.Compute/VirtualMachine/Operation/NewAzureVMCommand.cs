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
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using CM = Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Position = 3,
            HelpMessage = "Disable BG Info Extension")]
        public SwitchParameter DisableBginfoExtension { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tags { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string LicenseType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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

            if (ShouldProcess(this.VM.Name, VerbsCommon.New))
            {
                ExecuteClientAction(() =>
                {
                    var parameters = new VirtualMachine
                    {
                        DiagnosticsProfile = this.VM.DiagnosticsProfile,
                        HardwareProfile = this.VM.HardwareProfile,
                        StorageProfile = this.VM.StorageProfile,
                        NetworkProfile = this.VM.NetworkProfile,
                        OsProfile = this.VM.OSProfile,
                        Plan = this.VM.Plan,
                        LicenseType = this.LicenseType ?? this.VM.LicenseType,
                        AvailabilitySet = this.VM.AvailabilitySetReference,
                        Location = this.Location ?? this.VM.Location,
                        Tags = this.Tags != null ? this.Tags.ToDictionary() : this.VM.Tags
                    };

                    var op = this.VirtualMachineClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VM.Name,
                        parameters);
                    var wait = op.GetAwaiter();
                    var resultop = wait.GetResult();
                    var result = Mapper.Map<PSAzureOperationResponse>(resultop);

                    if (!(this.DisableBginfoExtension.IsPresent || IsLinuxOs()))
                    {

                        var currentBginfoVersion = GetBginfoExtension();

                        if (!string.IsNullOrEmpty(currentBginfoVersion))
                        {
                            var extensionParameters = new VirtualMachineExtension
                            {
                                Location = this.Location,
                                Publisher = VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                                VirtualMachineExtensionType = VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                TypeHandlerVersion = currentBginfoVersion,
                                AutoUpgradeMinorVersion = true,
                            };

                            typeof(CM.Resource).GetRuntimeProperty("Name").SetValue(extensionParameters, VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);
                            typeof(CM.Resource).GetRuntimeProperty("Type")
                                .SetValue(extensionParameters, VirtualMachineExtensionType);

                            var op2 = ComputeClient.ComputeManagementClient.VirtualMachineExtensions.CreateOrUpdateWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.VM.Name,
                                VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                extensionParameters).GetAwaiter().GetResult();
                            result = Mapper.Map<PSAzureOperationResponse>(op2);
                        }
                    }
                    WriteObject(result);
                });
            }
        }

        private string GetBginfoExtension()
        {
            var canonicalizedLocation = this.Location.Canonicalize();

            var publishers =
                ComputeClient.ComputeManagementClient.VirtualMachineImages.ListPublishers(canonicalizedLocation);

            var publisher = publishers.FirstOrDefault(e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher));

            if (publisher == null || !publisher.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher))
            {
                return null;
            }

            var virtualMachineImageClient = ComputeClient.ComputeManagementClient.VirtualMachineExtensionImages;


            var imageTypes =
                virtualMachineImageClient.ListTypes(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher);

            var extensionType = imageTypes.FirstOrDefault(
                e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName));

            if (extensionType == null || !extensionType.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName))
            {
                return null;
            }

            var bginfoVersions =
                virtualMachineImageClient.ListVersions(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);

            if (bginfoVersions != null
                && bginfoVersions.Count > 0)
            {
                return bginfoVersions.Max(ver =>
                {
                    Version result;
                    return (Version.TryParse(ver.Name, out result))
                        ? string.Format("{0}.{1}", result.Major, result.Minor)
                        : VirtualMachineBGInfoExtensionContext.ExtensionDefaultVersion;
                });
            }

            return null;
        }

        private bool IsLinuxOs()
        {
            if (this.VM == null)
            {
                return false;
            }

            if ((this.VM.StorageProfile != null)
                && (this.VM.StorageProfile.OsDisk != null)
                && (this.VM.StorageProfile.OsDisk.OsType != null))
            {
                return (this.VM.StorageProfile.OsDisk.OsType.Equals(OperatingSystemTypes.Linux));
            }

            return ((this.VM.OSProfile != null)
                    && (this.VM.OSProfile.LinuxConfiguration != null));
        }

        private string GetOrCreateStorageAccountForBootDiagnostics()
        {
            var storageAccountName = GetStorageAccountNameFromStorageProfile();
            var storageClient =
                    AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context,
                        AzureEnvironment.Endpoint.ResourceManager);

            if (!string.IsNullOrEmpty(storageAccountName))
            {
                try
                {
                    var storageAccountList = storageClient.StorageAccounts.List();
                    if (storageAccountList != null)
                    {
                        var osDiskStorageAccount = storageAccountList.First(e => e.Name.Equals(storageAccountName));

                        if (osDiskStorageAccount != null
                            && osDiskStorageAccount.AccountType.HasValue
                            && !osDiskStorageAccount.AccountType.Value.ToString().ToLowerInvariant().Contains("premium"))
                        {
                            return osDiskStorageAccount.PrimaryEndpoints.Blob;
                        }
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
            return storageAccount.PrimaryEndpoints.Blob;
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
            if (storageAccountList == null || storageAccountList.Count() == 0)
            {
                storageAccountList = client.StorageAccounts.List().Where(e => e.Location.Canonicalize().Equals(this.Location.Canonicalize()));
                if (storageAccountList == null || storageAccountList.Count() == 0)
                {
                    return null;
                }
            }

            try
            {
                return storageAccountList.First(
                e => e.AccountType.HasValue
                    && !e.AccountType.Value.ToString().ToLowerInvariant().Contains("premium"));
            }
            catch (InvalidOperationException e)
            {
                WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringChoosingStandardStorageAccount, e.Message));
                return null;
            }
        }

        private string CreateStandardStorageAccount(StorageManagementClient client)
        {
            string storageAccountName;

            var i = 0;
            do
            {
                storageAccountName = GetRandomStorageAccountName(i);
                i++;
            }
            while (i < 10 && (bool) !client.StorageAccounts.CheckNameAvailability(storageAccountName).NameAvailable);

            var storaeAccountParameter = new StorageAccountCreateParameters
            {
                AccountType = AccountType.StandardGRS,
                Location = this.Location ?? this.VM.Location,
            };

            try
            {
                client.StorageAccounts.Create(this.ResourceGroupName, storageAccountName, storaeAccountParameter);
                var getresponse = client.StorageAccounts.GetProperties(this.ResourceGroupName, storageAccountName);
                WriteWarning(string.Format(Properties.Resources.CreatingStorageAccountForBootDiagnostics, storageAccountName));

                return getresponse.PrimaryEndpoints.Blob;
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
