---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping

## SYNOPSIS
Removes an Azure Site Recovery Protection Container mapping.

## SYNTAX

```
Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping -InputObject <ASRProtectionContainerMapping>
 [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping** cmdlet removes an Azure Site Recovery Protection Container mapping.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
```

Starts the deletion of passed protection container mapping and returns the job for tracking.

## PARAMETERS

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
{{Fill InputObject Description}}

```yaml
Type: ASRProtectionContainerMapping
Parameter Sets: (All)
Aliases: ProtectionContainerMapping

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainerMapping

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrProtectionContainerMapping](./Get-AzureRmRecoveryServicesAsrProtectionContainerMapping.md)

[New-AzureRmRecoveryServicesAsrProtectionContainerMapping](./New-AzureRmRecoveryServicesAsrProtectionContainerMapping.md)
