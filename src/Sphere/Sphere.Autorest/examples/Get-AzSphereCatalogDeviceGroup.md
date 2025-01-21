### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCatalogDeviceGroup -CatalogName test2024 -ResourceGroupName group-test
```

```output
Name             SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      
----             ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      
testdevicegroup                                                                                                                                                 group-test
testdevicegroup2                                                                                                                                                group-test
```

This command gets list of device groups for the specified catalog with resource group.

