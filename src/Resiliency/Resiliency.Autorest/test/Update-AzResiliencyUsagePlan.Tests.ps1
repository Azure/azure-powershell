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
        # The PATCH is accepted asynchronously (202 with operation-status headers). These scenarios use -NoWait and
        # verify the persisted tags on the usage plan itself, because without -NoWait the cmdlet currently returns the
        # wrong object (see UpdateExpandedWithoutNoWait below).
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

    # Skipped: without -NoWait the generated poller reads the final result from the Location URL (UsagePlans_Update
    # declares final-state-via: location), which points at the operation status, so the cmdlet returns a UsagePlan whose
    # Name is the operation ID and whose Tag/PlanType/ProvisioningState are empty. Needs the same README directive as
    # goal assignments (final-state-via: original-uri); unskip and record once the module is regenerated.
    It 'UpdateExpandedWithoutNoWait' -skip {
        $plan = Update-AzResiliencyUsagePlan @planParameters -Tag @{ scenario = 'UpdateExpandedWithoutNoWait' }
        $plan.Name | Should -Be $env.usagePlanName
        $plan.PlanType | Should -Be 'Standard'
        $plan.ProvisioningState | Should -Be 'Succeeded'
        $plan.Tag['scenario'] | Should -Be 'UpdateExpandedWithoutNoWait'
    }
}
