### Example 1: List secrets for a container app.
```powershell
Get-AzContainerAppSecret -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Identity KeyVaultUrl Name         Value
-------- ----------- ----         -----
                     redis-config redis-password
```

List secrets for a container app.