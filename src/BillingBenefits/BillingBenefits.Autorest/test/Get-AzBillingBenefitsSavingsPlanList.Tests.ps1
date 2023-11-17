if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBillingBenefitsSavingsPlanList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBillingBenefitsSavingsPlanList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzBillingBenefitsSavingsPlanList' {
    It 'List' {
        $response = Get-AzBillingBenefitsSavingsPlanList
        $response | Should -Not -Be $null
        $response.Count | Should -BeGreaterThan 0

        for($i=0;$i -lt $response.Count;$i++)
        {   
            $version = $response.Count - $i
            $response[$i].CommitmentAmount | Should -BeGreaterThan 0
            $response[$i].AppliedScopeType | Should -Not -Be $null
            $response[$i].BenefitStartTime | Should -Not -Be $null
            $response[$i].BillingAccountId | Should -Not -Be $null
            $response[$i].Term | Should -Not -Be $null
            $response[$i].BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
            $response[$i].CommitmentCurrencyCode | Should -Be "USD"
            $response[$i].DisplayName | Should -Not -Be $null
            $response[$i].EffectiveDateTime | Should -Not -Be $null
            $response[$i].ExpiryDateTime | Should -Not -Be $null
            $response[$i].PurchaseDateTime | Should -Not -Be $null
            $response[$i].DisplayProvisioningState | Should -Be "Succeeded"
            $response[$i].ProvisioningState | Should -Be "Succeeded"
            $response[$i].CommitmentGrain | Should -Be "Hourly"
            $response[$i].UtilizationTrend | Should -Be "SAME"
            $response[$i].UtilizationAggregate | Should -Not -Be $null
            $response[$i].Renew | Should -Not -Be $null
            $response[$i].Id | Should -Not -Be $null
        }
    }

    It 'ListWithFiltering' {
        $response = Get-AzBillingBenefitsSavingsPlanList
        $response | Should -Not -Be $null
        $response.Count | Should -BeGreaterThan 0

        $arr = New-Object string[] $response.Count
        for($i=0;$i -lt $response.Count;$i++)
        { 
            $arr[$i] = $response[$i].AppliedScopeType
        }

        $arr | Should -Contain "Single"
        $arr | Should -Contain "Shared"

        $response1 = Get-AzBillingBenefitsSavingsPlanList -Filter "properties/userFriendlyAppliedScopeType eq 'Shared'"
        $arr1 = New-Object string[] $response1.Count
        for($i=0;$i -lt $response1.Count;$i++)
        { 
            $arr1[$i] = $response1[$i].AppliedScopeType
        }

        # Only returns "Shared" scope items when filter is applied
        $arr1 | Should -Not -Contain "Single"
        $arr1 | Should -Contain "Shared"
    }
}
