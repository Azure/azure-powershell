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
    
    # Load test environment variables from JSON file
    $envFile = 'localEnv.json'
    if ($TestMode -ne 'live') {
        $envFile = 'env.json'
    }
    
    $envFilePath = Join-Path $PSScriptRoot $envFile
    if (Test-Path -Path $envFilePath) {
        $envData = Get-Content $envFilePath | ConvertFrom-Json
        $envData.psobject.properties | ForEach-Object { 
            if (-not $env.Contains($_.Name)) {
                $env[$_.Name] = $_.Value 
            }
        }
    }
    
    # Create test resource group if it doesn't exist
    if ($env.resourceGroup -and $env.location) {
        Write-Host "Checking for resource group: $($env.resourceGroup)"
        $rg = Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction SilentlyContinue
        if (-not $rg) {
            Write-Host "Creating resource group: $($env.resourceGroup) in location: $($env.location)"
            New-AzResourceGroup -Name $env.resourceGroup -Location $env.location | Out-Null
            Write-Host "Resource group created successfully"
        } else {
            Write-Host "Resource group already exists"
        }
    }
    
    # For any resources you created for test, you should add it to $env here.
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Optionally remove the resource group after tests
    # Uncomment the following lines if you want to auto-cleanup:
    # if ($env.resourceGroup) {
    #     Write-Host "Cleaning up resource group: $($env.resourceGroup)"
    #     Remove-AzResourceGroup -Name $env.resourceGroup -Force -AsJob | Out-Null
    # }
}

<#
.SYNOPSIS
Creates a Virtual Network for testing purposes

.DESCRIPTION
Creates a Virtual Network with specified parameters. If the VNet already exists, returns the existing VNet.

.PARAMETER ResourceGroupName
The name of the resource group where the VNet will be created

.PARAMETER VNetName
The name of the Virtual Network to create

.PARAMETER Location
The Azure region where the VNet will be created

.PARAMETER AddressPrefix
The address prefix for the VNet (e.g., "10.0.0.0/16")

.EXAMPLE
New-TestVirtualNetwork -ResourceGroupName "rg-test" -VNetName "vnet-test" -Location "eastus" -AddressPrefix "10.0.0.0/16"
#>
function New-TestVirtualNetwork {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory = $true)]
        [string]$VNetName,
        
        [Parameter(Mandatory = $true)]
        [string]$Location,
        
        [Parameter(Mandatory = $false)]
        [string]$AddressPrefix = "10.0.0.0/16"
    )
    
    try {
        Write-Host "Checking for Virtual Network: $VNetName in resource group: $ResourceGroupName"
        $vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue
        
        if ($vnet) {
            Write-Host "Virtual Network '$VNetName' already exists"
            return $vnet
        }
        
        Write-Host "Creating Virtual Network: $VNetName with address prefix: $AddressPrefix"
        $vnet = New-AzVirtualNetwork -Name $VNetName `
                                     -ResourceGroupName $ResourceGroupName `
                                     -Location $Location `
                                     -AddressPrefix $AddressPrefix
        
        Write-Host "Virtual Network created successfully"
        return $vnet
    }
    catch {
        Write-Error "Failed to create Virtual Network: $_"
        throw
    }
}

<#
.SYNOPSIS
Creates a Subnet within a Virtual Network

.DESCRIPTION
Creates a subnet with specified parameters within an existing Virtual Network

.PARAMETER ResourceGroupName
The name of the resource group containing the VNet

.PARAMETER VNetName
The name of the Virtual Network

.PARAMETER SubnetName
The name of the subnet to create

.PARAMETER AddressPrefix
The address prefix for the subnet (e.g., "10.0.1.0/24")

.PARAMETER PrivateEndpointNetworkPoliciesFlag
Disable or Enable private endpoint network policies (default: Disabled for PE support)

.EXAMPLE
New-TestSubnet -ResourceGroupName "rg-test" -VNetName "vnet-test" -SubnetName "subnet-pe" -AddressPrefix "10.0.1.0/24"
#>
function New-TestSubnet {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory = $true)]
        [string]$VNetName,
        
        [Parameter(Mandatory = $true)]
        [string]$SubnetName,
        
        [Parameter(Mandatory = $false)]
        [string]$AddressPrefix = "10.0.1.0/24",
        
        [Parameter(Mandatory = $false)]
        [string]$PrivateEndpointNetworkPoliciesFlag = "Disabled"
    )
    
    try {
        Write-Host "Checking for Subnet: $SubnetName in VNet: $VNetName"
        $vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $vnet -ErrorAction SilentlyContinue
        
        if ($subnet) {
            Write-Host "Subnet '$SubnetName' already exists"
            return $subnet
        }
        
        Write-Host "Creating Subnet: $SubnetName with address prefix: $AddressPrefix"
        Add-AzVirtualNetworkSubnetConfig -Name $SubnetName `
                                         -VirtualNetwork $vnet `
                                         -AddressPrefix $AddressPrefix `
                                         -PrivateEndpointNetworkPoliciesFlag $PrivateEndpointNetworkPoliciesFlag | Out-Null
        
        $vnet | Set-AzVirtualNetwork | Out-Null
        
        $vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $vnet
        
        Write-Host "Subnet created successfully"
        return $subnet
    }
    catch {
        Write-Error "Failed to create Subnet: $_"
        throw
    }
}

<#
.SYNOPSIS
Creates a Private Endpoint for a FileShare resource

.DESCRIPTION
Creates a Private Endpoint to connect to a FileShare resource through a private network

.PARAMETER ResourceGroupName
The name of the resource group where the PE will be created

.PARAMETER PrivateEndpointName
The name of the Private Endpoint

.PARAMETER Location
The Azure region where the PE will be created

.PARAMETER SubnetId
The resource ID of the subnet where the PE will be deployed

.PARAMETER FileShareResourceId
The resource ID of the FileShare resource

.EXAMPLE
New-TestPrivateEndpoint -ResourceGroupName "rg-test" -PrivateEndpointName "pe-fileshare" -Location "eastus" -SubnetId "/subscriptions/.../subnets/subnet-pe" -FileShareResourceId "/subscriptions/.../providers/Microsoft.FileShares/shares/share01"
#>
function New-TestPrivateEndpoint {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory = $true)]
        [string]$PrivateEndpointName,
        
        [Parameter(Mandatory = $true)]
        [string]$Location,
        
        [Parameter(Mandatory = $true)]
        [string]$SubnetId,
        
        [Parameter(Mandatory = $true)]
        [string]$FileShareResourceId,
        
        [Parameter(Mandatory = $false)]
        [string]$GroupId = "share"
    )
    
    try {
        Write-Host "Checking for Private Endpoint: $PrivateEndpointName"
        $pe = Get-AzPrivateEndpoint -Name $PrivateEndpointName -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue
        
        if ($pe) {
            Write-Host "Private Endpoint '$PrivateEndpointName' already exists"
            return $pe
        }
        
        Write-Host "Creating Private Endpoint: $PrivateEndpointName"
        $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection `
            -Name "$PrivateEndpointName-connection" `
            -PrivateLinkServiceId $FileShareResourceId `
            -GroupId $GroupId
        
        $pe = New-AzPrivateEndpoint -Name $PrivateEndpointName `
                                    -ResourceGroupName $ResourceGroupName `
                                    -Location $Location `
                                    -Subnet @{Id = $SubnetId} `
                                    -PrivateLinkServiceConnection $privateLinkServiceConnection
        
        Write-Host "Private Endpoint created successfully"
        return $pe
    }
    catch {
        Write-Error "Failed to create Private Endpoint: $_"
        throw
    }
}

<#
.SYNOPSIS
Removes a Virtual Network

.DESCRIPTION
Removes a Virtual Network from a resource group

.PARAMETER ResourceGroupName
The name of the resource group containing the VNet

.PARAMETER VNetName
The name of the Virtual Network to remove

.EXAMPLE
Remove-TestVirtualNetwork -ResourceGroupName "rg-test" -VNetName "vnet-test"
#>
function Remove-TestVirtualNetwork {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory = $true)]
        [string]$VNetName
    )
    
    try {
        Write-Host "Removing Virtual Network: $VNetName"
        Remove-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName -Force | Out-Null
        Write-Host "Virtual Network removed successfully"
    }
    catch {
        Write-Warning "Failed to remove Virtual Network: $_"
    }
}

<#
.SYNOPSIS
Removes a Private Endpoint

.DESCRIPTION
Removes a Private Endpoint from a resource group

.PARAMETER ResourceGroupName
The name of the resource group containing the PE

.PARAMETER PrivateEndpointName
The name of the Private Endpoint to remove

.EXAMPLE
Remove-TestPrivateEndpoint -ResourceGroupName "rg-test" -PrivateEndpointName "pe-fileshare"
#>
function Remove-TestPrivateEndpoint {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,
        
        [Parameter(Mandatory = $true)]
        [string]$PrivateEndpointName
    )
    
    try {
        Write-Host "Removing Private Endpoint: $PrivateEndpointName"
        Remove-AzPrivateEndpoint -Name $PrivateEndpointName -ResourceGroupName $ResourceGroupName -Force | Out-Null
        Write-Host "Private Endpoint removed successfully"
    }
    catch {
        Write-Warning "Failed to remove Private Endpoint: $_"
    }
}

