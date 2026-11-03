---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosscenarioconfigurationvalidation
schema: 2.0.0
---

# Get-AzChaosScenarioConfigurationValidation

## SYNOPSIS
Get the latest scenario configuration validation result.

## SYNTAX

### Get (Default)
```
Get-AzChaosScenarioConfigurationValidation -ResourceGroupName <String> -ScenarioConfigurationName <String>
 -ScenarioName <String> -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosScenarioConfigurationValidation -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

### GetViaIdentityScenario
```
Get-AzChaosScenarioConfigurationValidation -ScenarioConfigurationName <String>
 -ScenarioInputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentitySubscription
```
Get-AzChaosScenarioConfigurationValidation -ScenarioConfigurationName <String> -ScenarioName <String>
 -SubscriptionInputObject <IChaosIdentity> -WorkspaceName <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzChaosScenarioConfigurationValidation -ScenarioConfigurationName <String> -ScenarioName <String>
 -WorkspaceInputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Get the latest scenario configuration validation result.

## EXAMPLES

### Example 1: Read the latest validation result after testing a scenario configuration
```powershell
Test-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
Get-AzChaosScenarioConfigurationValidation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
Status    ScenarioConfigurationName
------    -------------------------
Succeeded default
```

Reads the latest terminal validation record produced by `Test-AzChaosScenarioConfiguration`.
Use this when validation already ran and you need to inspect the stored result again before executing the configuration.

### Example 2: Read validation details that require attention
```powershell
Get-AzChaosScenarioConfigurationValidation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName canary
```

```output
Status            ScenarioConfigurationName
------            -------------------------
RequiresAttention canary
```

Reads the stored validation result for the `canary` configuration.
A result can report `RequiresAttention` and include permission entries with a target `resourceId`, `missingPermissions`, and `recommendedRoles`; run `Repair-AzChaosScenarioConfigurationResourcePermission` before starting the scenario if permissions are missing.

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

### -PassThru
Returns true when the command succeeds

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
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScenarioConfigurationName
Name of the scenario definition.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityScenario, GetViaIdentitySubscription, GetViaIdentityWorkspace
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
Parameter Sets: Get, GetViaIdentitySubscription, GetViaIdentityWorkspace
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
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentitySubscription
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: Get, GetViaIdentitySubscription
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IValidation

## NOTES

## RELATED LINKS

