if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzCommvaultStorageComplianceLock'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzCommvaultStorageComplianceLock.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Skipped on purpose: enabling the compliance lock changes the protection of a storage and the service provisions every
# storage with a lock already, so a test could not check anything that a recording of the other storage tests does not.
Describe 'Enable-AzCommvaultStorageComplianceLock' {
    It 'Enable' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityCloudAccount' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
