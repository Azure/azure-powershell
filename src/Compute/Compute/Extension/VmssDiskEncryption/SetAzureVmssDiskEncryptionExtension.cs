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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssDiskEncryptionExtension", SupportsShouldProcess = true, DefaultParameterSetName = AzureDiskEncryptionExtensionConstants.aadClientSecretParameterSet)]
    [OutputType(typeof(PSVirtualMachineScaleSetExtension))]
    public class SetAzureVmssDiskEncryptionExtensionCommand : VirtualMachineScaleSetExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name to which the VM Scale Set belongs to")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the virtual machine scale set")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "URL of the KeyVault where generated encryption key will be placed to")]
        public string DiskEncryptionKeyVaultUrl { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceID of the KeyVault where generated encryption key will be placed to")]
        public string DiskEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceID of the managed identity with access to keyvault for Azure Disk Encryption operations.")]
        [ValidateNotNullOrEmpty]
        public string EncryptionIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Versioned KeyVault URL of the KeyEncryptionKey used to encrypt the disk encryption key")]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceID of the KeyVault containing the KeyEncryptionKey used to encrypt the disk encryption key")]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyVaultId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyEncryption Algorithm used to encrypt the volume encryption key")]
        [ValidateSet("RSA-OAEP", "RSA1_5")]
        public string KeyEncryptionAlgorithm { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of the volume (OS or Data) to perform encryption operation")]
        [ValidateSet(
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeOS,
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeData,
            AzureVmssDiskEncryptionExtensionContext.VolumeTypeAll)]
        public string VolumeType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Generate a tag for force update.  This should be given to perform repeated encryption operations on the same VM.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ForceUpdate { get; set; }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type handler version.")]
        [ValidateNotNullOrEmpty]
        public string TypeHandlerVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension publisher name. If this parameter is not specified, default value is Microsoft.Azure.Security for Windows VMs and Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string ExtensionPublisherName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name. If this parameter is not specified, default values used are AzureDiskEncryption for Windows VMs and AzureDiskEncryptionForLinux for Linux VMs")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The extension type. Specify this parameter to override its default value of \"AzureDiskEncryption\" for Windows VMs and \"AzureDiskEncryptionForLinux\" for Linux VMs.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "EncryptFormatAll data drives that are not already encrypted")]
        public SwitchParameter EncryptFormatAll { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The passphrase specified in parameters. This parameter only works for Linux VM.")]
        [ValidateNotNullOrEmpty]
        public string Passphrase { get; set; }

        [Parameter(HelpMessage = "To force enabling encryption on the virtual machine scale set.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable auto-upgrade of minor version")]
        public SwitchParameter DisableAutoUpgradeMinorVersion { get; set; }

        private Hashtable GetExtensionPublicSettings()
        {
            Hashtable publicSettings = new Hashtable();

            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyVaultUrlKey, DiskEncryptionKeyVaultUrl ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyEncryptionKeyUrlKey, KeyEncryptionKeyUrl ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyVaultResourceIdKey, DiskEncryptionKeyVaultId ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.kekVaultResourceIdKey, KeyEncryptionKeyVaultId ?? string.Empty);
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.volumeTypeKey, VolumeType ?? string.Empty);

            if (EncryptFormatAll.IsPresent)
            {
                publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.enableEncryptionFormatAllOperation);
            }
            else
            {
                publicSettings.Add(AzureDiskEncryptionExtensionConstants.encryptionOperationKey, AzureDiskEncryptionExtensionConstants.enableEncryptionOperation);
            }

            string keyEncryptAlgorithm = string.Empty;
            if (!string.IsNullOrEmpty(this.KeyEncryptionKeyUrl))
            {
                if (!string.IsNullOrEmpty(KeyEncryptionAlgorithm))
                {
                    keyEncryptAlgorithm = KeyEncryptionAlgorithm;
                }
                else
                {
                    keyEncryptAlgorithm = AzureDiskEncryptionExtensionConstants.defaultKeyEncryptionAlgorithm;
                }
            }
            publicSettings.Add(AzureDiskEncryptionExtensionConstants.keyEncryptionAlgorithmKey, keyEncryptAlgorithm);

            return publicSettings;
        }

        private Hashtable GetExtensionProtectedSettings()
        {
            Hashtable protectedSettings = new Hashtable();
            if (OperatingSystemTypes.Linux.Equals(this.CurrentOSType))
            {
                protectedSettings.Add(AzureDiskEncryptionExtensionConstants.passphraseKey, Passphrase ?? null);
            }

            return protectedSettings;
        }

        private VirtualMachineScaleSetExtension GetVmssExtensionParameters()
        {
            Hashtable SettingString = GetExtensionPublicSettings();
            Hashtable ProtectedSettingString = GetExtensionProtectedSettings();

            VirtualMachineScaleSetExtension vmssExtensionParameters = null;

            if (OperatingSystemTypes.Windows.Equals(this.CurrentOSType))
            {
                this.ExtensionName = this.ExtensionName ?? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultName;
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultName;
                vmssExtensionParameters = new VirtualMachineScaleSetExtension
                {
                    Name = this.ExtensionName,
                    Publisher = this.ExtensionPublisherName,
                    Type1 = this.ExtensionType,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureVmssDiskEncryptionExtensionContext.ExtensionDefaultVersion,
                    Settings = SettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent,
                    ForceUpdateTag = this.ForceUpdate.IsPresent ? Guid.NewGuid().ToString() : null
                };

            }
            else if (OperatingSystemTypes.Linux.Equals(this.CurrentOSType))
            {
                this.ExtensionName = this.ExtensionName ?? AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                this.ExtensionPublisherName = this.ExtensionPublisherName ?? AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultPublisher;
                this.ExtensionType = this.ExtensionType ?? AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultName;
                vmssExtensionParameters = new VirtualMachineScaleSetExtension
                {
                    Name = this.ExtensionName,
                    Publisher = this.ExtensionPublisherName,
                    Type1 = this.ExtensionType,
                    TypeHandlerVersion = (this.TypeHandlerVersion) ?? AzureVmssDiskEncryptionExtensionContext.LinuxExtensionDefaultVersion,
                    Settings = SettingString,
                    AutoUpgradeMinorVersion = !DisableAutoUpgradeMinorVersion.IsPresent,
                    ForceUpdateTag = this.ForceUpdate.IsPresent ? Guid.NewGuid().ToString() : null
                };
            }

            if (ProtectedSettingString != null && ProtectedSettingString.Count > 0)
            {
                vmssExtensionParameters.ProtectedSettings = ProtectedSettingString;
            }

            return vmssExtensionParameters;
        }

        private bool UpdateVmssEncryptionIdentity()
        {
            bool updateVmss = false;
            var vmssParameters = (this.VirtualMachineScaleSetClient.Get(
                this.ResourceGroupName, this.VMScaleSetName));

            if (vmssParameters.Identity == null || vmssParameters.Identity.UserAssignedIdentities == null ||
                !vmssParameters.Identity.UserAssignedIdentities.ContainsKey(this.EncryptionIdentity))
                ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture,
                    "Encryption Identity should be an ARM Resource ID of one of the user assigned identities associated to the resource")),
                    "InvalidResult", ErrorCategory.InvalidResult, null));

            if (vmssParameters.VirtualMachineProfile == null)
            {
                vmssParameters.VirtualMachineProfile = new VirtualMachineScaleSetVMProfile();
            }

            if (vmssParameters.VirtualMachineProfile.SecurityProfile == null)
            {
                vmssParameters.VirtualMachineProfile.SecurityProfile = new SecurityProfile();
            }

            if (vmssParameters.VirtualMachineProfile.SecurityProfile.EncryptionIdentity == null)
            {
                vmssParameters.VirtualMachineProfile.SecurityProfile.EncryptionIdentity = new EncryptionIdentity();
            }

            if (String.IsNullOrEmpty(vmssParameters.VirtualMachineProfile.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId) || 
                !vmssParameters.VirtualMachineProfile.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId.Equals(this.EncryptionIdentity, 
                StringComparison.OrdinalIgnoreCase))
            {
                vmssParameters.VirtualMachineProfile.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId = this.EncryptionIdentity;
                updateVmss = true;
            }

            if (updateVmss)
            {
                // update VMss
                AzureOperationResponse<VirtualMachineScaleSet> updateEncryptionIdentity = null;
                updateEncryptionIdentity = this.VirtualMachineScaleSetClient.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName, vmssParameters.Name, vmssParameters).GetAwaiter().GetResult();

                if (updateEncryptionIdentity != null && updateEncryptionIdentity.Response != null && 
                    updateEncryptionIdentity.Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    ThrowTerminatingError(new ErrorRecord(new ApplicationException(string.Format(CultureInfo.CurrentUICulture,"Failed to update encryption identity on VMSS")),
                        "InvalidResult", ErrorCategory.InvalidResult, null));
                }
                return false;
            }
            return true;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(VMScaleSetName, Properties.Resources.EnableDiskEncryptionAction)
                && (this.Force.IsPresent ||
                this.ShouldContinue(Properties.Resources.EnableAzureDiskEncryptionConfirmation, Properties.Resources.EnableAzureDiskEncryptionCaption))) // Change this.
                {
                    VerifyParameters();

                    VirtualMachineScaleSet vmssResponse = this.VirtualMachineScaleSetClient.Get(
                        this.ResourceGroupName, VMScaleSetName);

                    if (vmssResponse == null || vmssResponse.VirtualMachineProfile == null)
                    {
                        ThrowInvalidArgumentError("The given VM Scale Set, {0}, does not exist.", this.VMScaleSetName);
                    }

                    SetOSType(vmssResponse.VirtualMachineProfile);

                    this.VolumeType = GetVolumeType(this.VolumeType, vmssResponse.VirtualMachineProfile.StorageProfile);
                    VerifyVolumeType();

                    VirtualMachineScaleSetExtension parameters = GetVmssExtensionParameters();

                    if (vmssResponse.VirtualMachineProfile.ExtensionProfile == null)
                    {
                        vmssResponse.VirtualMachineProfile.ExtensionProfile = new VirtualMachineScaleSetExtensionProfile();
                    }

                    if (vmssResponse.VirtualMachineProfile.ExtensionProfile.Extensions == null)
                    {
                        vmssResponse.VirtualMachineProfile.ExtensionProfile.Extensions = new List<VirtualMachineScaleSetExtension>();
                    }

                    vmssResponse.VirtualMachineProfile.ExtensionProfile.Extensions.Add(parameters);

                    VirtualMachineScaleSetExtension result = this.VirtualMachineScaleSetExtensionsClient.CreateOrUpdate(
                        this.ResourceGroupName,
                        this.VMScaleSetName,
                        this.ExtensionName,
                        parameters);

                    var psResult = result.ToPSVirtualMachineScaleSetExtension(this.ResourceGroupName, this.VMScaleSetName);
                    WriteObject(psResult);
                }
            });
        }

        private void VerifyParameters()
        {
            if (this.DiskEncryptionKeyVaultId != null)
            {
                VerifyKeyVault(this.DiskEncryptionKeyVaultId);
            }

            if (this.KeyEncryptionKeyVaultId != null)
            {
                VerifyKeyVault(this.KeyEncryptionKeyVaultId);
            }
        }

        private void UpdateVmssEncryptionIdentityBeforeVerifyKeyVaultOperation()
        {
            bool updateEncryptionIdentity = UpdateVmssEncryptionIdentity();
            if (updateEncryptionIdentity)
            {
                this.WriteObject("Encryption identity updated successfully on VMSS.");
            }
        }

        private void VerifyKeyVault(string keyVaultId)
        {
            string regexString = @"/subscriptions/(?<subId>\S+)/resourceGroups/(?<rgName>\S+)/providers/Microsoft.KeyVault/vaults/(?<vaultName>\S+)(.*?)";
            Regex r = new Regex(regexString, RegexOptions.IgnoreCase);
            Match m = r.Match(keyVaultId);
            if (m.Success)
            {
                string sub = m.Groups["subId"].Value;
                string rg = m.Groups["rgName"].Value;
                string kv = m.Groups["vaultName"].Value;
                if (!string.IsNullOrWhiteSpace(sub) && sub.Equals(this.DefaultContext.Subscription.Id))
                {
                    IKeyVaultManagementClient keyVaultManagementFactory =
                        AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(
                            this.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);

                    var thisVmss = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, this.VMScaleSetName);

                    Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models.Vault returnedKeyVault = null;
                    try
                    {
                        returnedKeyVault = keyVaultManagementFactory.Vaults.Get(rg, kv);
                    }
                    catch
                    {
                        WriteWarning("Cannot access the given key vault.  Please check if 'enabledForDiskEncryption' of the key vault is set.");
                    }

                    if (returnedKeyVault == null)
                    {
                        WriteWarning("Cannot access the given key vault.  Please check if 'enabledForDiskEncryption' of the key vault is set.");
                    }

                    if (!returnedKeyVault.Location.Replace(" ", "").Equals(thisVmss.Location.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                    {
                        ThrowInvalidArgumentError("The location of key vault ID, {0}, does not match with the VM scale set.", keyVaultId);

                    }
                    if (this.EncryptionIdentity != null)
                    {
                        UpdateVmssEncryptionIdentityBeforeVerifyKeyVaultOperation();
                    }
                    
                    VirtualMachineScaleSet vmssResponse = this.VirtualMachineScaleSetClient.Get(this.ResourceGroupName, VMScaleSetName);
                    if (vmssResponse != null && vmssResponse.VirtualMachineProfile != null && vmssResponse.VirtualMachineProfile.SecurityProfile != null && 
                        vmssResponse.VirtualMachineProfile.SecurityProfile.EncryptionIdentity != null && 
                        vmssResponse.VirtualMachineProfile.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId != null)
                    {
                        return;
                    }
                    else if (returnedKeyVault.Properties == null
                        || returnedKeyVault.Properties.EnabledForDiskEncryption == null
                        || returnedKeyVault.Properties.EnabledForDiskEncryption.Value == false)
                    {
                        ThrowInvalidArgumentError("The EnabledForDiskEncryption flag of the key vault ID, {0}, is not set.", keyVaultId);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    ThrowInvalidArgumentError("The subscription ID of key vault ID, {0}, is incorrect.", keyVaultId);
                }
            }
            else
            {
                ThrowInvalidArgumentError("The format of key vault ID, {0}, is incorrect.", keyVaultId);
            }
        }

        private void VerifyVolumeType()
        {
            if (this.CurrentOSType == OperatingSystemTypes.Linux && this.VolumeType.Equals("OS"))
            {
                ThrowInvalidArgumentError("Only data disk encryption is supported for Linux VM Scale Set.", "");
            }
        }
    }
}
