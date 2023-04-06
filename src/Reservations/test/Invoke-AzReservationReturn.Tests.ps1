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
    $response.Id | Should -Not -Be $null
    $response.Name | Should -Not -Be $null
    $response.DisplayName | Should -Not -Be $null
    $response.OriginalQuantity | Should -Not -Be $null
    $response.Term | Should -Not -Be $null
    $response.ProvisioningState | Should -Not -Be $null
    $response.BillingPlan | Should -Not -Be $null
    $response.Reservations | Should -Not -Be $null
    $response.Reservations.Count | Should -BeGreaterThan 0
    $response.Type | Should -Be "microsoft.capacity/reservationOrders"
    $response.BenefitStartTime | Should -Not -Be $null
    $response.ExpiryDateTime | Should -Not -Be $null
    $response.CreatedDateTime | Should -Not -Be $null
    $response.RequestDateTime | Should -Not -Be $null
}

Describe 'Invoke-AzReservationReturn' {
    It 'PostExpanded' {
        $orderId = "4c74b273-a5e4-4dff-822d-fb586cbfb4a6"
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/4c74b273-a5e4-4dff-822d-fb586cbfb4a6/reservations/318290ae-fb70-4661-ac30-043f3b0cd117"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/4c74b273-a5e4-4dff-822d-fb586cbfb4a6"
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'Post' {
        $orderId = "984f6907-4d2c-4411-a5d9-0e2e72d0e06a"
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/984f6907-4d2c-4411-a5d9-0e2e72d0e06a"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/984f6907-4d2c-4411-a5d9-0e2e72d0e06a/reservations/e188ea59-e105-493f-86be-64b4af4907a7"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -Body $body
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/984f6907-4d2c-4411-a5d9-0e2e72d0e06a/reservations/e188ea59-e105-493f-86be-64b4af4907a7"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }

        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -Body $body2
        ExecuteTestCases($response)
    }

    It 'PostViaIdentityExpanded' {
        $param = @{
                    ReservationOrderId = "4c74b273-a5e4-4dff-822d-fb586cbfb4a6" 
        }
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/4c74b273-a5e4-4dff-822d-fb586cbfb4a6/reservations/318290ae-fb70-4661-ac30-043f3b0cd117"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/4c74b273-a5e4-4dff-822d-fb586cbfb4a6"
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -InputObject $param -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'PostViaIdentity' {
        $param = @{
                    ReservationOrderId = "73e63333-9b94-442c-8a5d-9403ba0e8b87"  
        }
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87/reservations/6414bc34-8753-45df-8499-ba5b5af1c62b"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -Body $body

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87/reservations/6414bc34-8753-45df-8499-ba5b5af1c62b"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }
        $response = Invoke-AzReservationReturn -InputObject $param -Body $body2
        ExecuteTestCases($response)
    }
}
