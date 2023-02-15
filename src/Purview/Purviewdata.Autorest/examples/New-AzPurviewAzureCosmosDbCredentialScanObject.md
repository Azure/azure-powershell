### Example 1: Create Azure CosmosDb Credential scan object
```powershell
PS C:\>  New-AzPurviewAzureCosmosDbCredentialScanObject -Kind 'AzureCosmosDbCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'datascantestdataparv-accountkey' -CredentialType 'AccountKey' -ScanRulesetName 'AzureCosmosDb'  -ScanRulesetType 'System' -DatabaseName 'db'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : datascantestdataparv-accountkey
CredentialType            : AccountKey
DatabaseName              : db
Id                        :
Kind                      : AzureCosmosDbCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureCosmosDb
ScanRulesetType           : System
Worker                    :
```

Create Azure CosmosDb Credential scan object

