---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/get-azchangesafetystageprogression
schema: 2.0.0
---

# Get-AzChangeSafetyStageProgression

## SYNOPSIS
Get a ChangeRecordStageProgression

## SYNTAX

### List (Default)
```
Get-AzChangeSafetyStageProgression -ChangeRecordName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzChangeSafetyStageProgression -ChangeRecordName <String> [-SubscriptionId <String[]>]
 -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityChangeRecord1
```
Get-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecord1InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityChangeRecord
```
Get-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecordInputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a ChangeRecordStageProgression

## EXAMPLES

### Example 1: Get a specific StageProgression by name
```powershell
Get-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops"
```

```output
Name               ChangeRecordName StageReference Status     Sequence ProvisioningState
----               ---------------- -------------- ------     -------- -----------------
canary-progression appDeploymentV2  canary         InProgress 1        Succeeded
```

Retrieves a specific StageProgression by its name.

### Example 2: List all StageProgressions for a ChangeRecord
```powershell
Get-AzChangeSafetyStageProgression -ChangeRecordName "appDeploymentV2" -ResourceGroupName "rg-changeops"
```

```output
Name               ChangeRecordName StageReference Status     Sequence ProvisioningState
----               ---------------- -------------- ------     -------- -----------------
canary-progression appDeploymentV2  canary         Completed  1        Succeeded
prod-progression   appDeploymentV2  production     InProgress 2        Succeeded
```

Lists all StageProgressions associated with a ChangeRecord, showing the progression through stages.

## PARAMETERS

### -ChangeRecord1InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: GetViaIdentityChangeRecord1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ChangeRecordInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: GetViaIdentityChangeRecord
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
Parameter Sets: List, List1, Get1, Get
Aliases:

Required: True
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
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1, Get1
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
Parameter Sets: Get1, Get, GetViaIdentityChangeRecord1, GetViaIdentityChangeRecord
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
Parameter Sets: List, List1, Get1, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
