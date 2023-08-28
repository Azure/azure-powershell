---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/new-azconnectedvmwarevminstance
schema: 2.0.0
---

# New-AzConnectedVMwareVMInstance

## SYNOPSIS
The operation to create or update a virtual machine instance.
Please note some properties can be set only during virtual machine instance creation.

## SYNTAX

```
New-AzConnectedVMwareVMInstance -ResourceUri <String> [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-HardwareProfileMemorySizeMb <Int32>]
 [-HardwareProfileNumCoresPerSocket <Int32>] [-HardwareProfileNumCpUs <Int32>]
 [-InfrastructureProfileFirmwareType <FirmwareType>] [-InfrastructureProfileInventoryItemId <String>]
 [-InfrastructureProfileSmbiosUuid <String>] [-InfrastructureProfileTemplateId <String>]
 [-InfrastructureProfileVCenterId <String>] [-NetworkProfileNetworkInterface <INetworkInterface[]>]
 [-OSProfileAdminPassword <String>] [-OSProfileAdminUsername <String>] [-OSProfileComputerName <String>]
 [-OSProfileGuestId <String>] [-OSProfileOstype <OSType>] [-PlacementProfileClusterId <String>]
 [-PlacementProfileDatastoreId <String>] [-PlacementProfileHostId <String>]
 [-PlacementProfileResourcePoolId <String>] [-StorageProfileDisk <IVirtualDisk[]>]
 [-UefiSettingSecureBootEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a virtual machine instance.
Please note some properties can be set only during virtual machine instance creation.

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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ExtendedLocationName
The extended location name.

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
The extended location type.

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

### -InfrastructureProfileFirmwareType
Firmware type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.FirmwareType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileInventoryItemId
Gets or sets the inventory Item ID for the virtual machine.

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

### -InfrastructureProfileSmbiosUuid
Gets or sets the SMBIOS UUID of the vm.

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

### -InfrastructureProfileTemplateId
Gets or sets the ARM Id of the template resource to deploy the virtual machine.

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

### -InfrastructureProfileVCenterId
Gets or sets the ARM Id of the vCenter resource in which this resource pool resides.

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

### -NetworkProfileNetworkInterface
Gets or sets the list of network interfaces associated with the virtual machine.
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20231001.INetworkInterface[]
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

### -OSProfileAdminPassword
Sets administrator password.

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
Gets or sets administrator username.

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
Gets or sets computer name.

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

### -OSProfileGuestId
Gets or sets the guestId.

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
Gets or sets the type of the os.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.OSType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementProfileClusterId
Gets or sets the ARM Id of the cluster resource on which this virtual machine will deploy.

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

### -PlacementProfileDatastoreId
Gets or sets the ARM Id of the datastore resource on which the data for the virtual machine will be kept.

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

### -PlacementProfileHostId
Gets or sets the ARM Id of the host resource on which this virtual machine will deploy.

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

### -PlacementProfileResourcePoolId
Gets or sets the ARM Id of the resourcePool resource on which this virtual machine will deploy.

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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.

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

### -StorageProfileDisk
Gets or sets the list of virtual disks associated with the virtual machine.
To construct, see NOTES section for STORAGEPROFILEDISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20231001.IVirtualDisk[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20231001.IVirtualMachineInstance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`NETWORKPROFILENETWORKINTERFACE <INetworkInterface[]>`: Gets or sets the list of network interfaces associated with the virtual machine.
  - `[DeviceKey <Int32?>]`: Gets or sets the device key value.
  - `[IPSettingAllocationMethod <IPAddressAllocationMethod?>]`: Gets or sets the nic allocation method.
  - `[IPSettingDnsServer <String[]>]`: Gets or sets the dns servers.
  - `[IPSettingGateway <String[]>]`: Gets or sets the gateway.
  - `[IPSettingIpaddress <String>]`: Gets or sets the ip address for the nic.
  - `[IPSettingSubnetMask <String>]`: Gets or sets the mask.
  - `[Name <String>]`: Gets or sets the name of the network interface.
  - `[NetworkId <String>]`: Gets or sets the ARM Id of the network resource to connect the virtual machine.
  - `[NicType <NicType?>]`: NIC type
  - `[PowerOnBoot <PowerOnBootOption?>]`: Gets or sets the power on boot.

`STORAGEPROFILEDISK <IVirtualDisk[]>`: Gets or sets the list of virtual disks associated with the virtual machine.
  - `[ControllerKey <Int32?>]`: Gets or sets the controller id.
  - `[DeviceKey <Int32?>]`: Gets or sets the device key value.
  - `[DeviceName <String>]`: Gets or sets the device name.
  - `[DiskMode <DiskMode?>]`: Gets or sets the disk mode.
  - `[DiskSizeGb <Int32?>]`: Gets or sets the disk total size.
  - `[DiskType <DiskType?>]`: Gets or sets the disk backing type.
  - `[Name <String>]`: Gets or sets the name of the virtual disk.
  - `[UnitNumber <Int32?>]`: Gets or sets the unit number of the disk on the controller.

## RELATED LINKS

