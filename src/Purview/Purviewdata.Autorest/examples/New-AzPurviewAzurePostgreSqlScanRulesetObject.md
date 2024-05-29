### Example 1: Create Azure PostgreSQL custom scanruleset object
```powershell
New-AzPurviewAzurePostgreSqlScanRulesetObject -Kind 'AzurePostgreSql' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'
```

```output
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

