### Example 1: List all Virtual Machine Scale Sets in a Managed mode fleet
```powershell
Get-AzComputeFleetVirtualMachineScaleSet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, OperationStatus
```

```output
Name                    OperationStatus
----                    ---------------
managedFleet1_44ad8d96    Succeeded
```

Lists all Virtual Machine Scale Set resources managed by the specified Compute Fleet. This cmdlet is only supported for fleets in Managed mode. Each VMSS is named with the fleet name followed by a unique identifier.

### Example 2: Get detailed properties of Virtual Machine Scale Sets in a fleet
```powershell
Get-AzComputeFleetVirtualMachineScaleSet -Name "managedFleet1" -ResourceGroupName "myResourceGroup" |
    Select-Object Name, Id, OperationStatus
```

```output
Name                    : managedFleet1_44ad8d96
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachineScaleSets/managedFleet1_44ad8d96
OperationStatus         : Succeeded
```

Retrieves the Virtual Machine Scale Sets in the fleet and displays their name, full ARM resource ID, and operation status. The OperationStatus indicates whether the VMSS was provisioned successfully.

Use `Get-AzComputeFleetVirtualMachine` instead when the fleet is in Launch mode.