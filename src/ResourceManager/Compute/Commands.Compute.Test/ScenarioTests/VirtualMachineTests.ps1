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
Test Virtual Machines
#>
function Test-VirtualMachine
{
    # Setup
    $rgname = Get-ResourceGroupName

    try
    {
        # Common
        $loc = 'West US';
        New-AzureResourceGroup -Name $rgname -Location $loc;

        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201410.01-en.us-127GB.vhd';

        $p = New-AzureVMProfile;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24" -DnsServer "10.1.1.1";
        $vnet = New-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Properties.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic  -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Set-AzureVMNetworkProfile -VMProfile $p;
        $p.NetworkProfile.NetworkInterfaces.Clear();
        $p = Set-AzureVMNetworkInterface -VMProfile $p -PublicIPAddressReferenceUri $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        $osDiskName = 'osDisk';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMStorageProfile -VMProfile $p -OSDiskName $osDiskName -OSDiskVHDUri $osDiskVhdUri;
        $p = Add-AzureVMDataDiskProfile -VMProfile $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 0 -VhdUri $dataDiskVhdUri1;
        $p = Add-AzureVMDataDiskProfile -VMProfile $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 1 -VhdUri $dataDiskVhdUri2;
        $p = Add-AzureVMDataDiskProfile -VMProfile $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 2 -VhdUri $dataDiskVhdUri3;
        $p = Remove-AzureVMDataDiskProfile -VMProfile $p -Name 'testDataDisk3';
        
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching 'ReadWrite';
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 0;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $p = Set-AzureVMStorageProfile -VMProfile $p -VHDContainer $vhdContainer -SourceImageName $img;

        Assert-AreEqual $p.StorageProfile.DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $p.StorageProfile.SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);

        # OS
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        
        $p = Set-AzureVMOSProfile -VMProfile $p -ComputerName $computerName -Credential $cred;
        
        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Hardware
        $vmsize = 'Standard_A2';
        $vmname = 'vm' + $rgname;

        $p = Set-AzureVMHardwareProfile -VMProfile $p -VMSize $vmsize;
        
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # Virtual Machine
        # $avsetid = '/subscriptions/84fffc2f-5d77-449a-bc7f-58c363f2a6b9/resourceGroups/pstestrg1124uw4/providers/Microsoft.Compute/availabilitySets/avset1'
        # New-AzureVM -ResourceGroupName $rgname -Location $loc  -Name $vmname -VMProfile $p -AvailabilitySetId $avsetid;
        New-AzureVM -ResourceGroupName $rgname -Location $loc  -Name $vmname -VMProfile $p;

        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $vm1.StorageProfile.DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $vm1.StorageProfile.SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);
        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VirtualMachineSize $vmsize;

        Start-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Restart-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Stop-AzureVM -Name $vmname -ResourceGroupName $rgname -Force;

        # Update
        Set-AzureVM -ResourceGroupName $rgname -Location $loc  -Name $vmname -VMProfile $p;

        $vm2 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $vm2.StorageProfile.DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $vm2.StorageProfile.SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);
        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VirtualMachineSize $vmsize;

        # Remove
        Remove-AzureVM -Name $vmname -ResourceGroupName $rgname -Force;

        Get-AzureVM -ResourceGroupName $rgname | Remove-AzureVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzureVM -ResourceGroupName $rgname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
