### Example 1: Create Azure Sql Db Msi scan object
```powershell
PS C:\> New-AzPurviewAzureSqlDatabaseMsiScanObject -Kind 'AzureSqlDatabaseMsi' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDatabase' -ScanRulesetType 'System' -ServerEndpoint 'stzn.database.windows.net'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
DatabaseName              : db
Id                        :
Kind                      : AzureSqlDatabaseMsi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDatabase
ScanRulesetType           : System
ServerEndpoint            : stzn.database.windows.net
Worker                    :
```

Create Azure Sql Db Msi scan object

