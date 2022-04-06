### Example 1: Get all custom scanrulesets
```powershell
PS C:\> Get-AzPurviewScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/

CreatedAt                            : 1/25/2022 2:01:38 AM
Description                          : asdasd
ExcludedSystemClassification         : {MICROSOFT.GOVERNMENT.CYPRUS.TAX.IDENTIFICATION.NUMBER, MICROSOFT.GOVERNMENT.CHILE.CDI_NUMBER, MICROSOFT.GOVERNMENT.MALTA.DRIVERS.LICENSE.NUMBER,
                                       MICROSOFT.GOVERNMENT.TURKEY.TURKISH_NATIONAL_IDENTIFICATION_NUMBER…}
Id                                   : scanrulesets/DummySRSFOrDemo
IncludedCustomClassificationRuleName : {}
Kind                                 : AzureStorage
LastModifiedAt                       : 1/27/2022 4:37:15 AM
Name                                 : DummySRSFOrDemo
ScanningRuleCustomFileExtension      :
ScanningRuleFileExtension            : {CSV, JSON, PSV, SSV…}
Status                               : Enabled
Type                                 : Custom
Version                              : 4

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

Get all custom scanrulesets

### Example 2: Get custom scanruleset by name
```powershell
PS C:\> Get-AzPurviewScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/ -Name TestRule

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

Get custom scanruleset by name

