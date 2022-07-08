if(($null -eq $TestName) -or ($TestName -contains 'Merge-AzReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Merge-AzReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$reservationId1 = "/providers/Microsoft.Capacity/reservationOrders/30000000-aaaa-bbbb-cccc-200000000013/reservations/10000000-aaaa-bbbb-cccc-200000000007"
$reservationId2 = "/providers/Microsoft.Capacity/reservationOrders/30000000-aaaa-bbbb-cccc-200000000013/reservations/50000000-aaaa-bbbb-cccc-200000000007"

function ExecuteTestCases([object]$response) {

}

Describe 'Merge-AzReservation' {
    It 'Merge' {
        $reservationIds = @($reservationId1, $reservationId2)
        $response = Merge-AzReservation -ReservationOrderId "30000000-aaaa-bbbb-cccc-200000000013" -ReservationId $reservationIds
        $response | Should -Not -Be $null
        $response.Count | Should -Be 3
        $childQuantityTotal = $response[0].Quantity + $response[1].Quantity
        $childQuantityTotal | Should -Be $response[2].Quantity
        $response[0].ProvisioningState | Should -Be "Cancelled"
        $response[1].ProvisioningState | Should -Be "Cancelled"
        $response[2].ProvisioningState | Should -Be "Succeeded"
        $response[0].ExtendedStatusInfo | Should -Not -Be $null
        $response[0].ExtendedStatusInfo.StatusCode | Should -Be "Merged"  
        $response[1].ExtendedStatusInfo | Should -Not -Be $null
        $response[1].ExtendedStatusInfo.StatusCode | Should -Be "Merged"
        $response[0].SplitProperties | Should -Not -Be $null
        $response[0].SplitProperties.SplitSource | Should -Not -Be $null
        $response[0].MergeProperties | Should -Not -Be $null
        $response[0].MergeProperties.MergeDestination | Should -Not -Be $null
        $response[1].SplitProperties | Should -Not -Be $null
        $response[1].SplitProperties.SplitSource | Should -Not -Be $null
        $response[1].MergeProperties | Should -Not -Be $null
        $response[1].MergeProperties.MergeDestination | Should -Not -Be $null
        $response[2].MergeProperties | Should -Not -Be $null
        $response[2].MergeProperties.MergeSources | Should -Not -Be $null
        $response[2].MergeProperties.MergeSources.Count | Should -BeGreaterThan 0
        $response[2].MergeProperties.MergeSources | Should -Contain $reservationId1
        $response[2].MergeProperties.MergeSources | Should -Contain $reservationId2
    }
}
