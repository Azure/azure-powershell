### Example 1: Lists all resources and skus in a location
```powershell
<<<<<<< HEAD
Get-AzDiskPoolResourceSku -Location AustraliaEast
```

```output
=======
PS C:\> Get-AzDiskPoolResourceSku -Location AustraliaEast

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ApiVersion Name        ResourceType Tier
---------- ----        ------------ ----
2021-08-01 Standard_S1 diskPools    Standard
2021-08-01 Premium_P1  diskPools    Premium
2021-08-01 Basic_B1    diskPools    Basic
```

The command lists all resources and skus in a location.


