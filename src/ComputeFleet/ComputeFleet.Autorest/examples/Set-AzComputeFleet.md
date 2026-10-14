### Example 1: Update tags on a Managed mode Compute Fleet
```powershell
Set-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" `
    -Location "eastus2euap" `
    -Tag @{ EnableVMManagementPolicy = "true"; environment = "test" } | Select-Object Name, Location, Mode, Tag, ProvisioningState
```

```output
Name              : fleet5-001
Location          : eastus2euap
Mode              : Managed
Tag               : {
                      "EnableVMManagementPolicy": "true",
                      "environment": "test"
                    }
ProvisioningState : Succeeded
```

Updates the tags on an existing Managed mode Compute Fleet using a full PUT operation. Only `-Location` is required in addition to the fleet identity parameters. Properties not specified (such as `computeProfile`) are not sent in the request body. Note that `computeProfile` is immutable and must not be included when updating an existing fleet.

### Example 2: Update Spot priority capacity on a Managed mode Compute Fleet
```powershell
Set-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" `
    -Location "eastus2euap" `
    -SpotPriorityProfileCapacity 10 `
    -SpotPriorityProfileAllocationStrategy "LowestPrice" `
    -SpotPriorityProfileEvictionPolicy "Delete" `
    -Tag @{ EnableVMManagementPolicy = "true" } | Select-Object Name, SpotPriorityProfileCapacity, ProvisioningState
```

```output
Name              : fleet5-001
SpotPriorityProfileCapacity : 10
ProvisioningState : Succeeded
```

Uses `Set-AzComputeFleet` to replace the fleet configuration with updated Spot priority capacity. Since this is a PUT operation, any mutable properties not specified will be reset to defaults. Immutable properties like `computeProfile` must not be included.