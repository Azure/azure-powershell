if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace' {
    It 'DiagnoseExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Diagnose' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiagnoseViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiagnoseViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
