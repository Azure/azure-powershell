---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/update-azconnectedvmwarevm
schema: 2.0.0
---

# Update-AzConnectedVMwareVM

## SYNOPSIS
API to update certain properties of the virtual machine resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedVMwareVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-HardwareProfileMemorySizeMb <Int32>] [-HardwareProfileNumCoresPerSocket <Int32>]
 [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>]
 [-NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>] [-StorageProfileDisk <IVirtualDiskUpdate[]>]
 [-Tag <Hashtable>] [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedVMwareVM -InputObject <IConnectedVMwareIdentity> [-HardwareProfileMemorySizeMb <Int32>]
 [-HardwareProfileNumCoresPerSocket <Int32>] [-HardwareProfileNumCpUs <Int32>] [-IdentityType <IdentityType>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>]
 [-NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>] [-StorageProfileDisk <IVirtualDiskUpdate[]>]
 [-Tag <Hashtable>] [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API to update certain properties of the virtual machine resource.

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

### -HardwareProfileMemorySizeMb
Gets or sets memory size in MBs for the vm.

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

### -HardwareProfileNumCoresPerSocket
Gets or sets the number of cores per socket for the vm.
Defaults to 1 if unspecified.

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

### -HardwareProfileNumCpUs
Gets or sets the number of vCPUs for the vm.

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

### -IdentityType
The type of managed service identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.IdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinuxConfigurationPatchSettingsAssessmentMode
Specifies the assessment mode.

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

### -LinuxConfigurationPatchSettingsPatchMode
Specifies the patch mode.

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

### -Name
Name of the virtual machine resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: VirtualMachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileNetworkInterface
Gets or sets the list of network interfaces associated with the virtual machine.
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.INetworkInterfaceUpdate[]
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

### -ResourceGroupName
The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileDisk
Gets or sets the list of virtual disks associated with the virtual machine.
To construct, see NOTES section for STORAGEPROFILEDISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IVirtualDiskUpdate[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets the Resource tags.

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

### -WindowsConfigurationPatchSettingsAssessmentMode
Specifies the assessment mode.

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

### -WindowsConfigurationPatchSettingsPatchMode
Specifies the patch mode.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IVirtualMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IConnectedVMwareIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: Name of the cluster.
  - `[DatastoreName <String>]`: Name of the datastore.
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[HostName <String>]`: Name of the host.
  - `[Id <String>]`: Resource identity path
  - `[InventoryItemName <String>]`: Name of the inventoryItem.
  - `[MetadataName <String>]`: Name of the hybridIdentityMetadata.
  - `[Name <String>]`: The name of the vSphere VMware machine.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourcePoolName <String>]`: Name of the resourcePool.
  - `[SubscriptionId <String>]`: The Subscription ID.
  - `[VcenterName <String>]`: Name of the vCenter.
  - `[VirtualMachineName <String>]`: Name of the virtual machine resource.
  - `[VirtualMachineTemplateName <String>]`: Name of the virtual machine template resource.
  - `[VirtualNetworkName <String>]`: Name of the virtual network resource.

`NETWORKPROFILENETWORKINTERFACE <INetworkInterfaceUpdate[]>`: Gets or sets the list of network interfaces associated with the virtual machine.
  - `[DeviceKey <Int32?>]`: Gets or sets the device key value.
  - `[Name <String>]`: Gets or sets the name of the network interface.
  - `[NetworkId <String>]`: Gets or sets the ARM Id of the network resource to connect the virtual machine.
  - `[NicType <NicType?>]`: NIC type
  - `[PowerOnBoot <PowerOnBootOption?>]`: Gets or sets the power on boot.

`STORAGEPROFILEDISK <IVirtualDiskUpdate[]>`: Gets or sets the list of virtual disks associated with the virtual machine.
  - `[ControllerKey <Int32?>]`: Gets or sets the controller id.
  - `[DeviceKey <Int32?>]`: Gets or sets the device key value.
  - `[DeviceName <String>]`: Gets or sets the device name.
  - `[DiskMode <DiskMode?>]`: Gets or sets the disk mode.
  - `[DiskSizeGb <Int32?>]`: Gets or sets the disk total size.
  - `[DiskType <DiskType?>]`: Gets or sets the disk backing type.
  - `[Name <String>]`: Gets or sets the name of the virtual disk.
  - `[UnitNumber <Int32?>]`: Gets or sets the unit number of the disk on the controller.

## RELATED LINKS

