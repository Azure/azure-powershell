﻿# ----------------------------------------------------------------------------------
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
Test Virtual Machine Scale Set Profile
#>
function Test-VirtualMachineScaleSetProfile
{
    $loc =  Get-Location "Microsoft.Compute" "virtualMachines";
    $imgRef = Get-DefaultCRPImage -loc $loc;

    # IP config
    $ipName = 'iptest';
    $subnetId = 'subnetid';
    $ipPrefix = 'prefixid';

    $ipTagType1 = 'FirstPartyUsage1';
    $ipTagValue1 ='Sql1';
    $ipTag1 = New-AzureRmVmssIpTagConfig -IpTagType $ipTagType1 -Tag $ipTagValue1;
    $ipTagType2 = 'FirstPartyUsage2';
    $ipTagValue2 ='Sql2';
    $ipTag2 = New-AzureRmVmssIpTagConfig -IpTagType $ipTagType2 -Tag $ipTagValue2;

    $ipCfg = New-AzureRmVmssIPConfig -Name $ipName -SubnetId $subnetId -IpTag $ipTag1,$ipTag2 -PublicIPPrefix $ipPrefix;

    # Sku
    $skuName = 'Standard_A0';
    $skuCapacity = 2;
    $upgradePolicy = 'Automatic';

    $networkName = 'networktest';
    $computePrefix = 'computename';
    $createOption = 'FromImage';
    $osCaching = 'None';

    $adminUsername = 'Foo12';
    $adminPassword = $PLACEHOLDER;

    $extname = 'csetest';
    $publisher = 'Microsoft.Compute';
    $exttype = 'BGInfo';
    $extver = '2.1';

    $newUserId1 = "userid1";
    $newUserId2 = "userid2";

    $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity $skuCapacity -SkuName $skuName -UpgradePolicyMode $upgradePolicy `
            -IdentityType UserAssigned -IdentityId $newUserId1,$newUserId2 `
          | Add-AzureRmVmssNetworkInterfaceConfiguration -Name $networkName -Primary $true -IPConfiguration $ipCfg `
          | Set-AzureRmVmssOSProfile -ComputerNamePrefix $computePrefix  -AdminUsername $adminUsername -AdminPassword $adminPassword `
          | Set-AzureRmVmssStorageProfile -OsDiskCreateOption $createOption -OsDiskCaching $osCaching `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName `
          | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

    # IP config and Network profile
    Assert-AreEqual $ipName $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
    Assert-AreEqual $subnetId $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;
    Assert-AreEqual $ipTag1 $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0];
    Assert-AreEqual $ipTag2 $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[1];    
    Assert-AreEqual $ipPrefix $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.PublicIPPrefix.Id;
    Assert-AreEqual $networkName $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
    Assert-True { $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary };

    # Validate IP Tags  
    Assert-AreEqual $ipTagType1 `
        $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].IpTagType;
    Assert-AreEqual $ipTagValue1 `
        $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].Tag;
    Assert-AreEqual $ipTagType2 `
        $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[1].IpTagType;
    Assert-AreEqual $ipTagValue2 `
        $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[1].Tag;

    Assert-AreEqual $loc $vmss.Location;
    Assert-AreEqual $skuCapacity $vmss.Sku.Capacity;
    Assert-AreEqual $skuName $vmss.Sku.Name;
    Assert-AreEqual $upgradePolicy $vmss.UpgradePolicy.Mode;
    Assert-Null $vmss.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback;

    # OS profile
    Assert-AreEqual $computePrefix $vmss.VirtualMachineProfile.OSProfile.ComputerNamePrefix;
    Assert-AreEqual $adminUsername $vmss.VirtualMachineProfile.OSProfile.AdminUsername;

    # Storage profile
    Assert-AreEqual $createOption $vmss.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
    Assert-AreEqual $osCaching $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
    Assert-AreEqual $imgRef.Offer $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
    Assert-AreEqual $imgRef.Skus $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
    Assert-AreEqual $imgRef.Version $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Version;
    Assert-AreEqual $imgRef.PublisherName $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;
    Assert-Null $vmss.VirtualMachineProfile.StorageProfile.OsDisk.DiffDiskSettings;

    # Extension profile
    Assert-AreEqual $extname $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
    Assert-AreEqual $publisher $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
    Assert-AreEqual $exttype $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
    Assert-AreEqual $extver $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
    Assert-AreEqual $true $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

    # IdentityIds
    Assert-AreEqual 2 $vmss.Identity.UserAssignedIdentities.Keys.Count;
    Assert-True { $vmss.Identity.UserAssignedIdentities.ContainsKey($newUserId1) };
    Assert-True { $vmss.Identity.UserAssignedIdentities.ContainsKey($newUserId2) };
    Assert-AreEqual $newUserId1 $vmss.Identity.IdentityIds[0];
    Assert-AreEqual $newUserId2 $vmss.Identity.IdentityIds[1];

    # AdditionalCapabilities
    Assert-Null $vmss.VirtualMachineProfile.AdditionalCapabilities;

    $vmss2 = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $false;
    Assert-False { $vmss2.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };

    $vmss3 = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $true -EnableUltraSSD;
    Assert-True { $vmss3.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };
    Assert-True { $vmss3.VirtualMachineProfile.AdditionalCapabilities.UltraSSDEnabled };

    $vmss4 = New-AzureRmVmssConfig -Location $loc -SkuCapacity $skuCapacity -SkuName $skuName -UpgradePolicyMode $upgradePolicy ;
    Assert-Null $vmss4.Identity;

    $vmss4 = $vmss4 | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -OsDiskWriteAccelerator -ManagedDisk "Premium_LRS" -DiffDiskSetting "Local";

    # Storage profile
    Assert-AreEqual $createOption $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
    Assert-AreEqual $osCaching $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
    Assert-AreEqual $imgRef.Offer $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
    Assert-AreEqual $imgRef.Skus $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
    Assert-AreEqual $imgRef.Version $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Version;
    Assert-AreEqual $imgRef.PublisherName $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;
    Assert-AreEqual "Premium_LRS" $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.StorageAccountType;
    Assert-AreEqual "Local" $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.DiffDiskSettings.Option;
}
