### Example 1: List availability zones for a location
```powershell
<<<<<<< HEAD
Get-AzDiskPoolZone -Location eastus
```

```output
=======
PS C:\> Get-AzDiskPoolZone -Location eastus

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
SkuName  SkuTier  AvailabilityZone AdditionalCapability
-------  -------  ---------------- --------------------
Basic    Basic    {3, 1, 2}
Standard Standard {3, 1, 2}
Premium  Premium  {3, 1, 2}
```

The command lists all availability zones for a location.
