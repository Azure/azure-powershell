function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function Get-EdgeActionTestFixturePrefixes {
    @{
    'Deploy-AzEdgeActionVersionCode' = 'eadeploy'
    'Get-AzEdgeAction' = 'eaget'
    'Get-AzEdgeActionExecutionFilter' = 'eagetfilter'
    'Get-AzEdgeActionVersion' = 'eagetver'
    'Get-AzEdgeActionVersionCode' = 'eagetcode'
    'New-AzEdgeAction' = 'eanew'
    'New-AzEdgeActionExecutionFilter' = 'eanewfilter'
    'New-AzEdgeActionVersion' = 'eanewver'
    'Remove-AzEdgeAction' = 'eadelete'
    'Remove-AzEdgeActionExecutionFilter' = 'eadeletefilter'
    'Remove-AzEdgeActionVersion' = 'eadeletever'
    'Switch-AzEdgeActionVersionDefault' = 'easwap'
    'Update-AzEdgeAction' = 'eaupdate'
    'Update-AzEdgeActionVersion' = 'eaupdatever'
    'Update-AzEdgeActionExecutionFilter' = 'eaupdatefilter'
    }
}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    $script:edgeActionEnvironmentStarted = $false
    if ($TestMode -eq 'playback') { return }
    $prefixes = Get-EdgeActionTestFixturePrefixes
    foreach ($file in 'env.json', 'localEnv.json') {
        $path = Join-Path $PSScriptRoot $file
        if (Test-Path $path) {
            $previous = Get-Content $path -Raw | ConvertFrom-Json
            if ($previous.ResourceGroupState -in 'Creating', 'Created') {
                throw "An unfinished EdgeAction resource group remains in '$path'. Recover that exact group before starting another run; environment state was not overwritten."
            }
            foreach ($scenario in $prefixes.Keys) {
                if ($previous.EdgeActionFixtures.$scenario.State -in 'Creating', 'Created') {
                    throw "Unfinished EdgeAction fixtures remain in '$path'. Inspect and clean those exact resources before starting another run; environment state was not overwritten."
                }
            }
        }
    }
    $context = Get-AzContext
    if (-not $context.Subscription.Id -or -not $context.Tenant.Id -or -not $context.Environment.Name) {
        throw 'Authenticate to the authorized test subscription and environment before Record/Live.'
    }
    $env.SubscriptionId = $context.Subscription.Id
    $env.Tenant = $context.Tenant.Id
    $env.EnvironmentName = $context.Environment.Name
    $env.ResourceGroupName = 'rgps-powershellsdk-edgeaction-tests-' + [guid]::NewGuid().ToString('N').Substring(0, 12)
    $env.ResourceGroupLocation = 'westus'
    if ($env:EDGEACTION_TEST_RESOURCE_GROUP_LOCATION) {
        $env.ResourceGroupLocation = $env:EDGEACTION_TEST_RESOURCE_GROUP_LOCATION
    }
    $env.ResourceGroupState = 'NotCreated'
    $env.EdgeActionFixtures = @{}
    foreach ($scenario in $prefixes.Keys) {
        $env.EdgeActionFixtures[$scenario] = @{
            Name = $prefixes[$scenario] + [guid]::NewGuid().ToString('N').Substring(0, 12)
            State = 'NotCreated'
        }
    }
    Save-EdgeActionTestEnvironment
    $script:edgeActionEnvironmentStarted = $true
    $parameters = @{ Name = $env.ResourceGroupName; SubscriptionId = $env.SubscriptionId }
    $existing = Invoke-EdgeActionTestCommand 'Get-AzResourceGroup' $parameters "resource group '$($env.ResourceGroupName)'" -AllowNotFound -WithoutRecorder
    if (-not $existing.NotFound) {
        throw "Resource group '$($env.ResourceGroupName)' already exists. It was not modified or deleted; choose a new run."
    }
    $env.ResourceGroupState = 'Creating'
    Save-EdgeActionTestEnvironment
    $parameters.Location = $env.ResourceGroupLocation
    $null = Invoke-EdgeActionTestCommand 'New-AzResourceGroup' $parameters "resource group '$($env.ResourceGroupName)'" -WithoutRecorder
    $env.ResourceGroupState = 'Created'
    Save-EdgeActionTestEnvironment
}
function cleanupEnv() {
    if ($TestMode -eq 'playback' -or -not $script:edgeActionEnvironmentStarted) { return }
    $file = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    # Scenario loadEnv scripts use separate objects; reload their latest persisted state.
    $env = Get-Content (Join-Path $PSScriptRoot $file) -Raw -ErrorAction Stop | ConvertFrom-Json -ErrorAction Stop
    Remove-EdgeActionTestResourceGroup
    if ($env.ResourceGroupState -eq 'Cleaned') { Complete-EdgeActionTestRecording }
}

function Save-EdgeActionTestEnvironment {
    if ($TestMode -eq 'playback') { return }
    if ($TestMode -notin 'record', 'live') { throw 'An explicit Record or Live mode is required to save fixture state.' }
    $file = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    $path = Join-Path $PSScriptRoot $file
    $temporaryPath = "$path.tmp"
    $env | ConvertTo-Json -Depth 10 | Set-Content $temporaryPath -Encoding UTF8 -ErrorAction Stop
    Move-Item $temporaryPath $path -Force -ErrorAction Stop
}

function Get-EdgeActionTestFixtureName {
    param([string]$Scenario)
    $prefixes = Get-EdgeActionTestFixturePrefixes
    if (-not $prefixes.ContainsKey($Scenario) -or -not $env.EdgeActionFixtures.$Scenario.Name) {
        throw "Missing randomized fixture for '$Scenario'. Record all scenario groups with the current utils.ps1 and review the matching env.json before Playback."
    }
    $fixture = $env.EdgeActionFixtures.$Scenario
    if ($TestMode -eq 'playback') { $fixture.State = 'NotCreated' }
    $fixture.Name
}

function Resume-EdgeActionTestCleanup {
    [CmdletBinding(DefaultParameterSetName = 'Fixture', SupportsShouldProcess, ConfirmImpact = 'High')]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('record', 'live')]
        [string]$Mode,
        [Parameter(Mandatory = $true, ParameterSetName = 'Fixture')]
        [string]$Name,
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceGroup')]
        [switch]$ResourceGroup
    )
    $TestMode = $Mode
    $file = if ($Mode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    $path = Join-Path $PSScriptRoot $file
    $env = Get-Content $path -Raw -ErrorAction Stop | ConvertFrom-Json -ErrorAction Stop
    if ($ResourceGroup) {
        if ($env.ResourceGroupState -eq 'Cleaned' -and $env.ResourceGroupName -ceq 'powershellsdk-edgeaction-tests-rgname') { return }
        Assert-EdgeActionTestResourceGroup
        if ($PSCmdlet.ShouldProcess($env.ResourceGroupName, 'Delete the saved run-owned resource group and its remaining resources')) {
            Remove-EdgeActionTestResourceGroup
            if ($env.ResourceGroupState -eq 'Cleaned') { Complete-EdgeActionTestRecording }
        }
        return
    }
    $fixture = Assert-EdgeActionTestFixture $env.ResourceGroupName $Name
    if (-not $PSCmdlet.ShouldProcess($Name, "Recover this saved EdgeAction fixture in '$($env.ResourceGroupName)'")) { return }
    if ($fixture.State -eq 'Creating') {
        $parent = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' @{
            ResourceGroupName = $env.ResourceGroupName; Name = $Name
        } "parent '$Name'" -AllowNotFound
        if (-not $parent.NotFound) {
            throw "Fixture '$Name' exists but creation was not confirmed. Verify ownership and perform manual cleanup before marking its saved state Cleaned."
        }
        $fixture.State = 'Cleaned'
        Save-EdgeActionTestEnvironment
        return
    }
    Remove-EdgeActionTestResource $env.ResourceGroupName $Name
}

function Assert-EdgeActionTestResourceGroup {
    if ($TestMode -eq 'playback' -and $env.ResourceGroupName -ceq 'powershellsdk-edgeaction-tests-rgname') { return }
    if (-not $env.ResourceGroupName -or $env.ResourceGroupName -cnotmatch '^rgps-powershellsdk-edgeaction-tests-[0-9a-f]{12}$') {
        throw 'Fixture operations are restricted to the run-owned EdgeAction resource group saved in the environment file.'
    }
    if ($TestMode -ne 'playback') {
        if ($TestMode -notin 'record', 'live') { throw 'An explicit test mode is required before fixture operations.' }
        $context = Get-AzContext
        if (-not $env.SubscriptionId -or -not $env.Tenant -or -not $env.EnvironmentName -or
            $context.Subscription.Id -ne $env.SubscriptionId -or $context.Tenant.Id -ne $env.Tenant -or
            $context.Environment.Name -ne $env.EnvironmentName) {
            throw 'The Azure context does not match the saved fixture subscription, tenant, and environment. No fixture operation was attempted.'
        }
    }
}

function Remove-EdgeActionTestResourceGroup {
    if ($TestMode -eq 'playback') { return }
    if ($env.ResourceGroupState -eq 'Cleaned') { return }
    Assert-EdgeActionTestResourceGroup
    if ($env.ResourceGroupState -in 'NotCreated', 'Cleaned') { return }
    if ($env.ResourceGroupState -notin 'Creating', 'Created') {
        throw 'The saved resource-group ownership state is missing or invalid; no deletion was attempted.'
    }
    $parameters = @{ Name = $env.ResourceGroupName; SubscriptionId = $env.SubscriptionId }
    $resource = "resource group '$($env.ResourceGroupName)'"
    $existing = Invoke-EdgeActionTestCommand 'Get-AzResourceGroup' $parameters $resource -AllowNotFound -WithoutRecorder
    if (-not $existing.NotFound) {
        if ($env.ResourceGroupState -ne 'Created') {
            throw "Creation of $resource was not confirmed. Verify ownership and perform manual recovery; no deletion was attempted."
        }
        $deleteParameters = $parameters.Clone()
        $deleteParameters.Confirm = $false
        $null = Invoke-EdgeActionTestCommand 'Remove-AzResourceGroup' $deleteParameters $resource -AllowNotFound -WithoutRecorder
        $remaining = Invoke-EdgeActionTestCommand 'Get-AzResourceGroup' $parameters $resource -AllowNotFound -WithoutRecorder
        if (-not $remaining.NotFound) { throw "Cleanup failed: $resource still exists after deletion completed." }
    }
    $env.ResourceGroupState = 'Cleaned'
    foreach ($scenario in (Get-EdgeActionTestFixturePrefixes).Keys) {
        if ($env.EdgeActionFixtures.$scenario) { $env.EdgeActionFixtures.$scenario.State = 'Cleaned' }
    }
    Save-EdgeActionTestEnvironment
}

function Complete-EdgeActionTestRecording {
    if ($TestMode -ne 'record') { return }
    if ($env.ResourceGroupState -ne 'Cleaned') {
        throw 'Verify resource-group cleanup before replacing the live name in recordings and environment metadata.'
    }
    $placeholder = 'powershellsdk-edgeaction-tests-rgname'
    if ($env.ResourceGroupName -ceq $placeholder) { return }
    Assert-EdgeActionTestResourceGroup
    $pattern = [regex]::Escape($env.ResourceGroupName)
    $updates = @(
        foreach ($file in Get-ChildItem -LiteralPath $PSScriptRoot -Filter '*.Recording.json' -File) {
            $text = [System.IO.File]::ReadAllText($file.FullName)
            if ($text -notmatch $pattern) { continue }
            if ($text -match [regex]::Escape($placeholder)) {
                throw "Recording '$($file.Name)' mixes live and placeholder resource-group names; review it before normalization."
            }
            $updated = [regex]::Replace($text, $pattern, $placeholder, [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
            $null = ConvertFrom-Json -InputObject $updated -ErrorAction Stop
            @{ Path = $file.FullName; Content = $updated }
        }
    )
    foreach ($update in $updates) {
        $temporaryPath = "$($update.Path).tmp"
        [System.IO.File]::WriteAllText($temporaryPath, $update.Content, [System.Text.UTF8Encoding]::new($false))
        Move-Item -LiteralPath $temporaryPath -Destination $update.Path -Force -ErrorAction Stop
    }
    # Keep the live name recoverable on disk until every recording has been normalized.
    $env.ResourceGroupName = $placeholder
    Save-EdgeActionTestEnvironment
}

function Invoke-EdgeActionTestCommand {
    param(
        [string]$Command,
        [hashtable]$Parameters,
        [string]$Resource,
        [switch]$AllowNotFound,
        [switch]$WithoutRecorder
    )

    # Generated cmdlets can discard HTTP status when converting a service error to ErrorRecord.
    # Observe outside the recorder so live and playback responses use the same 404 check.
    if (-not ('EdgeActionTestResponse' -as [type])) {
        Add-Type -TypeDefinition @'
using System.Net.Http;
using System.Threading.Tasks;
public sealed class EdgeActionTestResponse {
    public int? StatusCode { get; private set; }
    public string ErrorBody { get; private set; }
    public async Task<HttpResponseMessage> Observe(Task<HttpResponseMessage> pending) {
        var response = await pending.ConfigureAwait(false);
        StatusCode = (int)response.StatusCode;
        ErrorBody = StatusCode >= 400 && response.Content != null
            ? await response.Content.ReadAsStringAsync().ConfigureAwait(false) : null;
        return response;
    }
}
'@
    }
    $observation = New-Object EdgeActionTestResponse
    $observer = {
        param($request, $eventListener, $next)
        $observation.Observe($next.SendAsync($request, $eventListener))
    }.GetNewClosure()
    $arguments = $Parameters.Clone()
    # Prepend installs the last step outermost. Keep the existing recorder inside our observer.
    $arguments.HttpPipelinePrepend = @()
    if (-not $WithoutRecorder) {
        $arguments.HttpPipelinePrepend = @($PSDefaultParameterValues['*:HttpPipelinePrepend']) |
            Where-Object { $null -ne $_ }
    }
    $arguments.HttpPipelinePrepend = @($arguments.HttpPipelinePrepend) + $observer
    $arguments.ErrorAction = 'Stop'
    try {
        $value = & $Command @arguments
        if ($null -eq $observation.StatusCode) {
            throw 'No HTTP response was observed; resource state could not be verified.'
        }
        return @{ NotFound = $false; Value = $value }
    } catch {
        if ($AllowNotFound -and $observation.StatusCode -eq 404) {
            return @{ NotFound = $true; Value = $null }
        }
        $reason = $_.Exception.Message
        if ($observation.ErrorBody) {
            try {
                $serviceError = $observation.ErrorBody | ConvertFrom-Json -ErrorAction Stop
                if ($serviceError.error) { $serviceError = $serviceError.error }
                if ($serviceError.message) { $reason = [string]$serviceError.message }
            } catch {
                $reason = 'The service returned a non-JSON error response; response body withheld.'
            }
        }
        $reason = $reason -replace 'https?://[^\s"''<>]+', '[URL redacted]' `
            -replace '(?i)/subscriptions/[^\s"''<>]+', '[resource ID redacted]' `
            -replace '(?i)[0-9a-f]{8}(?:-[0-9a-f]{4}){3}-[0-9a-f]{12}', '[ID redacted]' `
            -replace '''[^'']*''|"[^"]*"', '[quoted value redacted]' `
            -replace '(?i)(token|secret|password|authorization|sig)\s*[:=]\s*\S+', '$1=[redacted]'
        $status = if ($null -ne $observation.StatusCode) { "HTTP $($observation.StatusCode)" } else { 'no HTTP status' }
        throw "EdgeAction fixture operation '$Command' failed for $Resource ($status): $reason"
    }
}

function Assert-EdgeActionTestFixture {
    param([string]$ResourceGroupName, [string]$Name)
    $prefixes = Get-EdgeActionTestFixturePrefixes
    $fixtures = @(
        foreach ($scenario in $prefixes.Keys) {
            $fixture = $env.EdgeActionFixtures.$scenario
            if ($Name -and $fixture.Name -ceq $Name -and $Name -cmatch ('^' + $prefixes[$scenario] + '[0-9a-f]{12}$')) {
                $fixture
            }
        }
    )
    if ($ResourceGroupName -cne $env.ResourceGroupName -or $fixtures.Count -ne 1) {
        throw 'Fixture operations are restricted to the randomized names and resource group saved for this run.'
    }
    Assert-EdgeActionTestResourceGroup
    $fixtures[0]
}

function Initialize-EdgeActionTestScenario {
    param([scriptblock]$Setup)
    $script:edgeActionSetupFailure = $null
    $script:resourceGroupName = $null
    $script:edgeActionName = $null
    # AutoRest resets request counters for each It, including skipped cases.
    # Separate hook contexts prevent teardown from overwriting setup recordings.
    $recorder = $PSDefaultParameterValues['*:HttpPipelinePrepend']
    if ($recorder) { $recorder.PushContext('EdgeActionFixtureSetup') }
    try { & $Setup } catch {
        $script:edgeActionSetupFailure = $_
        throw
    } finally {
        if ($recorder) { $recorder.PopContext() }
    }
}

function Complete-EdgeActionTestScenario {
    param([string]$ResourceGroupName, [string]$Name)
    if (-not $Name -and $script:edgeActionSetupFailure) { return }
    $recorder = $PSDefaultParameterValues['*:HttpPipelinePrepend']
    if ($recorder) { $recorder.PushContext('EdgeActionFixtureCleanup') }
    try { Remove-EdgeActionTestResource $ResourceGroupName $Name } catch {
        # Pester 4 otherwise replaces a BeforeAll failure with the AfterAll exception.
        if ($script:edgeActionSetupFailure) {
            throw "Setup failed: $($script:edgeActionSetupFailure.Exception.Message)`nCleanup also failed: $($_.Exception.Message)"
        }
        throw
    } finally {
        if ($recorder) { $recorder.PopContext() }
    }
}

function Remove-EdgeActionTestResource {
    param([string]$ResourceGroupName, [string]$Name)
    $fixture = Assert-EdgeActionTestFixture $ResourceGroupName $Name
    if ($fixture.State -in 'NotCreated', 'Cleaned') { return }
    if ($fixture.State -ne 'Created') {
        throw "Creation of fixture '$Name' was not confirmed. Inspect the saved environment and the exact resource before manual recovery; no deletion was attempted."
    }
    $parentParameters = @{ ResourceGroupName = $ResourceGroupName; Name = $Name }
    $parent = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' $parentParameters "parent '$Name'" -AllowNotFound
    if ($parent.NotFound) {
        $fixture.State = 'Cleaned'
        Save-EdgeActionTestEnvironment
        return
    }

    Write-Host "Cleaning EdgeAction fixture '$Name': execution filters, non-default versions, current default version, then parent."
    foreach ($childType in 'ExecutionFilter', 'Version') {
        $parameters = @{ ResourceGroupName = $ResourceGroupName; EdgeActionName = $Name }
        $get = "Get-AzEdgeAction$childType"
        $remove = "Remove-AzEdgeAction$childType"
        $children = Invoke-EdgeActionTestCommand $get $parameters "$childType collection of '$Name'" -AllowNotFound
        $orderedChildren = @($children.Value | Where-Object { $null -ne $_ })
        if ($childType -eq 'Version') {
            foreach ($version in $orderedChildren) {
                if ([string]$version.IsDefaultVersion -notin @('True', 'False')) {
                    throw "Cleanup of '$Name' cannot determine default status for version '$($version.Name)'; no versions were deleted."
                }
            }
            if (@($orderedChildren | Where-Object { [string]$_.IsDefaultVersion -eq 'True' }).Count -gt 1) {
                throw "Cleanup of '$Name' received multiple default versions; no versions were deleted."
            }
            # The generated property is a string; casting 'False' to bool would produce true.
            # Use the current service state, not creation order or the expected outcome of a swap.
            $orderedChildren = @($orderedChildren | Sort-Object { [string]$_.IsDefaultVersion -eq 'True' })
        }
        foreach ($child in $orderedChildren) {
            if (-not $child.Name) { throw "Cleanup of '$Name' received a $childType without a name." }
            $childParameters = $parameters.Clone()
            $childParameters[$childType] = $child.Name
            $deleteParameters = $childParameters.Clone()
            $deleteParameters.Confirm = $false
            $resource = "$childType '$($child.Name)' under '$Name'"
            $null = Invoke-EdgeActionTestCommand $remove $deleteParameters $resource -AllowNotFound
            $remaining = Invoke-EdgeActionTestCommand $get $childParameters $resource -AllowNotFound
            if (-not $remaining.NotFound) {
                throw "Cleanup failed: $resource still exists after deletion completed."
            }
        }
    }
    $deleteParameters = $parentParameters.Clone()
    $deleteParameters.Confirm = $false
    $null = Invoke-EdgeActionTestCommand 'Remove-AzEdgeAction' $deleteParameters "parent '$Name'" -AllowNotFound
    $remaining = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' $parentParameters "parent '$Name'" -AllowNotFound
    if (-not $remaining.NotFound) {
        throw "Cleanup failed: parent '$Name' still exists after deletion completed."
    }
    $fixture.State = 'Cleaned'
    Save-EdgeActionTestEnvironment
    Write-Host "Completed cleanup of EdgeAction fixture '$Name'."
}

function New-EdgeActionTestResource {
    param([string]$ResourceGroupName, [string]$Name)
    $fixture = Assert-EdgeActionTestFixture $ResourceGroupName $Name
    if ($TestMode -ne 'playback' -and $env.ResourceGroupState -ne 'Created') {
        throw 'The resource group was not confirmed as created by this run; no fixture creation was attempted.'
    }
    if ($fixture.State -ne 'NotCreated') { throw "Fixture '$Name' has already been attempted in this run." }
    $existing = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' @{
        ResourceGroupName = $ResourceGroupName; Name = $Name
    } "parent '$Name'" -AllowNotFound
    if (-not $existing.NotFound) { throw "Fixture '$Name' already exists. It was not modified or deleted; choose a new run." }
    $parameters = @{
        ResourceGroupName = $ResourceGroupName; Name = $Name
        SkuName = 'Standard'; SkuTier = 'Standard'; Location = 'global'
    }
    # Persist before PUT so a timeout or terminated process cannot hide a possible resource.
    $fixture.State = 'Creating'
    Save-EdgeActionTestEnvironment
    $created = Invoke-EdgeActionTestCommand 'New-AzEdgeAction' $parameters "parent '$Name'"
    $fixture.State = 'Created'
    Save-EdgeActionTestEnvironment
    $created.Value
}
