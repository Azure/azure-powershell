### Example 1: Start a Container Apps Job.
```powershell
$initContainer = New-AzContainerAppJobExecutionContainerObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:lates" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
Start-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -InitContainer $initContainer
```

```output
Name                 ResourceGroupName
----                 -----------------
azps-app-job-vvhlnul azps_test_group_app
```

Start a Container Apps Job.