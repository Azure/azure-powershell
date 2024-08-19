### Example 1: Get an execution of an Experiment resource.
```powershell
Get-AzChaosExperimentExecution -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos
```

```output
Name                                 ResourceGroupName
----                                 -----------------
F7FEAFD8-5D50-42A1-ADB7-044A19B997AA azps_test_group_chaos
13E31E28-45F4-402E-99B4-DF19A78E457E azps_test_group_chaos
```

Get an execution of an Experiment resource.

### Example 2: Get an execution of an Experiment resource.
```powershell
Get-AzChaosExperimentExecution -ExperimentName experiment-test -ResourceGroupName azps_test_group_chaos -ExecutionId 13E31E28-45F4-402E-99B4-DF19A78E457E
```

```output
Id                : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test/executions/13E31E28-45F4-402E-99B4-DF19A7
                    8E457E
Name              : 13E31E28-45F4-402E-99B4-DF19A78E457E
ResourceGroupName : azps_test_group_chaos
StartedAt         : 2024-05-06 09:42:44 AM
Status            : Success
StoppedAt         : 2024-05-06 09:54:20 AM
Type              : Microsoft.Chaos/experiments/executions
```

Get an execution of an Experiment resource.