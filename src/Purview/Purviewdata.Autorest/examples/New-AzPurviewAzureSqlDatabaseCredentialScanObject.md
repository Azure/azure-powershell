### Example 1: Create Azure Sql Db Credential scan object
```powershell
New-AzPurviewAzureSqlDatabaseCredentialScanObject -Kind 'AzureSqlDatabaseCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDatabase' -ScanRulesetType 'System' -ServerEndpoint 'stzn.database.windows.net'
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
Kind                      : AzureSqlDatabaseCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDatabase
ScanRulesetType           : System
ServerEndpoint            : stzn.database.windows.net
Worker                    :
```

Create Azure Sql Db Credential scan object

