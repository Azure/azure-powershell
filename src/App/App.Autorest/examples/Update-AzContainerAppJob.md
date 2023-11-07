### Example 1: Update container app job.
```powershell
$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env).Id
$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"

Update-AzContainerAppJob -Name azps-app-job -ResourceGroupName azps_test_group_app -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp
```

```output
Location Name         ProvisioningState ResourceGroupName
-------- ----         ----------------- -----------------
East US  azps-app-job Succeeded         azps_test_group_app
```

Update container app job.