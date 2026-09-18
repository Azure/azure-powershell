### Example 1: Enable sharing of a compute limit
```powershell
Add-AzSharedLimit -Location "eastus" -Name "mySharedLimit"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Enables sharing of a compute limit by the host subscription with its guest subscriptions in the specified location.

### Example 2: Enable sharing of a compute limit in a different region
```powershell
Add-AzSharedLimit -Location "westeurope" -Name "standardDSv3Family"
```

```output
Name               Location   ProvisioningState
----               --------   -----------------
standardDSv3Family westeurope Succeeded
```

Enables sharing of the Standard DSv3 Family compute limit in the West Europe region.
