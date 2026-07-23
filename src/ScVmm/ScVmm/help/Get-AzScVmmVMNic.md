---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmvmnic
schema: 2.0.0
---

# Get-AzScVmmVMNic

## SYNOPSIS
The operation to Get a virtual machine network interface.

## SYNTAX

```
Get-AzScVmmVMNic -vmName <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-NicName <String>]
 [-NicId <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to Get a virtual machine network interface.

## EXAMPLES

### Example 1: List NIC on Virtual Machine
```powershell
Get-AzScVmmVMNic -vmName "test-vm" -ResourceGroupName "test-rg-01"
```

```output
DisplayName      : Network Adapter 1
Ipv4Address      : {x.x.x.x}
Ipv4AddressType  : Dynamic
Ipv6Address      : {x:x:x:x:x:x:x:x}
Ipv6AddressType  : Dynamic
MacAddress       : 00:00:00:00:00:00
MacAddressType   : Dynamic
Name             : nic_1
NetworkName      : 00000000-1111-2222-0001-000000000000
NicId            : 00000000-2222-2222-0001-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet

DisplayName      : Network Adapter 2
Ipv4Address      :
Ipv4AddressType  : Dynamic
Ipv6Address      :
Ipv6AddressType  : Dynamic
MacAddress       :
MacAddressType   : Dynamic
Name             : nic_2
NetworkName      : 00000000-1111-2222-0002-000000000000
NicId            : 00000000-2222-2222-0002-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet
```

List all NICs on Virtual Machine.

### Example 2: Get NIC on a Virtual Machine
```powershell
Get-AzScVmmVMNic -vmName "test-vm" -ResourceGroupName "test-rg-01" -NicName "nic_1"
```

```output
DisplayName      : Network Adapter 1
Ipv4Address      : {x.x.x.x}
Ipv4AddressType  : Dynamic
Ipv6Address      : {x:x:x:x:x:x:x:x}
Ipv6AddressType  : Dynamic
MacAddress       : 00:00:00:00:00:00
MacAddressType   : Dynamic
Name             : nic_1
NetworkName      : 00000000-1111-2222-0001-000000000000
NicId            : 00000000-2222-2222-0001-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet
```

Get NIC with name `NicName` or id `NicId` on Virtual Machine.

## PARAMETERS

### -NicId
The Id of Network Interface

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

### -NicName
The name of Network Interface

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -vmName
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.INetworkInterface

## NOTES

## RELATED LINKS
