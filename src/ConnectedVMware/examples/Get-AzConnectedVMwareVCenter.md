### Example 1: List VCenters in current subscription
```powershell
Get-AzConnectedVMwareVCenter -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                ResourceGroupName
----   --------      ----                                                -----------------
VMware eastus        vmurthy-vcenter                                     vmurthy-rg
VMware eastus        FirstPartyLab-ArcvCenter                            snmuvva-pm-demos
VMware eastus        demovcenter                                         partnertest
VMware eastus        testvcenter                                         naprajap
VMware eastus        uxvmwarevcenter                                     uxsetups
AVS    eastus        uxavsvcenter                                        uxsetups
VMware eastus        TulipvCenter                                        shujRG
VMware EastUS        pujgupta-vcenter                                    pujgupta-AzureArcTest
```

This command lists VCenters in current subscription.

### Example 2: List VCenters in a resource group
```powershell
Get-AzConnectedVMwareVCenter -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vc      azcli-test-rg
VMware eastus   test-vc2     azcli-test-rg
```

This command lists VCenters in a resource group named `azcli-test-rg`.

### Example 3: Get a specific VCenter
```powershell
Get-AzConnectedVMwareVCenter -Name "test-vc" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vc      azcli-test-rg
```

This command gets a VCenter named `test-vc` in a resource group named `azcli-test-rg`.