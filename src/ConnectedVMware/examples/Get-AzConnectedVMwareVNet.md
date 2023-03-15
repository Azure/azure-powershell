### Example 1: List Virtual Networks in current subscription
```powershell
Get-AzConnectedVMwareVNet -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        segment-2                                                        vmurthy-rg
       eastus        demonetwork                                                      partnertest
       eastus        uxvmwarenetwork1                                                 uxsetups
       eastus        uxvmwarenetwork2                                                 uxsetups
       eastus        uxavsnetwork1                                                    uxsetups
       eastus        uxavsnetwork2                                                    uxsetups
       eastus        NIC2                                                             partner-test-appliance-eus
       eastus        VMnetwork                                                        partner-test-appliance-eus
       eastus        Proxy-Network                                                    partner-test-appliance-eus
       eastus        appliance-segment                                                shujRG
       eastus        appliance-segment                                                support-arc-rg
```

This command lists Virtual Networks in current subscription.

### Example 2: List Virtual Networks in a resource group
```powershell
Get-AzConnectedVMwareVNet -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vnet    azcli-test-rg
VMware eastus   test-vnet2   azcli-test-rg
```

This command lists Virtual Networks in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Virtual Network
```powershell
Get-AzConnectedVMwareVNet -Name "test-vnet" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vnet azcli-test-rg
```

This command gets a Virtual Network named `test-vnet` in a resource group named `azcli-test-rg`.