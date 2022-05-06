if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerConfigurationForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerConfigurationForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerConfigurationForWebApp' {
    It 'Get' {
        $configs = Get-AzServiceLinkerConfigurationForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp -LinkerName $env.preparedLinker
        $configs.Count | Should -BeGreaterOrEqual 1
    }

}
