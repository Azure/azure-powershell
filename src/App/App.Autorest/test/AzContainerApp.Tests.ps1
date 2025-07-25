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
            $EnvId = (Get-AzContainerAppConnectedEnv -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnv1).Id

            $trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
            $configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80
            $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
            $temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
            
            $config = New-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp3 -Location $env.location -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -EnvironmentId $EnvId -ExtendedLocationName "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupConnected)/providers/Microsoft.ExtendedLocation/customLocations/$($env.customLocation)" -ExtendedLocationType CustomLocation
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
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp3
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
            $configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -Secret $secretObject

            $config = Update-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp3 -Configuration $configuration -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
            $configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -Secret $secretObject

            $config = Get-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp3
            $config = Update-AzContainerApp -InputObject $config -Configuration $configuration -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.containerApp3
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp3
        } | Should -Not -Throw
    }
}
