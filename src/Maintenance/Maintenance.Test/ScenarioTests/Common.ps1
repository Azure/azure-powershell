# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets maintenance configuration name
#>
function Get-RandomMaintenanceConfigurationName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets virtual machine name
#>
function Get-RandomVirtualMachineName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets dedicated host name
#>
function Get-RandomDedicatedHostGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets dedicated host name
#>
function Get-RandomDedicatedHostName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets resource group name
#>
function Get-RandomResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = $provider.Split("/")[0]
        if($provider.Contains("/"))
        {
            $type = $provider.Substring($namespace.Length + 1)
            $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

            if ($location -eq $null)
            {
                return "eastus2euap"
            } else
            {
                return $location.Locations[0].ToLower() -replace '\s',''
            }
        }

        return "eastus2euap"
    }

    return "eastus2euap"
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Creates a new virtual machine
#>
function New-VirtualMachine(
    [string] $virtualMachineName,
    [string] $resourceGroupName,
    [string] $location)
{
    $vmLocalAdminUser = "LocalAdminUser"
    $vmLocalAdminSecurePassword = ConvertTo-SecureString -String ([guid]::NewGuid()) -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential($vmLocalAdminUser, $vmLocalAdminSecurePassword);
    $patchMode = "AutomaticByPlatform"
    $patchSettings = New-Object `
        -TypeName Microsoft.Azure.Management.Compute.Models.WindowsVMGuestPatchAutomaticByPlatformSettings `
        -Property @{BypassPlatformSafetyChecksOnUserSchedule = $true}
    $sku = "Standard_D2s_v3"
    $computerName = $virtualMachineName
    $networkName = "Net$virtualMachineName"
    $nicName = "Nic$virtualMachineName"
    $subnetName = "Subnet$virtualMachineName"
    $subnetAddressPrefix = "10.0.0.0/24"
    $vnetAddressPrefix = "10.0.0.0/16"
    $securityType = "Standard"
    $imagePublisher = "MicrosoftVisualStudio"
    $imageOffer = "Windows"
    $imageSku = "Windows-10-N-x64"
    $imageVersion = "latest"

    $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $subnetAddressPrefix
    $vnet = New-AzVirtualNetwork `
        -Name $networkName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -AddressPrefix $vnetAddressPrefix `
        -Subnet $subnet
    $nic = New-AzNetworkInterface `
        -Name $nicName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -SubnetId $vnet.Subnets[0].Id

    $vmConfig = New-AzVMConfig `
        -VMName $virtualMachineName `
        -VMSize $sku `
        -SecurityType $securityType
    Set-AzVMOperatingSystem `
        -VM $vmConfig `
        -Windows `
        -ComputerName $computerName `
        -Credential $credential `
        -ProvisionVMAgent `
        -EnableAutoUpdate `
        -PatchMode $patchMode `
        | Out-Null
    Set-AzVMSourceImage `
        -VM $vmConfig `
        -PublisherName $imagePublisher `
        -Offer $imageOffer `
        -Skus $imageSku `
        -Version $imageVersion `
        | Out-Null
    Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id | Out-Null

    New-AzVM -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig | Out-Null
    $virtualMachine = Get-AzVM -ResourceGroupName $resourceGroupName -Name $virtualMachineName
    $virtualMachine.OSProfile.WindowsConfiguration.PatchSettings.AutomaticByPlatformSettings = $patchSettings
    Update-AzVM -VM $virtualMachine -ResourceGroupName $ResourceGroupName | Out-Null

    return $virtualMachine.Id
}

<#
.SYNOPSIS
Creates a new dedicated host
#>
function New-DedicatedHost(
    [string] $dedicatedHostName,
    [string] $dedicatedHostGroupName,
    [string] $resourceGroupName,
    [string] $location)
{
    $sku = "Dsv3-Type3"
    $platformFaultDomain = 1

    $dedicatedHostGroup = New-AzHostGroup `
        -Name $dedicatedHostGroupName `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -PlatformFaultDomain $platformFaultDomain

    $dedicatedHost = New-AzHost `
        -HostGroupName $dedicatedHostGroup.Name `
        -Location $location `
        -Name $dedicatedHostName `
        -ResourceGroupName $resourceGroupName `
        -Sku $sku

    return $dedicatedHost.Id
}