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
Test Availability Set
#>
function Test-AvailabilitySet
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $asetName = 'avs' + $rgname;
        $nonDefaultUD = 2;
        $nonDefaultFD = 3;

        $job = New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -PlatformUpdateDomainCount $nonDefaultUD -PlatformFaultDomainCount $nonDefaultFD -Sku 'Classic' -Tag @{"a"="b"} -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        for($i = 0; $i -lt 200; $i++)
        {
            $avsetname = $asetName + $i;
            New-AzAvailabilitySet -ResourceGroupName $rgname -Name $avsetname -Location $loc -PlatformUpdateDomainCount $nonDefaultUD -PlatformFaultDomainCount $nonDefaultFD -Sku 'Classic' -Tag @{"a"="b"};
        }
        
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($asetName -replace ".$") + "*"

        $asets = Get-AzAvailabilitySet;
        Assert-NotNull $asets;
        Assert-True {$asets.Count -gt 200}

        $asets = Get-AzAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $wildcardRgQuery;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -Name $wildcardNameQuery;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -Name $asetName;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $wildcardRgQuery -Name $asetName;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $wildcardNameQuery;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-AreEqual 'Classic' $aset.Sku;
        Assert-AreEqual "b" $aset.Tags["a"];

        $job = $aset | Update-AzAvailabilitySet -Sku 'Aligned' -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-AreEqual 'Aligned' $aset.Sku;

        $aset | Update-AzAvailabilitySet -Sku 'Aligned';
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-AreEqual 'Aligned' $aset.Sku;

        $job = Remove-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        $id = New-Object System.Guid;
        Assert-True { [System.Guid]::TryParse($st.RequestId, [REF] $id) };
        Assert-AreEqual "OK" $st.StatusCode;
        Assert-AreEqual "OK" $st.ReasonPhrase;
        Assert-True { $st.IsSuccessStatusCode };

        $asets = Get-AzAvailabilitySet -ResourceGroupName $rgname;
        $avset = $asets | ? {$_.Name -eq $asetName};
        Assert-Null $avset;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Size and Usage
#>
function Test-AvailabilitySetVM
{
    # Setup
    $rgname = Get-ComputeTestResourceName
    $passed = $false;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Availability Set
        $asetName = 'aset' + $rgname;
        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc;
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -AvailabilitySetId $aset.Id;
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage -DiskSizeInGB 200;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.OSDisk.DiskSizeGB 200;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;
        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = Set-AzVMSourceImage -VM $p -PublisherName $imgRef.PublisherName -Offer $imgRef.Offer -Skus $imgRef.Skus -Version $imgRef.Version;
        Assert-NotNull $p.StorageProfile.ImageReference;
        Assert-Null $p.StorageProfile.SourceImageId;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        # Validate Disks
        Assert-AreEqual $vm.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $vm.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $vm.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $vm.StorageProfile.OSDisk.DiskSizeGB 200;

        # Validate AvSet for VM reference
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset.VirtualMachinesReferences;
        Assert-True { $aset.VirtualMachinesReferences.Count -gt 0 };
        Assert-AreEqual $vm.Id $aset.VirtualMachinesReferences[0].Id;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull ($asets | ? {($_.VirtualMachinesReferences -ne $null) -and ($_.VirtualMachinesReferences[0].Id -eq $vm.Id)});

        $asets = Get-AzAvailabilitySet;
        Assert-NotNull ($asets | ? {($_.VirtualMachinesReferences -ne $null) -and ($_.VirtualMachinesReferences[0].Id -eq $vm.Id)});
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
