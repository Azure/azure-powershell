---
external help file:
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleetvirtualmachinescaleset
schema: 2.0.0
---

# Get-AzComputeFleetVirtualMachineScaleSet

## SYNOPSIS
List VirtualMachineScaleSet resources by Fleet

## SYNTAX

```
Get-AzComputeFleetVirtualMachineScaleSet -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List VirtualMachineScaleSet resources by Fleet

## EXAMPLES

### Example 1: List all Virtual Machine Scale Sets in a Managed mode fleet
```powershell
Get-AzComputeFleetVirtualMachineScaleSet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001"
```

```output
Name                    OperationStatus
----                    ---------------
fleet5-001_44ad8d96     Failed
```

Lists all Virtual Machine Scale Set resources managed by the specified Compute Fleet. This cmdlet is only supported for fleets in Managed mode. Each VMSS is named with the fleet name followed by a unique identifier.

### Example 2: Get detailed properties of Virtual Machine Scale Sets in a fleet
```powershell
Get-AzComputeFleetVirtualMachineScaleSet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" | Select-Object Name, Id, OperationStatus
```

```output
Name                    : fleet5-001_44ad8d96
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MY-FLEET-RG-001/providers/Microsoft.Compute/virtualMachineScaleSets/fleet5-001_44ad8d96
OperationStatus         : Failed
```

Retrieves the Virtual Machine Scale Sets in the fleet and displays their name, full ARM resource ID, and operation status. The OperationStatus indicates whether the VMSS was provisioned successfully.

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

### -Name
The name of the Fleet

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
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSet

## NOTES

## RELATED LINKS

