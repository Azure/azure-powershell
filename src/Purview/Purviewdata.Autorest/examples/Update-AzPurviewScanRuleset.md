### Example 1: Update a scan ruleset
```powershell
Update-AzPurviewScanRuleset -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'Rule1' -Kind AmazonPostgreSql
```

```output
CreatedAt                            : 2/17/2022 3:35:07 PM
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   : scanrulesets/Rule1
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AmazonPostgreSql
LastModifiedAt                       : 2/17/2022 3:35:07 PM
Name                                 : Rule1
ScanningRuleCustomFileExtension      :
ScanningRuleFileExtension            : {CSV, JSON, PSV, SSV…}
Status                               : Enabled
Type                                 : Custom
Version                              : 1
```

Update a scan ruleset