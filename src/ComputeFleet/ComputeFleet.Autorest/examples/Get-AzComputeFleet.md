### Example 1: Get a specific Compute Fleet by name
```powershell
Get-AzComputeFleet -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, Location, ProvisioningState, Mode, RegularPriorityProfileCapacity, RegularPriorityProfileAllocationStrategy
```

```output
Name                                     : fleet1
Location                                 : centralus
ProvisioningState                        : Succeeded
Mode                                     : Launch
RegularPriorityProfileCapacity           : 1
RegularPriorityProfileAllocationStrategy : LowestPrice
```

Retrieves a specific Compute Fleet by name and resource group, returning its full configuration including compute profile, VM sizes, priority settings, and provisioning state.

### Example 2: List all Compute Fleets in a resource group
```powershell
Get-AzComputeFleet -ResourceGroupName "myResourceGroup" |
    Select-Object Name, Location, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : centralus
ProvisioningState : Succeeded
Mode              : Launch
```

Lists all Compute Fleets within the specified resource group.

### Example 3: List all Compute Fleets in the current subscription
```powershell
Get-AzComputeFleet -SubscriptionId (Get-AzContext).Subscription.Id |
    Select-Object Name, Location, ResourceGroupName, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : centralus
ResourceGroupName : myResourceGroup
ProvisioningState : Succeeded
Mode              : Launch

Name              : managedFleet1
Location          : centralus
ResourceGroupName : myResourceGroup
ProvisioningState : Succeeded
Mode              : Managed
```

Lists all Compute Fleets across all resource groups in the current subscription.

### Example 4: Get a fleet using its identity
```powershell
$fleet = Get-AzComputeFleet -Name "fleet1" -ResourceGroupName "myResourceGroup"
Get-AzComputeFleet -InputObject $fleet |
    Select-Object Name, Mode, ProvisioningState
```

Retrieves the same fleet using the identity contained in an existing fleet object.