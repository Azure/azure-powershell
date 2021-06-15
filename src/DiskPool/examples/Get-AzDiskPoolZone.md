### Example 1: List availability zones for a location
```powershell
PS C:\> Get-AzDiskPoolZone -Location eastus

AdditionalCapability AvailabilityZone
-------------------- ----------------
                     {3, 1, 2}
                     {3, 1, 2}
                     {3, 1, 2}
```

The command lists all availability zones for a location.
