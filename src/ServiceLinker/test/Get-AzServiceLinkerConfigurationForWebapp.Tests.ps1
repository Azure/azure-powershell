if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceLinkerConfigurationForWebapp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerConfigurationForWebapp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceLinkerConfigurationForWebapp' {
    It 'Get' {
        $configs = Get-AzServiceLinkerConfigurationForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp -LinkerName $env.preparedLinker
        $configs.Count | Should -BeGreaterOrEqual 1
    }

}
