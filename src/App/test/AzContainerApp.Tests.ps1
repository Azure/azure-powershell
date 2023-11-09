if(($null -eq $TestName) -or ($TestName -contains 'AzContainerApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerApp' {
    It 'CreateExpanded' {
        {
            $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv1).Id

            $trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
            $iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
            $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
            $configuration = New-AzContainerAppConfigurationObject -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject
            $serviceBind = New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupManaged)/providers/Microsoft.App/containerApps/$($env.containerApp1)"
            
            $probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
            $probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
            $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
            $temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
            
            $config = New-AzContainerApp -ResourceGroupName $env.resourceGroupManaged -Name $env.containerApp3 -Location $env.location -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerApp
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupManaged -Name $env.containerApp3
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $newSecretObject = New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"
            $configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $newSecretObject

            $config = Update-AzContainerApp -ResourceGroupName $env.resourceGroupManaged -Name $env.containerApp3 -Configuration $configuration -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
            $configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -Secret $secretObject

            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp2
            $config = Update-AzContainerApp -InputObject $config -Configuration $configuration -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.containerApp2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerApp -ResourceGroupName $env.resourceGroupManaged -Name $env.containerApp3
        } | Should -Not -Throw
    }
}
