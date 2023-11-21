if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationCalculateRefund'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationCalculateRefund.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.SessionId | Should -Not -Be $null
    $response.BillingInformationBillingCurrencyProratedAmount | Should -Not -Be $null
    $response.BillingInformationBillingCurrencyRemainingCommitmentAmount | Should -Not -Be $null
    $response.BillingInformationBillingCurrencyTotalPaidAmount | Should -Not -Be $null
    $response.BillingInformationBillingCurrencyProratedAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingInformationBillingCurrencyProratedAmount.Amount | Should -Be 6.18
    $response.BillingInformationBillingCurrencyRemainingCommitmentAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingInformationBillingCurrencyRemainingCommitmentAmount.Amount | Should -Be 23.94
    $response.BillingInformationBillingCurrencyTotalPaidAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingInformationBillingCurrencyTotalPaidAmount.Amount | Should -Be 7.98
    $response.BillingInformationBillingPlan | Should -Be 'Monthly'
    $response.BillingInformationCompletedTransaction | Should -Be 3
    $response.BillingInformationTotalTransaction | Should -Be 12
    $response.BillingRefundAmount | Should -Not -Be $null
    $response.ConsumedRefundsTotal | Should -Not -Be $null
    $response.BillingRefundAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingRefundAmount.Amount | Should -Be 1.8
    $response.ConsumedRefundsTotal.CurrencyCode | Should -Be 'USD'
    $response.ConsumedRefundsTotal.Amount | Should -Be 0
    $response.Id| Should -Be '/providers/Microsoft.Capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003'
    $response.MaxRefundLimit | Should -Not -Be $null
    $response.MaxRefundLimit.CurrencyCode | Should -Be 'USD'
    $response.MaxRefundLimit.Amount | Should -Be 50000
    $response.PricingRefundAmount | Should -Not -Be $null
    $response.PricingRefundAmount.CurrencyCode | Should -Be 'USD'
    $response.PricingRefundAmount.Amount | Should -Be 1.8
}

Describe 'Invoke-AzReservationCalculateRefund' {
    It 'PostExpanded' {
        $orderId = "50000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
        $response = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'Post'  {
        $orderId = "50000000-aaaa-bbbb-cccc-100000000003"
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
            Scope = "Reservation"
        }
        $response = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -Body $body
        ExecuteTestCases($response)
    }

    It 'PostViaIdentityExpanded' {
        $param = @{
                    ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000003" 
        }
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
        $response = Invoke-AzReservationCalculateRefund -InputObject $param -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'PostViaIdentity' {
        $param = @{
                    ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000003" 
        }
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
            Scope = "Reservation"
        }
        $response = Invoke-AzReservationCalculateRefund -InputObject $param -Body $body
        ExecuteTestCases($response)
    }
}
