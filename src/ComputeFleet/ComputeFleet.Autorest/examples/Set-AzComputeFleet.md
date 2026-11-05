### Example 1: Update tags on a Managed mode Compute Fleet
```powershell
Set-AzComputeFleet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" `
    -Location "centralus" `
    -Tag @{ environment = "test" } |
    Select-Object Name, Location, Mode, Tag, ProvisioningState
```

```output
Name              : managedFleet1
Location          : centralus
Mode              : Managed
Tag               : {
                      "environment": "test"
                    }
ProvisioningState : Succeeded
```

Sends a PUT create-or-update request for the existing fleet. `-Location` is required. This tag-only example omits `computeProfile`, which cannot be changed after creation. For partial updates, prefer `Update-AzComputeFleet`.

### Example 2: Update Spot priority capacity on a Managed mode Compute Fleet
```powershell
Set-AzComputeFleet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" `
    -Location "centralus" `
    -SpotPriorityProfileCapacity 3 `
    -SpotPriorityProfileAllocationStrategy "LowestPrice" `
    -SpotPriorityProfileEvictionPolicy "Delete" `
    -Tag @{ environment = "test" } |
    Select-Object Name, SpotPriorityProfileCapacity, ProvisioningState
```

```output
Name                        : managedFleet1
SpotPriorityProfileCapacity : 3
ProvisioningState : Succeeded
```

Configures the mutable Spot priority profile through a PUT request. The requested VM capacity can incur additional charges. Do not include a different compute profile when updating an existing fleet.