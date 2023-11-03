if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationExchange'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationExchange.Recording.json'
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
    ReservationId = "/providers/microsoft.capacity/reservationOrders/068506a3-a704-4c3e-8d3a-6c566d4af58b/reservations/936a414b-5999-4eb9-9fe7-883c5fc19d34"
}
$reservationsToReturn = @($reservationToReturn1)
$reservationToPurchase1Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/10000000-aaaa-bbbb-cccc-100000000000"
    DisplayName = "PSExchange1"
    Quantity = 2
    ReservedResourceType = "VirtualMachines"
    Term = "P3Y"
}
$reservationToPurchase1 = @{
    Location = "westeurope"
    Properties = $reservationToPurchase1Properties
    Sku = "Standard_B16ms"
}
$reservationsToPurchase = @($reservationToPurchase1)

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.Status | Should -Be 'Succeeded'
    $response.Name | Should -Not -Be $null
    $response.Id | Should -Not -Be $null
    $response.SessionId | Should -Not -Be $null
    $response.RefundsTotal | Should -Not -Be $null
    $response.PurchasesTotal | Should -Not -Be $null
    $response.NetPayable | Should -Not -Be $null
    $response.RefundsTotal.CurrencyCode | Should -Be 'GBP'
    $response.RefundsTotal.Amount | Should -Be 42.84
    $response.PurchasesTotal.CurrencyCode | Should -Be 'GBP'
    $response.PurchasesTotal.Amount | Should -Be 11328
    $response.NetPayable.CurrencyCode | Should -Be 'GBP'
    $response.NetPayable.Amount | Should -Be 11285.16

    $response.ReservationsToPurchase | Should -Not -Be $null
    $response.ReservationsToPurchase.Count | Should -Be 1
    $response.ReservationsToPurchase[0].Properties | Should -Not -Be $null
    $response.ReservationsToPurchase[0].Properties.Location | Should -Be "westeurope"
    $response.ReservationsToPurchase[0].Properties.Sku | Should -Be "Standard_B16ms"
    $response.ReservationsToPurchase[0].Properties.BillingScopeId | Should -Be "/subscriptions/10000000-aaaa-bbbb-cccc-100000000000"
    $response.ReservationsToPurchase[0].Properties.Term | Should -Be "P3Y"
    $response.ReservationsToPurchase[0].Properties.BillingPlan | Should -Be "Upfront"
    $response.ReservationsToPurchase[0].Properties.Quantity | Should -Be 2
    $response.ReservationsToPurchase[0].Properties.ReservedResourceType | Should -Be "VirtualMachines"
    $response.ReservationsToPurchase[0].Properties.AppliedScopeType | Should -Be "Shared"
    $response.ReservationsToPurchase[0].Properties.DisplayName | Should -Be "PSExchange1"
    $response.ReservationsToPurchase[0].ReservationOrderId | Should -Not -Be $null
    $response.ReservationsToPurchase[0].ReservationId | Should -Not -Be $null
    $response.ReservationsToPurchase[0].BillingCurrencyTotal | Should -Not -Be $null
    $response.ReservationsToPurchase[0].BillingCurrencyTotal.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToPurchase[0].BillingCurrencyTotal.Amount | Should -Be 11328
    $response.ReservationsToPurchase[0].Status | Should -Be "Succeeded"

    $response.ReservationsToExchange | Should -Not -Be $null
    $response.ReservationsToExchange.Count | Should -Be 1
    $response.ReservationsToExchange[0].ReservationId | Should -Not -Be $null
    $response.ReservationsToExchange[0].Quantity | Should -Be 1
    $response.ReservationsToExchange[0].BillingRefundAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingRefundAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingRefundAmount.Amount | Should -Be 1.19
    $response.ReservationsToExchange[0].BillingInformation | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount.Amount | Should -Be 1.19
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyProratedAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyProratedAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyProratedAmount.Amount | Should -Be 0
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyRemainingCommitmentAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyRemainingCommitmentAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyRemainingCommitmentAmount.Amount | Should -Be 41.65
    $response.ReservationsToExchange[0].Status | Should -Be "Succeeded"
}

Describe 'Invoke-AzReservationExchange' {
    It 'PostExpanded' {
        $calculateExchangeRes = Invoke-AzReservationCalculateExchange -ReservationsToExchange $reservationsToReturn -ReservationsToPurchase $reservationsToPurchase
        $calculateExchangeRes.SessionId | Should -Not -Be $null

        $response = Invoke-AzReservationExchange -SessionId $calculateExchangeRes.SessionId
        ExecuteTestCases($response)
    }

    It 'Post' {
        $calculateExchangeRequest = @{
            ReservationsToExchange = $reservationsToReturn
            ReservationsToPurchase = $reservationsToPurchase
        }
        $calculateExchangeRes = Invoke-AzReservationCalculateExchange -Body $calculateExchangeRequest
        $calculateExchangeRes.SessionId | Should -Not -Be $null

        $request = @{
            SessionId = $calculateExchangeRes.SessionId
        }
        $response = Invoke-AzReservationExchange -Body $request
        ExecuteTestCases($response)
    }
}
