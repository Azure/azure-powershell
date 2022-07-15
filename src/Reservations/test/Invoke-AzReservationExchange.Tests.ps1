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
    ReservationId = "/providers/microsoft.capacity/reservationOrders/c3131617-d38c-4bbc-a33d-6094c5a88cbc/reservations/24fbc015-d032-4fc7-9dfe-7e46b655d8c1"
}
$reservationsToReturn = @($reservationToReturn1)
$reservationToPurchase1Properties = @{
    AppliedScopeType = "Shared"
    BillingPlan = "Upfront"
    BillingScopeId = "/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665"
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
    $response.RefundsTotal.Amount | Should -Be 6967.26
    $response.PurchasesTotal.CurrencyCode | Should -Be 'GBP'
    $response.PurchasesTotal.Amount | Should -Be 11328.0
    $response.NetPayable.CurrencyCode | Should -Be 'GBP'
    $response.NetPayable.Amount | Should -Be 4360.74

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
    $response.ReservationsToPurchase[0].Properties.DisplayName | Should -Be "PSExchange"
    $response.ReservationsToPurchase[0].ReservationOrderId | Should -Not -Be $null
    $response.ReservationsToPurchase[0].ReservationId | Should -Not -Be $null
    $response.ReservationsToPurchase[0].BillingCurrencyTotal | Should -Not -Be $null
    $response.ReservationsToPurchase[0].BillingCurrencyTotal.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToPurchase[0].BillingCurrencyTotal.Amount | Should -Be 11328.0
    $response.ReservationsToPurchase[0].Status | Should -Be "Succeeded"

    $response.ReservationsToExchange | Should -Not -Be $null
    $response.ReservationsToExchange.Count | Should -Be 1
    $response.ReservationsToExchange[0].ReservationId | Should -Not -Be $null
    $response.ReservationsToExchange[0].Quantity | Should -Be 1
    $response.ReservationsToExchange[0].BillingRefundAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingRefundAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingRefundAmount.Amount | Should -Be 85.21
    $response.ReservationsToExchange[0].BillingInformation | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyTotalPaidAmount.Amount | Should -Be 196.63
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyProratedAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyProratedAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyProratedAmount.Amount | Should -Be 111.42
    $response.ReservationsToExchange[0].BillingInformation.BillingCurrencyRemainingCommitmentAmount | Should -Not -Be $null
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyRemainingCommitmentAmount.CurrencyCode | Should -Be "GBP"
    $response.ReservationsToExchange[0].BillingInformation.billingCurrencyRemainingCommitmentAmount.Amount | Should -Be 6882.05
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
