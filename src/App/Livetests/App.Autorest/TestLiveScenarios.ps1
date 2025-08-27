Invoke-LiveTestScenario -Name "Operate ContainerApp" -Description "Test operating Container App" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"

    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $nsgName = New-LiveTestResourceName
    $natName = New-LiveTestResourceName
    $pipName = New-LiveTestResourceName
    $delName = New-LiveTestResourceName
    $wsName = New-LiveTestResourceName

    $pflName = New-LiveTestResourceName
    $envName = New-LiveTestResourceName
    $tplName = New-LiveTestResourceName
    $daprName = New-LiveTestResourceName
    $appName = New-LiveTestResourceName
    $appSecretName = New-LiveTestRandomName -Option StartWithLetter
    $appSecretValue = New-LiveTestRandomName -Option StartWithLetter

    $nsgRuleHighRiskPorts = New-AzNetworkSecurityRuleConfig -Name "DenyHighRiskPorts" -Direction Inbound -Priority 101 -Protocol Tcp -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 22, 3389 -Access Deny
    $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgName -Name $nsgName -Location $location -SecurityRules $nsgRuleHighRiskPorts
    $del = New-AzDelegation -Name $delName -ServiceName "Microsoft.App/environments"
    $ipTag = New-AzPublicIpTag -IpTagType FirstPartyUsage -Tag "/NonProd"
    $pip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Static -Sku Standard -IpTag $ipTag
    $nat = New-AzNatGateway -ResourceGroupName $rgName -Name $natName -Location $location -IdleTimeoutInMinutes 5 -Sku Standard -PublicIpAddress $pip
    $snetCfg = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.10.1.0/24 -DefaultOutboundAccess $false -NetworkSecurityGroup $nsg -InputObject $nat -Delegation $del
    New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.10.0.0/16 -Subnet $snetCfg

    $snet = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName | Get-AzVirtualNetworkSubnetConfig -Name $snetName

    New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName -Sku standalone -Location $location -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $custId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName).CustomerId
    $sharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $rgName -Name $wsName).PrimarySharedKey

    $wlProfile = New-AzContainerAppWorkloadProfileObject -Name $pflName -Type D4 -MinimumCount 1 -MaximumCount 3
    New-AzContainerAppManagedEnv -ResourceGroupName $rgName -Name $envName -Location $location -WorkloadProfile $wlProfile -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $custId -LogAnalyticConfigurationSharedKey $sharedKey -VnetConfigurationInternal -VnetConfigurationInfrastructureSubnetId $snet.Id
    $envId = (Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -Name $envName).Id

    $probeHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
    $probe = New-AzContainerAppProbeObject -Type Liveness -HttpGetPath "/health" -HttpGetPort 8080 -HttpGetHttpHeader $probeHeader -InitialDelaySecond 3 -PeriodSecond 3
    $appTemplate = New-AzContainerAppTemplateObject -Name $tplName -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Probe $probe -ResourceCpu 2 -ResourceMemory "4Gi"

    $appSecret = New-AzContainerAppSecretObject -Name $appSecretName -Value $appSecretValue
    $appConfig = New-AzContainerAppConfigurationObject -DaprAppId $daprName -DaprAppProtocol "http" -DaprAppPort 3000 -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 100 -DaprLogLevel "debug" -DaprEnableApiLogging $true -DaprEnabled $true -MaxInactiveRevision 50 -Secret $appSecret

    $actual = New-AzContainerApp -ResourceGroupName $rgName -Name $appName -Location $location -EnvironmentId $envId -TemplateContainer $appTemplate -Configuration $appConfig

    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $appName $actual.Name
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual $envId $actual.EnvironmentId
    Assert-AreEqual $appTemplate.Image $actual.TemplateContainer[0].Image
    Assert-AreEqual $appTemplate.ResourceCpu $actual.TemplateContainer[0].ResourceCpu
    Assert-AreEqual $appTemplate.ResourceMemory $actual.TemplateContainer[0].ResourceMemory
    Assert-NotNull $actual.TemplateContainer[0].Probe
    Assert-AreEqual $daprName $actual.Configuration.DaprAppId
    Assert-AreEqual $appConfig.DaprAppProtocol $actual.Configuration.DaprAppProtocol
    Assert-AreEqual 3000 $actual.Configuration.DaprAppPort
    Assert-AreEqual 30 $actual.Configuration.DaprHttpReadBufferSize
    Assert-AreEqual 100 $actual.Configuration.DaprHttpMaxRequestSize
    Assert-AreEqual 50 $actual.Configuration.MaxInactiveRevision
    Assert-AreEqual $appConfig.DaprLogLevel $actual.Configuration.DaprLogLevel
    Assert-AreEqual $true $actual.Configuration.DaprEnabled
    Assert-AreEqual $true $actual.Configuration.DaprEnableApiLogging
    Assert-AreEqual $appSecretName $actual.Configuration.Secret[0].Name
    Assert-Null $actual.Configuration.Secret[0].Value

    $env = Get-AzContainerAppManagedEnv -ResourceGroupName $rgName -Name $envName

    Assert-NotNull $env
    Assert-AreEqual $rgName $env.ResourceGroupName
    Assert-AreEqual $envName $env.Name
    Assert-AreEqual "Succeeded" $env.ProvisioningState
    Assert-AreEqual "log-analytics" $env.AppLogConfigurationDestination
    Assert-AreEqual $custId $env.LogAnalyticConfigurationCustomerId
    Assert-Null $env.LogAnalyticConfigurationSharedKey
    Assert-AreEqual $snet.Id $env.VnetConfigurationInfrastructureSubnetId

    $workloadProfile = $env.WorkloadProfile | Where-Object { $_.Name -eq $pflName }

    Assert-NotNull $workloadProfile
    Assert-AreEqual $pflName $workloadProfile.Name
    Assert-AreEqual $wlProfile.Type $workloadProfile.Type
    Assert-AreEqual $wlProfile.MinimumCount $workloadProfile.MinimumCount
    Assert-AreEqual $wlProfile.MaximumCount $workloadProfile.MaximumCount

    $app = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName

    Assert-NotNull $app
    Assert-AreEqual $rgName $app.ResourceGroupName
    Assert-AreEqual $appName $app.Name
    Assert-AreEqual "Succeeded" $app.ProvisioningState
    Assert-AreEqual $envId $app.EnvironmentId
    Assert-AreEqual $appTemplate.Image $app.TemplateContainer[0].Image
    Assert-AreEqual $appTemplate.ResourceCpu $app.TemplateContainer[0].ResourceCpu
    Assert-AreEqual $appTemplate.ResourceMemory $app.TemplateContainer[0].ResourceMemory
    Assert-NotNull $app.TemplateContainer[0].Probe
    Assert-AreEqual $daprName $app.Configuration.DaprAppId
    Assert-AreEqual $appConfig.DaprAppProtocol $app.Configuration.DaprAppProtocol
    Assert-AreEqual 3000 $app.Configuration.DaprAppPort
    Assert-AreEqual 30 $app.Configuration.DaprHttpReadBufferSize
    Assert-AreEqual 100 $app.Configuration.DaprHttpMaxRequestSize
    Assert-AreEqual 50 $app.Configuration.MaxInactiveRevision
    Assert-AreEqual $appConfig.DaprLogLevel $app.Configuration.DaprLogLevel
    Assert-AreEqual $true $app.Configuration.DaprEnabled
    Assert-AreEqual $true $app.Configuration.DaprEnableApiLogging
    Assert-AreEqual $appSecretName $app.Configuration.Secret[0].Name
    Assert-Null $app.Configuration.Secret[0].Value

    $appConfig.DaprHttpReadBufferSize = 50
    $appConfig.DaprHttpMaxRequestSize = 50
    $appConfig.DaprEnableApiLogging = $false

    Update-AzContainerApp -Name $appName -ResourceGroupName $rgName -Configuration $appConfig -Tag @{ "testtag" = "testval" }

    $app = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName

    Assert-NotNull $app
    Assert-AreEqual $rgName $app.ResourceGroupName
    Assert-AreEqual $appName $app.Name
    Assert-AreEqual "Succeeded" $app.ProvisioningState
    Assert-AreEqual $envId $app.EnvironmentId
    Assert-AreEqual $appTemplate.Image $app.TemplateContainer[0].Image
    Assert-AreEqual $appTemplate.ResourceCpu $app.TemplateContainer[0].ResourceCpu
    Assert-AreEqual $appTemplate.ResourceMemory $app.TemplateContainer[0].ResourceMemory
    Assert-NotNull $app.TemplateContainer[0].Probe
    Assert-AreEqual $daprName $app.Configuration.DaprAppId
    Assert-AreEqual $appConfig.DaprAppProtocol $app.Configuration.DaprAppProtocol
    Assert-AreEqual 3000 $app.Configuration.DaprAppPort
    Assert-AreEqual 50 $app.Configuration.DaprHttpReadBufferSize
    Assert-AreEqual 50 $app.Configuration.DaprHttpMaxRequestSize
    Assert-AreEqual 50 $app.Configuration.MaxInactiveRevision
    Assert-AreEqual $appConfig.DaprLogLevel $app.Configuration.DaprLogLevel
    Assert-AreEqual $true $app.Configuration.DaprEnabled
    Assert-AreEqual $false $app.Configuration.DaprEnableApiLogging
    Assert-AreEqual $appSecretName $app.Configuration.Secret[0].Name
    Assert-Null $app.Configuration.Secret[0].Value
    Assert-NotNull $app.Tag
    Assert-AreEqual 1 $app.Tag.Count
    Assert-AreEqual "testval" $app.Tag["testtag"]

    Remove-AzContainerApp -ResourceGroupName $rgName -Name $appName
    $app = Get-AzContainerApp -ResourceGroupName $rgName -Name $appName -ErrorAction SilentlyContinue
    Assert-Null $app
}
