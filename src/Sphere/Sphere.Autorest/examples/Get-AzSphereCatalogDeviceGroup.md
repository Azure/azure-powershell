### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCatalogDeviceGroup -CatalogName test2024 -ResourceGroupName joyer-test
```

```output
Name             SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      
----             ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      
testdevicegroup                                                                                                                                                 joyer-test
testdevicegroup2                                                                                                                                                joyer-test
```

This command gets list of device groups for the specified catalog with resource group.

