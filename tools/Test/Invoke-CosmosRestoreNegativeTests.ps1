# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

#Requires -Version 7.2
<#
.SYNOPSIS
Opt-in Cosmos restore client negatives and separately opted-in service validation.
.DESCRIPTION
Run in a fresh pwsh -NoProfile process with the same local ModulePath and trusted
StatePath as Invoke-CosmosRestoreScenario. EnableLive authorizes running this harness;
WITHOUT ServiceValidation it invokes only public, local object helpers. No Azure
context, inventory, validation or job command is called in that mode. An incomplete
backup is allowed for client tests; a placeholder RP is used only in local objects.

The nine benchmark cases are B1 missing service criteria, B2 empty selectors,
B11 three segments, B14 overlapping scopes, Duplicate, Count51, MissingConfig,
InvalidMode and Nonexistent. B2/B11/B14 have separate client and service rows:
client fail-fast is NOT evidence of service rejection. Screenshot labels not supplied
here must be compared by the caller; no screenshot equivalence is claimed.

ServiceValidation additionally requires a saved Completed backup/RP, matching current
subscription/tenant/account, and an explicitly supplied TargetAccountId. The target
must be an existing Created account recorded in the positive run, tagged
CosmosRestoreRun=RunId, different from source, with no SQL databases. No target is
chosen automatically; no account, permission, RBAC, backup or restore is created.
Service validation holds the positive run's scenario.lock from before state loading
through reporting. The target's keyed restore must be unsubmitted and in a known
pre-submission state. Unrelated active jobs do not block this local guard; service
concurrency acceptance is NOT assumed, and a rejected valid control aborts negatives.
The script reads account metadata and SQL database inventory and ONLY invokes native
Test-AzDataProtectionBackupInstanceRestore (including a valid control). It NEVER
triggers restore, even when validation accepts invalid criteria. Validation can defer
scope/RP checks; an accepted negative is VALIDATION_GAP, not PASS or proof of restore
behavior. B1 expects ARM 400 with exact UserErrorInvalidRequestParameter for the
asserted missing-criteria payload, or an InvalidParameter code with criteria/scope
evidence, excluding concurrency/submission limits and authorization failures. This benchmark is not assumed to
be actual service behavior; other errors are reported as unexpected observations.
WrongRecoveryPointId optionally adds a tenth, validation-only observation; it must
differ from the saved RP. This does not guarantee an RP error at validation time.

Request identity is explicitly copied from saved UserAssignedIdentityArmId: SAMI if
empty, otherwise UAMI with UseSystemAssignedIdentity=false. Malformed service models
intentionally bypass local helper validation AFTER initializing a valid typed request.
No raw DPP REST, context switching, sign-in, retries, debug, verbose or transcript.
Do not run inside an externally enabled transcript or token-capturing HTTP trace.
Only allowlisted error fields and correlation IDs are saved, never HTTP bodies,
headers, tokens, source documents, or request/response objects. Reports are written
to the supplied ignored OutputDirectory, never to positive state or module artifacts.
.EXAMPLE
./tools/Test/Invoke-CosmosRestoreNegativeTests.ps1 -EnableLive -ModulePath $builtManifest -StatePath $positiveState -OutputDirectory $ignoredNegativeDirectory
.EXAMPLE
Add -ServiceValidation -TargetAccountId $explicitOwnedEmptyAccountId to authorize
native read-only inventory and validation calls. No restore jobs are submitted.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $ModulePath,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $StatePath,
    [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $OutputDirectory,
    [switch] $EnableLive,
    [switch] $ServiceValidation,
    [string] $TargetAccountId,
    [string] $WrongRecoveryPointId
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$DebugPreference = 'SilentlyContinue'
$VerbosePreference = 'SilentlyContinue'

function Protect-NegativeText([string] $Text) {
    if (-not $Text) { return $null }
    $text = [regex]::Split($Text, '(?im)(?:^|\s)(?:Request\s*(?:Headers|Body|:)|Response\s*(?:Headers|Body)|Authorization\s*:|Headers\s*:)')[0]
    $text = [regex]::Split($text, '(?i)"(?:request|requestHeaders|requestBody|responseHeaders|responseBody)"\s*:')[0]
    $text = [regex]::Replace($text, '(?i)(https?://[^\s?]+)\?[^\s]+', '$1?[REDACTED]')
    $text = [regex]::Replace($text, '(?i)\b(?:Bearer|type=aad)\s*[^\r\n]*', '[REDACTED]')
    $text = [regex]::Replace($text, '(?i)["'']?(?:[\w-]*token|authorization|sig|signature|[\w-]*secret|password|accountkey|primarykey|secondarykey|credential)["'']?\s*[:=]\s*(?:"[^"]*"|''[^'']*''|[^\s,;}]+)', '[REDACTED]')
    $text = [regex]::Replace($text, '\beyJ[A-Za-z0-9_-]+(?:\.[A-Za-z0-9_-]+){1,2}\b|[A-Za-z0-9+/=_-]{80,}', '[REDACTED]')
    $text = [regex]::Replace($text, '[\r\n\t]+', ' ').Trim()
    return $text.Substring(0, [Math]::Min(2048, $text.Length))
}

function Get-NegativeFailure($ErrorRecord) {
    $codes = [System.Collections.Generic.List[string]]::new()
    $messages = [System.Collections.Generic.List[string]]::new()
    $failure = [ordered]@{
        Code = $null; InnerCodes = @(); StatusCode = $null; RequestId = $null
        ExceptionType = $ErrorRecord.Exception.GetType().FullName
        Message = Protect-NegativeText ([string]$ErrorRecord.Exception.Message)
        ErrorId = Protect-NegativeText ([string]$ErrorRecord.FullyQualifiedErrorId)
        Errors = @()
    }
    function Read-AllowlistedError($Node, [int] $Depth = 0) {
        if ($null -eq $Node -or $Depth -gt 16 -or $codes.Count -ge 64) { return }
        if ($Node -is [System.Collections.IDictionary]) {
            $code = [string]$Node['code']
            if ($code -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,199}$') {
                $codes.Add($code)
                $messages.Add((Protect-NegativeText ([string]$Node['message'])))
            }
            # info is essential: additionalInfo[].info can itself be JSON with
            # innererror. NEVER traverse arbitrary properties/request/header data.
            foreach ($key in @($Node.Keys)) {
                if ([string]$key -iin @('error', 'innererror', 'additionalinfo', 'info', 'details')) { Read-AllowlistedError $Node[$key] ($Depth + 1) }
            }
        } elseif ($Node -is [System.Collections.IEnumerable] -and $Node -isnot [string]) {
            foreach ($item in $Node) { Read-AllowlistedError $item ($Depth + 1) }
        } elseif ($Node -is [string] -and $Node.TrimStart() -match '^[\[{]') {
            try { Read-AllowlistedError (ConvertFrom-Json -InputObject $Node -AsHashtable -ErrorAction Stop) ($Depth + 1) } catch { }
        }
    }
    $exception = $ErrorRecord.Exception
    for ($depth = 0; $null -ne $exception -and $depth -lt 8; $depth++) {
        foreach ($name in @('ResponseBody', 'Body')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and $null -ne $property.Value) {
                try {
                    $node = if ($property.Value -is [string]) { ConvertFrom-Json -InputObject $property.Value -AsHashtable -ErrorAction Stop } else {
                        $property.Value | ConvertTo-Json -Depth 30 | ConvertFrom-Json -AsHashtable
                    }
                    Read-AllowlistedError $node
                } catch { } # Non-JSON bodies are never printed or saved.
            }
        }
        foreach ($name in @('Code', 'ErrorCode')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and [string]$property.Value -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,199}$' -and -not $failure.Code) { $failure.Code = [string]$property.Value }
        }
        foreach ($name in @('RequestId', 'StatusCode')) {
            $property = $exception.PSObject.Properties[$name]
            if ($null -ne $property -and [string]$property.Value -cmatch '^[A-Za-z0-9_.:-]{1,100}$') { $failure[$name] = [string]$property.Value }
        }
        $response = $exception.PSObject.Properties['Response']
        if ($null -ne $response -and $null -ne $response.Value) {
            $status = $response.Value.PSObject.Properties['StatusCode']
            if ($null -ne $status) {
                try { $failure.StatusCode = [int]$status.Value } catch { }
            }
        }
        $exception = $exception.InnerException
    }
    if ($null -ne $ErrorRecord.ErrorDetails) {
        try { Read-AllowlistedError (ConvertFrom-Json -InputObject $ErrorRecord.ErrorDetails.Message -AsHashtable -ErrorAction Stop) } catch { }
    }
    if (-not $failure.Code) {
        # Native cmdlets can expose only a plain Exception and a leading ARM
        # code in the error ID/message. Never treat a whole client message as a code.
        $leadingCode = ([string]$ErrorRecord.FullyQualifiedErrorId).Split(',')[0]
        if ($leadingCode -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,199}$') {
            $failure.Code = $leadingCode
        } else {
            $leadingCodeMatch = [regex]::Match([string]$ErrorRecord.Exception.Message, '^\[([A-Za-z][A-Za-z0-9_.-]{0,199})\]')
            if ($leadingCodeMatch.Success) { $failure.Code = $leadingCodeMatch.Groups[1].Value }
        }
    }
    if ($codes.Count -gt 0) {
        $failure.Code = $codes[0]
        $failure.InnerCodes = @($codes.ToArray() | Select-Object -Skip 1 -Unique)
        $failure.Errors = @(for ($i = 0; $i -lt $codes.Count; $i++) {
            [ordered]@{ Code = $codes[$i]; Message = $messages[$i] }
        })
    }
    return $failure
}

function Get-NegativeCases([string] $SingleSelector, [string] $AbsentSelector) {
    $database = $SingleSelector.Split('/')[0]
    # Nine distinct benchmark IDs; dual-layer observations retain the same ID.
    @(
        @{ CaseId = 'B1'; Selector = '<missing restoreCriteria>'; Local = $null; Service = 'Missing'; Parameter = 'RestoreCriterion' }
        @{ CaseId = 'B2'; Selector = '<empty>'; Local = 'Selectors'; Service = 'Empty'; Parameter = 'ResourceIdentifier'; Identifiers = [string[]]@(); Evidence = 'at least one' }
        @{ CaseId = 'B11'; Selector = "$SingleSelector/item"; Local = 'Selectors'; Service = 'Malformed'; Parameter = 'ResourceIdentifier'; Identifiers = @("$SingleSelector/item"); Evidence = 'database/container' }
        @{ CaseId = 'B14'; Selector = "$database, $SingleSelector"; Local = 'Selectors'; Service = 'Overlap'; Parameter = 'ResourceIdentifier'; Identifiers = @($database, $SingleSelector); Evidence = 'overlap' }
        @{ CaseId = 'Duplicate'; Selector = "$SingleSelector, $SingleSelector"; Local = 'Selectors'; Service = $null; Parameter = 'ResourceIdentifier'; Identifiers = @($SingleSelector, $SingleSelector); Evidence = 'duplicate' }
        @{ CaseId = 'Count51'; Selector = '<51 distinct databases>'; Local = 'Selectors'; Service = $null; Parameter = 'ResourceIdentifier'; Identifiers = @(1..51 | ForEach-Object { "negative-db-$_" }); Evidence = 'at most 50' }
        @{ CaseId = 'MissingConfig'; Selector = '<ILR without configuration>'; Local = 'MissingConfig'; Service = $null; Parameter = 'RestoreConfiguration'; Evidence = 'requires one RestoreConfiguration' }
        @{ CaseId = 'InvalidMode'; Selector = '<RestoreAsFiles>'; Local = 'InvalidMode'; Service = $null; Parameter = 'RestoreType'; Evidence = 'Allowed Values.*AlternateLocation' }
        @{ CaseId = 'Nonexistent'; Selector = $AbsentSelector; Local = $null; Service = 'Nonexistent'; Parameter = 'ResourceIdentifier'; Identifiers = @($AbsentSelector) }
    )
}

function Save-NegativeReport {
    $script:Report.UpdatedUtc = [datetime]::UtcNow.ToString('o')
    $script:Report.Results = @($script:Rows.ToArray())
    $temporary = "$script:ReportPath.$PID.tmp"
    [IO.File]::WriteAllText($temporary, (ConvertTo-Json -InputObject $script:Report -Depth 30), [Text.UTF8Encoding]::new($false))
    [IO.File]::Move($temporary, $script:ReportPath, $true)
}

function New-NegativeRow($Case, [string] $Layer) {
    [ordered]@{
        CaseId = $Case.CaseId; Layer = $Layer; Selector = $Case.Selector
        Outcome = 'NOT_RUN'; Parameter = $Case.Parameter; Code = $null; InnerCodes = @()
        StatusCode = $null; NativeCall = $false; NativeHttpObserved = $false
        NoJob = $true; RestoreSubmitted = $false; Failure = $null; Correlations = @()
    }
}

function Get-LocalRequestArguments {
    $rp = [string]$script:State['RecoveryPointId']
    if (-not $rp) { $rp = 'local-only-no-completed-recovery-point' }
    $arguments = @{
        DatasourceType = 'AzureCosmosDB'; SourceDataStore = 'VaultStore'
        RestoreLocation = [string]$script:State.RestoreLocation; RestoreType = 'AlternateLocation'
        TargetResourceId = $script:LocalTargetId; RecoveryPoint = $rp; ItemLevelRecovery = $true
        UseSystemAssignedIdentity = [string]::IsNullOrWhiteSpace([string]$script:State['UserAssignedIdentityArmId'])
        ErrorAction = 'Stop'
    }
    if (-not $arguments.UseSystemAssignedIdentity) { $arguments.UserAssignedIdentityArmId = [string]$script:State.UserAssignedIdentityArmId }
    return $arguments
}

function Invoke-ClientNegative($Case) {
    $row = New-NegativeRow $Case 'Client'
    try {
        if ($Case.Local -eq 'Selectors') {
            $null = Az.DataProtection\New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Case.Identifiers -ErrorAction Stop
        } else {
            $arguments = Get-LocalRequestArguments
            if ($Case.Local -eq 'InvalidMode') {
                $arguments.Remove('ItemLevelRecovery') | Out-Null
                $arguments.Remove('TargetResourceId') | Out-Null
                $arguments.RestoreType = 'RestoreAsFiles'
                $arguments.TargetContainerURI = 'https://local-only.invalid/container'
            }
            $null = Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @arguments
        }
        $row.Outcome = 'FAIL_LOCAL_ACCEPTED'
    } catch {
        $failure = Get-NegativeFailure $_
        $row.Failure = $failure; $row.Code = $failure.Code; $row.InnerCodes = $failure.InnerCodes
        # Unrelated errors (assembly, binding, missing commands) are not passes.
        $parameterPattern = '\b' + [regex]::Escape($Case.Parameter) + '\b'
        $row.Outcome = if ($failure.Message -match $parameterPattern -and $failure.Message -match $Case.Evidence) { 'PASS' } else { 'FAIL_UNEXPECTED_LOCAL_ERROR' }
    }
    $script:Rows.Add($row)
    Save-NegativeReport
}

function Assert-NegativeContext {
    $context = Get-AzContext -ErrorAction Stop
    if ($null -eq $context -or $context.Subscription.Id -ine $script:State.SubscriptionId -or
        $context.Tenant.Id -ine $script:State.TenantId -or $context.Account.Id -cne $script:State.AccountId) {
        throw 'Current subscription/tenant/executing account differs from positive state. No context switching is permitted.'
    }
}

function Open-NegativeScenarioLease([string] $PositiveStatePath) {
    # Same persistent lock as the positive harness. Never delete it: deleting a
    # leased path can let another process lock a different file at that path.
    return [IO.File]::Open((Join-Path (Split-Path -Parent $PositiveStatePath) 'scenario.lock'),
        [IO.FileMode]::OpenOrCreate, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
}

function Assert-NegativeTargetState($State, [string] $TargetId) {
    if ($State['Accounts'] -isnot [System.Collections.IDictionary] -or
        $State['Restores'] -isnot [System.Collections.IDictionary] -or
        $State.Accounts['source'] -isnot [System.Collections.IDictionary] -or
        -not $State.Accounts['source']['Id'] -or $TargetId -ieq $State.Accounts['source']['Id']) {
        throw 'Target ownership/source mapping is missing or invalid.'
    }
    $keys = @($State.Accounts.Keys | Where-Object {
        $State.Accounts[$_] -is [System.Collections.IDictionary] -and $State.Accounts[$_]['Id'] -ieq $TargetId
    })
    if ($keys.Count -ne 1 -or $keys[0] -ieq 'source' -or $State.Accounts[$keys[0]]['Status'] -cne 'Created') {
        throw 'Explicit target is not a uniquely recorded non-source Created account from the positive run.'
    }
    $targetKey = $keys[0]
    $allowed = @('Planned', 'Initialized', 'PermissionsAssigned', 'Validated')
    # Planned records do not yet have TargetResourceId. Accounts key is the
    # authoritative mapping, with any explicit restore mapping checked as well.
    $restore = $State.Restores[$targetKey]
    if ($restore -isnot [System.Collections.IDictionary] -or -not $restore.Contains('JobId') -or
        $restore['JobId'] -or $restore['Status'] -cnotin $allowed -or
        ($restore['TargetResourceId'] -and $restore['TargetResourceId'] -ine $TargetId)) {
        throw 'Target restore is missing, submitted, ambiguous or not in an allowlisted pre-submission state.'
    }
    foreach ($key in $State.Restores.Keys) {
        $other = $State.Restores[$key]
        if ($key -ine $targetKey -and $other -is [System.Collections.IDictionary] -and
            $other['TargetResourceId'] -ieq $TargetId -and
            (-not $other.Contains('JobId') -or $other['JobId'] -or $other['Status'] -cnotin $allowed)) {
            throw 'Another restore explicitly maps to the target with submitted or ambiguous state.'
        }
    }
}

function Test-NegativeB1Failure($Row) {
    if ($Row.Outcome -cne 'SERVICE_ERROR_UNATTRIBUTED' -or $Row.StatusCode -ne 400 -or -not $Row.Failure) { return $false }
    $codes = @($Row.Code) + @($Row.InnerCodes) + @($Row.Failure.Errors | ForEach-Object { $_.Code })
    $observed = (@($codes) + @($Row.Failure.Message) + @($Row.Failure.Errors | ForEach-Object { $_.Message })) -join ' '
    # ARM 400 alone proves nothing. The exact native code also covers NO_PARAM
    # for B1: Invoke-ServiceNegative asserts criteria are absent from the wire
    # payload before calling validation. Keep unrelated rejection exclusions.
    return (($codes -ccontains 'UserErrorInvalidRequestParameter' -or
            (($codes -join ' ') -match 'InvalidParameter' -and
                $observed -match '(?i)criteri(?:a|on)|resource[\s_-]*(?:selector|identifier)|restore[\s_-]*scope')) -and
        $observed -notmatch '(?i)MaxConcurrent|MaxSubmission|CASC|concurren|submission[\s_-]*limit|Authorization|Permission|Authentication|Token|Identity|Throttle')
}

function Assert-NegativeTarget {
    Assert-NegativeContext
    $target = Get-AzCosmosDBAccount -ResourceGroupName $script:TargetGroup -Name $script:TargetName -ErrorAction Stop
    if ($target.Id -ine $TargetAccountId -or $target.Kind -ine 'GlobalDocumentDB' -or
        $target.Location.Replace(' ', '') -ine $script:State.RestoreLocation.Replace(' ', '') -or
        $null -eq $target.Tags -or $target.Tags['CosmosRestoreRun'] -cne $script:State.RunId -or
        [string]$target.ProvisioningState -ine 'Succeeded') { throw 'Target metadata/ownership/location/provisioning check failed.' }
    if (@(Get-AzCosmosDBSqlDatabase -ResourceGroupName $script:TargetGroup -AccountName $script:TargetName -ErrorAction Stop).Count -ne 0) {
        throw 'Target contains SQL databases. Only an owned EMPTY target can be validated.'
    }
}

function Initialize-NegativeObserver {
    # CLR callback avoids a PowerShell runspace on native async continuations.
    # Runtime compilation happens only under ServiceValidation, never in local mode.
    # No bodies/URLs/headers collections are retained. Only IDs are allowlisted.
    if (-not ('CosmosNegativeValidation.Observer' -as [type])) {
        Add-Type -TypeDefinition @'
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
namespace CosmosNegativeValidation {
    public sealed class Correlation {
        public string Method;
        public string ClientRequestId;
        public string RequestId;
        public int StatusCode;
    }
    public sealed class Observer {
        public readonly ConcurrentQueue<Correlation> Records = new ConcurrentQueue<Correlation>();
        public string ValidationPath;
        private static string SafeId(string value) {
            return value != null && System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Za-z0-9_.:-]{1,100}$") ? value : null;
        }
        public async Task<HttpResponseMessage> Send(HttpRequestMessage request, object listener, object next) {
            // Fail closed: only this validation POST, or native LRO GET polling.
            if (request.Method != HttpMethod.Get && (request.Method != HttpMethod.Post ||
                !String.Equals(request.RequestUri.AbsolutePath, ValidationPath, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Only native validateRestore POST and LRO GET are permitted.");
            var record = new Correlation { Method = request.Method.Method };
            System.Collections.Generic.IEnumerable<string> values;
            if (request.Headers.TryGetValues("x-ms-client-request-id", out values))
                foreach (var value in values) { record.ClientRequestId = SafeId(value); break; }
            Records.Enqueue(record);
            var send = next.GetType().GetMethod("SendAsync");
            var response = await ((Task<HttpResponseMessage>)send.Invoke(next, new object[] { request, listener })).ConfigureAwait(false);
            record.StatusCode = (int)response.StatusCode;
            if (response.Headers.TryGetValues("x-ms-request-id", out values))
                foreach (var value in values) { record.RequestId = SafeId(value); break; }
            return response;
        }
    }
}
'@ -ErrorAction Stop
    }
    $observer = New-Object CosmosNegativeValidation.Observer
    $observer.ValidationPath = "$($script:State.BackupInstance.Id)/validateRestore"
    $step = [Delegate]::CreateDelegate([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep], $observer, $observer.GetType().GetMethod('Send'))
    return @{ Observer = $observer; Step = $step }
}

function New-PositiveNegativeRequest {
    $arguments = Get-LocalRequestArguments
    $arguments.TargetResourceId = $TargetAccountId
    $arguments.RestoreConfiguration = Az.DataProtection\New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @($script:SingleSelector) -ErrorAction Stop
    $request = Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @arguments
    if ($request -isnot [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IAzureBackupRestoreRequest] -or
        $request.RestoreTargetInfo -isnot [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreTargetInfo]) {
        throw 'Initializer did not return the expected unversioned typed item-level request.'
    }
    return $request
}

function Invoke-NativeNegativeValidation($Request, $Row) {
    Assert-NegativeTarget
    $capture = Initialize-NegativeObserver
    try {
        $Row.NativeCall = $true
        $result = @(Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore -SubscriptionId $script:State.SubscriptionId -ResourceGroupName $script:State.ResourceGroupName -VaultName $script:State.VaultName -Name $script:State.BackupInstance.Name -RestoreRequest $Request -HttpPipelineAppend $capture.Step -Confirm:$false -ErrorAction Stop)
        # A validation operation may return an operation identifier. It is NOT a
        # restore job. Never poll it with job commands or start a restore.
        $Row.Outcome = 'VALIDATION_GAP'
        if ($result.Count -gt 0) { $Row['ValidationReturnedObject'] = $true }
    } catch {
        $failure = Get-NegativeFailure $_
        $Row.Failure = $failure; $Row.Code = $failure.Code; $Row.InnerCodes = $failure.InnerCodes
        $Row.StatusCode = $failure.StatusCode
        $Row.Outcome = 'SERVICE_ERROR_UNATTRIBUTED'
    } finally {
        $Row.Correlations = @($capture.Observer.Records.ToArray() | ForEach-Object {
            [ordered]@{ Method = $_.Method; ClientRequestId = $_.ClientRequestId; RequestId = $_.RequestId; StatusCode = $_.StatusCode }
        })
        $Row.NativeHttpObserved = $Row.Correlations.Count -gt 0
        $failedHttp = @($Row.Correlations | Where-Object { $_.StatusCode -ge 400 })
        if ($failedHttp.Count -gt 0) { $Row.StatusCode = $failedHttp[-1].StatusCode }
        if (-not $Row.NativeHttpObserved) { $Row.Outcome = 'CLIENT_OR_TRANSPORT_ERROR' }
    }
}

function Invoke-ServiceNegative($Case) {
    $row = New-NegativeRow $Case 'Service'
    try {
        $request = New-PositiveNegativeRequest
        if ($Case.Service -eq 'Missing') {
            $request.RestoreTargetInfo.RestoreCriterion = $null
        } elseif ($Case.Service -eq 'WrongRecoveryPoint') {
            $request.RecoveryPointId = $WrongRecoveryPointId
        } else {
            # Deliberately bypass the helper for malformed/empty/overlap scopes.
            $selection = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria]::new()
            $selection.ObjectType = 'ResourceListSelectionCriteria'
            $selection.ResourceIdentifier = [System.Collections.Generic.List[string]]::new()
            foreach ($identifier in @($Case.Identifiers)) { $selection.ResourceIdentifier.Add($identifier) }
            $criterion = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria]::new()
            $criterion.ObjectType = 'GenericRestoreDatasourceCriteria'
            $criterion.ResourceSelector = $selection
            $request.RestoreTargetInfo.RestoreCriterion = @($criterion)
        }
        # Assert serializer shape locally; do not retain the wire body in reports.
        $wire = $request.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json -AsHashtable
        if ($wire.restoreTargetInfo.objectType -cne 'ItemLevelRestoreTargetInfo') { throw 'Service mutation lost the item-level target discriminator.' }
        if ($Case.Service -eq 'Missing') {
            if ($wire.restoreTargetInfo.ContainsKey('restoreCriteria')) { throw 'Missing criteria unexpectedly serialized.' }
        } elseif ($Case.Service -ne 'WrongRecoveryPoint') {
            $criteria = @($wire.restoreTargetInfo['restoreCriteria'])
            if ($criteria.Count -ne 1 -or $criteria[0].objectType -cne 'GenericRestoreDatasourceCriteria' -or
                $criteria[0].resourceSelectors.objectType -cne 'ResourceListSelectionCriteria' -or
                (ConvertTo-Json -InputObject @($criteria[0].resourceSelectors['resourceIdentifiers']) -Compress) -cne
                (ConvertTo-Json -InputObject @($Case.Identifiers) -Compress)) { throw 'Typed service selector mutation did not serialize exactly.' }
        }
        Invoke-NativeNegativeValidation $request $row
        # Benchmark expectation, not an assumption about the actual service.
        if ($Case.CaseId -eq 'B1' -and $row.Outcome -eq 'SERVICE_ERROR_UNATTRIBUTED') {
            $row.Outcome = if (Test-NegativeB1Failure $row) { 'EXPECTED_ERROR' } else { 'UNEXPECTED_ERROR' }
        }
    } catch {
        $row.Outcome = 'PRECONDITION_OR_MODEL_ERROR'
        $row.Failure = Get-NegativeFailure $_
        $row.Code = $row.Failure.Code; $row.InnerCodes = $row.Failure.InnerCodes
    }
    $script:Rows.Add($row)
    Save-NegativeReport
}

# Functions above are inert and can be extracted with the PowerShell AST for
# offline sanitizer/case-table tests. Never dot-source the full live entry point.
if (-not $EnableLive) { throw 'Explicit -EnableLive is required. No Azure operations or output writes were performed.' }
if ($PSBoundParameters.ContainsKey('Debug') -or $PSBoundParameters.ContainsKey('Verbose')) { throw 'Debug/Verbose are prohibited.' }
if (-not $ServiceValidation -and ($TargetAccountId -or $WrongRecoveryPointId)) { throw 'TargetAccountId/WrongRecoveryPointId require explicit -ServiceValidation.' }
$loadedAssemblyNames = @([AppDomain]::CurrentDomain.GetAssemblies() | ForEach-Object { $_.GetName().Name })
if ((Get-Module Az.DataProtection) -or ($loadedAssemblyNames -match '^Az\.DataProtection\.')) { throw 'Use a fresh pwsh -NoProfile process without DataProtection assemblies already loaded.' }
$repoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
$ModulePath = (Resolve-Path -LiteralPath $ModulePath).Path
$StatePath = (Resolve-Path -LiteralPath $StatePath).Path
$moduleRoot = Split-Path -Parent $ModulePath
$artifactRoot = [IO.Path]::GetFullPath((Join-Path $repoRoot 'artifacts')) + [IO.Path]::DirectorySeparatorChar
if (-not $ModulePath.StartsWith($artifactRoot, [StringComparison]::OrdinalIgnoreCase) -or [IO.Path]::GetFileName($ModulePath) -cne 'Az.DataProtection.psd1') { throw 'ModulePath must be the locally built DataProtection manifest under this checkout artifacts.' }
$OutputDirectory = [IO.Path]::GetFullPath($OutputDirectory)
if ($OutputDirectory -eq $moduleRoot -or $OutputDirectory.StartsWith($moduleRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) { throw 'OutputDirectory cannot be inside the module artifact.' }
$positiveDirectory = [IO.Path]::GetDirectoryName($StatePath)
$outputRoot = $OutputDirectory.TrimEnd([IO.Path]::DirectorySeparatorChar, [IO.Path]::AltDirectorySeparatorChar)
if ($outputRoot -ieq $positiveDirectory -or $outputRoot.StartsWith($positiveDirectory + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) {
    throw 'OutputDirectory must be separate from the positive state directory; no negative reports may be written there.'
}
$scenarioLease = $null
try {
if ($ServiceValidation) { $scenarioLease = Open-NegativeScenarioLease $StatePath }
# Load only after the service-mode lease; local-only mode never acquires it.
$script:State = Get-Content -LiteralPath $StatePath -Raw | ConvertFrom-Json -AsHashtable
foreach ($key in @('SchemaVersion', 'RunId', 'ModulePath', 'AssemblySha256', 'SubscriptionId', 'TenantId', 'AccountId', 'ResourceGroupName', 'VaultName', 'RestoreLocation', 'Accounts', 'Restores')) {
    if (-not $script:State.ContainsKey($key) -or $null -eq $script:State[$key]) { throw "Positive state is missing $key." }
}
if ($script:State.SchemaVersion -ne 1 -or $script:State.ModulePath -ine $ModulePath) { throw 'Positive state schema/module path mismatch.' }
$script:LocalTargetId = [string]$script:State.Accounts['single']['Id']
$script:SingleSelector = [string](@($script:State.Restores['single']['Selectors'])[0])
if ($script:SingleSelector.Split('/').Count -ne 2 -or -not $script:LocalTargetId) { throw 'Positive state must contain its valid single-container selector and target ARM ID.' }
$absentDatabase = "negative-absent-$([guid]::NewGuid().ToString('N'))"
if (@($script:State['SourceInventory'] | Where-Object { $_['Database'] -ceq $absentDatabase }).Count -ne 0) { throw 'Generated nonexistent database collides with saved source inventory.' }
$script:Cases = @(Get-NegativeCases $script:SingleSelector "$absentDatabase/absent-container")
$assembly = Join-Path $moduleRoot 'bin/Az.DataProtection.private.dll'
if ((Get-FileHash -LiteralPath $assembly -Algorithm SHA256).Hash -cne $script:State.AssemblySha256) { throw 'Module assembly fingerprint differs from positive state; no build is performed.' }
# Load the same authentication dependencies as the live scenario before the
# local module. Loading Cosmos later can otherwise resolve another Accounts DLL.
Import-Module Az.Accounts -MinimumVersion 5.5.3 -ErrorAction Stop
if ($ServiceValidation) {
    Import-Module Az.Resources -ErrorAction Stop
    Import-Module Az.CosmosDB -ErrorAction Stop
}
Import-Module $ModulePath -ErrorAction Stop
$type = 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type]
if ($null -eq $type -or $type.Namespace -cne 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models' -or
    [IO.Path]::GetFullPath($type.Assembly.Location) -ine [IO.Path]::GetFullPath($assembly)) { throw 'Wrong/versioned DataProtection model assembly loaded.' }
foreach ($name in @('New-AzDataProtectionRestoreConfigurationClientObject', 'Initialize-AzDataProtectionRestoreRequest', 'Test-AzDataProtectionBackupInstanceRestore')) {
    $command = Get-Command "Az.DataProtection\$name" -ErrorAction Stop
    if (-not $command.Module.ModuleBase.StartsWith($moduleRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase) -and $command.Module.ModuleBase -ine $moduleRoot) { throw 'Public command resolved outside the supplied module artifact.' }
}
$reportName = "CosmosRestoreNegativeTests-$([datetime]::UtcNow.ToString('yyyyMMddTHHmmssfff'))-$([guid]::NewGuid().ToString('N')).json"
$script:ReportPath = Join-Path $OutputDirectory $reportName
& git -C $repoRoot check-ignore --quiet --no-index -- $script:ReportPath
if ($LASTEXITCODE -ne 0) { throw 'OutputDirectory must be git-ignored (use artifacts outside the module).' }
$null = New-Item -ItemType Directory -Path $OutputDirectory -Force
$script:Rows = [System.Collections.Generic.List[object]]::new()
$script:Report = [ordered]@{
    SchemaVersion = 1; RunId = $script:State.RunId; StatePath = $StatePath
    CreatedUtc = [datetime]::UtcNow.ToString('o'); UpdatedUtc = $null
    ModulePath = $ModulePath; AssemblySha256 = $script:State.AssemblySha256
    ServiceValidation = [bool]$ServiceValidation; TargetAccountId = $TargetAccountId
    BenchmarkCaseCount = 9; NoRestoreSubmission = $true; NoJob = $true
    Control = $null; FatalFailure = $null; Results = @()
    Caveat = 'Client PASS proves only local fail-fast. Accepted service negatives are VALIDATION_GAP. Validation is not restore execution; RP/selector rejection is not guaranteed.'
}
Save-NegativeReport
try {
    foreach ($case in $script:Cases) {
        if ($case.Local) { Invoke-ClientNegative $case }
    }
    if ($ServiceValidation) {
        if (-not $TargetAccountId -or $script:State['Backup']['Status'] -cne 'Completed' -or -not $script:State['RecoveryPointId'] -or
            -not $script:State['BackupInstance']['Name'] -or -not $script:State['BackupInstance']['Id']) { throw 'Service validation requires TargetAccountId and a saved Completed backup, recovery point and backup instance.' }
        if ($WrongRecoveryPointId -and $WrongRecoveryPointId -ceq $script:State.RecoveryPointId) { throw 'WrongRecoveryPointId equals the saved valid RP.' }
        $match = [regex]::Match($TargetAccountId, '^/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/Microsoft\.DocumentDB/databaseAccounts/([^/]+)$', 'IgnoreCase')
        if (-not $match.Success -or $match.Groups[1].Value -ine $script:State.SubscriptionId -or $TargetAccountId -ieq $script:State.Accounts['source']['Id']) { throw 'Target must be a different owned Cosmos account in the saved subscription, never the source.' }
        Assert-NegativeTargetState $script:State $TargetAccountId
        $script:TargetGroup = $match.Groups[2].Value; $script:TargetName = $match.Groups[3].Value
        Import-Module Az.Accounts -ErrorAction Stop
        Import-Module Az.CosmosDB -ErrorAction Stop
        $controlCase = @{ CaseId = 'Control'; Selector = $script:SingleSelector; Parameter = 'RestoreConfiguration' }
        $control = New-NegativeRow $controlCase 'ServiceControl'
        Invoke-NativeNegativeValidation (New-PositiveNegativeRequest) $control
        if ($control.Outcome -eq 'VALIDATION_GAP') { $control.Outcome = 'CONTROL_ACCEPTED' }
        $script:Report.Control = $control
        Save-NegativeReport
        if ($control.Outcome -cne 'CONTROL_ACCEPTED') { throw 'Valid control was not accepted; negative errors cannot be attributed to selectors.' }
        foreach ($case in $script:Cases) { if ($case.Service) { Invoke-ServiceNegative $case } }
        if ($WrongRecoveryPointId) {
            Invoke-ServiceNegative @{ CaseId = 'WrongRecoveryPoint'; Selector = '<explicit different RP>'; Parameter = 'RecoveryPoint'; Service = 'WrongRecoveryPoint' }
        }
    } else {
        foreach ($case in $script:Cases) {
            if ($case.Service) {
                $row = New-NegativeRow $case 'Service'
                $row.Outcome = 'NOT_RUN_SERVICE_OPT_IN_REQUIRED'
                $script:Rows.Add($row)
            }
        }
    }
} catch {
    $script:Report.FatalFailure = Get-NegativeFailure $_
    foreach ($case in $script:Cases) {
        if ($case.Service -and @($script:Rows | Where-Object { $_.CaseId -ceq $case.CaseId -and $_.Layer -ceq 'Service' }).Count -eq 0) {
            $row = New-NegativeRow $case 'Service'; $row.Outcome = 'NOT_RUN_PRECONDITION_FAILED'; $script:Rows.Add($row)
        }
    }
} finally {
    Save-NegativeReport
    $script:Rows | ForEach-Object { [pscustomobject]$_ } | Format-Table CaseId, Layer, Selector, Outcome, Code, InnerCodes, NativeCall, NoJob -AutoSize | Out-Host
    Write-Host "Sanitized report: $script:ReportPath"
}
if ($script:Report.FatalFailure -or @($script:Rows | Where-Object { $_.Outcome -notin @('PASS', 'EXPECTED_ERROR', 'NOT_RUN_SERVICE_OPT_IN_REQUIRED') }).Count -gt 0) {
    throw 'Negative suite is incomplete or has findings. Inspect the sanitized report; no restore was submitted.'
}
} finally {
    if ($null -ne $scenarioLease) { $scenarioLease.Dispose() }
}