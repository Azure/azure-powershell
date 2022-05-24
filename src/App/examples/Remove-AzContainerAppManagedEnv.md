### Example 1: Delete a Managed Environment.
```powershell
Remove-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName azpstest_gp
```

Delete a Managed Environment.

### Example 2: Delete a Managed Environment.
```powershell
Get-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName azpstest_gp | Remove-AzContainerAppManagedEnv
```

Delete a Managed Environment.