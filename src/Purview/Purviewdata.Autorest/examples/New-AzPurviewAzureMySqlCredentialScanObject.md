### Example 1: Create Azure MySql Credential scan object
```powershell
<<<<<<< HEAD
New-AzPurviewAzureMySqlCredentialScanObject -Kind 'AzureMySqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -ScanRulesetName 'AzureMySql' -ScanRulesetType 'System' -ServerEndpoint 'tzn.mysql.database.azure.com'
```

```output
=======
PS C:\> New-AzPurviewAzureMySqlCredentialScanObject -Kind 'AzureMySqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -ScanRulesetName 'AzureMySql' -ScanRulesetType 'System' -ServerEndpoint 'tzn.mysql.database.azure.com'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : sqlauth
CredentialType            : SqlAuth
DatabaseName              : db
Id                        :
Kind                      : AzureMySqlCredential
LastModifiedAt            :
Name                      :
Port                      : 5432
Result                    :
ScanRulesetName           : AzureMySql
ScanRulesetType           : System
ServerEndpoint            : tzn.mysql.database.azure.com
Worker                    :
```

Create Azure MySql Credential scan object

