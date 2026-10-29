if(($null -eq $TestName) -or ($TestName -contains 'New-AzCommvaultPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCommvaultPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Every test creates its own plan and removes it again, so the tests do not depend on each other or on the run order.
Describe 'New-AzCommvaultPlan' {
    BeforeAll {
        $storagePoolId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Commvault.ContentStore/cloudAccounts/$($env.CloudAccountName)/storages/$($env.StorageName)"
        $storagePlan = @{ Name = $env.StorageName; StoragePoolId = $storagePoolId; CopyName = 'Primary Storage'; CopyPrecedence = 0; RetentionPeriod = 15; RetentionTime = 'daily'; BackupRuleType = 'ALL_FULLS'; ExtendedRetention = @() }
        $schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'minutes'; RunsEvery = 30; Time = '' }
        $storagePlanJson = @{ name = $env.StorageName; storagePoolId = $storagePoolId; copyName = 'Primary Storage'; copyPrecedence = 0; retentionPeriod = 15; retentionTime = 'daily'; backupRuleType = 'ALL_FULLS'; extendedRetention = @() }
        $scheduleJson = @{ backupType = 'INCREMENTAL'; frequency = 'minutes'; runsEvery = 30; time = '' }
        $planJson = @{ properties = @{ location = $env.Location; storagePlans = @($storagePlanJson); schedules = @($scheduleJson); retention = @{ numberOfSnapshots = 1 } } } | ConvertTo-Json -Depth 10 -Compress
    }

    It 'CreateExpanded' {
        $name = 'azps-plan-new'
        try {
            $plan = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
            $plan.Name | Should -Be $name
            $plan.ProvisioningState | Should -Be 'Succeeded'
        } finally {
            Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name
        }
    }

    It 'CreateViaJsonString' {
        $name = 'azps-plan-json'
        try {
            $plan = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -JsonString $planJson
            $plan.Name | Should -Be $name
            $plan.ProvisioningState | Should -Be 'Succeeded'
        } finally {
            Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name
        }
    }

    It 'CreateViaJsonFilePath' {
        $name = 'azps-plan-file'
        $jsonFile = Join-Path ([IO.Path]::GetTempPath()) 'azps-commvault-plan.json'
        Set-Content -Path $jsonFile -Value $planJson
        try {
            $plan = New-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -PlanName $name -JsonFilePath $jsonFile
            $plan.Name | Should -Be $name
            $plan.ProvisioningState | Should -Be 'Succeeded'
        } finally {
            Remove-Item -Path $jsonFile -Force -ErrorAction SilentlyContinue
            Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name
        }
    }

    It 'CreateViaIdentityCloudAccountExpanded' {
        $name = 'azps-plan-identity'
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        try {
            $plan = New-AzCommvaultPlan -CloudAccountInputObject @{ Id = $account.Id } -PlanName $name -Location $env.Location -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 1
            $plan.Name | Should -Be $name
            $plan.ProvisioningState | Should -Be 'Succeeded'
        } finally {
            Remove-AzCommvaultPlan -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $name
        }
    }
}
