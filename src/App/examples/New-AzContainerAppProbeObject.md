### Example 1: Create a ContainerAppProb object for ContainerApp.
```powershell
New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness
```

```output
FailureThreshold InitialDelaySecond PeriodSecond SuccessThreshold TerminationGracePeriodSecond TimeoutSecond
---------------- ------------------ ------------ ---------------- ---------------------------- -------------
                 3                  3
```

Create a ContainerAppProb object for ContainerApp.