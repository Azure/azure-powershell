### Example 1: Update standby virtual machine pool's max ready capacity.
```powershell
Update-AzStandbyVMPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-ResourceGroupName test-standbypool `
-Name testPool `
-MaxReadyCapacity 2
```

```output
AttachedVirtualMachineScaleSetId  : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss
ElasticityProfileMaxReadyCapacity : 2
Id                                : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.StandbyPool/standbyVirtualMachinePools/testPool
Location                          : eastus
Name                              : testPool
ProvisioningState                 : Succeeded
ResourceGroupName                 : test-standbypool
SystemDataCreatedAt               : 4/10/2024 7:15:23 PM
SystemDataCreatedBy               : dev@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 4/10/2024 7:18:46 PM
SystemDataLastModifiedBy          : dev@microsoft.com
SystemDataLastModifiedByType      : User
Tag                               : {
                                    }
Type                              : microsoft.standbypool/standbyvirtualmachinepools
VirtualMachineState               : Running
```

Above command is updating standby virtual machine pool's max ready capacity.
