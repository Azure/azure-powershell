### Example 1: Terminates execution of a running container apps job.
```powershell
Stop-AzContainerAppJobExecution -JobName azps-app-job2 -ResourceGroupName azps_test_group_app -Name azps-app-job-vvhlnul -PassThru
```

```output
True
```

Terminates execution of a running container apps job.