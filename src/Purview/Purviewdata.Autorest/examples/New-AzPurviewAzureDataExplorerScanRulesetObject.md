### Example 1:  Create Azure Data Explorer custom scanruleset object
```powershell
PS C:\> New-AzPurviewAzureDataExplorerScanRulesetObject -Kind 'AzureDataExplorer' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'

CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AzureDataExplorer
LastModifiedAt                       :
Name                                 :
Status                               :
Type                                 : Custom
Version                              :
```

Create Azure Data Explorer custom scanruleset object

