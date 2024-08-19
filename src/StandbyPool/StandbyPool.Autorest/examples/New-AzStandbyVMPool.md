### Example 1: Creat a new standby virtual machine pool
```powershell
New-AzStandbyVMPool `
-Name testPool `
-ResourceGroupName test-standbypool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-Location eastus `
-VMSSId /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss `
-MaxReadyCapacity 1 `
-VMState Running
```

```output
AttachedVirtualMachineScaleSetId  : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss
ElasticityProfileMaxReadyCapacity : 1
Id                                : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.StandbyPool/standbyVirtualMachinePools/testPool
Location                          : eastus
Name                              : testPool
ProvisioningState                 : Succeeded
ResourceGroupName                 : test-standbypool
SystemDataCreatedAt               : 4/10/2024 7:15:23 PM
SystemDataCreatedBy               : dev@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 4/10/2024 7:15:23 PM
SystemDataLastModifiedBy          : dev@microsoft.com
SystemDataLastModifiedByType      : User
Tag                               : {
                                    }
Type                              : microsoft.standbypool/standbyvirtualmachinepools
VirtualMachineState               : Running
```

Above commnand is creating a new standby virtual machine pool
