if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedEnvDapr'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedEnvDapr.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedEnvDapr' {
    It 'CreateExpanded' {
        {
            $scope = @("container-app-1","container-app-2","container-app-3")
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

            $config = New-AzContainerAppManagedEnvDapr -DaprName $env.envDaprName -EnvName $env.envName -ResourceGroupName $env.resourceGroup -componentType state.azure.cosmosdb -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.envDaprName

            $config = New-AzContainerAppManagedEnvDapr -DaprName $env.envDaprName2 -EnvName $env.envName -ResourceGroupName $env.resourceGroup -componentType state.azure.cosmosdb -Version v1 -IgnoreError:$false -InitTimeout 50s
            $config.Name | Should -Be $env.envDaprName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.envName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.envName -ResourceGroupName $env.resourceGroup -DaprName $env.envDaprName
            $config.Name | Should -Be $env.envDaprName
        } | Should -Not -Throw
    }

    It 'DaprSecret-List' {
        {
            $config = Get-AzContainerAppManagedEnvDaprSecret -EnvName $env.envName -ResourceGroupName $env.resourceGroup -DaprName $env.envDaprName
            $config.Name | Should -Be "masterkey"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppManagedEnvDapr -EnvName $env.envName -ResourceGroupName $env.resourceGroup -DaprName $env.envDaprName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.envName -ResourceGroupName $env.resourceGroup -DaprName $env.envDaprName2
            Remove-AzContainerAppManagedEnvDapr -InputObject $config
        } | Should -Not -Throw
    }
}
