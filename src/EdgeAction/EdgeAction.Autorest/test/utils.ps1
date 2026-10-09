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
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.ResourceGroupName = "powershelltests"
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

function Invoke-EdgeActionTestCommand {
    param(
        [string]$Command,
        [hashtable]$Parameters,
        [string]$Resource,
        [switch]$AllowNotFound
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
    $arguments.HttpPipelinePrepend = @($PSDefaultParameterValues['*:HttpPipelinePrepend']) |
        Where-Object { $null -ne $_ }
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
    $fixtureNames = @(
        'eaptdeploydec02', 'eagetdec01', 'eagetfilterdec02', 'eagetverdec01',
        'eagetcodedec03', 'eatestdec01', 'eafilterdec03', 'eaverdec01',
        'eadeletedec01', 'eadelfilterdec02', 'eadelverdec01', 'easwapdec01'
    )
    if ($ResourceGroupName -cne 'powershelltests' -or $Name -cnotin $fixtureNames) {
        throw 'Fixture cleanup is restricted to the maintained scenario names in the dedicated powershelltests resource group.'
    }
}

function Initialize-EdgeActionTestScenario {
    param([scriptblock]$Setup)
    $script:edgeActionSetupFailure = $null
    try { & $Setup } catch {
        $script:edgeActionSetupFailure = $_
        throw
    }
}

function Complete-EdgeActionTestScenario {
    param([string]$ResourceGroupName, [string]$Name)
    try { Remove-EdgeActionTestResource $ResourceGroupName $Name } catch {
        # Pester 4 otherwise replaces a BeforeAll failure with the AfterAll exception.
        if ($script:edgeActionSetupFailure) {
            throw "Setup failed: $($script:edgeActionSetupFailure.Exception.Message)`nCleanup also failed: $($_.Exception.Message)"
        }
        throw
    }
}

function Remove-EdgeActionTestResource {
    param([string]$ResourceGroupName, [string]$Name)
    Assert-EdgeActionTestFixture $ResourceGroupName $Name
    $parentParameters = @{ ResourceGroupName = $ResourceGroupName; Name = $Name }
    $parent = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' $parentParameters "parent '$Name'" -AllowNotFound
    if ($parent.NotFound) { return }

    Write-Host "Cleaning EdgeAction fixture '$Name': execution filters, versions, then parent."
    foreach ($childType in 'ExecutionFilter', 'Version') {
        $parameters = @{ ResourceGroupName = $ResourceGroupName; EdgeActionName = $Name }
        $get = "Get-AzEdgeAction$childType"
        $remove = "Remove-AzEdgeAction$childType"
        $children = Invoke-EdgeActionTestCommand $get $parameters "$childType collection of '$Name'" -AllowNotFound
        foreach ($child in @($children.Value | Where-Object { $null -ne $_ })) {
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
    Write-Host "Completed cleanup of EdgeAction fixture '$Name'."
}

function New-EdgeActionTestResource {
    param([string]$ResourceGroupName, [string]$Name)
    Remove-EdgeActionTestResource $ResourceGroupName $Name
    $parameters = @{
        ResourceGroupName = $ResourceGroupName; Name = $Name
        SkuName = 'Standard'; SkuTier = 'Standard'; Location = 'global'
    }
    $created = Invoke-EdgeActionTestCommand 'New-AzEdgeAction' $parameters "parent '$Name'"
    $created.Value
}
