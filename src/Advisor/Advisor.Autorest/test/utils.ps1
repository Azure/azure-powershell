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
    $recommendationId = "/subscriptions/45bc121f-54a8-4e7d-ac12-7033247f9f2c/resourcegroups/rg-arv-extractor-dev-cac/providers/microsoft.web/sites/func-j6lptrkb6izaw/providers/Microsoft.Advisor/recommendations/f228b427-bbff-3b0b-3561-33c0ca8580c1"
    $recommendationName = "f228b427-bbff-3b0b-3561-33c0ca8580c1"
    $recommendationResourceId = "/subscriptions/45bc121f-54a8-4e7d-ac12-7033247f9f2c/resourcegroups/rg-arv-extractor-dev-cac/providers/microsoft.web/sites/func-j6lptrkb6izaw"
    $resourceUri = "/subscriptions/45bc121f-54a8-4e7d-ac12-7033247f9f2c"
    $resourceGroup = "rg-arv-extractor-dev-cac"

    $null = $env.Add('recommendationName',$recommendationName)
    $null = $env.Add('recommendationResourceId',$recommendationResourceId)
    $null = $env.Add('recommendationId',$recommendationId)
    $null = $env.Add('resourceUri',$resourceUri)
    $null = $env.Add('resourceGroup',$resourceGroup)

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)

}
function cleanupEnv() {
    # Clean resources you create for testing
}

