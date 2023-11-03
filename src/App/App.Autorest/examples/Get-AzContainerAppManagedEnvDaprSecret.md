### Example 1: Get secrets for a dapr component.
```powershell
Get-AzContainerAppManagedEnvDaprSecret -EnvName azps-env -ResourceGroupName azpstest_gp -DaprName azps-dapr
```

```output
Name      Value
----      -----
masterkey keyvalue
```

Get secrets for a dapr component.