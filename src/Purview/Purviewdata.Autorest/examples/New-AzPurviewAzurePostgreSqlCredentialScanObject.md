### Example 1: Create Azure PostgreSql Credential scan object
```powershell
New-AzPurviewAzurePostgreSqlCredentialScanObject -Kind 'AzurePostgreSqlCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -Port 5432 -SslMode 1 -ScanRulesetName 'AzurePostgreSql' -ScanRulesetType 'System' -ServerEndpoint 'anstzn.postgres.database.azure.com'
```

```output
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

