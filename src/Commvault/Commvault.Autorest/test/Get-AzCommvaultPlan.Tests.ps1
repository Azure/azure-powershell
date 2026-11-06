if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCommvaultPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommvaultPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCommvaultPlan' {
    It 'List' {
        $plans = @(Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -CloudAccountName $env.CloudAccountName -ResourceGroupName $env.ResourceGroupName)
        $plans.Count | Should -BeGreaterOrEqual 1
        $plans.Name | Should -Contain $env.PlanName
    }

    It 'Get' {
        $plan = Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -CloudAccountName $env.CloudAccountName -Name $env.PlanName -ResourceGroupName $env.ResourceGroupName
        $plan.Name | Should -Be $env.PlanName
        $plan.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'GetViaIdentityCloudAccount' {
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $plan = Get-AzCommvaultPlan -CloudAccountInputObject @{ Id = $account.Id } -Name $env.PlanName
        $plan.Name | Should -Be $env.PlanName
    }

    It 'GetViaIdentity' {
        $plan = Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -CloudAccountName $env.CloudAccountName -Name $env.PlanName -ResourceGroupName $env.ResourceGroupName
        $byIdentity = Get-AzCommvaultPlan -InputObject @{ Id = $plan.Id }
        $byIdentity.Name | Should -Be $env.PlanName
        $byIdentity.Id | Should -Be $plan.Id
    }
}
