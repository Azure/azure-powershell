if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit' {
    It 'ExtendExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Extend' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExtendViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExtendViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
