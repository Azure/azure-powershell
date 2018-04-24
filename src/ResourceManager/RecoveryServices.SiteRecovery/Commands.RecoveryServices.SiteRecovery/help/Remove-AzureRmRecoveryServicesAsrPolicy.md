---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: AzureRM.RecoveryServices.SiteRecovery
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.recoveryservices.siterecovery/remove-azurermrecoveryservicesasrpolicy
schema: 2.0.0
---

# Remove-AzureRmRecoveryServicesAsrPolicy

## SYNOPSIS
Deletes the specified ASR replication policy from the Recovery Services vault.

## SYNTAX

```
Remove-AzureRmRecoveryServicesAsrPolicy -InputObject <ASRPolicy> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmRecoveryServicesAsrPolicy** cmdlet deleted the specified replication policy from the Recovery Services vault.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Remove-AzureRmRecoveryServicesAsrPolicy -Policy $Policy
```

Starts the deletion of the specified replication policy and returns the ASR job used to track the operation.

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.
```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object to the cmdlet: The ASR replication policy object corresponding to the replication policy to be deleted.

```yaml
Type: ASRPolicy
Parameter Sets: (All)
Aliases: Policy

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRPolicy

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrPolicy](./Get-AzureRmRecoveryServicesAsrPolicy.md)

[New-AzureRmRecoveryServicesAsrPolicy](./New-AzureRmRecoveryServicesAsrPolicy.md)
