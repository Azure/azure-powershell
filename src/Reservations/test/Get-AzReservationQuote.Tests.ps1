if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationQuote'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationQuote.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.BillingCurrencyTotal | Should -Not -Be $null
    $response.PricingCurrencyTotal | Should -Not -Be $null
    $response.BillingCurrencyTotal.CurrencyCode | Should -Be "USD"
    $response.BillingCurrencyTotal.Amount | Should -Be 32
    $response.PricingCurrencyTotal.CurrencyCode | Should -Be "USD"
    $response.PricingCurrencyTotal.Amount | Should -Be 32
    $response.ReservationOrderId | Should -Not -Be $null
}

Describe 'Get-AzReservationQuote' {
    It 'CalculateExpanded' {
        $response = Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/30000000-aaaa-bbbb-cccc-100000000005' -DisplayName 'TestVm' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
        ExecuteTestCases($response)
    }

    It 'Calculate' {
        $reservationToPurchase = @{
            AppliedScopeType = "Shared"
            BillingPlan = "Upfront"
            billingScopeId = '/subscriptions/30000000-aaaa-bbbb-cccc-100000000005' 
            DisplayName = "Testvm"
            Location = "westus"
            Quantity = 1
            ReservedResourceType = "VirtualMachines"
            Sku = "Standard_b1ls"
            Term = "P1Y"
        }
        $response = Get-AzReservationQuote -Body $reservationToPurchase
        ExecuteTestCases($response)
    }
}
