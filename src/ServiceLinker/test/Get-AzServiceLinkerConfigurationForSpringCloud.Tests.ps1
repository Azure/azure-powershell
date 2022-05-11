if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerConfigurationForSpringCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerConfigurationForSpringCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerConfigurationForSpringCloud' {
    It 'Get' {
        $configs = Get-AzServiceLinkerConfigurationForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp -LinkerName $env.preparedLinker
        $configs.Count | Should -BeGreaterOrEqual 1
    }
}
