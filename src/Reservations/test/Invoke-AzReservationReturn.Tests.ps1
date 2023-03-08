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
        $orderId = "73e63333-9b94-442c-8a5d-9403ba0e8b87"
        $fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87/reservations/89ab48ca-721b-4044-b9e1-389d6d5ead4d"
        $fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/73e63333-9b94-442c-8a5d-9403ba0e8b87"
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null
        
        $response = Invoke-AzReservationReturn -ReservationOrderId $orderId -ReservationToReturnQuantity 1  -ReservationToReturnReservationId $fullyQualifiedId -ReturnReason "Sample return reason" -SessionId $res.SessionId  -Scope "Reservation"
        ExecuteTestCases($response)
    }

    It 'Post' {
        $orderId = "0667f90e-a383-4c24-b3d4-1b624589f713"
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/0667f90e-a383-4c24-b3d4-1b624589f713"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/0667f90e-a383-4c24-b3d4-1b624589f713/reservations/7b2ad768-936a-4c5d-973f-35788eb96934"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -Body $body
        $res | Should -Not -Be $null
        $res.SessionId | Should -Not -Be $null

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/0667f90e-a383-4c24-b3d4-1b624589f713/reservations/7b2ad768-936a-4c5d-973f-35788eb96934"
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
                    ReservationOrderId = "62069b8a-8f84-49ab-9a4a-f69009390876"  
        }
        $body = @{
            Id = "/providers/microsoft.capacity/reservationOrders/62069b8a-8f84-49ab-9a4a-f69009390876"
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/62069b8a-8f84-49ab-9a4a-f69009390876/reservations/21eae555-c406-47d5-a178-98cf422be361"
            Scope = "Reservation"
        }
        $res = Invoke-AzReservationCalculateRefund -InputObject $param -Body $body

        $body2 = @{
            ReservationToReturnQuantity = 1
            ReservationToReturnReservationId = "/providers/microsoft.capacity/reservationOrders/62069b8a-8f84-49ab-9a4a-f69009390876/reservations/21eae555-c406-47d5-a178-98cf422be361"
            Scope = "Reservation"
            ReturnReason = "Sample reason"
            SessionId = $res.SessionId
        }
        $response = Invoke-AzReservationReturn -InputObject $param -Body $body2
        ExecuteTestCases($response)
    }
}
