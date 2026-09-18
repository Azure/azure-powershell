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
    $env.Add("location", "eastus")
    $resourceGroup = "autoTestGroup" + (RandomString -allChars $false -len 5)
    $env.AddWithCache("resourceGroup", $resourceGroup, $true)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    $mapName = "autoTestDependencyMap" + (RandomString -allChars $false -len 2)
    $env.AddWithCache("mapName", $mapName, $true)
    $mapNameForCreation = "autoTestDependencyMap" + (RandomString -allChars $false -len 2)
    $env.AddWithCache("mapNameForCreation", $mapNameForCreation, $true)
    $sourceName = "autoTestSource" + (RandomString -allChars $false -len 2)
    $env.AddWithCache("sourceName", $sourceName, $true)
    $sourceNameForCreation = "autoTestSource" + (RandomString -allChars $false -len 2)
    $env.AddWithCache("sourceNameForCreation", $sourceNameForCreation, $true)

    Write-Host "Create dependency map $($env.mapName) resource group: $($env.resourceGroup)"
    New-AzDependencyMap -Name $env.mapName -ResourceGroupName $env.resourceGroup -Location $env.location

    Write-Host "Create dependency map source $($env.sourceName) in resource group: $($env.resourceGroup)"
    $property = New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject -SourceId testSourceId
    New-AzDependencyMapDiscoverySource -SourceName $env.sourceName -ResourceGroupName $env.resourceGroup -Location $env.location -MapName $env.mapName -Property $property

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

