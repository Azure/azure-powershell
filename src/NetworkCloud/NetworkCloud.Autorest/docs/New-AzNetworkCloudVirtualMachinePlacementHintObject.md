---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudvirtualmachineplacementhintobject
schema: 2.0.0
---

# New-AzNetworkCloudVirtualMachinePlacementHintObject

## SYNOPSIS
Create an in-memory object for VirtualMachinePlacementHint.

## SYNTAX

```
New-AzNetworkCloudVirtualMachinePlacementHintObject -HintType <String> -ResourceId <String>
 -SchedulingExecution <String> -Scope <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualMachinePlacementHint.

## EXAMPLES

### Example 1: Create an in-memory object for VirtualMachinePlacementHint.
```powershell
New-AzNetworkCloudVirtualMachinePlacementHintObject -HintType "Affinity" -ResourceId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/racks/rackName" -SchedulingExecution "Hard" -Scope "Machine"
```

```output
HintType ResourceId                                                                                                     SchedulingExecution Scope
-------- ----------                                                                                                     ------------------- -----
Affinity /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/racks/rackName Hard                Machine
```

Creates an in-memory object for VirtualMachinePlacementHint.

## PARAMETERS

### -HintType
The specification of whether this hint supports affinity or anti-affinity with the referenced resources.

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

### -ResourceId
The resource ID of the target object that the placement hints will be checked against, e.g., the bare metal node to host the virtual machine.

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

### -SchedulingExecution
The indicator of whether the hint is a hard or soft requirement during scheduling.

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

### -Scope
The scope for the virtual machine affinity or anti-affinity placement hint.
It should always be "Machine" in the case of node affinity.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.VirtualMachinePlacementHint

## NOTES

## RELATED LINKS

