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

########################################################################### IP Forwarding and VM cmdlets Scenario Tests ###################################################################

<#
.SYNOPSIS
Executes Get and Update-AzureVM does not clear IPForwarding.
#>

function Test-SetIPForwardingOnVMAndUpdateVM
{
    # Setup
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    $name = getAssetName
    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Test
    New-AzureVMConfig -ImageName $image -Name $name -InstanceSize Small |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    Set-AzureSubnet -SubnetNames $SubnetName |
    New-AzureVM -VNetName $VirtualNetworkName -ServiceName $name -Location $Location

    Get-AzureVM $name | Set-AzureIPForwarding -Enable

    # update VM
    Get-AzureVM $name |
    Add-AzureEndpoint -Name "http" -Protocol tcp -LocalPort 80 -PublicPort 80 |
    Update-AzureVM

    # Assert
    $ipForwarding = Get-AzureVM $name | Get-AzureIPForwarding
    Assert-AreEqual "Enabled" $ipForwarding
}

<#
.SYNOPSIS
Executes Get and Update-AzureVM does not clear IPForwarding on NIC.
#>

function Test-SetIPForwardingOnNICAndUpdateVM
{
    # Setup
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    $name = getAssetName
    $nicName = getAssetName
    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName

    # Test
    New-AzureVMConfig -ImageName $image -Name $name -InstanceSize Large |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    Set-AzureSubnet -SubnetNames $SubnetName |
    Add-AzureNetworkInterfaceConfig -Name $nicName -SubnetName $SubnetName |
    New-AzureVM -VNetName $VirtualNetworkName -ServiceName $name -Location $Location

    Get-AzureVM $name | Set-AzureIPForwarding -Enable -NetworkInterfaceName $nicName

    # update VM
    Get-AzureVM $name |
    Add-AzureEndpoint -Name "http" -Protocol tcp -LocalPort 80 -PublicPort 80 |
    Update-AzureVM

    # Assert
    $ipForwarding = Get-AzureVM $name | Get-AzureIPForwarding -NetworkInterfaceName $nicName
    Assert-AreEqual "Enabled" $ipForwarding
}
