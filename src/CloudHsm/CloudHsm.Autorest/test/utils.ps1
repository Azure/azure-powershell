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
    # Run with -UsePreviousConfigForRecord to keep values from env.json when re-recording a subset of tests.
    $null = $env.AddWithCache('SubscriptionId', (Get-AzContext).Subscription.Id, $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('Tenant', (Get-AzContext).Tenant.Id, $UsePreviousConfigForRecord)

    # Cloud HSM created and deleted by the New/Remove tests (mock HFC)
    $null = $env.AddWithCache('rgName', 'PS-Test', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('cloudHsmName', 'TestPSResource', $UsePreviousConfigForRecord)

    # Existing activated Cloud HSM in West Europe used by the Get/Update/Backup tests.
    # Its user-assigned identity has Storage Blob Data Contributor on backupContainerUri.
    $null = $env.AddWithCache('existingSubscriptionId', (Get-AzContext).Subscription.Id, $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('existingRgName', 'ngangwar', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('existingCloudHsmName', 'test-pw-chsm', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('backupContainerUri', 'https://chsme2estorageaccountcs.blob.core.windows.net/teste2eblobcontainer', $UsePreviousConfigForRecord)

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

