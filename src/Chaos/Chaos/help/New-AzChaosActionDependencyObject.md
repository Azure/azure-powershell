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

### Example 1: Order one action after another succeeds
```powershell
$dependency = New-AzChaosActionDependencyObject -Name 'stop-primary-vm' -OnActionLifecycle 'Success'
New-AzChaosScenarioActionObject -Name 'stop-secondary-vm' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT5M' -RunAfterItem $dependency
```

```output
Name              ActionId                       Duration RunAfterItem
----              --------                       -------- ------------
stop-secondary-vm microsoft-compute-shutdown/1.0 PT5M     {stop-primary-vm}
```

Creates an in-memory action dependency and attaches it to a later scenario action.
Use this when a custom scenario must wait for one action to reach a specified lifecycle state before another starts.

### Example 2: Order an action after multiple terminal dependencies
```powershell
$dependencies = @(
    New-AzChaosActionDependencyObject -Name 'stop-zone-two' -OnActionLifecycle 'AnyTerminal'
    New-AzChaosActionDependencyObject -Name 'stop-zone-three' -OnActionLifecycle 'AnyTerminal'
)
New-AzChaosScenarioActionObject -Name 'stop-zone-one' -ActionId 'microsoft-compute-shutdown/1.0' -Duration 'PT2M' -RunAfterItem $dependencies
```

```output
Name          ActionId                       Duration RunAfterItem
----          --------                       -------- ------------
stop-zone-one microsoft-compute-shutdown/1.0 PT2M     {stop-zone-two, stop-zone-three}
```

Creates two action dependencies and attaches them to a later action.
The later action can start after both named actions reach a terminal state, which lets a custom scenario express action order without using `-JsonString`.

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

