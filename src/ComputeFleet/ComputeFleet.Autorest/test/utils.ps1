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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.Location = "centralus"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Cleanup is handled by AfterAll in each test suite
}

# Creates a resource group with VNet, subnet, and NSG. Returns a hashtable with SubnetId and NsgId.
function New-TestResourceGroup {
    param(
        [string]$ResourceGroupName,
        [string]$Location,
        [string]$VNetName,
        [string]$NsgName,
        [string]$SubnetName = "subnet1",
        [string]$VNetAddressPrefix = "172.16.0.0/16",
        [string]$SubnetAddressPrefix = "172.16.0.0/24"
    )

    New-AzResourceGroup -Name $ResourceGroupName -Location $Location -Confirm:$false

    $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $ResourceGroupName `
        -Location $Location -Name $NsgName

    $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $SubnetName `
        -AddressPrefix $SubnetAddressPrefix `
        -NetworkSecurityGroupId $nsg.Id
    $vnet = New-AzVirtualNetwork -ResourceGroupName $ResourceGroupName `
        -Location $Location -Name $VNetName `
        -AddressPrefix $VNetAddressPrefix -Subnet $subnetConfig

    return @{
        SubnetId = $vnet.Subnets[0].Id
        NsgId    = $nsg.Id
    }
}

# Returns a hashtable representing the base VM profile for JSON-based tests
function Get-BaseVmProfileJson {
    param(
        [Parameter(Mandatory)]
        [string]$SubnetId,
        [Parameter(Mandatory)]
        [string]$NsgId,
        [string]$VmNamePrefix = "fleetvm"
    )
    return @{
        storageProfile = @{
            imageReference = @{
                publisher = "MicrosoftWindowsServer"
                offer     = "WindowsServer"
                sku       = "2022-datacenter-azure-edition"
                version   = "latest"
            }
            osDisk = @{
                createOption = "FromImage"
                caching      = "ReadWrite"
                osType       = "Windows"
                managedDisk  = @{ storageAccountType = "Standard_LRS" }
            }
        }
        osProfile = @{
            adminUsername      = "testadmin"
            adminPassword      = "TestP@ss1234!"
            computerNamePrefix = $VmNamePrefix
        }
        networkProfile = @{
            networkApiVersion = "2020-11-01"
            networkInterfaceConfigurations = @(
                @{
                    name = "nic1"
                    properties = @{
                        primary                    = $true
                        enableAcceleratedNetworking = $false
                        networkSecurityGroup       = @{ id = $NsgId }
                        ipConfigurations = @(
                            @{
                                name = "ipconfig1"
                                properties = @{
                                    primary = $true
                                    subnet  = @{ id = $SubnetId }
                                }
                            }
                        )
                    }
                }
            )
        }
        securityProfile = @{
            securityType = "TrustedLaunch"
            uefiSettings = @{
                secureBootEnabled = $true
                vTpmEnabled       = $true
            }
        }
    }
}

# Builds a typed .NET BaseVirtualMachineProfile object for expanded parameter set tests
function New-TestVmProfile {
    param(
        [Parameter(Mandatory)]
        [string]$SubnetId,
        [Parameter(Mandatory)]
        [string]$NsgId,
        [string]$VmNamePrefix = "fleetvm"
    )
    $storageProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile]::new()
    $storageProfile.ImageReferencePublisher = "MicrosoftWindowsServer"
    $storageProfile.ImageReferenceOffer = "WindowsServer"
    $storageProfile.ImageReferenceSku = "2022-datacenter-azure-edition"
    $storageProfile.ImageReferenceVersion = "latest"
    $storageProfile.OSDiskCreateOption = "FromImage"
    $storageProfile.OSDiskCaching = "ReadWrite"
    $storageProfile.OSDiskOstype = "Windows"
    $storageProfile.ManagedDiskStorageAccountType = "Standard_LRS"

    $osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
    $osProfile.AdminUsername = "testadmin"
    $osProfile.ComputerNamePrefix = $VmNamePrefix
    $osProfile.AdminPassword = ConvertTo-SecureString "TestP@ss1234!" -AsPlainText -Force

    $ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration]::new()
    $ipConfig.Name = "ipconfig1"
    $ipConfig.Primary = $true
    $ipConfig.SubnetId = $SubnetId

    $nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration]::new()
    $nicConfig.Name = "nic1"
    $nicConfig.Primary = $true
    $nicConfig.EnableAcceleratedNetworking = $false
    $nicConfig.NetworkSecurityGroupId = $NsgId
    $nicConfig.IPConfiguration = @($ipConfig)

    $vmProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
    $vmProfile.StorageProfile = $storageProfile
    $vmProfile.OSProfile = $osProfile
    $vmProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
    $vmProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
    $vmProfile.SecurityProfileSecurityType = "TrustedLaunch"
    $vmProfile.UefiSettingSecureBootEnabled = $true
    $vmProfile.UefiSettingVTpmEnabled = $true

    return $vmProfile
}
