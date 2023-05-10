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

    # Need to create [Iot Hub] and [Private endpoint] in a same Resource group
    $accountName1 = "azpstest" + (RandomString -allChars $false -len 6)
    $accountName2 = "azpstest" + (RandomString -allChars $false -len 6)
    $accountName3 = "azpstest" + (RandomString -allChars $false -len 6)

    $env.Add("accountName1", $accountName1)
    $env.Add("accountName2", $accountName2)
    $env.Add("accountName3", $accountName3)

    $instanceName1 = "azpstest" + (RandomString -allChars $false -len 6)
    $instanceName2 = "azpstest" + (RandomString -allChars $false -len 6)
    $instanceName3 = "azpstest" + (RandomString -allChars $false -len 6)

    $env.Add("instanceName1", $instanceName1)
    $env.Add("instanceName2", $instanceName2)
    $env.Add("instanceName3", $instanceName3)

    $connectionName1 = "azpstest" + (RandomString -allChars $false -len 6)
    $connectionName2 = "azpstest" + (RandomString -allChars $false -len 6)
    $connectionName3 = "azpstest" + (RandomString -allChars $false -len 6)

    $env.Add("connectionName1", $connectionName1)
    $env.Add("connectionName2", $connectionName2)
    $env.Add("connectionName3", $connectionName3)

    $env.Add("location", "eastus")

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "azpstest_gp"
    $env.Add("resourceGroup", $resourceGroup)

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

