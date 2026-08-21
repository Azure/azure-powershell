### Example 1: List all virtual machines in a Launch mode fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "fleet-ps-tst"
```

```output
Name                         OperationStatus
----                         ---------------
fleet1prefix_b223f9c1_0      Succeeded
fleet1prefix_b223f9c1_1      Succeeded
fleet1prefix_b223f9c1_2      Succeeded
fleet1prefix_b223f9c1_3      Succeeded
fleet1prefix_b223f9c1_4      Succeeded
```

Lists all virtual machines belonging to the specified Launch mode Compute Fleet. Each VM is named with the fleet's VM name prefix followed by a unique identifier.

### Example 2: Get full details of virtual machines in a fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Id, OperationStatus
```

```output
Name                    : fleet1prefix_b223f9c1_0
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fleet-ps-tst/providers/Microsoft.Compute/virtualMachines/fleet1prefix_b223f9c1_0
OperationStatus         : Succeeded
```

Retrieves the virtual machines in the fleet and displays their name, full ARM resource ID, and operation status.