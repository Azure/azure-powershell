---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmminventoryitem
schema: 2.0.0
---

# Get-AzScVmmInventoryItem

## SYNOPSIS
Shows an inventory item.

## SYNTAX

### List (Default)
```
Get-AzScVmmInventoryItem -ResourceGroupName <String> [-SubscriptionId <String[]>] -VmmServerName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityVmmServer
```
Get-AzScVmmInventoryItem -Name <String> -VmmServerInputObject <IScVmmIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzScVmmInventoryItem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VmmServerName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmInventoryItem -InputObject <IScVmmIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Shows an inventory item.

## EXAMPLES

### Example 1: List InventoryItems
```powershell
Get-AzScVmmInventoryItem -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -VmmServerName "test-vmmserver-01"
```

```output
Name                                 InventoryItemName InventoryType          ProvisioningState
----                                 ----------------- -------------          -----------------
00000000-1111-0000-0001-000000000000 test-vnet         VirtualNetwork         Succeeded
00000000-1111-0000-0002-000000000000 test-cloud        Cloud                  Succeeded
00000000-1111-0000-0003-000000000000 test-vm-template  VirtualMachineTemplate Succeeded
00000000-1111-0000-0004-000000000000 test-vm           VirtualMachine         Succeeded
00000000-1111-0000-0005-000000000000 test-vnet-02      VirtualNetwork         Succeeded
```

This Commands list the InventoryItems for the VmmServerName named `test-vmmserver-01` in a resource group named `test-rg-01`.

The Name here is the UUID of the resource specified by InventoryItemName of the type specified by InventoryType on the On-premises SCVMM Server.

### Example 2: Get InventoryItem
```powershell
Get-AzScVmmInventoryItem -Name "00000000-1111-0000-0001-000000000000" Get-AzScVmmInventoryItem -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -VmmServerName "test-vmmserver-01"
```

```output
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0001-000000000000
InventoryItemName            : test-vnet-01
InventoryType                : VirtualNetwork
Kind                         : VirtualNetwork
ManagedResourceId            : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet-01
Name                         : 00000000-1111-0000-0001-000000000000
Property                     : {
                                 "inventoryType": "VirtualNetwork",
                                 "managedResourceId": "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet-01",
                                 "uuid": "00000000-1111-0000-0001-000000000000",
                                 "inventoryItemName": "test-vnet-01",
                                 "provisioningState": "Succeeded"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : 11111111-aaaa-2222-bbbb-333333333333
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/vmmservers/inventoryitems
Uuid                         : 00000000-1111-0000-0001-000000000000
```

This Commands gets the InventoryItem `00000000-1111-0000-0001-000000000000` for the VmmServerName named `test-vmmserver-01` in a resource group named `test-rg-01`.

The Name here is the UUID of the resource specified by InventoryItemName of the type specified by InventoryType on the On-premises SCVMM Server.

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
Name of the inventoryItem.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityVmmServer, Get
Aliases: InventoryItemResourceName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmmServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: GetViaIdentityVmmServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VmmServerName
Name of the VmmServer.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IInventoryItem

## NOTES

## RELATED LINKS
