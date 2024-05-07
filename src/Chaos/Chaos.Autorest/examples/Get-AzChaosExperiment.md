### Example 1: List Experiment resource.
```powershell
Get-AzChaosExperiment
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

List Experiment resource.

### Example 2: List Experiment resource.
```powershell
Get-AzChaosExperiment -ResourceGroupName azps_test_group_chaos
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

List Experiment resource.

### Example 3: Get a Experiment resource.
```powershell
Get-AzChaosExperiment -ResourceGroupName azps_test_group_chaos -Name experiment-test
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Get a Experiment resource.