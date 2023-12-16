if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppConnectedEnvDapr'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppConnectedEnvDapr.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppConnectedEnvDapr' {
    It 'CreateExpanded' {
        {
            $scope = @("container-app-1","container-app-2")
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

            $config = New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvDapr -ComponentType "state.azure.cosmosdb" -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.connectedEnvDapr
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvDapr
            $config.Name | Should -Be $env.connectedEnvDapr
        } | Should -Not -Throw
    }

    It 'ConnectedEnvDaprSecretList' {
        {
            $config = Get-AzContainerAppConnectedEnvDaprSecret -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -DaprName $env.connectedEnvDapr
            $config.Name | Should -Be "masterkey"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

            $config = Update-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvDapr -ComponentType "state.azure.cosmosdb" -Version v2 -IgnoreError:$false -InitTimeout 60s -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.connectedEnvDapr
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
            $config = Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvDapr

            $config = Update-AzContainerAppConnectedEnvDapr -InputObject $config -ComponentType "state.azure.cosmosdb" -Version v2 -IgnoreError:$false -InitTimeout 60s -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.connectedEnvDapr
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvDapr
        } | Should -Not -Throw
    }
}
