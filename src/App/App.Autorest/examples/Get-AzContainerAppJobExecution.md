### Example 1: Get details of a single job execution.
```powershell
Get-AzContainerAppJobExecution -JobName azps-app-job -ResourceGroupName azps_test_group_app -Name "azps-app-job-vvhlnul"
```

```output
EndTime Name                 ResourceGroupName   StartTime Status
------- ----                 -----------------   --------- ------
        azps-app-job-vvhlnul azps_test_group_app
```

Get details of a single job execution.