if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerConfigurationForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerConfigurationForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerConfigurationForSpringcloud' {
    It 'Get' {
        $configs = Get-AzServiceLinkerConfigurationForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.preparedLinker
        $configs.Count | Should -BeGreaterOrEqual 1
    }
}
