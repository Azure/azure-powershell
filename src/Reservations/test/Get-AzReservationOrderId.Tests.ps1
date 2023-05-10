if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationOrderId'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationOrderId.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationOrderId' {
    It 'Get' {
        $response = Get-AzReservationOrderId -SubscriptionId '10000000-aaaa-bbbb-cccc-100000000005'
        $response | Should -Not -Be $null
        $response.Count | Should -Be 1
        $response.Type | Should -Be "Microsoft.Capacity/AppliedReservations"
        $response.ReservationOrderIdValue | Should -Not -Be $null
        $response.ReservationOrderIdValue.Count | Should -BeGreaterThan 1
    }
}
