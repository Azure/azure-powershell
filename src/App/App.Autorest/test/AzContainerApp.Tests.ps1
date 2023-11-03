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
            $certificateId = (Get-AzContainerAppManagedEnvCert -EnvName $env.EnvName -ResourceGroupName $env.resourceGroup -Name $env.envCertName).Id
            $customDomain2 = New-AzContainerAppCustomDomainObject -CertificateId $certificateId -Name "www.fabrikam2.com" -BindingType SniEnabled
            $customDomain3 = New-AzContainerAppCustomDomainObject -CertificateId $certificateId -Name "www.fabrikam3.com" -BindingType SniEnabled

            $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision:$True -Weight 100
            $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"

            $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
            $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
            $image = New-AzContainerAppTemplateObject -Name $env.containerAppName2 -Image "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest" -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi

            $envId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup -EnvName $env.envName).Id

            $config = New-AzContainerApp -Name $env.containerAppName2 -ResourceGroupName $env.resourceGroup -Location $env.location -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $envId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-2" -DaprAppPort 8080 -IngressCustomDomain $customDomain2
            $config.Name | Should -Be $env.containerAppName2

            $config = New-AzContainerApp -Name $env.containerAppName3 -ResourceGroupName $env.resourceGroup -Location $env.location -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $envId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-3" -DaprAppPort 8080 -IngressCustomDomain $customDomain3
            $config.Name | Should -Be $env.containerAppName3
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
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroup -Name $env.containerAppName2
            $config.Name | Should -Be $env.containerAppName2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzContainerApp -ResourceGroupName $env.resourceGroup -Name $env.containerAppName2 -Location $env.location -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-2" -DaprAppPort 8080
            $config.Name | Should -Be $env.containerAppName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroup -Name $env.containerAppName3
            $config = Update-AzContainerApp -InputObject $config -Location $env.location -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-3" -DaprAppPort 8080
            $config.Name | Should -Be $env.containerAppName3
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerApp -ResourceGroupName $env.resourceGroup -Name $env.containerAppName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroup -Name $env.containerAppName3
            Remove-AzContainerApp -InputObject $config
        } | Should -Not -Throw
    }
}
