if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBillingBenefitsSavingsPlanOrder'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBillingBenefitsSavingsPlanOrder.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function ExecuteTestCases([object]$response) {
    $response.Id | Should -Not -Be $null
    $response.Name | Should -Not -Be $null
    $response.SkuName | Should -Be "Compute_Savings_Plan"
    $response.ProvisioningState | Should -Be "Succeeded"
    $response.Term | Should -Be "P3Y"
    $response.ExpiryDateTime | Should -Not -Be $null
    $response.BenefitStartTime | Should -Not -Be $null
    $response.BillingAccountId | Should -Be "/providers/Microsoft.Billing/billingAccounts/4973e1de-a829-5c64-4fef-0a692e2b3108:1970c5da-0aa4-46fd-a917-4772f9a17978_2019-05-31"
    $response.BillingProfileId | Should -Be "/providers/Microsoft.Billing/billingAccounts/4973e1de-a829-5c64-4fef-0a692e2b3108:1970c5da-0aa4-46fd-a917-4772f9a17978_2019-05-31/billingProfiles/KPSV-DWNE-BG7-TGB"
    $response.BillingScopeId | Should -Be "eef82110-c91b-4395-9420-fcfcbefc5a47"
    $response.SavingsPlan | Should -Not -Be $null
    $response.SavingsPlan.Count | Should -BeGreaterThan 0
}

Describe 'Get-AzBillingBenefitsSavingsPlanOrder' {
    It 'List' {
        $response = Get-AzBillingBenefitsSavingsPlanOrder
        $response | Should -Not -Be $null
        $response.Count | Should -BeGreaterThan 0
        foreach ($res in $response)
        {
            ExecuteTestCases($res)
        }
    }

    It 'Get' {
        $response = Get-AzBillingBenefitsSavingsPlanOrder -Id "849623f7-c032-4868-a6a1-c8891fa3af17"
        $response | Should -Not -Be $null
        ExecuteTestCases($response)
    }

    It 'GetViaIdentity' {
        $identity = @{
                        SavingsPlanOrderId = "849623f7-c032-4868-a6a1-c8891fa3af17"
                    }
        $response = Get-AzBillingBenefitsSavingsPlanOrder -InputObject $identity
        $response | Should -Not -Be $null
        ExecuteTestCases($response)
    }
}
