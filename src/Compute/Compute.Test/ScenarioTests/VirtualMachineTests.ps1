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
.DESCRIPTION
SmokeTest
#>
function Test-VirtualMachine
{
    param ($loc, [bool] $hasManagedDisks = $false)
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

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;


        if($hasManagedDisks -eq $false)
        {
            $osDiskName = 'osDisk';
            $osDiskCaching = 'ReadWrite';
            $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
            $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
            $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
            $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

            $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

            $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
            $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
            $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
            $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

            Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
            Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
            Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
            Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
            Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
            Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
            Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
            Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
            Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
            Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
            Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
            Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
        }
        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus2euap" -publisherName "MicrosoftWindowsServer" -offer "WindowsServer" -skus "2012-R2-Datacenter" -version "4.127.20180315";
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint Expand;

        # VM Expand output
        $a = $vm1 | Out-String;
        Write-Verbose("Get-AzVM output:");
        Write-Verbose($a);
        Assert-NotNull $a
        Assert-True {$a.Contains("Sku");}

        # VM Compact output
        $vm1.DisplayHint = "Compact";
        $a = $vm1 | Out-String;
        Assert-NotNull $a
        Assert-False {$a.Contains("Sku");}

        # Table format output
        $a = $vm1 | Format-Table | Out-String;
        Write-Verbose("Get-AzVM | Format-Table output:");
        Write-Verbose($a);

        Assert-NotNull $vm1.VmId;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual "BGInfo" $vm1.Extensions[0].VirtualMachineExtensionType
        Assert-AreEqual "Microsoft.Compute" $vm1.Extensions[0].Publisher

        $job = Start-AzVM -Id $vm1.Id -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSComputeLongRunningOperation $st;

        $job = Restart-AzVM -Id $vm1.Id -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSComputeLongRunningOperation $st;

        $job = Stop-AzVM -Id $vm1.Id -Force -StayProvisioned -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSComputeLongRunningOperation $st;

        # Update
        $p.Location = $vm1.Location;
        Update-AzVM -ResourceGroupName $rgname -VM $p;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $null $vm2.Zones;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        $vms = Get-AzVM -ResourceGroupName $rgname;
        $a = $vms | Out-String;
        Write-Verbose("Get-AzVM (List) output:");
        Write-Verbose($a);
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($vmname -replace ".$") + "*"
        
        $vms = Get-AzVM;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -ResourceGroupName $wildcardRgQuery;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -Name $vmname;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -Name $wildcardNameQuery;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -ResourceGroupName $wildcardRgQuery -Name $vmname;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        $vms = Get-AzVM -ResourceGroupName $rgname -Name $wildcardNameQuery;
        $a = $vms | Out-String;
        Assert-NotNull $a
        Assert-True{$a.Contains("NIC");}
        Assert-AreNotEqual $vms $null;
        
        Assert-NotNull $vms[0]
        # VM Compact output
        $a = $vms[0] | Format-Custom | Out-String;
        Assert-NotNull $a
        Assert-False {$a.Contains("Sku");}

        # VM Expand output
        $vms[0].DisplayHint = "Expand";
        $a = $vms[0] | Format-Custom | Out-String;
        Assert-NotNull $a
        Assert-True {$a.Contains("Sku");}

        # Remove All VMs
        $job = Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;

        # Availability Set
        $asetName = 'aset' + $rgname;
        $asetSkuName = 'Classic';
        $UD = 3;
        $FD = 3;
        if($hasManagedDisks -eq $true)
        {
            $asetSkuName = 'Aligned';
            $FD = 2;
        }

        New-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -PlatformUpdateDomainCount $UD -PlatformFaultDomainCount $FD -Sku $asetSkuName;

        $asets = Get-AzAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $aset = Get-AzAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $asetName $aset.Name;
        Assert-AreEqual $UD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $FD $aset.PlatformFaultDomainCount;
        Assert-AreEqual $asetSkuName $aset.Sku;
        Assert-NotNull $asets[0].RequestId;
        Assert-NotNull $asets[0].StatusCode;

        $subId = Get-SubscriptionIdFromResourceGroup $rgname;

        $asetId = ('/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/availabilitySets/' + $asetName);
        $vmname2 = $vmname + '2';
        $p2 = New-AzVMConfig -VMName $vmname2 -VMSize $vmsize -AvailabilitySetId $asetId;
        $p2.HardwareProfile = $p.HardwareProfile;
        $p2.OSProfile = $p.OSProfile;
        $p2.NetworkProfile = $p.NetworkProfile;
        $p2.StorageProfile = $p.StorageProfile;

        $p2.StorageProfile.DataDisks = $null;
        if($hasManagedDisks -eq $false)
        {
            $p2.StorageProfile.OsDisk.Vhd.Uri = "https://$stoname.blob.core.windows.net/test/os2.vhd";
        }
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p2;

        $vm2 = Get-AzVM -Name $vmname2 -ResourceGroupName $rgname;
        Assert-NotNull $vm2;
        $vm2_out = $vm2 | Out-String
        Assert-True {$vm2_out.Contains("AvailabilitySetReference")};
        Assert-AreEqual $vm2.AvailabilitySetReference.Id $asetId;
        Assert-True { $vm2.ResourceGroupName -eq $rgname }

        # Remove
        $st = Remove-AzVM -Id $vm2.Id -Force;
        Verify-PSComputeLongRunningOperation $st;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineInEdgeZone
{
    $ResourceGroup = Get-ComputeTestResourceName;
    $LocationName = "eastus2euap";
    $EdgeZone = "microsoftrrdclab1";
    $VMName = "MyVM";

    try
    {
        New-AzResourceGroup -Name $ResourceGroup -Location $LocationName -Force;

        $VMLocalAdminUser = "LocalAdminUser";
        $VMLocalAdminSecurePassword = ConvertTo-SecureString $PLACEHOLDER -AsPlainText -Force;
        
        $VMSize = "Standard_B1ls";
        $ComputerName = "MyComputer";
        $NetworkName = "MyNet";
        $NICName = "MyNIC";
        $SubnetName = "MySubnet";
        $SubnetAddressPrefix = "10.0.0.0/24";
        $VnetAddressPrefix = "10.0.0.0/16";

        $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
        $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroup -Location $LocationName -EdgeZone $EdgeZone -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet;
        $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $ResourceGroup -Location $LocationName -EdgeZone $EdgeZone -SubnetId $Vnet.Subnets[0].Id;

        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

        $VirtualMachine = New-AzVMConfig -VMName $VMName -VMSize $VMSize;
        $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate;
        $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id;
        $VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName 'MicrosoftWindowsServer' -Offer 'WindowsServer' -Skus '2016-DataCenter' -Version 'latest';

        New-AzVM -ResourceGroupName $ResourceGroup -Location $LocationName -EdgeZone $EdgeZone -VM $VirtualMachine;

        $vm = Get-AzVm -ResourceGroupName $ResourceGroup -Name $VMName

        Assert-AreEqual $vm.ExtendedLocation.Name $EdgeZone;

         # validate that extendedlocation is propagated correctly in this cmdlet
        Update-AzVM -VM $vm -ResourceGroupName $ResourceGroup;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $ResourceGroup;
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachinePiping
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Add-AzVMDataDisk -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty `
             | Add-AzVMDataDisk -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual $vm1.Extensions[0].AutoUpgradeMinorVersion $true;
        Assert-AreEqual $vm1.Extensions[0].Publisher "Microsoft.Compute"
        Assert-AreEqual $vm1.Extensions[0].VirtualMachineExtensionType "BGInfo";

        $st = Get-AzVM -ResourceGroupName $rgname | Start-AzVM;
        Verify-PSComputeLongRunningOperation $st;
        $st = Get-AzVM -ResourceGroupName $rgname | Restart-AzVM;
        Verify-PSComputeLongRunningOperation $st;
        $st = Get-AzVM -ResourceGroupName $rgname | Stop-AzVM -Force -StayProvisioned;
        Verify-PSComputeLongRunningOperation $st;

        # Update VM
        Get-AzVM -ResourceGroupName $rgname -Name $vmname `
        | Add-AzVMDataDisk -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty `
        | Update-AzVM;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 3;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        Get-AzVM -ResourceGroupName $rgname | Stop-AzVM -Force;
        Get-AzVM -ResourceGroupName $rgname | Set-AzVM -Generalize;

        $dest = Get-ComputeTestResourceName;
        $templatePath = Join-Path $TestOutputRoot "template.txt";
        $job = Get-AzVM -ResourceGroupName $rgname | Save-AzVMImage -DestinationContainerName $dest -VHDNamePrefix 'pslib' -Overwrite -Path $templatePath -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSComputeLongRunningOperation $st;

        $template = Get-Content $templatePath;
        Assert-True { $template[1].Contains("$schema"); }

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -Force;
        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Update Virtual Machines without NIC (Negative Test)
#>
function Test-VirtualMachineUpdateWithoutNic
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Add-AzVMDataDisk -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty `
             | Add-AzVMDataDisk -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $job = $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual $vm1.Extensions[0].AutoUpgradeMinorVersion $true;
        Assert-AreEqual $vm1.Extensions[0].Publisher "Microsoft.Compute";
        Assert-AreEqual $vm1.Extensions[0].VirtualMachineExtensionType "BGInfo";

        # Update VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname | Remove-AzVMNetworkInterface;

        Assert-ThrowsContains { Update-AzVM -ResourceGroupName $rgname -VM $vm; } "must have at least one network interface"
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
function Test-VirtualMachineList
{
    $s1 = Get-AzVM;
    $s2 = Get-AzVM;

    if ($s2 -ne $null)
    {
        Assert-NotNull $s2[0].Id;
    }
    Assert-ThrowsContains { $s3 = Get-AzVM -NextLink "https://www.test.com/test"; } "Unable to deserialize the response"
}

<#
.SYNOPSIS
Test Virtual Machine Size and Usage
#>
function Test-VirtualMachineImageList
{
    # Setup
    $passed = $false;

    try
    {
        $locStr = Get-ComputeVMLocation;

        # List Tests
        $foundAnyImage = $false;
        $pubNames = Get-AzVMImagePublisher -Location $locStr | select -ExpandProperty PublisherName;
        $maxPubCheck = 3;
        $numPubCheck = 1;
        $pubNameFilter = '*Windows*';
        foreach ($pub in $pubNames)
        {
            # Filter Windows Images
            if (-not ($pub -like $pubNameFilter)) { continue; }

            $s2 = Get-AzVMImageOffer -Location $locStr -PublisherName $pub;
            if ($s2.Count -gt 0)
            {
                # Check "$maxPubCheck" publishers at most
                $numPubCheck = $numPubCheck + 1;
                if ($numPubCheck -gt $maxPubCheck) { break; }

                $offerNames = $s2 | select -ExpandProperty Offer;
                foreach ($offer in $offerNames)
                {
                    $s3 = Get-AzVMImageSku -Location $locStr -PublisherName $pub -Offer $offer;
                    if ($s3.Count -gt 0)
                    {
                        $skus = $s3 | select -ExpandProperty Skus;
                        foreach ($sku in $skus)
                        {
                            $s4 = Get-AzVMImage -Location $locStr -PublisherName $pub -Offer $offer -Sku $sku -Version "*";
                            if ($s4.Count -gt 0)
                            {
                                $versions = $s4 | select -ExpandProperty Version;

                                foreach ($ver in $versions)
                                {
                                    if ($ver -eq $null -or $ver -eq '') { continue; }
                                    $s6 = Get-AzVMImage -Location $locStr -PublisherName $pub -Offer $offer -Sku $sku -Version $ver;
                                    Assert-NotNull $s6;
                                    $s6;

                                    Assert-True { $versions -contains $ver };
                                    Assert-True { $versions -contains $s6.Name };

                                    $s6.Id;

                                    $foundAnyImage = $true;
                                }
                            }
                        }
                    }
                }
            }
        }

        Assert-True { $foundAnyImage };

        # Test Extension Image
        $foundAnyExtensionImage = $false;
        $pubNameFilter = '*Microsoft.Compute*';

        foreach ($pub in $pubNames)
        {
            # Filter Windows Images
            if (-not ($pub -like $pubNameFilter)) { continue; }

            $s1 = Get-AzVMExtensionImageType -Location $locStr -PublisherName $pub;
            $types = $s1 | select -ExpandProperty Type;
            if ($types.Count -gt 0)
            {
                foreach ($type in $types)
                {
                    $s2 = Get-AzVMExtensionImage -Location $locStr -PublisherName $pub -Type $type -FilterExpression "startswith(name,'1')" -Version "*";
                    $versions = $s2 | select -ExpandProperty Version;
                    foreach ($ver in $versions)
                    {
                        $s3 = Get-AzVMExtensionImage -Location $locStr -PublisherName $pub -Type $type -Version $ver;

                        Assert-NotNull $s3;
                        Assert-True { $s3.Version -eq $ver; }
                        $s3.Id;

                        $foundAnyExtensionImage = $true;
                    }
                }
            }
        }

        Assert-True { $foundAnyExtensionImage };

        # Test Piping
        $pubNameFilter = '*Microsoft*Windows*Server*';
        $imgs = Get-AzVMImagePublisher -Location $locStr | where { $_.PublisherName -like $pubNameFilter } | Get-AzVMImageOffer | Get-AzVMImageSku | Get-AzVMImage | Get-AzVMImage;
        Assert-True { $imgs.Count -gt 0 };

        $pubNameFilter = '*Microsoft.Compute*';
        $extimgs = Get-AzVMImagePublisher -Location $locStr | where { $_.PublisherName -like $pubNameFilter } | Get-AzVMExtensionImageType | Get-AzVMExtensionImage | Get-AzVMExtensionImage;
        Assert-True { $extimgs.Count -gt 0 };

        # Negative Tests
        # VM Images
        $s1 = Get-AzVMImagePublisher -Location $locStr;
        Assert-NotNull $s1;

        $publisherName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s2 = Get-AzVMImageOffer -Location $locStr -PublisherName $publisherName; } "$publisherName was not found";

        $offerName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s3 = Get-AzVMImageSku -Location $locStr -PublisherName $publisherName -Offer $offerName; } "was not found";

        $skusName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s4 = Get-AzVMImage -Location $locStr -PublisherName $publisherName -Offer $offerName -Skus $skusName; } "was not found";
        $version = '1.0.0';
        Assert-ThrowsContains { $s6 = Get-AzVMImage -Location $locStr -PublisherName $publisherName -Offer $offerName -Skus $skusName -Version $version; } "was not found";

        # Extension Images
        $type = Get-ComputeTestResourceName;

        Assert-ThrowsContains { $s8 = Get-AzVMExtensionImageType -Location $locStr -PublisherName $publisherName; } "was not found";

        $passed = $true;
    }
    finally
    {
        #Assert-True { $passed };
    }
}

<#
.SYNOPSIS
Test Virtual Machine Size and Usage
#>
function Test-VirtualMachineSizeAndUsage
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
        $vmsize = 'Standard_A1';
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
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage -DiskSizeInGB 200;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.OSDisk.DiskSizeGB 200;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

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
        Assert-AreEqual $vm.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $vm.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $vm.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $vm.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $vm.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $vm.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $vm.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $vm.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $vm.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # Test Sizes
        $s1 = Get-AzVMSize -Location ($loc -replace ' ');
        Assert-NotNull $s1;
        Assert-NotNull $s1.RequestId;
        Assert-NotNull $s1.StatusCode;
        Validate-VirtualMachineSize $vmsize $s1;

        $s2 = Get-AzVMSize -ResourceGroupName $rgname -VMName $vmname;
        Assert-NotNull $s2;
        Validate-VirtualMachineSize $vmsize $s2;

        $asetName = $aset.Name;
        $s3 = Get-AzVMSize -ResourceGroupName $rgname -AvailabilitySetName $asetName;
        Assert-NotNull $s3;
        Validate-VirtualMachineSize $vmsize $s3;

        # Test Usage
        $u1 = Get-AzVMUsage -Location ($loc -replace ' ');

        $usageOutput = $u1 | Out-String;
        Write-Verbose("Get-AzVMUsage: ");
        Write-Verbose($usageOutput);
        $usageOutput =  $u1 | Out-String;
        Write-Verbose("Get-AzVMUsage | Format-Custom : ");
        $usageOutput =  $u1 | Format-Custom | Out-String;
        Write-Verbose($usageOutput);
        Validate-VirtualMachineUsage $u1;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Validate-VirtualMachineSize
{
    param([string] $vmSize, $vmSizeList)

    $count = 0;

    foreach ($item in $vmSizeList)
    {
        if ($item.Name -eq $vmSize)
        {
            $count = $count + 1;
        }
    }

    $valid = $count -eq 1;

    return $valid;
}

function Validate-VirtualMachineUsage
{
    param($vmUsageList)

    $valid = $true;

    foreach ($item in $vmUsageList)
    {
        Assert-NotNull $item;
        Assert-NotNull $item.Name;
        Assert-NotNull $item.Name.Value;
        Assert-NotNull $item.Name.LocalizedValue;
        Assert-True { $item.CurrentValue -le $item.Limit };
        Assert-NotNull $item.RequestId;
        Assert-NotNull $item.StatusCode;
    }

    return $valid;
}

<#
.SYNOPSIS
Test Virtual Machines with PIR v2
#>
function Test-VirtualMachinePIRv2
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
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
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
        Assert-NotNull $p.StorageProfile.ImageReference;
        Assert-Null $p.StorageProfile.SourceImageId;

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Remove
        # Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Capture
#>
function Test-VirtualMachineCapture
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Stop the VM before Capture
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force;

        Set-AzVM -Generalize -ResourceGroupName $rgname -Name $vmname;

        $dest = Get-ComputeTestResourceName;
        $templatePath = Join-Path $TestOutputRoot "template.txt";
        $st = Save-AzVMImage -ResourceGroupName $rgname -VMName $vmname -DestinationContainerName $dest -VHDNamePrefix 'pslib' -Overwrite -Path $templatePath;
        $template = Get-Content $templatePath;
        Assert-True { $template[1].Contains("$schema"); }
        Verify-PSComputeLongRunningOperation $st;

        # Remove
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Capture
#>
function Test-VirtualMachineCaptureNegative
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Capture the VM without stopping.
        Assert-ThrowsContains `
            {Set-AzVM -Generalize -ResourceGroupName $rgname -Name $vmname;} `
            "Please power off";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-VirtualMachineDataDisk
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";
        $dataDiskName1 = 'testDataDisk1';
        $dataDiskName2 = 'testDataDisk2';
        $dataDiskName3 = 'testDataDisk3';

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name $dataDiskName1 -Caching 'ReadOnly' -DiskSizeInGB 5 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name $dataDiskName2 -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name $dataDiskName3 -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name $dataDiskName3;

        $p = Set-AzVMDataDisk -VM $p -Name $dataDiskName1 -DiskSizeInGB 10;
        Assert-ThrowsContains { Set-AzVMDataDisk -VM $p -Name $dataDiskName3 -Caching 'ReadWrite'; } "not currently assigned for this VM";

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;

        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $p.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].CreateOption 'Empty';

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].CreateOption 'Empty';

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        $vm1 = Set-AzVMDataDisk -VM $vm1 -Caching 'ReadWrite' -Lun 1;
        $vm1 = Set-AzVMDataDisk -VM $vm1 -Name $dataDiskName2 -Caching 'ReadWrite';
        $vm1 = Add-AzVMDataDisk -VM $vm1 -Name $dataDiskName3 -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;

        # Update
        $job = Update-AzVM -ResourceGroupName $rgname -VM $vm1 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Caching 'ReadWrite';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Caching 'ReadWrite';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].CreateOption 'Empty';

        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Name $dataDiskName3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Caching 'ReadOnly';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].DiskSizeGB 12;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Lun 3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Vhd.Uri $dataDiskVhdUri3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].CreateOption 'Empty';

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreNotEqual $vms $null;

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Data Disks Negative
#>
function Test-VirtualMachineDataDiskNegative
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Negative Tests on A0 Size + 2 Data Disks
        Assert-ThrowsContains { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p; } "The maximum number of data disks allowed to be attached to a VM of this size is 1.";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Plan
#>
function Test-VirtualMachinePlan
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        $plan = Get-ComputeTestResourceName;
        $p = Set-AzVMPlan -VM $p -Name $plan -Publisher $plan -Product $plan -PromotionCode $plan;

        # Negative Tests on non-existing Plan
        Assert-ThrowsContains { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p; } "User failed validation to purchase resources";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}



<#
.SYNOPSIS
Test Virtual Machines Plan 2
.Description
AzureAutomationTest
#>
function Test-VirtualMachinePlan2
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = Get-DefaultVMSize;
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = Get-DefaultStorageType;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        # Pick a VMM Image
        $imgRef = Get-FirstMarketplaceImage;
        $plan = $imgRef.PurchasePlan;
        $p = Set-AzVMSourceImage -VM $p -PublisherName $imgRef.PublisherName -Offer $imgRef.Offer -Skus $imgRef.Skus -Version $imgRef.Version;
        $p = Set-AzVMPlan -VM $p -Name $plan.Name -Publisher $plan.Publisher -Product $plan.Product;
        $p.OSProfile.WindowsConfiguration = $null;

        # Negative Tests on non-purchased Plan
        Assert-ThrowsContains { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p; } "Legal terms have not been accepted for this item on this subscription";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Virtual Machines Tags
#>
function Test-VirtualMachineTags
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Test Tags
        $tags = @{test1 = "testval1"; test2 = "testval2" };
        $st = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p -Tag $tags;
        #Assert-NotNull $st.RequestId;
        Assert-NotNull $st.StatusCode;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        $a = $vm | Out-String;
        Write-Verbose("Get-AzVM output:");
        Write-Verbose($a);

        Assert-NotNull $vm.RequestId;
        Assert-NotNull $vm.StatusCode;

        # Assert
        Assert-AreEqual "testval1" $vm.Tags["test1"];
        Assert-AreEqual "testval2" $vm.Tags["test2"];

        # Update VM
        $vm = $vm | Update-AzVM;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        Assert-NotNull $vm.RequestId;
        Assert-NotNull $vm.StatusCode;
        Assert-AreEqual "testval1" $vm.Tags["test1"];
        Assert-AreEqual "testval2" $vm.Tags["test2"];

        # Update VM with new Tags
        $new_tags = @{test1 = "testval3"; test2 = "testval4" };
        $st = $vm | Update-AzVM -Tag $new_tags;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        Assert-NotNull $vm.RequestId;
        Assert-NotNull $vm.StatusCode;
        Assert-AreEqual "testval3" $vm.Tags["test1"];
        Assert-AreEqual "testval4" $vm.Tags["test2"];

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines with VMAgent and AutoUpdate
.Description
AzureAutomationTest
#>
function Test-VirtualMachineWithVMAgentAutoUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $imgRef = Get-DefaultCRPWindowsImageOffline;

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-Null $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent "NULL";

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Remove
        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines with VMAgent and AutoUpdate
.Description
AzureAutomationTest
#>
function Test-LinuxVirtualMachine
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $imgRef = Get-DefaultCRPLinuxImageOffline;

        $p = Set-AzVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Remove
        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

# Test Image Cmdlet Output Format
<#
.Description
AzureAutomationTest
#>
function Test-VMImageCmdletOutputFormat
{
    $locStr = Get-ComputeVMLocation;
    $imgRef = Get-DefaultCRPImage -loc $locStr;
    $publisher = $imgRef.PublisherName;
    $offer = $imgRef.Offer;
    $sku = $imgRef.Skus;
    $ver = $imgRef.Version;

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr'" @('Id', 'Location', 'PublisherName');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } " @('Id', 'Location', 'PublisherName');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer " @('Id', 'Location', 'PublisherName', 'Offer');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer | Get-AzVMImageSku " @('Publisher', 'Offer', 'Skus');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer | Get-AzVMImageSku | Get-AzVMImage " @('Version', 'Skus');

    Assert-OutputContains " Get-AzVMImage -Location '$locStr' -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');

    Assert-OutputContains " Get-AzVMImage -Location '$locStr' -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');
}

# Test Image Cmdlet Output Format with EdgeZone
<#
.Description
AzureAutomationTest
#>
function Test-VMImageEdgeZoneCmdletOutputFormat
{
    $locStr = "westus"; 
    $publisher = "MicrosoftWindowsServer";
    $offer = "WindowsServer";
    $sku = "2016-Datacenter";
    $ver = "14393.4048.2011170655";
    $edgeZone = "microsoftlosangeles1";

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer -EdgeZone '$edgeZone' | Select EdgeZone, Location " @('microsoftlosangeles1', 'westus');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer -EdgeZone '$edgeZone'| Get-AzVMImageSku " @('Publisher', 'Offer', 'Skus');

    Assert-OutputContains " Get-AzVMImagePublisher -Location '$locStr' | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzVMImageOffer -EdgeZone '$edgeZone' | Get-AzVMImageSku | Get-AzVMImage " @('Version', 'Skus');

    Assert-OutputContains " Get-AzVMImage -Location '$locStr' -EdgeZone '$edgeZone' -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');

    Assert-OutputContains " Get-AzVMImage -Location '$locStr' -EdgeZone '$edgeZone' -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');
}

# Test Get VM Size from All Locations
function Test-GetVMSizeFromAllLocations
{
    $locations = get_all_vm_locations;
    foreach ($loc in $locations)
    {
        $vmsizes = Get-AzVMSize -Location $loc;
        Assert-True { $vmsizes.Count -gt 0 }
        Assert-True { ($vmsizes | where { $_.Name -eq 'Standard_A3' }).Count -eq 1 }

        Write-Output ('Found VM Size Standard_A3 in Location: ' + $loc);
    }
}

function get_all_vm_locations
{
    if ((Get-ComputeTestMode) -ne 'Playback')
    {
        $namespace = "Microsoft.Compute"
        $type = "virtualMachines"
        $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

        if ($location -eq $null)
        {
            return @("East US")
        }
        else
        {
            return $location.Locations
        }
    }

    return @("East US")
}

<#
.SYNOPSIS
Test Virtual Machine List with Paging
#>
function Test-VirtualMachineListWithPaging
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeDefaultLocation;
        $st = New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $numberOfInstances = 51;
        $vmSize = 'Standard_A0';

        $templateFile = ".\Templates\azuredeploy.json";
        $paramFile = ".\Templates\azuredeploy-parameters-51vms.json";
        $paramContent =
@"
{
  "newStorageAccountName": {
    "value": "${rgname}sto"
  },
  "adminUsername": {
    "value": "Foo12"
  },
  "adminPassword": {
    "value": "BaR@123${rgname}"
  },
  "numberOfInstances": {
    "value": $numberOfInstances
  },
  "location": {
    "value": "$loc"
  },
  "vmSize": {
    "value": "$vmSize"
  }
}
"@;

        $st = Set-Content -Path $paramFile -Value $paramContent -Force;
        $st = New-AzResourceGroupDeployment -Name $rgname -ResourceGroupName $rgname -TemplateFile $templateFile -TemplateParameterFile $paramFile;

        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-True { $vms.Count -eq $numberOfInstances };

        $vms = Get-AzVM -Location $loc;
        Assert-True { $vms.Count -ge $numberOfInstances };

        $vms = Get-AzVM;
        Assert-True { $vms.Count -ge $numberOfInstances };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineWithDifferentStorageResource
{
    # Setup
    $rgname = Get-ComputeTestResourceName
    $rgname_storage = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        New-AzResourceGroup -Name $rgname_storage  -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname_storage -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname_storage -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual $true $vm1.DiagnosticsProfile.BootDiagnostics.Enabled;
        Assert-AreEqual $stoaccount.PrimaryEndpoints.Blob $vm1.DiagnosticsProfile.BootDiagnostics.StorageUri;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname_storage
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineWithPremiumStorageAccount
{
    # Setup
    $rgname = Get-ComputeTestResourceName
    $rgname_storage = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        # Create a Storage Account in a difference resource group
        New-AzResourceGroup -Name $rgname_storage  -Location $loc -Force;
        $stoname1 = 'sto' + $rgname_storage;
        $stotype1 = 'Standard_GRS';
        $stoaccount1 = New-AzStorageAccount -ResourceGroupName $rgname_storage -Name $stoname1 -Location $loc -Type $stotype1;

        # Create a resource group
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a premium Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $stoaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual $true $vm1.DiagnosticsProfile.BootDiagnostics.Enabled;
        Assert-AreNotEqual $stoaccount.PrimaryEndpoints.Blob $vm1.DiagnosticsProfile.BootDiagnostics.StorageUri;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname_storage
    }
}


<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineWithEmptyAuc
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        Assert-AreEqual $true $vm1.DiagnosticsProfile.BootDiagnostics.Enabled;
        Assert-AreEqual $stoaccount.PrimaryEndpoints.Blob $vm1.DiagnosticsProfile.BootDiagnostics.StorageUri;

        # Update VM with an empty additional unattend content
        $vm1 = Set-AzVMDataDisk -VM $vm1 -Name 'testDataDisk1' -Caching 'None'

        $aucSetting = "AutoLogon";
        $aucContent = "<UserAccounts><AdministratorPassword><Value>" + $password + "</Value><PlainText>true</PlainText></AdministratorPassword></UserAccounts>";
        $vm1 = Add-AzVMAdditionalUnattendContent -VM $vm1 -Content $aucContent -SettingName $aucSetting;
        [System.Collections.Generic.List[Microsoft.Azure.Management.Compute.Models.AdditionalUnattendContent]]$emptyAUC=@();
        $vm1.OSProfile.WindowsConfiguration.AdditionalUnattendContent.RemoveAt(0)

        # Verify Additional Unattend Content
        Assert-NotNull $vm1.OSProfile.WindowsConfiguration.AdditionalUnattendContent;
        Assert-AreEqual 0 $vm1.OSProfile.WindowsConfiguration.AdditionalUnattendContent.Count;

        Update-AzVM -ResourceGroupName $rgname -VM $vm1;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        Assert-AreEqual $true $vm2.DiagnosticsProfile.BootDiagnostics.Enabled;
        Assert-AreEqual $stoaccount.PrimaryEndpoints.Blob $vm2.DiagnosticsProfile.BootDiagnostics.StorageUri;

        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreNotEqual $vms $null;

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineWithBYOL
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = "mybyolosimage";

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $userImageUrl = "https://$stoname.blob.core.windows.net/vhdsrc/win2012-tag0.vhd";

        $p = Set-AzVMOSDisk -VM $p -Windows -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -SourceImage $userImageUrl -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $licenseType = "Windows_Server";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -LicenseType $licenseType -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        $output = $vm1 | Out-String;
        Write-Verbose ('Output String   : ' + $output);
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;
        Assert-AreEqual $vm1.LicenseType $licenseType;

        Assert-AreEqual $true $vm1.DiagnosticsProfile.BootDiagnostics.Enabled;

        Get-AzVM -ResourceGroupName $rgname -Name $vmname `
        | Add-AzVMDataDisk -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri2 -CreateOption Empty `
        | Update-AzVM;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 2;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-AreEqual $vm2.LicenseType $licenseType;
        Assert-NotNull $vm2.Location;

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Redeploy
#>
function Test-VirtualMachineRedeploy
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 2;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        # Redeploy the VM
        $job = Set-AzVM -Id $vm2.Id -Redeploy -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 2;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        # Remove
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines Reapply
#>
function Test-VirtualMachineReapply
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";


        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Create a Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname -DisplayHint Expand;

        Assert-AreEqual $vmname $vm.Name;
        Assert-AreEqual "Succeeded" $vm.ProvisioningState;

        # Reapply the VM
        $job = Set-AzVM -Id $vm.Id -Reapply -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm2 = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        Assert-AreEqual $vmname $vm2.Name;
        Assert-AreEqual "Succeeded" $vm2.ProvisioningState;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineGetStatus
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

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        $a = $vm1 | Out-String;
        Write-Verbose("Get-AzVM output:");
        Write-Verbose($a);
        $a = $vm1 | Format-Table | Out-String;
        Write-Verbose("Get-AzVM | Format-Table output:");
        Write-Verbose($a);

        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname -Status;

        $a = $vm | Out-String;
        Write-Verbose($a);
        Assert-True {$a.Contains("Statuses");}

        $vms = Get-AzVM -ResourceGroupName $rgname -Status;
        Assert-AreEqual "VM running" ($vms | ? {$_.Name -eq $vmname}).PowerState;
        $a = $vms | Out-String;
        Write-Verbose($a);
        Assert-True {$a.Contains("VM running")};

        $vms = Get-AzVM -Status;
        Assert-AreEqual "VM running" ($vms | ? {$_.Name -eq $vmname}).PowerState;
        $a = $vms | Out-String;
        Write-Verbose($a);
        Assert-True {$a.Contains("VM running")};

        # VM Compact output
        $a = $vms[0] | Format-Custom | Out-String;
        Assert-False{$a.Contains("Sku");};

        # VM Expand output
        $vms[0].DisplayHint = "Expand"
        $a = $vms[0] | Format-Custom | Out-String;
        Assert-True{$a.Contains("Sku");};

        # Remove
        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines's Status With Health Extension
Description:
This test creates a virtual machine and adds a vm health extension
and gets the virtual machine with -Status flag which returns the instance
view of the virtual machine. Since the vm has a health extension,
the vm's instance view should have the "vmHealth" field present in its return
object.
#>
function Test-VirtualMachineGetStatusWithHealhtExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;

        # OS & Image
        $username = "admin01";
        $password = $PLACEHOLDER | ConvertTo-SecureString -AsPlainText -Force;
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password;
        [string]$domainNameLabel = "vcrptestps7691-6f2166";
        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -DomainNameLabel $domainNameLabel -Name $vmname -Credential $cred -Size $vmsize;

        # Adding health extension on VM
        $publicConfig = @{"protocol" = "http"; "port" = 80; "requestPath" = "/healthEndpoint"};
        $extensionName = "myHealthExtension"
        $extensionType = "ApplicationHealthWindows"
        $publisher = "Microsoft.ManagedServices"
        Set-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Publisher $publisher -Settings $publicConfig -ExtensionType $extensionType -ExtensionName $extensionName -Loc $loc -TypeHandlerVersion "1.0"

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname -Status;

        # Check for VmHealth Property
        Assert-NotNull $vm.VMHealth
        Assert-NotNull $vm.VMHealth.Status
        Assert-NotNull $vm.VMHealth.Status.Code
        Assert-NotNull $vm.VMHealth.Status.Level
        Assert-NotNull $vm.VMHealth.Status.DisplayStatus
        Assert-NotNull $vm.VMHealth.Status.Time

        # Remove
        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machines
#>
function Test-VirtualMachineGetStatusWithAssignedHost
{
    param ($loc)
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        $loc = $loc.Replace(' ', '');
        
        # Creating the resource group
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Hostgroup and Hostgroupname
        $hostGroupName = $rgname + "HostGroup"
        $hostGroup = New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 2 -Zone "2" -SupportAutomaticPlacement $true -Tag @{key1 = "val1"};


        $Sku = "Esv3-Type1"
        $hostName = $rgname + "Host"
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku $Sku -PlatformFaultDomain 1 -Tag @{test = "true"}
        
        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname = $rgname + 'Vm';

        # Creating a VM using simple parameter set
        $user = "Foo2";
        $password = Get-PasswordForVM
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        
        New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel "crptestps2532vm-1d1de" -HostGroupId $hostGroup.Id;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status
        $a = $vm | Out-String

        Assert-True {$a.Contains("AssignedHost")};
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine managed disk conversion
#>
function Test-VirtualMachineManagedDiskConversion
{
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

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 2;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        Assert-Null  $vm2.StorageProfile.OSDisk.ManagedDisk
        Assert-Null  $vm2.StorageProfile.DataDisks[0].ManagedDisk
        Assert-Null  $vm2.StorageProfile.DataDisks[1].ManagedDisk

        # Deallocate the VM before conversion
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force

        # Convert VM to managed disks
        $job = ConvertTo-AzVMManagedDisk -ResourceGroupName $rgname -VMName $vmname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-NotNull  $vm2.StorageProfile.OSDisk.ManagedDisk
        Assert-NotNull  $vm2.StorageProfile.DataDisks[0].ManagedDisk
        Assert-NotNull  $vm2.StorageProfile.DataDisks[1].ManagedDisk

        # Remove
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine managed disk delete option
#>
function Test-VirtualMachineDiskDeleteOption
{
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

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage -DeleteOption "Delete";

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty  -DeleteOption "Delete";
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty  -DeleteOption "Detach";
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.OSDisk.DeleteOption "Delete";
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DeleteOption "Delete";
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DeleteOption "Detach";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].Id $nicId;
        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 2;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VmSize $vmsize;
        Assert-NotNull $vm2.Location;

        Assert-Null  $vm2.StorageProfile.OSDisk.ManagedDisk
        Assert-Null  $vm2.StorageProfile.DataDisks[0].ManagedDisk
        Assert-Null  $vm2.StorageProfile.DataDisks[1].ManagedDisk

        # Deallocate the VM before conversion
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force

        # Convert VM to managed disks
        $job = ConvertTo-AzVMManagedDisk -ResourceGroupName $rgname -VMName $vmname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm2 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-NotNull  $vm2.StorageProfile.OSDisk.ManagedDisk
        Assert-AreEqual $vm2.StorageProfile.OSDisk.DeleteOption "Delete"
        Assert-NotNull  $vm2.StorageProfile.DataDisks[0].ManagedDisk
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].DeleteOption "Delete"
        Assert-NotNull  $vm2.StorageProfile.DataDisks[1].ManagedDisk
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].DeleteOption "Detach"

        # Remove
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Performance Maintenance
#>
function Test-VirtualMachinePerformanceMaintenance
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $stoaccount = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        $vm = Get-AzVM -ResourceGroupName $rgname

        Assert-ThrowsContains {
            Restart-AzVM -PerformMaintenance -ResourceGroupName $rgname -Name $vmname; } `
            "since the Subscription of this VM is not eligible.";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Identity
#>
function Test-VirtualMachineIdentity
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -IdentityType "SystemAssigned" `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint "Expand";

        Assert-AreEqual "SystemAssigned" $vm1.Identity.Type;
        Assert-NotNull $vm1.Identity.PrincipalId;
        Assert-NotNull $vm1.Identity.TenantId;
        $vm1_output = $vm1 | Out-String;
        Write-Verbose($vm1_output);

        $vms = Get-AzVM -ResourceGroupName $rgname
        $vms_output = $vms | Out-String;
        Write-Verbose($vms_output);
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Identity Update
#>
function Test-VirtualMachineIdentityUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;

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

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOSDisk -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-Null $vm1.Identity;
        $vm1_output = $vm1 | Out-String;
        Write-Verbose($vm1_output);

        $vms = Get-AzVM -ResourceGroupName $rgname
        $vms_output = $vms | Out-String;
        Write-Verbose($vms_output);

        $st = $vm1 | Update-AzVM -IdentityType "SystemAssigned";

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint "Expand";

        Assert-AreEqual "SystemAssigned" $vm1.Identity.Type;
        Assert-NotNull $vm1.Identity.PrincipalId;
        Assert-NotNull $vm1.Identity.TenantId;
        $vm1_output = $vm1 | Out-String;
        Write-Verbose($vm1_output);

        $vms = Get-AzVM -ResourceGroupName $rgname
        $vms_output = $vms | Out-String;
        Write-Verbose($vms_output);
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Write Accelerator Update
#>
function Test-VirtualMachineWriteAcceleratorUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        $vm1_output = $vm1 | Out-String;
        Write-Verbose($vm1_output);

        Assert-ThrowsContains {
            $st = $vm1 | Update-AzVM -OsDiskWriteAccelerator $true; } `
             "not supported on disks with Write Accelerator enabled";

        $output = $error | Out-String;
        Assert-True {$output.Contains("Target");}

        $st = $vm1 | Update-AzVM -OsDiskWriteAccelerator $false;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Managed Disk
#>
function Test-VirtualMachineManagedDisk
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1';
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

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

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Assert-NotNull $vm.StorageProfile.OsDisk.ManagedDisk.Id;
        Assert-AreEqual 'Premium_LRS' $vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType;

        # Create OS snapshot from the VM
        $snapshotConfig = New-AzSnapshotConfig -SourceUri $vm.Storageprofile.OsDisk.ManagedDisk.Id -Location $loc -CreateOption Copy;
        $snapshotname = "ossnapshot";
        Update-AzSnapshot -Snapshot $snapshotConfig -SnapshotName $snapshotname -ResourceGroupName $rgname;
        $snapshot = Get-AzSnapshot -SnapshotName $snapshotname -ResourceGroupName $rgname;

        Assert-NotNull $snapshot.Id;
        Assert-AreEqual $snapshotname $snapshot.Name;
        Assert-AreEqual 'Standard_LRS' $snapshot.Sku.Name;

        # Create an OS disk from the snapshot
        $osdiskConfig = New-AzDiskConfig -Location $loc -CreateOption Copy -SourceUri $snapshot.Id;
        $osdiskname = "osdisk";
        New-AzDisk -ResourceGroupName $rgname -DiskName $osdiskname -Disk $osdiskConfig;
        $osdisk = Get-AzDisk -ResourceGroupName $rgname -DiskName $osdiskname;

        Assert-NotNull $osdisk.Id;
        Assert-AreEqual $osdiskname $osdisk.Name;
        Assert-AreEqual 'Standard_LRS' $osdisk.Sku.Name;

        # Stop the VM
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force;

        # Change the OS disk of the VM
        $vm = Set-AzVMOSDisk -VM $vm -Name $osdiskname -ManagedDiskId $osdisk.Id;

        # Create an empty disk
        $datadiskconfig = New-AzDiskConfig -Location $loc -CreateOption Empty -AccountType 'Standard_LRS' -DiskSizeGB 10;
        $datadiskname = "datadisk";
        New-AzDisk -ResourceGroupName $rgname -DiskName $datadiskname -Disk $datadiskconfig;
        $datadisk = Get-AzDisk -ResourceGroupName $rgname -DiskName $datadiskname;

        Assert-NotNull $datadisk.Id;
        Assert-AreEqual $datadiskname $datadisk.Name;
        Assert-AreEqual 'Standard_LRS' $datadisk.Sku.Name;

        # Add the disk to the VM
        $vm = Add-AzVMDataDisk -VM $vm -Name $datadiskname -ManagedDiskId $dataDisk.Id -Lun 2 -CreateOption Attach -Caching 'ReadWrite';

        # Update and start the VM
        Update-AzVM -ResourceGroupName $rgname -VM $vm;
        Start-AzVM -ResourceGroupName $rgname -Name $vmname;

        # Get the updated VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;

        Assert-NotNull $vm.VmId;
        Assert-AreEqual $vmname $vm.Name ;
        Assert-AreEqual 1 $vm.NetworkProfile.NetworkInterfaces.Count;
        Assert-AreEqual $nicId $vm.NetworkProfile.NetworkInterfaces[0].Id;

        Assert-AreEqual $imgRef.Offer $vm.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.PublisherName $vm.StorageProfile.ImageReference.Publisher;
        Assert-AreEqual $imgRef.Skus $vm.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $vm.StorageProfile.ImageReference.Version;

        Assert-AreEqual $user $vm.OSProfile.AdminUsername;
        Assert-AreEqual $computerName $vm.OSProfile.ComputerName;
        Assert-AreEqual $vmsize $vm.HardwareProfile.VmSize;

        Assert-True {$vm.DiagnosticsProfile.BootDiagnostics.Enabled;};

        Assert-AreEqual "BGInfo" $vm.Extensions[0].VirtualMachineExtensionType;
        Assert-AreEqual "Microsoft.Compute" $vm.Extensions[0].Publisher;

        Assert-AreEqual $osdisk.Id $vm.StorageProfile.OsDisk.ManagedDisk.Id;
        Assert-AreEqual 'Standard_LRS' $vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType;
        Assert-AreEqual $datadisk.Id $vm.StorageProfile.DataDisks[0].ManagedDisk.Id;
        Assert-AreEqual 'Standard_LRS' $vm.StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Reimage
#>
function Test-VirtualMachineReimage
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred `
             | Set-AzVMOSDisk -DiffDiskSetting "Local" -Caching 'ReadOnly' -CreateOption FromImage;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        $vm_output = $vm | Out-String;
        Write-Verbose($vm_output);

        Invoke-AzVMReimage -ResourceGroupName $rgname -Name $vmname -TempDisk;
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Managed Disk
#>
function Test-VirtualMachineStop
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1';
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

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

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;
        Assert-AreEqual "PowerState/running" $vmstate.Statuses[1].Code;

        # Stop the VM
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -StayProvisioned -SkipShutdown -Force;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;
        Assert-AreEqual "PowerState/stopped" $vmstate.Statuses[1].Code;

        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Managed Disk
#>
function Test-VirtualMachineRemoteDesktop
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmSize = "Standard_E64s_v3";
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -EnableUltraSSD -Zone "1";

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";

        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine

        $p.AdditionalCapabilities.UltraSSDEnabled = $false;
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-False {$vm.AdditionalCapabilities.UltraSSDEnabled};
        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;

        Assert-ThrowsContains { `
            Get-AzRemoteDesktopFile -ResourceGroupName $rgname -Name $vmname -LocalPath ".\file.rdp"; } `
            "The RDP file cannot be generated because the network interface of the virtual machine does not reference a PublicIP or an InboundNatRule of a public load balancer.";

        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -Zone "1" -Sku "Standard" -AllocationMethod "Static" -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;

        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nic | Set-AzNetworkInterfaceIpConfig -Name 'ipconfig1' -SubnetId $subnetId -PublicIpAddressId $pubip.Id | Set-AzNetworkInterface;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;

        Get-AzRemoteDesktopFile -ResourceGroupName $rgname -Name $vmname -LocalPath ".\file.rdp";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Low Priority Virtual Machine
#>
function Test-LowPriorityVirtualMachine
{
# Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -Priority 'Low' -EvictionPolicy 'Deallocate' -MaxPrice 0.1538;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Create a Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname -DisplayHint Expand;
        Assert-AreEqual "Low" $vm.Priority;
        Assert-AreEqual "Deallocate" $vm.EvictionPolicy;
        Assert-AreEqual 0.1538 $vm.BillingProfile.MaxPrice;
        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;
        Assert-AreEqual "PowerState/running" $vmstate.Statuses[1].Code;

        Set-AzVM -ResourceGroupName $rgname -Name $vmname -SimulateEviction;

        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual "Low" $vm.Priority;
        Assert-AreEqual "Deallocate" $vm.EvictionPolicy;
        Assert-AreEqual 0.1538 $vm.BillingProfile.MaxPrice;

        $vmstate = Get-AzVM -ResourceGroupName $rgname -Name $vmname -Status;
        Assert-AreEqual "PowerState/running" $vmstate.Statuses[1].Code;

        # Update the max price of the VM
        Assert-ThrowsContains { Update-AzVM -ResourceGroupName $rgname -VM $vm -MaxPrice 0.2; } `
            "Max price change is not allowed.";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test EncryptionAtHost Virtual Machine
#>
function Test-EncryptionAtHostVMNull
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel;
        Assert-AreEqual $null $vm.SecurityProfile.encryptionathost

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $null $vm.SecurityProfile.encryptionAtHost
        Assert-AreEqual $null $vm.encryptionAtHost

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test EncryptionAtHost Virtual Machine
#>
function Test-EncryptionAtHostVM
{
# Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware

        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -EncryptionAtHost;

        # Get VM
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual True $vm.SecurityProfile.encryptionAtHost
        Assert-ThrowsContains { Update-AzVM -ResourceGroupName $rgname -VM $vm -EncryptionAtHost $false; } "can be updated only when VM is in deallocated state"
        
        #update vm with encryptionathost false
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
        Update-AzVM -ResourceGroupName $rgname -VM $vm -EncryptionAtHost $false;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual False $vm.SecurityProfile.encryptionAtHost
        
        #update vm with encryptionathost false
        Update-AzVM -ResourceGroupName $rgname -VM $vm -EncryptionAtHost $true;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual True $vm.SecurityProfile.encryptionAtHost
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Test EncryptionAtHost Virtual Machine Default Param Set
#>
function Test-EncryptionAtHostVMDefaultParamSet
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -EncryptionAtHost;

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
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual True $vm.SecurityProfile.encryptionAtHost

        # Remove
        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzVMOperatingSystem
#>
function Test-SetAzVMOperatingSystem
{
# Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;
        $vmname2 = 'vm2' + $rgname;
        $vmname3 = 'vm3' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
        $p2 = New-AzVMConfig -VMName $vmname2 -VMSize $vmsize;
        $p3 = New-AzVMConfig -VMName $vmname3 -VMSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        #1
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;
        #2
        $pubip2 = New-AzPublicIpAddress -Force -Name ('pubip2' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip2' + $rgname);
        $pubip2 = Get-AzPublicIpAddress -Name ('pubip2' + $rgname) -ResourceGroupName $rgname;
        $pubipId2 = $pubip2.Id;
        $nic2 = New-AzNetworkInterface -Force -Name ('nic2' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip2.Id;
        $nic2 = Get-AzNetworkInterface -Name ('nic2' + $rgname) -ResourceGroupName $rgname;
        $nicId2 = $nic2.Id;
        #3
        $pubip3 = New-AzPublicIpAddress -Force -Name ('pubip3' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip3' + $rgname);
        $pubip3 = Get-AzPublicIpAddress -Name ('pubip3' + $rgname) -ResourceGroupName $rgname;
        $pubipId3 = $pubip3.Id;
        $nic3 = New-AzNetworkInterface -Force -Name ('nic3' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip3.Id;
        $nic3 = Get-AzNetworkInterface -Name ('nic3' + $rgname) -ResourceGroupName $rgname;
        $nicId3 = $nic3.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
        $p2 = Add-AzVMNetworkInterface -VM $p2 -Id $nicId2;
        $p3 = Add-AzVMNetworkInterface -VM $p3 -Id $nicId3;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate:$false -PatchMode "Manual";
        $p2 = Set-AzVMOperatingSystem -VM $p2 -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate;
        $p3 = Set-AzVMOperatingSystem -VM $p3 -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate -PatchMode "AutomaticByPlatform";

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServer" -offer "WindowsServer" -skus "2012-R2-Datacenter" -version "4.127.20180315";

        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
        $p2 = ($imgRef | Set-AzVMSourceImage -VM $p2);
        $p3 = ($imgRef | Set-AzVMSourceImage -VM $p3);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p2;
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p3;

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        $vm2 = Get-AzVM -Name $vmname2 -ResourceGroupName $rgname;
        $vm3 = Get-AzVM -Name $vmname3 -ResourceGroupName $rgname;
        Assert-AreEqual $vm.osProfile.WindowsConfiguration.PatchSettings.Patchmode "Manual"
        Assert-AreEqual $vm2.osProfile.WindowsConfiguration.PatchSettings.Patchmode "AutomaticByOS"
        Assert-AreEqual $vm3.osProfile.WindowsConfiguration.PatchSettings.Patchmode "AutomaticByPlatform"


        #updating existing VM using Set-AzVMOperatingSystem    "AutomaticByPlatform -> AutomaticByOS"
        $vm3 = Set-AzVMOperatingSystem -VM $vm3 -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate -PatchMode "AutomaticByOS";
        Update-AzVM $rgname -vm $vm3;
        $vm3 = Get-AzVM -Name $vmname3 -ResourceGroupName $rgname;
        Assert-AreEqual $vm3.osProfile.WindowsConfiguration.PatchSettings.Patchmode "AutomaticByOS"

        #updating existing VM using Set-AzVMOperatingSystem    "AutomaticByOS -> AutomaticByPlatform"
        $vm2 = Set-AzVMOperatingSystem -VM $vm2 -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate -PatchMode "automaticbyplatform";
        Update-AzVM $rgname -vm $vm2;
        $vm2 = Get-AzVM -Name $vmname2 -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.osProfile.WindowsConfiguration.PatchSettings.Patchmode "AutomaticByPlatform"

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzVMOperatingSystem: if PatchMode is set to AutomaticByPlatForm, both [-ProvisionVMAgent] [-EnableAutoUpdate] has to be true, other wise it is an error.
#>
function Test-SetAzVMOperatingSystemError
{
# Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

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

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -EnableAutoUpdate -DisableVMAgent -Patchmode "AutomaticByPlatform";
      
        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";


        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
       
        # Virtual Machine
        Assert-ThrowsContains { New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p; } "The patchMode 'AutomaticByPlatform' is invalid. For patchMode 'AutomaticByPlatform', the property 'enableAutomaticUpdates' must be set to true. Also, this operation cannot be performed when extension operations are disallowed. To allow, please ensure VM Agent is installed on the VM and the osProfile.allowExtensionOperations property is true.";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test HostGroup property is set on a VM correctly when HostGroup.Id is passed as a parameter.
#>
function Test-HostGroupPropertySetOnVirtualMachine
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        $loc = $loc.Replace(' ', '');
        
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $hostGroupName = $rgname + 'hostgroup'
        $hostGroup = New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 2 -Zone "2";
        
        $hostName = $rgname + 'host'
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku "ESv3-Type1" -PlatformFaultDomain 1;

        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname0 = 'v' + $rgname;

        # Creating a VM using simple parameter set
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "vcrptestps7691-6f2166";

        $vm0 = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname0 -Credential $cred -Zone "2" -Size $vmsize -HostGroupId $hostGroup.Id -DomainNameLabel $domainNameLabel;
        
        Assert-AreEqual $hostGroup.Id $vm0.HostGroup.Id;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzVMImage new parameters -OrderBy and -Top.
#>
function Test-VirtualMachineImageListTopOrderExpand
{
    # Setup
    $loc = Get-ComputeVMLocation;

    try
    {
        $pubNames = "MicrosoftWindowsServer";
        $pubNameFilter = '*Windows*';
        $offer = "windowsserver";
        $sku = "2012-R2-Datacenter";
        $numRecords = 3;
        $orderNameDesc = "name desc";
        $orderNameAsc = "name asc";

        # Test -Top
        $vmImagesTop = Get-AzVMImage -Location $loc -PublisherName $pubNames -Offer $offer -Sku $sku -Top $numRecords;
        Assert-AreEqual $numRecords $vmImagesTop.Count; 

        # Test -OrderBy
        $vmImagesOrderDesc = Get-AzVMImage -Location $loc -PublisherName $pubNames -Offer $offer -Sku $sku -OrderBy $orderNameDesc;
        $vmImagesOrderAsc = Get-AzVMImage -Location $loc -PublisherName $pubNames -Offer $offer -Sku $sku -OrderBy $orderNameAsc;

        if ($vmImagesOrderDesc.Count -gt 0)
        {
            $isLessThan = $vmImagesOrderDesc[0].Version -ge $vmImagesOrderAsc[0].Version;
            Assert-True { $isLessThan };
        }
    }
    finally 
    {
    
	}

}

<#
.SYNOPSIS
This test can only run in Record mode. Several lines need to be uncommented for it to test the cmdlet. 
Downloads the managed boot diagnostics of a Windows machine to a local file path. 
#>
function Test-VirtualMachineBootDiagnostics
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS1_v2';
        $vmname = 'vm' + $rgname;
        # Create the file path on your machine, then set this variable to it. 
        # $localPath = "C:\Users\adsandor\Documents\bootDiags"

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        #1
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        # Windows OS test case. 
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";


        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        $vm = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        Assert-NotNull $vm;

        # Get Managed Boot Diagnostics 
        # uncomment this when running locally. 
        # Get-AzVmBootDiagnosticsData -ResourceGroupName $rgname -Name $vmname -Windows -LocalPath $localPath;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	  }
}

<#
.SYNOPSIS
Test the Get-AzVm cmdlet when using VMs with the 
same name across multiple Resource Groups. 
#>
function Test-VirtualMachineGetVMNameAcrossResourceGroups
{
    # Setup
    $loc = "eastus";
    $rgname = Get-ComputeTestResourceName;
    $rgname2 = Get-ComputeTestResourceName;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        New-AzResourceGroup -Name $rgname2 -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname1 = 'v' + $rgname;
        $vmname3 = 'v3' + $rgname;

        # Creating a VM using simple parameter set
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password

        $domainNameLabel1 = "domain1" + $rgname;
        $domainNameLabel2 = "domain2" + $rgname;
        $domainNameLabel3 = "domain3" + $rgname;

        $vm1 = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname1 -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel $domainNameLabel1;
        $vm2 = New-AzVM -ResourceGroupName $rgname2 -Location $loc -Name $vmname1 -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel $domainNameLabel2;
        $vm3 = New-AzVM -ResourceGroupName $rgname2 -Location $loc -Name $vmname3 -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel $domainNameLabel3;

        $vms = Get-AzVm -Name $vmname1 -Status;

        Assert-AreEqual 2 $vms.Count;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
        Clean-ResourceGroup $rgname2;
    }
}

<#
.SYNOPSIS

#>
function Test-VirtualMachineGetVMExtensionPiping
{
    # Setup
    $loc = "eastus";
    $rgname = Get-ComputeTestResourceName;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname = 'v' + $rgname;

        # Creating a VM using simple parameter set
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $domainNameLabel1 = "domain1" + $rgname;

        $vm1 = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel $domainNameLabel1;
        
        # No error is thrown
        $vmExt = Get-AzVM -VM $vm1 | Get-AzVMExtension;

        # Test expected error message when missing ResourceGroup. 
        $vmname2 = "errorvm";
        $vmConfig = New-AzVMConfig -Name $vmname2 -VMSize $vmsize;
        Assert-ThrowsContains {
            $vmError = $vmconfig | Get-AzVMExtension; } "The incoming virtual machine must have a 'resourceGroupName'.";
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Windows machine enable hot patching, linux machines patchmode
#>
function Test-VirtualMachinePatchAPI
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_E2s_v3';
        $vmname0 = 'v' + $rgname;

        # Creating a VM using simple parameter set
        $username = "admin01";
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password;
        [string]$domainNameLabel = "d"+ $rgname;
        $computerName = 'test';
        $patchMode = "AutomaticByPlatform";

        # EnableHotPatching for Windows machine. 
        $vm0 = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname0 -Credential $cred -Zone "2" -Size $vmsize -DomainNameLabel $domainNameLabel;
        $p = Set-AzVMOperatingSystem -VM $vm0 -Windows -ComputerName $computerName -Credential $cred -EnableHotpatching -PatchMode $patchMode;
        Assert-True {$vm0.OSProfile.WindowsConfiguration.PatchSettings.EnableHotpatching};
        Assert-AreEqual $vm0.OSProfile.WindowsConfiguration.PatchSettings.PatchMode $patchMode;

        # Test Linux VM PatchMode scenario. 
        # This currently requires creating a Linux (Ubuntu) VM manually in the Azure Portal as the DefaultCRPLinuxImageOffline cmd uses a 
        # storage account that Compute does not currently support. 
        $rgname2 = "adamddeast";
        $vmname = "linuxtest";
        $linuxvm = Get-AzVM -ResourceGroupName $rgname2 -Name $vmname;
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $user = "usertest";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $vmset = Set-AzVMOperatingSystem -VM $linuxvm -Linux -ComputerName $computerName -Credential $cred -PatchMode $patchMode;

        Assert-AreEqual $linuxvm.OSProfile.LinuxConfiguration.PatchSettings.PatchMode $patchMode;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Create VM using New-AzVM non-Default parameter set to test the hardcoded default VM size Standard_D2s_v3. 
#>
function Test-NewAzVMDefaultingSize
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "eastus";

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $defaultSize = "Standard_D2s_v3";
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM using simple parameter set
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel;
        
        Assert-NotNull $vm;
        Assert-AreEqual $vm.HardwareProfile.Vmsize $defaultSize;
        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
	}
}

<#
.SYNOPSIS

#>
function Test-InvokeAzVMInstallPatch
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "eastus";#Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname;
        $vmsize = "Standard_B1s";
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM 
        $p = New-AzVmConfig -VMName $vmname -vmsize $vmsize 

        $publisherName = "MicrosoftWindowsServer"
        $offer = "WindowsServer"
        $sku = "2019-DataCenter"
        $p = Set-AzVMSourceImage -VM $p -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest'

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel;
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $vm = New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $p
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
        
        Assert-NotNull $vm;

        $patchResult = Invoke-azvminstallpatch -VM $vm -windows -RebootSetting 'Never' -MaximumDuration PT1H -ClassificationToIncludeForWindows critical
        
        Assert-AreEqual 'Succeeded' $patchResult.Status

        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
	}
}

<#
.SYNOPSIS
Windows machine enable hot patching, linux machines patchmode
#>
function Test-VirtualMachineAssessmentMode
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname;
        $vmsize = "Standard_B1s";
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM 
        $p = New-AzVmConfig -VMName $vmname -vmsize $vmsize 

        $publisherName = "MicrosoftWindowsServer"
        $offer = "WindowsServer"
        $sku = "2019-DataCenter"
        $p = Set-AzVMSourceImage -VM $p -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest'

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel;
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $assessmentMode = "AutomaticByPlatform";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -AssessmentMode $assessmentMode;

        $vm = New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        
        Assert-NotNull $vm;

        Assert-AreEqual $vm.osProfile.WindowsConfiguration.PatchSettings.AssessmentMode "AutomaticByPlatform";
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Windows machine test ensuring the EnableAutoUpdate value on the 
provided VM is not overwritten. 
#>
function Test-VirtualMachineEnableAutoUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname;
        $vmsize = "Standard_B1s";
        $domainNameLabel = "d1" + $rgname;
        $computerName = "v" + $rgname;

        # VM Credential
        $user = "usertest";
        $password = "Testing1234567";
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Creating a VM 
        $vmConfig = New-AzVmConfig -VMName $vmname -vmsize $vmsize;
        
        $vmSet = Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $computerName -Credential $cred -provisionVMAgent -EnableAutoUpdate:$false;
        Assert-AreEqual $vmSet.OSProfile.WindowsConfiguration.EnableAutomaticUpdates $false;
        
        $vmSet2 = Set-AzVMOperatingSystem -VM $vmSet -Windows -ComputerName $computerName -Credential $cred -provisionVMAgent -EnableAutoUpdate;
        Assert-AreEqual $vmSet2.OSProfile.WindowsConfiguration.EnableAutomaticUpdates $true;

        $vmSet3 = Set-AzVMOperatingSystem -VM $vmSet2 -Windows -ComputerName $computerName -Credential $cred -provisionVMAgent;
        Assert-AreEqual $vmSet3.OSProfile.WindowsConfiguration.EnableAutomaticUpdates $true;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
} 

<#
.SYNOPSIS
Windows machine test ensuring the EnableAutoUpdate value on the 
provided VM is not overwritten. 
#>
function Test-CapacityReservation
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = 'eastus2euap';

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # create a CRG
        $CRGName = 'CRG' + $rgname
        New-AzCapacityReservationGroup -ResourceGroupName $rgname -Name $CRGName -Location $loc

        # Create 2 CR in CRG with two different skus
        $CRName1 = "cr1" + $rgname
        $Sku1 = "Standard_DS1_v2"
        $CRName2 = "cr2" + $rgname
        $Sku2 = "Standard_A2_v2"
        $cr1 = New-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName1 -Sku $Sku1 -CapacityToReserve 4 -location $loc
        $cr2 = New-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName2 -Sku $Sku2 -CapacityToReserve 4 -location $loc
        
        # try Get-CRG with InstanceView
        $CRG = Get-AzCapacityReservationGroup -ResourceGroupName $rgname -Name $CRGName -InstanceView
        Assert-AreEqual 2 $crg.InstanceView.CapacityReservations.count

        # try Get-CR  count == 2 
        $CR = Get-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName 
        Assert-AreEqual 2 $CR.count
        
        # create credential 
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Add one VM from creation 
        $vmname1 = '1' + $rgname;
        $domainNameLabel1 = "d1" + $rgname;
        $vm1 = New-AzVM -ResourceGroupName $rgname -Name $vmname1 -Credential $cred -DomainNameLabel $domainNameLabel1 -CapacityReservationGroupId $CRG.id -Size $Sku1 -Location $loc

        # Create one VM then update to associate with CRG
        $vmname2 = '2' + $rgname;
        $domainNameLabel2 = "d2" + $rgname;
        $vm2 = New-AzVM -ResourceGroupName $rgname -Name $vmname2 -Credential $cred -DomainNameLabel $domainNameLabel2 -Size $Sku2 -Location $loc
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname2 -Force
        Update-AzVm -ResourceGroupName $rgname -vm $vm2 -CapacityReservationGroupId $CRG.id

        # get instance view of CR. verify
        $vm2 = Get-AzVM -ResourceGroupName $rgname -Name $vmname2
        $cr1 = Get-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName1 -InstanceView
        $cr2 = Get-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName2 -InstanceView
        Assert-AreEqual $vm2.CapacityReservation.CapacityReservationGroup.id $CRG.id
        Assert-AreEqual $cr1.InstanceView.UtilizationInfo.VirtualMachinesAllocated.id $vm1.id
        Assert-AreEqual $cr2.VirtualMachinesAssociated[0].id $vm2.id

        # remove VMs
        Remove-AzVm -ResourceGroupName $rgname -Name $vmname1 -Force
        Remove-AzVm -ResourceGroupName $rgname -Name $vmname2 -Force

        # remove CRs
        Remove-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName1
        Remove-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName -Name $CRName2
        $CR = Get-AzCapacityReservation -ResourceGroupName $rgname -ReservationGroupName $CRGName 
        Assert-AreEqual 0 $CR.count

        # remove CRG
        Remove-AzCapacityReservationGroup -ResourceGroupName $rgname -Name $CRGName 
        $CRG = Get-AzCapacityReservationGroup -ResourceGroupName $rgname
        Assert-AreEqual 0 $CRG.count

    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
} 

function Test-VMwithSSHKey
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        
        # create credential 
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Add one VM from creation 
        $vmname = '1' + $rgname;
        $domainNameLabel = "d1" + $rgname;
        $sshKeyName = "s" + $rgname
        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -Image CentOS -DomainNameLabel $domainNameLabel -SshKeyname $sshKeyName -generateSshkey 

        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmname
        $sshKey = Get-AzSshKey -ResourceGroupName $rgname -Name $sshKeyName

        #assert compare 
        Assert-AreEqual $vm.OSProfile.LinuxConfiguration.Ssh.PublicKeys[0].KeyData $sshKey.publickey

    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
} 

<#
.SYNOPSIS
Test Virtual Machine UserData feature. 
#>
function Test-VMUserData
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $defaultSize = "Standard_D2s_v3";
        $domainNameLabel = "d1" + $rgname;

        $text = "this isvm encoded";
        $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
        $encodedText = [Convert]::ToBase64String($bytes);
        $userData = $encodedText;

        # Creating a VM using simple parameter set
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -UserData $userData;

        $vmGet = Get-AzVM -ResourceGroupName $rgname -Name $vmname -UserData;
        Assert-AreEqual $userData $vmGet.UserData;

        #Update Userdata test
        $text = "this is vm update";
        $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
        $encodedTextVMUp = [Convert]::ToBase64String($bytes);

        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
        Update-AzVM -ResourceGroupName $rgname -VM $vmGet -UserData $encodedTextVMUp;

        $vmGet2 = Get-AzVM -ResourceGroupName $rgname -Name $vmname -UserData;
        Assert-AreEqual $encodedTextVMUp $vmGet2.UserData;

        #Null UserData test
        Update-AzVm -ResourceGroupName $rgname -VM $vmGet -UserData "";
        $vmGet3 = Get-AzVM -ResourceGroupName $rgname -Name $vmname -UserData;
        Assert-Null $vmGet3.Userdata;

        #New-AzVMConfig test
        $vmname2 = 'vm2' + $rgname;
        $vmsize2 = "Standard_B1s";
        $domainNameLabel2 = "d2" + $rgname;
        $computerName2 = "v2" + $rgname;
        $identityType = "SystemAssigned";
        $text3 = "this is vm third encoded";
        $bytes3 = [System.Text.Encoding]::Unicode.GetBytes($text3);
        $encodedText3 = [Convert]::ToBase64String($bytes3);

        # Creating a VM 
        $p = New-AzVmConfig -VMName $vmname2 -vmsize $vmsize2 -Userdata $encodedText3 -IdentityType $identityType;
        Assert-AreEqual $encodedText3 $p.UserData;

        $publisherName = "MicrosoftWindowsServer"
        $offer = "WindowsServer"
        $sku = "2019-DataCenter"
        $p = Set-AzVMSourceImage -VM $p -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest'

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2;
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $vm = New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $p;
        $vmGet2 = Get-AzVM -ResourceGroupName $rgname -Name $vmname2 -UserData;
        Assert-AreEqual $encodedText3 $vmGet2.Userdata;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine UserData feature. 
#>
function Test-VMUserDataBase64Encoded
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $defaultSize = "Standard_D2s_v3";
        $domainNameLabel = "d1" + $rgname;

        $text = "this isvm encoded";
        $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
        $encodedText = [Convert]::ToBase64String($bytes);
        $userData = $encodedText;

        # Creating a VM using simple parameter set
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        Start-Transcript -Path "transcript.txt";
        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -UserData $text;
        Stop-Transcript;

        $wordToFind= "The provided UserData parameter value was not Base64 encoded.";
        $file = (Get-Content -path "transcript.txt") -join ' ';
        Assert-True { $file -match $wordToFind } ;

        $vmGet = Get-AzVM -ResourceGroupName $rgname -Name $vmname -UserData;
        Assert-AreEqual $userData $vmGet.UserData; 
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine creation process does not create a Public IP Address when it is 
not provided as a parameter. 
When using a VM Config object, this problem does not occur. 
#>
function Test-VMNoPublicIPAddress
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM using simple parameter set
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel;

        # Check that no PublicIPAddress resource was created. 
        $publicIPAddress = Get-AzPublicIpAddress -ResourceGroupName $rgname;
        Assert-Null $publicIPAddress;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Force Delete 
#>
function Test-ForceDelete
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM using simple parameterset
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel;

        Remove-AzVM -ResourceGroupName $rgname -Name $vmname -ForceDeletion $true -Force;

    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine DiffDiskPlacement feature. 
#>
function Test-VirtualMachineDiffDiskPlacement
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        ## Cache Disk Test ##
        # Common
        $loc = Get-ComputeVMLocation;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS3_v2';
        $vmname = 'vm' + $rgname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # OS & Image
        $user = "Foo12";
        $password = Get-PasswordForVM;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $diffDiskPlacement = "CacheDisk";

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $cred `
             | Set-AzVMOSDisk -DiffDiskSetting "Local" -DiffDiskPlacement $diffDiskPlacement -Caching 'ReadOnly' -CreateOption FromImage;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname -Location $loc;

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        # Validate DiffDiskPlacement
        Assert-AreEqual $vm.StorageProfile.OsDisk.DiffDiskSettings.Placement $diffDiskPlacement;


        ## Resource Disk Test ##
        $loc = "eastus2euap";
        $rgname2 = Get-ComputeTestResourceName;
        New-AzResourceGroup -Name $rgname2 -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname2;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname2) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname2) -ResourceGroupName $rgname2 -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname2) -ResourceGroupName $rgname2 -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname2);
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname2) -ResourceGroupName $rgname2 -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nicId = $nic.Id;

        # OS & Image
        $user = "Foo12";
        $password = Get-PasswordForVM;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $diffDiskPlacement = "ResourceDisk";
        $vmsize = 'Standard_B4ms';

        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize `
             | Add-AzVMNetworkInterface -Id $nicId -Primary `
             | Set-AzVMOperatingSystem -Linux -ComputerName $computerName -Credential $cred `
             | Set-AzVMOSDisk -DiffDiskSetting "Local" -DiffDiskPlacement $diffDiskPlacement -Caching 'ReadOnly' -CreateOption FromImage;# -DiskSizeInGB 30;# tried adding disksize

        # I had to create a VM and Capture an image from it to meet the size requirements for the Resource Disk value.
        # The VM I made with a source image of Ubuntu 18.04 LTS Gen 1, and size Standard_B4ms. 
        # Choose the 'Capture a managed version' option when capturing the image. 
        $imgRef = Get-AzImage -ResourceGroupName "adsandordiff" -ImageName "vmdiffubunImage";
        $imgRef | Set-AzVMSourceImage -VM $p | New-AzVM -ResourceGroupName $rgname2 -Location $loc;

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname2;

        # Validate DiffDiskPlacement
        Assert-AreEqual $vm.StorageProfile.OsDisk.DiffDiskSettings.Placement $diffDiskPlacement;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
        Clean-ResourceGroup $rgname2;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Hibernate feature.
#>
function Test-VirtualMachineHibernate
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "eastus";

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # New-AzVMConfig test
        $vmname = 'vm2' + $rgname;
        $vmsize = "Standard_B1s";
        $domainNameLabel2 = "d2" + $rgname;
        $computerName2 = "v2" + $rgname;
        $identityType = "SystemAssigned";
        $hibernationEnabled = $true;
        $hibernationDisabled = $false;

        # Creating a VM 
        $vmconfig = New-AzVmConfig -VMName $vmname -vmsize $vmsize -IdentityType $identityType -HibernationEnabled;

        $publisherName = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $sku = "2019-DataCenter";
        $vmconfig = Set-AzVMSourceImage -VM $vmconfig -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest';

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2;
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $vmconfig = Add-AzVMNetworkInterface -VM $vmconfig -Id $nicId;

        # OS & Image
        $user = "usertest";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $vmconfig = Set-AzVMOperatingSystem -VM $vmconfig -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $vmconfig;
        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $hibernationEnabled $vm.AdditionalCapabilities.HibernationEnabled;

        # Update HibernationEnabled
        $job = Stop-AzVm -ResourceGroupName $rgname -Name $vmname -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmname;
        Update-AzVm -ResourceGroupName $rgname -VM $vm -HibernationEnabled:$false;
        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $hibernationDisabled $vm.AdditionalCapabilities.HibernationEnabled;
        Update-AzVm -ResourceGroupName $rgname -VM $vm -HibernationEnabled:$true;
        
        $job = Start-AzVm -ResourceGroupName $rgname -Name $vmname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Stop with Hibernate
        $job = Stop-AzVm -ResourceGroupName $rgname -Name $vmname -Hibernate -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test the VM vCPU feature in New-AzVm, New-AzVmConfig, and Update-AzVm.
#>
function Test-VMvCPUFeatures
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "eastus";

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'v' + $rgname;
        $domainNameLabel = "d1" + $rgname;
        #$vmSize = 'Standard_DS3_v2';
        $vmSize = 'Standard_D4s_v4';
        $vCPUsCore1 = 1;
        $vCPUsAvailable1 = 1;
        $vCPUsCoreInitial = 2;
        $vCPUsAvailableInitial = 4;

        # Creating a VM using simple parameter set
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -Size $vmSize -vCPUCountPerCore $vCPUsCoreInitial -vCPUCountAvailable $vCPUsAvailableInitial;
        Assert-AreEqual $vCPUsAvailableInitial $vm.HardwareProfile.VmSizeProperties.VCPUsAvailable;
        Assert-AreEqual $vCPUsCoreInitial $vm.HardwareProfile.VmSizeProperties.VCPUsPerCore;

        $vmUp = Update-AzVm -ResourceGroupName $rgname -VM $vm -vCPUCountAvailable $vCPUsAvailable1 -vCPUCountPerCore $vCPUsCore1;

        $vmGet = Get-AzVm -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $vCPUsAvailable1 $vmGet.HardwareProfile.VmSizeProperties.VCPUsAvailable;
        Assert-AreEqual $vCPUsCore1 $vmGet.HardwareProfile.VmSizeProperties.VCPUsPerCore;


        # New-AzVMConfig test
        $vmname = 'vm2' + $rgname;
        $vmSize = 'Standard_DS3_v2';
        $domainNameLabel2 = "d2" + $rgname;
        $computerName2 = "v2" + $rgname;
        $identityType = "SystemAssigned";

        # Creating a VM 
        $vmconfig = New-AzVmConfig -VMName $vmname -vmsize $vmsize -IdentityType $identityType -vCPUCountAvailable $vCPUsAvailable1 -vCPUCountPerCore $vCPUsCore1;

        $publisherName = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $sku = "2019-DataCenter";
        $vmconfig = Set-AzVMSourceImage -VM $vmconfig -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest';

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2;
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $vmconfig = Add-AzVMNetworkInterface -VM $vmconfig -Id $nicId;

        # OS & Image
        $user = "usertest";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $vmconfig = Set-AzVMOperatingSystem -VM $vmconfig -Windows -ComputerName $computerName -Credential $cred;

        New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $vmconfig;
        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $vCPUsAvailable1 $vm.HardwareProfile.VmSizeProperties.VCPUsAvailable;
        Assert-AreEqual $vCPUsCore1 $vm.HardwareProfile.VmSizeProperties.VCPUsPerCore;
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Test GetVirtualMachineById Parameter Set
#>
function Test-GetVirtualMachineById
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'testvm2';
        $domainNameLabel = "d1" + $rgname;

        # Creating a VM using simple parameterset
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel;

        $res = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/"+$rgname+"/providers/Microsoft.Compute/virtualMachines/testvm2"
        $getvm = Get-AzVM -ResourceId $res
        Assert-NotNull $getvm
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Test GetVirtualMachineById Parameter Set
#>
function Test-VirtualMachinePlatformFaultDomain
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname;
        $domainNameLabel = "d1" + $rgname;

        $vnetname = "myVnet";
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "slb" + $rgname;
        $subnetAddress = "10.0.2.0/24";
        $vmssName = "vmss" + $rgname;
        $FaultDomainNumber = 2;
        $vmssFaultDomain = 3;

        $OSDiskName = $vmname + "-osdisk";
        $NICName = $vmname+ "-nic";
        $NSGName = $vmname + "-NSG";
        $OSDiskSizeinGB = 128;
        $VMSize = "Standard_DS2_v2";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2019-Datacenter";



        # Creating a VM using Simple parameterset
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;

        $vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

        $vmssConfig = New-AzVmssConfig -Location $loc -PlatformFaultDomainCount $vmssFaultDomain;
        $VMSS = New-AzVmss -ResourceGroupName $RGName -Name $VMSSName -VirtualMachineScaleSet $vmssConfig -Verbose;

        $nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $RGName -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
        $nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $RGName -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;

        # VM
        $vmConfig = New-AzVMConfig -VMName $vmName -VMSize $VMSize  -VmssId $VMSS.Id -PlatformFaultDomain $FaultDomainNumber  ;
        Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmName -Credential $cred ;
        Set-AzVMOSDisk -VM $vmConfig -StorageAccountType "Premium_LRS" -Caching ReadWrite -Name $OSDiskName -DiskSizeInGB $OSDiskSizeinGB -CreateOption FromImage ;
        Set-AzVMSourceImage -VM $vmConfig -PublisherName $PublisherName -Offer $Offer -Skus $SKU -Version latest ;
        Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;

        New-AzVM -ResourceGroupName $RGName -Location $loc -VM $vmConfig ;
        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmName;

        Assert-AreEqual $vm.PlatformFaultDomain $FaultDomainNumber;

        # Create VM using Default Parameter set
        $domainNameLabel = "d1" + $rgname;
        $vmnameDef = "defvm" + $rgname;
        $platformFaultDomainVMDefaultSet = 2;
        $vmDef = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -PlatformFaultDomain $platformFaultDomainVMDefaultSet -VmssId $VMSS.Id;

        Assert-AreEqual $vmDef.PlatformFaultDomain $platformFaultDomainVMDefaultSet;

    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test GuestAttestation defaulting behavior.
1) SecurityType is TrustedLaunch.
2) EnableVtpm is true.
3) EnabledSecureBoot is true.
4) DisableIntegrityMonitoring is not true.
Then this test removes the VM and recreates it with -DisableIntegrityMonitoring set to true so the
Guest Attestation extension is not installed.
#>
function Test-VirtualMachineGuestAttestation
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmname = 'vm' + $rgname;
        $domainNameLabel = "d1" + $rgname;

        $vnetname = "myVnet";
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "slb" + $rgname;
        $subnetAddress = "10.0.2.0/24";
        $OSDiskName = $vmname + "-osdisk";
        $NICName = $vmname+ "-nic";
        $NSGName = $vmname + "-NSG";
        $OSDiskSizeinGB = 128;
        $VMSize = "Standard_DS2_v2";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2022-datacenter-smalldisk-g2";
        $securityType = "TrustedLaunch";
        $secureboot = $true;
        $vtpm = $true;
        $extDefaultName = "GuestAttestation";
        $vmGADefaultIDentity = "SystemAssigned";

        # Creating a VM using Simple parameterset
        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;  
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;

        $vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

        $nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $RGName -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
        $nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $RGName -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;

        # VM
        $vmConfig = New-AzVMConfig -VMName $vmName -VMSize $VMSize;
        Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmName -Credential $cred;
        Set-AzVMSourceImage -VM $vmConfig -PublisherName $PublisherName -Offer $Offer -Skus $SKU -Version latest ;
        Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;
        $vmConfig = Set-AzVMSecurityProfile -VM $vmConfig -SecurityType $securityType;
        $vmConfig = Set-AzVmUefi -VM $vmConfig -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        New-AzVM -ResourceGroupName $RGName -Location $loc -VM $vmConfig ;
        $vm = Get-AzVm -ResourceGroupName $rgname -Name $vmName;
        $vmExt = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmName -Name $extDefaultName;

        # Assert the default extension has been installed, and the Identity.Type defaulted to SystemAssigned.
        Assert-AreEqual $vmExt.Name $extDefaultName;
        Assert-AreEqual $vm.Identity.Type $vmGADefaultIDentity;

        Remove-AzVm -ResourceGroupName $rgname -Name $vmname -Force;
        New-AzVM -ResourceGroupName $RGName -Location $loc -VM $vmConfig -DisableIntegrityMonitoring;
        Assert-ThrowsContains {
            $vmExtError = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmName -Name $extDefaultName; } "For more details please go to https://aka.ms/ARMResourceNotFoundFix";
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
