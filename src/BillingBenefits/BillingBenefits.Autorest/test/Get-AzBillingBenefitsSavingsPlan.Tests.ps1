if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBillingBenefitsSavingsPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBillingBenefitsSavingsPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.AppliedScopeType | Should -Not -Be $null
    $response.BenefitStartTime | Should -Not -Be $null
    $response.BillingAccountId | Should -Not -Be $null
    $response.Term | Should -Not -Be $null
    $response.BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
    $response.CommitmentCurrencyCode | Should -Be "USD"
    $response.DisplayName | Should -Not -Be $null
    $response.EffectiveDateTime | Should -Not -Be $null
    $response.ExpiryDateTime | Should -Not -Be $null
    $response.PurchaseDateTime | Should -Not -Be $null
    $response.DisplayProvisioningState | Should -Be "Succeeded"
    $response.ProvisioningState | Should -Be "Succeeded"
    $response.CommitmentGrain | Should -Be "Hourly"
    $response.UtilizationTrend | Should -Be "SAME"
    $response.UtilizationAggregate | Should -Not -Be $null
    $response.Renew | Should -Not -Be $null
    $response.Id | Should -Not -Be $null
}

Describe 'Get-AzBillingBenefitsSavingsPlan' {
    It 'List' {
        $response = Get-AzBillingBenefitsSavingsPlan -OrderId '254638e0-2860-4e7b-af3e-92285554fc9d'
        $response | Should -Not -Be $null
        $response.Count | Should -Be 1
        ExecuteTestCases($response[0])
    }

    It 'Get' {
        $response = Get-AzBillingBenefitsSavingsPlan -OrderId '254638e0-2860-4e7b-af3e-92285554fc9d' -Id 'cd6d708d-068e-4972-8535-410de471558f'
        ExecuteTestCases($response)
    }

    It 'GetViaIdentity' {
        $identity = @{
                        SavingsPlanOrderId = "254638e0-2860-4e7b-af3e-92285554fc9d"
                        SavingsPlanId = "cd6d708d-068e-4972-8535-410de471558f"
                    }
        $response = Get-AzBillingBenefitsSavingsPlan -InputObject $identity
        ExecuteTestCases($response)
    }
}
