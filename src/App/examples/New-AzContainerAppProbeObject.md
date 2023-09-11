### Example 1: Create an in-memory object for ContainerAppProbe.
```powershell
$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"

New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
```

```output
FailureThreshold InitialDelaySecond PeriodSecond SuccessThreshold TerminationGracePeriodSecond TimeoutSecond
---------------- ------------------ ------------ ---------------- ---------------------------- -------------
                 3                  3
```

Create an in-memory object for ContainerAppProbe.