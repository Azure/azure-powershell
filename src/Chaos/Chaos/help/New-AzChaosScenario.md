---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/new-azchaosscenario
schema: 2.0.0
---

# New-AzChaosScenario

## SYNOPSIS
Create a scenario.

## SYNTAX

### CreateExpanded (Default)
```
New-AzChaosScenario -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Action <IScenarioAction[]>] [-Description <String>]
 [-Parameter <IScenarioParameter[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzChaosScenario -Name <String> -WorkspaceInputObject <IChaosIdentity> [-Action <IScenarioAction[]>]
 [-Description <String>] [-Parameter <IScenarioParameter[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChaosScenario -Name <String> -ResourceGroupName <String> -WorkspaceName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChaosScenario -Name <String> -ResourceGroupName <String> -WorkspaceName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a scenario.

## EXAMPLES

### Example 1: Create a scenario with a single action
```powershell
$action = New-AzChaosScenarioActionObject -Name 'stop-vm' -ActionId 'urn:csci:microsoft:virtualMachine:shutdown/1.0' -Duration 'PT10M'
New-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario -Description 'Shut down the target virtual machine.' -Action $action
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
```

Creates the `contoso-scenario` scenario with one shutdown action built by `New-AzChaosScenarioActionObject`.

### Example 2: Create a scenario from a JSON file
```powershell
New-AzChaosScenario -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-scenario -JsonFilePath ./scenario.json
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
contoso-scenario contoso-rg        Succeeded
```

Creates a scenario from a hand-authored JSON payload on disk.

## PARAMETERS

### -Action
Array of actions that define the scenario's orchestration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioAction[]
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -Description
Description of what this scenario does (optional).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the scenario.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ScenarioName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameter definitions for the scenario.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioParameter[]
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenario

## NOTES

## RELATED LINKS

