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

Retrieves the fleet with GET using the `2026-08-01` Compute Fleet API, updates its tags, and sends the modified configuration with PUT. The existing compute profile is included in the PUT request. Tags supplied here replace the tag collection; include any existing tags you want to retain.

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

Uses the piped fleet object's identity to retrieve the current configuration with GET, updates its Spot capacity, and sends the modified configuration with PUT, including the existing compute profile. Pipeline input supplies the identity, not the configuration sent in the PUT request. Increasing capacity can incur additional charges.