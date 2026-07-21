---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosscenariorun
schema: 2.0.0
---

# Get-AzChaosScenarioRun

## SYNOPSIS
Get a scenario run.\n\nThis endpoint is also the polling target for ScenarioConfigurations.execute\nand ScenarioRuns.cancel (final-state-via: location).
While the run is in\nprogress the service returns 202 with a Location header pointing back to\nthis URL; clients must keep polling until they receive 200, which carries\nthe final ScenarioRun body.

## SYNTAX

### List (Default)
```
Get-AzChaosScenarioRun -ResourceGroupName <String> -ScenarioName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosScenarioRun -ResourceGroupName <String> -RunId <String> -ScenarioName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosScenarioRun -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityScenario
```
Get-AzChaosScenarioRun -RunId <String> -ScenarioInputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzChaosScenarioRun -RunId <String> -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a scenario run.\n\nThis endpoint is also the polling target for ScenarioConfigurations.execute\nand ScenarioRuns.cancel (final-state-via: location).
While the run is in\nprogress the service returns 202 with a Location header pointing back to\nthis URL; clients must keep polling until they receive 200, which carries\nthe final ScenarioRun body.

## EXAMPLES

### Example 1: List all runs for a scenario
```powershell
Get-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario
```

```output
RunId                                Status    ProvisioningState
-----                                ------    -----------------
11111111-1111-1111-1111-111111111111 Succeeded Succeeded
22222222-2222-2222-2222-222222222222 Running   Succeeded
```

Lists every scenario run recorded for the `contoso-scenario` scenario.

### Example 2: Get a single scenario run by run id
```powershell
Get-AzChaosScenarioRun -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -RunId 11111111-1111-1111-1111-111111111111
```

```output
RunId                                Status    ProvisioningState
-----                                ------    -----------------
11111111-1111-1111-1111-111111111111 Succeeded Succeeded
```

Gets a single scenario run by its run id.
This is also the polling target for a run started by `Invoke-AzChaosScenarioConfigurationExecution`.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunId
The name of the ScenarioRun

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityScenario, GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScenarioInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentityScenario
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScenarioName
Name of the scenario.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
String that represents a Workspace resource name.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioRun

## NOTES

## RELATED LINKS

