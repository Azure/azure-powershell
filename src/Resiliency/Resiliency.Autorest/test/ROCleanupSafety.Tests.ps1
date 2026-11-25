# Pure Pester 4 tests: no module import, authentication, env.json, or live Azure requests.
# Definitions are local to each test so discovery cannot shadow native cmdlets in
# unrelated recorder scenarios. Only the maintained helpers beside this file run.
Describe 'ROCleanupSafety' {
    BeforeEach {
        $previousPlanOutstanding = $global:ROValidationPlanOutstanding
        $previousSetupOutstanding = $global:ROValidationSetupOutstanding
        $UsePreviousConfigForRecord = $false
        . (Join-Path $PSScriptRoot 'utils.ps1')
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        function Get-AzResiliencyRecoveryPlan { param($ServiceGroupName, $Name, $ErrorAction) throw 'Unmocked plan read' }
        function New-AzResiliencyRecoveryPlan { param($ServiceGroupName, $Name, $GroupUniqueId, $PlanType, $PlanDescription, $Description, $OrderId, $EnableSystemAssignedIdentity, $ErrorAction) throw 'Unmocked plan creation' }
        function Remove-AzResiliencyRecoveryPlan { [CmdletBinding(SupportsShouldProcess)] param($ServiceGroupName, $Name, [switch]$NoWait) throw 'Unmocked plan deletion' }
        function Invoke-AzRestMethod { param($Method, $Path, $Payload, $ErrorAction) throw 'Unmocked REST request' }
        function Get-AzContext { throw 'Unmocked context read' }
        function Get-AzResiliencyRecoveryJob { param($ServiceGroupName, $RecoveryPlanName, $Name, $ErrorAction) throw 'Unmocked job read' }

        $TestMode = 'playback'
        $env = @{ recoveryServiceGroupName = 'roBCDRAzValidationSG1'; reuseSharedSetup = $true }
        # A fixed local fixture, not a private recorded env or a random live seed.
        # Registry generation itself is covered by ROScenarioHelpers.Tests.ps1.
        $seed = '65c5cd36-c035-497b-b16a-00208fe6b199'
        $registry = [ordered]@{}
        foreach ($key in 'Get.Resource', 'Get.Plan') {
            $name = 'ropsrec-' + (Get-ROSeededGuid $seed "$key/plan").Replace('-', '').Substring(0,16)
            $registry[$key] = [pscustomobject]@{
                PlanName = $name
                PlanId = "/providers/Microsoft.Management/serviceGroups/roBCDRAzValidationSG1/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$name"
                GroupId = Get-ROSeededGuid $seed "$key/group"
                ReaderRoleAssignmentId = Get-ROSeededGuid $seed "$key/reader"
                OperatorRoleAssignmentId = Get-ROSeededGuid $seed "$key/operator"
                AutomationReaderRoleAssignmentId = Get-ROSeededGuid $seed "$key/automation-reader"
            }
        }
        $env.scenarioRegistry = [pscustomobject]$registry
        $entry = Get-ROScenario 'Get.Resource'
        $global:ROValidationPlanOutstanding = $false
        $global:ROValidationSetupOutstanding = $false
        Mock Get-AzResiliencyRecoveryPlan { @() }
        Mock Remove-AzResiliencyRecoveryPlan { }
        Mock New-AzResiliencyRecoveryPlan { throw 'Unexpected New' }
        Mock Invoke-AzRestMethod { throw 'Shared setup mutation forbidden' }
        Mock Get-AzResiliencyRecoveryJob { throw 'Unexpected job read' }
        Mock Save-ROScenarioEnv { }
        Mock Start-TestSleep { }
        Mock Get-AzContext { [pscustomobject]@{ Subscription = @{Id='sub'}; Tenant=@{Id='tenant'} } }
    }

    AfterEach {
        $global:ROValidationPlanOutstanding = $previousPlanOutstanding
        $global:ROValidationSetupOutstanding = $previousSetupOutstanding
    }

    It 'SharedCleanupNeverDeletesGoalMembershipEnrollmentOrServiceGroup' {
        $env.fixtureGoal = 'shared-goal'
        $env.fixtureMembershipPath = '/shared-member'
        cleanupEnv
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $env.fixtureGoal | Should -Be 'shared-goal'
    }

    It 'SharedCleanupRejectsOutstandingOwnedPlanWithoutMutatingSharedState' {
        $global:ROValidationPlanOutstanding = $true
        { cleanupEnv } | Should -Throw 'requires reconciliation'
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $true
    }

    It 'CachedSharedOptInRejectsMissingAndDifferentGroupBeforeAnyMutation' {
        $UsePreviousConfigForRecord = $true
        $env.SubscriptionId = 'sub'
        $env.Tenant = 'tenant'
        $saved = $env:RESILIENCY_TEST_SHARED_SERVICE_GROUP
        try {
            foreach ($value in @('', 'roBCDRAzValidationSG3')) {
                $env:RESILIENCY_TEST_SHARED_SERVICE_GROUP = $value
                { setupEnv } | Should -Throw 'same service group'
            }
            $env.recoveryServiceGroupName | Should -Be 'roBCDRAzValidationSG1'
            Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
            Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        } finally { $env:RESILIENCY_TEST_SHARED_SERVICE_GROUP = $saved }
    }

    It 'RejectsTeardownOfDifferentScenarioAndPreservesOutstandingOwnership' {
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        { Remove-ROScenarioPlan 'Get.Plan' } | Should -Throw 'not owned'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $env.activeScenarioKey | Should -Be 'Get.Resource'
        $global:ROValidationPlanOutstanding | Should -Be $true
    }

    It 'RejectsSameNameWithForeignIdWithoutDeletion' {
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        Mock Get-AzResiliencyRecoveryPlan { [pscustomobject]@{Name=$entry.PlanName;Id='/foreign/plan'} }
        { Remove-ROScenarioPlan 'Get.Resource' } | Should -Throw 'refusing deletion'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $true
    }

    It 'RejectsDuplicateOwnedNamesWithoutDeletion' {
        $env.activeScenarioKey = 'Get.Resource'
        Mock Get-AzResiliencyRecoveryPlan { @(
            [pscustomobject]@{Name=$entry.PlanName;Id=$entry.PlanId}
            [pscustomobject]@{Name=$entry.PlanName;Id=$entry.PlanId}
        ) }
        { Remove-ROScenarioPlan 'Get.Resource' } | Should -Throw 'refusing deletion'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $env.activeScenarioKey | Should -Be 'Get.Resource'
    }

    It 'AbsentOwnedPlanDoesNotDeleteConcurrentCliPlan' {
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        Mock Get-AzResiliencyRecoveryPlan { [pscustomobject]@{Name='rocli-concurrent';Id='/foreign/cli'} }
        Remove-ROScenarioPlan 'Get.Resource'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $env.activeScenarioKey | Should -BeNullOrEmpty
        $global:ROValidationPlanOutstanding | Should -Be $false
        $env.lastScenarioCleanup.Absent | Should -Be $true
        $env.lastScenarioCleanup.PlanId | Should -Be $entry.PlanId
    }

    It 'DeletesOnlyExactOwnedNameAndVerifiesAbsenceBeforeReleasingOwnership' {
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        $script:reads = 0
        Mock Get-AzResiliencyRecoveryPlan {
            $script:reads++
            if ($script:reads -eq 1) { [pscustomobject]@{Name=$entry.PlanName;Id=$entry.PlanId} }
            [pscustomobject]@{Name='rocli-concurrent';Id='/foreign/cli'}
        }
        Remove-ROScenarioPlan 'Get.Resource'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $entry.PlanName -and $ServiceGroupName -eq 'roBCDRAzValidationSG1'
        }
        $global:ROValidationPlanOutstanding | Should -Be $false
        $env.lastScenarioCleanup.PlanId | Should -Be $entry.PlanId
        $script:reads | Should -Be 2
    }

    It 'FailedAbsencePollRetainsOwnershipAndDoesNotDeleteUnrelatedPlan' {
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        Mock Get-AzResiliencyRecoveryPlan { [pscustomobject]@{Name=$entry.PlanName;Id=$entry.PlanId} }
        { Remove-ROScenarioPlan 'Get.Resource' } | Should -Throw 'stop the batch'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $entry.PlanName }
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 49 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $true
        $env.activeScenarioKey | Should -Be 'Get.Resource'
    }

    It 'RejectsNewAtFiveTotalPlansWithoutAnyWrite' {
        Mock Get-AzResiliencyRecoveryPlan { foreach ($i in 1..5) { [pscustomobject]@{Name="rocli-$i";Id="/foreign/$i"} } }
        { New-ROScenarioPlan 'Get.Resource' } | Should -Throw 'No safe owned-plan slot'
        Assert-MockCalled New-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $false
    }

    It 'RejectsOverriddenOwnershipAndOutstandingPlanBeforeAnyWrite' {
        { New-ROScenarioPlan 'Get.Resource' @{Name='shared-plan'} } | Should -Throw 'cannot be overridden'
        $global:ROValidationPlanOutstanding = $true
        { New-ROScenarioPlan 'Get.Resource' } | Should -Throw 'unresolved'
        Assert-MockCalled New-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
    }

    It 'MissingKnownNativeJobCannotBeMistakenForTerminalCleanup' {
        $env.recoveryServiceGroupName = 'roBCDRAzValidationSG3'
        $entry.PlanId = $entry.PlanId.Replace('roBCDRAzValidationSG1','roBCDRAzValidationSG3')
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        $entry | Add-Member -NotePropertyName ProducedJobs -NotePropertyValue ([pscustomobject]@{
            Readiness = "$($entry.PlanId)/recoveryJobs/known-job"
        })
        Mock Get-AzResiliencyRecoveryJob { @() }
        { Wait-ROOwnedJobsTerminal 'Get.Resource' } | Should -Throw 'omitted a known native-produced job'
        Assert-MockCalled Get-AzResiliencyRecoveryJob -Times 1 -Exactly -Scope It
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $true
    }

    It 'ForeignJobPreventsPlanOrRoleCleanup' {
        $env.recoveryServiceGroupName = 'roBCDRAzValidationSG3'
        $entry.PlanId = $entry.PlanId.Replace('roBCDRAzValidationSG1','roBCDRAzValidationSG3')
        $env.activeScenarioKey = 'Get.Resource'
        $global:ROValidationPlanOutstanding = $true
        Mock Get-AzResiliencyRecoveryJob { [pscustomobject]@{Name='foreign-job';Id='/foreign/job';Status='Completed'} }
        { Wait-ROOwnedJobsTerminal 'Get.Resource' } | Should -Throw 'foreign job'
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        $env.activeScenarioKey | Should -Be 'Get.Resource'
    }

    It 'NativeActionErrorsCannotHideBehindAnEmptyCodeOrMessage' {
        foreach ($response in @(
            [pscustomobject]@{Code='NativeError';Message=''},
            [pscustomobject]@{Code='';Message='Native failure'},
            [pscustomobject]@{Code='NativeError';Message='Native failure'}
        )) {
            { Assert-RONoActionError $response } | Should -Throw 'Native action returned'
        }
        Assert-MockCalled Save-ROScenarioEnv -Times 0 -Exactly -Scope It
        $entry.ProducedJobs | Should -BeNullOrEmpty
    }

    It 'MissingNativeJobIdNeverFallsBackOrPersistsASeed' {
        foreach ($response in @($null, [pscustomobject]@{JobId=''}, [pscustomobject]@{Code='Failed'})) {
            { Save-ROProducedJob 'Get.Resource' 'Readiness' $response } | Should -Throw 'omitted JobId'
        }
        Assert-MockCalled Save-ROScenarioEnv -Times 0 -Exactly -Scope It
        $entry.ProducedJobs | Should -BeNullOrEmpty
    }

    It 'ForeignNativeJobIdIsNeverPersistedAsAnOwnedSeed' {
        { Save-ROProducedJob 'Get.Resource' 'Reprotect' ([pscustomobject]@{JobId='/foreign/recoveryJobs/job'}) } |
            Should -Throw 'outside the owned plan'
        Assert-MockCalled Save-ROScenarioEnv -Times 0 -Exactly -Scope It
        $entry.ProducedJobs | Should -BeNullOrEmpty
    }

    It 'ExactJobPollingRejectsDifferentNameAndDifferentIdEvenWhenCompleted' {
        $entry.PlanId = $entry.PlanId.Replace('roBCDRAzValidationSG1','roBCDRAzValidationSG3')
        $env.activeScenarioKey = 'Get.Resource'
        foreach ($returned in @(
            [pscustomobject]@{Name='foreign';Id="$($entry.PlanId)/recoveryJobs/native-job";Status='Completed'},
            [pscustomobject]@{Name='native-job';Id='/foreign/native-job';Status='Completed'}
        )) {
            Mock Get-AzResiliencyRecoveryJob { $returned }
            { Wait-ROExactJob 'Get.Resource' 'native-job' -Attempts 1 } | Should -Throw 'different identity'
        }
        Assert-MockCalled Save-ROScenarioEnv -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $env.activeScenarioKey | Should -Be 'Get.Resource'
    }

    It 'FreshUnresolvedSetupAndPlanNeverMutateResources' {
        $env.reuseSharedSetup = $false
        $global:ROValidationSetupOutstanding = $true
        cleanupEnv
        $global:ROValidationSetupOutstanding = $false
        $global:ROValidationPlanOutstanding = $true
        cleanupEnv
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzResiliencyRecoveryPlan -Times 0 -Exactly -Scope It
        $global:ROValidationPlanOutstanding | Should -Be $true
    }

    It 'RefusesRoleDeletionOutsideSeededOwnedPathsBeforeAnyRequest' {
        $TestMode = 'record'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $assignment = [pscustomobject]@{
            Confirmed=$true; Removed=$false; Path='/foreign/providers/Microsoft.Authorization/roleAssignments/foreign'
            PrincipalId='owned-principal'
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'exact seeded owned paths'
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        $assignment.Removed | Should -Be $false
    }

    It 'UnconfirmedForeignRolePathIsRejectedBeforeAnyRequest' {
        $TestMode = 'record'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $assignment = [pscustomobject]@{
            Confirmed=$false; Removed=$false; Path='/foreign/providers/Microsoft.Authorization/roleAssignments/foreign'
            PrincipalId='owned-principal'
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'exact seeded owned paths'
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
        $assignment.Removed | Should -Be $false
    }

    It 'UnconfirmedSeeded404ReconcilesAbsenceWithoutDeletingAnything' {
        $TestMode = 'record'
        $scope = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/fixture'
        $definition = '/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue ([pscustomobject]@{ResourceId=$scope})
        $path = "$scope/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01"
        $assignment = [pscustomobject]@{
            Confirmed=$false; Removed=$false; Path=$path; PrincipalId='owned-principal'; Definition=$definition; Scope=$scope
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        Mock Invoke-AzRestMethod { [pscustomobject]@{StatusCode=404} } -ParameterFilter { $Method -eq 'GET' }
        Remove-ROOwnedFixtureRoles 'Get.Resource'
        $expectedPath = $path
        Assert-MockCalled Invoke-AzRestMethod -Times 1 -Exactly -Scope It -ParameterFilter { $Method -eq 'GET' -and $Path -eq $expectedPath }
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It -ParameterFilter { $Method -ne 'GET' }
        $assignment.Removed | Should -Be $true
        @($entry.OwnedRoleAssignments).Count | Should -Be 0
    }

    It 'UnconfirmedSeeded200RetainsAmbiguousGrantWithoutDeletion' {
        $TestMode = 'record'
        $scope = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/fixture'
        $definition = '/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue ([pscustomobject]@{ResourceId=$scope})
        $assignment = [pscustomobject]@{
            Confirmed=$false; Removed=$false; PrincipalId='owned-principal'; Definition=$definition; Scope=$scope
            Path="$scope/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01"
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        Mock Invoke-AzRestMethod { [pscustomobject]@{StatusCode=200} } -ParameterFilter { $Method -eq 'GET' }
        { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'never delete an ambiguous assignment'
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It -ParameterFilter { $Method -ne 'GET' }
        $assignment.Removed | Should -Be $false
        @($entry.OwnedRoleAssignments).Count | Should -Be 1
    }

    It 'ChangedRolePrincipalIsNeverDeletedOrMarkedRemoved' {
        $TestMode = 'record'
        $scope = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/fixture'
        $definition = '/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue ([pscustomobject]@{ResourceId=$scope})
        $path = "$scope/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01"
        $assignment = [pscustomobject]@{
            Confirmed=$true; Removed=$false; Path=$path; PrincipalId='owned-principal'; Definition=$definition; Scope=$scope
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        Mock Invoke-AzRestMethod {
            [pscustomobject]@{ StatusCode=200; Content=(@{
                id=$path.Split('?')[0]
                properties=@{principalId='foreign-principal';roleDefinitionId=$definition;scope=$scope}
            } | ConvertTo-Json -Depth 10) }
        } -ParameterFilter { $Method -eq 'GET' }
        { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'Role binding changed'
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It -ParameterFilter { $Method -eq 'DELETE' }
        $assignment.Removed | Should -Be $false
    }

    It 'CachedRoleDefinitionAndScopeCannotBroadenSeededCleanup' {
        $TestMode = 'record'
        $scope = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/fixture'
        $definition = '/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue ([pscustomobject]@{ResourceId=$scope})
        foreach ($changed in @('Definition','Scope')) {
            $assignment = [pscustomobject]@{
                Confirmed=$true; Removed=$false; PrincipalId='owned-principal'; Definition=$definition; Scope=$scope
                Path="$scope/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01"
            }
            $assignment.$changed = '/foreign'
            $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment) -Force
            { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'differs from the seeded'
            $assignment.Removed | Should -Be $false
        }
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It
    }

    It 'ChangedNativeRoleIdDefinitionOrScopeNeverDeletesTheBinding' {
        $TestMode = 'record'
        $scope = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/fixture/providers/Microsoft.Storage/storageAccounts/fixture'
        $definition = '/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7'
        $entry | Add-Member -NotePropertyName PrincipalId -NotePropertyValue 'owned-principal'
        $entry | Add-Member -NotePropertyName StorageMember -NotePropertyValue ([pscustomobject]@{ResourceId=$scope})
        $path = "$scope/providers/Microsoft.Authorization/roleAssignments/$($entry.ReaderRoleAssignmentId)?api-version=2022-04-01"
        $assignment = [pscustomobject]@{
            Confirmed=$true; Removed=$false; Path=$path; PrincipalId='owned-principal'; Definition=$definition; Scope=$scope
        }
        $entry | Add-Member -NotePropertyName OwnedRoleAssignments -NotePropertyValue @($assignment)
        foreach ($changed in @('id','roleDefinitionId','scope')) {
            $native = @{id=$path.Split('?')[0];properties=@{principalId='owned-principal';roleDefinitionId=$definition;scope=$scope}}
            if ($changed -eq 'id') { $native.id = '/foreign' } else { $native.properties.$changed = '/foreign' }
            Mock Invoke-AzRestMethod {
                [pscustomobject]@{StatusCode=200;Content=($native|ConvertTo-Json -Depth 10)}
            } -ParameterFilter { $Method -eq 'GET' }
            { Remove-ROOwnedFixtureRoles 'Get.Resource' } | Should -Throw 'Role binding changed'
            $assignment.Removed | Should -Be $false
        }
        Assert-MockCalled Invoke-AzRestMethod -Times 0 -Exactly -Scope It -ParameterFilter { $Method -eq 'DELETE' }
    }
}
