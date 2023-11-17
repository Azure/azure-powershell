if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzCostManagementReservationDetailReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCostManagementReservationDetailReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzCostManagementReservationDetailReport' {
    # No authorization to execute
    It 'By' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'By1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
