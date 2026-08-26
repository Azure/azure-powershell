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
Tests implicit public IP first-party service tags for VMs and VM scale sets.
#>
function Test-FirstPartyServiceTagConfigurations
{
    # Step 1: Verify existing VMSS type and tag behavior and service tag omission.
    $vmssTagWithoutServiceId = New-AzVmssIpTagConfig -IpTagType 'FirstPartyUsage' -Tag 'Sql'
    Assert-AreEqual 'Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetIpTag' ($vmssTagWithoutServiceId.GetType().FullName)
    Assert-AreEqual 'FirstPartyUsage' $vmssTagWithoutServiceId.IpTagType
    Assert-AreEqual 'Sql' $vmssTagWithoutServiceId.Tag
    Assert-Null $vmssTagWithoutServiceId.FirstPartyServiceTagId

    # Step 2: Verify VMSS service tag binding and nesting.
    $vmssServiceId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/firstPartyServiceTags/vmss'
    $vmssTagWithServiceId = New-AzVmssIpTagConfig -IpTagType 'FirstPartyUsage' -Tag 'Storage' -FirstPartyServiceTagId $vmssServiceId
    $vmssIpConfiguration = New-AzVmssIpConfig -Name 'vmssIpConfig' -IpTag $vmssTagWithServiceId
    Assert-AreEqual $vmssServiceId $vmssTagWithServiceId.FirstPartyServiceTagId
    Assert-AreEqual 1 $vmssIpConfiguration.PublicIPAddressConfiguration.IpTags.Count
    Assert-AreEqual $vmssServiceId $vmssIpConfiguration.PublicIPAddressConfiguration.IpTags[0].FirstPartyServiceTagId

    $vmssIpConfigurationWithNullTag = New-AzVmssIpConfig -Name 'vmssIpConfigWithNullTag' -IpTag $null
    Assert-Null $vmssIpConfigurationWithNullTag.PublicIPAddressConfiguration

    # Step 3: Verify VM type and tag behavior with supplied and omitted service tag identifiers.
    $vmTagWithoutServiceId = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -Tag 'Sql'
    Assert-AreEqual 'Microsoft.Azure.Management.Compute.Models.VirtualMachineIpTag' ($vmTagWithoutServiceId.GetType().FullName)
    Assert-AreEqual 'FirstPartyUsage' $vmTagWithoutServiceId.IpTagType
    Assert-AreEqual 'Sql' $vmTagWithoutServiceId.Tag
    Assert-Null $vmTagWithoutServiceId.FirstPartyServiceTagId

    $vmServiceId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/firstPartyServiceTags/vm'
    $vmTagWithServiceId = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -FirstPartyServiceTagId $vmServiceId
    Assert-AreEqual 'FirstPartyUsage' $vmTagWithServiceId.IpTagType
    Assert-Null $vmTagWithServiceId.Tag
    Assert-AreEqual $vmServiceId $vmTagWithServiceId.FirstPartyServiceTagId

    # Step 4: Verify VM IP tag nesting and preservation of each supplied tag.
    $vmIpConfiguration = New-AzVMIpConfig -Name 'vmIpConfig' -SubnetId '/subnets/test' `
        -PublicIPAddressConfigurationName 'vmPublicIp' -IpTag $vmTagWithoutServiceId,$vmTagWithServiceId
    Assert-AreEqual 'Microsoft.Azure.Management.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration' ($vmIpConfiguration.GetType().FullName)
    Assert-AreEqual 'vmIpConfig' $vmIpConfiguration.Name
    Assert-AreEqual '/subnets/test' $vmIpConfiguration.Subnet.Id
    Assert-AreEqual 'vmPublicIp' $vmIpConfiguration.PublicIPAddressConfiguration.Name
    Assert-AreEqual 2 $vmIpConfiguration.PublicIPAddressConfiguration.IpTags.Count
    Assert-AreEqual 'Sql' $vmIpConfiguration.PublicIPAddressConfiguration.IpTags[0].Tag
    Assert-AreEqual $vmServiceId $vmIpConfiguration.PublicIPAddressConfiguration.IpTags[1].FirstPartyServiceTagId

    $vmIpConfigurationWithoutTag = New-AzVMIpConfig -Name 'vmIpConfigWithoutTag'
    Assert-Null $vmIpConfigurationWithoutTag.PublicIPAddressConfiguration

    $vmIpConfigurationWithNullTag = New-AzVMIpConfig -Name 'vmIpConfigWithNullTag' -IpTag $null
    Assert-Null $vmIpConfigurationWithNullTag.PublicIPAddressConfiguration

    $fullVmIpConfiguration = New-AzVMIpConfig -Name 'fullVmIpConfig' -PrivateIPAddressVersion 'IPv4' `
        -PublicIPAddressConfigurationIdleTimeoutInMinutes 10 -DnsSetting 'service-tag-test' `
        -PublicIPPrefix '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/publicIPPrefixes/prefix' `
        -PublicIPAddressVersion 'IPv4' -PublicIPAllocationMethod 'Static'
    Assert-AreEqual 'IPv4' $fullVmIpConfiguration.PrivateIPAddressVersion
    Assert-AreEqual 10 $fullVmIpConfiguration.PublicIPAddressConfiguration.IdleTimeoutInMinutes
    Assert-AreEqual 'service-tag-test' $fullVmIpConfiguration.PublicIPAddressConfiguration.DnsSettings.DomainNameLabel
    Assert-AreEqual '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/publicIPPrefixes/prefix' $fullVmIpConfiguration.PublicIPAddressConfiguration.PublicIPPrefix.Id
    Assert-AreEqual 'IPv4' $fullVmIpConfiguration.PublicIPAddressConfiguration.PublicIPAddressVersion
    Assert-AreEqual 'Static' $fullVmIpConfiguration.PublicIPAddressConfiguration.PublicIPAllocationMethod

    # Step 5: Verify network profile initialization and approved parameter syntax.
    $vm = New-AzVMConfig -VMName 'serviceTagVm' -VMSize 'Standard_A1'
    $vm.NetworkProfile = $null
    $vm = Add-AzVMNetworkInterfaceConfiguration -VM $vm -Name 'nicConfig1' -Primary `
        -IpConfiguration $vmIpConfiguration -NetworkApiVersion '2022-11-01'
    Assert-NotNull $vm.NetworkProfile
    Assert-AreEqual '2022-11-01' $vm.NetworkProfile.NetworkApiVersion
    Assert-AreEqual 1 $vm.NetworkProfile.NetworkInterfaceConfigurations.Count
    Assert-AreEqual 1 $vm.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count
    Assert-AreEqual $vmServiceId $vm.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[1].FirstPartyServiceTagId

    # Step 6: Verify existing configurations and NetworkApiVersion are preserved when the parameter is omitted.
    $secondIpConfiguration = New-AzVMIpConfig -Name 'vmIpConfig2' -IpTag $vmTagWithoutServiceId
    $vm = $vm | Add-AzVMNetworkInterfaceConfiguration -Name 'nicConfig2' -IpConfiguration $secondIpConfiguration
    Assert-AreEqual '2022-11-01' $vm.NetworkProfile.NetworkApiVersion
    Assert-AreEqual 2 $vm.NetworkProfile.NetworkInterfaceConfigurations.Count
    Assert-AreEqual 'nicConfig1' $vm.NetworkProfile.NetworkInterfaceConfigurations[0].Name
    Assert-AreEqual 'nicConfig2' $vm.NetworkProfile.NetworkInterfaceConfigurations[1].Name
    Assert-AreEqual 'Sql' $vm.NetworkProfile.NetworkInterfaceConfigurations[1].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].Tag

    # Step 7: Verify create, get, update, and removal behavior against Azure.
    $rgname = Get-ComputeTestResourceName
    $loc = 'eastus2euap'
    $vmSize = 'Standard_D2s_v5'
    $adminUsername = 'Foo12'
    $securePassword = $PLACEHOLDER | ConvertTo-SecureString -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ($adminUsername, $securePassword)

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix '10.0.0.0/24'
        $vnet = New-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc `
            -AddressPrefix '10.0.0.0/16' -Subnet $subnet -Force
        $subnetId = $vnet.Subnets[0].Id

        $serviceTag = New-AzFirstPartyServiceTag -ResourceGroupName $rgname -Name ('tag' + $rgname) `
            -Location $loc -Value '/RnmRunners' -Tag @{ environment = 'test' }
        $serviceTag = Get-AzFirstPartyServiceTag -ResourceGroupName $rgname -Name $serviceTag.Name
        Assert-NotNull $serviceTag.Id

        $liveVmIpTag = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -Tag '/RnmRunners' `
            -FirstPartyServiceTagId $serviceTag.Id

        # Standalone VM.
        $standaloneVmName = 'vm' + $rgname
        $standaloneIpConfig = New-AzVMIpConfig -Name 'ipconfig' -SubnetId $subnetId `
            -PublicIPAddressConfigurationName ('pip' + $rgname) -IpTag $liveVmIpTag
        $standaloneVmConfig = New-AzVMConfig -VMName $standaloneVmName -VMSize $vmSize -SecurityType 'Standard'
        $standaloneVmConfig = Set-AzVMOperatingSystem -VM $standaloneVmConfig -Windows `
            -ComputerName 'serviceTagVm' -Credential $credential
        $standaloneVmConfig = Set-AzVMSourceImage -VM $standaloneVmConfig -PublisherName 'MicrosoftWindowsServer' `
            -Offer 'WindowsServer' -Skus '2022-datacenter-g2' -Version '20348.4648.260108'
        $standaloneVmConfig = Set-AzVMBootDiagnostic -VM $standaloneVmConfig -Disable
        $standaloneVmConfig = $standaloneVmConfig | Add-AzVMNetworkInterfaceConfiguration -Name 'nicconfig' `
            -Primary -IpConfiguration $standaloneIpConfig -NetworkApiVersion '2022-11-01'
        $null = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $standaloneVmConfig -DisableBginfoExtension

        # Uniform VM scale set.
        $liveVmssIpTag = New-AzVmssIpTagConfig -IpTagType 'FirstPartyUsage' -Tag '/RnmRunners' `
            -FirstPartyServiceTagId $serviceTag.Id
        $uniformVmssName = 'uniform' + $rgname
        $uniformIpConfig = New-AzVmssIpConfig -Name 'ipconfig' -SubnetId $subnetId `
            -PublicIPAddressConfigurationName ('upip' + $rgname) -IpTag $liveVmssIpTag
        $uniformVmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity 0 -SkuName $vmSize `
            -UpgradePolicyMode 'Manual' -SecurityType 'Standard' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'nicconfig' -Primary $true -IPConfiguration $uniformIpConfig `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'uniform' -AdminUsername $adminUsername -AdminPassword $PLACEHOLDER `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                -ImageReferenceOffer 'WindowsServer' -ImageReferenceSku '2022-datacenter-g2' `
                -ImageReferenceVersion '20348.4648.260108' -ImageReferencePublisher 'MicrosoftWindowsServer'
        $null = New-AzVmss -ResourceGroupName $rgname -Name $uniformVmssName -VirtualMachineScaleSet $uniformVmssConfig

        $uniformVmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $uniformVmssName
        $uniformIpTag = $uniformVmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0]
        Assert-AreEqual $serviceTag.Id $uniformIpTag.FirstPartyServiceTagId

        $uniformIpTag.FirstPartyServiceTagId = $null
        $null = Update-AzVmss -ResourceGroupName $rgname -Name $uniformVmssName -VirtualMachineScaleSet $uniformVmss
        $uniformVmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $uniformVmssName
        Assert-AreEqual '' $uniformVmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].FirstPartyServiceTagId

        $uniformVmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].FirstPartyServiceTagId = $serviceTag.Id
        $null = Update-AzVmss -ResourceGroupName $rgname -Name $uniformVmssName -VirtualMachineScaleSet $uniformVmss
        $uniformVmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $uniformVmssName
        Assert-AreEqual $serviceTag.Id $uniformVmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].FirstPartyServiceTagId

        # Flexible VM scale set instance.
        $flexVmssName = 'flex' + $rgname
        $flexVmssConfig = New-AzVmssConfig -Location $loc -OrchestrationMode 'Flexible' `
            -PlatformFaultDomainCount 1 -SinglePlacementGroup $false
        $null = New-AzVmss -ResourceGroupName $rgname -Name $flexVmssName -VirtualMachineScaleSet $flexVmssConfig
        $flexVmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $flexVmssName
        $flexVmName = 'flexvm' + $rgname
        $flexVmName = 'flexvm' + $rgname
        $flexIpConfig = New-AzVMIpConfig -Name 'ipconfig' -SubnetId $subnetId `
            -PublicIPAddressConfigurationName ('fpip' + $rgname) -IpTag $liveVmIpTag
        $flexVmConfig = New-AzVMConfig -VMName $flexVmName -VMSize $vmSize -VmssId $flexVmss.Id `
            -SecurityType 'Standard'
        $flexVmConfig = Set-AzVMOperatingSystem -VM $flexVmConfig -Windows -ComputerName 'flexServiceTag' `
            -Credential $credential
        $flexVmConfig = Set-AzVMSourceImage -VM $flexVmConfig -PublisherName 'MicrosoftWindowsServer' `
            -Offer 'WindowsServer' -Skus '2022-datacenter-g2' -Version '20348.4648.260108'
        $flexVmConfig = Set-AzVMBootDiagnostic -VM $flexVmConfig -Disable
        $flexVmConfig = $flexVmConfig | Add-AzVMNetworkInterfaceConfiguration -Name 'nicconfig' `
            -Primary -IpConfiguration $flexIpConfig -NetworkApiVersion '2022-11-01'
        $null = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $flexVmConfig -DisableBginfoExtension

    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

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
    $ipTag1 = New-AzVmssIpTagConfig -IpTagType $ipTagType1 -Tag $ipTagValue1;
    $ipTagType2 = 'FirstPartyUsage2';
    $ipTagValue2 ='Sql2';
    $ipTag2 = New-AzVmssIpTagConfig -IpTagType $ipTagType2 -Tag $ipTagValue2;

    $ipCfg = New-AzVmssIPConfig -Name $ipName -SubnetId $subnetId -IpTag $ipTag1,$ipTag2 -PublicIPPrefix $ipPrefix;

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

    $vmss = New-AzVmssConfig -Location $loc -SkuCapacity $skuCapacity -SkuName $skuName -UpgradePolicyMode $upgradePolicy `
            -IdentityType UserAssigned -IdentityId $newUserId1,$newUserId2 `
          | Add-AzVmssNetworkInterfaceConfiguration -Name $networkName -Primary $true -IPConfiguration $ipCfg `
          | Set-AzVmssOSProfile -ComputerNamePrefix $computePrefix  -AdminUsername $adminUsername -AdminPassword $adminPassword `
          | Set-AzVmssStorageProfile -OsDiskCreateOption $createOption -OsDiskCaching $osCaching `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName `
          | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
          | Add-AzVmssDataDisk -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeGB  20 -Lun 1 -CreateOption Empty -DiskIOPSReadWrite 100 -DiskMBpsReadWrite 1000;


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

    Assert-AreEqual 'testDataDisk1' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Name;
    Assert-AreEqual 'ReadOnly' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Caching;
    Assert-AreEqual 20 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].DiskSizeGB;
    Assert-AreEqual 1 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Lun;
    Assert-AreEqual 'Empty' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].CreateOption;
    Assert-AreEqual 100 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].DiskIOPSReadWrite;
    Assert-AreEqual 1000 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].DiskMBpsReadWrite;

    # Security Profile
    Assert-Null $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.VtpmEnabled;
    Assert-Null $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled;

    $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $vmss -EnableVtpm $true -EnableSecureBoot $true
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.VtpmEnabled $true;
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;

    $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $vmss -EnableVtpm $true -EnableSecureBoot $false
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.VtpmEnabled $true;
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $false;

    $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $vmss -EnableVtpm $false -EnableSecureBoot $true
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.VtpmEnabled $false;
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;

    $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $vmss -EnableVtpm $false -EnableSecureBoot $false
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.VtpmEnabled $false;
    Assert-AreEqual $vmss.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $false;


    # Extension profile
    Assert-AreEqual $extname $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
    Assert-AreEqual $publisher $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
    Assert-AreEqual $exttype $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
    Assert-AreEqual $extver $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
    Assert-True { $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion };
    Assert-Null $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].ProvisionAfterExtensions;

    # IdentityIds
    Assert-AreEqual 2 $vmss.Identity.UserAssignedIdentities.Keys.Count;
    Assert-True { $vmss.Identity.UserAssignedIdentities.ContainsKey($newUserId1) };
    Assert-True { $vmss.Identity.UserAssignedIdentities.ContainsKey($newUserId2) };

    # AdditionalCapabilities
    Assert-Null $vmss.VirtualMachineProfile.AdditionalCapabilities;

    # AutomaticRepairsPolicy
    Assert-Null $vmss.AutomaticRepairsPolicy;

    $extname2 = 'catextension';
    $publisher2 = 'Microsoft.AzureCAT.AzureEnhancedMonitoring';
    $exttype2 = 'AzureCATExtensionHandler';
    $extver2 = '2.2';

    $vmss2 = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $false -SkipExtensionsOnOverprovisionedVMs `
           | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $false `
           | Add-AzVmssExtension -Name $extname2 -Publisher $publisher2 -Type $exttype2 -TypeHandlerVersion $extver2 -AutoUpgradeMinorVersion $false -ProvisionAfterExtension $extname;

    Assert-False { $vmss2.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };
    Assert-True { $vmss2.DoNotRunExtensionsOnOverprovisionedVMs };

    Assert-AreEqual $extname $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
    Assert-False { $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion };
    Assert-Null $vmss.VirtualMachineProfile.ExtensionProfile.Extensions[0].ProvisionAfterExtensions;

    Assert-AreEqual $extname2 $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[1].Name;
    Assert-False { $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[1].AutoUpgradeMinorVersion };
    Assert-AreEqual 1 $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[1].ProvisionAfterExtensions.Count;
    Assert-AreEqual $extname $vmss2.VirtualMachineProfile.ExtensionProfile.Extensions[1].ProvisionAfterExtensions[0];

    $vmss3 = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $true -EnableUltraSSD `
                              -TerminateScheduledEvents -TerminateScheduledEventNotBeforeTimeoutInMinutes 15 `
                              -EnableAutomaticRepair;
    Assert-True { $vmss3.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };
    Assert-True { $vmss3.AdditionalCapabilities.UltraSSDEnabled };
    Assert-True { $vmss3.VirtualMachineProfile.ScheduledEventsProfile.TerminateNotificationProfile.Enable };
    Assert-AreEqual "PT15M" $vmss3.VirtualMachineProfile.ScheduledEventsProfile.TerminateNotificationProfile.NotBeforeTimeout;

    # AutomaticRepairsPolicy
    Assert-True { $vmss3.AutomaticRepairsPolicy.Enabled };

    $ppgid = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgname/providers/Microsoft.Compute/proximityPlacementGroups/ppgname"
    $vmss4 = New-AzVmssConfig -Location $loc -SkuCapacity $skuCapacity -SkuName $skuName -UpgradePolicyMode $upgradePolicy -ProximityPlacementGroupId $ppgid;
    Assert-Null $vmss4.Identity;

    $vmss4 = $vmss4 | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -OsDiskWriteAccelerator `
            -ManagedDisk "Premium_LRS" -DiffDiskSetting "Local" -DiskEncryptionSetId "enc_id1";

    # Storage profile
    Assert-AreEqual $createOption $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
    Assert-AreEqual $osCaching $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
    Assert-AreEqual $imgRef.Offer $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
    Assert-AreEqual $imgRef.Skus $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
    Assert-AreEqual $imgRef.Version $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Version;
    Assert-AreEqual $imgRef.PublisherName $vmss4.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;
    Assert-AreEqual "Premium_LRS" $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.StorageAccountType;
    Assert-AreEqual "enc_id1" $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id;
    Assert-AreEqual "Local" $vmss4.VirtualMachineProfile.StorageProfile.OsDisk.DiffDiskSettings.Option;
    Assert-AreEqual $ppgid $vmss4.ProximityPlacementGroup.Id;
}
