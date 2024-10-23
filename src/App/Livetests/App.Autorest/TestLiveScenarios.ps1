Invoke-LiveTestScenario -Name "List ContainerApp" -Description "Test listing ContainerApp" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $workspaceName = New-LiveTestResourceName
    $envName = New-LiveTestResourceName
    $appLocation = "northcentralusstage"
    $location = "eastus"

    $null = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $workspaceName -Sku PerGB2018 -Location $location -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $workspaceName).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name $workspaceName).PrimarySharedKey
    $workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"
    $null = New-AzContainerAppManagedEnv -EnvName $envName -ResourceGroupName $rgName -Location $appLocation -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -EnvName $envName).Id
    $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
    $probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $probeHttpGetHttpHeader
    $temp = New-AzContainerAppTemplateObject -Name $appName -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
    $configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject

    # Test creating AzContainerApp
    $actual = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -Configuration $configuration -TemplateContainer $temp -EnvironmentId $EnvId
    Assert-AreEqual $appName $actual.Name
    Assert-AreEqual $actual.ProvisioningState "Succeeded"
    # Test listing ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -Configuration $configuration -TemplateContainer $temp -EnvironmentId $EnvId
    $actual = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-True { $actual.Count -ge 1 }
    # Test getting one ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -Configuration $configuration -TemplateContainer $temp -EnvironmentId $EnvId
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $appName $actual.Name
    # Test Updating one specific ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -Configuration $configuration -TemplateContainer $temp -EnvironmentId $EnvId
    $null = Update-AzContainerApp -Name $appName -ResourceGroupName $rgName -Configuration $configuration -Tag @{"123"="abc"}
    $actual = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $actual.Tag.Count 1
    Assert-AreEqual $actual.Tag["123"] "abc"
    # Test Removing ContainerApp
    $null = New-AzContainerApp -Name $appName -ResourceGroupName $rgName -Location $appLocation -Configuration $configuration -TemplateContainer $temp -EnvironmentId $EnvId
    $null = Remove-AzContainerApp -ResourceGroupName $rgName -Name $appName
    $GetServiceList = Get-AzContainerApp -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $appName}

}
