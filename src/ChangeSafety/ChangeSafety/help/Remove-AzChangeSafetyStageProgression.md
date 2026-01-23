---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/remove-azchangesafetystageprogression
schema: 2.0.0
---

# Remove-AzChangeSafetyStageProgression

## SYNOPSIS
Delete a ChangeRecordStageProgression

## SYNTAX

### Delete (Default)
```
Remove-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Delete1
```
Remove-AzChangeSafetyStageProgression -ChangeRecordName <String> -StageProgressionName <String>
 [-SubscriptionId <String>] -ResourceGroupName <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityChangeRecord1
```
Remove-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecord1InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityChangeRecord
```
Remove-AzChangeSafetyStageProgression -StageProgressionName <String>
 -ChangeRecordInputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity1
```
Remove-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzChangeSafetyStageProgression -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a ChangeRecordStageProgression

## EXAMPLES

### Example 1: Delete a StageProgression by name
```powershell
Remove-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops"
```

Deletes the specified StageProgression from a ChangeRecord.

### Example 2: Delete a StageProgression with confirmation prompt suppressed
```powershell
Remove-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Confirm:$false
```

Deletes the specified StageProgression without prompting for confirmation.

## PARAMETERS

### -ChangeRecord1InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: DeleteViaIdentityChangeRecord1
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
Parameter Sets: DeleteViaIdentityChangeRecord
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
Parameter Sets: Delete, Delete1
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
Parameter Sets: DeleteViaIdentity1, DeleteViaIdentity
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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Delete1
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
Parameter Sets: Delete, Delete1, DeleteViaIdentityChangeRecord1, DeleteViaIdentityChangeRecord
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
Parameter Sets: Delete, Delete1
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

### System.Boolean

## NOTES

## RELATED LINKS
