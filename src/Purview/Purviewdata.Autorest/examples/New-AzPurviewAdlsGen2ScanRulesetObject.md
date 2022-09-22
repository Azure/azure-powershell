### Example 1: Create AdlsGen2 custom scanruleset object
```powershell
New-AzPurviewAdlsGen2ScanRulesetObject -Kind 'AdlsGen2' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -ScanningRuleFileExtension @("CSV","JSON","PSV","SSV","TSV","TXT","XML","PARQUET","AVRO","ORC","Documents","GZ","DOC","DOCM","DOCX","DOT","ODP","ODS","ODT","PDF","POT","PPS","PPSX","PPT","PPTM","PPTX","XLC","XLS","XLSB","XLSM","XLSX","XLT") -Type 'Custom'
```

```output
CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AdlsGen2
LastModifiedAt                       :
Name                                 :
ScanningRuleCustomFileExtension      :
ScanningRuleFileExtension            : {CSV, JSON, PSV, SSV…}
Status                               :
Type                                 : Custom
Version                              :
```

Create AdlsGen2 custom scanruleset object

