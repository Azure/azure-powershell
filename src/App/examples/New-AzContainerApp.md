### Example 1: Create or update a Container App.
```powershell
$trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision:$True -Weight 100
$secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"

$containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
$probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
$image = New-AzContainerAppTemplateObject -Name azps-containerapp -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi

$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azpstest_gp -EnvName azps-env).Id

New-AzContainerApp -Name azps-containerapp -ResourceGroupName azpstest_gp -Location canadacentral -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Create or update a Container App.