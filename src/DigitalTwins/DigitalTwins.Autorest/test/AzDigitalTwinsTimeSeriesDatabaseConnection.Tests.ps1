if(($null -eq $TestName) -or ($TestName -contains 'AzDigitalTwinsTimeSeriesDatabaseConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDigitalTwinsTimeSeriesDatabaseConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDigitalTwinsTimeSeriesDatabaseConnection' {
    It 'List' {
        {
            $config = Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName1 -Name azps-tsdc
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName1 -Name azps-tsdc
        } | Should -Not -Throw
    }
}
