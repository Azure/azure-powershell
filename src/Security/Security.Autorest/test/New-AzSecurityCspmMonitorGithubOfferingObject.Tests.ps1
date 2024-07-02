if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityCspmMonitorGithubOfferingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityCspmMonitorGithubOfferingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityCspmMonitorGithubOfferingObject' {
    It '__AllParameterSets' {
        $offering = New-AzSecurityCspmMonitorGithubOfferingObject
        $offering.OfferingType | Should -Be "CspmMonitorGitHub"
    }
}
