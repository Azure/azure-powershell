---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosactiondependencyobject
schema: 2.0.0
---

# New-AzChaosActionDependencyObject

## SYNOPSIS
Create an in-memory object for ActionDependency.

## SYNTAX

```
New-AzChaosActionDependencyObject -Name <String> [-OnActionLifecycle <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ActionDependency.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
$dependency = New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
New-AzChaosScenarioActionObject -Name 'stop-secondary-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT5M' -RunAfterItem $dependency
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
$dependencies = @(
    New-AzChaosActionDependencyObject -Name 'stop-vm' -OnActionLifecycle 'Success'
    New-AzChaosActionDependencyObject -Name 'stop-zone-two' -OnActionLifecycle 'AnyTerminal'
)
New-AzChaosScenarioActionObject -Name 'stop-zone-three' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT2M' -RunAfterItem $dependencies
```



## PARAMETERS

### -Name
Name of the action this depends on.

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

### -OnActionLifecycle
The lifecycle state of the dependency action that triggers this action to start.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ActionDependency

## NOTES

## RELATED LINKS

