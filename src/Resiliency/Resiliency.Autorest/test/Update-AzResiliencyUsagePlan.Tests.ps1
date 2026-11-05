if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyUsagePlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyUsagePlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyUsagePlan' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; Name = $env.usagePlanName }
        $identity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        # The PATCH is accepted asynchronously (202 with operation-status headers); -NoWait returns that
        # operation and the persisted tags are then verified on the usage plan itself.
        function Assert-UsagePlanTag([object]$Operation, [string]$Value) {
            $Operation.Target | Should -Match '/operationStatuses/'
            $plan = Wait-ResiliencySucceeded -Command { Get-AzResiliencyUsagePlan @planParameters } -Until { param($p) $p.Tag['scenario'] -eq $Value }
            $plan.Name | Should -Be $env.usagePlanName
            $plan.PlanType | Should -Be 'Standard'
            $plan.Tag['scenario'] | Should -Be $Value
        }
    }

    It 'UpdateExpanded' {
        $operation = Update-AzResiliencyUsagePlan @planParameters -Tag @{ scenario = 'UpdateExpanded' } -NoWait
        Assert-UsagePlanTag $operation 'UpdateExpanded'
    }

    It 'UpdateViaJsonString' {
        $json = @{ tags = @{ scenario = 'UpdateViaJsonString' } } | ConvertTo-Json
        $operation = Update-AzResiliencyUsagePlan @planParameters -JsonString $json -NoWait
        Assert-UsagePlanTag $operation 'UpdateViaJsonString'
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'usagePlanUpdate.json'
        @{ tags = @{ scenario = 'UpdateViaJsonFilePath' } } | ConvertTo-Json | Set-Content $jsonFilePath
        $operation = Update-AzResiliencyUsagePlan @planParameters -JsonFilePath $jsonFilePath -NoWait
        Assert-UsagePlanTag $operation 'UpdateViaJsonFilePath'
    }

    It 'Update' {
        $operation = Update-AzResiliencyUsagePlan @planParameters -Property @{ Tag = @{ scenario = 'Update' } } -NoWait
        Assert-UsagePlanTag $operation 'Update'
    }

    It 'UpdateViaIdentityExpanded' {
        $operation = Update-AzResiliencyUsagePlan -InputObject $identity -Tag @{ scenario = 'UpdateViaIdentityExpanded' } -NoWait
        Assert-UsagePlanTag $operation 'UpdateViaIdentityExpanded'
    }

    It 'UpdateViaIdentity' {
        $operation = Update-AzResiliencyUsagePlan -InputObject $identity -Property @{ Tag = @{ scenario = 'UpdateViaIdentity' } } -NoWait
        Assert-UsagePlanTag $operation 'UpdateViaIdentity'
    }
}
