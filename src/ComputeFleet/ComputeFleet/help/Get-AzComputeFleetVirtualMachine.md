---
external help file: Az.ComputeFleet-help.xml
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
 [-Filter <String>] [-Skiptoken <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
List VirtualMachine resources of a Launch mode Fleet.

## EXAMPLES

### Example 1: List all virtual machines in a Launch mode fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, OperationStatus
```

```output
Name                         OperationStatus
----                         ---------------
fleet1prefix_b223f9c1_0      Succeeded
```

Lists the VMs launched by the fleet and their launch operation status.
During provisioning, `OperationStatus` can progress through `Launching` and `Creating` before reaching `Succeeded`.
This is the fleet launch status, not the VM's guest operating system or power state.

### Example 2: Get full details of virtual machines in a fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, Id, OperationStatus
```

```output
Name                    : fleet1prefix_b223f9c1_0
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/fleet1prefix_b223f9c1_0
OperationStatus         : Succeeded
```

Retrieves the virtual machines in the fleet and displays their name, full ARM resource ID, and operation status.

### Example 3: Find VM launches that have not succeeded
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Where-Object OperationStatus -ne "Succeeded" |
    Select-Object Name, OperationStatus
```

Returns pending or unsuccessful launches for inspection.
No output means every returned VM has reached `Succeeded`; it does not establish that the fleet returned any VMs.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
