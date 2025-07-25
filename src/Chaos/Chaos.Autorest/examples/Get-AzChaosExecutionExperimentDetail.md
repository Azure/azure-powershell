### Example 1: Execution details of an experiment resource.
```powershell
Get-AzChaosExecutionExperimentDetail -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 13E31E28-45F4-402E-99B4-DF19A78E457E
```

```output
FailureReason      :
Id                 : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/13E31E28-45F4-402E-99B4-DF19A
                     78E457E
LastActionAt       : 2024-05-06 09:54:20 AM
Name               : 13E31E28-45F4-402E-99B4-DF19A78E457E
ResourceGroupName  : azps_test_group_chaos
RunInformationStep : {{
                       "stepName": "step1",
                       "stepId": "step1",
                       "status": "completed",
                       "branches": [
                         {
                           "branchName": "branch1",
                           "branchId": "branch1",
                           "status": "completed",
                           "actions": [
                             {
                               "actionName": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                               "actionId": "c5e62ae5-60c2-4cb4-b620-890bbf671c7b",
                               "status": "completed",
                               "startTime": "2024-05-06T09:43:15.6470366Z",
                               "endTime": "2024-05-06T09:54:16.1794070Z",
                               "targets": [
                                 {
                                   "status": "completed",
                                   "target": "urn:x-chaos-targets:Azure-virtualMachine:/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virt
                     ualMachines/exampleVM/providers/Microsoft.Chaos/targets/microsoft-virtualMachine",
                                   "targetFailedTime": "0001-01-01T00:00:00.0000000Z",
                                   "targetCompletedTime": "2024-05-06T09:54:16.1708885Z"
                                 }
                               ]
                             }
                           ]
                         }
                       ]
                     }}
StartedAt          : 2024-05-06 09:42:44 AM
Status             : Success
StoppedAt          : 2024-05-06 09:54:20 AM
Type               : Microsoft.Chaos/experiments/executions
```

Execution details of an experiment resource.