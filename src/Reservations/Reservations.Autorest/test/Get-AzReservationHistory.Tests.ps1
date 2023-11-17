if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationHistory'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationHistory.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationHistory' {
    It 'Get' {
        $response = Get-AzReservationHistory -ReservationOrderId "10000000-aaaa-bbbb-cccc-100000000001" -ReservationId "50000000-aaaa-bbbb-cccc-100000000003"
    
        $response | Should -Not -Be $null
        $response.Count | Should -BeGreaterThan 0
        for($i=0;$i -lt $response.Count;$i++)
        {   
            $version = $response.Count - $i
            $response[$i].Location | Should -Be "westeurope"
            $response[$i].Id | Should -Be "/providers/microsoft.capacity/reservationOrders/10000000-aaaa-bbbb-cccc-100000000001/reservations/50000000-aaaa-bbbb-cccc-100000000003/revisions/$version"
            $response[$i].Name | Should -Be "$version"
            $response[$i].SkuName | Should -Be "Standard_B1ls"
            $response[$i].ProvisioningState | Should -Not -Be $null
            $response[$i].SkuDescription | Should -Be "Reserved VM Instance, Standard_B1ls, EU West, 3 Years"
            $response[$i].Quantity | Should -Be 1
            $response[$i].Renew | Should -Be "False"
            $response[$i].ReservedResourceType | Should -Be "VirtualMachines"
            $response[$i].InstanceFlexibility | Should -Be "On"
            $response[$i].AppliedScopeType | Should -Be "Single"
            $response[$i].AppliedScopePropertySubscriptionId | Should -Be "/subscriptions/10000000-aaaa-bbbb-cccc-100000000001"
        }
    }
}
