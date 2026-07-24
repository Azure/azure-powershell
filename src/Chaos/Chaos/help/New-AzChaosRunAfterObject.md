---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosrunafterobject
schema: 2.0.0
---

# New-AzChaosRunAfterObject

## SYNOPSIS
Create an in-memory object for RunAfter.

## SYNTAX

```
New-AzChaosRunAfterObject -Item <IActionDependency[]> [-Behavior <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RunAfter.

## EXAMPLES

### Example 1: Order one action after another
```powershell
$dependency = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ActionDependency]@{ ActionId = 'stop-vm'; DependencyType = 'DependsOn' }
New-AzChaosRunAfterObject -Item $dependency
```

```output
Behavior Item
-------- ----
         {stop-vm}
```

Creates an in-memory run-after object so that an action starts only after the `stop-vm` action completes.

### Example 2: Order an action with an explicit behavior
```powershell
$dependency = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ActionDependency]@{ ActionId = 'stop-vm'; DependencyType = 'DependsOn' }
New-AzChaosRunAfterObject -Item $dependency -Behavior 'WaitForCompletion'
```

```output
Behavior          Item
--------          ----
WaitForCompletion {stop-vm}
```

Creates a run-after object that waits for the referenced action to complete before the dependent action starts.

## PARAMETERS

### -Behavior
Defines how multiple dependencies are evaluated.

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

### -Item
Array of action dependencies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IActionDependency[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.RunAfter

## NOTES

## RELATED LINKS

