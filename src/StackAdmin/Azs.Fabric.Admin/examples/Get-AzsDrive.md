### Example 1:
```powershell
PS C:\> Get-AzsDrive -ScaleUnit s-cluster -StorageSubSystem s-cluster.DomainFQDN
```

Get a list of all storage drives for a given cluster.

### Example 2:
```powershell
PS C:\> Get-AzsDrive -ScaleUnit s-cluster -StorageSubSystem s-cluster.DomainFQDN -Name '{a185d466-4d21-4c1f-9489-7c9c66b6b172}:PD:{fd389cf7-2115-2144-5afe-27910562d6b3}'
```

Get a storage drive by name for a given cluster.

