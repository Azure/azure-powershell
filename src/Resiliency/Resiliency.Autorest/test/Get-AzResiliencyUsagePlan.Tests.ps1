if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyUsagePlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyUsagePlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyUsagePlan' {
    It 'List' {
        $plans = @(Get-AzResiliencyUsagePlan -SubscriptionId $env.SubscriptionId)
        $plans.Name | Should -Contain $env.usagePlanName
    }

    It 'Get' {
        $plan = Get-AzResiliencyUsagePlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Name $env.usagePlanName
        $plan.Name | Should -Be $env.usagePlanName
        $plan.Location | Should -Be 'global'
        $plan.PlanType | Should -Be 'Standard'
        $plan.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'ListByResourceGroup' {
        $plans = @(Get-AzResiliencyUsagePlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName)
        $plans.Name | Should -Contain $env.usagePlanName
        $plans.ResourceGroupName | Should -Contain $env.resourceGroupName
    }

    It 'GetViaIdentity' {
        $identity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $plan = Get-AzResiliencyUsagePlan -InputObject $identity
        $plan.Name | Should -Be $env.usagePlanName
        $plan.PlanType | Should -Be 'Standard'
    }
}
