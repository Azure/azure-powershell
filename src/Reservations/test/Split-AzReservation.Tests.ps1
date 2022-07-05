if(($null -eq $TestName) -or ($TestName -contains 'Split-AzReservation'))
{
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
}

function ExecuteTestCases([object]$response) {
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

Describe 'Split-AzReservation' {
    It 'SplitExpanded' {
        $res = Split-AzReservation -ReservationOrderId "50000000-aaaa-bbbb-cccc-200000000002" -ReservationId "/providers/Microsoft.Capacity/reservationOrders/50000000-aaaa-bbbb-cccc-200000000002/reservations/10000000-aaaa-bbbb-cccc-200000000006" -Quantity @(7,3)
        ExecuteTestCases($res)
    }

    It 'Split' {
        $quantity = @(15,4)
        $request = @{
            Quantity = $quantity
            ReservationId = "/providers/Microsoft.Capacity/reservationOrders/40000000-aaaa-bbbb-cccc-200000000002/reservations/30000000-aaaa-bbbb-cccc-200000000009"
        }
        $res = Split-AzReservation -ReservationOrderId "40000000-aaaa-bbbb-cccc-200000000002" -Body $request
        ExecuteTestCases($res)
    }

    It 'SplitViaIdentityExpanded' {
        $param = @{
            ReservationOrderId = "30000000-aaaa-bbbb-cccc-200000000016"
        }
        $res = Split-AzReservation -InputObject $param -ReservationId "/providers/Microsoft.Capacity/reservationOrders/30000000-aaaa-bbbb-cccc-200000000016/reservations/40000000-aaaa-bbbb-cccc-200000000006" -Quantity @(7,3)
        ExecuteTestCases($res)
    }

    It 'SplitViaIdentity' {
        $quantity = @(2,8)
        $request = @{
            Quantity = $quantity
            ReservationId = "/providers/Microsoft.Capacity/reservationOrders/40000000-aaaa-bbbb-cccc-200000000012/reservations/30000000-aaaa-bbbb-cccc-200000000013"
        }
        $param = @{
            ReservationOrderId = "40000000-aaaa-bbbb-cccc-200000000012"
        }
        $res = Split-AzReservation -InputObject $param -Body $request
        ExecuteTestCases($res)
    }
}
