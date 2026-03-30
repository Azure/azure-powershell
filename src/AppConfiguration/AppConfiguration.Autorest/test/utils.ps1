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

    $str1 = RandomString -allChars $false -len 6

    $appStoreName1 = "az" + (RandomString -allChars $false -len 4)
    $env.Add("appStoreName1", $appStoreName1)

    $appStoreName2 = "az" + (RandomString -allChars $false -len 4)
    $env.Add("appStoreName2", $appStoreName2)

    $env.Add("location", "eastus")

    $replicaTestStoreName = "az" + (RandomString -allChars $false -len 4)
    $env.Add("replicaTestStoreName", $replicaTestStoreName)
    $env.Add("replicaName", "eastus2replica")

    $newReplicaStoreName = "az" + (RandomString -allChars $false -len 4)
    $env.Add("newReplicaStoreName", $newReplicaStoreName)

    $removeReplicaStoreName = "az" + (RandomString -allChars $false -len 4)
    $env.Add("removeReplicaStoreName", $removeReplicaStoreName)

    write-host "start to create test group"
    $resourceGroup = "azpstestgroup-" + $str1
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup

    # Sanitize recording files and env.json so they can be committed without PII
    $subscriptionId = $env.SubscriptionId
    $tenantId = $env.Tenant
    $testDir = $PSScriptRoot

    # Sanitize all recording JSON files
    Get-ChildItem -Path $testDir -Filter '*.Recording.json' | ForEach-Object {
        $content = Get-Content $_.FullName -Raw
        $sanitized = $content -replace [regex]::Escape($subscriptionId), '00000000-0000-0000-0000-000000000000' `
                              -replace [regex]::Escape($tenantId), '00000000-0000-0000-0000-000000000000' `
                              -replace '(?<=Secret=)[^\\"]+', 'SANITIZED' `
                              -replace '(?<=\\"connectionString\\":\\")(Endpoint=https://[^"\\]+)(?=\\")', 'Endpoint=https://sanitized.azconfig.io;Id=XXXX;Secret=SANITIZED' `
                              -replace '(?<=\\"value\\":\\")[A-Za-z0-9+/]{20,}=*(?=\\")', 'SANITIZED' `
                              -replace '[a-zA-Z0-9._%+-]+@microsoft\.com', 'testuser@microsoft.com'
        if ($content -ne $sanitized) {
            Set-Content $_.FullName $sanitized -NoNewline
        }
    }

    # Sanitize env.json
    $envFile = Join-Path $testDir 'env.json'
    if (Test-Path $envFile) {
        $envContent = Get-Content $envFile -Raw | ConvertFrom-Json
        $envContent.SubscriptionId = '00000000-0000-0000-0000-000000000000'
        $envContent.Tenant = '00000000-0000-0000-0000-000000000000'
        Set-Content $envFile -Value (ConvertTo-Json $envContent)
    }
}

