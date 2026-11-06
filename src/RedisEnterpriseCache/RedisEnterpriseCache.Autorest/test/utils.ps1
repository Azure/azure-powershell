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
function New-RedisEnterpriseCacheTestPolicyTokenObserver {
    param([hashtable]$Observation)
    {
        param($request, $eventListener, $next)
        if ($request.Method.Method -in 'POST', 'PUT', 'PATCH', 'DELETE') {
            $header = 'x-ms-policy-external-evaluations'
            if (-not $request.Headers.Contains($header)) {
                throw 'The tested write has no Change Safety policy header.'
            }
            foreach ($value in $request.Headers.GetValues($header)) {
                if ([string]::IsNullOrWhiteSpace($value) -or $value -eq '[Filtered]') {
                    throw 'The tested write has an empty or filtered Change Safety policy header.'
                }
            }
            $Observation.Writes++
        }
        $next.SendAsync($request, $eventListener)
    }.GetNewClosure()
}

function Protect-RedisEnterpriseCacheTestPollingUrl {
    param([string]$Url)
    $uri = $null
    if (-not [uri]::TryCreate($Url, [UriKind]::Absolute, [ref]$uri)) {
        throw 'A recording contains an invalid request or polling URL.'
    }
    if ($uri.AbsolutePath -notmatch '(?i)/providers/Microsoft\.Cache/(?:locations/[^/]+/(?:operationsStatus|operationResults)|redisEnterprise/[^/]+/operationResults)/[^/]+$' -or -not $uri.Query) {
        return $Url
    }
    $queryStart = $Url.IndexOf('?')
    $fragmentStart = $Url.IndexOf('#', $queryStart)
    if ($fragmentStart -lt 0) { $fragmentStart = $Url.Length }
    $query = $Url.Substring($queryStart, $fragmentStart - $queryStart)
    $sanitized = [regex]::Replace($query, '(?i)([?&][tcsh]=)[^&#]*', '${1}Sanitized')
    $Url.Substring(0, $queryStart) + $sanitized + $Url.Substring($fragmentStart)
}

function Protect-RedisEnterpriseCacheTestRecording {
    param([string]$Content)
    # Match EdgeAction's case-sensitive, Desktop-compatible recording normalization.
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
        if (-not $requestUri -or -not $requestUri.InnerText) {
            throw 'A recording entry has no request URL; no files were changed.'
        }
        $url = $requestUri.InnerText
        $newUrl = Protect-RedisEnterpriseCacheTestPollingUrl $url
        if ($newUrl -cne $url) {
            # The recorder formats lookup URLs with Uri.ToString(), but stores AbsoluteUri.
            $keyUrl = if ($key.Contains($url)) { $url } else { ([uri]$url).ToString() }
            if (-not $key.Contains($keyUrl)) {
                throw 'A recording lookup key does not contain its request URL; no files were changed.'
            }
            $newKey = $key.Replace($keyUrl, (Protect-RedisEnterpriseCacheTestPollingUrl $keyUrl))
            $replacements[$key] = $newKey
            $replacements[$url] = $newUrl
        }
        foreach ($header in $entry.SelectNodes('Response/Headers/*')) {
            $headerName = if ($header.HasAttribute('item')) { $header.GetAttribute('item') } else { $header.LocalName }
            if ($headerName -notin 'Azure-AsyncOperation', 'Location') { continue }
            $urls = if ($header.GetAttribute('type') -eq 'array') { $header.ChildNodes } else { $header }
            foreach ($value in $urls) {
                $url = $value.InnerText
                $newUrl = Protect-RedisEnterpriseCacheTestPollingUrl $url
                if ($newUrl -cne $url) { $replacements[$url] = $newUrl }
            }
        }
        if (-not $keys.Add($newKey)) {
            throw 'Polling URL sanitization would create duplicate recording lookup keys; no files were changed.'
        }
    }
    if (-not $replacements.Count) { return $Content }
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

function Complete-RedisEnterpriseCacheTestRecording {
    param([string]$Path)
    if ($TestMode -ne 'record') { return }
    $content = [System.IO.File]::ReadAllText($Path)
    $protected = Protect-RedisEnterpriseCacheTestRecording $content
    $temporaryPath = "$Path.tmp"
    [System.IO.File]::WriteAllText($temporaryPath, $protected, [System.Text.UTF8Encoding]::new($false))
    Move-Item -LiteralPath $temporaryPath -Destination $Path -Force -ErrorAction Stop
}

function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.ClusterName  = 'ps-cache-test1-' + (RandomString -allChars $false -len 8)
    $env.ClusterName2 = 'ps-cache-test2-' + (RandomString -allChars $false -len 8)
    $env.ClusterName3  = 'ps-cache-test3-' + (RandomString -allChars $false -len 8)
    $env.ClusterName4 = 'ps-cache-test4-' + (RandomString -allChars $false -len 8)
    $env.ResourceGroupName = 'ps-redisenterprise-rg-' + (RandomString -allChars $false -len 8)
    $env.Location = 'eastus'
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName | Out-Null
}
