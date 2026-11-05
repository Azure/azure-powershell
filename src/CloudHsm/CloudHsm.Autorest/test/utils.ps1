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

    # Cloud HSM created by New-AzCloudHsm, used by the Get/Update/Restore/Backup tests and deleted by Remove-AzCloudHsm.
    # Restore activates it from an existing backup; its user-assigned identity needs Storage Blob Data Contributor on backupContainerUri.
    $null = $env.AddWithCache('rgName', 'ps-test', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('cloudHsmName', 'ps-test-chsm', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('location', 'westeurope', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('userAssignedIdentityId', "/subscriptions/$($env.SubscriptionId)/resourceGroups/ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/ps-test-chsm-uami", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('backupContainerUri', 'https://chsme2estorageaccountcs.blob.core.windows.net/teste2eblobcontainer', $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('backupId', 'cloudhsm-c2c00b0e-50cc-479f-b9d1-30e3cd7fefcc-2026102019512385', $UsePreviousConfigForRecord)

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

