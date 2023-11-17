if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBillingBenefitsSavingsPlanOrderAlias'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBillingBenefitsSavingsPlanOrderAlias.Recording.json'
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
    $response.displayName | Should -Be "PSTest2"
    $response.CommitmentGrain | Should -Be "Hourly"
    $response.CommitmentCurrencyCode | Should -Be "USD"
    $response.CommitmentAmount | Should -Be 0.001
    $response.BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

Describe 'Get-AzBillingBenefitsSavingsPlanOrderAlias' {
    It 'Get' {
        $response = Get-AzBillingBenefitsSavingsPlanOrderAlias -Name "PSTest2"
        ExecuteTestCases($response)
    }

    It 'GetViaIdentity' {
        $identity = @{
                        SavingsPlanOrderAliasName = "PSTest2"
                    }
        $response = Get-AzBillingBenefitsSavingsPlanOrderAlias -InputObject $identity
        ExecuteTestCases($response)
    }
}
