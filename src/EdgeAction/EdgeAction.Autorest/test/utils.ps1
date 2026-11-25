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
        if ($env.ResourceGroupState -eq 'Cleaned' -and $env.ResourceGroupName -ceq 'powershellsdk-edgeaction-tests-rgname') {
            if ($Mode -eq 'record' -and $PSCmdlet.ShouldProcess('completed EdgeAction recordings', 'Sanitize polling URLs')) {
                Complete-EdgeActionTestRecording
            }
            return
        }
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

function Protect-EdgeActionTestPollingUrl {
    param([string]$Url)
    $uri = $null
    if (-not [uri]::TryCreate($Url, [UriKind]::Absolute, [ref]$uri)) {
        throw 'A recording contains an invalid request or polling URL; review it before sanitization.'
    }
    if ($uri.AbsolutePath -notmatch '(?i)/providers/Microsoft\.Cdn/edgeactionoperations/[^/]+$' -or -not $uri.Query) {
        return $Url
    }
    $queryStart = $Url.IndexOf('?')
    $fragmentStart = $Url.IndexOf('#', $queryStart)
    if ($fragmentStart -lt 0) { $fragmentStart = $Url.Length }
    $query = $Url.Substring($queryStart, $fragmentStart - $queryStart)
    $sanitized = [regex]::Replace($query, '(?i)([?&][tcsh]=)[^&#]*', '${1}Sanitized')
    $Url.Substring(0, $queryStart) + $sanitized + $Url.Substring($fragmentStart)
}

function Protect-EdgeActionTestRecording {
    param([string]$Content)
    # The framework JSON reader preserves case-sensitive keys on both Desktop and Core.
    Add-Type -AssemblyName System.Runtime.Serialization
    $reader = [System.Runtime.Serialization.Json.JsonReaderWriterFactory]::CreateJsonReader(
        [System.Text.Encoding]::UTF8.GetBytes($Content), [System.Xml.XmlDictionaryReaderQuotas]::Max)
    $recording = New-Object System.Xml.XmlDocument
    try {
        $recording.Load($reader)
    } finally {
        $reader.Dispose()
    }
    if ($recording.DocumentElement.GetAttribute('type') -ne 'object') {
        throw 'A recording must contain a JSON object of request lookup keys; no files were changed.'
    }
    $keys = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    $replacements = [System.Collections.Generic.Dictionary[string, string]]::new([StringComparer]::Ordinal)
    foreach ($entry in $recording.DocumentElement.ChildNodes) {
        $key = if ($entry.HasAttribute('item')) { $entry.GetAttribute('item') } else { $entry.LocalName }
        $newKey = $key
        $requestUri = $entry.SelectSingleNode('Request/RequestUri')
        if ($requestUri -and $requestUri.InnerText) {
            $url = $requestUri.InnerText
            $newUrl = Protect-EdgeActionTestPollingUrl $url
            if ($newUrl -cne $url) {
                if (-not $key.Contains($url)) {
                    throw 'A recording lookup key does not contain its request URL; no files were changed.'
                }
                $newKey = $key.Replace($url, $newUrl)
                $replacements[$key] = $newKey
                $replacements[$url] = $newUrl
            }
        }
        foreach ($header in $entry.SelectNodes('Response/Headers/*')) {
            $headerName = if ($header.HasAttribute('item')) { $header.GetAttribute('item') } else { $header.LocalName }
            if ($headerName -notin 'Azure-AsyncOperation', 'Location') { continue }
            $urls = if ($header.GetAttribute('type') -eq 'array') { $header.ChildNodes } else { $header }
            foreach ($value in $urls) {
                $url = $value.InnerText
                $newUrl = Protect-EdgeActionTestPollingUrl $url
                if ($newUrl -cne $url) { $replacements[$url] = $newUrl }
            }
        }
        if (-not $keys.Add($newKey)) {
            throw 'Polling URL sanitization would create duplicate recording lookup keys; no files were changed.'
        }
    }
    if (-not $replacements.Count) { return $Content }
    # Replace whole JSON string tokens, preserving formatting and embedded code/payload strings.
    [regex]::Replace($Content, '"(?:\\.|[^"\\])*"', [System.Text.RegularExpressions.MatchEvaluator]{
        param($match)
        if ($match.Value -notmatch '\?|\\u003f') { return $match.Value }
        $value = ConvertFrom-Json -InputObject $match.Value -ErrorAction Stop
        $replacement = $null
        if ($replacements.TryGetValue($value, [ref]$replacement)) {
            return ConvertTo-Json -InputObject $replacement -Compress
        }
        $match.Value
    })
}

function Complete-EdgeActionTestRecording {
    if ($TestMode -ne 'record') { return }
    if ($env.ResourceGroupState -ne 'Cleaned') {
        throw 'Verify resource-group cleanup before replacing the live name in recordings and environment metadata.'
    }
    $placeholder = 'powershellsdk-edgeaction-tests-rgname'
    $pattern = $null
    if ($env.ResourceGroupName -cne $placeholder) {
        Assert-EdgeActionTestResourceGroup
        $pattern = [regex]::Escape($env.ResourceGroupName)
    }
    $updates = @(
        foreach ($file in Get-ChildItem -LiteralPath $PSScriptRoot -Filter '*.Recording.json' -File) {
            $text = [System.IO.File]::ReadAllText($file.FullName)
            $updated = $text
            if ($pattern -and $text -match $pattern) {
                if ($text -match [regex]::Escape($placeholder)) {
                    throw "Recording '$($file.Name)' mixes live and placeholder resource-group names; review it before normalization."
                }
                $updated = [regex]::Replace($text, $pattern, $placeholder, [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
            }
            $updated = Protect-EdgeActionTestRecording $updated
            if ($updated -cne $text) { @{ Path = $file.FullName; Content = $updated } }
        }
    )
    foreach ($update in $updates) {
        $temporaryPath = "$($update.Path).tmp"
        [System.IO.File]::WriteAllText($temporaryPath, $update.Content, [System.Text.UTF8Encoding]::new($false))
        Move-Item -LiteralPath $temporaryPath -Destination $update.Path -Force -ErrorAction Stop
    }
    # Keep the live name recoverable on disk until every recording has been normalized.
    if ($pattern) {
        $env.ResourceGroupName = $placeholder
        Save-EdgeActionTestEnvironment
    }
}

function New-EdgeActionTestResponse {
    # Generated cmdlets can discard HTTP status when converting a service error to ErrorRecord.
    # Observe outside the recorder so live and playback responses use the same 404 check.
    if (-not ('EdgeActionTestResponse' -as [type])) {
        $compilerParameters = @{}
        if ($PSVersionTable.PSEdition -eq 'Desktop') {
            Add-Type -AssemblyName System.Net.Http
            $compilerParameters.ReferencedAssemblies = @([System.Net.Http.HttpResponseMessage].Assembly.Location)
        }
        Add-Type @compilerParameters -TypeDefinition @'
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
public sealed class EdgeActionTestExchange {
    public string Method;
    public System.Uri Uri;
    public int StatusCode;
    public string AsyncOperation;
    public string Location;
    public string Content;
}
public sealed class EdgeActionTestResponse {
    public int? StatusCode { get; private set; }
    public string ErrorBody { get; private set; }
    public List<EdgeActionTestExchange> Exchanges = new List<EdgeActionTestExchange>();
    public async Task<HttpResponseMessage> Capture(HttpRequestMessage request, Task<HttpResponseMessage> pending) {
        var response = await pending.ConfigureAwait(false);
        IEnumerable<string> asyncOperation;
        var exchange = new EdgeActionTestExchange {
            Method = request.Method.Method,
            Uri = request.RequestUri,
            StatusCode = (int)response.StatusCode,
            AsyncOperation = response.Headers.TryGetValues("Azure-AsyncOperation", out asyncOperation)
                ? string.Join(",", asyncOperation) : null,
            Location = response.Headers.Location == null ? null : response.Headers.Location.OriginalString,
            Content = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false)
        };
        Exchanges.Add(exchange);
        return response;
    }
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
    New-Object EdgeActionTestResponse
}

function Invoke-EdgeActionTestCommand {
    param(
        [string]$Command,
        [hashtable]$Parameters,
        [string]$Resource,
        [switch]$AllowNotFound,
        [switch]$WithoutRecorder
    )

    $observation = New-EdgeActionTestResponse
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

function Assert-EdgeActionTestJsonProperty {
    param([object]$Object, [string]$Name, [string]$Type, [switch]$Required)
    $property = @($Object.PSObject.Properties | Where-Object Name -CEQ $Name)
    if (-not $property.Count) {
        if ($Required) { throw "API response is missing required '$Name' ($Type)." }
        return
    }
    $value = $property[0].Value
    $valid = switch ($Type) {
        # ConvertFrom-Json can materialize a JSON date string as DateTime.
        'string' { $value -is [string] -or $value -is [datetime] -or $value -is [datetimeoffset] }
        'object' { $value -is [System.Management.Automation.PSCustomObject] }
        'array' { $value -is [array] }
        default { throw "Unknown API response assertion type '$Type'." }
    }
    if (-not $valid) { throw "API response '$Name' must be a JSON $Type." }
}

function Assert-EdgeActionTestResponseModel {
    param([object]$Body, [string]$Schema)
    # Focused subset of stable 2026-10-01 definitions and common-types/v6.
    # Keep this mapping aligned with the source README's Swagger pin.
    if ($Body -isnot [System.Management.Automation.PSCustomObject]) {
        throw "API response must be a JSON object matching $Schema."
    }
    if ($Schema -like '*ListResult') {
        Assert-EdgeActionTestJsonProperty $Body 'value' 'array' -Required
        Assert-EdgeActionTestJsonProperty $Body 'nextLink' 'string'
        foreach ($item in $Body.value) {
            Assert-EdgeActionTestResponseModel $item ($Schema -replace 'ListResult$', '')
        }
        return
    }
    if ($Schema -eq 'VersionCode') {
        foreach ($name in 'name', 'content') {
            Assert-EdgeActionTestJsonProperty $Body $name 'string' -Required
        }
        return
    }
    if ($Schema -notin 'EdgeAction', 'EdgeActionVersion', 'EdgeActionExecutionFilter') {
        throw "Unknown API response schema '$Schema'."
    }
    Assert-EdgeActionTestJsonProperty $Body 'location' 'string' -Required
    foreach ($name in 'id', 'name', 'type') {
        Assert-EdgeActionTestJsonProperty $Body $name 'string'
    }
    Assert-EdgeActionTestJsonProperty $Body 'tags' 'object'
    if ($null -ne $Body.tags) {
        foreach ($tag in $Body.tags.PSObject.Properties) {
            Assert-EdgeActionTestJsonProperty $Body.tags $tag.Name 'string' -Required
        }
    }
    Assert-EdgeActionTestJsonProperty $Body 'systemData' 'object'
    if ($null -ne $Body.systemData) {
        foreach ($name in 'createdBy', 'createdByType', 'createdAt', 'lastModifiedBy', 'lastModifiedByType', 'lastModifiedAt') {
            Assert-EdgeActionTestJsonProperty $Body.systemData $name 'string'
        }
    }
    if ($Schema -eq 'EdgeAction') {
        Assert-EdgeActionTestJsonProperty $Body 'sku' 'object' -Required
        foreach ($name in 'name', 'tier') {
            Assert-EdgeActionTestJsonProperty $Body.sku $name 'string' -Required
        }
    }
    Assert-EdgeActionTestJsonProperty $Body 'properties' 'object'
    if ($null -eq $Body.properties) { return }
    Assert-EdgeActionTestJsonProperty $Body.properties 'provisioningState' 'string'
    switch ($Schema) {
        'EdgeAction' {
            Assert-EdgeActionTestJsonProperty $Body.properties 'attachments' 'array' -Required
            foreach ($attachment in $Body.properties.attachments) {
                if ($attachment -isnot [System.Management.Automation.PSCustomObject]) {
                    throw 'API response attachment must be a JSON object.'
                }
                Assert-EdgeActionTestJsonProperty $attachment 'id' 'string'
                Assert-EdgeActionTestJsonProperty $attachment 'attachedResourceId' 'string' -Required
            }
        }
        'EdgeActionVersion' {
            foreach ($name in 'deploymentType', 'isDefaultVersion') {
                Assert-EdgeActionTestJsonProperty $Body.properties $name 'string' -Required
            }
            $validationStatus = @($Body.properties.PSObject.Properties | Where-Object Name -CEQ 'validationStatus')
            if ($validationStatus.Count -eq 1 -and $null -eq $validationStatus[0].Value) {
                # Remove this allowance when the service omits an unset validationStatus.
                Write-Warning 'Temporary service-contract allowance: EdgeActionVersion.properties.validationStatus is null; expected an omitted field or a JSON string.'
            } else {
                Assert-EdgeActionTestJsonProperty $Body.properties 'validationStatus' 'string'
            }
            Assert-EdgeActionTestJsonProperty $Body.properties 'lastPackageUpdateTime' 'string'
        }
        'EdgeActionExecutionFilter' {
            foreach ($name in 'versionId', 'executionFilterIdentifierHeaderName', 'executionFilterIdentifierHeaderValue') {
                Assert-EdgeActionTestJsonProperty $Body.properties $name 'string' -Required
            }
            Assert-EdgeActionTestJsonProperty $Body.properties 'lastUpdateTime' 'string'
        }
    }
}

function Assert-EdgeActionTestResponseShape {
    param([string]$Content, [string]$Schema, [switch]$Completed)
    if (-not $Content -or -not $Content.TrimStart().StartsWith('{')) {
        throw "API response must be a JSON object matching $Schema."
    }
    try { $body = ConvertFrom-Json -InputObject $Content -ErrorAction Stop } catch {
        throw "API response is not valid JSON for $Schema; response body withheld."
    }
    Assert-EdgeActionTestResponseModel $body $Schema
    if ($Completed -and $null -ne $body.properties.provisioningState -and
        $body.properties.provisioningState -cne 'Succeeded') {
        throw 'Location final resource provisioningState must be Succeeded when present.'
    }
}

function Get-EdgeActionTestResponseContract {
    param([string]$Method, [uri]$Uri)
    if ($Uri.AbsolutePath -notmatch '(?i)/providers/Microsoft\.Cdn/edgeActions(?<suffix>/.*)?$') { return }
    $suffix = $Matches.suffix
    $schema = switch -Regex ($suffix) {
        '^/?$' { 'EdgeActionListResult'; break }
        '^/[^/]+$' { 'EdgeAction'; break }
        '^/[^/]+/versions$' { 'EdgeActionVersionListResult'; break }
        '^/[^/]+/executionFilters$' { 'EdgeActionExecutionFilterListResult'; break }
        '^/[^/]+/versions/[^/]+(/deployVersionCode)?$' { 'EdgeActionVersion'; break }
        '^/[^/]+/executionFilters/[^/]+$' { 'EdgeActionExecutionFilter'; break }
        '^/[^/]+/versions/[^/]+/getVersionCode$' { 'VersionCode'; break }
        '^/[^/]+/versions/[^/]+/swapDefault$' { 'Empty'; break }
        default { throw 'No response contract is mapped for this EdgeAction operation.' }
    }
    $codes = switch ($Method) {
        'GET' { @(200) }
        'PUT' { @(200, 201) }
        'PATCH' { @(200, 202) }
        'POST' { if ($schema -eq 'Empty') { @(202, 204) } else { @(200, 202) } }
        'DELETE' { $schema = 'Empty'; @(200, 202, 204) }
        default { throw "No response contract is mapped for HTTP $Method." }
    }
    @{ Schema = $schema; Codes = $codes }
}

function Assert-EdgeActionTestApiResponses {
    param([object[]]$Exchanges)
    $polls = @()
    $location = $null
    foreach ($exchange in $Exchanges) {
        if ($exchange.Method -ne 'GET') { $polls = @() }
        if ($exchange.Method -eq 'GET' -and $exchange.Uri.AbsoluteUri -in $polls) {
            if ($exchange.Uri.AbsoluteUri -eq $location -and $exchange.StatusCode -ne 202) {
                $polls = @()
            }
            continue
        }
        $contract = Get-EdgeActionTestResponseContract $exchange.Method $exchange.Uri
        # Expected fixture-probe 404s and error bodies are not successful response schemas.
        if ($null -eq $contract -or $exchange.StatusCode -ge 400) { continue }
        if ($exchange.StatusCode -notin $contract.Codes) {
            throw "API $($exchange.Method) response returned HTTP $($exchange.StatusCode); expected $($contract.Codes -join ' or ')."
        }
        if ($exchange.StatusCode -eq 202 -or $contract.Schema -eq 'Empty') {
            if (-not [string]::IsNullOrWhiteSpace($exchange.Content)) {
                throw 'API response must be empty for this operation and HTTP status.'
            }
        } else {
            Assert-EdgeActionTestResponseShape $exchange.Content $contract.Schema
        }
        if ($exchange.Method -ne 'GET') {
            $polls = @($exchange.AsyncOperation, $exchange.Location) | Where-Object { $_ }
            $location = $exchange.Location
        }
    }
}

function Assert-EdgeActionTestAsyncResponses {
    param([object[]]$Exchanges)
    # ARM RPC async-api-reference.md: monitor GETs return 200 with a required status.
    # Provider-defined intermediate states are allowed, but these scenarios expect success.
    for ($index = 0; $index -lt $Exchanges.Count; $index++) {
        $start = $Exchanges[$index]
        if ($start.Method -notin 'PUT', 'PATCH', 'POST', 'DELETE' -or
            $start.Uri.AbsolutePath -notmatch '(?i)/providers/Microsoft\.Cdn/edgeActions/[^/]+' -or
            $null -eq $start.AsyncOperation) { continue }
        $statuses = if ($start.Method -eq 'PUT') { @(200, 201) } else { @(202) }
        if ($start.StatusCode -notin $statuses) {
            throw "Asynchronous $($start.Method) returned HTTP $($start.StatusCode); expected $($statuses -join ' or ') per the stable API specification."
        }
        $monitor = $null
        if (-not [uri]::TryCreate($start.AsyncOperation, [UriKind]::Absolute, [ref]$monitor) -or
            $monitor.Scheme -notin 'http', 'https') {
            throw 'Azure-AsyncOperation must be an absolute HTTP(S) URL.'
        }
        $succeeded = $false
        for ($next = $index + 1; $next -lt $Exchanges.Count; $next++) {
            $candidate = $Exchanges[$next]
            if ($candidate.Method -ne 'GET') { break }
            if ($candidate.Uri -eq $monitor) {
                if ($candidate.StatusCode -ne 200) {
                    throw "Azure-AsyncOperation GET returned HTTP $($candidate.StatusCode); expected 200."
                }
                if (-not $candidate.Content -or -not $candidate.Content.TrimStart().StartsWith('{')) {
                    throw 'Azure-AsyncOperation response must be a JSON status object.'
                }
                try { $body = ConvertFrom-Json -InputObject $candidate.Content -ErrorAction Stop } catch {
                    throw 'Azure-AsyncOperation response is not valid JSON; response body withheld.'
                }
                $status = @($body.PSObject.Properties | Where-Object Name -CEQ 'status')
                if ($status.Count -ne 1 -or $status[0].Value -isnot [string] -or
                    [string]::IsNullOrWhiteSpace($status[0].Value)) {
                    throw 'Azure-AsyncOperation response requires a nonempty string status.'
                }
                # Non-status monitor fields are a known service issue deferred until the next API.
                # This does not exempt the separate final Location/resource response.
                if ($status[0].Value -in 'Failed', 'Canceled') {
                    throw 'Azure-AsyncOperation reached a failed or canceled terminal state; this scenario requires Succeeded.'
                }
                if ($succeeded -and $status[0].Value -ne 'Succeeded') {
                    throw 'Azure-AsyncOperation status regressed after Succeeded.'
                }
                $succeeded = $status[0].Value -eq 'Succeeded'
            } elseif (($start.Location -and $candidate.Uri -eq $start.Location -and $candidate.StatusCode -ne 202) -or
                ($start.Method -eq 'PUT' -and $candidate.Uri -eq $start.Uri)) {
                if (-not $succeeded) {
                    throw 'Final resource/Location GET was observed before Azure-AsyncOperation reached Succeeded.'
                }
                break
            }
        }
        if (-not $succeeded) {
            throw 'No Succeeded terminal response was observed at the Azure-AsyncOperation URL.'
        }
    }
}

function Assert-EdgeActionTestLocationResponses {
    param([object[]]$Exchanges)
    for ($index = 0; $index -lt $Exchanges.Count; $index++) {
        $start = $Exchanges[$index]
        $isPut = $start.Method -eq 'PUT' -and $start.StatusCode -in 200, 201
        if (-not $isPut -and $start.StatusCode -ne 202) { continue }
        $path = $start.Uri.AbsolutePath
        if ($start.Method -notin 'PUT', 'PATCH', 'POST', 'DELETE' -or
            $path -notmatch '(?i)/providers/Microsoft\.Cdn/edgeActions/[^/]+') { continue }
        # PUT may finish with a resource GET rather than a Location GET.
        # Validate an observed result without requiring that extra request.
        if (-not $isPut -and -not [string]::IsNullOrWhiteSpace($start.Content)) {
            throw 'Accepted HTTP 202 response must be empty per the ARM asynchronous API contract.'
        }
        $location = $null
        if ($isPut -and -not $start.Location) {
            $location = $start.Uri
        } elseif (-not [uri]::TryCreate($start.Location, [UriKind]::Absolute, [ref]$location) -or
            $location.Scheme -notin 'http', 'https') {
            throw "Accepted $($start.Method) operation requires an absolute HTTP(S) Location URL."
        }
        $final = $null
        for ($next = $index + 1; $next -lt $Exchanges.Count; $next++) {
            $candidate = $Exchanges[$next]
            if ($candidate.Method -ne 'GET') { break }
            if ($candidate.Uri -eq $location -and $candidate.StatusCode -eq 202) {
                if (-not [string]::IsNullOrWhiteSpace($candidate.Content)) {
                    throw 'Pending Location HTTP 202 response must be empty.'
                }
            } elseif ($candidate.Uri -eq $location) {
                $final = $candidate
                break
            }
        }
        if ($null -eq $final) {
            if ($isPut) { continue }
            throw 'No terminal GET response was observed at the Location URL; the status monitor alone does not verify the final response.'
        }
        if ($final.StatusCode -lt 200 -or $final.StatusCode -ge 300) {
            throw "Location final response returned HTTP $($final.StatusCode); this scenario requires success."
        }
        # Temporarily defer swapDefault's final Location payload until the RP fix.
        # Keep its monitor, URL, and observed-success checks.
        if ($start.Method -eq 'POST' -and $path -match '/versions/[^/]+/swapDefault$') { continue }
        $contract = Get-EdgeActionTestResponseContract $start.Method $start.Uri
        $codes = if ($start.Method -eq 'DELETE') { @(200, 204) } else { @(200) }
        if ($final.StatusCode -notin $codes) {
            throw "Location final response returned HTTP $($final.StatusCode); expected $($codes -join ' or ')."
        }
        if ($contract.Schema -eq 'Empty') {
            if (-not [string]::IsNullOrWhiteSpace($final.Content)) {
                throw 'Location final response must be empty for this operation.'
            }
        } else {
            Assert-EdgeActionTestResponseShape $final.Content $contract.Schema -Completed
        }
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
    $script:edgeActionLocationObserver = New-EdgeActionTestResponse
    $observer = $script:edgeActionLocationObserver
    $capture = {
        param($request, $eventListener, $next)
        $observer.Capture($request, $next.SendAsync($request, $eventListener))
    }.GetNewClosure()
    if ($recorder) {
        $PSDefaultParameterValues['*:HttpPipelinePrepend'] = @($recorder, $capture)
    }
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
    $recorder = @($PSDefaultParameterValues['*:HttpPipelinePrepend'])[0]
    if ($recorder) { $recorder.PushContext('EdgeActionFixtureCleanup') }
    try { Remove-EdgeActionTestResource $ResourceGroupName $Name } catch {
        # Pester 4 otherwise replaces a BeforeAll failure with the AfterAll exception.
        if ($script:edgeActionSetupFailure) {
            throw "Setup failed: $($script:edgeActionSetupFailure.Exception.Message)`nCleanup also failed: $($_.Exception.Message)"
        }
        throw
    } finally {
        if ($recorder) { $recorder.PopContext() }
        $PSDefaultParameterValues['*:HttpPipelinePrepend'] = $recorder
    }
    if (-not $script:edgeActionSetupFailure) {
        Assert-EdgeActionTestAsyncResponses $script:edgeActionLocationObserver.Exchanges
        Assert-EdgeActionTestLocationResponses $script:edgeActionLocationObserver.Exchanges
        Assert-EdgeActionTestApiResponses $script:edgeActionLocationObserver.Exchanges
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
