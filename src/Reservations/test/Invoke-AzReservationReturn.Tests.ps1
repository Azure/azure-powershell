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
        $orderId = "3e8a292c-1e34-4e97-b418-f465caaed066"
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/3e8a292c-1e34-4e97-b418-f465caaed066/reservations/ce393c70-16c4-4bf4-80d9-cfdd1394f609"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/3e8a292c-1e34-4e97-b418-f465caaed066"
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'Post' {
        $orderId = "b73c2c25-6c4e-4942-896f-594427543c2e"
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/b73c2c25-6c4e-4942-896f-594427543c2e"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/b73c2c25-6c4e-4942-896f-594427543c2e/reservations/43ffe01b-196a-4053-a68f-330fe3ac1581"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -Body $body
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/b73c2c25-6c4e-4942-896f-594427543c2e/reservations/43ffe01b-196a-4053-a68f-330fe3ac1581"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }

        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -Body $body2
        ExecuteTestCases($response)
    }

    It 'PostViaIdentityExpanded' {
        $param = @{
                    ReservationOrderId = "e77c28cf-e0d8-4322-8b41-b3fa26ec21eb" 
        }
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/e77c28cf-e0d8-4322-8b41-b3fa26ec21eb/reservations/89ab48ca-721b-4044-b9e1-389d6d5ead4d"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/e77c28cf-e0d8-4322-8b41-b3fa26ec21eb"
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
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87/reservations/ab9761bb-324c-474a-b96c-3471bd643328"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -Body $body
        

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87/reservations/ab9761bb-324c-474a-b96c-3471bd643328"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }
        $response = Invoke-AzReservationReturn -InputObject $param -Body $body2
        ExecuteTestCases($response)
    }
}
