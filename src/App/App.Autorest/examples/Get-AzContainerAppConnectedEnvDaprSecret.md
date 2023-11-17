### Example 1: List secrets for a dapr component.
```powershell
Get-AzContainerAppConnectedEnvDaprSecret -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -DaprName azps-connectedenvdapr
```

```output
Name      Value
----      -----
masterkey keyvalue
```

List secrets for a dapr component.