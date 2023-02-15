### Example 1: Create an image object for Container.
```powershell
$containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
$probeArray = @()
$probeArray += New-AzContainerAppProbeObject -HttpGetPath "/health01" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
$probeArray += New-AzContainerAppProbeObject -HttpGetPath "/health02" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
New-AzContainerAppTemplateObject -Name azps-containerapp -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probeArray -ResourceCpu 2.0 -ResourceMemory 4.0Gi
```

```output
Arg Command Image                                                       Name
--- ------- -----                                                       ----
            mcr.microsoft.com/azuredocs/containerapps-helloworld:latest azps-containerapp
```

Create an image object for Container.