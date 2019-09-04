---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/set-azvmss
schema: 2.0.0
---

# Set-AzVmss

## SYNOPSIS
Create or update a VM scale set.

## SYNTAX

```
Set-AzVmss -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-AutomaticOSUpgrade] [-DisableAutoRollback] [-DoNotRunExtensionsOnOverprovisionedVM]
 [-FaultDomainCount <Int32>] [-IdentityId <Hashtable>] [-IdentityType <ResourceIdentityType>]
 [-MaxBatchInstancePercent <Int32>] [-MaxUnhealthyInstancePercent <Int32>]
 [-MaxUnhealthyUpgradedInstancePercent <Int32>] [-Overprovision] [-PauseTimeBetweenBatches <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-ProximityPlacementGroupId <String>] [-SinglePlacementGroup] [-SkuCapacity <Int64>] [-SkuName <String>]
 [-SkuTier <String>] [-Tag <Hashtable>] [-UltraSsdEnabled] [-UpgradePolicyMode <UpgradeMode>]
 [-VirtualMachineProfile <IVirtualMachineScaleSetVMProfile>] [-Zone <String[]>] [-ZoneBalance]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a VM scale set.

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

### -AutomaticOSUpgrade
Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available.
Default value is false.


 If this is set to true for Windows based scale sets, [enableAutomaticUpdates](https://docs.microsoft.com/dotnet/api/microsoft.azure.management.compute.models.windowsconfiguration.enableautomaticupdatesview=azure-dotnet) is automatically set to false and cannot be set to true.

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

### -DisableAutoRollback
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

### -DoNotRunExtensionsOnOverprovisionedVM
When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept.
This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.

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

### -FaultDomainCount
Fault Domain count for each placement group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: PlatformFaultDomainCount

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityId
The list of user identities associated with the virtual machine scale set.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
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

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
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

### -ProximityPlacementGroupId
Resource Id

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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
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

### -UltraSsdEnabled
The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.
Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: EnableUltraSSD

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVMProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Zone
The virtual machine scale set zones.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ZoneBalance
Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### VIRTUALMACHINEPROFILE <IVirtualMachineScaleSetVMProfile>: The virtual machine profile.
  - `OSDiskCreateOption <DiskCreateOptionTypes>`: Specifies how the virtual machines in the scale set should be created.   The only allowed value is: **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
  - `[BillingProfileMaxPrice <Double?>]`: Specifies the maximum price you are willing to pay for a low priority VM/VMSS. This price is in US Dollars.    This price will be compared with the current low priority price for the VM size. Also, the prices are compared at the time of create/update of low priority VM/VMSS and the operation will only succeed if  the maxPrice is greater than the current low priority price.    The maxPrice will also be used for evicting a low priority VM/VMSS if the current low priority price goes beyond the maxPrice after creation of VM/VMSS.    Possible values are:    - Any decimal value greater than zero. Example: $0.01538    -1 – indicates default price to be up-to on-demand.    You can set the maxPrice to -1 to indicate that the low priority VM/VMSS should not be evicted for price reasons. Also, the default max price is -1 if it is not provided by you.   Minimum api-version: 2019-03-01.
  - `[BootDiagnosticEnabled <Boolean?>]`: Whether boot diagnostics should be enabled on the Virtual Machine.
  - `[BootDiagnosticStorageUri <String>]`: Uri of the storage account to use for placing the console output and screenshot.
  - `[DiffDiskSettingOption <DiffDiskOptions?>]`: Specifies the ephemeral disk settings for operating system disk.
  - `[EvictionPolicy <VirtualMachineEvictionPolicyTypes?>]`: Specifies the eviction policy for virtual machines in a low priority scale set.   Minimum api-version: 2017-10-30-preview
  - `[ExtensionProfileExtension <IVirtualMachineScaleSetExtension[]>]`: The virtual machine scale set child extension resources.
    - `[AutoUpgradeMinorVersion <Boolean?>]`: Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
    - `[ExtensionName <String>]`: The name of the extension.
    - `[ForceUpdateTag <String>]`: If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
    - `[ProtectedSetting <IVirtualMachineScaleSetExtensionPropertiesProtectedSettings>]`: The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    - `[ProvisionAfterExtension <String[]>]`: Collection of extension names after which this extension needs to be provisioned.
    - `[Publisher <String>]`: The name of the extension handler publisher.
    - `[Setting <IVirtualMachineScaleSetExtensionPropertiesSettings>]`: Json formatted public settings for the extension.
    - `[Type <String>]`: Specifies the type of the extension; an example is "CustomScriptExtension".
    - `[TypeHandlerVersion <String>]`: Specifies the version of the script handler.
  - `[HealthProbeId <String>]`: The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
  - `[ImageReferenceId <String>]`: Resource Id
  - `[ImageReferenceOffer <String>]`: Specifies the offer of the platform image or marketplace image used to create the virtual machine.
  - `[ImageReferencePublisher <String>]`: The image publisher.
  - `[ImageReferenceSku <String>]`: The image SKU.
  - `[ImageReferenceVersion <String>]`: Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or 'latest'. Major, Minor, and Build are decimal numbers. Specify 'latest' to use the latest version of an image available at deploy time. Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.
  - `[ImageUri <String>]`: Specifies the virtual hard disk's uri.
  - `[LicenseType <String>]`: Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system.    Possible values are:    Windows_Client    Windows_Server    If this element is included in a request for an update, the value must match the initial value. This value cannot be updated.    For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json)    Minimum api-version: 2015-06-15
  - `[LinuxConfigurationDisablePasswordAuthentication <Boolean?>]`: Specifies whether password authentication should be disabled.
  - `[LinuxConfigurationProvisionVMAgent <Boolean?>]`: Indicates whether virtual machine agent should be provisioned on the virtual machine.    When this property is not specified in the request body, default behavior is to set it to true.  This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.
  - `[LinuxConfigurationSshPublicKey <ISshPublicKey[]>]`: The list of SSH public keys used to authenticate with linux based VMs.
    - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
    - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
  - `[ManagedDiskStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
  - `[NetworkProfileNetworkInterfaceConfiguration <IVirtualMachineScaleSetNetworkConfiguration[]>]`: The list of network configurations.
    - `IPConfiguration <IVirtualMachineScaleSetIPConfiguration[]>`: Specifies the IP configurations of the network interface.
      - `DnsSettingDomainNameLabel <String>`: The Domain name label.The concatenation of the domain name label and vm index will be the domain name labels of the PublicIPAddress resources that will be created
      - `Name <String>`: The IP configuration name.
      - `PublicIPAddressConfigurationName <String>`: The publicIP address configuration name.
      - `[Id <String>]`: Resource Id
      - `[ApplicationGatewayBackendAddressPool <ISubResource[]>]`: Specifies an array of references to backend address pools of application gateways. A scale set can reference backend address pools of multiple application gateways. Multiple scale sets cannot use the same application gateway.
        - `[Id <String>]`: Resource Id
      - `[ApplicationSecurityGroup <ISubResource[]>]`: Specifies an array of references to application security group.
      - `[IPTag <IVirtualMachineScaleSetIPTag[]>]`: The list of IP tags associated with the public IP address.
        - `[IPTagType <String>]`: IP tag type. Example: FirstPartyUsage.
        - `[Tag <String>]`: IP tag associated with the public IP. Example: SQL, Storage etc.
      - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
      - `[LoadBalancerBackendAddressPool <ISubResource[]>]`: Specifies an array of references to backend address pools of load balancers. A scale set can reference backend address pools of one public and one internal load balancer. Multiple scale sets cannot use the same load balancer.
      - `[LoadBalancerInboundNatPool <ISubResource[]>]`: Specifies an array of references to inbound Nat pools of the load balancers. A scale set can reference inbound nat pools of one public and one internal load balancer. Multiple scale sets cannot use the same load balancer
      - `[Primary <Boolean?>]`: Specifies the primary network interface in case the virtual machine has more than 1 network interface.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
      - `[PublicIPPrefixId <String>]`: Resource Id
      - `[SubnetId <String>]`: The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
    - `Name <String>`: The network configuration name.
    - `[Id <String>]`: Resource Id
    - `[DnsSettingDnsServer <String[]>]`: List of DNS servers IP addresses
    - `[EnableAcceleratedNetworking <Boolean?>]`: Specifies whether the network interface is accelerated networking-enabled.
    - `[EnableIPForwarding <Boolean?>]`: Whether IP forwarding enabled on this NIC.
    - `[NetworkSecurityGroupId <String>]`: Resource Id
    - `[Primary <Boolean?>]`: Specifies the primary network interface in case the virtual machine has more than 1 network interface.
  - `[OSDiskCaching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
  - `[OSDiskName <String>]`: The disk name.
  - `[OSDiskOstype <OperatingSystemTypes?>]`: This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD.    Possible values are:    **Windows**    **Linux**
  - `[OSDiskSizeInGb <Int32?>]`: Specifies the size of the operating system disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
  - `[OSDiskVhdContainer <String[]>]`: Specifies the container urls that are used to store operating system disks for the scale set.
  - `[OSDiskWriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.
  - `[OSProfileAdminPassword <String>]`: Specifies the password of the administrator account.    **Minimum-length (Windows):** 8 characters    **Minimum-length (Linux):** 6 characters    **Max-length (Windows):** 123 characters    **Max-length (Linux):** 72 characters    **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled   Has lower characters  Has upper characters   Has a digit   Has a special character (Regex match [\W_])    **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"    For resetting the password, see [How to reset the Remote Desktop service or its login password in a Windows VM](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-reset-rdp?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json)    For resetting root password, see [Manage users, SSH, and check or repair disks on Azure Linux VMs using the VMAccess Extension](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-vmaccess-extension?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#reset-root-password)
  - `[OSProfileAdminUsername <String>]`: Specifies the name of the administrator account.    **Windows-only restriction:** Cannot end in "."    **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".    **Minimum-length (Linux):** 1  character    **Max-length (Linux):** 64 characters    **Max-length (Windows):** 20 characters    <li> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) <li> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
  - `[OSProfileComputerNamePrefix <String>]`: Specifies the computer name prefix for all of the virtual machines in the scale set. Computer name prefixes must be 1 to 15 characters long.
  - `[OSProfileCustomData <String>]`: Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the Virtual Machine. The maximum length of the binary array is 65535 bytes.    For using cloud-init for your VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
  - `[OSProfileSecret <IVaultSecretGroup[]>]`: Specifies set of certificates that should be installed onto the virtual machines in the scale set.
    - `[SourceVaultId <String>]`: Resource Id
    - `[VaultCertificate <IVaultCertificate[]>]`: The list of key vault references in SourceVault which contain certificates.
      - `[CertificateStore <String>]`: For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account.   For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.
      - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8:    {   "data":"<Base64-encoded-certificate>",   "dataType":"pfx",   "password":"<pfx-file-password>" }
  - `[Priority <VirtualMachinePriorityTypes?>]`: Specifies the priority for the virtual machines in the scale set.   Minimum api-version: 2017-10-30-preview
  - `[StorageProfileDataDisk <IVirtualMachineScaleSetDataDisk[]>]`: Specifies the parameters that are used to add data disks to the virtual machines in the scale set.    For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
    - `CreateOption <DiskCreateOptionTypes>`: The create option.
    - `Lun <Int32>`: Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
    - `[Caching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
    - `[ManagedStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
    - `[Name <String>]`: The disk name.
    - `[SizeInGb <Int32?>]`: Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
    - `[WriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.
  - `[TerminateNotificationProfileEnable <Boolean?>]`: Specifies whether the Terminate Scheduled event is enabled or disabled.
  - `[TerminateNotificationProfileNotBeforeTimeout <String>]`: Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M)
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

