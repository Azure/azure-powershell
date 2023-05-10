if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedEnv'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedEnv.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedEnv' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -skip {
        {
            $config = New-AzContainerAppManagedEnv -EnvName $env.envName2 -ResourceGroupName $env.resourceGroup -Location $env.location -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $env.customId -LogAnalyticConfigurationSharedKey $env.sharedKey -VnetConfigurationInternal:$false
            $config.Name | Should -Be $env.envName2
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $config = Get-AzContainerAppManagedEnv
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -skip {
        {
            $config = Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup -EnvName $env.envName2
            $config.Name | Should -Be $env.envName2
        } | Should -Not -Throw
    }

    It 'List1' -skip {
        {
            $config = Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            Update-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup -EnvName $env.envName2 -Tag @{"123"="abc"}
        } | Should -Not -Throw
    }

    It 'Delete' -skip {
        {
            Remove-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup -EnvName $env.envName2
        } | Should -Not -Throw
    }
}
