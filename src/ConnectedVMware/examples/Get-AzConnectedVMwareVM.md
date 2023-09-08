### Example 1: List VMs in current subscription
```powershell
Get-AzConnectedVMwareVM -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
AVS    eastus        namratmpvm                                                       naprajap
VMware eastus        vmurthy-vm01                                                     vmurthy-rg
AVS    eastus        VM-avs-0511                                                      k0
VMware eastus        namraonpremvm                                                    uxsetups
VMware eastus        uxvmwareLinuxVM                                                  uxsetups
VMware eastus        namrawintest                                                     uxsetups
VMware eastus        TulipVM2                                                         shujRG
VMware eastus        TulipVM3                                                         shujRG
```

This command lists VMs in current subscription.

### Example 2: List VMs in a resource group
```powershell
Get-AzConnectedVMwareVM -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vm      azcli-test-rg
VMware eastus   test-vm2     azcli-test-rg
```

This command lists VMs in a resource group named `azcli-test-rg`.

### Example 3: Get a specific VM
```powershell
Get-AzConnectedVMwareVM -Name "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vm      azcli-test-rg
```

This command gets a VM named `test-vm` in a resource group named `azcli-test-rg`