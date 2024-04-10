### Example 1: Update a Experiment resource Tag.
```powershell
Update-AzChaosExperiment -Name experiment-test0410 -ResourceGroupName azps_test_group_chaos -Location eastus2euap -Tag @{"a"="1"}
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST0410
IdentityPrincipalId          : 72f14040-8265-4f10-b5ea-377c6fc2671c
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2euap
Name                         : EXPERIMENT-TEST0410
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "selector1",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM0410/providers/Microso
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