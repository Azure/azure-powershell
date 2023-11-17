if(($null -eq $TestName) -or ($TestName -contains 'New-AzBillingBenefitsReservationOrderAlias'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBillingBenefitsReservationOrderAlias.Recording.json'
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
    $response.SkuName | Should -Be "Standard_B1ls"
    $response.ProvisioningState | Should -Be "Created"
    $response.Location | Should -Be "westus"
    $response.Type | Should -Be "Microsoft.BillingBenefits/reservationOrderAliases"
    $response.Term | Should -Be "P1Y"
    $response.ReservedResourceType | Should -Be "VirtualMachines"
    $response.DisplayName | Should -Not -Be $null
    $response.ReservationOrderId | Should -Not -Be $null
    $response.AppliedScopeType | Should -Be "Shared"
    $response.BillingPlan | Should -Be "P1M"
    $response.BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

Describe 'New-AzBillingBenefitsReservationOrderAlias' {
    It 'CreateExpanded' {
        $response = New-AzBillingBenefitsReservationOrderAlias -Name "PSRITest1" -AppliedScopeType "Shared" -BillingPlan "P1M" -BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -SkuName "Standard_B1ls" -Location "westus" -Quantity 1 -ReservedResourceType 'VirtualMachines' -Term "P1Y" -DisplayName "PSRITest1"
        ExecuteTestCases($response)
    }

    It 'Create' {
        $purchaseRequest = @{
            AppliedScopeType = "Shared"
            BillingPlan = "P1M"
            BillingScopeId = '/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47' 
            DisplayName = "PSRITest2"
            Location = "westus"
            Quantity = 1
            ReservedResourceType = "VirtualMachines"
            SkuName = "Standard_B1ls"
            Term = "P1Y"
        }

        $response = New-AzBillingBenefitsReservationOrderAlias -Name "PSRITest2" -Body $purchaseRequest 
        ExecuteTestCases($response)
    }

    It 'CreateViaIdentityExpanded' {
        $identity = @{
                        ReservationOrderAliasName = "PSRITest5"
                    }
        $response = New-AzBillingBenefitsReservationOrderAlias -InputObject $identity -AppliedScopeType "Shared" -BillingPlan "P1M" -BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -SkuName "Standard_B1ls" -Location "westus" -Quantity 1 -ReservedResourceType 'VirtualMachines' -Term "P1Y" -DisplayName "PSRITest5"
        ExecuteTestCases($response)
    }

    It 'CreateViaIdentity' {
        $purchaseRequest = @{
            AppliedScopeType = "Shared"
            BillingPlan = "P1M"
            BillingScopeId = '/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47' 
            DisplayName = "PSRITest4"
            Location = "westus"
            Quantity = 1
            ReservedResourceType = "VirtualMachines"
            SkuName = "Standard_B1ls"
            Term = "P1Y"
        }

        $identity = @{
                        ReservationOrderAliasName = "PSRITest4"
                    }

        $response = New-AzBillingBenefitsReservationOrderAlias -InputObject $identity -Body $purchaseRequest
        ExecuteTestCases($response)
    }
}
