---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/set-azstackhcivmvirtualmachine
schema: 2.0.0
---

# Set-AzStackHciVMVirtualMachine

## SYNOPSIS
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## SYNTAX

```
Set-AzStackHciVMVirtualMachine -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-DynamicMemoryConfigMaximumMemoryMb <Int64>]
 [-DynamicMemoryConfigMinimumMemoryMb <Int64>] [-DynamicMemoryConfigTargetMemoryBuffer <Int32>]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <ExtendedLocationTypes>]
 [-HardwareProfileMemoryMb <Int64>] [-HardwareProfileProcessor <Int32>] [-HardwareProfileVMSize <VMSizeEnum>]
 [-IdentityType <ResourceIdentityType>] [-ImageReferenceId <String>]
 [-LinuxConfigurationDisablePasswordAuthentication] [-LinuxConfigurationProvisionVMAgent]
 [-LinuxConfigurationSshPublicKey <IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]>]
 [-NetworkProfileNetworkInterface <IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[]>]
 [-OSDiskId <String>] [-OSProfileAdminPassword <String>] [-OSProfileAdminUsername <String>]
 [-OSProfileComputerName <String>] [-OSProfileOstype <OSTypeEnum>] [-SecurityProfileEnableTpm]
 [-StorageProfileDataDisk <IVirtualMachinePropertiesStorageProfileDataDisksItem[]>]
 [-StorageProfileVMConfigStoragePathId <String>] [-Tag <Hashtable>] [-UefiSettingSecureBootEnabled]
 [-WindowConfigurationEnableAutomaticUpdate] [-WindowConfigurationProvisionVMAgent]
 [-WindowConfigurationTimeZone <String>]
 [-WindowsConfigurationSshPublicKey <IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
```

### -DynamicMemoryConfigMaximumMemoryMb
.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMemoryConfigMinimumMemoryMb
.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMemoryConfigTargetMemoryBuffer
Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total memory that the virtual machine is thought to need.
This only applies to virtual systems with dynamic memory enabled.
This property can be in the range of 5 to 2000.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileMemoryMb
RAM in MB for the virtual machine

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileProcessor
number of processors for the virtual machine

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileVMSize
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageReferenceId
Resource ID of the image

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxConfigurationDisablePasswordAuthentication
DisablePasswordAuthentication - whether password authentication should be disabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxConfigurationProvisionVMAgent
Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxConfigurationSshPublicKey
PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
To construct, see NOTES section for LINUXCONFIGURATIONSSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the virtual machine

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualMachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileNetworkInterface
NetworkInterfaces - list of network interfaces to be attached to the virtual machine
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -OSDiskId
Resource ID of the OS disk

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileAdminPassword
AdminPassword - admin password

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileAdminUsername
AdminUsername - admin username

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileComputerName
ComputerName - name of the compute

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileOstype
OsType - string specifying whether the OS is Linux or Windows

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityProfileEnableTpm
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileDataDisk
adds data disks to the virtual machine
To construct, see NOTES section for STORAGEPROFILEDATADISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileVMConfigStoragePathId
Id of the storage container that hosts the VM configuration file

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UefiSettingSecureBootEnabled
Specifies whether secure boot should be enabled on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowConfigurationEnableAutomaticUpdate
Whether to EnableAutomaticUpdates on the machine

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowConfigurationProvisionVMAgent
Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowConfigurationTimeZone
TimeZone for the virtual machine

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowsConfigurationSshPublicKey
PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
To construct, see NOTES section for WINDOWSCONFIGURATIONSSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachines

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`LINUXCONFIGURATIONSSHPUBLICKEY <IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]>`: PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
  - `[KeyData <String>]`: KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Li      nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[Path <String>]`: Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

`NETWORKPROFILENETWORKINTERFACE <IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[]>`: NetworkInterfaces - list of network interfaces to be attached to the virtual machine
  - `[Id <String>]`: ID - Resource Id of the network interface

`STORAGEPROFILEDATADISK <IVirtualMachinePropertiesStorageProfileDataDisksItem[]>`: adds data disks to the virtual machine
  - `[Id <String>]`: Resource ID of the data disk

`WINDOWSCONFIGURATIONSSHPUBLICKEY <IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]>`: PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
  - `[KeyData <String>]`: KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Li      nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[Path <String>]`: Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

## RELATED LINKS

