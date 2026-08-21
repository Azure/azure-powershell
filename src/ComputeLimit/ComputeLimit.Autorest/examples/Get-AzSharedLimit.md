### Example 1: List all shared limits in a location
```powershell
Get-AzSharedLimit -Location "eastus"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Lists all compute limits shared by the host subscription in the East US region.

### Example 2: Get a specific shared limit by name
```powershell
Get-AzSharedLimit -Location "eastus" -Name "mySharedLimit"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Gets the properties of a specific shared limit by name and location.