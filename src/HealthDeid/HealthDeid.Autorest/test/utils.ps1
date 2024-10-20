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

    Write-Output "Creating DeID services"
    $deidServiceName = RandomString -allChars $false -len 6
    $env.Add("deidServiceName", $deidServiceName)
    $deidServiceNameWithPL = RandomString -allChars $false -len 6
    $env.Add("deidServiceNameWithPL", $deidServiceNameWithPL)
    $deidServiceNameToDelete1 = RandomString -allChars $false -len 6
    $env.Add("deidServiceNameToDelete1", $deidServiceNameToDelete1)
    $deidServiceNameToDelete2 = RandomString -allChars $false -len 6
    $env.Add("deidServiceNameToDelete1", $deidServiceNameToDelete2)
    $deidServiceToCreateInTests = RandomString -allChars $false -len 6
    $env.Add("deidServiceToCreateInTests", $deidServiceToCreateInTests)
    Write-Output "Finished creating DeID services"

    $env.Add("location", "eastus2")

    # Create the test resource group
    Write-Host "Creating test resource group"
    $resourceGroup = "azps-test-rg-eus2"
    $env.Add("resourceGroupName", $resourceGroup)
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location
    Write-Host "Resource group created"

    # Create resources to use in tests
    New-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceName -Location $env.location
    New-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceNameWithPL -Location $env.location
    # TODO: add private link

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
    Write-Host "Resource group deleted"
}

