if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticVersion' {
    It 'List' {
        # Test with a valid region
        $region = 'westus2'
        $elasticVersions = Get-AzElasticVersion -Region $region
        $elasticVersions | Should -Not -BeNullOrEmpty
        $elasticVersions | Should -BeOfType 'Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticVersionListFormat'
        
        # Ensure output contains version data
        $elasticVersions.version | Should -Contain '8.19.5'
        $elasticVersions.version | Should -Contain '9.1.5'
    }
}
