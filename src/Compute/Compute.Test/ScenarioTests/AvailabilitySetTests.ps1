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
        $stnd = "Standard";
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -SecurityType $stnd -AvailabilitySetId $aset.Id;
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

<#
.SYNOPSIS
Test Availability Set Migration to VMSS Flex
Note: This test requires the subscription to be enabled for the feature flag Microsoft.Compute/MigrateToVmssFlex
#>
function Test-AvailabilitySetMigration
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        if ($loc -eq $null)
        {
            $loc = Get-ComputeVMLocation;
        }
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create Availability Set
        $asetName = 'aset' + $rgname;
        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -Sku 'Aligned' -PlatformFaultDomainCount 2 -PlatformUpdateDomainCount 7;
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;

        # Create a VM in the Availability Set
        $vmname = 'vm' + $rgname;
        $vm = New-TestVmInAvailabilitySet -ResourceGroupName $rgname -Location $loc -AvailabilitySetId $aset.Id -VmName $vmname;
        $a = $vm | Out-String;
        Write-Verbose("Get-AzVM output:");
        Write-Verbose($a);
        Assert-NotNull $a

        # Create a Flexible VMSS for migration target
        $vmssName = 'vmss' + $rgname;
        $vmssConfig = New-AzVmssConfig -Location $loc -OrchestrationMode 'Flexible' -PlatformFaultDomainCount 2 -SinglePlacementGroup $false;
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmssConfig;
        Assert-NotNull $vmss;
        $vmssId = $vmss.Id;

        # Test Validate Migration cmdlet
        $validateResult = Test-AzAvailabilitySetMigration -ResourceGroupName $rgname -Name $asetName -VirtualMachineScaleSetFlexibleId $vmssId;
        Assert-NotNull $validateResult;

        # Test StartMigration cmdlet
        $migrationResult = Start-AzAvailabilitySetMigration -ResourceGroupName $rgname -Name $asetName -VirtualMachineScaleSetFlexibleId $vmssId;
        Assert-NotNull $migrationResult;

        # Migrate VM to VMSS Flex
        $migratedVM = Move-AzVirtualMachineToVmss -Id $vm.Id
        Assert-NotNull $migratedVM;

        # Test Convert cmdlet (creates a new VMSS)
       # $newVmssName = 'vmss2' + $rgname;
       # $convertResult = Convert-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -VirtualMachineScaleSetName $newVmssName;
       # Assert-NotNull $convertResult;

        Write-Host "Availability Set Migration cmdlets test completed successfully";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Availability Set Convert to VMSS Flex
Note: This test requires the subscription to be enabled for the feature flag Microsoft.Compute/ConvertToVmssFlex
#>
function Test-AvailabilitySetConvert
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        if ($loc -eq $null)
        {
            $loc = Get-ComputeVMLocation;
        }
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create Availability Set
        $asetName = 'aset' + $rgname;
        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -Sku 'Aligned' -PlatformFaultDomainCount 2 -PlatformUpdateDomainCount 5;
        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;

        # Create a VM in the Availability Set
        $vmname = 'vm' + $rgname;
        $vm = New-TestVmInAvailabilitySet -ResourceGroupName $rgname -Location $loc -AvailabilitySetId $aset.Id -VmName $vmname;
        $a = $vm | Out-String;
        Write-Verbose("Get-AzVM output:");
        Write-Verbose($a);
        Assert-NotNull $a

        # Test Convert cmdlet (creates a new VMSS)
        $newVmssName = 'vmss2' + $rgname;
        $convertResult = Convert-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -VirtualMachineScaleSetName $newVmssName;
        Assert-NotNull $convertResult;

        Write-Host "Availability Set Migration cmdlets test completed successfully";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

# Helper: Create a VM in the specified availability set
function New-TestVmInAvailabilitySet {
    param(
        [Parameter(Mandatory = $true)]
        [string] $ResourceGroupName,
        [Parameter(Mandatory = $true)]
        [string] $Location,
        [Parameter(Mandatory = $true)]
        [string] $AvailabilitySetId,
        [Parameter(Mandatory = $true)]
        [string] $VmName
    )

    # VM config assigned to Availability Set
    $vmSize = 'Standard_DS1_v2';
    $vmConfig = New-AzVMConfig -VMName $VmName -VMSize $vmSize -AvailabilitySetId $AvailabilitySetId;

    # Network
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ("subnet" + $VmName) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ("vnet" + $VmName) -ResourceGroupName $ResourceGroupName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ("vnet" + $VmName) -ResourceGroupName $ResourceGroupName;
    $subnetId = $vnet.Subnets[0].Id;

    $pubip = New-AzPublicIpAddress -Force -Name ("pubip" + $VmName) -ResourceGroupName $ResourceGroupName -Location $Location -AllocationMethod Static -DomainNameLabel ("pubip" + $VmName);
    $pubip = Get-AzPublicIpAddress -Name ("pubip" + $VmName) -ResourceGroupName $ResourceGroupName;

    $nic = New-AzNetworkInterface -Force -Name ("nic" + $VmName) -ResourceGroupName $ResourceGroupName -Location $Location -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
    $nic = Get-AzNetworkInterface -Name ("nic" + $VmName) -ResourceGroupName $ResourceGroupName;

    $vmConfig = Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;
    Assert-AreEqual $vmConfig.NetworkProfile.NetworkInterfaces.Count 1;
   
    # Minimal OS setup (test-only)
    $user = "User$($VmName.Substring(0,4))";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $vmConfig = Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $VmName -Credential $cred;

    $vmConfig = Set-AzVMSourceImage -VM $vmConfig -publisherName "MicrosoftWindowsServer" -offer "WindowsServer" -skus "2022-datacenter-g2" -version "latest";  
    #$vmConfig = ($imgRef | Set-AzVMSourceImage -VM $vmConfig);

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;
    
    New-AzVM -ResourceGroupName $ResourceGroupName -Location $Location -VM $vmConfig;
    return Get-AzVM -ResourceGroupName $ResourceGroupName -Name $VmName;
}
