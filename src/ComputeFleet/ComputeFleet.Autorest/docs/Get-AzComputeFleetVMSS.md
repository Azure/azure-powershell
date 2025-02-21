---
external help file:
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleetvmss
schema: 2.0.0
---

# Get-AzComputeFleetVMSS

## SYNOPSIS
List VirtualMachineScaleSet resources by Fleet

## SYNTAX

```
Get-AzComputeFleetVMSS -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List VirtualMachineScaleSet resources by Fleet

## EXAMPLES

### Example 1: Get a list of compute fleet resource's Virtual Machine Scale Sets (VMSS) information by ResourceGroupName and FleetName
```powershell
Get-AzComputeFleetVMSS -ResourceGroupName "test-fleet" -FleetName "testFleet"
```

```output
Name               OperationStatus
----               ---------------
testFleet_8553c385 Succeeded    

Code                    : 
Detail                  : 
Id                      : /subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/test-fleet/providers/Microsoft.Compute/virtualMac
                          hineScaleSets/testFleet_8553c385
InnererrorErrorDetail   : 
InnererrorExceptionType : 
Message                 : 
Name                    : testFleet_8553c385
OperationStatus         : Succeeded
Target                  : 
Type                    : 
```

This command gets a list of compute fleet resource's Virtual Machine Scale Sets (VMSS) information by ResourceGroupName and FleetName.

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
Aliases: FleetName

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

