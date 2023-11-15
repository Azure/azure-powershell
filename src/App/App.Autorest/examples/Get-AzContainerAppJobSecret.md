### Example 1: List secrets for a container apps job.
```powershell
Get-AzContainerAppJobSecret -JobName azps-app-job -ResourceGroupName azps_test_group_app
```

```output
Identity KeyVaultUrl Name   Value
-------- ----------- ----   -----
                     jobkey
```

List secrets for a container apps job.