### Example 1: Update tags on a Compute Fleet using Update
```powershell
Update-AzComputeFleet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" `
    -Tag @{ environment = "staging" } |
    Select-Object Name, Tag, ProvisioningState
```

```output
Name              : managedFleet1
Tag               : {
                      "environment": "staging"
                    }
ProvisioningState : Succeeded
```

Sends a PATCH request using the `2026-08-01` Compute Fleet API. This request supplies the tag collection without resending the fleet's immutable compute profile. Tags supplied here replace the tag collection; include any existing tags you want to retain.

### Example 2: Update Spot capacity via pipeline input
```powershell
Get-AzComputeFleet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" |
    Update-AzComputeFleet -SpotPriorityProfileCapacity 3 |
    Select-Object Name, SpotPriorityProfileCapacity, ProvisioningState
```

```output
Name                        : managedFleet1
SpotPriorityProfileCapacity : 3
ProvisioningState           : Succeeded
```

Uses the existing fleet object's identity to PATCH its Spot capacity. The input object identifies the fleet; it is not sent as a complete replacement configuration. Increasing capacity can incur additional charges.