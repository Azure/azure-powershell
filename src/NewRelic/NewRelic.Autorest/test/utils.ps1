function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
    $resourceGroup = 'ps-test'
    $env.Add('resourceGroup', $resourceGroup)

    $region = 'eastus'
    $env.Add('region', $region)

    $testerEmail = 'v-jiaji@microsoft.com'
    $env.Add('testerEmail', $testerEmail)

    $testMonitorName = 'test-03'
    $env.Add('testMonitorName', $testMonitorName)

    $NewMonitorName = 'test-01'
    $env.Add('NewMonitorName', $NewMonitorName)

    $testApp = '/subscriptions/272c26cb-7026-4b37-b190-7cb7b2abecb0/resourceGroups/ps-test/providers/Microsoft.Web/sites/joyertest'
    $env.Add('testApp', $testApp)

    #Plan Data
    $planDetails = "newrelic-pay-as-you-go-free-live@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg"
    $env.Add('planDetails', $planDetails)
    $billingCycle = "MONTHLY"
    $env.Add('billingCycle', $billingCycle)
    $usageType = 'PAYG'
    $env.Add('usageType', $usageType)

    #create test group
    #create app service

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

