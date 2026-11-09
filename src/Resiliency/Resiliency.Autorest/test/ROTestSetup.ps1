# Recovery-plan scenarios borrow explicitly approved fixtures; unrelated setup stays unchanged.
$global:ROValidationPlanOutstanding = $false
$global:ROValidationSetupOutstanding = $false
. (Join-Path $PSScriptRoot 'ROScenarioHelpers.ps1')

function Set-ROValidationPlanOutstanding([bool]$Outstanding) {
    $global:ROValidationPlanOutstanding = $Outstanding
}

function Get-ROScenarioEnvironment([string]$Directory) {
    $fileName = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    Get-Content (Join-Path $Directory $fileName) -Raw | ConvertFrom-Json
}

function setupEnv {
    if ($UsePreviousConfigForRecord -and $env.reuseSharedSetup -and
        $env:RESILIENCY_TEST_SHARED_SERVICE_GROUP -ne $env.recoveryServiceGroupName) {
        throw 'Reusing a saved shared setup requires explicit opt-in to the same service group.'
    }
    $names = @(
        'Get-AzResiliencyRecoveryPlan', 'New-AzResiliencyRecoveryPlan',
        'Update-AzResiliencyRecoveryPlan', 'Get-AzResiliencyRecoveryResource',
        'Get-AzResiliencyRecoveryJob', 'Get-AzResiliencyRecoveryJobResource',
        'Update-AzResiliencyRecoveryPlanResource', 'Test-AzResiliencyRecoveryPlanReadiness',
        'Test-AzResiliencyRecoveryPlanOperationValidation', 'Test-AzResiliencyRecoveryPlanReprotectValidation',
        'Invoke-AzResiliencyRecoveryPlanReprotect', 'Invoke-AzResiliencyRecoveryJobRetry',
        'Invoke-AzResiliencyRecoveryPlanFailover', 'Resume-AzResiliencyRecoveryJob',
        'Invoke-AzResiliencyRecoveryPlanFinalize', 'Test-AzResiliencyRecoveryPlanFailoverValidation',
        'Remove-AzResiliencyRecoveryPlan'
    )
    $selected = @($TestName | Where-Object { $_ -in $names })
    if ($selected.Count -eq 0) {
        if (-not $TestName) { throw 'Select explicit Describe names before recording; shared recovery fixtures require their own setup.' }
        setupResiliencyEnv
        return
    }
    if ($selected.Count -ne $TestName.Count) { throw 'Record recovery-plan scenarios separately from unrelated area fixtures.' }
    $independentEnvironments = @{
        'Invoke-AzResiliencyRecoveryPlanFailover' = 'Failover'
        'Resume-AzResiliencyRecoveryJob' = 'Resume'
        'Invoke-AzResiliencyRecoveryPlanFinalize' = 'Finalize'
        'Test-AzResiliencyRecoveryPlanFailoverValidation' = 'FailoverValidation'
        'Remove-AzResiliencyRecoveryPlan' = 'Remove'
    }
    $independent = @($selected | Where-Object { $independentEnvironments.ContainsKey($_) })
    if ($independent.Count -and $selected.Count -ne 1) {
        throw 'Record this operation separately to preserve its independent environment provenance.'
    }
    Assert-ROPlanOwnershipAvailable
    if ([string]::IsNullOrWhiteSpace($env:RESILIENCY_TEST_SHARED_SERVICE_GROUP)) {
        throw 'Set RESILIENCY_TEST_SHARED_SERVICE_GROUP to the explicitly approved borrowed service group.'
    }
    $context = Get-AzContext
    if ($UsePreviousConfigForRecord -and
        ($env.SubscriptionId -ne $context.Subscription.Id -or $env.Tenant -ne $context.Tenant.Id)) {
        throw 'Previous fixture configuration does not match the authenticated subscription and tenant.'
    }
    $env.SubscriptionId = $context.Subscription.Id
    $env.Tenant = $context.Tenant.Id
    $env.reuseSharedSetup = $true
    $env.recoveryServiceGroupName = $env:RESILIENCY_TEST_SHARED_SERVICE_GROUP
    $kind = if ($independent.Count) { $independentEnvironments[$independent[0]] } else { 'Historical' }
    $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot "RecoveryPlans\$kind"
    Initialize-ROScenarioRegistry
    if ($env:RESILIENCY_RECORD_FRESH_SCENARIO) {
        foreach ($freshKey in $env:RESILIENCY_RECORD_FRESH_SCENARIO.Split(',')) {
            Renew-ROScenarioFixture -Key $freshKey.Trim()
        }
    }
    $env.recoveryPlanName = $env.scenarioRegistry.'New.SharedCrud'.PlanName
    $env.recoveryGroupId = $env.scenarioRegistry.'New.SharedCrud'.GroupId
    $env.operationId = $env.scenarioRegistry.'New.SharedCrud'.OperationIds.Readiness
    $plans = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName -ErrorAction Stop)
    if ($plans.Count -ge 5) { throw 'The shared service group has no free recovery-plan slots.' }
    if (@($plans | Where-Object Name -Like 'ropsrec-*').Count -ne 0) {
        throw 'A recovery-plan fixture already exists; reconcile before recording another scenario.'
    }
    Initialize-ROPublishedScenarioFixtures
    Save-ROScenarioEnv
}

function cleanupEnv {
    if ($env.reuseSharedSetup) {
        if ($global:ROValidationPlanOutstanding -or $env.activeScenarioKey -or $env.standalonePlanOwnership.Outstanding) {
            throw "Owned plan $($env.recoveryPlanName) requires reconciliation; shared setup was preserved."
        }
        return
    }
    cleanupResiliencyEnv
}

# Called by setupEnv only. Authoring/importing utils never changes the saved environment.
function Initialize-ROPublishedScenarioFixtures {
    if ($TestMode -in @('live', 'record')) {
        Assert-ROPlanOwnershipAvailable
        if (-not $env:RESILIENCY_CUSTOM_RUNBOOK_FIXTURE) { throw 'Supply the explicitly approved live runbook fixture manifest.' }
        $fixture = Get-Content -LiteralPath $env:RESILIENCY_CUSTOM_RUNBOOK_FIXTURE -Raw | ConvertFrom-Json
        if ($fixture.client -ne 'ps' -or $fixture.status -ne 'ReadyForServiceGroupOnboarding' -or
            $fixture.subscriptionId -ne $env.SubscriptionId -or $fixture.tenantId -ne $env.Tenant -or
            $fixture.automationAccountId -notmatch '^/subscriptions/([^/]+)/resourceGroups/[^/]+/providers/Microsoft.Automation/automationAccounts/[^/]+$' -or
            $Matches[1] -ne $env.SubscriptionId -or
            $fixture.noOpRunbookId -notmatch ('^' + [regex]::Escape($fixture.automationAccountId) + '/runbooks/[a-zA-Z0-9_-]+$')) {
            throw 'Explicit live fixture must contain an approved no-op in its same-primary-subscription Automation Account and tenant.'
        }
        if ($fixture.intentionalFailureRunbookId -and (
            $fixture.intentionalFailureRunbookId -eq $fixture.noOpRunbookId -or
            $fixture.intentionalFailureRunbookId -notmatch ('^' + [regex]::Escape($fixture.automationAccountId) + '/runbooks/[a-zA-Z0-9_-]+$'))) {
            throw 'Intentional-failure fixture must be distinct from the no-op and belong to the approved Automation Account.'
        }
        $values = @{
            fixtureAutomationAccountId = $fixture.automationAccountId
            fixtureRunbookSubscriptionId = $fixture.subscriptionId
            fixtureRunbookId = $fixture.noOpRunbookId
            fixtureFailureRunbookId = $fixture.intentionalFailureRunbookId
            fixtureStorageAccountId = $fixture.storageAccountId
        }
        foreach ($name in $values.Keys) {
            if ($env -is [System.Collections.IDictionary]) { $env[$name] = $values[$name] }
            else { $env | Add-Member -NotePropertyName $name -NotePropertyValue $values[$name] -Force }
        }
        return
    }
    if ($TestMode -ne 'playback') { throw 'Published fixture initialization requires an explicit Live, Record, or Playback mode.' }
    if (-not $env.fixtureAutomationAccountId -or -not $env.fixtureRunbookSubscriptionId -or
        -not $env.fixtureRunbookId -or -not $env.fixtureFailureRunbookId) {
        if (-not $env:RESILIENCY_CUSTOM_RUNBOOK_FIXTURE) { throw 'Supply the approved published runbook fixture manifest.' }
        $fixture = Get-Content -LiteralPath $env:RESILIENCY_CUSTOM_RUNBOOK_FIXTURE -Raw | ConvertFrom-Json
        if ($fixture.status -ne 'ReadyForServiceGroupOnboarding') { throw 'Runbook fixture prerequisites are not marked ready.' }
        $defaults = @{
            fixtureAutomationAccountId = $fixture.automationAccountId
            fixtureRunbookSubscriptionId = $fixture.subscriptionId
            fixtureRunbookId = $fixture.noOpRunbookId
            fixtureFailureRunbookId = $fixture.intentionalFailureRunbookId
        }
        foreach ($name in $defaults.Keys) {
            if (-not $env[$name]) { $env[$name] = $defaults[$name] }
        }
    }
    if ($env.fixtureAutomationAccountId -notmatch '^/subscriptions/([^/]+)/resourceGroups/[^/]+/providers/Microsoft.Automation/automationAccounts/[^/]+$' -or
        $Matches[1] -ne $env.fixtureRunbookSubscriptionId -or
        $env.fixtureRunbookId -ne "$($env.fixtureAutomationAccountId)/runbooks/ro-validation-noop" -or
        $env.fixtureFailureRunbookId -ne "$($env.fixtureAutomationAccountId)/runbooks/ro-validation-failure") {
        throw 'Saved published fixture IDs are inconsistent; preserve env and reconcile instead of overwriting.'
    }
}
