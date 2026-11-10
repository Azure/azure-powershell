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
        # Users run Update- without -NoWait: the cmdlet waits for the PATCH (202) and returns the usage plan read from the
        # resource itself (final-state-via: original-uri, feffbf3a05). Assert the returned plan. UpdateViaIdentity covers
        # the -NoWait path, which returns the operation target and is verified by polling the plan.
        function Assert-UsagePlan([object]$Plan, [string]$Value) {
            $Plan.Name | Should -Be $env.usagePlanName
            $Plan.PlanType | Should -Be 'Standard'
            $Plan.ProvisioningState | Should -Be 'Succeeded'
            $Plan.Tag['scenario'] | Should -Be $Value
        }
    }

    It 'UpdateExpanded' {
        $plan = Update-AzResiliencyUsagePlan @planParameters -Tag @{ scenario = 'UpdateExpanded' }
        Assert-UsagePlan $plan 'UpdateExpanded'
    }

    It 'UpdateViaJsonString' {
        $json = @{ tags = @{ scenario = 'UpdateViaJsonString' } } | ConvertTo-Json
        $plan = Update-AzResiliencyUsagePlan @planParameters -JsonString $json
        Assert-UsagePlan $plan 'UpdateViaJsonString'
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'usagePlanUpdate.json'
        @{ tags = @{ scenario = 'UpdateViaJsonFilePath' } } | ConvertTo-Json | Set-Content $jsonFilePath
        $plan = Update-AzResiliencyUsagePlan @planParameters -JsonFilePath $jsonFilePath
        Assert-UsagePlan $plan 'UpdateViaJsonFilePath'
    }

    It 'Update' {
        $plan = Update-AzResiliencyUsagePlan @planParameters -Property @{ Tag = @{ scenario = 'Update' } }
        Assert-UsagePlan $plan 'Update'
    }

    It 'UpdateViaIdentityExpanded' {
        $plan = Update-AzResiliencyUsagePlan -InputObject $identity -Tag @{ scenario = 'UpdateViaIdentityExpanded' }
        Assert-UsagePlan $plan 'UpdateViaIdentityExpanded'
    }

    It 'UpdateViaIdentity' {
        $operation = Update-AzResiliencyUsagePlan -InputObject $identity -Property @{ Tag = @{ scenario = 'UpdateViaIdentity' } } -NoWait
        $operation.Target | Should -Match '/operationStatuses/'
        $plan = Wait-ResiliencySucceeded -Command { Get-AzResiliencyUsagePlan @planParameters } -Until { param($p) $p.Tag['scenario'] -eq 'UpdateViaIdentity' }
        Assert-UsagePlan $plan 'UpdateViaIdentity'
    }
}
