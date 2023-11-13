### Example 1: Create a Volume object for ContainerApp.
```powershell
New-AzContainerAppVolumeObject -Name "volumeName" -StorageName "azpssa"
```

```output
MountOption Name       StorageName StorageType
----------- ----       ----------- -----------
            volumeName azpssa
```

Create a Volume object for ContainerApp.