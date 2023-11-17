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
            $scope = @("container-app-1","container-app-2")
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
            
            $config = New-AzContainerAppManagedEnvDapr -Name $env.managedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -componentType state.azure.cosmosdb -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.managedEnvDapr
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvDapr
            $config.Name | Should -Be $env.managedEnvDapr
        } | Should -Not -Throw
    }

    It 'DaprSecret-List' {
        {
            $config = Get-AzContainerAppManagedEnvDaprSecret -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -DaprName $env.managedEnvDapr
            $config.Name | Should -Be "masterkey"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $scope = @("container-app-1","container-app-2")
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

            $config = Update-AzContainerAppManagedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvDapr -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.managedEnvDapr
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $scope = @("container-app-1","container-app-2")
            $secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
            $daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
            $config = Get-AzContainerAppManagedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvDapr

            $config = Update-AzContainerAppManagedEnvDapr -InputObject $config -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
            $config.Name | Should -Be $env.managedEnvDapr
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppManagedEnvDapr -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvDapr
        } | Should -Not -Throw
    }
}
