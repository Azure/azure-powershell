### Example 1: List dapr component.
```powershell
Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azpstest_gp
```

```output
Name       ComponentType        IgnoreError InitTimeout ResourceGroupName Version
----       -------------        ----------- ----------- ----------------- -------
azps-dapr  state.azure.cosmosdb False       50s         azpstest_gp       v1
azps-dapr1 state.azure.cosmosdb True        50s         azpstest_gp       v1
```

List dapr component.

### Example 2: Get a dapr component.
```powershell
Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azpstest_gp -DaprName azps-dapr1
```

```output
Name       ComponentType        IgnoreError InitTimeout ResourceGroupName Version
----       -------------        ----------- ----------- ----------------- -------
azps-dapr1 state.azure.cosmosdb True        50s         azpstest_gp       v1
```

Get a dapr component.