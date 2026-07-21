---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/invoke-azchaosworkspacescenarioevaluation
schema: 2.0.0
---

# Invoke-AzChaosWorkspaceScenarioEvaluation

## SYNOPSIS
Evaluate a workspace end to end.

## SYNTAX

```
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName <String> -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [-NoWait] [-SubscriptionId <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Evaluate a workspace end to end.
This is a workflow cmdlet: it discovers the in-scope
resources and evaluates which scenarios apply to them, producing per-scenario
recommendation statuses.
Its identity is the discovery-plus-evaluation workflow,
independent of how many API operations implement it.

## EXAMPLES

### Example 1: Evaluate a workspace end to end
```powershell
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
True
```

Discovers the in-scope resources for the `contoso-workspace` workspace and evaluates which catalog scenarios apply to them, refreshing each per-scenario recommendation status.
Run this before you start a catalog scenario.

### Example 2: Evaluate a workspace and return immediately
```powershell
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -NoWait
```

```output
True
```

Starts the discover-plus-evaluate workflow and returns before it completes with `-NoWait`.
Query the scenarios with `Get-AzChaosScenario` to read the refreshed recommendation status.

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

### -NoWait
Run the command asynchronously and return before the evaluation completes.

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

