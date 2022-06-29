### Example 1: Create Azure Sql Data Warehouse Msi scan object
```powershell
PS C:\> New-AzPurviewAzureSqlDataWarehouseMsiScanObject -Kind 'AzureSqlDataWarehouseMsi' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DatabaseName 'db' -ScanRulesetName 'AzureSqlDataWarehouse' -ScanRulesetType 'System' -ServerEndpoint 'canstzn.database.windows.net'

CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
DatabaseName              : db
Id                        :
Kind                      : AzureSqlDataWarehouseMsi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureSqlDataWarehouse
ScanRulesetType           : System
ServerEndpoint            : canstzn.database.windows.net
Worker                    :
```

Create Azure Sql Data Warehouse Msi scan object

