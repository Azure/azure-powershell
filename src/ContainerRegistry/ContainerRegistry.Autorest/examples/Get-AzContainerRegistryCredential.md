### Example 1: Get the login credentials for a container registry
```powershell
 Get-AzContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```

```output
Username            Password           Password2
--------            --------           ---------
RegistryExample     xxxxxxxxx          XXXXXXXXX
```

This command gets the login credentials for the specified container registry. Admin user has to be enabled for the container registry `RegistryExample` to get login credentials.
