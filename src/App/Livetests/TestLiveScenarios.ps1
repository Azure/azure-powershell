Invoke-LiveTestScenario -Name "Create ContainerApp" -Description "Test New-AzContainerApp" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name workspace-azpstestgp).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName azps-env).Id
    $scaleRule = @()
    New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    Assert-AreEqual $appName $actual.Name
    Assert-AreEqual $appLocation $actual.Location
}

Invoke-LiveTestScenario -Name "List ContainerApp" -Description "Test listing ContainerApp" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name workspace-azpstestgp).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName azps-env).Id
    $scaleRule = @()
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $actual = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-AreEqual 1 $actual.Count
}

Invoke-LiveTestScenario -Name "Get ContainerApp" -Description "Test getting one ContainerApp" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name workspace-azpstestgp).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName azps-env).Id
    $scaleRule = @()
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $appName $actual.Name
}

Invoke-LiveTestScenario -Name "Update ContainerApp" -Description "Test Updating one specific ContainerApp" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name workspace-azpstestgp).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName azps-env).Id
    $scaleRule = @()
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $null = Update-AzContainerApp -Name $appName -ResourceGroupName $rgName -DaprAppPort 8888 -Location $appLocation
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName 
    Assert-AreEqual $actual.$DaprAppPort 8888
}

Invoke-LiveTestScenario -Name "Remove ContainerApp" -Description "Test Removing ContainerApp" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name workspace-azpstestgp).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name workspace-azpstestgp).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName azps-env).Id
    $scaleRule = @()
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    $GetServiceList = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $appName}
}