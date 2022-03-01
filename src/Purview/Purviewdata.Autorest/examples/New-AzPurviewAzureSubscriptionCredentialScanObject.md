### Example 1: Create Azure resource sub Credential scan object
```powershell
PS C:\> New-AzPurviewAzureSubscriptionCredentialScanObject -Kind 'AzureSubscriptionCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialType 'ServicePrincipal' -CredentialReferenceName 'svcp'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Id                        :
Kind                      : AzureSubscriptionCredential
LastModifiedAt            :
Name                      :
ResourceType              : {
                            }
Result                    :
ScanRulesetName           :
ScanRulesetType           :
Worker                    :
```

Create Azure resource sub Credential scan object

