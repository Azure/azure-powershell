### Example 1: Create Azure Sql Database Managed Instance Credential scan object
```powershell
New-AzPurviewAzureSqlDatabaseManagedInstanceCredentialScanObject -Kind 'AzureSqlDatabaseManagedInstanceCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDatabaseManagedInstance' -ScanRulesetType 'System' -ServerEndpoint 'tcp:sqstzn.public.5aaf14.database.windows.net,3342'
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
Kind                      : AzureSqlDatabaseManagedInstanceCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDatabaseManagedInstance
ScanRulesetType           : System
ServerEndpoint            : tcp:sqstzn.public.5aaf14.database.windows.net,3342
Worker                    :
```

Create Azure Sql Database Managed Instance Credential scan object

