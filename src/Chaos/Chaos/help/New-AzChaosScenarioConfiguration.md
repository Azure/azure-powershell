---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/new-azchaosscenarioconfiguration
schema: 2.0.0
---

# New-AzChaosScenarioConfiguration

## SYNOPSIS
Create a scenario definition.

## SYNTAX

### CreateExpanded (Default)
```
New-AzChaosScenarioConfiguration -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-ExclusionResource <String[]>]
 [-ExclusionTag <IKeyValuePair[]>] [-ExclusionType <String[]>] [-FilterLocation <String[]>]
 [-FilterPhysicalZone <String[]>] [-FilterZone <String[]>] [-Parameter <IKeyValuePair[]>]
 [-ScenarioId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityScenarioExpanded
```
New-AzChaosScenarioConfiguration -Name <String> -ScenarioInputObject <IChaosIdentity>
 [-ExclusionResource <String[]>] [-ExclusionTag <IKeyValuePair[]>] [-ExclusionType <String[]>]
 [-FilterLocation <String[]>] [-FilterPhysicalZone <String[]>] [-FilterZone <String[]>]
 [-Parameter <IKeyValuePair[]>] [-ScenarioId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzChaosScenarioConfiguration -Name <String> -ScenarioName <String> -WorkspaceInputObject <IChaosIdentity>
 [-ExclusionResource <String[]>] [-ExclusionTag <IKeyValuePair[]>] [-ExclusionType <String[]>]
 [-FilterLocation <String[]>] [-FilterPhysicalZone <String[]>] [-FilterZone <String[]>]
 [-Parameter <IKeyValuePair[]>] [-ScenarioId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChaosScenarioConfiguration -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChaosScenarioConfiguration -Name <String> -ResourceGroupName <String> -ScenarioName <String>
 -WorkspaceName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a scenario definition.

## EXAMPLES

### Example 1: Create a scenario configuration
```powershell
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name default
```

```output
Name    ResourceGroupName ProvisioningState
----    ----------------- -----------------
default contoso-rg        Succeeded
```

Creates the `default` scenario configuration for the `contoso-scenario` scenario using the workspace scopes.

### Example 2: Create a scenario configuration with resource filters and exclusions
```powershell
New-AzChaosScenarioConfiguration -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -ScenarioName contoso-scenario -Name canary `
    -FilterLocation 'eastus' -FilterZone '1' -ExclusionType 'Microsoft.Compute/virtualMachines'
```

```output
Name   ResourceGroupName ProvisioningState
----   ----------------- -----------------
canary contoso-rg        Succeeded
```

Creates a scenario configuration that only targets resources in `eastus` zone `1`, and excludes virtual machines from the blast radius.

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

### -ExclusionResource
Array of specific resource IDs to exclude from fault injection.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExclusionTag
Array of tag key-value pairs.
Resources with matching tags are excluded.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IKeyValuePair[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExclusionType
Array of resource types.
All resources of these types are excluded.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterLocation
Array of Azure location strings.
Only resources in these locations are included.Null or omitted means all locations (no filter).
Empty array means include nothing.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterPhysicalZone
SENTRECURSIVE

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterZone
Array of availability zone identifiers ("1", "2", "3", "zone-redundant").Only resources whose zones intersect this list are included.Null or omitted means all zones (including non-zonal).
Empty array means include nothing.Mutually exclusive with `physicalZones` — set one or the other, not both.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
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
Name of the scenario definition.

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

### -Parameter
Runtime parameter values for the scenario.
Keys must match parameter names defined in the scenario.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IKeyValuePair[]
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
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

### -ScenarioId
Resource ID of the scenario this configuration applies to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityScenarioExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScenarioInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: CreateViaIdentityScenarioExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenarioConfiguration

## NOTES

## RELATED LINKS

