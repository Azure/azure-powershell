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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName;
    Assert-NotNull $cmdletData;
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") };
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") };
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.","";
    return $cmdletReturnTypes -contains $realReturnType;
}

<#
.SYNOPSIS
Test creating new NetworkProfile using minimal set of parameters
#>
function Test-NetworkProfileCRUDMinimalParameters
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rglocation = Get-ProviderLocation ResourceManagement;
    $npName = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/NetworkProfiles";
    # Dependency parameters
    $containerNicConfigName = "cnic1";

    try
    {
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation;

        # Create required dependencies
        $containerNicConfig = New-AzureRmContainerNicConfig -Name $containerNicConfigName;

        # Create NetworkProfile
        $vNetworkProfile = New-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName -Location $location -ContainerNetworkInterfaceConfiguration $containerNicConfig;
        Assert-NotNull $vNetworkProfile;
        Assert-True { Check-CmdletReturnType "New-AzureRmNetworkProfile" $vNetworkProfile };
        Assert-Null $vNetworkProfile.ContainerNetworkInterfaces;
        Assert-NotNull $vNetworkProfile.ContainerNetworkInterfaceConfigurations;
        Assert-True { @($vNetworkProfile.ContainerNetworkInterfaceConfigurations).Count -gt 0 };
        Assert-AreEqual $npName $vNetworkProfile.Name;

        # Get NetworkProfile
        $vNetworkProfile = Get-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName;
        Assert-NotNull $vNetworkProfile;
        Assert-True { Check-CmdletReturnType "Get-AzureRmNetworkProfile" $vNetworkProfile };
        Assert-AreEqual $npName $vNetworkProfile.Name;

        # Remove NetworkProfile
        $removeNetworkProfile = Remove-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName -Force;

        # Get NetworkProfile should fail
        Assert-ThrowsContains { Get-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName } "${npName} not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test creating new NetworkProfile
#>
function Test-NetworkProfileCRUDAllParameters
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rglocation = Get-ProviderLocation ResourceManagement;
    $npName = Get-ResourceName;
    $location = Get-ProviderLocation "Microsoft.Network/NetworkProfiles";
    # Dependency parameters
    $containerNicConfigName = "cnic1";

    try
    {
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation;
           
        # Create NetworkProfile
        $vNetworkProfile = New-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName -Location $location
        $vNetworkProfile.ContainerNetworkInterfaceConfigurations = New-AzureRmContainerNicConfig -Name $containerNicConfigName

        Assert-NotNull $vNetworkProfile;
        Assert-True { Check-CmdletReturnType "New-AzureRmNetworkProfile" $vNetworkProfile };
        Assert-Null $vNetworkProfile.ContainerNetworkInterfaces;
        Assert-NotNull $vNetworkProfile.ContainerNetworkInterfaceConfigurations;
        Assert-True { @($vNetworkProfile.ContainerNetworkInterfaceConfigurations).Count -gt 0 };
        Assert-AreEqual $npName $vNetworkProfile.Name;

        $vNetworkProfile | Set-AzureRmNetworkProfile

        # Get NetworkProfile
        $vNetworkProfile = Get-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName;
        Assert-NotNull $vNetworkProfile;
        Assert-True { Check-CmdletReturnType "Get-AzureRmNetworkProfile" $vNetworkProfile };
        Assert-AreEqual $npName $vNetworkProfile.Name;

        # Get Container nic config
        $containerNicConfig = @($vNetworkProfile.ContainerNetworkInterfaceConfigurations)[0]
        Assert-NotNull $containerNicConfig
        Assert-AreEqual $containerNicConfig.Name $containerNicConfigName
        
        # Remove NetworkProfile
        $removeNetworkProfile = Remove-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName -Force;

        # Get NetworkProfile should fail
        Assert-ThrowsContains { Get-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $npName } "${npName} not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test creating new ContainerNetworkInterface using minimal set of parameters
#>
function Test-ContainerNetworkInterfaceConfigCRUDMinimalParameters
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rglocation = Get-ProviderLocation ResourceManagement;
    $networkProfileName = "np1"
    $containerNicConfigName = Get-ResourceName;
    $containerNicConfigNameAdd = "${containerNicConfigName}Add";
    $location = Get-ProviderLocation "Microsoft.Network/NetworkProfiles";

    try
    {
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation;

        # Create ContainerNetworkInterface
        $vContainerNetworkInterfaceConfig = New-AzureRmContainerNicConfig -Name $containerNicConfigName;
        Assert-NotNull $vContainerNetworkInterfaceConfig;
        Assert-True { Check-CmdletReturnType "New-AzureRmContainerNicConfig" $vContainerNetworkInterfaceConfig };
        $vNetworkProfile = New-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $networkProfileName -ContainerNetworkInterface $vContainerNetworkInterfaceConfig -Location $location;
        Assert-NotNull $vNetworkProfile;
        Assert-AreEqual $containerNicConfigName $vContainerNetworkInterfaceConfig.Name;

        # Get ContainerNetworkInterface
        $vContainerNetworkInterfaceConfig = @($vNetworkProfile.ContainerNetworkInterfaceConfigurations)[0]
        Assert-NotNull $vContainerNetworkInterfaceConfig;
        Assert-AreEqual $containerNicConfigName $vContainerNetworkInterfaceConfig.Name;

        # Add ContainerNetworkInterface
        $nicCfg = New-AzureRmContainerNicConfig -Name $containerNicConfigNameAdd
        $vNetworkProfile.ContainerNetworkInterfaceConfigurations.Add($nicCfg)
        Assert-NotNull $vNetworkProfile;
        $vNetworkProfile = $vNetworkProfile | Set-AzureRmNetworkProfile;

        # Get ContainerNetworkInterface
        $vContainerNetworkInterfaceConfig = $vNetworkProfile.ContainerNetworkInterfaceConfigurations | ? { $_.Name -eq $containerNicConfigNameAdd }
        Assert-NotNull $vContainerNetworkInterfaceConfig;
        Assert-AreEqual $containerNicConfigNameAdd $vContainerNetworkInterfaceConfig.Name;

        # Remove ContainerNetworkInterface
        $vNetworkProfile.ContainerNetworkInterfaceConfigurations = $null
        $vNetworkProfile = $vNetworkProfile | Set-AzureRmNetworkProfile;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

function Test-ContainerNetworkInterfaceConfigCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName;
    $rglocation = Get-ProviderLocation ResourceManagement;
    $networkProfileName = "np1"
    $containerNicConfigName = Get-ResourceName;
    $ipConfigProfileName = "ipconfigprofile1"
    $ipConfigProfileNameAdd = "${ipConfigProfileName}Add"
    $location = Get-ProviderLocation "Microsoft.Network/NetworkProfiles";
    $vnetName = "vnet1"
    $subnetName = "subnet1"
    $subnetNameAdd = "${subnetName}Add"

    try
    {
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation;

        # Create virtual network and subnet
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $subnetAdd = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetNameAdd -AddressPrefix 10.0.2.0/24
        $response = New-AzureRmVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet @($subnet, $subnetAdd)

        $subnet = $response.Subnets[0]
        $subnetAdd = $response.Subnets[1]

        Assert-AreEqual $subnet.Name $subnetName
        Assert-AreEqual $subnetAdd.Name $subnetNameAdd

        # Create IPConfigurationProfile
        $ipConfigProfile = New-AzureRmContainerNicConfigIpConfig -Name $ipConfigProfileName -Subnet $subnet
        Assert-NotNull $ipConfigProfile
        Assert-True { Check-CmdletReturnType "New-AzureRmContainerNicConfigIpConfig" $ipConfigProfile };
        Assert-AreEqual $ipConfigProfile.Name $ipConfigProfileName

        # Create ContainerNetworkInterfaceConfig
        $vContainerNetworkInterfaceConfig = New-AzureRmContainerNicConfig -Name $containerNicConfigName -IPConfiguration $ipConfigProfile;
        Assert-NotNull $vContainerNetworkInterfaceConfig;
        Assert-True { Check-CmdletReturnType "New-AzureRmContainerNicConfig" $vContainerNetworkInterfaceConfig };
        Assert-AreEqual $vContainerNetworkInterfaceConfig.Name $containerNicConfigName

        $vNetworkProfile = New-AzureRmNetworkProfile -ResourceGroupName $rgname -Name $networkProfileName -ContainerNetworkInterfaceConfiguration $vContainerNetworkInterfaceConfig -Location $location;
        Assert-NotNull $vNetworkProfile;
        Assert-AreEqual $vNetworkProfile.Name $networkProfileName;

        # Get ContainerNetworkInterfaceConfig
        $vContainerNetworkInterfaceConfig = @($vNetworkProfile.ContainerNetworkInterfaceConfigurations)[0]
        Assert-NotNull $vContainerNetworkInterfaceConfig;
        Assert-AreEqual $containerNicConfigName $vContainerNetworkInterfaceConfig.Name;

        # Get IPConfigurationProfile 
        $ipConfigProfile = @($vContainerNetworkInterfaceConfig.IpConfigurations)[0]
        Assert-NotNull $ipConfigProfile;
        Assert-AreEqual $ipConfigProfileName $ipConfigProfile.Name;

        # Add IPConfigurationProfile
        $ipCfg = New-AzureRmContainerNicConfigIpConfig -Name $ipConfigProfileNameAdd -Subnet $subnet
        $vContainerNetworkInterfaceConfig.IpConfigurations.Add($ipCfg);
        Assert-NotNull $vContainerNetworkInterfaceConfig
        Assert-True { @($vContainerNetworkInterfaceConfig.IpConfigurations).Count -gt 1 }
        Assert-AreEqual  $vContainerNetworkInterfaceConfig.IpConfigurations[0].Name $ipConfigProfileName
        Assert-AreEqual  $vContainerNetworkInterfaceConfig.IpConfigurations[1].Name $ipConfigProfileNameAdd
        $vNetworkProfile.ContainerNetworkInterfaceConfigurations[0] = $vContainerNetworkInterfaceConfig
        $vNetworkProfile = $vNetworkProfile | Set-AzureRmNetworkProfile

        # Remove by setting
        $vNetworkProfile.ContainerNetworkInterfaceConfigurations[0] = New-AzureRmContainerNicConfig -Name $containerNicConfigName -IpConfiguration $vContainerNetworkInterfaceConfig.IpConfigurations[0]
        Assert-NotNull $vNetworkProfile;
        Assert-True { @($vNetworkProfile.ContainerNetworkInterfaceConfigurations).Count -eq 1 }
        Assert-AreEqual $vNetworkProfile.ContainerNetworkInterfaceConfigurations[0].Name $containerNicConfigName
        $vNetworkProfile = $vNetworkProfile | Set-AzureRmNetworkProfile;

        # Get IPConfigurationProfile
        $vContainerNetworkInterfaceConfig = @($vNetworkProfile.ContainerNetworkInterfaceConfigurations)[0];
        $ipConfigProfile = $vContainerNetworkInterfaceConfig.IpConfigurations | ? {$_.Name -eq $ipConfigProfileName}
        Assert-NotNull $ipConfigProfile;
        Assert-AreEqual $ipConfigProfileName $ipConfigProfileName;
        Assert-True { @($vContainerNetworkInterfaceConfig.IpConfigurations).Count -eq 1 }

        $vNetworkProfile.ContainerNetworkInterfaceConfigurations = $null

        $vNetworkProfile | Set-AzureRmNetworkProfile;

        $vNetworkProfile | Remove-AzureRmNetworkProfile -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
