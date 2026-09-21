---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosscenarioconfiguration
schema: 2.0.0
---

# Get-AzChaosScenarioConfiguration

## SYNOPSIS
Get a scenario definition.

## SYNTAX

### List (Default)
```
Get-AzChaosScenarioConfiguration -ResourceGroupName <String> -ScenarioName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosScenarioConfiguration -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosScenarioConfiguration -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityScenario
```
Get-AzChaosScenarioConfiguration -Name <String> -ScenarioInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzChaosScenarioConfiguration -Name <String> -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a scenario definition.

## EXAMPLES

### Example 1: List all scenario configurations for a scenario
```powershell
Get-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
canary  contoso-rg        Succeeded
```

Lists every scenario configuration under the `contoso-scenario` scenario.

### Example 2: Get a single scenario configuration by name
```powershell
Get-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
```

Gets the `default` scenario configuration from the `contoso-scenario` scenario.

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

### -Name
Name of the scenario definition.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityScenario, GetViaIdentityWorkspace
Aliases: ScenarioConfigurationName

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioConfiguration

## NOTES

## RELATED LINKS

