---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmvmtemplate
schema: 2.0.0
---

# Get-AzScVmmVMTemplate

## SYNOPSIS
Implements VirtualMachineTemplate GET method.

## SYNTAX

### List (Default)
```
Get-AzScVmmVMTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzScVmmVMTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmVMTemplate -InputObject <IScVmmIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements VirtualMachineTemplate GET method.

## EXAMPLES

### Example 1: Get Virtual Machine Template By Subscription Id
```powershell
Get-AzScVmmVMTemplate -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-vmt      test-rg-01        00000000-1111-0000-0102-000000000000 Succeeded
test-vmt-02   test-rg-01        00000000-1111-0000-0111-000000000000 Succeeded
test-vmt-03   test-rg-01        00000000-1111-0000-0112-000000000000 Succeeded
test-vmt-04   test-rg-02        00000000-1111-0000-0113-000000000000 Succeeded
test-vmt-05   test-rg-02        00000000-1111-0000-0114-000000000000 Succeeded
test-vmt-06   test-rg-03        00000000-1111-0000-0115-000000000000 Succeeded
```

This command lists Virtual Machine Templates in provided subscription.

### Example 2: Get Virtual Machine Template By Resource Group
```powershell
Get-AzScVmmVMTemplate -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-vmt      test-rg-01        00000000-1111-0000-0102-000000000000 Succeeded
test-vmt-02   test-rg-01        00000000-1111-0000-0111-000000000000 Succeeded
test-vmt-03   test-rg-01        00000000-1111-0000-0112-000000000000 Succeeded
```

This command lists Virtual Machine Templates in provided Resource Group.

### Example 3: Get Virtual Machine Template
```powershell
Get-AzScVmmVMTemplate -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-vmt"
```

```output
ComputerName                 : *
CpuCount                     : 1
Disk                         : {{
                                 "name": "disk_1",
                                 "displayName": "disk.vhd",
                                 "diskId": "00000000-1133-0000-0001-000000000000",
                                 "diskSizeGB": 9,
                                 "maxDiskSizeGB": 40,
                                 "bus": 0,
                                 "lun": 0,
                                 "busType": "IDE",
                                 "vhdType": "Dynamic",
                                 "volumeType": "BootAndSystem",
                                 "vhdFormatType": "VHD",
                                 "createDiffDisk": "false"
                               }}
DynamicMemoryEnabled         : false
DynamicMemoryMaxMb           :
DynamicMemoryMinMb           :
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Generation                   : 1
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VirtualNetworks/test-vmt
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0001-000000000000
IsCustomizable               : true
IsHighlyAvailable            : false
LimitCpuForMigration         : false
Location                     : eastus
MemoryMb                     : 1024
Name                         : test-vmt
NetworkInterface             : {{
                                 "name": "nic_1",
                                 "displayName": "Network Adapter 1",
                                 "virtualNetworkId": "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/provid
                               ers/Microsoft.SCVMM/VirtualNetworks/test-vnet",
                                 "networkName": "00000000-1111-0000-0001-000000000000",
                                 "ipv4AddressType": "Dynamic",
                                 "ipv6AddressType": "Dynamic",
                                 "macAddressType": "Dynamic",
                                 "nicId": "00000000-1122-0000-0001-000000000000"
                               }}
OSName                       : Windows Server
OSType                       : Windows
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 15:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/virtualnetworks
Uuid                         : 00000000-1111-0000-0001-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command gets the Virtual Machine Template named `test-vmt` in the resource group named `test-rg-01`.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the VirtualMachineTemplate.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualMachineTemplateName

Required: True
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
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineTemplate

## NOTES

## RELATED LINKS
