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

    $suffix = RandomString -allChars $false -len 6
    $env.ResourceGroupName = "fleet-test-$suffix"
    $env.Location = "centralus"
    $env.ManagedFleetName = "managed-fleet-$suffix"
    $env.LaunchFleetName = "launch-fleet-$suffix"
    $env.LaunchFleetJsonName = "launch-fleet-json-$suffix"
    $env.LaunchFleetJsonStrName = "launch-fleet-jsonstr-$suffix"
    $env.ManagedFleetJsonName = "managed-fleet-json-$suffix"
    $env.ManagedFleetJsonStrName = "managed-fleet-jsonstr-$suffix"
    $env.VNetName = "vnet-$suffix"
    $env.SubnetName = "subnet1"
    $env.NsgName = "nsg-$suffix"
    $env.VmNamePrefix = "fleetvm"

    # Create resource group
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location

    # Create NSG
    $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $env.ResourceGroupName `
        -Location $env.Location -Name $env.NsgName

    # Create VNet with subnet
    $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName `
        -AddressPrefix "172.16.0.0/24" `
        -NetworkSecurityGroupId $nsg.Id
    $vnet = New-AzVirtualNetwork -ResourceGroupName $env.ResourceGroupName `
        -Location $env.Location -Name $env.VNetName `
        -AddressPrefix "172.16.0.0/16" -Subnet $subnetConfig

    $env.SubnetId = $vnet.Subnets[0].Id
    $env.NsgId = $nsg.Id

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
}

