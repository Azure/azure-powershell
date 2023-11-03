if(($null -eq $TestName) -or ($TestName -contains 'Update-AzBillingBenefitsSavingsPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzBillingBenefitsSavingsPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzBillingBenefitsSavingsPlan' {
    It 'UpdateExpanded' {
        $response1 = Get-AzBillingBenefitsSavingsPlan -Id "f82fd820-f829-4022-8ba5-e3bf4ffc329b" -OrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11"
        $oldName = $response1.DisplayName
        $response2 = Update-AzBillingBenefitsSavingsPlan -Id "f82fd820-f829-4022-8ba5-e3bf4ffc329b" -OrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11" -DisplayName "TestPSName1"
        $response2 | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $oldName
    }

    It 'Update' {
        $response1 = Get-AzBillingBenefitsSavingsPlan -Id "0c382729-4c81-48a9-a350-5b7a8beccea5" -OrderId "e0167471-b48e-4c03-93ca-506ac67a567f"
        $oldName = $response1.DisplayName
        $request = @{
            DisplayName = "TestPSName2"
        }
        $response2 = Update-AzBillingBenefitsSavingsPlan -Id "0c382729-4c81-48a9-a350-5b7a8beccea5" -OrderId "e0167471-b48e-4c03-93ca-506ac67a567f" -Body $request
        $response2 | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $oldName
    }

    It 'UpdateViaIdentityExpanded' {
        $identity = @{
            SavingsPlanId = "55b6f673-9f5e-407b-abcf-ef11b844c1e7"
            SavingsPlanOrderId = "2641510c-3174-4831-8665-b693673880be"
        }
        $response1 = Get-AzBillingBenefitsSavingsPlan -InputObject $identity
        $oldName = $response1.DisplayName
        $response2 = Update-AzBillingBenefitsSavingsPlan -InputObject $identity -DisplayName "TestPSName3"
        $response2 | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $oldName
    }

    It 'UpdateViaIdentity' {
        $identity = @{
            SavingsPlanId = "cd6d708d-068e-4972-8535-410de471558f"
            SavingsPlanOrderId = "254638e0-2860-4e7b-af3e-92285554fc9d"
        }
        $request = @{
            DisplayName = "TestPSName4"
        }
        $response1 = Get-AzBillingBenefitsSavingsPlan -InputObject $identity
        $oldName = $response1.DisplayName
        $response2 = Update-AzBillingBenefitsSavingsPlan -InputObject $identity -Body $request
        $response2 | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $null
        $response2.DisplayName | Should -Not -Be $oldName
    }

    It 'UpdateWithRenewalSetting' {
        $response1 = Get-AzBillingBenefitsSavingsPlan -Id "82a298d8-67ca-470d-ae9d-17dc39793fe8" -OrderId "6296d1ad-86dd-4959-a949-64b8a10603a6"
        $response1.Renew | Should -Be $False

        $request = @{
            Renew = "true"
            RenewProperty = @{
                    PurchaseProperty = @{
                    AppliedScopeType = "Shared"
                    BillingPlan = "P1M"
                    BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                    CommitmentAmount = 0.001
                    CommitmentGrain = "Hourly"
                    CommitmentCurrency = "USD"
                    DisplayName = "newDisplayName"
                    Term = "P1Y"
                    SkuName = "Compute_Savings_Plan"
                }
            }
        }

        $response2 = Update-AzBillingBenefitsSavingsPlan -Id "0c382729-4c81-48a9-a350-5b7a8beccea5" -OrderId "e0167471-b48e-4c03-93ca-506ac67a567f" -Body $request
        $response2 | Should -Not -Be $null
        $response2.Renew | Should -Be $True
    }
}
