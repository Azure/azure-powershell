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
        [string] $purchasePlanName, [string] $purchasePlanPublisher, [string] $purchasePlanProduct,
        [string] $hyperVGeneration)

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

        if (-not [string]::IsNullOrEmpty($hyperVGeneration))
        {
            Assert-AreEqual $hyperVGeneration $imageDefinition.HyperVGeneration;
        }
}

function Verify-GalleryImageVersion
{
    param($imageVersion, [string] $rgname, [string] $imageVersionName, [string] $loc,
        [string] $sourceImageId, [int] $replicaCount, $endOfLifeDate, $targetRegions,
        $osDiskImage, $dataDiskImages)

        Assert-AreEqual $rgname $imageVersion.ResourceGroupName;
        Assert-AreEqual $imageVersionName $imageVersion.Name;
        Assert-AreEqual $loc $imageVersion.Location;
        Assert-AreEqual "Microsoft.Compute/galleries/images/versions" $imageVersion.Type;
        Assert-NotNull $imageVersion.Id;

        if (-not [string]::IsNullOrEmpty($sourceImageId))
        {
            Assert-AreEqual $sourceImageId $imageVersion.StorageProfile.Source.Id;
        }

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

        if ($osDiskImage -ne $null)
        {
            Assert-AreEqual $osDiskImage.Source.Id $imageVersion.StorageProfile.OSDiskImage.Source.Id;
        }

        for ($i = 0; $i -lt $dataDiskImages.Count; ++$i)
        {
            Assert-AreEqual $dataDiskImages[$i].Source.Id $imageVersion.StorageProfile.DataDiskImages[$i].Source.Id;
            Assert-AreEqual $dataDiskImages[$i].Lun $imageVersion.StorageProfile.DataDiskImages[$i].Lun;
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
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
        $osType = "Windows";

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
        $stnd = "Standard";
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -SecurityType $stnd;
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
        $targetRegions = @(@{Name='South Central US';ReplicaCount=1},@{Name='East US';ReplicaCount=2});
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

        $targetRegions = @(@{Name='South Central US';ReplicaCount=1},@{Name='East US';ReplicaCount=2},@{Name='Central US';StorageAccountType="Standard_ZRS"});

        Update-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                          -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                          -TargetRegion $targetRegions -Tag $tag;

        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions;
        $output = $version | Out-String;

        $version | Remove-AzGalleryImageVersion -Force;
        Wait-Seconds 300;
        $definition | Remove-AzGalleryImageDefinition -Force;
        Wait-Seconds 300;
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
        $stnd = "Standard";
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -SecurityType $stnd;

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

<#
.SYNOPSIS
Testing gallery image version commands
#>
function Test-GalleryImageVersion
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $galleryName = 'gallery' + $rgname;
    $galleryImageName = 'galleryimage' + $rgname;
    $galleryImageVersionName = 'imageversion' + $rgname;

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $description1 = "Original Description";

        # Gallery
        New-AzGallery -ResourceGroupName $rgname -Name $galleryName -Description $description1 -Location $loc;

        $gallery = Get-AzGallery -ResourceGroupName $rgname -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;

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
        $purchasePlanPublisher = "20";
        $osState = "Generalized";
        $osType = "Windows";

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

        $definition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        $output = $definition | Out-String;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        # Gallery Image Version
        $galleryImageVersionName = "1.0.0";

        # Create a VM first
        $vmsize = 'Standard_A2_v2';
        $vmname = 'vm' + $rgname;
        $stnd = "Standard";
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize -SecurityType $stnd;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;

        # Adding the same Nic but not set it Primary
        $p = Add-AzVMNetworkInterface -VM $p -Id $nic.Id -Primary;

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

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        # $p.StorageProfile.OSDisk = $null;
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred;

        $imgRef = Get-DefaultCRPImage -loc $loc -New $True;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Create Image using the VM's OS disk and data disks.
        $imageName = 'image' + $rgname;
        $imageConfig = New-AzImageConfig -Location $loc;
        Set-AzImageOsDisk -Image $imageConfig -OsType 'Windows' -OsState 'Generalized' -BlobUri $osDiskVhdUri;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 1 -BlobUri $dataDiskVhdUri1;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 2 -BlobUri $dataDiskVhdUri2;

        $image = New-AzImage -Image $imageConfig -ImageName $imageName -ResourceGroupName $rgname
        $targetRegions = @(@{Name='South Central US';ReplicaCount=1;StorageAccountType='Standard_LRS'},@{Name='East US';ReplicaCount=2},@{Name='Central US'});
        $tag = @{test1 = "testval1"; test2 = "testval2" };

        # Set TargetExtendedLocation
        $storageAccountType = "Standard_LRS"
        $extendedLocation = @{Name = 'microsoftlosangeles1';Type='EdgeZone'}
        $edgezone_losangeles = @{Location = "westus";ExtendedLocation=$extendedLocation;ReplicaCount = 3;StorageAccountType = 'StandardSSD_LRS'}
        $targetExtendedLocations = @($edgezone_losangeles)

        New-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                       -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                       -Location $loc -SourceImageId $image.Id -ReplicaCount 1 `
                                       -PublishingProfileEndOfLifeDate $endOfLifeDate `
                                       -StorageAccountType Standard_LRS `
                                       -TargetRegion $targetRegions -TargetExtendedLocation $targetExtendedLocations;

        # Check TargetExtendedLocation
        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions;
        Assert-AreEqual $version.PublishingProfile.TargetExtendedLocations.count 1

        # remove TargetExtendedLocation
        Update-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                          -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                          -Tag $tag -TargetExtendedLocation @() -AllowDeletionOfReplicatedLocation $True;

        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $image.Id 1 $endOfLifeDate $targetRegions
        # check TargetExtendedLocation count
        Assert-AreEqual $version.PublishingProfile.TargetExtendedLocations.count 0

        $version | Remove-AzGalleryImageVersion -Force;
        Wait-Seconds 300;
        $definition | Remove-AzGalleryImageDefinition -Force;
        Wait-Seconds 300;
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
Testing gallery image version with disk image parameters
#>
function Test-GalleryImageVersionDiskImage
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $galleryName = 'gallery' + $rgname;
    $galleryImageName = 'galleryimage' + $rgname;
    $galleryImageVersionName = 'imageversion' + $rgname;

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $description1 = "Original Description";

        # Gallery
        New-AzGallery -ResourceGroupName $rgname -Name $galleryName -Description $description1 -Location $loc;

        $gallery = Get-AzGallery -ResourceGroupName $rgname -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;

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
        $osType = "Windows";

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
                                          -PurchasePlanPublisher $purchasePlanPublisher `
                                          -HyperVGeneration 'V1';

        $definition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        $output = $definition | Out-String;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct 'V1';

        # Gallery Image Version
        $galleryImageVersionName = "1.0.0";

        $snapshotname1 = 'ossnapshot' + $rgname;
        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -HyperVGeneration "V1";
        $snapshot1 = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname1 -Snapshot $snapshotconfig

        $snapshotname2 = 'data1snapshot' + $rgname;
        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -HyperVGeneration "V1";
        $snapshot2 = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname2 -Snapshot $snapshotconfig

        $snapshotname3 = 'data2snapshot' + $rgname;
        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -HyperVGeneration "V1";
        $snapshot3 = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname3 -Snapshot $snapshotconfig

        $targetRegions = @(@{Name='South Central US';ReplicaCount=1;StorageAccountType='Standard_LRS'},@{Name='East US';ReplicaCount=2},@{Name='Central US'});
        $tag = @{test1 = "testval1"; test2 = "testval2" };

        $osDiskImage = @{Source = @{Id="$($snapshot1.Id)"}}
        $dataDiskImage1 = @{Source = @{Id="$($snapshot2.Id)"};Lun=1}
        $dataDiskImage2 = @{Source = @{Id="$($snapshot3.Id)"};Lun=2}

        New-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                       -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                       -Location $loc -ReplicaCount 1 `
                                       -PublishingProfileEndOfLifeDate $endOfLifeDate `
                                       -StorageAccountType Standard_LRS `
                                       -TargetRegion $targetRegions `
                                       -OSDiskImage $osDiskImage -DataDiskImage $dataDiskImage1,$dataDiskImage2;

        $version = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;

        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $null 1 $endOfLifeDate $targetRegions $osDiskImage @($dataDiskImage1, $dataDiskImage2)
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-GalleryDirectSharing
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $galleryName = 'gallery' + $rgname;

    try
    {
        $loc = 'eastus'
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # create gallery with permissions groups
        New-AzGallery -ResourceGroupName $rgname -Location $loc -Name $galleryName -Permission 'Groups'

        # get that gallery check for SharingProfile
        $gal = Get-AzGallery -ResourceGroupName $rgname -Name $galleryName -Expand 'SharingProfile/Groups'
        Assert-AreEqual $gal.sharingProfile.Permissions 'Groups'

        # Add 2 subscriptions to share with
        $gal = Update-AzGallery -ResourceGroupName $rgname -Name $galleryName -Permission 'Groups' -Share -Subscription '88fd8cb2-8248-499e-9a2d-4929a4b0133c','54b875cc-a81a-4914-8bfd-1a36bc7ddf4d'

        # check
        Assert-AreEqual $gal.SharingProfile.Groups[0].Type 'Subscriptions'
        Assert-AreEqual $gal.SharingProfile.Groups[0].Ids.count 2

        # remove 1
        $gal = Update-AzGallery -ResourceGroupName $rgname -Name $galleryName -Permission 'Groups' -Share -RemoveSubscription '88fd8cb2-8248-499e-9a2d-4929a4b0133c'

        # check
        Assert-AreEqual $gal.SharingProfile.Groups[0].Type 'Subscriptions'
        Assert-AreEqual $gal.SharingProfile.Groups[0].Ids.count 1

        # Reset that gallery
        $gal = Update-AzGallery -ResourceGroupName $rgname -Name $galleryName -Share -Reset

        # check
        Assert-AreEqual $gal.SharingProfile.Permissions 'Private'
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests the New-AzGalleryImageVersion new parameter SourceImageVMId.
#>
function Test-GalleryVersionWithSourceImageVMId
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {

        $location = $loc;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # create credential
        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $user = Get-ComputeTestResourceName;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Add one VM from creation
        $vmname = 'vm' + $rgname;
        $domainNameLabel = "d1" + $rgname;
        $securityType_TL = "TrustedLaunch";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2022-datacenter-azure-edition";
        $version = "latest";
        $disable = $false;
        $enable = $true;
        $galleryName = "g" + $rgname;
        $VMSize = "Standard_DS2_v2";
        $vnetname = "vn" + $rgname;
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "slb" + $rgname;
        $subnetAddress = "10.0.2.0/24";
        $pubipname = "p" + $rgname;
        $OSDiskName = $vmname + "-osdisk";
        $NICName = $vmname+ "-nic";
        $NSGName = $vmname + "-NSG";
        $nsgrulename = "nsr" + $rgname;
        $OSDiskSizeinGB = 128;
        $VMSize = "Standard_DS2_v2";
        $vmname2 = "2" + $vmname;


        # Gallery variables
        $resourceGroup = $rgname
        $galleryName = 'gl' + $rgname
        $definitionName = 'def' + $rgname
        $skuDetails = @{
            Publisher = 'test'
            Offer = 'test'
            Sku = 'test'
        }
        $osType = 'Windows'
        $osState = 'Specialized'
        [bool]$trustedLaunch = $false
        $storageAccountSku = 'Standard_LRS'
        $hyperVGeneration = 'v1'

        # create new VM
        $vm = New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname -Credential $cred -SecurityType "Standard" -DomainNameLabel $domainNameLabel;
        Start-TestSleep -Seconds 300

        # Setup Image Gallery
        New-AzGallery -ResourceGroupName $rgname -Name $galleryName -location $location -ErrorAction 'Stop' | Out-Null;

        # Setup Image Definition
        $paramNewAzImageDef = @{
            ResourceGroupName = $rgname
            GalleryName       = $galleryName
            Name              = $definitionName
            Publisher         = $skuDetails.Publisher
            Offer             = $skuDetails.Offer
            Sku               = $skuDetails.Sku
            Location          = $location
            OSState           = $osState
            OsType            = $osType
            HyperVGeneration  = $hyperVGeneration
            ErrorAction       = 'Stop'
        }

        New-AzGalleryImageDefinition @paramNewAzImageDef;

        # Setup Image Version
        $imageVersionName = "1.0.0";
        $targetRegions = @(@{Name=$loc;ReplicaCount=1;});
        $paramNewAzImageVer = @{
            ResourceGroupName   = $rgname
            GalleryName         = $galleryName
            GalleryImageDefinitionName  = $definitionName
            Name                = $imageVersionName
            Location            = $location
            SourceImageVMId       = $vm.Id
            ErrorAction         = 'Stop'
            StorageAccountType  = $storageAccountSku
            TargetRegion        = $targetRegions
        }
        $galversion = New-AzGalleryImageVersion @paramNewAzImageVer;

        # Assert VMId in version was set to the vm.Id value and was created.
        Assert-AreEqual $galversion.StorageProfile.Source.VirtualMachineId $vm.Id;
        Assert-Null $galversion.PublishingProfile.TargetRegion ExcludeFromLatest;

        $targetRegions = @{Name=$loc;ReplicaCount=1; ExcludeFromLatest=$true}

        Update-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
										  -GalleryImageDefinitionName $definitionName -Name $imageVersionName `
										  -TargetRegion $targetRegions;

        $galversion = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
												  -GalleryImageDefinitionName $definitionName -Name $imageVersionName;

        Assert-AreEqual $galversion.PublishingProfile.TargetRegions.ExcludeFromLatest $true;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Tests New-AzGalleryImageDefinition to default to HyperVGen V2 and TL
#>
function Test-GalleryImageDefinitionDefaults
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
    
        $location = $loc;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Gallery variables
        $resourceGroup = $rgname
        $galleryName = 'gl' + $rgname
        $definitionName = 'def' + $rgname
        $definitionName2 = $definitionName + '2'
        $skuDetails = @{
            Publisher = 'test'
            Offer = 'test'
            Sku = 'test'
        }
        $osType = 'Windows'
        $osState = 'Specialized'
        $storageAccountSku = 'Standard_LRS'
        
        # Setup Image Gallery
        New-AzGallery -ResourceGroupName $rgname -Name $galleryName -location $location

        # Setup Image Definition
        $paramNewAzImageDef = @{
            ResourceGroupName = $rgname
            GalleryName       = $galleryName
            Name              = $definitionName
            Publisher         = $skuDetails.Publisher
            Offer             = $skuDetails.Offer
            Sku               = $skuDetails.Sku
            Location          = $location
            OSState           = $osState
            OsType            = $osType
            ErrorAction       = 'Stop'
        }
        
        New-AzGalleryImageDefinition @paramNewAzImageDef;

        $definition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $definitionName;

        # verify HyperVGeneration and TL default 
         Assert-AreEqual $definition.HyperVGeneration "V2";
         Assert-AreEqual $definition.features[0].Name "SecurityType";
         Assert-AreEqual $definition.features[0].Value "TrustedLaunchSupported";


         # Testing by passing TL default by explictly setting securityType 

        $skuDetails2 = @{
            Publisher = 'test0'
            Offer = 'test0'
            Sku = 'test0'
        }

        $paramNewAzImageDef2 = @{
            ResourceGroupName = $rgname
            GalleryName       = $galleryName
            Name              = $definitionName2
            Publisher         = $skuDetails2.Publisher
            Offer             = $skuDetails2.Offer
            Sku               = $skuDetails2.Sku
            Location          = $location
            OSState           = $osState
            OsType            = $osType
            ErrorAction       = 'Stop'
            Feature           = @{Name="SecurityType"; Value="ConfidentialVM"}
        }


         New-AzGalleryImageDefinition @paramNewAzImageDef2
         $definition2 = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $definitionName2;

         # verify HyperVGeneration and TL default 
         Assert-AreNotEqual $definition2.features[0].Value "TrustedLaunchSupported";
         Assert-AreEqual $definition2.features.count 1


    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

