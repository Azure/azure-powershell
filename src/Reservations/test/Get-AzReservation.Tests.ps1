if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservation'{
    It 'List1' {
        $res = Get-AzReservation
        $res | Should -Not -Be $null
        $res.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $res = Get-AzReservation -ReservationOrderId "10000000-aaaa-bbbb-cccc-100000000001" -ReservationId "50000000-aaaa-bbbb-cccc-100000000003"
        $res | Should -Not -Be $null
        $res.Location | Should -Be "westeurope"
        $res.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001/reservations/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Sku | Should -Be "Standard_B1ls"
        $res.ProvisioningState | Should -Be "Succeeded"
        $res.SkuDescription | Should -Be "Reserved VM Instance, Standard_B1ls, EU West, 3 Years"
    }

    It 'List' {
        $res = Get-AzReservation
        $res.Count | Should -BeGreaterThan 0
    }

    It 'GetViaIdentity'  {
        $param = @{
                    ReservationOrderId = "10000000-aaaa-bbbb-cccc-100000000001" 
                    ReservationId = "50000000-aaaa-bbbb-cccc-100000000003"
                }
        $res = Get-AzReservation -InputObject $param
        $res | Should -Not -Be $null
        $res.Location | Should -Be "westeurope"
        $res.Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001/reservations/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Name | Should -Be "10000000-aaaa-bbbb-cccc-100000000001/50000000-aaaa-bbbb-cccc-100000000003"
        $res.Sku | Should -Be "Standard_B1ls"
        $res.SkuDescription | Should -Be "Reserved VM Instance, Standard_B1ls, EU West, 3 Years"
    }
}
