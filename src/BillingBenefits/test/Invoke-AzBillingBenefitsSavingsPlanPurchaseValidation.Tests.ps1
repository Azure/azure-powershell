if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$model = @{
    SkuName = "Compute_Savings_Plan"
    DisplayName = "MockName"
    Term = "P1Y"
    AppliedScopeType = "Shared"
    BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
    CommitmentGrain = "Hourly"
    CommitmentAmount = 0.01
    CommitmentCurrencyCode = "USD"
}

$models = @($model)

$body = @{
    Benefit = $models
}

Describe 'Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation' {
    It 'ValidateExpanded' {
        $response = Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation -Benefit $models
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }

    It 'Validate' {
        $response = Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation -Body $body
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }
}
