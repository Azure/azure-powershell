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
    # Generate some random strings for use in the test.
    $rstr1 = "lnxcr"
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    $rstr7 = RandomString -allChars $false -len 6
    $rstr8 = RandomString -allChars $false -len 6
    $webhook = "webhook001"
    $replication = "replication001"
    $null = $env.Add("rstr1", $rstr1)
    $null = $env.Add("rstr2", $rstr2)
    $null = $env.Add("rstr3", $rstr3)
    $null = $env.Add("webhook", "webhook001")
    $null = $env.Add("replication", "replication001")
    $null = $env.Add("webhook2", "webhook002")
    $null = $env.Add("replication2", "replication002")
    $null = $env.Add("webhook3", "webhook003")
    $null = $env.Add("replication3", "replication003")
    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "lnxtest"
    $null = $env.Add("resourceGroup", $resourceGroup)
    New-AzContainerRegistryReplication -RegistryName $rstr1 -ResourceGroupName  $resourceGroup -Name $replication -Location 'east us'
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
}

