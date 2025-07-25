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
    $env.AddWithCache("SubscriptionId", (Get-AzContext).Subscription.Id, $true)
    $env.AddWithCache("Tenant", (Get-AzContext).Tenant.Id, $true)

    $env.AddWithCache("location", "eastus2", $true)

    # Create the test resource group
    Write-Host "Creating test resource group"
    $resourceGroup = "azps-test-rg-eus2"
    $env.AddWithCache("resourceGroupName", $resourceGroup, $true)
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location
    Write-Host "Resource group created"

    $deidServiceName = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceName", $deidServiceName, $true)
    $deidServiceName2 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceName2", $deidServiceName2, $true)
    $deidServiceNameToDelete1 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceNameToDelete1", $deidServiceNameToDelete1, $true)
    $deidServiceNameToDelete2 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceNameToDelete2", $deidServiceNameToDelete2, $true)
    $deidServiceToCreateInTests1 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceToCreateInTests1", $deidServiceToCreateInTests1, $true)
    $deidServiceToCreateInTests2 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceToCreateInTests2", $deidServiceToCreateInTests2, $true)
    $deidServiceToCreateInTests3 = RandomString -allChars $false -len 6
    $env.AddWithCache("deidServiceToCreateInTests3", $deidServiceToCreateInTests3, $true)

    # Create resources to use in tests
    Write-Output "Creating DeID services"
    New-AzDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceName -Location $env.location
    New-AzDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceName2 -Location $env.location
    New-AzDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceNameToDelete1 -Location $env.location
    New-AzDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceNameToDelete2 -Location $env.location
    Write-Output "Finished creating DeID services"

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    $resourceGroup = "azps-test-rg-eus2"
    $env.AddWithCache("resourceGroupName", $resourceGroup, $true)
    Remove-AzResourceGroup -Name $env.resourceGroupName
    Write-Host "Resource group deleted"
}

