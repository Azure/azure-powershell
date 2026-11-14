# Pure Pester 4 coverage for the shared acquisition guard and loader/write contract.
Describe 'ROHarnessLifecycle' {
    BeforeEach {
        $previousOutstanding = $global:ROValidationPlanOutstanding
        $previousSetupOutstanding = $global:ROValidationSetupOutstanding
        $UsePreviousConfigForRecord = $false
        . (Join-Path $PSScriptRoot 'utils.ps1')
        function New-AzResiliencyRecoveryPlan { param($ServiceGroupName, $Name, $GroupUniqueId, $ErrorAction) throw 'Unexpected native creation' }
        function Get-AzResiliencyRecoveryPlan { param($ServiceGroupName, $Name, $ErrorAction) throw 'Unexpected native read' }
        $TestMode = 'playback'
        $env = @{
            reuseSharedSetup = $true
            recoveryServiceGroupName = 'roBCDRAzValidationSG8'
            recoveryPlanName = 'ropsrec-0123456789abcdef'
            fixtureGoal = 'borrowed-goal'
            fixtureMembershipPath = '/borrowed/member'
        }
        $fixture = [pscustomobject]@{
            reuseSharedSetup = $true
            recoveryServiceGroupName = $env.recoveryServiceGroupName
            recoveryPlanName = $env.recoveryPlanName
        }
        Mock New-AzResiliencyRecoveryPlan { throw 'Unexpected New' }
        Mock Get-AzResiliencyRecoveryPlan { throw 'Unexpected Get' }
        Mock Set-Content { }
        $global:ROValidationPlanOutstanding = $false
    }

    AfterEach {
        $global:ROValidationPlanOutstanding = $previousOutstanding
        $global:ROValidationSetupOutstanding = $previousSetupOutstanding
    }

    It 'StandaloneCrudCannotAcquireOrClearAnOutstandingRegistryOrGlobalOwner' {
        foreach ($kind in 'registry', 'global') {
            $env.activeScenarioKey = if ($kind -eq 'registry') { 'Invoke.Failover' } else { $null }
            $global:ROValidationPlanOutstanding = $kind -eq 'global'
            $before = $env | ConvertTo-Json -Depth 20 -Compress
            { Start-ROStandalonePlanOwnership $fixture } | Should -Throw 'unresolved'
            ($env | ConvertTo-Json -Depth 20 -Compress) | Should -Be $before
            $global:ROValidationPlanOutstanding | Should -Be ($kind -eq 'global')
        }
        Assert-MockCalled New-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Set-Content -Times 0 -Exactly -Scope It
    }

    It 'CachedStandaloneOwnerBlocksTheCommonGuardAndSharedCleanupAfterProcessRestart' {
        $env.standalonePlanOwnership = [pscustomobject]@{ PlanId = '/owned/pending'; Outstanding = $true }
        { Assert-ROPlanOwnershipAvailable } | Should -Throw 'unresolved'
        { Start-ROStandalonePlanOwnership $fixture } | Should -Throw 'unresolved'
        { cleanupEnv } | Should -Throw 'requires reconciliation'
        $env.standalonePlanOwnership.PlanId | Should -Be '/owned/pending'
        $env.standalonePlanOwnership.Outstanding | Should -Be $true
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Set-Content -Times 0 -Exactly -Scope It
    }

    It 'StandaloneAcquisitionRejectsUnapprovedOrIncompleteFixtureWithoutPersistingOwnership' {
        $TestMode = 'record'
        foreach ($case in @(
            @('reuseSharedSetup', $false),
            @('recoveryServiceGroupName', $null), @('recoveryServiceGroupName', ''), @('recoveryServiceGroupName', ' '),
            @('recoveryPlanName', $null), @('recoveryPlanName', ''), @('recoveryPlanName', ' ')
        )) {
            $invalid = $fixture.psobject.Copy()
            $invalid.($case[0]) = $case[1]
            $before = $env | ConvertTo-Json -Depth 20 -Compress
            { Start-ROStandalonePlanOwnership $invalid } | Should -Throw 'explicitly selected shared fixture'
            ($env | ConvertTo-Json -Depth 20 -Compress) | Should -Be $before
            $global:ROValidationPlanOutstanding | Should -Be $false
        }
        Assert-MockCalled New-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Set-Content -Times 0 -Exactly -Scope It
    }

    It 'StandaloneLifecyclePersistsOnlyItsOwnOwnershipAndRejectsForeignRelease' {
        $TestMode = 'record'
        # loadEnv produces PSCustomObject, while setupEnv initially uses Hashtable.
        $env = [pscustomobject]$env
        Start-ROStandalonePlanOwnership $fixture
        $expected = '/providers/Microsoft.Management/serviceGroups/roBCDRAzValidationSG8/providers/Microsoft.AzureResilienceManagement/recoveryPlans/ropsrec-0123456789abcdef'
        $env.standalonePlanOwnership.PlanId | Should -Be $expected
        $env.standalonePlanOwnership.Outstanding | Should -Be $true
        $global:ROValidationPlanOutstanding | Should -Be $true
        $foreign = [pscustomobject]@{ recoveryServiceGroupName = 'roBCDRAzValidationSG10'; recoveryPlanName = $fixture.recoveryPlanName }
        { Complete-ROStandalonePlanOwnership $foreign } | Should -Throw 'different or unowned'
        $env.standalonePlanOwnership.Outstanding | Should -Be $true
        Assert-MockCalled Set-Content -Times 1 -Exactly -Scope It
        Complete-ROStandalonePlanOwnership $fixture
        $env.standalonePlanOwnership.Outstanding | Should -Be $false
        $global:ROValidationPlanOutstanding | Should -Be $false
        $env.standalonePlanOwnership.PlanId | Should -Be $expected
        $env.fixtureGoal | Should -Be 'borrowed-goal'
        $env.fixtureMembershipPath | Should -Be '/borrowed/member'
        { Complete-ROStandalonePlanOwnership $fixture } | Should -Throw 'different or unowned'
        $env.standalonePlanOwnership.Outstanding | Should -Be $false
        Assert-MockCalled Set-Content -Times 2 -Exactly -Scope It
    }

    It 'RecordAndLivePersistenceUseTheUnchangedLoadersExactModeFilename' {
        $expectedRecordPath = Join-Path $PSScriptRoot 'env.json'
        $expectedLivePath = Join-Path $PSScriptRoot 'localEnv.json'
        foreach ($mode in 'record', 'live') {
            $TestMode = $mode
            Save-ROScenarioEnv
        }
        Assert-MockCalled Set-Content -Times 1 -Exactly -Scope It -ParameterFilter {
            $Path -eq $expectedRecordPath -and
            ($Value | ConvertFrom-Json).fixtureGoal -eq 'borrowed-goal'
        }
        Assert-MockCalled Set-Content -Times 1 -Exactly -Scope It -ParameterFilter {
            $Path -eq $expectedLivePath -and
            ($Value | ConvertFrom-Json).recoveryPlanName -eq 'ropsrec-0123456789abcdef'
        }
        Assert-MockCalled Set-Content -Times 2 -Exactly -Scope It
    }

    It 'PlaybackAndUnknownModesNeverWriteEitherEnvironmentFile' {
        Save-ROScenarioEnv
        foreach ($mode in @($null, 'unknown')) {
            $TestMode = $mode
            { Save-ROScenarioEnv } | Should -Throw 'explicit Record, Live, or Playback'
        }
        $env.fixtureGoal | Should -Be 'borrowed-goal'
        Assert-MockCalled Set-Content -Times 0 -Exactly -Scope It
    }

    It 'ActualUnchangedLoaderReadsRecordAndLiveFilesWithoutPlaybackWrites' {
        $directory = Join-Path $TestDrive 'portable-loader'
        $null = New-Item -Path $directory -ItemType Directory
        Copy-Item (Join-Path $PSScriptRoot 'loadEnv.ps1') $directory
        [IO.File]::WriteAllText((Join-Path $directory 'env.json'), '{"Tenant":"dummy-record","marker":11}')
        [IO.File]::WriteAllText((Join-Path $directory 'localEnv.json'), '{"Tenant":"dummy-live","marker":22}')
        foreach ($case in @(@('record',11,'dummy-record'), @('live',22,'dummy-live'), @('playback',11,'dummy-record'))) {
            $TestMode = $case[0]
            . (Join-Path $directory 'loadEnv.ps1')
            $env.marker | Should -Be $case[1]
            $PSDefaultParameterValues['*:Tenant'] | Should -Be $case[2]
        }
        Assert-MockCalled Set-Content -Times 0 -Exactly -Scope It
    }

    It 'CanonicalStandaloneCrudAcquiresBeforeEnteringAnyTeardown' {
        $tokens = $null
        $errors = $null
        $ast = [Management.Automation.Language.Parser]::ParseFile(
            (Join-Path $PSScriptRoot 'New-AzResiliencyRecoveryPlan.Tests.ps1'), [ref]$tokens, [ref]$errors)
        @($errors).Count | Should -Be 0
        $guards = @($ast.FindAll({
            param($node)
            $node -is [Management.Automation.Language.CommandAst] -and
            $node.GetCommandName() -eq 'Start-ROStandalonePlanOwnership'
        }, $true))
        $guards.Count | Should -Be 1
        $tries = @($ast.FindAll({param($node) $node -is [Management.Automation.Language.TryStatementAst]}, $true))
        $tries.Count | Should -Be 1
        $guards[0].Extent.StartOffset | Should -BeLessThan $tries[0].Extent.StartOffset
        $tries[0].Body.Extent.Text | Should -Match 'New-AzResiliencyRecoveryPlan'
        $tries[0].Finally.Extent.Text | Should -Match 'Complete-ROStandalonePlanOwnership'
    }

    It 'SelectedStorageScopeRejectsForeignUnprotectedAndNonStorageNativeInputs' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $id = '/providers/Microsoft.Management/serviceGroups/roBCDRAzValidationSG8/providers/Microsoft.AzureResilienceManagement/recoveryPlans/ropsrec-0123456789abcdef'
        $env.scenarioRegistry = [pscustomobject]@{ 'Invoke.Failover' = [pscustomobject]@{
            PlanId = $id; PlanName = 'ropsrec-0123456789abcdef'; GroupId = '00000000-0000-0000-0000-000000000005'
        } }
        $valid = @{
            Name = 'storage-member'
            UniqueId = '00000000-0000-0000-0000-000000000004'
            Id = "$id/recoveryResources/storage-member"
            ResourceId = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/storage'
            InclusionState = 'Included'
            ProtectionStatus = 'Protected'
            AssociatedIdentityType = 'SystemAssigned'
        }
        { Assert-ROSelectedStorage 'Invoke.Failover' ([pscustomobject]$valid) } | Should -Not -Throw
        foreach ($case in @(
            @('Name',$null), @('UniqueId',$null), @('Id','/foreign/resource'),
            @('ResourceId','/providers/Microsoft.Compute/virtualMachines/foreign'),
            @('InclusionState','Excluded'), @('ProtectionStatus','NotProtected'),
            @('AssociatedIdentityType','None')
        )) {
            $invalid = $valid.Clone()
            $invalid[$case[0]] = $case[1]
            { Assert-ROSelectedStorage 'Invoke.Failover' ([pscustomobject]$invalid) } | Should -Throw 'exact native included protected'
        }
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
    }

    It 'SelectedResourceFixtureAuthorizesOwnedIdentityBeforeProtectionAndPreservesLegacyOrder' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $env.fixtureAutomationAccountId = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Automation/automationAccounts/fixture'
        $env.fixtureRunbookId = "$($env.fixtureAutomationAccountId)/runbooks/noop"
        $env.scenarioRegistry = [pscustomobject]@{ 'Invoke.Failover' = [pscustomobject]@{
            PlanId = '/owned/plan'; PlanName = 'ropsrec-0123456789abcdef'; GroupId = '00000000-0000-0000-0000-000000000005'
        } }
        $sequence = [Collections.Generic.List[string]]::new()
        $resource = [pscustomobject]@{ Name='native-storage'; Id='/owned/resource' }
        Mock New-ROScenarioPlan { $sequence.Add('new'); [pscustomobject]@{ PlanType='Zonal' } }
        Mock Get-ROOwnedStorage { $sequence.Add('inventory'); $resource }
        Mock Add-ROOwnedFixtureRoles { $sequence.Add('roles') }
        Mock Set-ROOwnedProtection { $sequence.Add('protection'); $resource }
        $before = Initialize-ROOperationScenario 'Invoke.Failover' -AuthorizeBeforeProtection
        ($sequence -join ',') | Should -Be 'new,inventory,roles,protection'
        $before.Name | Should -Be 'native-storage'
        $env.scenarioRegistry.'Invoke.Failover'.PlanType | Should -Be 'Zonal'
        $sequence.Clear()
        $legacy = Initialize-ROOperationScenario 'Invoke.Failover'
        ($sequence -join ',') | Should -Be 'new,inventory,protection,roles'
        $legacy.Id | Should -Be '/owned/resource'
        Assert-MockCalled Add-ROOwnedFixtureRoles -Times 2 -Exactly -Scope It
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
    }
}
