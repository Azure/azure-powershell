### Example 1: Create Azure Data Explorer Credential scan object
```powershell
PS C:\> New-AzPurviewAzureDataExplorerCredentialScanObject -Kind 'AzureDataExplorerCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'svcp' -CredentialType 'ServicePrincipal' -ScanRulesetName 'AzureDataExplorer' -ScanRulesetType 'System'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Database                  :
Id                        :
Kind                      : AzureDataExplorerCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureDataExplorer
ScanRulesetType           : System
Worker                    :
```

Create Azure Data Explorer Credential scan object

