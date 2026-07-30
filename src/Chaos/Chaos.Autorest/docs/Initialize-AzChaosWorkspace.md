---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/initialize-azchaosworkspace
schema: 2.0.0
---

# Initialize-AzChaosWorkspace

## SYNOPSIS
Stand up a ready-to-use Chaos Studio workspace end to end.

## SYNTAX

```
Initialize-AzChaosWorkspace -Location <String> -ResourceGroupName <String> -Scope <String[]>
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-RoleDefinitionName <String>] [-SkipEvaluationWait]
 [-SkipPermission] [-SubscriptionId <String>] [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stand up a ready-to-use Chaos Studio workspace end to end.
This is a first-day
workflow cmdlet that runs the five setup steps: ensure the resource group exists,
create the workspace with a system-assigned managed identity, grant that identity
the Reader role on each scope, evaluate scenarios, and report the discovered
scenarios plus suggested next commands.
Discovery and evaluation run under the
workspace identity and cannot enumerate resources without the Reader grant.
Pass
-SkipPermission to opt out of the RBAC grant.
Pass -SkipEvaluationWait to run a
single evaluation attempt instead of waiting out Azure Resource Graph propagation.
The default Reader grant enables discovery and evaluation only; most run actions
need additional permissions.
Use Repair-AzChaosScenarioConfigurationResourcePermission
after creating a scenario configuration to inspect or grant those permissions.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg'
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
$scopes = @(
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg',
    '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/payments-rg'
)
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope $scopes -SkipPermission -SkipEvaluationWait
```



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

### -Location
The geo-location where the workspace lives.

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

### -RoleDefinitionName
The role definition name granted to the workspace identity on each scope.
Defaults to Reader.

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

### -Scope
The list of ARM resource scopes the workspace discovers and evaluates.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipEvaluationWait
Run a single evaluation attempt instead of waiting for Azure Resource Graph propagation.

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

### -SkipPermission
Do not grant the workspace identity an RBAC role on the scopes.

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

### -Tag
Resource tags applied to the workspace.

```yaml
Type: System.Collections.Hashtable
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenario

## NOTES

## RELATED LINKS

