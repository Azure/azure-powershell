if(($null -eq $TestName) -or ($TestName -contains 'New-AzBillingBenefitsSavingsPlanOrderAlias'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBillingBenefitsSavingsPlanOrderAlias.Recording.json'
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
    $response.SkuName | Should -Be "Compute_Savings_Plan"
    $response.ProvisioningState | Should -Be "Created"
    $response.Type | Should -Be "Microsoft.BillingBenefits/savingsPlanOrderAliases"
    $response.Term | Should -Be "P3Y"
    $response.DisplayName | Should -Not -Be $null
    $response.SavingsPlanOrderId | Should -Not -Be $null
    $response.AppliedScopeType | Should -Be "Shared"
    $response.BillingPlan | Should -Be "P1M"
    $response.CommitmentGrain | Should -Be "Hourly"
    $response.CommitmentCurrencyCode | Should -Be "USD"
    $response.CommitmentAmount | Should -Be 0.001
    $response.BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

Describe 'New-AzBillingBenefitsSavingsPlanOrderAlias' {
    It 'CreateExpanded' {
        $response = New-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest1" -AppliedScopeType "Shared" -BillingPlan "P1M" -BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -CommitmentAmount 0.001 -CommitmentCurrencyCode "USD" -CommitmentGrain "Hourly" -SkuName "Compute_Savings_Plan" -DisplayName "PSTest1" -Term "P3Y"
        ExecuteTestCases($response)
    }

    It 'Create' {
        $request = @{
                        AppliedScopeType = "Shared"
                        BillingPlan = "P1M"
                        BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                        CommitmentAmount = 0.001
                        CommitmentCurrencyCode = "USD"
                        CommitmentGrain = "Hourly"
                        SkuName = "Compute_Savings_Plan"
                        DisplayName = "PSTest2"
                        Term = "P3Y"
                    }
        $response = New-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest5" -Body $request
        ExecuteTestCases($response)
        
    }

    It 'CreateViaIdentityExpanded' {
        $request = @{
                        AppliedScopeType = "Shared"
                        BillingPlan = "P1M"
                        BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                        CommitmentAmount = 0.001
                        CommitmentCurrencyCode = "USD"
                        CommitmentGrain = "Hourly"
                        SkuName = "Compute_Savings_Plan"
                        DisplayName = "PSTest3"
                        Term = "P3Y"
                    }

        $identity = @{
                        SavingsPlanOrderAliasName = "PSTest3"
                    }
        
        $response = New-AzBillingBenefitsSavingsPlanOrderAlias -InputObject $identity -Body $request
        ExecuteTestCases($response)
    }

    It 'CreateViaIdentity' {
        $identity = @{
                        SavingsPlanOrderAliasName = "PSTest10"
                    }
        $response = New-AzBillingBenefitsSavingsPlanOrderAlias -InputObject $identity -AppliedScopeType "Shared" -BillingPlan "P1M" -BillingScopeId "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47" -CommitmentAmount 0.001 -CommitmentCurrencyCode "USD" -CommitmentGrain "Hourly" -SkuName "Compute_Savings_Plan" -DisplayName "PSTest10" -Term "P3Y"
        ExecuteTestCases($response)
    }
}
