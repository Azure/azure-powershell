if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCommvaultPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCommvaultPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Every test creates the plan it removes, so the tests do not depend on each other or on the run order.
Describe 'Remove-AzCommvaultPlan' {
    BeforeAll {
        $storagePoolId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Commvault.ContentStore/cloudAccounts/$($env.CloudAccountName)/storages/$($env.StorageName)"
        $storagePlan = @{ Name = $env.StorageName; StoragePoolId = $storagePoolId; CopyName = 'Primary Storage'; CopyPrecedence = 0; RetentionPeriod = 15; RetentionTime = 'daily'; BackupRuleType = 'ALL_FULLS'; ExtendedRetention = @() }
        $schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'minutes'; RunsEvery = 30; Time = '' }
    }

    It 'Delete' {
        $name = 'azps-plan-delete'
        $null = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
        Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name -PassThru | Should -BeTrue
        { Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityCloudAccount' {
        $name = 'azps-plan-delete-ca'
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $null = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
        Remove-AzCommvaultPlan -CloudAccountInputObject @{ Id = $account.Id } -Name $name -PassThru | Should -BeTrue
        { Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $name = 'azps-plan-delete-id'
        $plan = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
        Remove-AzCommvaultPlan -InputObject @{ Id = $plan.Id } -PassThru | Should -BeTrue
        { Get-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name -ErrorAction Stop } | Should -Throw
    }
}
