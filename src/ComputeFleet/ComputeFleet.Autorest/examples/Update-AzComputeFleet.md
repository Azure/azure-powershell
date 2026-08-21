### Example 1: Update tags on a Compute Fleet using Update
```powershell
Update-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" `
    -Tag @{ EnableVMManagementPolicy = "true"; environment = "staging" } | Select-Object Name, Tag, ProvisioningState
```

```output
Name              : fleet5-001
Tag               : {
                      "EnableVMManagementPolicy": "true",
                      "environment": "staging"
                    }
ProvisioningState : Succeeded
```

Updates the tags on a Managed mode Compute Fleet. The `Update-AzComputeFleet` cmdlet performs a read-modify-write operation — it fetches the existing fleet, merges only the properties you specify, and PUTs the result back. This means unspecified properties retain their existing values.

### Example 2: Update Spot capacity via pipeline input
```powershell
Get-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" | Update-AzComputeFleet `
    -SpotPriorityProfileCapacity 8 | Select-Object Name, SpotPriorityProfileCapacity, ProvisioningState
```

```output
Name                        : fleet5-001
SpotPriorityProfileCapacity : 8
ProvisioningState           : Succeeded
```

Retrieves an existing Compute Fleet and pipes it to `Update-AzComputeFleet` using the `-InputObject` parameter set. Only the Spot priority capacity is changed; all other properties are preserved from the existing fleet. Note that `computeProfile` is immutable and cannot be changed after fleet creation.