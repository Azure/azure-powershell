if(($null -eq $TestName) -or ($TestName -contains 'New-AzReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.DisplayName | Should -Not -Be $null
    $response.RequestDateTime | Should -Not -Be $null
    $response.CreatedDateTime | Should -Not -Be $null
    $response.ExpiryDate | Should -Not -Be $null
    $response.BenefitStartTime | Should -Not -Be $null
    $response.Term| Should -Be "P1Y"
    $response.Reservations | Should -Not -Be $null
    $response.Reservations.Count | Should -Be 1
    $response.OriginalQuantity | Should -Be 1
    $response.BillingPlan | Should -Be "Upfront"
}

Describe 'New-AzReservation' {
    It 'PurchaseExpanded' {
        $quoteResponse = Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006' -DisplayName 'TestVm1' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
        $quoteResponse.ReservationOrderId | Should -Not -Be $null

        $response = New-AzReservation -ReservationOrderId $quoteResponse.ReservationOrderId -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006' -DisplayName 'TestVm1' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
        ExecuteTestCases($response)
    }

    It 'Purchase' {
        $purchaseRequest = @{
            AppliedScopeType = "Shared"
            BillingPlan = "Upfront"
            billingScopeId = '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006' 
            DisplayName = "Testvm2"
            Location = "westus"
            Quantity = 1
            ReservedResourceType = "VirtualMachines"
            Sku = "Standard_b1ls"
            Term = "P1Y"
        }
        $quoteResponse = Get-AzReservationQuote -Body $purchaseRequest
        $quoteResponse.ReservationOrderId | Should -Not -Be $null

        $response = New-AzReservation -ReservationOrderId $quoteResponse.ReservationOrderId -Body $purchaseRequest
        ExecuteTestCases($response)
    }

    It 'PurchaseViaIdentityExpanded' {
        $quoteResponse = Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006' -DisplayName 'TestVm3' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
        $quoteResponse.ReservationOrderId | Should -Not -Be $null
        $param = @{
            ReservationOrderId = $quoteResponse.ReservationOrderId
        }
        $response = New-AzReservation -InputObject $param -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006' -DisplayName 'TestVm3' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
        ExecuteTestCases($response)
    }

    It 'PurchaseViaIdentity' {
        $purchaseRequest = @{
            AppliedScopeType = "Shared"
            BillingPlan = "Upfront"
            billingScopeId = '/subscriptions/40000000-aaaa-bbbb-cccc-200000000006'
            DisplayName = "Testvm4"
            Location = "westus"
            Quantity = 1
            ReservedResourceType = "VirtualMachines"
            Sku = "Standard_b1ls"
            Term = "P1Y"
        }
        $quoteResponse = Get-AzReservationQuote -Body $purchaseRequest
        $quoteResponse.ReservationOrderId | Should -Not -Be $null
        $param = @{
            ReservationOrderId = $quoteResponse.ReservationOrderId
        }
        $response = New-AzReservation -InputObject $param -Body $purchaseRequest
        ExecuteTestCases($response)
    }
}
