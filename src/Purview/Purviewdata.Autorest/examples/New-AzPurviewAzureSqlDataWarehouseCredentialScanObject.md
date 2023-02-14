### Example 1: Create Azure Sql Data Warehouse Credential scan object
```powershell
<<<<<<< HEAD
New-AzPurviewAzureSqlDataWarehouseCredentialScanObject -Kind 'AzureSqlDataWarehouseCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDataWarehouse' -ScanRulesetType 'System' -ServerEndpoint 'canstzn.database.windows.net' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth'
```

```output
=======
PS C:\>  New-AzPurviewAzureSqlDataWarehouseCredentialScanObject -Kind 'AzureSqlDataWarehouseCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDataWarehouse' -ScanRulesetType 'System' -ServerEndpoint 'canstzn.database.windows.net' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth'

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
Kind                      : AzureSqlDataWarehouseCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDataWarehouse
ScanRulesetType           : System
ServerEndpoint            : canstzn.database.windows.net
Worker                    :
```

Create Azure Sql Data Warehouse Credential scan object

