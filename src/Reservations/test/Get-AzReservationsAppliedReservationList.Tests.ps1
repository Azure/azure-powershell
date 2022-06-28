if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationsAppliedReservationList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationsAppliedReservationList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationsAppliedReservationList' {
    It 'Get' {
        $response = Get-AzReservationsAppliedReservationList
        $response | Should -Not -Be $null
        $response.Count | Should -Be 1
        $response.Type | Should -Be "Microsoft.Capacity/AppliedReservations"
        $response.ReservationOrderIdValue | Should -Not -Be $null
        $response.ReservationOrderIdValue.Count | Should -BeGreaterThan 1
    }
}
