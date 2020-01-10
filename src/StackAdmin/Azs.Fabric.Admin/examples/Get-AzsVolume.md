### Example 1:
```powershell
PS C:\> Get-AzsVolume -ScaleUnit s-cluster -StorageSubSystem s-cluster.DomainFQDN
```

Get a list of all storage volumes at a given location.

### Example 2:
```powershell
PS C:\> Get-AzsVolume -ScaleUnit s-cluster -StorageSubSystem s-cluster.DomainFQDN -Name ee594cf5-cf54-46b4-a641-139553307195
```

Get a storage volume by name at a given location.

