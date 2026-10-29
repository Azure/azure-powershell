if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCommvaultPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCommvaultPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# The first test creates the plan that the following tests update. The last test removes it again.
Describe 'Update-AzCommvaultPlan' {
    BeforeAll {
        # Not named $name: the test framework's It function has a parameter called Name that would shadow it.
        $planName = 'azps-plan-update'
        $storagePoolId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Commvault.ContentStore/cloudAccounts/$($env.CloudAccountName)/storages/$($env.StorageName)"
        $storagePlan = @{ Name = $env.StorageName; StoragePoolId = $storagePoolId; CopyName = 'Primary Storage'; CopyPrecedence = 0; RetentionPeriod = 15; RetentionTime = 'daily'; BackupRuleType = 'ALL_FULLS'; ExtendedRetention = @() }
        $schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'minutes'; RunsEvery = 30; Time = '' }
    }

    It 'UpdateExpanded' {
        $null = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $planName -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
        $plan = Update-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $planName -RetentionNumberOfSnapshot 2
        $plan.Name | Should -Be $planName
        $plan.RetentionNumberOfSnapshot | Should -Be 2
    }

    It 'UpdateViaIdentityCloudAccountExpanded' {
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $plan = Update-AzCommvaultPlan -CloudAccountInputObject @{ Id = $account.Id } -Name $planName -RetentionNumberOfSnapshot 3
        $plan.Name | Should -Be $planName
        $plan.RetentionNumberOfSnapshot | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
        $existing = Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $planName
        $plan = Update-AzCommvaultPlan -InputObject @{ Id = $existing.Id } -RetentionNumberOfSnapshot 4
        $plan.Name | Should -Be $planName
        $plan.RetentionNumberOfSnapshot | Should -Be 4
    }

    It 'Cleanup' {
        Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $planName
        { Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $planName -ErrorAction Stop } | Should -Throw
    }
}
