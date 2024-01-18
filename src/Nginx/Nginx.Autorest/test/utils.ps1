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
    $env.resourceGroup = 'limgu_rg'
    $env.nginxDeployment1 = 'test920'
    $env.nginxDeployment2 = 'test91922'
    $env.nginxCert = 'testCert'
    $env.nginxNewCert = 'testNewCert'
    $env.nginxConf = 'default'
    $env.nginxFilePath = 'nginx.conf'
    $env.nginxFileContent = 'aHR0cCB7DQogICAgdXBzdHJlYW0gYXBwIHsNCiAgICAgICAgc2VydmVyIDE3Mi4yNy4wLjQ6ODA7DQogICAgfQ0KICAgIHNlcnZlciB7DQogICAgICAgIGxpc3RlbiA4MDsNCiAgICAgICAgbG9jYXRpb24gLyB7DQogICAgICAgICAgICBkZWZhdWx0X3R5cGUgdGV4dC9odG1sOw0KICAgICAgICAgICAgcmV0dXJuIDIwMCAnPCFET0NUWVBFIGh0bWw+PGgxIHN0eWxlPSJmb250LXNpemU6MzBweDsiPkhlbGxvIGZyb20gTmdpbnggV2ViIFNlcnZlciE8L2gxPlxuJzsNCiAgICAgICAgfQ0KICAgICAgICBsb2NhdGlvbiAvYXBwLyB7DQogICAgICAgICAgICBwcm94eV9wYXNzIGh0dHA6Ly9hcHAuYmxvYi5jb3JlLndpbmRvd3MubmV0LzsNCiAgICAgICAgICAgIHByb3h5X2h0dHBfdmVyc2lvbiAxLjE7DQogICAgICAgICAgICBwcm94eV9yZWFkX3RpbWVvdXQgNjAwOw0KCSAgICAgICAgcHJveHlfY29ubmVjdF90aW1lb3V0IDYwMDsNCgkgICAgICAgIHByb3h5X3NlbmRfdGltZW91dCA2MDA7DQogICAgICAgIH0NCiAgICB9DQp9'

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

