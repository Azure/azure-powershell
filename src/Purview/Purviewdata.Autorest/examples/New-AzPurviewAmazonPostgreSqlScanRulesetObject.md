### Example 1: Create Amazon PostgreSql custom scanruleset object
```powershell
New-AzPurviewAmazonPostgreSqlScanRulesetObject -Kind 'AmazonPostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'
```

```output
CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AmazonPostgreSql
LastModifiedAt                       :
Name                                 :
Status                               :
Type                                 : Custom
Version                              :
```

Create Amazon PostgreSql custom scanruleset object

