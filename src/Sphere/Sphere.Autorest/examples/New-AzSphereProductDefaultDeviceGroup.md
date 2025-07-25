### Example 1: Generate default device groups for the product
```powershell
New-AzSphereProductDefaultDeviceGroup -CatalogName test2024 -ProductName product0207 -ResourceGroupName group-test
```

```output
Name                     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
Development                                                                                                                                                             group-test
Field Test                                                                                                                                                              group-test
Production                                                                                                                                                              group-test
Production OS Evaluation                                                                                                                                                group-test
Field Test OS Evaluation                                                                                                                                                group-test
```

This command generates default device groups for the product.

