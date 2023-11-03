if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationCalculateExchange'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationCalculateExchange.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Prepare request body
$reservationToReturn1 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
}
$reservationToReturn2 = @{
    Quantity = 1
    ReservationId = "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000003/reservations/40000000-aaaa-bbbb-cccc-100000000002"
}
$reservationsToReturn = @($reservationToReturn1, $reservationToReturn2)
$reservationToPurchase1Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/10000000-aaaa-bbbb-cccc-100000000001"
    DisplayName = "PSExchange"
    Term = "P3Y"
    Quantity = 1
    ReservedResourceType = "VirtualMachines"
}
$reservationToPurchase2Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/10000000-aaaa-bbbb-cccc-100000000001"
    DisplayName = "PSExchange2"
    Quantity = 2
    ReservedResourceType = "VirtualMachines"
    Term = "P3Y"
}
$reservationToPurchase1 = @{
    Location = "westeurope"
    Sku = "Standard_B12ms"
    Properties = $reservationToPurchase1Properties
}
$reservationToPurchase2 = @{
    Location = "westeurope"
    Sku = "Standard_B8ms"
    Properties = $reservationToPurchase2Properties
}
$reservationsToPurchase = @($reservationToPurchase1, $reservationToPurchase2)

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.SessionId | Should -Not -Be $null
    $response.Status | Should -Be 'Succeeded'
    $response.RefundsTotal | Should -Not -Be $null
    $response.PurchasesTotal | Should -Not -Be $null
    $response.NetPayable | Should -Not -Be $null
    $response.RefundsTotal.CurrencyCode | Should -Be 'USD'
    $response.RefundsTotal.Amount | Should -Be 55.86
    $response.PurchasesTotal.CurrencyCode | Should -Be 'USD'
    $response.PurchasesTotal.Amount | Should -Be 13297
    $response.NetPayable.CurrencyCode | Should -Be 'USD'
    $response.NetPayable.Amount | Should -Be 13241.14
}

Describe 'Invoke-AzReservationCalculateExchange' {
    It 'PostExpanded' {
        $response = Invoke-AzReservationCalculateExchange -ReservationsToExchange $reservationsToReturn -ReservationsToPurchase $reservationsToPurchase
        ExecuteTestCases($response)
    }

    It 'Post' {
        $request = @{
            ReservationsToExchange = $reservationsToReturn
            ReservationsToPurchase = $reservationsToPurchase
        }
        $response = Invoke-AzReservationCalculateExchange -Body $request
        ExecuteTestCases($response)
    }
}
