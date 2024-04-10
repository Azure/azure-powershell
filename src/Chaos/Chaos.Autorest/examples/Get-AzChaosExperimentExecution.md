### Example 1: Get an execution of an Experiment resource.
```powershell
Get-AzChaosExperimentExecution -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
```

```output
Id                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/1B326FD9-1E4D-4BD1-98CA-F700071C20
                    E1
Name              : 1B326FD9-1E4D-4BD1-98CA-F700071C20E1
ResourceGroupName : azps_test_group_chaos
StartedAt         : 2024-04-02 09:39:17 AM
Status            : Failed
StoppedAt         : 2024-04-02 09:40:10 AM
Type              : Microsoft.Chaos/experiments/executions
```

Get an execution of an Experiment resource.