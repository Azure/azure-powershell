---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/update-azchangesafetychangerecord
schema: 2.0.0
---

# Update-AzChangeSafetyChangeRecord

## SYNOPSIS
Update a ChangeRecord

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-AdditionalData <IAny>]
 [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>] [-ChangeDefinitionDetail <IAny>]
 [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>] [-ChangeType <String>] [-Comment <String>]
 [-Description <String>] [-Link <ILink[]>] [-OrchestrationTool <String>] [-Parameter <Hashtable>]
 [-ReleaseLabel <String>] [-RolloutType <String>] [-StageMapParameter <Hashtable>]
 [-StageMapResourceId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Targets
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-ResourceGroupName <String>]
 [-AdditionalData <IAny>] [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>]
 [-ChangeType <String>] [-Comment <String>] [-Description <String>] [-Link <ILink[]>]
 [-OrchestrationTool <String>] [-Parameter <Hashtable>] [-ReleaseLabel <String>] [-RolloutType <String>]
 [-StageMapParameter <Hashtable>] [-StageMapResourceId <String>] [-DefaultProfile <PSObject>]
 -Targets <Object[]> [-TargetName <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString1
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] -JsonString <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 -JsonString <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath1
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] -JsonFilePath <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 -JsonFilePath <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded1
```
Update-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-AdditionalData <IAny>] [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>]
 [-ChangeDefinitionDetail <IAny>] [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>]
 [-ChangeType <String>] [-Comment <String>] [-Description <String>] [-Link <ILink[]>]
 [-OrchestrationTool <String>] [-Parameter <Hashtable>] [-ReleaseLabel <String>] [-RolloutType <String>]
 [-StageMapParameter <Hashtable>] [-StageMapResourceId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzChangeSafetyChangeRecord -InputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>]
 [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>] [-ChangeDefinitionDetail <IAny>]
 [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>] [-ChangeType <String>] [-Comment <String>]
 [-Description <String>] [-Link <ILink[]>] [-OrchestrationTool <String>] [-Parameter <Hashtable>]
 [-ReleaseLabel <String>] [-RolloutType <String>] [-StageMapParameter <Hashtable>]
 [-StageMapResourceId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzChangeSafetyChangeRecord -InputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>]
 [-AnticipatedEndTime <DateTime>] [-AnticipatedStartTime <DateTime>] [-ChangeDefinitionDetail <IAny>]
 [-ChangeDefinitionKind <String>] [-ChangeDefinitionName <String>] [-ChangeType <String>] [-Comment <String>]
 [-Description <String>] [-Link <ILink[]>] [-OrchestrationTool <String>] [-Parameter <Hashtable>]
 [-ReleaseLabel <String>] [-RolloutType <String>] [-StageMapParameter <Hashtable>]
 [-StageMapResourceId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a ChangeRecord

## EXAMPLES

### Example 1: Update a ChangeRecord description
```powershell
Update-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -Description "Updated: Delete unused storage account for Q4 cleanup" `
    -Comment "Updated description for clarity"
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Updates the description and adds a comment to an existing ChangeRecord.

### Example 2: Update a ChangeRecord with new Targets
```powershell
Update-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -Targets @{
        subscriptionId = (Get-AzContext).Subscription.Id
        resourceGroups = @("rg-prod-eastus", "rg-prod-westus")
    }
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Updates the ChangeRecord with new target scope including specific resource groups.

## PARAMETERS

### -AdditionalData
Additional metadata for the change required for various orchestration tools.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IAny
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath1, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString1, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateViaJsonString1, UpdateViaJsonString, UpdateViaJsonFilePath1, UpdateViaJsonFilePath, UpdateExpanded1
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaJsonString1, UpdateViaJsonFilePath1, UpdateExpanded1
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Targets, UpdateViaJsonString1, UpdateViaJsonString, UpdateViaJsonFilePath1, UpdateViaJsonFilePath, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetName
Name for the target definition.

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
One or more target selection criteria as hashtables.

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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord

## NOTES

## RELATED LINKS
