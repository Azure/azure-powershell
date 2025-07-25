if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPaloAltoNetworksLocalRulestackFirewall'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPaloAltoNetworksLocalRulestackFirewall.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPaloAltoNetworksLocalRulestackFirewall' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
