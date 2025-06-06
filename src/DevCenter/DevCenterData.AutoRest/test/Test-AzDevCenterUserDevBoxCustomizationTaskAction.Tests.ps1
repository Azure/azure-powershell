if(($null -eq $TestName) -or ($TestName -contains 'Test-AzDevCenterUserDevBoxCustomizationTaskAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzDevCenterUserDevBoxCustomizationTaskAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzDevCenterUserDevBoxCustomizationTaskAction' {
    It 'ValidateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpandedByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateExpandedByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
