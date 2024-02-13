if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSecurityApiCollectionApimOffboard'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSecurityApiCollectionApimOffboard.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSecurityApiCollectionApimOffboard' {
    It 'Delete' {
        "Covered in Invoke-AzSecurityApiCollectionApimOnboard Tests" | Should -Not -BeNullOrEmpty
    }

    It 'DeleteViaIdentity' {
        "Covered in Invoke-AzSecurityApiCollectionApimOnboard Tests" | Should -Not -BeNullOrEmpty
    }
}
