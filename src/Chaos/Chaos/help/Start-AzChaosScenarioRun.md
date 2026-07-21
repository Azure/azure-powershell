---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/start-azchaosscenariorun
schema: 2.0.0
---

# Start-AzChaosScenarioRun

## SYNOPSIS
Start a scenario run for a scenario configuration.

## SYNTAX

```
Start-AzChaosScenarioRun -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-NoWait] [-SkipValidation] [-SubscriptionId <String>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Start a scenario run for a scenario configuration.
This is a workflow cmdlet: it
validates the scenario configuration first and starts the run only if validation
succeeds, mirroring the Azure Portal where validation precedes the Run action.
Pass
-SkipValidation to bypass the pre-flight check.
For a catalog (non-custom) scenario
the workspace must have been evaluated before a run can start; if it has not, the
cmdlet fails with a friendly error and does not trigger evaluation as a side effect.

## EXAMPLES

### Example 1: Start a scenario run with pre-flight validation
```powershell
Start-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
True
```

Validates the `default` scenario configuration and, only if validation succeeds, starts the scenario run.
This mirrors the Azure Portal, where validation precedes the Run action.
For a catalog scenario the cmdlet fails with a friendly error if the workspace has not been evaluated yet.

### Example 2: Start a scenario run without validation and return immediately
```powershell
Start-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default -SkipValidation -NoWait
```

```output
True
```

Bypasses the pre-flight validation with `-SkipValidation` and returns before the run completes with `-NoWait`.
Poll the run status with `Get-AzChaosScenarioRun`.

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
Name of the scenario configuration to run.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ScenarioConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously and return before the scenario run completes.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

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

### -ScenarioName
Name of the scenario.

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

### -SkipValidation
Bypass the pre-flight validation of the scenario configuration.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -WorkspaceName
Name of the workspace.

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

### System.Boolean

## NOTES

## RELATED LINKS

