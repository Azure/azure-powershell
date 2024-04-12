### Example 1: Create Azure Sql Database Managed Instance Msi scan object
```powershell
New-AzPurviewAzureSqlDatabaseManagedInstanceMsiScanObject -Kind 'AzureSqlDatabaseManagedInstanceMsi' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDatabaseManagedInstance' -ScanRulesetType 'System' -ServerEndpoint 'tcp:sqstzn.public.5aaf14.database.windows.net,3342'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
DatabaseName              : db
Id                        :
Kind                      : AzureSqlDatabaseManagedInstanceMsi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDatabaseManagedInstance
ScanRulesetType           : System
ServerEndpoint            : tcp:sqstzn.public.5aaf14.database.windows.net,3342
Worker                    :
```

Create Azure Sql Database Managed Instance Msi scan object

