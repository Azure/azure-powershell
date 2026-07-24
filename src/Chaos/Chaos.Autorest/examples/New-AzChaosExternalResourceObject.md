### Example 1: Create an external resource reference
```powershell
New-AzChaosExternalResourceObject -ResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm'
```

```output
ResourceId
----------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
```

Creates an in-memory external resource reference for a virtual machine. Use it to point a scenario action at a specific ARM resource.

### Example 2: Reference an external resource from a variable
```powershell
$vmId = (Get-AzVM -ResourceGroupName contoso-rg -Name contoso-vm).Id
New-AzChaosExternalResourceObject -ResourceId $vmId
```

```output
ResourceId
----------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
```

Creates an external resource reference from the resource id of an existing virtual machine.
