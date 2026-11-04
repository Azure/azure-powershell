### Example 1: Add a resource to a drill
```powershell
Update-AzResiliencyDrillResource -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FaultDurationInMin 30 -ResourceListIncludeResource @(@{ Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm" })
```

Adds a virtual machine to the drill and sets the fault duration to 30 minutes. `-OperationId` is a client-generated GUID that identifies this long-running operation.

### Example 2: Exclude a resource from a drill
```powershell
Update-AzResiliencyDrillResource -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FaultDurationInMin 30 -ResourceListExcludeResource "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm2"
```

Excludes a virtual machine from the drill.
