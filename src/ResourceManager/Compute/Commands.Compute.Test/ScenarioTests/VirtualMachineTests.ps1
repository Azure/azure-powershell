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
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Adding the same Nic but not set it Primary
        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name 'testDataDisk3';
        
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;
        
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VirtualMachineSize $vmsize;

        Start-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Restart-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Stop-AzureVM -Name $vmname -ResourceGroupName $rgname -Force -StayProvisioned;

        # Update
        $p.Location = $vm1.Location;
        Update-AzureVM -ResourceGroupName $rgname -VM $p;

        $vm2 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VirtualMachineSize $vmsize;
        Assert-NotNull $vm2.Location;
        
        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-AreNotEqual $vms $null;

        # Remove All VMs
        Get-AzureVM -ResourceGroupName $rgname | Remove-AzureVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-AreEqual $vms $null;

        # Availability Set
        $asetName = 'aset' + $rgname;
        $st = New-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc;
        Assert-NotNull $st.RequestId;
        Assert-NotNull $st.StatusCode;

        $asets = Get-AzureAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;
        Assert-NotNull $asets[0].RequestId;
        Assert-NotNull $asets[0].StatusCode;

        $aset = Get-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $asetName $aset.Name;

        $asetId = ('/subscriptions/' + (Get-AzureSubscription -Current).SubscriptionId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/availabilitySets/' + $asetName);
        $vmname2 = $vmname + '2';
        $p2 = New-AzureVMConfig -VMName $vmname2 -VMSize $vmsize -AvailabilitySetId $asetId;
        $p2.HardwareProfile = $p.HardwareProfile;
        $p2.OSProfile = $p.OSProfile;
        $p2.NetworkProfile = $p.NetworkProfile;
        $p2.StorageProfile = $p.StorageProfile;
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p2;

        $vm2 = Get-AzureVM -Name $vmname2 -ResourceGroupName $rgname;
        Assert-NotNull $vm2;
        # Assert-AreEqual $vm2.AvailabilitySetReference.ReferenceUri $asetId;
        # Assert-True { $vm2.ResourceGroupName -eq $rgname }
        
        # Remove
        Remove-AzureVM -Name $vmname2 -ResourceGroupName $rgname -Force;
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
    # Setup
    $passed = $false;

    try
    {
        $s1 = Get-AzureVM;
        $s2 = Get-AzureVM;

        if ($s2 -ne $null)
        {
            Assert-NotNull $s2[0].Id;
        }

        Assert-ThrowsContains { $s3 = Get-AzureVM -NextLink "http://www.test.com/test"; } "Unexpected character"

        $passed = $true;
    }
    finally
    {
        Assert-True { $passed };
    }
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
        $pubNames = Get-AzureVMImagePublisher -Location $locStr | select -ExpandProperty PublisherName;
        $maxPubCheck = 3;
        $numPubCheck = 1;
        $pubNameFilter = '*Windows*';
        foreach ($pub in $pubNames)
        {
            # Filter Windows Images
            if (-not ($pub -like $pubNameFilter)) { continue; }

            $s2 = Get-AzureVMImageOffer -Location $locStr -PublisherName $pub;
            if ($s2.Count -gt 0)
            {
                # Check "$maxPubCheck" publishers at most
                $numPubCheck = $numPubCheck + 1;
                if ($numPubCheck -gt $maxPubCheck) { break; }

                $offerNames = $s2 | select -ExpandProperty Offer;
                foreach ($offer in $offerNames)
                {
                    $s3 = Get-AzureVMImageSku -Location $locStr -PublisherName $pub -Offer $offer;
                    if ($s3.Count -gt 0)
                    {
                        $skus = $s3 | select -ExpandProperty Skus;
                        foreach ($sku in $skus)
                        {
                            $s4 = Get-AzureVMImage -Location $locStr -PublisherName $pub -Offer $offer -Sku $sku;
                            if ($s4.Count -gt 0)
                            {
                                $versions = $s4 | select -ExpandProperty Version;

                                $s5 = Get-AzureVMImage -Location $locStr -PublisherName $pub -Offer $offer -Sku $sku -FilterExpression ('name -eq *');
                                Assert-NotNull $s5;
                                Assert-NotNull $s5.Count -gt 0;
                                $verNames = $s5 | select -ExpandProperty Version;

                                foreach ($ver in $versions)
                                {
                                    if ($ver -eq $null -or $ver -eq '') { continue; }
                                    $s6 = Get-AzureVMImage -Location $locStr -PublisherName $pub -Offer $offer -Sku $sku -Version $ver;
                                    Assert-NotNull $s6;
                                    $s6;

                                    Assert-True { $verNames -contains $ver };
                                    Assert-True { $verNames -contains $s6.Name };

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

            $s1 = Get-AzureVMExtensionImageType -Location $locStr -PublisherName $pub;
            $types = $s1 | select -ExpandProperty Type;
            if ($types.Count -gt 0)
            {
                foreach ($type in $types)
                {
                    $s2 = Get-AzureVMExtensionImage -Location $locStr -PublisherName $pub -Type $type -FilterExpression '*';
                    $versions = $s2 | select -ExpandProperty Version;
                    foreach ($ver in $versions)
                    {
                        $s3 = Get-AzureVMExtensionImage -Location $locStr -PublisherName $pub -Type $type -Version $ver -FilterExpression '*';
                
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
        $imgs = Get-AzureVMImagePublisher -Location $locStr | where { $_.PublisherName -like $pubNameFilter } | Get-AzureVMImageOffer | Get-AzureVMImageSku | Get-AzureVMImage | Get-AzureVMImage;
        Assert-True { $imgs.Count -gt 0 };

        $pubNameFilter = '*Microsoft.Compute*';
        $extimgs = Get-AzureVMImagePublisher -Location $locStr | where { $_.PublisherName -like $pubNameFilter } | Get-AzureVMExtensionImageType | Get-AzureVMExtensionImage | Get-AzureVMExtensionImage;
        Assert-True { $extimgs.Count -gt 0 };

        # Negative Tests
        # VM Images
        $s1 = Get-AzureVMImagePublisher -Location $locStr;
        Assert-NotNull $s1;

        $publisherName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s2 = Get-AzureVMImageOffer -Location $locStr -PublisherName $publisherName; } "$publisherName was not found";

        $offerName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s3 = Get-AzureVMImageSku -Location $locStr -PublisherName $publisherName -Offer $offerName; } "was not found";
        
        $skusName = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s4 = Get-AzureVMImage -Location $locStr -PublisherName $publisherName -Offer $offerName -Skus $skusName; } "was not found";

        $filter = "name eq 'latest'";
        Assert-ThrowsContains { $s5 = Get-AzureVMImage -Location $locStr -PublisherName $publisherName -Offer $offerName -Skus $skusName -FilterExpression $filter; } "was not found";

        $version = '1.0.0';
        Assert-ThrowsContains { $s6 = Get-AzureVMImage -Location $locStr -PublisherName $publisherName -Offer $offerName -Skus $skusName -Version $version; } "was not found";

        # Extension Images
        $type = Get-ComputeTestResourceName;
        Assert-ThrowsContains { $s7 = Get-AzureVMExtensionImage -Location $locStr -PublisherName $publisherName -Type $type -FilterExpression $filter -Version $version; } "was not found";

        Assert-ThrowsContains { $s8 = Get-AzureVMExtensionImageType -Location $locStr -PublisherName $publisherName; } "was not found";

        Assert-ThrowsContains { $s9 = Get-AzureVMExtensionImage -Location $locStr -PublisherName $publisherName -Type $type -FilterExpression $filter; } "was not found";

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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;

        # Availability Set
        $asetName = 'aset' + $rgname;
        New-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc;
        $aset = Get-AzureAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        # VM Profile & Hardware
        $vmsize = 'Standard_A1';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize -AvailabilitySetId $aset.Id;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name 'testDataDisk3';
        
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = Set-AzureVMSourceImage -VM $p -PublisherName $imgRef.PublisherName -Offer $imgRef.Offer -Skus $imgRef.Skus -Version $imgRef.Version;
        Assert-NotNull $p.StorageProfile.ImageReference;
        Assert-Null $p.StorageProfile.SourceImageId;

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Test Sizes
        $s1 = Get-AzureVMSize -Location ($loc -replace ' ');
        Assert-NotNull $s1;
        Assert-NotNull $s1.RequestId;
        Assert-NotNull $s1.StatusCode;
        Validate-VirtualMachineSize $vmsize $s1;

        $s2 = Get-AzureVMSize -ResourceGroupName $rgname -VMName $vmname;
        Assert-NotNull $s2;
        Validate-VirtualMachineSize $vmsize $s2;

        $asetName = $aset.Name;
        $s3 = Get-AzureVMSize -ResourceGroupName $rgname -AvailabilitySetName $asetName;
        Assert-NotNull $s3;
        Validate-VirtualMachineSize $vmsize $s3;

        # Test Usage
        $u1 = Get-AzureVMUsage -Location ($loc -replace ' ');
        Validate-VirtualMachineUsage $u1;

        $passed = $true;
    }
    finally
    {
        Assert-True { $passed };

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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name 'testDataDisk3';
        
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);
        Assert-NotNull $p.StorageProfile.ImageReference;
        Assert-Null $p.StorageProfile.SourceImageId;

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Remove
        # Remove-AzureVM -ResourceGroupName $rgname -Name $vmname -Force;
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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name 'testDataDisk3';
        
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        # TODO: Remove Data Disks for now
        $p.StorageProfile.DataDisks = $null;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Stop the VM before Capture
        Stop-AzureVM -ResourceGroupName $rgname -Name $vmname -Force;

        Set-AzureVM -Generalize -ResourceGroupName $rgname -Name $vmname;

        $dest = Get-ComputeTestResourceName;
        $templatePath = ".\template.txt";
        Save-AzureVMImage -ResourceGroupName $rgname -VMName $vmname -DestinationContainerName $dest -VHDNamePrefix 'pslib' -Overwrite -Path $templatePath;
        $template = Get-Content $templatePath;
        Assert-True { $template[1].Contains("$schema"); }

        # Remove
        Remove-AzureVM -ResourceGroupName $rgname -Name $vmname -Force;
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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Adding the same Nic but not set it Primary
        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId -Primary;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";
        $dataDiskName1 = 'testDataDisk1';
        $dataDiskName2 = 'testDataDisk2';
        $dataDiskName3 = 'testDataDisk3';

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name $dataDiskName1 -Caching 'ReadOnly' -DiskSizeInGB 5 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name $dataDiskName2 -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name $dataDiskName3 -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name $dataDiskName3;

        $p = Set-AzureVMDataDisk -VM $p -Name $dataDiskName1 -DiskSizeInGB 10;
        Assert-ThrowsContains { Set-AzureVMDataDisk -VM $p -Name $dataDiskName3 -Caching 'ReadWrite'; } "not currently assigned for this VM";

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;

        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $p.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].CreateOption 'Empty';

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;

        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;
        Assert-AreEqual $vm1.StorageProfile.DataDisks[1].CreateOption 'Empty';

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VirtualMachineSize $vmsize;

        $vm1 = Set-AzureVMDataDisk -VM $vm1 -Caching 'ReadWrite' -Lun 1;
        $vm1 = Set-AzureVMDataDisk -VM $vm1 -Name $dataDiskName2 -Caching 'ReadWrite';
        $vm1 = Add-AzureVMDataDisk -VM $vm1 -Name $dataDiskName3 -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;

        # Update
        Update-AzureVM -ResourceGroupName $rgname -VM $vm1;

        $vm2 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm2.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        Assert-AreEqual $vm2.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm2.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm2.StorageProfile.DataDisks.Count 3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Name $dataDiskName1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Caching 'ReadWrite';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].VirtualHardDisk.Uri $dataDiskVhdUri1;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[0].CreateOption 'Empty';

        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Name $dataDiskName2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Caching 'ReadWrite';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].VirtualHardDisk.Uri $dataDiskVhdUri2;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[1].CreateOption 'Empty';

        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Name $dataDiskName3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Caching 'ReadOnly';
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].DiskSizeGB 12;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].Lun 3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].VirtualHardDisk.Uri $dataDiskVhdUri3;
        Assert-AreEqual $vm2.StorageProfile.DataDisks[2].CreateOption 'Empty';

        Assert-AreEqual $vm2.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm2.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm2.HardwareProfile.VirtualMachineSize $vmsize;
        Assert-NotNull $vm2.Location;

        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-AreNotEqual $vms $null;

        # Remove All VMs
        Get-AzureVM -ResourceGroupName $rgname | Remove-AzureVM -ResourceGroupName $rgname -Force;
        $vms = Get-AzureVM -ResourceGroupName $rgname;
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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
        $p = Add-AzureVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
        $p = Remove-AzureVMDataDisk -VM $p -Name 'testDataDisk3';
        
        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        # Negative Tests on A0 Size + 2 Data Disks
        Assert-ThrowsContains { New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p; } "The maximum number of data disks allowed to be attached to a VM is 1.";
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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
        $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        $plan = Get-ComputeTestResourceName;
        $p.Plan = New-Object Microsoft.Azure.Management.Compute.Models.Plan;
        $p.Plan.Name = $plan;
        $p.Plan.Publisher = $plan;
        $p.Plan.Product = $plan;
        $p.Plan.PromotionCode = $plan;

        # Negative Tests on non-existing Plan
        Assert-ThrowsContains { New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p; } "User failed validation to purchase resources";
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
#>
function Test-VirtualMachinePlan2
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = Get-DefaultVMSize;
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = Get-DefaultStorageType;
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        # Pick a VMM Image
        $imgRef = (Get-MarketplaceImage)[0];
        $plan = $imgRef.PurchasePlan;
        $p = Set-AzureVMSourceImage -VM $p -PublisherName $imgRef.PublisherName -Offer $imgRef.Offer -Skus $imgRef.Skus -Version $imgRef.Version;
        $p.Plan = New-Object Microsoft.Azure.Management.Compute.Models.Plan;
        $p.Plan.Name = $plan.Name;
        $p.Plan.Publisher = $plan.Publisher;
        $p.Plan.Product = $plan.Product;
        $p.Plan.PromotionCode = $null;
        $p.OSProfile.WindowsConfiguration = $null;
        
        # Negative Tests on non-purchased Plan
        Assert-ThrowsContains { New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p; } "Legal terms have not been accepted for this item on this subscription";
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
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;
        
        # VM Profile & Hardware
        $vmsize = 'Standard_A0';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';

        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        # Image Reference
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        # Test Tags
        $tags = @{Name = "test1"; Value = "testval1"}, @{ Name = "test2"; Value = "testval2" };
        $st = New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p -Tags $tags;
        Assert-NotNull $st.RequestId;
        Assert-NotNull $st.StatusCode;
        $vm = Get-AzureVM -ResourceGroupName $rgname -Name $vmname;
        Assert-NotNull $vm.RequestId;
        Assert-NotNull $vm.StatusCode;

        # Assert
        Assert-AreEqual $tags[0].Value $vm.Tags[$tags[0].Name];
        Assert-AreEqual $tags[1].Value $vm.Tags[$tags[1].Name];
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
#>
function Test-VirtualMachineWithVMAgentAutoUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";
        $imgRef = Get-DefaultCRPWindowsImageOffline;

        $p = Set-AzureVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate;
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-Null $p.OSProfile.WindowsConfiguration.AdditionalUnattendContents "NULL";

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VirtualMachineSize $vmsize;

        # Remove
        Remove-AzureVM -Name $vmname -ResourceGroupName $rgname -Force;
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
#>
function Test-LinuxVirtualMachine
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A4';
        $vmname = 'vm' + $rgname;
        $p = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VirtualMachineSize $vmsize;

        # NRP
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -DnsServer "10.1.1.1" -Subnet $subnet;
        $vnet = Get-AzureVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzurePublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzurePublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $p = Set-AzureVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.VirtualHardDisk.Uri $osDiskVhdUri;

        # OS & Image
        $user = "Foo12";
        $password = 'BaR@123' + $rgname;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $imgRef = Get-DefaultCRPLinuxImageOffline;

        $p = Set-AzureVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred
        $p = ($imgRef | Set-AzureVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzureVM for SA, even it's returned in Get-.
        New-AzureVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Get VM
        $vm1 = Get-AzureVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].ReferenceUri $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VirtualMachineSize $vmsize;

        # Remove
        Remove-AzureVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

# Test Image Cmdlet Output Format
function Test-VMImageCmdletOutputFormat
{
    $locStr = Get-ComputeVMLocation;
    $imgRef = Get-DefaultCRPImage -loc $locStr;
    $publisher = $imgRef.PublisherName;
    $offer = $imgRef.Offer;
    $sku = $imgRef.Skus;
    $ver = $imgRef.Version;

    Assert-OutputContains " Get-AzureVMImagePublisher -Location $locStr" @('Id', 'Location', 'PublisherName');

    Assert-OutputContains " Get-AzureVMImagePublisher -Location $locStr | ? { `$_.PublisherName -eq `'$publisher`' } " @('Id', 'Location', 'PublisherName');

    Assert-OutputContains " Get-AzureVMImagePublisher -Location $locStr | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzureVMImageOffer " @('Id', 'Location', 'PublisherName', 'Offer');

    Assert-OutputContains " Get-AzureVMImagePublisher -Location $locStr | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzureVMImageOffer | Get-AzureVMImageSku " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku');

    Assert-OutputContains " Get-AzureVMImagePublisher -Location $locStr | ? { `$_.PublisherName -eq `'$publisher`' } | Get-AzureVMImageOffer | Get-AzureVMImageSku | Get-AzureVMImage " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'FilterExpression');

    Assert-OutputContains " Get-AzureVMImage -Location $locStr -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'FilterExpression', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');

    Assert-OutputContains " Get-AzureVMImage -Location $locStr -PublisherName $publisher -Offer $offer -Skus $sku -Version $ver " @('Id', 'Location', 'PublisherName', 'Offer', 'Sku', 'Version', 'FilterExpression', 'Name', 'DataDiskImages', 'OSDiskImage', 'PurchasePlan');
}

# Test Get VM Size from All Locations
function Test-GetVMSizeFromAllLocations
{
    $locations = Get-AzureLocation | where { $_.Name -like 'Microsoft.Compute/virtualMachines' } | select -ExpandProperty Locations;
    foreach ($loc in $locations)
    {
        $vmsizes = Get-AzureVMSize -Location $loc;
        Assert-True { $vmsizes.Count -gt 0 }
        Assert-True { ($vmsizes | where { $_.Name -eq 'Standard_A3' }).Count -eq 1 }

        Write-Output ('Found VM Size Standard_A3 in Location: ' + $loc);
    }
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
        $st = New-AzureResourceGroup -Name $rgname -Location $loc -Force;

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

        $st = New-AzureResourceGroupDeployment -Name "${rgname}dp" -ResourceGroupName $rgname -TemplateFile $templateFile -TemplateParameterFile $paramFile;

        $vms = Get-AzureVM -ResourceGroupName $rgname;
        Assert-True { $vms.Count -eq $numberOfInstances };

        $vms = Get-AzureVM;
        Assert-True { $vms.Count -ge $numberOfInstances };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
