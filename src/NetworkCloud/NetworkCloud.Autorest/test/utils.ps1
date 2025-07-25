function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | ForEach-Object { [char]$_ })
    }
    else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | ForEach-Object { [char]$_ })
    }
}
$configFile = "test-artifacts/config.json"
$global:Config = Get-Content (Join-Path $PSScriptRoot $configFile)  -Raw -ErrorAction:SilentlyContinue -WarningAction:SilentlyContinue | ConvertFrom-Json -ErrorAction:SilentlyContinue -WarningAction:SilentlyContinue
$global:config = ($Config)
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | ForEach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.subscriptionId = (Get-AzContext).Subscription.Id
    $env.tenant = (Get-AzContext).Tenant.Id

    # For any resources you created for test, you should add it to $env here.
    # Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6

    # Create the test group
    $resourceGroup = 'pstest_rg' + $rstr1
    $null = $env.Add("resourceGroup", $resourceGroup)
}


function cleanupEnv() {
    # Check if resource group exists before cleanup
    Get-AzResourceGroup -Name $env.resourceGroup -ErrorVariable NotPresent -ErrorAction SilentlyContinue
    if ($NotPresent) {
        # ResourceGroup doesn't exist
    }
    else {
        # ResourceGroup exist, remove test resource group
        Write-Host "Removing test resource group"
        Remove-AzResourceGroup -Name $env.resourceGroup
    }
}

