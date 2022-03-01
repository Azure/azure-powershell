### Example 1: Create Azure resource group Credential scan object
```powershell
PS C:\> New-AzPurviewAzureResourceGroupCredentialScanObject -Kind 'AzureResourceGroupCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialType 'ServicePrincipal' -CredentialReferenceName 'svcp'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Id                        :
Kind                      : AzureResourceGroupCredential
LastModifiedAt            :
Name                      : ScanTest
ResourceType              : {
                            }
Result                    :
ScanRulesetName           :
ScanRulesetType           :
Worker                    :
```

Create Azure resource group Credential scan object

