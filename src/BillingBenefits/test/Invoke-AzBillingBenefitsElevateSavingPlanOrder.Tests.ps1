if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzBillingBenefitsElevateSavingPlanOrder'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBillingBenefitsElevateSavingPlanOrder.Recording.json'
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
    $response.PrincipalId | Should -Not -Be $null
    $response.RoleDefinitionId | Should -Not -Be $null
    $response.Scope | Should -Not -Be $null
}

Describe 'Invoke-AzBillingBenefitsElevateSavingPlanOrder' {
    It 'Elevate' {
        $response = Invoke-AzBillingBenefitsElevateSavingPlanOrder -SavingsPlanOrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11"
        ExecuteTestCases($response)
    }

    It 'ElevateViaIdentity' {
        $identity = @{
            SavingsPlanOrderId = "e45905d2-9207-4f24-8549-f615c203b49b"
        }
        $response = Invoke-AzBillingBenefitsElevateSavingPlanOrder -InputObject $identity
        ExecuteTestCases($response)
    }
}
