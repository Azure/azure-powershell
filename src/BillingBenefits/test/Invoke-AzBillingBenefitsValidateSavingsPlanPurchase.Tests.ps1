if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzBillingBenefitsValidateSavingsPlanPurchase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBillingBenefitsValidateSavingsPlanPurchase.Recording.json'
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

Describe 'Invoke-AzBillingBenefitsValidateSavingsPlanPurchase' {
    It 'ValidateExpanded' {
        $response = Invoke-AzBillingBenefitsValidateSavingsPlanPurchase -Benefit $models
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }

    It 'Validate' {
        $response = Invoke-AzBillingBenefitsValidateSavingsPlanPurchase -Body $body
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }
}
