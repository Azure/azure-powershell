---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/set-azvm
schema: 2.0.0
---

# Set-AzVM

## SYNOPSIS
The operation to create or update a virtual machine.

## SYNTAX

```
Set-AzVM -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-AvailabilitySetId <String>] [-BootDiagnosticEnabled] [-BootDiagnosticStorageUri <String>]
 [-DataDisk <IDataDisk[]>] [-IdentityId <Hashtable>] [-IdentityType <ResourceIdentityType>]
 [-ImageReferenceId <String>] [-ImageReferenceOffer <String>] [-ImageReferencePublisher <String>]
 [-ImageReferenceSku <String>] [-ImageReferenceVersion <String>] [-LicenseType <String>]
 [-LinuxConfigurationDisablePasswordAuthentication] [-LinuxConfigurationProvisionVMAgent]
 [-LinuxConfigurationSshPublicKey <ISshPublicKey[]>] [-NetworkInterface <INetworkInterfaceReference[]>]
 [-OSDisk <IOSDisk>] [-OSProfileAdminPassword <String>] [-OSProfileAdminUsername <String>]
 [-OSProfileAllowExtensionOperation] [-OSProfileComputerName <String>] [-OSProfileCustomData <String>]
 [-OSProfileSecret <IVaultSecretGroup[]>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-ProximityPlacementGroupId <String>]
 [-Size <VirtualMachineSizeTypes>] [-Tag <Hashtable>] [-UltraSsdEnabled]
 [-WindowConfigurationAdditionalUnattendContent <IAdditionalUnattendContent[]>]
 [-WindowConfigurationEnableAutomaticUpdate] [-WindowConfigurationProvisionVMAgent]
 [-WindowConfigurationTimeZone <String>] [-WinRmListener <IWinRmListener[]>] [-Zone <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a virtual machine.

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

### -AvailabilitySetId
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

### -BootDiagnosticEnabled
Whether boot diagnostics should be enabled on the Virtual Machine.

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

### -BootDiagnosticStorageUri
Uri of the storage account to use for placing the console output and screenshot.

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

### -DataDisk
Specifies the parameters that are used to add a data disk to a virtual machine.


 For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
To construct, see NOTES section for DATADISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IDataDisk[]
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
The list of user identities associated with the Virtual Machine.
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
The type of identity used for the virtual machine.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the virtual machine.

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

### -ImageReferenceId
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

### -ImageReferenceOffer
Specifies the offer of the platform image or marketplace image used to create the virtual machine.

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

### -ImageReferencePublisher
The image publisher.

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

### -ImageReferenceSku
The image SKU.

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

### -ImageReferenceVersion
Specifies the version of the platform image or marketplace image used to create the virtual machine.
The allowed formats are Major.Minor.Build or 'latest'.
Major, Minor, and Build are decimal numbers.
Specify 'latest' to use the latest version of an image available at deploy time.
Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.

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

### -LicenseType
Specifies that the image or disk that is being used was licensed on-premises.
This element is only used for images that contain the Windows Server operating system.


 Possible values are: 

 Windows_Client 

 Windows_Server 

 If this element is included in a request for an update, the value must match the initial value.
This value cannot be updated.


 For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensingtoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) 

 Minimum api-version: 2015-06-15

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

### -LinuxConfigurationDisablePasswordAuthentication
Specifies whether password authentication should be disabled.

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

### -LinuxConfigurationProvisionVMAgent
Indicates whether virtual machine agent should be provisioned on the virtual machine.


 When this property is not specified in the request body, default behavior is to set it to true.
This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.

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

### -LinuxConfigurationSshPublicKey
The list of SSH public keys used to authenticate with linux based VMs.
To construct, see NOTES section for LINUXCONFIGURATIONSSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.ISshPublicKey[]
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

### -Name
The name of the virtual machine.

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

### -NetworkInterface
Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
To construct, see NOTES section for NETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.INetworkInterfaceReference[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -OSDisk
Specifies information about the operating system disk used by the virtual machine.


 For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
To construct, see NOTES section for OSDISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IOSDisk
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSProfileAdminPassword
Specifies the password of the administrator account.


 **Minimum-length (Windows):** 8 characters 

 **Minimum-length (Linux):** 6 characters 

 **Max-length (Windows):** 123 characters 

 **Max-length (Linux):** 72 characters 

 **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled 
 Has lower characters 
Has upper characters 
 Has a digit 
 Has a special character (Regex match [\W_]) 

 **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!" 

 For resetting the password, see [How to reset the Remote Desktop service or its login password in a Windows VM](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-reset-rdptoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) 

 For resetting root password, see [Manage users, SSH, and check or repair disks on Azure Linux VMs using the VMAccess Extension](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-vmaccess-extensiontoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#reset-root-password)

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

### -OSProfileAdminUsername
Specifies the name of the administrator account.


 **Windows-only restriction:** Cannot end in "." 

 **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".


 **Minimum-length (Linux):** 1 character 

 **Max-length (Linux):** 64 characters 

 **Max-length (Windows):** 20 characters 

\<li\> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privilegestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
\<li\> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernamestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)

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

### -OSProfileAllowExtensionOperation
Specifies whether extension operations should be allowed on the virtual machine.


This may only be set to False when no extensions are present on the virtual machine.

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

### -OSProfileComputerName
Specifies the host OS name of the virtual machine.


 This name cannot be updated after the VM is created.


 **Max-length (Windows):** 15 characters 

 **Max-length (Linux):** 64 characters.


 For naming conventions and restrictions see [Azure infrastructure services implementation guidelines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-infrastructure-subscription-accounts-guidelinestoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#1-naming-conventions).

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

### -OSProfileCustomData
Specifies a base-64 encoded string of custom data.
The base-64 encoded string is decoded to a binary array that is saved as a file on the Virtual Machine.
The maximum length of the binary array is 65535 bytes.


 For using cloud-init for your VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-inittoc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)

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

### -OSProfileSecret
Specifies set of certificates that should be installed onto the virtual machine.
To construct, see NOTES section for OSPROFILESECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVaultSecretGroup[]
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

### -Size
Specifies the size of the virtual machine.
For more information about virtual machine sizes, see [Sizes for virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-sizestoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).


 The available VM sizes depend on region and availability set.
For a list of available sizes use these APIs: 

 [List all available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/availabilitysets/listavailablesizes) 

 [List all available virtual machine sizes in a region](https://docs.microsoft.com/rest/api/compute/virtualmachinesizes/list) 

 [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.VirtualMachineSizeTypes
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

### -WindowConfigurationAdditionalUnattendContent
Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.
To construct, see NOTES section for WINDOWCONFIGURATIONADDITIONALUNATTENDCONTENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IAdditionalUnattendContent[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowConfigurationEnableAutomaticUpdate
Indicates whether virtual machine is enabled for automatic Windows updates.
Default value is true.


 For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning.

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

### -WindowConfigurationProvisionVMAgent
Indicates whether virtual machine agent should be provisioned on the virtual machine.


 When this property is not specified in the request body, default behavior is to set it to true.
This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.

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

### -WindowConfigurationTimeZone
Specifies the time zone of the virtual machine.
e.g.
"Pacific Standard Time"

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

### -WinRmListener
The list of Windows Remote Management listeners
To construct, see NOTES section for WINRMLISTENER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IWinRmListener[]
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
The virtual machine zones.

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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachine

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DATADISK <IDataDisk[]>: Specifies the parameters that are used to add a data disk to a virtual machine.    For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
  - `CreateOption <DiskCreateOptionTypes>`: Specifies how the virtual machine should be created.   Possible values are:   **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.   **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
  - `Lun <Int32>`: Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
  - `[Caching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
  - `[ImageUri <String>]`: Specifies the virtual hard disk's uri.
  - `[ManagedId <String>]`: Resource Id
  - `[ManagedStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
  - `[Name <String>]`: The disk name.
  - `[SizeInGb <Int32?>]`: Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
  - `[ToBeDetached <Boolean?>]`: Specifies whether the datadisk is in process of detachment from the VirtualMachine/VirtualMachineScaleset
  - `[VhdUri <String>]`: Specifies the virtual hard disk's uri.
  - `[WriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.

#### LINUXCONFIGURATIONSSHPUBLICKEY <ISshPublicKey[]>: The list of SSH public keys used to authenticate with linux based VMs.
  - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

#### NETWORKINTERFACE <INetworkInterfaceReference[]>: Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
  - `[Id <String>]`: Resource Id
  - `[Primary <Boolean?>]`: Specifies the primary network interface in case the virtual machine has more than 1 network interface.

#### OSDISK <IOSDisk>: Specifies information about the operating system disk used by the virtual machine.    For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
  - `CreateOption <DiskCreateOptionTypes>`: Specifies how the virtual machine should be created.   Possible values are:   **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.   **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
  - `EncryptionKeySecretUrl <String>`: The URL referencing a secret in a Key Vault.
  - `KeyEncryptionKeyUrl <String>`: The URL referencing a key encryption key in Key Vault.
  - `[Caching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
  - `[DiffSettingOption <DiffDiskOptions?>]`: Specifies the ephemeral disk settings for operating system disk.
  - `[EncryptionKeySourceVaultId <String>]`: Resource Id
  - `[EncryptionSettingEnabled <Boolean?>]`: Specifies whether disk encryption should be enabled on the virtual machine.
  - `[ImageUri <String>]`: Specifies the virtual hard disk's uri.
  - `[KeyEncryptionKeySourceVaultId <String>]`: Resource Id
  - `[ManagedId <String>]`: Resource Id
  - `[ManagedStorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
  - `[Name <String>]`: The disk name.
  - `[OSType <OperatingSystemTypes?>]`: This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD.    Possible values are:    **Windows**    **Linux**
  - `[SizeInGb <Int32?>]`: Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
  - `[VhdUri <String>]`: Specifies the virtual hard disk's uri.
  - `[WriteAcceleratorEnabled <Boolean?>]`: Specifies whether writeAccelerator should be enabled or disabled on the disk.

#### OSPROFILESECRET <IVaultSecretGroup[]>: Specifies set of certificates that should be installed onto the virtual machine.
  - `[SourceVaultId <String>]`: Resource Id
  - `[VaultCertificate <IVaultCertificate[]>]`: The list of key vault references in SourceVault which contain certificates.
    - `[CertificateStore <String>]`: For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account.   For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.
    - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8:    {   "data":"<Base64-encoded-certificate>",   "dataType":"pfx",   "password":"<pfx-file-password>" }

#### WINDOWCONFIGURATIONADDITIONALUNATTENDCONTENT <IAdditionalUnattendContent[]>: Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.
  - `[ComponentName <ComponentNames?>]`: The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
  - `[Content <String>]`: Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted.
  - `[PassName <PassNames?>]`: The pass name. Currently, the only allowable value is OobeSystem.
  - `[SettingName <SettingNames?>]`: Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.

#### WINRMLISTENER <IWinRmListener[]>: The list of Windows Remote Management listeners
  - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8:    {   "data":"<Base64-encoded-certificate>",   "dataType":"pfx",   "password":"<pfx-file-password>" }
  - `[Protocol <ProtocolTypes?>]`: Specifies the protocol of listener.    Possible values are:  **http**    **https**

## RELATED LINKS

