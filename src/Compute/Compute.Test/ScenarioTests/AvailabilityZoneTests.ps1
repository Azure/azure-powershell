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
Test Virtual Machine Performance Maintenance
#>
function Test-VirtualMachineZone
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        #[string]$loc = Get-Location "Microsoft.Compute" "virtualMachines" "East US 2";
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc `
                                       -AllocationMethod 'Static' -DomainNameLabel ('pubip' + $rgname) -Zone "1" -Sku 'Standard';
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -Zone "1" `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";

        $p = $imgRef | Set-AzVMSourceImage -VM $p;
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual "1" $vm.Zones;

        $vm | Update-AzVM;
        Assert-AreEqual "1" $vm.Zones;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
