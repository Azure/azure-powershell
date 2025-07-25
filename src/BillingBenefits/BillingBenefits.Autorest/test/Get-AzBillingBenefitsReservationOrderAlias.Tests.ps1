if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBillingBenefitsReservationOrderAlias'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBillingBenefitsReservationOrderAlias.Recording.json'
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
    $response.Name | Should -Be "PSRITest2"
    $response.SkuName | Should -Be "Standard_B1ls"
    $response.ProvisioningState | Should -Be "Created"
    $response.Location | Should -Be "westus"
    $response.Type | Should -Be "Microsoft.BillingBenefits/reservationOrderAliases"
    $response.Term | Should -Be "P1Y"
    $response.ReservedResourceType | Should -Be "VirtualMachines"
    $response.DisplayName | Should -Not -Be $null
    $response.ReservationOrderId | Should -Not -Be $null
    $response.AppliedScopeType | Should -Be "Shared"
    $response.BillingPlan | Should -Be "P1M"
    $response.BillingScopeId | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
}

Describe 'Get-AzBillingBenefitsReservationOrderAlias' {
    It 'Get' {
        $response = Get-AzBillingBenefitsReservationOrderAlias -Name "PSRITest2"
        ExecuteTestCases($response)
    }

    It 'GetViaIdentity' {
        $identity = @{
                        ReservationOrderAliasName = "PSRITest2"
                    }
        $response = Get-AzBillingBenefitsReservationOrderAlias -InputObject $identity
        ExecuteTestCases($response)
    }
}
