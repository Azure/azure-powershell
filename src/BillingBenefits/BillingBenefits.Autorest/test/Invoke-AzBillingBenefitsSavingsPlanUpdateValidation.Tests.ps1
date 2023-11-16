if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzBillingBenefitsSavingsPlanUpdateValidation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBillingBenefitsSavingsPlanUpdateValidation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$model = @{
    AppliedScopeType = "Single"
    AppliedScopePropertiesSubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

$models = @($model)

$body = @{
    Benefit = $models
}

$identity = @{
    SavingsPlanOrderId = "d7ea1620-2bba-46e2-8434-11f31bfb984d"
    SavingsPlanId = "9fde2a72-776b-49fc-869c-dca8859d7d62"
}

Describe 'Invoke-AzBillingBenefitsSavingsPlanUpdateValidation' {
    It 'ValidateExpanded' {
        $response = Invoke-AzBillingBenefitsSavingsPlanUpdateValidation -SavingsPlanId "9fde2a72-776b-49fc-869c-dca8859d7d62" -SavingsPlanOrderId "d7ea1620-2bba-46e2-8434-11f31bfb984d" -Benefit $models
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }

    It 'Validate' {
        $response = Invoke-AzBillingBenefitsSavingsPlanUpdateValidation -SavingsPlanId "9fde2a72-776b-49fc-869c-dca8859d7d62" -SavingsPlanOrderId "d7ea1620-2bba-46e2-8434-11f31bfb984d" -Body $body
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }

    It 'ValidateViaIdentityExpanded' {
        $response = Invoke-AzBillingBenefitsSavingsPlanUpdateValidation -InputObject $identity -Benefit $models
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }

    It 'ValidateViaIdentity' {
        $response = Invoke-AzBillingBenefitsSavingsPlanUpdateValidation -InputObject $identity -Body $body
        $response | Should -Not -Be $null
        $response.Valid | Should -Not -Be $null
        $response.Valid | Should -Be "True"
    }
}
