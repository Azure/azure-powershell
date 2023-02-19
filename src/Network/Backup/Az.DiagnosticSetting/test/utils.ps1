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
    $resourceGroupName = 'diagnostic-setting-group' + (RandomString -allChars $false -len 6)
    write-host "start to create test group $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location eastus
    $null = $env.Add("resourceGroupName", $resourceGroupName)

    # For any resources you created for test, you should add it to $env here.

    $vnetName = 'test-vnet' + (RandomString -allChars $false -len 6)
    write-host "start to create virtual network $vnetName"
    New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -AddressPrefix "10.0.1.0/24" -Location eastus
    $vnetId = (Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName).Id
    $null = $env.Add("vnetId", $vnetId)

    $workspaceName = 'test-workspace' + (RandomString -allChars $false -len 6)
    write-host "start to create log analytics workspace $workspaceName"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -Location eastus
    $workspaceId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName).ResourceId
    $null = $env.Add("workspaceId", $workspaceId)

    $diagnosticSettingName = 'test-diagnostic-setting' + (RandomString -allChars $false -len 6)
    $null = $env.Add("diagnosticSettingName", $diagnosticSettingName)

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

