  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Split-AzReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

Describe 'Split-AzReservation' {
    It 'Split' {
        $response = Split-AzReservation -ReservationOrderId "50000000-aaaa-bbbb-cccc-200000000002" -ReservationId "10000000-aaaa-bbbb-cccc-200000000006" -Quantity @(1,4)
        
        $response | Should -Not -Be $null
        $response.Count | Should -Be 3
        $childQuantityTotal = $response[0].Quantity + $response[1].Quantity
        $childQuantityTotal | Should -Be $response[2].Quantity
        $response[0].ProvisioningState | Should -Be "Succeeded"
        $response[1].ProvisioningState | Should -Be "Succeeded"
        $response[2].ProvisioningState | Should -Be "Cancelled"
        $response[2].ExtendedStatusInfo | Should -Not -Be $null
        $response[2].ExtendedStatusInfo.StatusCode | Should -Be "Split"
        $response[2].SplitProperties | Should -Not -Be $null
        $response[2].SplitProperties.SplitDestinations | Should -Not -Be $null
        $response[2].SplitProperties.SplitDestinations.Count | Should -Be 2
    }
}
