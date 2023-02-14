### Example 1: Create Azure PostgreSQL custom scanruleset object
```powershell
<<<<<<< HEAD
New-AzPurviewAzurePostgreSqlScanRulesetObject -Kind 'AzurePostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'
```

```output
=======
PS C:\> New-AzPurviewAzurePostgreSqlScanRulesetObject -Kind 'AzurePostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AzurePostgreSql
LastModifiedAt                       :
Name                                 :
Status                               :
Type                                 : Custom
Version                              :
```

Create Azure PostgreSQL custom scanruleset object

