### Example 1: Create Azure Synapse Workspace custom scanruleset object
```powershell
PS C:\> New-AzPurviewAzureSynapseWorkspaceScanRulesetObject -Kind 'AzureSynapseWorkspace' -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'

CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AzureSynapseWorkspace
LastModifiedAt                       :
Name                                 :
Status                               :
Type                                 : Custom
Version                              :
```

Create Azure Synapse Workspace custom scanruleset object

