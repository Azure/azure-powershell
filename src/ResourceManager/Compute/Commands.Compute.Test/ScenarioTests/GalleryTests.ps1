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
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;        
        $description1 = "Original Description";
        $description2 = "Updated Description";

        # Gallery
        New-AzureRmGallery -ResourceGroupName $rgname -Name $galleryName -Description $description1 -Location $loc;

        $galleryList = Get-AzureRmGallery;
        $gallery = $galleryList | ? {$_.Name -eq $galleryName};
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;

        $galleryList = Get-AzureRmGallery -ResourceGroupName $rgname;
        $gallery = $galleryList | ? {$_.Name -eq $galleryName};
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;

        $gallery = Get-AzureRmGallery -ResourceGroupName $rgname -Name $galleryName;
        Verify-Gallery $gallery $rgname $galleryName $loc $description1;
        $output = $gallery | Out-String;

        Update-AzureRmGallery -ResourceGroupName $rgname -Name $galleryName -Description $description2;
        $gallery = Get-AzureRmGallery -ResourceGroupName $rgname -Name $galleryName;
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

        New-AzureRmGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName `
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

        $galleryImageDefinitionList = Get-AzureRmGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName;
        $definition = $galleryImageDefinitionList | ? {$_.Name -eq $galleryImageName};
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        $definition = Get-AzureRmGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        $output = $definition | Out-String;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description1 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        Update-AzureRmGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName `
                                             -Description $description2;

        $definition = Get-AzureRmGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $galleryImageName;
        Verify-GalleryImageDefinition $definition $rgname $galleryImageName $loc $description2 `
                                      $eula $privacyStatementUri $releaseNoteUri `
                                      $osType $osState $endOfLifeDate `
                                      $publisherName $offerName $skuName `
                                      $minVCPU $maxVCPU $minMemory $maxMemory `
                                      $disallowedDiskTypes `
                                      $purchasePlanName $purchasePlanPublisher $purchasePlanProduct;

        # Gallery Image Version        
        $galleryImageVersionName = "1.0.0";
        $sourceImageId = "/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/LONGLIVEDGALLERYSCUS/providers/Microsoft.Compute/images/gallerysourcewindows";
        $targetRegions = @(@{Name='South Central US';ReplicaCount=1},@{Name='East US';ReplicaCount=2},@{Name='Central US'});        
        $tag = @{test1 = "testval1"; test2 = "testval2" };

        New-AzureRmGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                       -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                       -Location $loc -SourceImageId $sourceImageId -ReplicaCount 1 `
                                       -PublishingProfileEndOfLifeDate $endOfLifeDate `
                                       -TargetRegion $targetRegions;

        $galleryImageVersionList = Get-AzureRmGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                                  -GalleryImageDefinitionName $galleryImageName;
                                       
        $version = $galleryImageVersionList | ? {$_.Name -eq $galleryImageVersionName};
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $sourceImageId 1 $endOfLifeDate $targetRegions;

        $version = Get-AzureRmGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $sourceImageId 1 $endOfLifeDate $targetRegions;

        Update-AzureRmGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                          -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName `
                                          -Tag $tag;

        $version = Get-AzureRmGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName `
                                                  -GalleryImageDefinitionName $galleryImageName -Name $galleryImageVersionName;
        Verify-GalleryImageVersion $version $rgname $galleryImageVersionName $loc `
                                   $sourceImageId 1 $endOfLifeDate $targetRegions;
        $output = $version | Out-String;

        $version | Remove-AzureRmGalleryImageVersion -Force;
        $definition | Remove-AzureRmGalleryImageDefinition -Force;
        $gallery | Remove-AzureRmGallery -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
