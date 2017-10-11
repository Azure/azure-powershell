---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: 441478B4-1453-4A11-AD52-53ADB85E194F
online version: 
schema: 2.0.0
---

# Remove-AzureRmSiteRecoveryStorageClassificationMapping

## SYNOPSIS
Removes a storage classification mapping from Site Recovery.

## SYNTAX

```
Remove-AzureRmSiteRecoveryStorageClassificationMapping
 -StorageClassificationMapping <ASRStorageClassificationMapping> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmSiteRecoveryStorageClassificationMapping** cmdlet removes a storage classification mapping from Azure Site Recovery.

## EXAMPLES

## PARAMETERS

### -StorageClassificationMapping
Specifies a storage classification mapping that this cmdlet removes.

```yaml
Type: ASRStorageClassificationMapping
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ASRStorageClassificationMapping

Parameter 'StorageClassificationMapping' accepts value of type 'ASRStorageClassificationMapping' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmSiteRecoveryStorageClassificationMapping](./Get-AzureRmSiteRecoveryStorageClassificationMapping.md)

[New-AzureRmSiteRecoveryStorageClassificationMapping](./New-AzureRmSiteRecoveryStorageClassificationMapping.md)
