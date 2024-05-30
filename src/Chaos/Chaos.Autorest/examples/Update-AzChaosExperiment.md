### Example 1: Update a Experiment resource Tag.
```powershell
Update-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -Location eastus -Tag @{"a"="1"}
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          : 72f14040-8265-4f10-b5ea-377c6fc2671c
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : EXPERIMENT-TEST
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "selector1",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microso
                               ft.Chaos/targets/Microsoft-VirtualMachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "step1",
                                 "branches": [
                                   {
                                     "name": "branch1",
                                     "actions": [
                                       {
                                         "type": "continuous",
                                         "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                                         "duration": "PT10M",
                                         "parameters": [
                                           {
                                             "key": "abruptShutdown",
                                             "value": "false"
                                           }
                                         ],
                                         "selectorId": "selector1"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-04-10 10:28:10 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-10 10:50:21 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Update a Experiment resource Tag.

### Example 1: Update a Experiment resource IdentityType.
```powershell
Update-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -Location eastus -UserAssignedIdentity "/subscriptions/{subId}/resourcegroups/azps_test_group_chaos/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami" -EnableSystemAssignedIdentity:$false
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : UserAssigned
IdentityUserAssignedIdentity : {
                                 "/subscriptions/{subId}/resourcegroups/azps_test_group_chaos/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami": {
                                 }
                               }
Location                     : eastus
Name                         : EXPERIMENT-TEST
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "selector1",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microso
                               ft.Chaos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "step1",
                                 "branches": [
                                   {
                                     "name": "branch1",
                                     "actions": [
                                       {
                                         "type": "continuous",
                                         "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                                         "duration": "PT5M",
                                         "parameters": [
                                           {
                                             "key": "abruptShutdown",
                                             "value": "false"
                                           }
                                         ],
                                         "selectorId": "selector1"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-04-17 03:14:43 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-17 03:20:23 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Update a Experiment resource IdentityType.