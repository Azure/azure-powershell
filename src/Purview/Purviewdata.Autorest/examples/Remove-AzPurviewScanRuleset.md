### Example 1: Remove custom scanruleset by name
```powershell
Remove-AzPurviewScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/ -Name TestRule
```

```output
CreatedAt                            : 2/17/2022 2:30:15 PM
Description                          : test desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS, MICROSOFT.MISCELLANEOUS.IPADDRESS}
Id                                   : scanrulesets/TestRule
IncludedCustomClassificationRuleName : {ClassificationRule5, ClassificationRule2}
Kind                                 : AzureStorage
LastModifiedAt                       : 2/17/2022 2:32:02 PM
Name                                 : TestRule
ScanningRuleCustomFileExtension      :
ScanningRuleFileExtension            : {CSV, JSON, PSV, SSV…}
Status                               : Enabled
Type                                 : Custom
Version                              : 2
```

Remove custom scanruleset by name

