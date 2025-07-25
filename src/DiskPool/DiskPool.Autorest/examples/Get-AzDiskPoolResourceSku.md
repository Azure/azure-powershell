### Example 1: Lists all resources and skus in a location
```powershell
Get-AzDiskPoolResourceSku -Location AustraliaEast
```

```output
ApiVersion Name        ResourceType Tier
---------- ----        ------------ ----
2021-08-01 Standard_S1 diskPools    Standard
2021-08-01 Premium_P1  diskPools    Premium
2021-08-01 Basic_B1    diskPools    Basic
```

The command lists all resources and skus in a location.


