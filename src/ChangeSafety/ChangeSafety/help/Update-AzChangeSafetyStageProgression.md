---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/update-azchangesafetystageprogression
schema: 2.0.0
---

# Update-AzChangeSafetyStageProgression

## SYNOPSIS
Update a ChangeRecordStageProgression

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] [-AdditionalData <IAny>] [-Comment <String>] [-Link <ILink[]>]
 [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString1
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath1
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded1
```
Update-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> [-AdditionalData <IAny>] [-Comment <String>]
 [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>]
 [-Status <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityChangeRecordExpanded1
```
Update-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecordInputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>] [-Comment <String>]
 [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>]
 [-Status <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityChangeRecordExpanded
```
Update-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecordInputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>] [-Comment <String>]
 [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>] [-StageVariable <Hashtable>]
 [-Status <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>]
 [-Comment <String>] [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>]
 [-StageVariable <Hashtable>] [-Status <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-AdditionalData <IAny>]
 [-Comment <String>] [-Link <ILink[]>] [-Parameter <Hashtable>] [-StageReference <String>]
 [-StageVariable <Hashtable>] [-Status <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a ChangeRecordStageProgression

## EXAMPLES

### Example 1: Complete a stage progression
```powershell
Update-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Status "Completed" `
    -Comment "Canary deployment completed successfully, metrics look good"
```

```output
Name               ChangeRecordName StageReference Status    ProvisioningState
----               ---------------- -------------- ------    -----------------
canary-progression appDeploymentV2  canary         Completed Succeeded
```

Marks a stage progression as completed.
This allows the next stage to be started.

### Example 2: Cancel a stage progression
```powershell
Update-AzChangeSafetyStageProgression -Name "prod-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Status "Cancelled" `
    -Comment "Cancelling due to critical bug found in canary"
```

```output
Name             ChangeRecordName StageReference Status    ProvisioningState
----             ---------------- -------------- ------    -----------------
prod-progression appDeploymentV2  production     Cancelled Succeeded
```

Cancels a stage progression.
Use this when you need to abort a deployment.

## PARAMETERS

### -AdditionalData
Additional metadata for the stageProgression resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IAny
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeRecordInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ChangeRecordName
The name of the ChangeRecord resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString1, UpdateViaJsonString, UpdateViaJsonFilePath1, UpdateViaJsonFilePath, UpdateExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaJsonString1, UpdateViaJsonFilePath1, UpdateExpanded1
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString1, UpdateViaJsonString, UpdateViaJsonFilePath1, UpdateViaJsonFilePath, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityChangeRecordExpanded1, UpdateViaIdentityChangeRecordExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString1, UpdateViaJsonString, UpdateViaJsonFilePath1, UpdateViaJsonFilePath, UpdateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecordStageProgression

## NOTES

## RELATED LINKS
