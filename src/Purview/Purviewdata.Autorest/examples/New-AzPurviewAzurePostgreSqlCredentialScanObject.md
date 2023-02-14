### Example 1: Create Azure PostgreSql Credential scan object
```powershell
<<<<<<< HEAD
New-AzPurviewAzurePostgreSqlCredentialScanObject -Kind 'AzurePostgreSqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -SslMode 1 -ScanRulesetName 'AzurePostgreSql' -ScanRulesetType 'System' -ServerEndpoint 'anstzn.postgres.database.azure.com'
```

```output
=======
PS C:\> New-AzPurviewAzurePostgreSqlCredentialScanObject -Kind 'AzurePostgreSqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -SslMode 1 -ScanRulesetName 'AzurePostgreSql' -ScanRulesetType 'System' -ServerEndpoint 'anstzn.postgres.database.azure.com'

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
Kind                      : AzurePostgreSqlCredential
LastModifiedAt            :
Name                      :
Port                      : 5432
Result                    :
ScanRulesetName           : AzurePostgreSql
ScanRulesetType           : System
ServerEndpoint            : anstzn.postgres.database.azure.com
SslMode                   : 1
Worker                    :
```

Create Azure PostgreSql Credential scan object

