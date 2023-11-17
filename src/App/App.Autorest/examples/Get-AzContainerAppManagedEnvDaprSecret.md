### Example 1: List secrets for a dapr component.
```powershell
Get-AzContainerAppManagedEnvDaprSecret -DaprName azps-dapr -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name      Value
----      -----
masterkey keyvalue
```

List secrets for a dapr component.