### Example 1: List availability zones for a location
```powershell
PS C:\> Get-AzDiskPoolZone -Location eastus

SkuName  SkuTier  AvailabilityZone AdditionalCapability
-------  -------  ---------------- --------------------
Basic    Basic    {3, 1, 2}
Standard Standard {3, 1, 2}
Premium  Premium  {3, 1, 2}
```

The command lists all availability zones for a location.
