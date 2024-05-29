### Example 1: Create an in-memory object for ContainerRegistryBasicCredentials.
```powershell
New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
```

```output
Password        Server             Type      Username
--------        ------             ----      --------
ibOL0******887K azpsacr.azurecr.io BasicAuth azpsacr
```

Create an in-memory object for ContainerRegistryBasicCredentials.