### Example 1: Create Sql Server DB Credential scan object
```powershell
New-AzPurviewSqlServerDatabaseCredentialScanObject -Kind 'SqlServerDatabaseCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -ScanRulesetName 'SqlServer' -ScanRulesetType 'Custom' -ServerEndpoint '10.1.2.1' -ConnectedViaReferenceName 'IntegrationRuntime-NJh'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName : IntegrationRuntime-NJh
CreatedAt                 :
CredentialReferenceName   : sqlauth
CredentialType            : SqlAuth
DatabaseName              : db
Id                        :
Kind                      : SqlServerDatabaseCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : SqlServer
ScanRulesetType           : Custom
ServerEndpoint            : 10.1.2.1
Worker                    :
```

Create Swl Server DB Credential scan object

