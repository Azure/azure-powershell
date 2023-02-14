### Example 1: Remove custom scanruleset by name
```powershell
<<<<<<< HEAD
Remove-AzPurviewScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/ -Name TestRule
```

```output
=======
PS C:\> Remove-AzPurviewScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/ -Name TestRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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

