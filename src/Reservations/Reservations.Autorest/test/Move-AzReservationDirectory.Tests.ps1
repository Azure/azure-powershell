if(($null -eq $TestName) -or ($TestName -contains 'Move-AzReservationDirectory'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzReservationDirectory.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.Reservation | Should -Not -Be $null
    $response.Reservation.Count | Should -BeGreaterThan 0
    $response.ReservationOrderId | Should -Not -Be $null
    $response.ReservationOrderError | Should -Be $null
    $response.ReservationOrderIsSucceeded | Should -Be "True"
    $response.ReservationOrderName | Should -Not -Be $null
}

Describe 'Move-AzReservationDirectory' {
    It 'ChangeExpanded' {
        $response = Move-AzReservationDirectory -ReservationOrderId "40000000-aaaa-bbbb-cccc-100000000001" -DestinationTenantId "30000000-aaaa-bbbb-cccc-100000000004"
        ExecuteTestCases($response)
    }

    It 'Change' {
        $request = @{ DestinationTenantId = "30000000-aaaa-bbbb-cccc-100000000004" }
        $response = Move-AzReservationDirectory -ReservationOrderId "50000000-aaaa-bbbb-cccc-200000000005" -Body $request
        ExecuteTestCases($response)
    }

    It 'ChangeViaIdentityExpanded' {
        $identity = @{ ReservationOrderId = "30000000-aaaa-bbbb-cccc-200000000018" }
        $response = Move-AzReservationDirectory -InputObject $identity -DestinationTenantId "30000000-aaaa-bbbb-cccc-100000000004"
        ExecuteTestCases($response)
    }

    It 'ChangeViaIdentity' {
        $identity = @{ ReservationOrderId = "40000000-aaaa-bbbb-cccc-200000000007" }
        $request = @{ DestinationTenantId = "30000000-aaaa-bbbb-cccc-100000000004" }
        $response = Move-AzReservationDirectory -InputObject $identity -Body $request
        ExecuteTestCases($response)
    }
}
