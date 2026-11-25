### Example 1: List all virtual machines in a Launch mode fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, OperationStatus
```

```output
Name                         OperationStatus
----                         ---------------
fleet1prefix_b223f9c1_0      Succeeded
```

Lists the VMs launched by the fleet and their launch operation status. During provisioning, `OperationStatus` can progress through `Launching` and `Creating` before reaching `Succeeded`. This is the fleet launch status, not the VM's guest operating system or power state.

### Example 2: Get full details of virtual machines in a fleet
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, Id, OperationStatus
```

```output
Name                    : fleet1prefix_b223f9c1_0
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/fleet1prefix_b223f9c1_0
OperationStatus         : Succeeded
```

Retrieves the virtual machines in the fleet and displays their name, full ARM resource ID, and operation status.

### Example 3: Find VM launches that have not succeeded
```powershell
Get-AzComputeFleetVirtualMachine -Name "fleet1" -ResourceGroupName "myResourceGroup" |
    Where-Object OperationStatus -ne "Succeeded" |
    Select-Object Name, OperationStatus
```

Returns pending or unsuccessful launches for inspection. No output means every returned VM has reached `Succeeded`; it does not establish that the fleet returned any VMs.