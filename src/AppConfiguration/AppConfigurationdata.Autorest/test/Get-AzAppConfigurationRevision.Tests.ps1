if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppConfigurationRevision'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationRevision.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppConfigurationRevision' {
    It 'Get' {
        $results = Get-AzAppConfigurationRevision -Endpoint $env.endpoint
        $results | Should -Not -BeNullOrEmpty
        $results[0].PSObject.Properties.Name | Should -Contain 'Description'
    }
}
