### Example 1: Create an in-memory object for Container.
```powershell
$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader

New-AzContainerAppTemplateObject -Image "repo/testcontainerApp0:v1" -Name "testcontainerApp0" -Probe $probe
```

```output
Image                     Name              ResourceCpu ResourceEphemeralStorage ResourceMemory
-----                     ----              ----------- ------------------------ --------------
repo/testcontainerApp0:v1 testcontainerApp0
```

Create an in-memory object for Container.