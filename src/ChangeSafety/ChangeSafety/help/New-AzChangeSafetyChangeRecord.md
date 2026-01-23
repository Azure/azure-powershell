---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/new-azchangesafetychangerecord
schema: 2.0.0
---

# New-AzChangeSafetyChangeRecord

## SYNOPSIS
Create a ChangeRecord

## SYNTAX

### CreateExpanded (Default)
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-AdditionalData <IAny>]
 [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>] [-ChangeDefinitionDetail <IAny>]
 [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>] [-ChangeType <String>] [-Comment <String>]
 [-Description <String>] [-Link <ILink[]>] [-OrchestrationTool <String>] [-Parameter <Hashtable>]
 [-ReleaseLabel <String>] [-RolloutType <String>] [-StageMapParameter <Hashtable>]
 [-StageMapResourceId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Targets
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-ResourceGroupName <String>]
 [-AdditionalData <IAny>] [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>]
 [-ChangeType <String>] [-Comment <String>] [-Description <String>] [-Link <ILink[]>]
 [-OrchestrationTool <String>] [-Parameter <Hashtable>] [-ReleaseLabel <String>] [-RolloutType <String>]
 [-StageMapParameter <Hashtable>] [-StageMapResourceId <String>] [-DefaultProfile <PSObject>]
 -Targets <Object[]> [-TargetName <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString1
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] -JsonString <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath1
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] -JsonFilePath <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded1
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-AdditionalData <IAny>] [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>]
 [-ChangeDefinitionDetail <IAny>] [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>]
 [-ChangeType <String>] [-Comment <String>] [-Description <String>] [-Link <ILink[]>]
 [-OrchestrationTool <String>] [-Parameter <Hashtable>] [-ReleaseLabel <String>] [-RolloutType <String>]
 [-StageMapParameter <Hashtable>] [-StageMapResourceId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 -JsonFilePath <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 -JsonString <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a ChangeRecord

## EXAMPLES

### Example 1: Create a stageless ChangeRecord with Targets (simple flow)
```powershell
New-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Hotfix" `
    -Description "Delete unused storage account for cleanup" `
    -Targets @{
        subscriptionId = (Get-AzContext).Subscription.Id
    }
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Creates a simple stageless ChangeRecord targeting the current subscription.
This is used for guarded operations where you want policy protection without staged rollouts.

### Example 2: Create a ChangeRecord with StageMap for staged rollouts
```powershell
New-AzChangeSafetyChangeRecord -Name "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "AppDeployment" `
    -RolloutType "Normal" `
    -Description "Deploy microservices application v2.1.0 to production" `
    -StageMapResourceId "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-changeops/providers/Microsoft.ChangeSafety/stageMaps/prod-deployment-stages" `
    -AnticipatedStartTime (Get-Date).AddHours(1) `
    -AnticipatedEndTime (Get-Date).AddHours(4) `
    -ReleaseLabel "v2.1.0-prod"
```

```output
Name             ResourceGroupName ChangeType    RolloutType Status      ProvisioningState
----             ----------------- ----------    ----------- ------      -----------------
appDeploymentV2  rg-changeops      AppDeployment Normal      Initialized Succeeded
```

Creates a ChangeRecord with a StageMap reference for staged rollouts.
Use this when you need to progress through multiple stages (e.g., canary, production).

### Example 3: Create a ChangeRecord with ApiOperations change definition
```powershell
$changeDefinitionDetail = @{
    operations = @(
        @{
            httpMethod = "DELETE"
            uri = "https://management.azure.com/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-test/providers/Microsoft.Storage/storageAccounts/teststorageaccount?api-version=2023-01-01"
        }
    )
}

New-AzChangeSafetyChangeRecord -Name "storageDelete" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Normal" `
    -ChangeDefinitionKind "ApiOperations" `
    -ChangeDefinitionName "Delete storage account" `
    -ChangeDefinitionDetail $changeDefinitionDetail
```

```output
Name          ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----          ----------------- ----------  ----------- ------      -----------------
storageDelete rg-changeops      ManualTouch Normal      Initialized Succeeded
```

Creates a ChangeRecord with explicit API operations defined.
The policy will validate that the actual operation matches the declared operations.

## PARAMETERS

### -AdditionalData
Additional metadata for the change required for various orchestration tools.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IAny
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnticipatedEndTime
Expected completion time when the change should be finished, in ISO 8601 format.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnticipatedStartTime
Expected start time when the change execution should begin, in ISO 8601 format.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeDefinitionDetail
Free form object containing additional details for the change definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IAny
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeDefinitionKind
Kind of the change definition.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeDefinitionName
Name of the change definition.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeType
Describes the nature of the change.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
Comments about the last update to the ChangeRecord resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
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
Brief description about the change.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
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
Parameter Sets: CreateViaJsonFilePath1, CreateViaJsonFilePath
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
Parameter Sets: CreateViaJsonString1, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Link
Collection of related links for the change.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.ILink[]
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ChangeRecord resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ChangeRecordName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrchestrationTool
Tool used for deployment orchestration of this change.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Schema of parameters that will be provided for each stageProgression.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReleaseLabel
Label for the release associated with this change.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
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
Parameter Sets: Targets
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString1, CreateViaJsonFilePath1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RolloutType
Describes the type of the rollout used for the change.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StageMapParameter
Key value pairs of parameter names & their values for the stageMap referenced by the resourceId field.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StageMapResourceId
ARM resource ID for the nested stagemap resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Targets, CreateExpanded1
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetName
Name for the target definition.
Defaults to 'TargetSelection'.

```yaml
Type: System.String
Parameter Sets: Targets
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Targets
Target selection criteria.
Can be a single hashtable or an array of hashtables.
Keys include: resourceType, subscriptions, resourceGroups, regions.

```yaml
Type: System.Object[]
Parameter Sets: Targets
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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord

## NOTES

## RELATED LINKS
