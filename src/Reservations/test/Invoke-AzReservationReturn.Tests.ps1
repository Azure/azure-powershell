if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationReturn'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationReturn.Recording.json'
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
    $response.BillingInformationBillingCurrencyProratedAmount.Amount | Should -Be 15.06
    $response.BillingInformationBillingCurrencyRemainingCommitmentAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingInformationBillingCurrencyRemainingCommitmentAmount.Amount | Should -Be 18.06
    $response.BillingInformationBillingCurrencyTotalPaidAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingInformationBillingCurrencyTotalPaidAmount.Amount | Should -Be 15.48
    $response.BillingInformationBillingPlan | Should -Be 'Monthly'
    $response.BillingInformationCompletedTransaction | Should -Be 5
    $response.BillingInformationTotalTransaction | Should -Be 12
    $response.BillingRefundAmount | Should -Not -Be $null
    $response.ConsumedRefundsTotal | Should -Not -Be $null
    $response.BillingRefundAmount.CurrencyCode | Should -Be 'USD'
    $response.BillingRefundAmount.Amount | Should -Be 0.42
    $response.ConsumedRefundsTotal.CurrencyCode | Should -Be 'USD'
    $response.ConsumedRefundsTotal.Amount | Should -Be 367.81
    $response.Id| Should -Be '/providers/Microsoft.Capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003'
    $response.MaxRefundLimit | Should -Not -Be $null
    $response.MaxRefundLimit.CurrencyCode | Should -Be 'USD'
    $response.MaxRefundLimit.Amount | Should -Be 50000
    $response.PricingRefundAmount | Should -Not -Be $null
    $response.PricingRefundAmount.CurrencyCode | Should -Be 'USD'
    $response.PricingRefundAmount.Amount | Should -Be 0.42
    $response.Quantity | Should -Be 1
}

Describe 'Invoke-AzReservationReturn' {
    It 'PostExpanded' {
        $orderId = "50000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'Post' {
        $orderId = "50000000-aaaa-bbbb-cccc-100000000003"
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -Body $body
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }

        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -Body $body2
        ExecuteTestCases($response)
    }

    It 'PostViaIdentityExpanded' {
        $param = @{
                    ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000003" 
        }
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -InputObject $param -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
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
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -Body $body
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }
        $response = Invoke-AzReservationReturn -InputObject $param -Body $body2
        ExecuteTestCases($response)
    }
}
