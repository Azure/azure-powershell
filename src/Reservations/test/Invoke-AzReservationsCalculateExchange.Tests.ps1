if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationsCalculateExchange'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationsCalculateExchange.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$reservationToReturn1 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
}
$reservationToReturn2 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000003/reservations/40000000-aaaa-bbbb-cccc-100000000002"
}
$reservationsToReturn = @($reservationToReturn1, $reservationToReturn2)
$reservationToPurchase1 = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/10000000-aaaa-bbbb-cccc-100000000001"
    DisplayName = "PSExchange"
    Location = "westeurope"
    Quantity = 1
    ReservedResourceType = "VirtualMachines"
    SkuName = "Standard_B12ms"
    Term = "P3Y"
}
$reservationToPurchase2 = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/10000000-aaaa-bbbb-cccc-100000000001"
    DisplayName = "PSExchange2"
    Location = "westeurope"
    Quantity = 2
    ReservedResourceType = "VirtualMachines"
    SkuName = "Standard_B8ms"
    Term = "P3Y"
}
$reservationsToPurchase = @($reservationToPurchase1, $reservationToPurchase2)

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.SessionId | Should -Not -Be $null
    $response.Status | Should -Be 'Succeeded'
    $response.RefundTotalCurrencyCode | Should -Be 'GBP'
    $response.RefundTotalAmount | Should -Be 5598.46
    $response.PurchaseTotalCurrencyCode | Should -Be 'GBP'
    $response.PurchaseTotalAmount | Should -Be 9910.0
    $response.NetPayableCurrencyCode | Should -Be 'GBP'
    $response.NetPayableAmount | Should -Be 4311.54
}

Describe 'Invoke-AzReservationsCalculateExchange' {
    It 'PostExpanded' {
        $response = Invoke-AzReservationsCalculateExchange -ReservationsToExchange $reservationsToReturn -ReservationsToPurchase $reservationsToPurchase
        ExecuteTestCases($response)
    }

    It 'Post' {
        $request = @{
            ReservationsToExchange = $reservationsToReturn
            ReservationsToPurchase = $reservationsToPurchase
        }
        $response = Invoke-AzReservationsCalculateExchange -Body $request
        ExecuteTestCases($response)
    }
}
