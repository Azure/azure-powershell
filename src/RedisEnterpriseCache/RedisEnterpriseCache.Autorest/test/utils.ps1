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

function Get-MigrationResource {
    param(
        [Parameter(Mandatory)]
        [scriptblock] $Operation
    )

    try {
        return & $Operation
    } catch {
        $statusCode = $_.Exception.Response.StatusCode
        if (($null -ne $statusCode -and [int] $statusCode -eq 404) -or
            $_.Exception.Message -match 'NotFound|could not be found') {
            return $null
        }

        throw
    }
}

function Wait-ForMigrationResources {
    param(
        [Parameter(Mandatory)]
        [string] $ResourceGroupName,

        [Parameter(Mandatory)]
        [string] $OssCacheName,

        [Parameter(Mandatory)]
        [string] $ClusterName
    )

    if ($TestMode -eq 'playback') {
        return
    }

    $deadline = (Get-Date).AddMinutes(30)
    do {
        $ossCache = Get-MigrationResource {
            Get-AzRedisCache -ResourceGroupName $ResourceGroupName -Name $OssCacheName -ErrorAction Stop
        }
        $cluster = Get-MigrationResource {
            Get-AzRedisEnterpriseCache -ResourceGroupName $ResourceGroupName -Name $ClusterName -ErrorAction Stop
        }
        $database = Get-MigrationResource {
            Get-AzRedisEnterpriseCacheDatabase -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -ErrorAction Stop
        }

        if ($ossCache.ProvisioningState -eq 'Succeeded' -and
            $cluster.ProvisioningState -eq 'Succeeded' -and
            $cluster.ResourceState -eq 'Running' -and
            $database.ProvisioningState -eq 'Succeeded' -and
            $database.ResourceState -eq 'Running') {
            return
        }

        Start-TestSleep -Seconds 30
    } while ((Get-Date) -lt $deadline)

    $ossState = if ($ossCache) { $ossCache.ProvisioningState } else { 'NotFound' }
    $clusterState = if ($cluster) { "$($cluster.ProvisioningState)/$($cluster.ResourceState)" } else { 'NotFound' }
    $databaseState = if ($database) { "$($database.ProvisioningState)/$($database.ResourceState)" } else { 'NotFound' }
    throw "Migration resources did not become ready within 30 minutes. OSS provisioning: $ossState; cluster provisioning/resource: $clusterState; database provisioning/resource: $databaseState."
}

$testScenarios = @(
    @{
        TestName = 'RedisEnterpriseCache-ChangeSafety'
        Recording = 'ChangeSafety.Recording.json'
        Fixture = 'None'
        ResourceGroupProperty = 'ResourceGroupName'
        EnvironmentProperties = @('ResourceGroupName', 'ClusterName')
    }
    @{
        TestName = 'AzRedisEnterpriseCacheClusterLifecycle'
        Recording = 'AzRedisEnterpriseCacheClusterLifecycle.Recording.json'
        Fixture = 'None'
        ResourceGroupProperty = 'ClusterLifecycleResourceGroupName'
        EnvironmentProperties = @('ClusterLifecycleResourceGroupName', 'ClusterLifecycleClusterName')
    }
    @{
        TestName = 'AzRedisEnterpriseCacheDatabaseLifecycle'
        Recording = 'AzRedisEnterpriseCacheDatabaseLifecycle.Recording.json'
        Fixture = 'None'
        ResourceGroupProperty = 'DatabaseLifecycleResourceGroupName'
        EnvironmentProperties = @('DatabaseLifecycleResourceGroupName', 'DatabaseLifecycleClusterName')
    }
    @{
        TestName = 'AzRedisEnterpriseCacheGeoReplication'
        Recording = 'AzRedisEnterpriseCacheGeoReplication.Recording.json'
        Fixture = 'None'
        ResourceGroupProperty = 'GeoResourceGroupName'
        EnvironmentProperties = @('GeoResourceGroupName', 'GeoPrimaryClusterName', 'GeoSecondaryClusterName')
    }
    @{
        TestName = 'Test-AzRedisEnterpriseCacheMigration'
        Recording = 'Test-AzRedisEnterpriseCacheMigration.Recording.json'
        Fixture = 'BalancedMigration'
        ResourceGroupProperty = 'MigrationValidateResourceGroupName'
        ClusterProperty = 'MigrationValidateClusterName'
        OssCacheProperty = 'MigrationValidateOssCacheName'
        EnvironmentProperties = @('MigrationValidateResourceGroupName', 'MigrationValidateClusterName', 'MigrationValidateOssCacheName')
    }
    @{
        TestName = 'Start-AzRedisEnterpriseCacheMigration'
        Recording = 'Start-AzRedisEnterpriseCacheMigration.Recording.json'
        Fixture = 'BalancedMigration'
        ResourceGroupProperty = 'MigrationStartResourceGroupName'
        ClusterProperty = 'MigrationStartClusterName'
        OssCacheProperty = 'MigrationStartOssCacheName'
        EnvironmentProperties = @('MigrationStartResourceGroupName', 'MigrationStartClusterName', 'MigrationStartOssCacheName')
    }
    @{
        TestName = 'Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint'
        Recording = 'Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint.Recording.json'
        Fixture = 'BalancedMigration'
        ResourceGroupProperty = 'MigrationUnlinkResourceGroupName'
        ClusterProperty = 'MigrationUnlinkClusterName'
        OssCacheProperty = 'MigrationUnlinkOssCacheName'
        EnvironmentProperties = @('MigrationUnlinkResourceGroupName', 'MigrationUnlinkClusterName', 'MigrationUnlinkOssCacheName')
    }
    @{
        TestName = 'Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint'
        Recording = 'Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint.Recording.json'
        Fixture = 'EnterpriseMigration'
        ResourceGroupProperty = 'ClusterUnlinkResourceGroupName'
        ClusterProperty = 'ClusterUnlinkClusterName'
        EnvironmentProperties = @('ClusterUnlinkResourceGroupName', 'ClusterUnlinkClusterName')
    }
)

$playbackEnvironment = Get-Content (Join-Path $PSScriptRoot 'env.json') -Raw | ConvertFrom-Json

function Get-SelectedTestNames {
    $selectedTestNames = @(
        $TestName |
            Where-Object { -not [string]::IsNullOrWhiteSpace([string]$_) }
    )

    if (($selectedTestNames.Count -eq 0) -or ($selectedTestNames -contains '*')) {
        return @()
    }

    return $selectedTestNames
}

function Get-SelectedTestScenarios {
    $selectedTestNames = @(Get-SelectedTestNames)
    if ($selectedTestNames.Count -eq 0) {
        return @($testScenarios)
    }

    return @(
        $testScenarios | Where-Object {
            $scenarioTestName = $_.TestName
            $null -ne ($selectedTestNames | Where-Object { $scenarioTestName -like $_ } | Select-Object -First 1)
        }
    )
}

function Initialize-TestFixture {
    param(
        [Parameter(Mandatory)]
        [hashtable] $Scenario,

        [Parameter(Mandatory)]
        [System.Collections.IDictionary] $TestEnvironment
    )

    if ($Scenario.Fixture -eq 'None') {
        return
    }

    $resourceGroupName = $TestEnvironment[$Scenario.ResourceGroupProperty]
    $clusterName = $TestEnvironment[$Scenario.ClusterProperty]

    if ($Scenario.Fixture -eq 'BalancedMigration') {
        $ossCacheName = $TestEnvironment[$Scenario.OssCacheProperty]
        $redisCacheModulePath = $env:AZURE_POWERSHELL_REDIS_CACHE_MODULE_PATH
        if ($redisCacheModulePath) {
            Import-Module $redisCacheModulePath -Force -ErrorAction Stop
        } else {
            Import-Module Az.RedisCache -ErrorAction Stop
        }

        New-AzRedisCache -ResourceGroupName $resourceGroupName -Name $ossCacheName -Location $TestEnvironment.Location -Sku 'Basic' -Size 'C0' | Out-Null
        New-AzRedisEnterpriseCache -Name $clusterName -ResourceGroupName $resourceGroupName -Location $TestEnvironment.Location -Sku 'Balanced_B1' -ClientProtocol 'Encrypted' -ClusteringPolicy 'OSSCluster' -EvictionPolicy 'VolatileLRU' -PublicNetworkAccess 'Enabled' -ErrorAction Stop | Out-Null
        Wait-ForMigrationResources -ResourceGroupName $resourceGroupName -OssCacheName $ossCacheName -ClusterName $clusterName
        return
    }

    if ($Scenario.Fixture -eq 'EnterpriseMigration') {
        New-AzRedisEnterpriseCache -Name $clusterName -ResourceGroupName $resourceGroupName -Location $TestEnvironment.Location -Sku 'Enterprise_E1' -ClientProtocol 'Encrypted' -ClusteringPolicy 'EnterpriseCluster' -EvictionPolicy 'NoEviction' -PublicNetworkAccess 'Enabled' -ErrorAction Stop | Out-Null
        return
    }

    throw "Unsupported test fixture '$($Scenario.Fixture)'."
}

function Invoke-ScenarioRecordingSanitizer {
    foreach ($scenario in Get-SelectedTestScenarios) {
        # Change Safety keeps separate fixture metadata and normalizes its recording in AfterAll.
        if ($scenario.TestName -eq 'RedisEnterpriseCache-ChangeSafety') { continue }
        $recordingPath = Join-Path $PSScriptRoot $scenario.Recording
        $content = Get-Content $recordingPath -Raw

        foreach ($property in $playbackEnvironment.PSObject.Properties) {
            $recordingValue = $script:recordingEnvironment[$property.Name]
            if ($recordingValue) {
                $content = $content.Replace([string]$recordingValue, [string]$property.Value)
            }
        }

        $content = $content -replace '(\\?"(?:primaryKey|secondaryKey)\\?"\s*:\s*\\?")[^"\\]*(\\?")', '${1}[Sanitized]${2}'
        Set-Content -Path $recordingPath -Value $content -NoNewline
    }

    Set-Content -Path (Join-Path $PSScriptRoot 'env.json') -Value ($playbackEnvironment | ConvertTo-Json) -NoNewline
}

function setupEnv {
    $script:recordingEnvironment = [ordered]@{}
    foreach ($property in $playbackEnvironment.PSObject.Properties) {
        $script:recordingEnvironment[$property.Name] = $property.Value
    }

    $script:recordingEnvironment.SubscriptionId = (Get-AzContext).Subscription.Id
    $script:recordingEnvironment.Tenant = (Get-AzContext).Tenant.Id
    $script:recordingEnvironment.Location = 'eastus2euap'
    $script:testResourceGroups = @()

    foreach ($scenario in Get-SelectedTestScenarios) {
        foreach ($propertyName in $scenario.EnvironmentProperties) {
            if ($propertyName -like '*ResourceGroupName') {
                $script:recordingEnvironment[$propertyName] = 'ps-redisenterprise-rg-' + (RandomString -allChars $false -len 8)
            } elseif ($propertyName -like '*OssCacheName') {
                $script:recordingEnvironment[$propertyName] = 'ps-oss-cache-' + (RandomString -allChars $false -len 8)
            } else {
                $script:recordingEnvironment[$propertyName] = 'ps-cache-' + (RandomString -allChars $false -len 8)
            }
        }

        $resourceGroupName = $script:recordingEnvironment[$scenario.ResourceGroupProperty]
        New-AzResourceGroup -Name $resourceGroupName -Location $script:recordingEnvironment.Location | Out-Null
        $script:testResourceGroups += $resourceGroupName
        Initialize-TestFixture -Scenario $scenario -TestEnvironment $script:recordingEnvironment
    }

    $environmentFile = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    Set-Content -Path (Join-Path $PSScriptRoot $environmentFile) -Value ($script:recordingEnvironment | ConvertTo-Json)
}

function cleanupEnv {
    foreach ($resourceGroupName in @($script:testResourceGroups | Select-Object -Unique)) {
        Az.Resources\Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue | Out-Null
    }

    if ($TestMode -eq 'record') {
        Invoke-ScenarioRecordingSanitizer
    }
}
