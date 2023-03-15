### Example 1: List Hosts in current subscription
```powershell
Get-AzConnectedVMwareHost -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        esx04-r03-p01-f71506e8bc3e432e9ec20-southcentralus-avs-azure-com demo-2021
       eastus        esx11-r16-p01-fe4e4b599359446380db42-southeastasia-avs-azure-com naprajap
       eastus        test-host                                                        service-sdk-test
       eastus        esx12-r14-p01-f71506e8bc3e432e9ec20-southcentralus-avs-azure-com ArcbenchVM
       eastus        10-150-101-34                                                    t-ahelc-arcResource
       eastus        esx17-r07-p01-fe4e4b599359446380db42-southeastasia-avs-azure-com dshiferaw
       eastus        ArcVMwareSyntheticsInventoryHost                                 ArcVMwareSynthetics-eastus-05082022-055514AM
```

This command lists Hosts in current subscription.

### Example 2: List Hosts in a resource group
```powershell
Get-AzConnectedVMwareHost -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-host    azcli-test-rg
VMware eastus   test-host2   azcli-test-rg
```

This command lists Hosts in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Host
```powershell
Get-AzConnectedVMwareHost -Name "test-host" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-host    azcli-test-rg
```

This command gets a Host named `test-host` in a resource group named `azcli-test-rg`.