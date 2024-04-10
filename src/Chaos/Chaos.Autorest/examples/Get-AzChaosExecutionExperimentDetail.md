### Example 1: Execution details of an experiment resource.
```powershell
Get-AzChaosExecutionExperimentDetail -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
```

```output
FailureReason      :
Id                 : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/1B326FD9-1E4D-4BD1-98CA-F700071C2
                     0E1
LastActionAt       :
Name               : 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
ResourceGroupName  : azps_test_group_chaos
RunInformationStep :
StartedAt          : 2024-04-02 09:39:17 AM
Status             : PreProcessingQueued
StoppedAt          :
Type               : Microsoft.Chaos/experiments/executions
```

Execution details of an experiment resource.