Invoke-LiveTestScenario -Name "List ContainerApp" -Description "Test listing ContainerApp" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $workspaceName = New-LiveTestResourceName
    $envName = New-LiveTestResourceName
    $headerName = New-LiveTestResourceName
    $secretName = New-LiveTestResourceName
    $appLocation = "westus"
    $null = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $workspaceName -Sku PerGB2018 -Location $appLocation -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $workspaceName).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name $workspaceName).PrimarySharedKey
    $null = New-AzContainerAppManagedEnv -EnvName $envName -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name $secretName -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name $headerName -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $appName -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName $envName).Id
    $scaleRule = @()
    # Test creating AzContainerApp
    $actual = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    Assert-AreEqual $appName $actual.Name
    Assert-AreEqual 8080 $actual.DaprAppPort
    # Test listing ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $actual = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-True { $actual.Count -ge 1 }
    # Test getting one ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $appName $actual.Name
    # Test Updating one specific ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $null = Update-AzContainerApp -Name $appName -ResourceGroupName $rgName -DaprAppPort 8888 -Location $appLocation
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $actual.DaprAppPort 8888
    # Test Removing ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $EnvId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -ScaleRule $scaleRule
    $null = Remove-AzContainerApp -ResourceGroupName $rgName -Name $appName
    $GetServiceList = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $appName}

}
