if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationsReservationOrder'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationsReservationOrder.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationsReservationOrder' {
    It 'List' {
        $res = Get-AzReservationsReservationOrder
        $res | Should -Not -Be $null
        $res.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $res = Get-AzReservationsReservationOrder -ReservationOrderId "10000000-aaaa-bbbb-cccc-100000000001"
        $res | Should -Not -Be $null
        $res.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001"
        $res.DisplayName | Should -Be "VM_RI_06-21-2022_13-13"
        $res.OriginalQuantity | Should -Be 1
        $res.Term | Should -Be "P3Y"
        $res.ProvisioningState | Should -Be "Succeeded"
        $res.BillingPlan | Should -Be "Monthly"
        $res.Reservation | Should -Not -Be $null
        $res.Reservation.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001/reservations/50000000-aaaa-bbbb-cccc-100000000003"
    }

    It 'GetViaIdentity' {
         $param = @{
                    ReservationOrderId = "10000000-aaaa-bbbb-cccc-100000000001" 
                }
        $res = Get-AzReservationsReservationOrder -InputObject $param
        $res | Should -Not -Be $null
        $res.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001"
        $res.DisplayName | Should -Be "VM_RI_06-21-2022_13-13"
        $res.OriginalQuantity | Should -Be 1
        $res.Term | Should -Be "P3Y"
        $res.ProvisioningState | Should -Be "Succeeded"
        $res.BillingPlan | Should -Be "Monthly"
        $res.Reservation | Should -Not -Be $null
        $res.Reservation.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001/reservations/50000000-aaaa-bbbb-cccc-100000000003"
    }
}
