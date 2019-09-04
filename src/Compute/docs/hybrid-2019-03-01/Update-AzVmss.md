---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azvmss
schema: 2.0.0
---

# Update-AzVmss

## SYNOPSIS
Update a VM scale set.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzVmss -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AutoOSUpgradePolicyDisableAutoRollback] [-IdentityId <String[]>] [-IdentityType <ResourceIdentityType>]
 [-MaxBatchInstancePercent <Int32>] [-MaxUnhealthyInstancePercent <Int32>]
 [-MaxUnhealthyUpgradedInstancePercent <Int32>] [-Overprovision] [-PauseTimeBetweenBatches <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-SinglePlacementGroup] [-SkuCapacity <Int64>] [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-UpgradePolicyAutomaticOSUpgrade] [-UpgradePolicyMode <UpgradeMode>]
 [-VirtualMachineProfile <IVirtualMachineScaleSetUpdateVMProfile>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVmss -InputObject <IComputeIdentity> [-AutoOSUpgradePolicyDisableAutoRollback]
 [-IdentityId <String[]>] [-IdentityType <ResourceIdentityType>] [-MaxBatchInstancePercent <Int32>]
 [-MaxUnhealthyInstancePercent <Int32>] [-MaxUnhealthyUpgradedInstancePercent <Int32>] [-Overprovision]
 [-PauseTimeBetweenBatches <String>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-SinglePlacementGroup] [-SkuCapacity <Int64>]
 [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-UpgradePolicyAutomaticOSUpgrade]
 [-UpgradePolicyMode <UpgradeMode>] [-VirtualMachineProfile <IVirtualMachineScaleSetUpdateVMProfile>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a VM scale set.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoOSUpgradePolicyDisableAutoRollback
Whether OS image rollback feature should be disabled.
Default value is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityId
The list of user identities associated with the virtual machine scale set.
The user identity references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: UserAssignedIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The type of identity used for the virtual machine scale set.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the virtual machine scale set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -MaxBatchInstancePercent
The maximum percent of total virtual machine instances that will be upgraded simultaneously by the rolling upgrade in one batch.
As this is a maximum, unhealthy instances in previous or future batches can cause the percentage of instances in a batch to decrease to ensure higher reliability.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxUnhealthyInstancePercent
The maximum percentage of the total virtual machine instances in the scale set that can be simultaneously unhealthy, either as a result of being upgraded, or by being found in an unhealthy state by the virtual machine health checks before the rolling upgrade aborts.
This constraint will be checked prior to starting any batch.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxUnhealthyUpgradedInstancePercent
The maximum percentage of upgraded virtual machine instances that can be found to be in an unhealthy state.
This check will happen after each batch is upgraded.
If this percentage is ever exceeded, the rolling update aborts.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the VM scale set to create or update.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: VMScaleSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Overprovision
Specifies whether the Virtual Machine Scale Set should be overprovisioned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PauseTimeBetweenBatches
The wait time between completing the update for all virtual machines in one batch and starting the next batch.
The time duration should be specified in ISO 8601 format.
The default value is 0 seconds (PT0S).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanName
The plan ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanProduct
Specifies the product of the image from the marketplace.
This is the same value as Offer under the imageReference element.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SinglePlacementGroup
When true this limits the scale set to a single placement group, of max size 100 virtual machines.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
Specifies the number of virtual machines in the scale set.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The sku name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
Specifies the tier of virtual machines in a scale set.\<br /\>\<br /\> Possible Values:\<br /\>\<br /\> **Standard**\<br /\>\<br /\> **Basic**

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UpgradePolicyAutomaticOSUpgrade
Whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the image becomes available.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UpgradePolicyMode
Specifies the mode of an upgrade to virtual machines in the scale set.\<br /\>\<br /\> Possible values are:\<br /\>\<br /\> **Manual** - You control the application of updates to virtual machines in the scale set.
You do this by using the manualUpgrade action.\<br /\>\<br /\> **Automatic** - All virtual machines in the scale set are automatically updated at the same time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.UpgradeMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualMachineProfile
The virtual machine profile.
To construct, see NOTES section for VIRTUALMACHINEPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetUpdateVMProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSet

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IComputeIdentity>: Identity Parameter
  - `[AvailabilitySetName <String>]`: The name of the availability set.
  - `[CommandId <String>]`: The command id.
  - `[DiskName <String>]`: The name of the managed disk that is being created. The name can't be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters.
  - `[GalleryApplicationName <String>]`: The name of the gallery Application Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryApplicationVersionName <String>]`: The name of the gallery Application Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryImageDefinitionName <String>]`: The name of the gallery Image Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryImageVersionName <String>]`: The name of the gallery Image Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryName <String>]`: The name of the Shared Image Gallery. The allowed characters are alphabets and numbers with dots and periods allowed in the middle. The maximum length is 80 characters.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[InstanceId <String>]`: The instance ID of the virtual machine.
  - `[Location <String>]`: The name of a supported Azure region.
  - `[Offer <String>]`: A valid image publisher offer.
  - `[ProximityPlacementGroupName <String>]`: The name of the proximity placement group.
  - `[PublisherName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[Sku <String>]`: A valid image SKU.
  - `[SnapshotName <String>]`: The name of the snapshot that is being created. The name can't be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[Type <String>]`: 
  - `[VMExtensionName <String>]`: The name of the virtual machine extension.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VMScaleSetName <String>]`: The name of the VM scale set.
  - `[Version <String>]`: 
  - `[VirtualMachineScaleSetName <String>]`: The name of the VM scale set.
  - `[VmssExtensionName <String>]`: The name of the VM scale set extension.

#### VIRTUALMACHINEPROFILE <IVirtualMachineScaleSetUpdateVMProfile>: The virtual machine profile.
  - `[BootDiagnosticEnabled <Boolean?>]`: Whether boot diagnostics should be enabled on the Virtual Machine.
  - `[BootDiagnosticStorageUri <String>]`: Uri of the storage account to use for placing the console output and screenshot.
  - `[ExtensionProfileExtension <IVirtualMachineScaleSetExtension[]>]`: The virtual machine scale set child extension resources.
    - `[AutoUpgradeMinorVersion <Boolean?>]`: Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
    - `[ExtensionName <String>]`: The name of the extension.
    - `[ForceUpdateTag <String>]`: If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
    - `[ProtectedSetting <IVirtualMachineScaleSetExtensionPropertiesProtectedSettings>]`: The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    - `[Publisher <String>]`: The name of the extension handler publisher.
    - `[Setting <IVirtualMachineScaleSetExtensionPropertiesSettings>]`: Json formatted public settings for the extension.
    - `[Type <String>]`: Specifies the type of the extension; an example is "CustomScriptExtension".
    - `[TypeHandlerVersion <String>]`: Specifies the version of the script handler.
  - `[ImageReferenceId <String>]`: Resource Id
  - `[ImageReferenceOffer <String>]`: Specifies the offer of the platform image or marketplace image used to create the virtual machine.
  - `[ImageReferencePublisher <String>]`: The image publisher.
  - `[ImageReferenceSku <String>]`: The image SKU.
  - `[ImageReferenceVersion <String>]`: Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or 'latest'. Major, Minor, and Build are decimal numbers. Specify 'latest' to use the latest version of an image available at deploy time. Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.
  - `[ImageUri <String>]`: Specifies the virtual hard disk's uri.
  - `[LicenseType <String>]`: The license type, which is for bring your own license scenario.
  - `[LinuxConfigurationDisablePasswordAuthentication <Boolean?>]`: Specifies whether password authentication should be disabled.
  - `[ManagedDiskStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
  - `[NetworkProfileNetworkInterfaceConfiguration <IVirtualMachineScaleSetUpdateNetworkConfiguration[]>]`: The list of network configurations.
    - `[Id <String>]`: Resource Id
    - `[DnsSettingDnsServer <String[]>]`: List of DNS servers IP addresses
    - `[EnableAcceleratedNetworking <Boolean?>]`: Specifies whether the network interface is accelerated networking-enabled.
    - `[EnableIPForwarding <Boolean?>]`: Whether IP forwarding enabled on this NIC.
    - `[IPConfiguration <IVirtualMachineScaleSetUpdateIPConfiguration[]>]`: The virtual machine scale set IP Configuration.
      - `DnsSettingDomainNameLabel <String>`: The Domain name label.The concatenation of the domain name label and vm index will be the domain name labels of the PublicIPAddress resources that will be created
      - `[Id <String>]`: Resource Id
      - `[ApplicationGatewayBackendAddressPool <ISubResource[]>]`: The application gateway backend address pools.
        - `[Id <String>]`: Resource Id
      - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
      - `[LoadBalancerBackendAddressPool <ISubResource[]>]`: The load balancer backend address pools.
      - `[LoadBalancerInboundNatPool <ISubResource[]>]`: The load balancer inbound nat pools.
      - `[Name <String>]`: The IP configuration name.
      - `[Primary <Boolean?>]`: Specifies the primary IP Configuration in case the network interface has more than one IP Configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
      - `[PublicIPAddressConfigurationName <String>]`: The publicIP address configuration name.
      - `[SubnetId <String>]`: The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
    - `[Name <String>]`: The network configuration name.
    - `[NetworkSecurityGroupId <String>]`: Resource Id
    - `[Primary <Boolean?>]`: Whether this is a primary NIC on a virtual machine.
  - `[OSDiskCaching <CachingTypes?>]`: The caching type.
  - `[OSDiskVhdContainer <String[]>]`: The list of virtual hard disk container uris.
  - `[OSDiskWriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.
  - `[OSProfileCustomData <String>]`: A base-64 encoded string of custom data.
  - `[OSProfileSecret <IVaultSecretGroup[]>]`: The List of certificates for addition to the VM.
    - `[SourceVaultId <String>]`: Resource Id
    - `[VaultCertificate <IVaultCertificate[]>]`: The list of key vault references in SourceVault which contain certificates.
      - `[CertificateStore <String>]`: For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account.   For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.
      - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8:    {   "data":"<Base64-encoded-certificate>",   "dataType":"pfx",   "password":"<pfx-file-password>" }
  - `[SshPublicKey <ISshPublicKey[]>]`: The list of SSH public keys used to authenticate with linux based VMs.
    - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
    - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
  - `[StorageProfileDataDisk <IVirtualMachineScaleSetDataDisk[]>]`: The data disks.
    - `CreateOption <DiskCreateOptionTypes>`: The create option.
    - `Lun <Int32>`: Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
    - `[Caching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
    - `[ManagedStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
    - `[Name <String>]`: The disk name.
    - `[SizeInGb <Int32?>]`: Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
    - `[WriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.
  - `[WinRmListener <IWinRmListener[]>]`: The list of Windows Remote Management listeners
    - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8:    {   "data":"<Base64-encoded-certificate>",   "dataType":"pfx",   "password":"<pfx-file-password>" }
    - `[Protocol <ProtocolTypes?>]`: Specifies the protocol of listener.    Possible values are:  **http**    **https**
  - `[WindowConfigurationAdditionalUnattendContent <IAdditionalUnattendContent[]>]`: Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.
    - `[ComponentName <ComponentNames?>]`: The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
    - `[Content <String>]`: Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted.
    - `[PassName <PassNames?>]`: The pass name. Currently, the only allowable value is OobeSystem.
    - `[SettingName <SettingNames?>]`: Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.
  - `[WindowConfigurationEnableAutomaticUpdate <Boolean?>]`: Indicates whether Automatic Updates is enabled for the Windows virtual machine. Default value is true.    For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning.
  - `[WindowConfigurationProvisionVMAgent <Boolean?>]`: Indicates whether virtual machine agent should be provisioned on the virtual machine.    When this property is not specified in the request body, default behavior is to set it to true.  This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.
  - `[WindowConfigurationTimeZone <String>]`: Specifies the time zone of the virtual machine. e.g. "Pacific Standard Time"

## RELATED LINKS

