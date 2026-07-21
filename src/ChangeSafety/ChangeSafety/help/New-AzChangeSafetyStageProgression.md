---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/new-azchangesafetystageprogression
schema: 2.0.0
---

# New-AzChangeSafetyStageProgression

## SYNOPSIS
Create a ChangeRecordStageProgression

## SYNTAX

### CreateExpanded (Default)
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] [-AdditionalData <IAny>] [-Comment <String>] [-Link <ILink[]>]
 [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString1
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath1
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> [-AdditionalData <IAny>] [-Comment <String>]
 [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>]
 [-Status <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a ChangeRecordStageProgression

## EXAMPLES

### Example 1: Start a stage progression (set to InProgress)
```powershell
New-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -StageReference "canary" `
    -Status "InProgress" `
    -Comment "Starting canary deployment"
```

```output
Name               ChangeRecordName StageReference Status     ProvisioningState
----               ---------------- -------------- ------     -----------------
canary-progression appDeploymentV2  canary         InProgress Succeeded
```

Creates a StageProgression to start the canary stage of a deployment.
This puts the ChangeRecord in an active state for the specified stage.

### Example 2: Create a stage progression with stage variables
```powershell
New-AzChangeSafetyStageProgression -Name "prod-eastus-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -StageReference "eastus-prod" `
    -Status "InProgress" `
    -StageVariable @{
        region = "eastus"
        replicas = 3
        featureFlags = @("new-ui", "enhanced-logging")
    } `
    -Comment "Starting production deployment in East US"
```

```output
Name                    ChangeRecordName StageReference Status     ProvisioningState
----                    ---------------- -------------- ------     -----------------
prod-eastus-progression appDeploymentV2  eastus-prod    InProgress Succeeded
```

Creates a StageProgression with stage-specific variables that can be used during the deployment.

## PARAMETERS

### -AdditionalData
Additional metadata for the stageProgression resource.

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

### -ChangeRecordName
The name of the ChangeRecord resource.

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

### -Comment
Comments about the update to the resource.

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
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Stage specific key value pairs of parameter names & their values for the current Stage, If any.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateViaJsonString1, CreateViaJsonFilePath1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StageProgressionName
Name of the stageProgression

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

### -StageReference
Stage name relevant to hierarchical StageMap.

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

### -StageVariable
Variables to apply on the change of that stage.
Key value pairs supporting any JSON values.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
StageProgression resource status.

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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecordStageProgression

## NOTES

## RELATED LINKS
