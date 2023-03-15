### Example 1: List Inventory Items in a resource group
```powershell
Get-AzConnectedVMwareInventoryItem -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name                Kind                   ResourceGroupName
----                ----                   -----------------
resgroup-713957     ResourcePool           azcli-test-rg
resgroup-754929     ResourcePool           azcli-test-rg
resgroup-713962     ResourcePool           azcli-test-rg
dvportgroup-1153526 VirtualNetwork         azcli-test-rg
host-713958         Host                   azcli-test-rg
vmtpl-vm-1085854    VirtualMachineTemplate azcli-test-rg
datastore-563660    Datastore              azcli-test-rg
domain-c721505      Cluster                azcli-test-rg
```

This command lists Clusters in a resource group named `azcli-test-rg`.

### Example 2: Get a specific Inventory Item
```powershell
Get-AzConnectedVMwareInventoryItem -Name "domain-c649660" -VcenterName "azcli-test-vc" -ResourceGroupName "azcli-test-rg"
-SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name           Kind    ResourceGroupName
----           ----    -----------------
domain-c649660 Cluster azcli-test-rg
```

This command gets a Inventory Item named `test-cluster` in a resource group named `azcli-test-rg`.