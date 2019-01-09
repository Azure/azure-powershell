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


#
# ChefExtensionTests.ps1
#

<#
.SYNOPSIS
Test the usage of the Set virtual machine chef extension command
#>
function Test-SetChefExtensionBasic
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        ############ Create Virtual Machine #############
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

        # OS & Image
        $user = "localadmin";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
        $p = Set-AzVMSourceImage -VM $p -PublisherName MicrosoftWindowsServer -Offer WindowsServer -Skus 2012-R2-Datacenter -Version "latest"

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        ############ Created Virtual Machine #############

        ############ Test Chef Extension #################
        $version = "1210.12"
        $client_rb = Join-Path $TemplatesPath "client.rb";
        $validationPemFile = Join-Path $TemplatesPath "tstorgnztn-validator.pem";

        # Set Chef extension
        Set-AzVMChefExtension -ResourceGroupName $rgname -VMName $vmname -TypeHandlerVersion $version -ClientRb $client_rb -ValidationPem $validationPemFile -Windows
        $extension = Get-AzVMChefExtension -ResourceGroupName $rgname -VMName $vmname -Windows

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Chef.Bootstrap.WindowsAzure'
        Assert-AreEqual $extension.ExtensionType 'ChefClient'
        Assert-AreEqual $extension.Name 'ChefClient'

        # Test Remove command.
        Remove-AzVMChefExtension -ResourceGroupName $rgname -VMName $vmname -Windows
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
