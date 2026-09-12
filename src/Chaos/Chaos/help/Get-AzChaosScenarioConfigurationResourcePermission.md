---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosscenarioconfigurationresourcepermission
schema: 2.0.0
---

# Get-AzChaosScenarioConfigurationResourcePermission

## SYNOPSIS
Get the latest scenario configuration resource permission fix result.

## SYNTAX

### Get (Default)
```
Get-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName <String>
 -ScenarioConfigurationName <String> -ScenarioName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosScenarioConfigurationResourcePermission -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

### GetViaIdentityScenario
```
Get-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String>
 -ScenarioInputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentitySubscription
```
Get-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String> -ScenarioName <String>
 -SubscriptionInputObject <IChaosIdentity> -WorkspaceName <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String> -ScenarioName <String>
 -WorkspaceInputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Get the latest scenario configuration resource permission fix result.

## EXAMPLES

### Example 1: Read the latest permission fix result after a dry run
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default -WhatIfMode
Get-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
State           ScenarioConfigurationName Summary
-----           ------------------------- -------
WhatIfCompleted default                   2 role assignments would be created.
```

Reads the latest permission-fix record produced by `Repair-AzChaosScenarioConfigurationResourcePermission -WhatIfMode`.
Use this to inspect the service-side dry-run result later; the record includes a `state`, a `summary`, and per-assignment `roleAssignments` statuses.

### Example 2: Read the latest permission fix result after applying permissions
```powershell
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
Get-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -ScenarioConfigurationName default
```

```output
State     ScenarioConfigurationName Summary
-----     ------------------------- -------
Completed default                   Required role assignments are present.
```

Reads the stored permission-fix result after the repair operation runs.
Use this cmdlet when you need to re-check the terminal permission result without creating new role assignments or running another dry run.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IPermissionsFix

## NOTES

## RELATED LINKS

