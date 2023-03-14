### Example 1: List Resource Pools in current subscription
```powershell
Get-AzConnectedVMwareResourcePool -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                          ResourceGroupName
----   --------      ----                                          -----------------
       eastus        vmurthy-rp                                    vmurthy-rg
       eastus        demorp                                        partnertest
       eastus        uxvmwarerp                                    uxsetups
       eastus        uxavsrp                                       uxsetups
       eastus        tulip-rp                                      shujRG
       eastus        niaro-respool                                 partner-test-appliance-eus
       eastus        shubhamRP                                     shujRG
       eastus        avs-rp                                        support-arc-rg
```

This command lists Resource Pools in current subscription.

### Example 2: List Resource Pools in a resource group
```powershell
Get-AzConnectedVMwareResourcePool -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-rp      azcli-test-rg
VMware eastus   test-rp2     azcli-test-rg
```

This command lists Resource Pools in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Resource Pool
```powershell
Get-AzConnectedVMwareResourcePool -Name "test-rp" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-rp      azcli-test-rg
```

This command gets a Resource Pool named `test-rp` in a resource group named `azcli-test-rg`.