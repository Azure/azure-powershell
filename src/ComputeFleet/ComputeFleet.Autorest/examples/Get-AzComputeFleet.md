### Example 1: Get a specific Compute Fleet by name
```powershell
Get-AzComputeFleet -Name "fleet1" -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Location, ProvisioningState, Mode, RegularPriorityProfileCapacity, RegularPriorityProfileAllocationStrategy
```

```output
Name                                     : fleet1
Location                                 : EastUS2EUAP
ProvisioningState                        : Succeeded
Mode                                     : Launch
RegularPriorityProfileCapacity           : 5
RegularPriorityProfileAllocationStrategy : LowestPrice
```

Retrieves a specific Compute Fleet by name and resource group, returning its full configuration including compute profile, VM sizes, priority settings, and provisioning state.

### Example 2: List all Compute Fleets in a resource group
```powershell
Get-AzComputeFleet -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Location, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : EastUS2EUAP
ProvisioningState : Succeeded
Mode              : Launch
```

Lists all Compute Fleets within the specified resource group.

### Example 3: List all Compute Fleets in the current subscription
```powershell
Get-AzComputeFleet | Select-Object Name, Location, ResourceGroupName, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : EastUS2EUAP
ResourceGroupName : FLEET-PS-TST
ProvisioningState : Succeeded
Mode              : Launch

Name              : fleet5-001
Location          : eastus2euap
ResourceGroupName : MY-FLEET-RG-001
ProvisioningState : Succeeded
Mode              : Managed
```

Lists all Compute Fleets across all resource groups in the current subscription.