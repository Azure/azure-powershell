if (($null -eq $TestName) -or ($TestName -contains 'ROScenarioHelpers')) {
    . (Join-Path $PSScriptRoot 'ROScenarioHelpers.ps1')
}

Describe 'ROScenarioHelpers' {
    It 'DerivesStableGuidsWithScenarioAndPurposeSeparation' {
        $seed = '65c5cd36-c035-497b-b16a-00208fe6b199'
        $first = Get-ROSeededGuid $seed 'Get.Resource/group'
        $first | Should -Be '03366e46-b0b6-84d3-060d-daf20eddf012'
        $first | Should -Be (Get-ROSeededGuid $seed 'Get.Resource/group')
        $first | Should -Not -Be (Get-ROSeededGuid $seed 'Get.Plan/group')
        $first | Should -Not -Be (Get-ROSeededGuid $seed 'Get.Resource/operation/Readiness')
        ([guid]$first).ToString() | Should -Be $first
    }

    It 'AllocatesTheEntireBatchAndPreservesEveryCachedValue' {
        $env = @{ recoveryServiceGroupName = 'roBCDRAzValidationSG1' }
        $UsePreviousConfigForRecord = $false
        Initialize-ROScenarioRegistry
        $entries = @($env.scenarioRegistry.psobject.Properties.Value)
        $entries.Count | Should -Be 27
        @($entries.PlanName | Select-Object -Unique).Count | Should -Be 27
        @($entries.GroupId | Select-Object -Unique).Count | Should -Be 27
        $operations = @($entries | ForEach-Object { $_.OperationIds.psobject.Properties.Value })
        $operations.Count | Should -Be 297
        @($operations | Select-Object -Unique).Count | Should -Be 297
        foreach ($entry in $entries) {
            $entry.PlanId | Should -Be "/providers/Microsoft.Management/serviceGroups/roBCDRAzValidationSG1/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$($entry.PlanName)"
            $entry.ResumeReason | Should -Match ([regex]::Escape($entry.PlanName))
        }
        $before = $env | ConvertTo-Json -Depth 20 -Compress
        $UsePreviousConfigForRecord = $true
        Initialize-ROScenarioRegistry
        ($env | ConvertTo-Json -Depth 20 -Compress) | Should -Be $before
        (Get-ROScenario 'Get.Resource').PlanName | Should -Match '^ropsrec-[0-9a-f]{16}$'
    }

    It 'FailsClosedForLegacyOrIncompleteIncrementalRegistryWithoutChangingIt' {
        $env = @{ recoveryServiceGroupName = 'roBCDRAzValidationSG1' }
        $UsePreviousConfigForRecord = $true
        { Initialize-ROScenarioRegistry } | Should -Throw 'no batch registry'
        $env.ContainsKey('scenarioSeed') | Should -Be $false
        $UsePreviousConfigForRecord = $false
        Initialize-ROScenarioRegistry
        $env.scenarioRegistry.'Get.Resource'.OperationIds.psobject.Properties.Remove('Readiness')
        $before = $env | ConvertTo-Json -Depth 20 -Compress
        $UsePreviousConfigForRecord = $true
        { Initialize-ROScenarioRegistry } | Should -Throw 'lacks Readiness'
        ($env | ConvertTo-Json -Depth 20 -Compress) | Should -Be $before
        { Get-ROScenario 'NotAllocated' } | Should -Throw 'allocated by setupEnv'
    }

    It 'FreshAttemptChangesOnlyItsSeededScenarioAndIsPersistableBeforeRequests' {
        $env = @{ recoveryServiceGroupName = 'roBCDRAzValidationSG3' }
        $UsePreviousConfigForRecord = $false
        $global:ROValidationPlanOutstanding = $false
        Initialize-ROScenarioRegistry
        $other = $env.scenarioRegistry.'Get.Resource' | ConvertTo-Json -Depth 20 -Compress
        $entry = Get-ROScenario 'Test.Readiness'
        $oldName = $entry.PlanName
        $oldGroup = $entry.GroupId
        $oldOperation = $entry.OperationIds.Readiness
        Renew-ROScenarioFixture 'Test.Readiness'
        $entry.Attempt | Should -Be 1
        $entry.PlanName | Should -Not -Be $oldName
        $entry.GroupId | Should -Not -Be $oldGroup
        $entry.OperationIds.Readiness | Should -Not -Be $oldOperation
        $entry.PlanId | Should -Be "/providers/Microsoft.Management/serviceGroups/roBCDRAzValidationSG3/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$($entry.PlanName)"
        ($env.scenarioRegistry.'Get.Resource' | ConvertTo-Json -Depth 20 -Compress) | Should -Be $other
        $before = $env | ConvertTo-Json -Depth 30 -Compress
        $env.activeScenarioKey = 'Test.Readiness'
        { Renew-ROScenarioFixture 'Test.Readiness' } | Should -Throw 'active scenario'
        $env.activeScenarioKey = $null
        ($env | ConvertTo-Json -Depth 30 -Compress) | Should -Be $before
    }

    It 'AllowsRecordedPlaybackScopeButRejectsCrossGroupLiveRequests' {
        $env = @{ recoveryServiceGroupName = 'roBCDRAzValidationSG3' }
        $UsePreviousConfigForRecord = $false
        Initialize-ROScenarioRegistry
        $env.recoveryServiceGroupName = 'roBCDRAzValidationSG5'
        $TestMode = 'record'
        { Get-ROScenarioGroup 'Get.Resource' } | Should -Throw 'differs from explicitly selected'
        $TestMode = 'playback'
        Get-ROScenarioGroup 'Get.Resource' | Should -Be 'roBCDRAzValidationSG3'
        (Get-ROScenario 'Get.Resource').PlanId | Should -Match '/serviceGroups/roBCDRAzValidationSG3/'
    }
}
