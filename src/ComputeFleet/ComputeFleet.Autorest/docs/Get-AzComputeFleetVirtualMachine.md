---
external help file:
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleetvirtualmachine
schema: 2.0.0
---

# Get-AzComputeFleetVirtualMachine

## SYNOPSIS
List VirtualMachine resources of a Launch mode Fleet.

## SYNTAX

```
Get-AzComputeFleetVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Skiptoken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List VirtualMachine resources of a Launch mode Fleet.

## EXAMPLES

### Example 1: List all virtual machines in a Launch mode fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "fleet-ps-tst"
```

```output
Name                         OperationStatus
----                         ---------------
fleet1prefix_b223f9c1_0      Succeeded
fleet1prefix_b223f9c1_1      Succeeded
fleet1prefix_b223f9c1_2      Succeeded
fleet1prefix_b223f9c1_3      Succeeded
fleet1prefix_b223f9c1_4      Succeeded
```

Lists all virtual machines belonging to the specified Launch mode Compute Fleet. Each VM is named with the fleet's VM name prefix followed by a unique identifier.

### Example 2: Get full details of virtual machines in a fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Id, OperationStatus
```

```output
Name                    : fleet1prefix_b223f9c1_0
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fleet-ps-tst/providers/Microsoft.Compute/virtualMachines/fleet1prefix_b223f9c1_0
OperationStatus         : Succeeded
```

Retrieves the virtual machines in the fleet and displays their name, full ARM resource ID, and operation status.

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

### -Filter
Filter expression to filter the virtual machines.

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

### -Skiptoken
Skip token for pagination.
Uses the token from a previous response to fetch the next page of results.

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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachine

## NOTES

## RELATED LINKS

