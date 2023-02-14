### Example 1: Create Amazon PostgreSql custom scanruleset object
```powershell
<<<<<<< HEAD
New-AzPurviewAmazonPostgreSqlScanRulesetObject -Kind 'AmazonPostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'
```

```output
=======
PS C:\>  New-AzPurviewAmazonPostgreSqlScanRulesetObject -Kind 'AmazonPostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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

