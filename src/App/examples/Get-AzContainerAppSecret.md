### Example 1: List secrets for a container app
```powershell
Get-AzContainerAppSecret -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

```output
Name Value
---- -----
key1 value1
```

List secrets for a container app