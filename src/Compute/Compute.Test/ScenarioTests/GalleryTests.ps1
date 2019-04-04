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

function Verify-Gallery
{
    param($gallery, [string] $rgname, [string] $galleryName, [string] $loc, [string] $description)

        Assert-AreEqual $rgname $gallery.ResourceGroupName;
        Assert-AreEqual $galleryName $gallery.Name;
        Assert-AreEqual $loc $gallery.Location;
        Assert-AreEqual "Microsoft.Compute/galleries" $gallery.Type;
        Assert-AreEqual $description $gallery.Description;
        Assert-NotNull $gallery.Identifier.UniqueName;
        Assert-NotNull $gallery.Id;
}

function Verify-GalleryImageDefinition
{
    param($imageDefinition, [string] $rgname, [string] $imageDefinitionName, [string] $loc, [string] $description,
        [string] $eula, [string] $privacyStatementUri, [string] $releaseNoteUri,   
        [string] $osType, [string] $osState, $endOfLifeDate,
        [string] $publisherName, [string] $offerName, [string] $skuName,
        [int] $minVCPU, [int] $maxVCPU, [int] $minMemory, [int] $maxMemory, 
        [string] $disallowedDiskType,
        [string] $purchasePlanName, [string] $purchasePlanPublisher, [string] $purchasePlanProduct)

        Assert-AreEqual $rgname $imageDefinition.ResourceGroupName;
        Assert-AreEqual $imageDefinitionName $imageDefinition.Name;
        Assert-AreEqual $loc $imageDefinition.Location;
        Assert-AreEqual "Microsoft.Compute/galleries/images" $imageDefinition.Type;
        Assert-AreEqual $description $imageDefinition.Description;
        Assert-NotNull $imageDefinition.Id;

        Assert-AreEqual $eula $imageDefinition.Eula;
        Assert-AreEqual $privacyStatementUri $imageDefinition.PrivacyStatementUri;
        Assert-AreEqual $releaseNoteUri $imageDefinition.ReleaseNoteUri;
        Assert-AreEqual $osType $imageDefinition.OsType;
        Assert-AreEqual $osState $imageDefinition.OsState;
        Assert-AreEqual $endOfLifeDate $imageDefinition.EndOfLifeDate;

        Assert-AreEqual $publisherName $imageDefinition.Identifier.Publisher;
        Assert-AreEqual $offerName $imageDefinition.Identifier.Offer;
        Assert-AreEqual $skuName $imageDefinition.Identifier.Sku;

        Assert-AreEqual $minVCPU $imageDefinition.Recommended.VCPUs.Min;
        Assert-AreEqual $maxVCPU $imageDefinition.Recommended.VCPUs.Max;
        Assert-AreEqual $minMemory $imageDefinition.Recommended.Memory.Min;
        Assert-AreEqual $maxMemory $imageDefinition.Recommended.Memory.Max;

        Assert-AreEqual $disallowedDiskType $imageDefinition.Disallowed.DiskTypes[0];
        Assert-AreEqual $purchasePlanName $imageDefinition.PurchasePlan.Name;
        Assert-AreEqual $purchasePlanPublisher $imageDefinition.PurchasePlan.Publisher;
        Assert-AreEqual $purchasePlanProduct $imageDefinition.PurchasePlan.Product;
}

function Verify-GalleryImageVersion
{
    param($imageVersion, [string] $rgname, [string] $imageVersionName, [string] $loc,
        [string] $sourceImageId, [int] $replicaCount, $endOfLifeDate, $targetRegions)

        Assert-AreEqual $rgname $imageVersion.ResourceGroupName;
        Assert-AreEqual $imageVersionName $imageVersion.Name;
        Assert-AreEqual $loc $imageVersion.Location;
        Assert-AreEqual "Microsoft.Compute/galleries/images/versions" $imageVersion.Type;
        Assert-NotNull $imageVersion.Id;

        Assert-AreEqual $sourceImageId $imageVersion.PublishingProfile.Source.ManagedImage.Id;
        Assert-AreEqual $replicaCount $imageVersion.PublishingProfile.ReplicaCount;
        Assert-False { $imageVersion.PublishingProfile.ExcludeFromLatest };

        Assert-NotNull $imageVersion.PublishingProfile.PublishedDate;
        Assert-AreEqual $endOfLifeDate $imageVersion.PublishingProfile.EndOfLifeDate;

        for ($i = 0; $i -lt $targetRegions.Count; ++$i)
        {
            Assert-AreEqual $targetRegions[$i].Name $imageVersion.PublishingProfile.TargetRegions[$i].Name;

            if ($targetRegions[$i].ReplicaCount -eq $null)
            {
                Assert-AreEqual 1 $imageVersion.PublishingProfile.TargetRegions[$i].RegionalReplicaCount;
            }
            else
            {
                Assert-AreEqual $targetRegions[$i].ReplicaCount $imageVersion.PublishingProfile.TargetRegions[$i].RegionalReplicaCount;
            }
        }
}

<#
.SYNOPSIS
Testing gallery commands
#>
function Test-Gallery
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $galleryName = 'gallery' + $rgname;
    $galleryImageName = 'galleryimage' + $rgname;
    $galleryImageVersionName = 'imageversion' + $rgname;

    try
    {
        # Common
        $loc = "southcentralus";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;        
        $description1 = "Original Description";
        $description2 = "Updated Description";

        # Gallery
        New-AzGallery -ResourceGroupName $rgname -Name $galleryName -Description $description1 -Location $loc;
        
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($galleryName -replace ".$") + "*"

        $galleryList = Get-AzGallery;
        $gallery = $galleryList | ? {$_.Name -eq $galleryName};
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;

        $galleryList = Get-AzGallery -ResourceGroupName $rgname;
        $gallery = $galleryList | ? {$_.Name -eq $galleryName};
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        
        $galleryList = Get-AzGallery -ResourceGroupName $wildcardRgQuery;
        $gallery = $galleryList | ? {$_.Name -eq $galleryName};
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        
        $gallery = Get-AzGallery -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        $gallery = Get-AzGallery -Name $wildcardNameQuery;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        $gallery = Get-AzGallery -ResourceGroupName $rgname -Name $wildcardNameQuery;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        $gallery = Get-AzGallery -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        $gallery = Get-AzGallery -ResourceGroupName $wildcardRgQuery -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        $gallery = Get-AzGallery -ResourceGroupName $rgname -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;
        
        Update-AzGallery -ResourceGroupName $rgname -Name $galleryName -Description $description2;
        $gallery = Get-AzGallery -ResourceGroupName $rgname -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description2;

        # Gallery Image Definition
        $publisherName = "galleryPublisher20180927";
        $offerName = "galleryOffer20180927";
        $skuName = "gallerySku20180927";
        $eula = "eula";
        $privacyStatementUri = "https://www.microsoft.com";
        $releaseNoteUri = "https://www.microsoft.com";
        $disallowedDiskTypes = "Premium_LRS";
        $endOfLifeDate = [DateTime]::ParseExact('12 07 2025 18 02', 'HH mm yyyy dd MM', $null);
        $minMemory = 1;
        $maxMemory = 100;
        $minVCPU = 2;
        $maxVCPU = 32;
        $purchasePlanName = "purchasePlanName";
        $purchasePlanProduct = "purchasePlanProduct";
        $purchasePlanPublisher = "";
        $osState = "Generalized";
        $osType = "Linux";

        New-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName `
                                          -Location $loc -Publisher $publisherName -Offer $offerName -Sku $skuName `
                                          -OsState $osState -OsType $osType `
                                          -Description $description1 -Eula $eula `
                                          -PrivacyStatementUri $privacyStatementUri -ReleaseNoteUri $releaseNoteUri `
                                          -DisallowedDiskType $disallowedDiskTypes -EndOfLifeDate $endOfLifeDate `
                                          -MinimumMemory $minMemory -MaximumMemory $maxMemory `
                                          -MinimumVCPU $minVCPU -MaximumVCPU $maxVCPU `
                                          -PurchasePlanName $purchasePlanName `
                                          -PurchasePlanProduct $purchasePlanProduct `
                                          -PurchasePlanPublisher $purchasePlanPublisher;
                                          
        $wildcardNameQuery = ($galleryImageName -replace ".$") + "*"
        $galleryImageDefinitionList = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $wildcardNameQuery;
        $definition = $galleryImageDefinitionList | ? {$_.Name -eq $galleryImageName};
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        $definition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        $output = $definition | Out-String;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        Update-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName `
                                             -Description $description2;

        $definition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description2 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        # Gallery Image Version        
        $galleryImageVersionName = "1.0.0";
        
        # Create a VM first
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
        
        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;
        
        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
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

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Create Image using the VM's OS disk and data disks.
        $imageName = 'image' + $rgname;
        $imageConfig = New-AzImageConfig -Location $loc;
        Set-AzImageOsDisk -Image $imageConfig -OsType 'Windows' -OsState 'Generalized' -BlobUri $osDiskVhdUri;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 1 -BlobUri $dataDiskVhdUri1;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 2 -BlobUri $dataDiskVhdUri2;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 3 -BlobUri $dataDiskVhdUri2;
        Assert-AreEqual 3 $imageConfig.StorageProfile.DataDisks.Count;
        $imageConfig = Remove-AzImageDataDisk -Image $imageConfig -Lun 3;
        Assert-AreEqual 2 $imageConfig.StorageProfile.DataDisks.Count;

        $image = New-AzImage -Image $imageConfig -ImageName $imageName -ResourceGroupName $rgname
        $targetRegions = @(@{Name='South Central US';ReplicaCount=1},@{Name='East US';ReplicaCount=2},@{Name='Central US'});        
        $tag = @{test1 = "testval1"; test2 = "testval2" };

        New-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                       -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                       -Location $loc -SourceImageId $image.Id -ReplicaCount 1 `
                                       -PublishingProfileEndOfLifeDate $endOfLifeDate `
                                       -TargetRegion $targetRegions;

        $wildcardNameQuery = ($galleryImageVersionName -replace ".$") + "*"
        $galleryImageVersionList = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $wildcardNameQuery;
                                       
        $version = $galleryImageVersionList | ? {$_.Name -eq $galleryImageVersionName};
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions;

        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions;

        Update-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                          -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                          -Tag $tag;

        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions;
        $output = $version | Out-String;

        $version | Remove-AzGalleryImageVersion -Force;
        $definition | Remove-AzGalleryImageDefinition -Force;
        $gallery | Remove-AzGallery -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Testing creating VM with a shared gallery image from a different subscription.
#>
function Test-GalleryCrossTenant
{
    # Setup
    # In order to record this test, please use another subscription to create a gallery image and share the image to the test subscription.  And then set the gallery image id here.
    $imageId = "/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/xwRg/providers/Microsoft.Compute/galleries/galleryForCirrus/images/xwGalleryImageForCirrusWindows/versions/1.0.0";

    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM first
        $vmsize = 'Standard_D2_v2';
        $vmname = 'vm' + $rgname;
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;
        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId -Primary;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $p = Set-AzVMSourceImage -VM $p -Id $imageId;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $imageId $vm.StorageProfile.ImageReference.Id;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
