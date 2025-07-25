---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewamazons3scanrulesetobject
schema: 2.0.0
---

# New-AzPurviewAmazonS3ScanRulesetObject

## SYNOPSIS
Create an in-memory object for AmazonS3ScanRuleset.

## SYNTAX

```
New-AzPurviewAmazonS3ScanRulesetObject [-Description <String>] [-ExcludedSystemClassification <String[]>]
 [-IncludedCustomClassificationRuleName <String[]>]
 [-ScanningRuleCustomFileExtension <ICustomFileExtension[]>] [-ScanningRuleFileExtension <String[]>]
 [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmazonS3ScanRuleset.

## EXAMPLES

### Example 1: Create AmazonS3 custom scanruleset object
```powershell
New-AzPurviewAmazonS3ScanRulesetObject -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -ScanningRuleFileExtension @("CSV","JSON","PSV","SSV","TSV","TXT","XML","PARQUET","AVRO","ORC","Documents","GZ","DOC","DOCM","DOCX","DOT","ODP","ODS","ODT","PDF","POT","PPS","PPSX","PPT","PPTM","PPTX","XLC","XLS","XLSB","XLSM","XLSX","XLT") -Type 'Custom'
```

```output
CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AmazonS3
LastModifiedAt                       :
Name                                 :
ScanningRuleCustomFileExtension      :
ScanningRuleFileExtension            : {CSV, JSON, PSV, SSV…}
Status                               :
Type                                 : Custom
Version                              :
```

Create AmazonS3 custom scanruleset object

## PARAMETERS

### -Description


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludedSystemClassification


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedCustomClassificationRuleName


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanningRuleCustomFileExtension


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.ICustomFileExtension[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanningRuleFileExtension


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AmazonS3ScanRuleset

## NOTES

## RELATED LINKS

