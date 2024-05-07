### Example 1: Create Or Update a Experiment resource for Json File Path.
```powershell
New-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -JsonFilePath "C:\Users\abc\Desktop\jsonStr.json"
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
SystemDataLastModifiedAt     : 2024-04-10 10:32:47 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Create Or Update a Experiment resource for Json File Path.

### Example 2: Create Or Update a Experiment resource for Json String.
```powershell
$jsonStr = '
{
  "location": "eastus",
  "identity": {
    "type": "SystemAssigned"
  },
  "properties": {
    "steps": [
      {
        "name": "step1",
        "branches": [
          {
            "name": "branch1",
            "actions": [
              {
                "type": "continuous",
                "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                "selectorId": "selector1",
                "duration": "PT10M",
                "parameters": [
                  {
                    "key": "abruptShutdown",
                    "value": "false"
                  }
                ]
              }
            ]
          }
        ]
      }
    ],
    "selectors": [
      {
        "type": "List",
        "id": "selector1",
        "targets": [
          {
            "type": "ChaosTarget",
            "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/azpstest1/providers/Microsoft.Chaos/targets/microsoft-virtualmachine"
          }
        ]
      }
    ]
  }
}'

New-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -JsonString $jsonStr
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
SystemDataLastModifiedAt     : 2024-04-10 10:32:47 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Create Or Update a Experiment resource for Json String.