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
Test Virtual Machine Profile
#>
function Test-VirtualMachineProfile
{
    # Common
    $img = 'testvmimagename';
    $loc = 'East US';

    $p = New-AzureVMProfile;

    # Network
    $ipname = 'hpfip' + ((Get-Random) % 10000);
    $ipRefUri = "https://test.foo.bar/$ipname";
    $nicName = $ipname + 'nic1';
    $publicIPName = $ipname + 'name1';

    $p = Set-AzureVMNetworkProfile -VMProfile $p;
    $p = Set-AzureVMNetworkInterface -VMProfile $p -Name $nicName -PublicIPAddressName $publicIPName -PublicIPAddressReferenceUri $ipRefUri;
        
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Name $nicName;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Properties.IPConfigurations.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Properties.IPConfigurations[0].Name $publicIPName;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Properties.IPConfigurations[0].PublicIPAddress.ReferenceUri.ToString() $ipRefUri;

    # Storage
    $stoname = 'hpfteststo' + ((Get-Random) % 10000);
    $stotype = 'Standard_GRS';

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
    Assert-AreEqual $p.StorageProfile.OSDisk.VhdUri.ToString() $osDiskVhdUri;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 0;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].VhdUri.ToString() $dataDiskVhdUri1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].VhdUri.ToString() $dataDiskVhdUri2;

    $vhdContainer = "https://$stoname.blob.core.windows.net/test";
    $p = Set-AzureVMStorageProfile -VMProfile $p -VHDContainer $vhdContainer -SourceImageName $img;

    Assert-AreEqual $p.StorageProfile.DestinationVhdsContainer.ToString() $vhdContainer;
    Assert-AreEqual $p.StorageProfile.SourceImage.ReferenceUri ('/' + (Get-AzureSubscription -Current).SubscriptionId + '/services/images/' + $img);

    # OS
    $user = "Foo12";
    $password = 'BaR@000' + ((Get-Random) % 10000);
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
        
    $p = Set-AzureVMOSProfile -VMProfile $p -ComputerName $computerName -Credential $cred;
        
    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual ([System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($p.OSProfile.AdminPassword))) $password;

    # Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'hpftestvm' + ((Get-Random) % 10000);

    $p = Set-AzureVMHardwareProfile -VMProfile $p -VMSize $vmsize;
        
    Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;
}
