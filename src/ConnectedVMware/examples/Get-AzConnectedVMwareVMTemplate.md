### Example 1: List VM Templates in current subscription
```powershell
Get-AzConnectedVMwareVMTemplate -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                             ResourceGroupName
----   --------      ----                                             -----------------
       eastus        ubuntu2004                                       vmurthy-rg
       eastus        demotemplate                                     partnertest
       eastus        uxvmwareWintemplate                              uxsetups
       eastus        uxvmwareLinuxtemplate                            uxsetups
       eastus        uxvmwareBlanktemplate                            uxsetups
       eastus        uxvmwareBlank2nics2disktemplate                  uxsetups
```

This command lists VM Templates in current subscription.

### Example 2: List VM Templates in a resource group
```powershell
Get-AzConnectedVMwareVMTemplate -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vmtmpl  azcli-test-rg
VMware eastus   test-vmtmpl2 azcli-test-rg
```

This command lists VM Templates in a resource group named `azcli-test-rg`.

### Example 3: Get a specific VM Template
```powershell
Get-AzConnectedVMwareVMTemplate -Name "test-vmtmpl" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vmtmpl azcli-test-rg
```

This command gets a VM Template named `test-vmtmpl` in a resource group named `azcli-test-rg`.