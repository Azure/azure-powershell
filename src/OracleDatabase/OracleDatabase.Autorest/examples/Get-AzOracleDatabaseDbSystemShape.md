### Example 1: Gets a list of the Database System Shapes by location
```powershell
Get-AzOracleDatabaseDbSystemShape -Location "eastus"
```

```output
AvailableCoreCount                : 0
AvailableCoreCountPerNode         : 126
AvailableDataStorageInTb          : 63
AvailableDataStoragePerServerInTb : 
AvailableDbNodePerNodeInGb        : 2243
AvailableDbNodeStorageInGb        : 
AvailableMemoryInGb               : 
AvailableMemoryPerNodeInGb        : 1390
CoreCountIncrement                : 
Id                                : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/providers/Oracle.Database/locations/eastus/dbSystemShapes/Exadata.X9M
MaxStorageCount                   : 
MaximumNodeCount                  : 32
MinCoreCountPerNode               : 0
MinDataStorageInTb                : 2
MinDbNodeStoragePerNodeInGb       : 60
MinMemoryPerNodeInGb              : 30
MinStorageCount                   : 
MinimumCoreCount                  : 0
MinimumNodeCount                  : 2
Name                              : Exadata.X9M
ResourceGroupName                 : 
RuntimeMinimumCoreCount           : 
ShapeFamily                       : EXADATA
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Type                              : Oracle.Database/Locations/dbSystemShapes
```

Gets a list of the Database System Shapes by location.
For more information, execute `Get-Help Get-AzOracleDatabaseDbSystemShape`