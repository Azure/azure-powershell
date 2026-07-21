---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/repair-azchaosscenarioconfigurationresourcepermission
schema: 2.0.0
---

# Repair-AzChaosScenarioConfigurationResourcePermission

## SYNOPSIS
Fixes resource permissions for the given scenario configuration.

## SYNTAX

### FixExpanded (Default)
```
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName <String>
 -ScenarioConfigurationName <String> -ScenarioName <String> -WorkspaceName <String> [-SubscriptionId <String>]
 [-WhatIfMode] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Fix
```
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName <String>
 -ScenarioConfigurationName <String> -ScenarioName <String> -WorkspaceName <String>
 -Body <IFixResourcePermissionsRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaIdentity
```
Repair-AzChaosScenarioConfigurationResourcePermission -InputObject <IChaosIdentity>
 -Body <IFixResourcePermissionsRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### FixViaIdentityExpanded
```
Repair-AzChaosScenarioConfigurationResourcePermission -InputObject <IChaosIdentity> [-WhatIfMode]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaIdentityScenario
```
Repair-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String>
 -ScenarioInputObject <IChaosIdentity> -Body <IFixResourcePermissionsRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaIdentityScenarioExpanded
```
Repair-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String>
 -ScenarioInputObject <IChaosIdentity> [-WhatIfMode] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaIdentityWorkspace
```
Repair-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String>
 -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity> -Body <IFixResourcePermissionsRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaIdentityWorkspaceExpanded
```
Repair-AzChaosScenarioConfigurationResourcePermission -ScenarioConfigurationName <String>
 -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity> [-WhatIfMode] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FixViaJsonFilePath
```
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName <String>
 -ScenarioConfigurationName <String> -ScenarioName <String> -WorkspaceName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### FixViaJsonString
```
Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName <String>
 -ScenarioConfigurationName <String> -ScenarioName <String> -WorkspaceName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Fixes resource permissions for the given scenario configuration.

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

### -AsJob
Run the command as a job

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

### -Body
Request body for fixing resource permissions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IFixResourcePermissionsRequest
Parameter Sets: Fix, FixViaIdentity, FixViaIdentityScenario, FixViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
Parameter Sets: FixViaIdentity, FixViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Fix operation

```yaml
Type: System.String
Parameter Sets: FixViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Fix operation

```yaml
Type: System.String
Parameter Sets: FixViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Fix, FixExpanded, FixViaJsonFilePath, FixViaJsonString
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
Parameter Sets: Fix, FixExpanded, FixViaIdentityScenario, FixViaIdentityScenarioExpanded, FixViaIdentityWorkspace, FixViaIdentityWorkspaceExpanded, FixViaJsonFilePath, FixViaJsonString
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
Parameter Sets: FixViaIdentityScenario, FixViaIdentityScenarioExpanded
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
Parameter Sets: Fix, FixExpanded, FixViaIdentityWorkspace, FixViaIdentityWorkspaceExpanded, FixViaJsonFilePath, FixViaJsonString
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
Type: System.String
Parameter Sets: Fix, FixExpanded, FixViaJsonFilePath, FixViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIfMode
Optional value that indicates whether to run a "dry run" of fixing resource permissions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: FixExpanded, FixViaIdentityExpanded, FixViaIdentityScenarioExpanded, FixViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: FixViaIdentityWorkspace, FixViaIdentityWorkspaceExpanded
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
Parameter Sets: Fix, FixExpanded, FixViaJsonFilePath, FixViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IFixResourcePermissionsRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

