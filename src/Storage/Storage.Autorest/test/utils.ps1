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
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $env.RandomString = (RandomString $false 8)
    $env.ResourceGroupName = "testaccountmigrationrg"
    $env.AccountName = "testaccountmigration111"
    $env.FilePV2AccountName = "pshtestaccountpv2"
    $env.TaskID = "/subscriptions/45b60d85-fd72-427a-a708-f994d26e593e/resourceGroups/weitry/providers/Microsoft.StorageActions/storageTasks/mytask1"
    $env.TaskAssignmentResourceGroup = "testtaskassignmentrg"
    $env.TaskAssignmentAccount = "testassignmentaccount2"
    $env.NspResourceGroup = "nsprg"
    $env.NspAccount = "nspaccount"

    $fixturePath = [Environment]::GetEnvironmentVariable('AZURE_STORAGE_MANAGEMENT_TEST_FIXTURES')
    if (-not [string]::IsNullOrWhiteSpace($fixturePath)) {
        $fixtureJson = Get-Content -LiteralPath $fixturePath -Raw
        if ($fixtureJson -match '"(?:secretAccessKey|accessKeyId)"\s*:') {
            throw 'Recording fixtures must reference credential environment variables, not contain access keys.'
        }
        $env.ManagementApi = ($fixtureJson | ConvertFrom-Json).ManagementApi
        if ($null -eq $env.ManagementApi) {
            throw 'The recording fixture file requires a ManagementApi object.'
        }
        if ($env.ManagementApi.SubscriptionId -and $env.ManagementApi.SubscriptionId -ne $env.SubscriptionId) {
            throw 'The ManagementApi fixture subscription does not match the current Azure context.'
        }
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 100)
}
function cleanupEnv() {
    if ($TestMode -eq 'record') {
        Protect-StorageManagementRecording
    }
}

function Get-StorageManagementFixture {
    param([Parameter(Mandatory = $true)][string]$Name)
    $value = $env.ManagementApi.$Name
    if ($null -eq $value -or ($value -is [string] -and [string]::IsNullOrWhiteSpace($value))) {
        throw "The ManagementApi recording fixture requires $Name. Configure AZURE_STORAGE_MANAGEMENT_TEST_FIXTURES before recording."
    }
    return $value
}

function Protect-StorageManagementRecording {
    $path = Join-Path $PSScriptRoot 'ManagementApiUpgrade.BlobAccessPoint.Recording.json'
    if ($TestMode -ne 'record' -or -not (Test-Path -LiteralPath $path)) {
        return
    }
    $recording = Get-Content -LiteralPath $path -Raw | ConvertFrom-Json
    foreach ($entry in $recording.PSObject.Properties) {
        foreach ($message in @($entry.Value.Request, $entry.Value.Response)) {
            if ([string]::IsNullOrEmpty($message.Content)) {
                continue
            }
            $content = $message.Content
            if ($message.isContentBase64) {
                $content = [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($content))
            }
            $content = [regex]::Replace($content,
                '("(?:secretAccessKey|accessKeyId)"\s*:\s*)"(?:[^"\\]|\\.)*"',
                '${1}"REDACTED"', [Text.RegularExpressions.RegexOptions]::IgnoreCase)
            if ($message.isContentBase64) {
                $content = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes($content))
            }
            $message.Content = $content
        }
    }
    [IO.File]::WriteAllText($path, ($recording | ConvertTo-Json -Depth 100), [Text.UTF8Encoding]::new($false))
}
