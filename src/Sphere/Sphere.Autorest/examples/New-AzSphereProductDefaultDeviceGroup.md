### Example 1: Generate default device groups for the product
```powershell
New-AzSphereProductDefaultDeviceGroup -CatalogName test2024 -ProductName product0207 -ResourceGroupName joyer-test
```

```output
Name                     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
Development                                                                                                                                                             joyer-test
Field Test                                                                                                                                                              joyer-test
Production                                                                                                                                                              joyer-test
Production OS Evaluation                                                                                                                                                joyer-test
Field Test OS Evaluation                                                                                                                                                joyer-test
```

This command generates default device groups for the product.

