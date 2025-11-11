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

    $env.resourceGroup = 'storageDiscoveryTestRg'
    $env.region = 'eastus2'
    $env.testWorkspaceName1 = 'pshtestworkspace1'
    $env.testWorkspaceName2 = 'pshtestworkspace2'
    $env.workspaceRoot = @("/subscriptions/$($env.SubscriptionId)")
    
    Write-Host 'Start to create test resource group' $env.resourceGroup
    try {
        Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction Stop
        Write-Host 'Get created group'
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.region
    }

    # Create test storage discovery resources if needed
    # Note: Add specific StorageDiscovery resource creation here based on the cmdlets available
    # Example structure based on the module pattern:
    try {
        $null = Get-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup -ErrorAction Stop
    }
    catch {
        # Create discovery workspace with appropriate parameters
        $scope1 = New-AzStorageDiscoveryScopeObject -DisplayName "scope1" -ResourceType "Microsoft.Storage/storageAccounts" -TagKeysOnly "key1" -Tag @{"tag1" = "value1"; "tag2" = "value2"}
        $null = New-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup -Location $env.region -WorkspaceRoot $env.workspaceRoot -Sku Standard -Scope $scope1 -Description "test storage discovery workspace 1"
    }

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove test storage discovery resources
    if (Get-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue) {
        Remove-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName1 -ResourceGroupName $env.resourceGroup
    }
    if (Get-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName2 -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue) {
        Remove-AzStorageDiscoveryWorkspace -Name $env.testWorkspaceName2 -ResourceGroupName $env.resourceGroup
    }
}

