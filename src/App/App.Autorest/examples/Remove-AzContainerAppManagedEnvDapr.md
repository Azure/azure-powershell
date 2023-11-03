### Example 1: Delete a Dapr Component from a Managed Environment.
```powershell
Remove-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azpstest_gp -DaprName azps-dapr
```

Delete a Dapr Component from a Managed Environment.

### Example 2: Delete a Dapr Component from a Managed Environment.
```powershell
Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azpstest_gp -DaprName azps-dapr | Remove-AzContainerAppManagedEnvDapr
```

Delete a Dapr Component from a Managed Environment.