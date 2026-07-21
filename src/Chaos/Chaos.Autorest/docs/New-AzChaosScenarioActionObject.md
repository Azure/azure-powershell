---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosscenarioactionobject
schema: 2.0.0
---

# New-AzChaosScenarioActionObject

## SYNOPSIS
Create an in-memory object for ScenarioAction.

## SYNTAX

```
New-AzChaosScenarioActionObject -ActionId <String> -Duration <String> -Name <String> [-Description <String>]
 [-ExternalResourceId <String>] [-Parameter <IKeyValuePair[]>] [-RunAfterBehavior <String>]
 [-RunAfterItem <IActionDependency[]>] [-Timeout <String>] [-WaitBefore <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScenarioAction.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ActionId
Identifier of the action and version (e.g., "microsoft-compute-shutdown/1.0").

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

### -Description
Human-readable description of what this action does.

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

### -Duration
ISO 8601 duration for how long the action runs (e.g., PT30M for 30 minutes).
Supports template macro syntax (%%\{parameters.\\<name\\>\}%%).

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

### -ExternalResourceId
The resource ID of the external resource.

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
Unique name for the action.

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

### -Parameter
Action-specific parameter values.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IKeyValuePair[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAfterBehavior
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

### -RunAfterItem
Array of action dependencies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IActionDependency[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
ISO 8601 duration for maximum action execution time.
Supports template macro syntax.

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

### -WaitBefore
ISO 8601 duration to wait before action starts (e.g., PT30S for 30 seconds).
Supports template macro syntax.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ScenarioAction

## NOTES

## RELATED LINKS

