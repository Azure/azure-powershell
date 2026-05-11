if(($null -eq $TestName) -or ($TestName -contains 'New-AzDisconnectedOperationsDisconnectedOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDisconnectedOperationsDisconnectedOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDisconnectedOperationsDisconnectedOperation' {
    It 'CreateExpanded' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name "winfield-ps-test-3" -ResourceGroupName $env.ResourceGroupName -ConnectionIntent "Disconnected" -BillingConfigurationAutoRenew $env.DisabledAutoRenew -CurrentCore $env.CurrentCore -CurrentPricingModel $env.AnnualPricingModel -BenefitPlanAzureHybridWindowsServerBenefit "Enabled" -BenefitPlanWindowsServerVMCount 10 -Location $env.Location -Tag @{}

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be "winfield-ps-test-3"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        $result.Location | Should -Be $env.Location
        $result.CurrentCore | Should -Be $env.CurrentCore
        $result.CurrentPricingModel | Should -Be $env.AnnualPricingModel
        $result.BenefitPlanAzureHybridWindowsServerBenefit | Should -Be "Enabled"
        $result.BenefitPlanWindowsServerVMCount | Should -Be 10

    }

    It 'CreateViaJsonFilePath' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/CreateDisconnectedOperations.json')

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        $result.Location | Should -Be $env.Location
        $result.CurrentCore | Should -Be $env.CurrentCore
        $result.CurrentPricingModel | Should -Be $env.AnnualPricingModel
        $result.BenefitPlanAzureHybridWindowsServerBenefit | Should -Be "Enabled"
        $result.BenefitPlanWindowsServerVMCount | Should -Be 10

    }

    It 'CreateViaJsonString' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity","billingConfiguration":{"autoRenew":"Disabled","current":{"cores":8,"pricingModel":"Annual"},"upcoming":{"cores":8,"pricingModel":"Annual"}},"benefitPlans":{"azureHybridWindowsServerBenefit":"Enabled","windowsServerVmCount":10}},"tags":{},"location":"eastus2euap"}'

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        $result.Location | Should -Be $env.Location
        $result.CurrentCore | Should -Be $env.CurrentCore
        $result.CurrentPricingModel | Should -Be $env.AnnualPricingModel
        $result.BenefitPlanAzureHybridWindowsServerBenefit | Should -Be "Enabled"
        $result.BenefitPlanWindowsServerVMCount | Should -Be 10

    }
}
