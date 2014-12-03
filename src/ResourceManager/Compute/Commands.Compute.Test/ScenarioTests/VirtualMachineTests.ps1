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
    $rgname = Get-ComputeTestResourceGroupName

    try
    {
        # Common
        $loc = 'West US';
        New-AzureResourceGroup -Name $rgname -Location $loc;

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
        $p.GetNetworkProfile().NetworkInterfaces.Clear();
        $p = Set-AzureVMNetworkInterface -VMProfile $p -PublicIPAddressReferenceUri $nicId;
        Assert-AreEqual $p.GetNetworkProfile().NetworkInterfaces.Count 1;
        Assert-AreEqual $p.GetNetworkProfile().NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname; }

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
        
        Assert-AreEqual $p.GetStorageProfile().OSDisk.Caching 'ReadWrite';
        Assert-AreEqual $p.GetStorageProfile().OSDisk.Name $osDiskName;
        Assert-AreEqual $p.GetStorageProfile().OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.GetStorageProfile().DataDisks.Count 2;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.GetStorageProfile().DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[0].Lun 0;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.GetStorageProfile().DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[1].Lun 1;
        Assert-AreEqual $p.GetStorageProfile().DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201410.01-en.us-127GB.vhd';
        $p = Set-AzureVMStorageProfile -VMProfile $p -VHDContainer $vhdContainer -SourceImageName $img;

        Assert-AreEqual $p.GetStorageProfile().DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $p.GetStorageProfile().SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);

        # OS
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        
        $p = Set-AzureVMOSProfile -VMProfile $p -ComputerName $computerName -Credential $cred;
        
        Assert-AreEqual $p.GetOSProfile().AdminUsername $user;
        Assert-AreEqual $p.GetOSProfile().ComputerName $computerName;
        Assert-AreEqual $p.GetOSProfile().AdminPassword $password;

        # Hardware
        $vmsize = 'Standard_A2';
        $vmname = 'vm' + $rgname;

        $p = Set-AzureVMHardwareProfile -VMProfile $p -VMSize $vmsize;
        
        Assert-AreEqual $p.GetHardwareProfile().VirtualMachineSize $vmsize;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        Retry-IfException { New-AzureVM -ResourceGroupName $rgname -Location $loc -Name $vmname -VMProfile $p; }

        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.GetNetworkProfile().NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.GetNetworkProfile().NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $vm1.GetStorageProfile().DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $vm1.GetStorageProfile().SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);
        Assert-AreEqual $vm1.GetOSProfile().AdminUsername $user;
        Assert-AreEqual $vm1.GetOSProfile().ComputerName $computerName;
        Assert-AreEqual $vm1.GetHardwareProfile().VirtualMachineSize $vmsize;

        Retry-IfException { Start-AzureVM -Name $vmname -ResourceGroupName $rgname; }
        Retry-IfException { Restart-AzureVM -Name $vmname -ResourceGroupName $rgname; }
        Retry-IfException { Stop-AzureVM -Name $vmname -ResourceGroupName $rgname -Force; }

        # Update
        Retry-IfException { Set-AzureVM -ResourceGroupName $rgname -Location $loc  -Name $vmname -VMProfile $p; }

        $vm2 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.GetNetworkProfile().NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.GetNetworkProfile().NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $vm2.GetStorageProfile().DestinationVhdsContainer.ToString() $vhdContainer;
        Assert-AreEqual $vm2.GetStorageProfile().SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);
        Assert-AreEqual $vm2.GetOSProfile().AdminUsername $user;
        Assert-AreEqual $vm2.GetOSProfile().ComputerName $computerName;
        Assert-AreEqual $vm2.GetHardwareProfile().VirtualMachineSize $vmsize;
        
        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-AreNotEqual $vms $null;

        # Remove All VMs
        Get-AzureVM -ResourceGroupName $rgname | Remove-AzureVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;

        # Availability Set
        $asetName = 'aset' + $rgname;
        New-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc;

        $asets = Get-AzureAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $aset = Get-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $asetName $aset.Name;

        $asetId = ('/subscriptions/' + (Get-AzureSubscription -Current).SubscriptionId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/availabilitySets/' + $asetName);

        $vmname2 = $vmname + '2'
        New-AzureVM -ResourceGroupName $rgname -Location $loc  -Name $vmname2 -VMProfile $p -AvailabilitySetId $asetId;

        $vm2 = Get-AzureVM -Name $vmname2 -ResourceGroupName $rgname;
        Assert-NotNull $vm2;
        
        # Remove
        Remove-AzureVM -Name $vmname2 -ResourceGroupName $rgname -Force;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
