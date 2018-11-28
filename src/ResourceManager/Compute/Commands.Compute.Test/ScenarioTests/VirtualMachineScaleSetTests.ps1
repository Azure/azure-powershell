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
Test Virtual Machine Scalet Set

PS C:\> Get-Command *VMSS* | ft Name,Version,ModuleName

Name                                            Version ModuleName
----                                            ------- ----------
Add-AzureRmVmssAdditionalUnattendContent           1.2.4      AzureRM.Compute
Add-AzureRmVmssExtension                           1.2.4      AzureRM.Compute
Add-AzureRmVMSshPublicKey                          1.2.4      AzureRM.Compute
Add-AzureRmVmssNetworkInterfaceConfiguration       1.2.4      AzureRM.Compute
Add-AzureRmVmssSecret                              1.2.4      AzureRM.Compute
Add-AzureRmVmssSshPublicKey                        1.2.4      AzureRM.Compute
Add-AzureRmVmssWinRMListener                       1.2.4      AzureRM.Compute
Get-AzureRmVmss                                    1.2.4      AzureRM.Compute
Get-AzureRmVmssSku                                 1.2.4      AzureRM.Compute
Get-AzureRmVmssVM                                  1.2.4      AzureRM.Compute
New-AzureRmVmss                                    1.2.4      AzureRM.Compute
New-AzureRmVmssConfig                              1.2.4      AzureRM.Compute
New-AzureRmVmssIpConfig                            1.2.4      AzureRM.Compute
New-AzureRmVmssVaultCertificateConfig              1.2.4      AzureRM.Compute
Remove-AzureRmVmss                                 1.2.4      AzureRM.Compute
Remove-AzureRmVmssExtension                        1.2.4      AzureRM.Compute
Remove-AzureRmVmssNetworkInterfaceConfiguration    1.2.4      AzureRM.Compute
Restart-AzureRmVmss                                1.2.4      AzureRM.Compute
Set-AzureRmVmss                                    1.2.4      AzureRM.Compute
Set-AzureRmVmssOsProfile                           1.2.4      AzureRM.Compute
Set-AzureRmVmssStorageProfile                      1.2.4      AzureRM.Compute
Set-AzureRmVmssVM                                  1.2.4      AzureRM.Compute
Start-AzureRmVmss                                  1.2.4      AzureRM.Compute
Stop-AzureRmVmss                                   1.2.4      AzureRM.Compute
Update-AzureRmVmss                                 1.2.4      AzureRM.Compute
Update-AzureRmVmssInstance                         1.2.4      AzureRM.Compute
#>

<#
.SYNOPSIS
Test Virtual Machine Scale Set
.DESCRIPTION
Smoke[Ignore]Test
#>
function Test-VirtualMachineScaleSet
{
    Test-VirtualMachineScaleSet-Common $false
}
<#
.SYNOPSIS
Test Virtual Machine Scale Set with Managed disks
#>
function Test-VirtualMachineScaleSet-ManagedDisks
{
    Test-VirtualMachineScaleSet-Common $true
}
function Test-VirtualMachineScaleSet-Common($IsManaged)
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId -Primary;
        Assert-True { $ipCfg.Primary };

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        Assert-False { $ipCfg.Primary };

        $vmss = New-AzureRmVmssConfig -Location $loc -Zone "1" -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Remove-AzureRmVmssExtension -Name $extname `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $ipCfg `
            | Remove-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2'

        $vmss | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test3' -IPConfiguration $ipCfg -EnableAcceleratedNetworking;
        Assert-True { $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[1].EnableAcceleratedNetworking };
        $vmss | Remove-AzureRmVmssNetworkInterfaceConfiguration -Name 'test3'

        if ($IsManaged -eq $true)
        {
            $vmss = $vmss | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                    -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
                    -ImageReferencePublisher $imgRef.PublisherName -OsDiskWriteAccelerator `
                    | Add-AzureRmVmssDataDisk -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeGB  20 -Lun 1 -CreateOption Empty `
                    -StorageAccountType Standard_LRS -WriteAccelerator;

            Assert-AreEqual 'FromImage' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
            Assert-AreEqual 'None' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
            Assert-AreEqual $true $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;
            $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled = $false;

            Assert-AreEqual $imgRef.PublisherName $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;
            Assert-AreEqual $imgRef.Offer $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
            Assert-AreEqual $imgRef.Skus $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
            Assert-AreEqual $imgRef.Version $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Version;

            Assert-AreEqual 'testDataDisk1' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Name;
            Assert-AreEqual 'ReadOnly' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Caching;
            Assert-AreEqual 20 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].DiskSizeGB;
            Assert-AreEqual 1 $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].Lun;
            Assert-AreEqual 'Empty' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].CreateOption;
            Assert-AreEqual "Standard_LRS" $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType;
            Assert-AreEqual $true $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].WriteAcceleratorEnabled;
            $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].WriteAcceleratorEnabled = $false;

            $vmss = $vmss | Remove-AzureRmVmssDataDisk -Lun 1;
            Assert-AreEqual 0 $vmss.VirtualMachineProfile.StorageProfile.DataDisks.Count;
        }
        else
        {
            $vmss = $vmss| Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                    -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
                    -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
        }

        # Validate Remove Network profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        Assert-AreEqual "1" $vmss.Zones
        $vmss.Zones = $null

        $job = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $vmss = $job | Receive-Job

        Assert-AreEqual $loc $vmss.Location;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $vmss.Sku.Name;
        Assert-AreEqual 'Automatic' $vmss.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $vmss.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $vmss.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile

        Assert-AreEqual 'FromImage' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        if($IsManaged -eq $false)
        {
            Assert-AreEqual 'test' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Name;
            Assert-AreEqual $vhdContainer $vmss.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        }
        Assert-AreEqual $imgRef.Offer $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss');
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $vmssName $vmssResult.Name;
        Assert-True { $vmssName -eq $vmssResult.Name };
        $output = $vmssResult | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List All
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss ListAll');
        $vmssList = Get-AzureRmVmss;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List from RG
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss List');
        $vmssList = Get-AzureRmVmss -ResourceGroupName $rgname;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List Skus
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssSku');
        $skuList = Get-AzureRmVmssSku -ResourceGroupName $rgname  -VMScaleSetName $vmssName;
        $output = $skuList | Out-String;
        Write-Verbose ($output);
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssSku | Format-Custom');
        $output = $skuList | Format-Custom | Out-String;
        Write-Verbose ($output);
        #Assert-True { $output.Contains("Sku") };

        # List All VMs
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM List');
        $vmListResult = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $output = $vmListResult | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("StorageProfile") };

        # List each VM
        for ($i = 0; $i -lt 2; $i++)
        {
            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM');
            $vm = Get-AzureRmVmssVM -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vm;
            $output = $vm | Out-String;
            Write-Verbose ($output);
            Assert-True { $output.Contains("StorageProfile") };

            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM -InstanceView');
            $vmInstance = Get-AzureRmVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vmInstance;
            $output = $vmInstance | Out-String;

            Write-Verbose($output);
            Assert-True { $output.Contains("PlatformUpdateDomain") };
        }

        $st = $vmssResult | Stop-AzureRmVmss -StayProvision -Force;
        Verify-PSOperationStatusResponse $st;

        $job = $vmssResult | Stop-AzureRmVmss -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        $job = $vmssResult | Start-AzureRmVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;

        $job = $vmssResult | Restart-AzureRmVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        if ($IsManaged -eq $true)
        {
            $job = $vmssResult | Set-AzureRmVmss -ReimageAll -AsJob;
            $job | Wait-Job;
            $result = $job | Wait-Job;
            Assert-AreEqual "Completed" $result.State;
            $st = $job | Receive-Job;
            Verify-PSOperationStatusResponse $st;
        }
        $instanceListParam = @();
        for ($i = 0; $i -lt 2; $i++)
        {
            $instanceListParam += $i.ToString();
        }

        $st = $vmssResult | Stop-AzureRmVmss -StayProvision -InstanceId $instanceListParam -Force;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Stop-AzureRmVmss -InstanceId $instanceListParam -Force;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Start-AzureRmVmss -InstanceId $instanceListParam;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Restart-AzureRmVmss -InstanceId $instanceListParam;
        Verify-PSOperationStatusResponse $st;

        if ($IsManaged -eq $true)
        {
            for ($j = 0; $j -lt 2; $j++)
            {
                $job = Set-AzureRmVmssVM -ReimageAll -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $j -AsJob;
                $result = $job | Wait-Job;
                Assert-AreEqual "Completed" $result.State;
                $st = $job | Receive-Job;
                Verify-PSOperationStatusResponse $st;
            }
        }

        # Remove
        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1 -Force;
        Verify-PSOperationStatusResponse $st;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Upgrade
#>
function Test-VirtualMachineScaleSetUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $result.Sku.Name;
        Assert-AreEqual 'Manual' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $result.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        # Verify the result of VMSS
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;

        Assert-ThrowsContains {
            Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -DisablePasswordAuthentication $true -EnableAutomaticUpdate $true; } `
            "Cannot specify both Windows and Linux configurations.";

        $tags = @{test1 = "testval1"; test2 = "testval2" };
        $job = Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -Tag $tags -SkuCapacity 3 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $returned_tags = $vmss.Tags;
        Assert-AreEqual 2 $returned_tags.Count;
        Assert-AreEqual $tags["test1"] $returned_tags["test1"];
        Assert-AreEqual $tags["test2"] $returned_tags["test2"];
        Assert-AreEqual 3 $vmss.Sku.Capacity;

        $vmss2 = $vmss | Update-AzureRmVmss -SkuCapacity 4;
        $returned_tags2 = $vmss2.Tags;
        Assert-AreEqual 2 $returned_tags2.Count;
        Assert-AreEqual $tags["test1"] $returned_tags["test1"];
        Assert-AreEqual $tags["test2"] $returned_tags["test2"];
        Assert-AreEqual 4 $vmss2.Sku.Capacity;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Reimage and Upgrade
#>
function Test-VirtualMachineScaleSetReimageUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $aucComponentName="Microsoft-Windows-Shell-Setup";
        $aucComponentName="MicrosoftWindowsShellSetup";
        $aucPassName ="oobeSystem";
        $aucSetting = "AutoLogon";
        $aucContent = "<UserAccounts><AdministratorPassword><Value>password</Value><PlainText>true</PlainText></AdministratorPassword></UserAccounts>";

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssAdditionalUnattendContent -ComponentName  $aucComponentName -Content  $aucContent -PassName  $aucPassName -SettingName  $aucSetting `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $vmss.VirtualMachineProfile.OsProfile.WindowsConfiguration.AdditionalUnattendContent = $null;
        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $result.Sku.Name;
        Assert-AreEqual 'Manual' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $result.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Manual Upgrade operation
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;

        Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName
        $id = $vmssVMs[0].InstanceId

        $job = Update-AzureRmVmssInstance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Reimage operation
        Set-AzureRmVmss -Reimage -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Remove
        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id -Force;
        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set
#>
function Test-VirtualMachineScaleSetLB
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'westus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRMPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRMPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;

        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3364 -BackendPort 3370;
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $expectedLb.ResourceGroupName $actualLb.ResourceGroupName;
        Assert-AreEqual $expectedLb.Name $actualLb.Name;
        Assert-AreEqual $expectedLb.Location $actualLb.Location;
        Assert-AreEqual "Succeeded" $expectedLb.ProvisioningState;
        Assert-NotNull $expectedLb.ResourceGuid;
        Assert-AreEqual 1 @($expectedLb.FrontendIPConfigurations).Count;
        Assert-AreEqual $frontendName $expectedLb.FrontendIPConfigurations[0].Name;
        Assert-AreEqual $pubip.Id $expectedLb.FrontendIPConfigurations[0].PublicIpAddress.Id;
        Assert-Null $expectedLb.FrontendIPConfigurations[0].PrivateIpAddress;
        Assert-AreEqual $backendAddressPoolName $expectedLb.BackendAddressPools[0].Name;
        Assert-AreEqual $probeName $expectedLb.Probes[0].Name;
        Assert-AreEqual $probe.RequestPath $expectedLb.Probes[0].RequestPath;
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.InboundNatPools[0].FrontendIPConfiguration.Id;
        Assert-AreEqual $lbruleName $expectedLb.LoadBalancingRules[0].Name;
        Assert-AreEqual $expectedLb.FrontendIPConfigurations[0].Id $expectedLb.LoadBalancingRules[0].FrontendIPConfiguration.Id;
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $expectedLb.LoadBalancingRules[0].BackendAddressPool.Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;
        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;
        Assert-AreEqual $expectedLb.InboundNatPools[0].Id $ipCfg.LoadBalancerInboundNatPools[0].Id;
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $ipCfg.LoadBalancerBackendAddressPools[0].Id;
        Assert-AreEqual $subnetId $ipCfg.Subnet.Id;

        $settingString = ‘{ “AntimalwareEnabled”: true}’;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true -Setting $settingString `
            | Remove-AzureRmVmssExtension -Name $extname `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $ipCfg `
            | Remove-AzureRmVmssNetworkInterfaceConfiguration -Name 'test2' `
            | New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName;

        Assert-AreEqual $loc $vmss.Location;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $vmss.Sku.Name;
        Assert-AreEqual 'automatic' $vmss.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $expectedLb.InboundNatPools[0].Id  `
            $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerInboundNatPools[0].Id;
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id  `
            $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools[0].Id;
        Assert-AreEqual $subnetId `
            $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $vmss.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $vmss.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $vmss.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $vmss.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $vmss.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss');
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssName -eq $vmssResult.Name };
        $output = $vmssResult | Out-String;
        Write-Verbose ($output);
        Write-Output $output;
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List All
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss ListAll');
        $vmssList = Get-AzureRmVmss | ? Name -like 'vmsscrptestps*';
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Assert-True { $vmssList.Count -ge 0 }
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List from RG
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmss List');
        $vmssList = Get-AzureRmVmss -ResourceGroupName $rgname;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List Skus
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssSku');
        $skuList = Get-AzureRmVmssSku -ResourceGroupName $rgname  -VMScaleSetName $vmssName;
        $output = $skuList | Out-String;
        Write-Verbose ($output);

        # List All VMs
        Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM List');
        $vmListResult = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName; # -Select $null;
        $output = $vmListResult | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("StorageProfile") };

        # List each VM
        for ($i = 0; $i -lt 2; $i++)
        {
            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM');
            $vm = Get-AzureRmVmssVM -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vm;
            $output = $vm | Out-String;
            Write-Verbose ($output);
            Assert-True { $output.Contains("StorageProfile") };

            Write-Verbose ('Running Command : ' + 'Get-AzureRmVmssVM -InstanceView');
            $vmInstance = Get-AzureRmVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vmInstance;
            $output = $vmInstance | Out-String;
            Write-Verbose($output);
            Assert-True { $output.Contains("PlatformUpdateDomain") };
        }

        $st = Remove-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Reimage and Upgrade
#>
function Test-VirtualMachineScaleSetNextLink
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'southeastasia';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vmss_number = 180;

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false -SinglePlacementGroup $false `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssVmResult = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName | ? Name -like 'vmsscrptestps*';
        Assert-AreEqual $vmss_number $vmssVmResult.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Boot Diagnostics
#>
function Test-VirtualMachineScaleSetBootDiagnostics
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $storageUri = "https://" + $stoname + ".blob.core.windows.net/"
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Set-AzureRmVmssBootDiagnostic -Enabled $true -StorageUri $storageUri;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.sku.capacity;
        Assert-AreEqual 'standard_a0' $result.sku.name;
        Assert-AreEqual 'manual' $result.upgradepolicy.mode;

        # Boot Diagnostics Profile
        Assert-True {$result.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.Enabled};
        Assert-AreEqual $storageUri $result.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.StorageUri;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
           $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $result.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Boot Diagnostics Profile
        Assert-True {$vmssResult.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.Enabled};
        Assert-AreEqual $storageUri $vmssResult.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.StorageUri;

        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Identity
#>
function Test-VirtualMachineScaleSetIdentity
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $storageUri = "https://" + $stoname + ".blob.core.windows.net/"
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg -AssignIdentity `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.sku.capacity;
        Assert-AreEqual 'standard_a0' $result.sku.name;
        Assert-AreEqual 'manual' $result.upgradepolicy.mode;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $result.Identity.Type;
        Assert-NotNull $result.Identity.PrincipalId;
        Assert-NotNull $result.Identity.TenantId;
        Assert-Null $result.Identity.UserAssignedIdentities;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
           $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $result.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $vmssResult.Identity.Type;
        Assert-NotNull $vmssResult.Identity.PrincipalId;
        Assert-NotNull $vmssResult.Identity.TenantId;
        Assert-Null $vmssResult.Identity.UserAssignedIdentities;

        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;
        $output = $vmssInstanceViewResult | Out-String

        Update-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmssResult;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $vmssResult.Identity.Type;
        Assert-NotNull $vmssResult.Identity.PrincipalId;
        Assert-NotNull $vmssResult.Identity.TenantId;
        Assert-Null $vmssResult.Identity.UserAssignedIdentities;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Identity
#>
function Test-VirtualMachineScaleSetUserIdentity
{
    # Setup
    $subid = "24fb23e3-6ba3-41f0-9b6e-e41131d5d61e";
    $rgname = "UAITG123456";
    $loc = 'Central US';
    $identityname = $rgname + 'Identity';

    # To record this test run these commands first:
    #
    # New-AzureRmResourceGroup -Name $rgname -Location 'Central US'
    # New-AzureRmUserAssignedIdentity -ResourceGroupName $rgname -Name $identityname
    # 
    # Now get the identity :
    # 
    # $newUserIdentity = Get-AzureRmUserAssignedIdentity -ResourceGroupName $rgname -Name $identityname
    # $newUserId = $newUserIdentity.Id
    $newUserId = "/subscriptions/${subid}/resourcegroups/${rgname}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/${identityname}";

    try
    {
        # SRP
        $stoname = 'sto' + $rgname.ToLowerInvariant();
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName.ToLowerInvariant();

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            -IdentityType UserAssigned -IdentityId $newUserId `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName;
        
        Assert-AreEqual $vmssName $vmss.Name;
        Assert-AreEqual "UserAssigned" $vmss.Identity.Type;
        Assert-NotNull $vmss.Identity.UserAssignedIdentities;
        Assert-AreEqual 1 $vmss.Identity.UserAssignedIdentities.Count;
        Assert-True { $vmss.Identity.UserAssignedIdentities.ContainsKey($newUserId) };
        Assert-NotNull $vmss.Identity.UserAssignedIdentities[$newUserId].PrincipalId;
        Assert-NotNull $vmss.Identity.UserAssignedIdentities[$newUserId].ClientId;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Networking part
#>
function Test-VirtualMachineScaleSetNetworking
{
    # Setup
    $rgname = Get-ComputeTestResourceName
    $ipName = Get-ComputeTestResourceName
    $nsgName = Get-ComputeTestResourceName
    $namespace = "Microsoft.Compute";
    $type = "virtualMachineScaleSets/publicIPAddresses";
    $location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type};
    $loc = "";
    if($location) { $loc = $location.Locations[0] } else { $loc = "southeastasia" };

    try
    {
        # Common
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vmss_number = 2;

        $nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname -Name $nsgName -Location $loc;
        $nsgId = $nsg.Id;
        $dns = '10.11.12.13';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId -PublicIPAddressConfigurationName $ipName -PublicIPAddressConfigurationIdleTimeoutInMinutes 10 -DnsSetting "testvmssdnscom";
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false -SinglePlacementGroup $false `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg -DnsSettingsDnsServer $dns -NetworkSecurityGroupId $nsg.Id -EnableIPForwarding `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-NotNull $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations;
        Assert-AreEqual $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers $dns;
        Assert-AreEqual $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].NetworkSecurityGroup.Id $nsgId;
        Assert-NotNull $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations;
        Assert-AreEqual $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.Name $ipName;
        Assert-True {$result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].EnableIPForwarding};
        $output = $result | out-string
        Assert-True {$output.Contains("EnableIPForwarding")};

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Rolling Upgraade
#>
function Test-VirtualMachineScaleSetRollingUpgrade
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'southcentralus';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRMPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRMPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;


        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzureRmLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzureRmLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzureRmLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3368 -BackendPort 3370;
        $lbrule = New-AzureRmLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzureRmLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $storageUri = "https://" + $stoname + ".blob.core.windows.net/"
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;

        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Rolling' -NetworkInterfaceConfiguration $netCfg -HealthProbeId $expectedLb.Probes[0].Id `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Set-AzureRmVmssRollingUpgradePolicy -MaxBatchInstancePercent 90 -MaxUnhealthyInstancePercent 50 -MaxUnhealthyUpgradedInstancePercent 30 -PauseTimeBetweenBatches 10 `

        Assert-AreEqual 90 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent;
        Assert-AreEqual 50 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent;
        Assert-AreEqual 30 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent;
        Assert-AreEqual 10 $vmss.UpgradePolicy.RollingUpgradePolicy.PauseTimeBetweenBatches;
        $vmss.UpgradePolicy.RollingUpgradePolicy = $null;

        Assert-ThrowsContains { New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss; } `
            "is not registered for feature Microsoft.Network/AllowVmssHealthProbe";
        $vmss.VirtualMachineProfile.NetworkProfile.HealthProbe = $null;
        Assert-ThrowsContains { New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss; } `
            "health probe was not provided";
        $vmss.UpgradePolicy.Mode=[Microsoft.Azure.Management.Compute.Models.UpgradeMode]::Automatic;
        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        $job = Start-AzureRmVmssRollingOSUpgrade -ResourceGroupName $rgname -VMScaleSetName $vmssName -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Failed" $result.State;
        Assert-True { $result.Error[0].ToString().Contains("InternalExecutionError")};

        $job = Stop-AzureRmVmssRollingUpgrade -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Failed" $result.State;

        Assert-True { $result.Error[0].ToString().Contains("There is no ongoing Rolling Upgrade to cancel.")};
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Priority
#>
function Test-VirtualMachineScaleSetPriority
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $storageUri = "https://" + $stoname + ".blob.core.windows.net/"
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg -Priority 'Low' -EvictionPolicy 'Delete' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Low" $vmssResult.VirtualMachineProfile.Priority;
        Assert-AreEqual "Delete" $vmssResult.VirtualMachineProfile.EvictionPolicy;
        $output = $vmssResult | Out-String;
        Assert-True {$output.Contains("Priority")};
        Assert-True {$output.Contains("EvictionPolicy")};

        Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssResult;
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Low" $vmssResult.VirtualMachineProfile.Priority;
        Assert-AreEqual "Delete" $vmssResult.VirtualMachineProfile.EvictionPolicy;

        $vmssResult.VirtualMachineProfile.Priority = "Regular";
        Assert-ThrowsContains { Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssResult; } `
            "Changing property 'priority' is not allowed";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Write Accelerator Update
#>
function Test-VirtualMachineScaleSetWriteAcceleratorUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'WestEurope';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $result.Sku.Name;
        Assert-AreEqual 'Manual' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        # Verify the result of VMSS
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        Assert-ThrowsContains {
            $vmss | Update-AzureRmVmss -OsDiskWriteAccelerator $true; } `
            "not supported on disks with Write Accelerator enabled";

        $vmss2 = $vmss | Update-AzureRmVmss -OsDiskWriteAccelerator $false;
        Assert-AreEqual $false $vmss2.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Force Service Fabric UD Walk
#>
function Test-VirtualMachineScaleSetForceUDWalk
{
    # Setup
    $rgname = "vmsssfudtest"

    try
    {
        # Common
        $loc = 'CentralUS';
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;
        $testMode = Get-ComputeTestMode;

        if ($testMode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            $sf_endpoint = "https://${loc}.servicefabric.azure.com/runtime/clusters/828bd729-f938-41de-8fba-24139669e2d2";
            $sf_nodename = "nt1vm";
            $sf_durability = "Bronze";
        }
        else
        {
            ###
            ### For record test, first run the following commands.
            ###
            $password = ConvertTo-SecureString $adminPassword -AsPlainText -Force;
            New-AzureRmServiceFabricCluster -ResourceGroupName $rgname -Location $loc -VmPassword $password;
            $sf_cluster = Get-AzureRmServiceFabricCluster -ResourceGroupName $rgname -Name $rgname;
            $sf_endpoint = $sf_cluster.ClusterEndpoint;
            $sf_nodename = $sf_cluster.NodeTypes[0].Name;
            $sf_durability = $sf_cluster.NodeTypes[0].DurabilityLevel;
        }

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $imgRef = Get-DefaultCRPImage -loc $loc;

        $extname = 'udwalktest';
        $publisher = 'Microsoft.Azure.ServiceFabric';
        $exttype = 'ServiceFabricNode';
        $extver = '1.0';
        $settings = @{"clusterEndpoint"=${sf_endpoint};"nodeTypeRef"=${sf_nodename};"durabilityLevel"=${sf_durability};"enableParallelJobs"="true";"dataPath"="D:\\\\SvcFab"};

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -Setting $settings -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $LOC $RESULT.LOCATION;
        Assert-AreEqual 2 $RESULT.SKU.CAPACITY;
        Assert-AreEqual 'STANDARD_A0' $RESULT.SKU.NAME;
        Assert-AreEqual 'Automatic' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
           $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        # Verify the result of VMSS
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName;
        $job = Update-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss -SkuName 'Standard_A1' -AsJob;

        Wait-Seconds 300;
        $vmss_view = Get-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -InstanceView;
        $output = $vmss_view | Out-String

        $result = Repair-AzureRmVmssServiceFabricUpdateDomain -ResourceGroupName $rgname -VMScaleSetName $vmssName -PlatformUpdateDomain 0;
        Assert-True {$result.WalkPerformed};
        Assert-AreEqual 1 $result.NextPlatformUpdateDomain;

        $result = $vmss | Repair-AzureRmVmssServiceFabricUD -PlatformUpdateDomain 1;
        Assert-True {$result.WalkPerformed};
        Assert-AreEqual 2 $result.NextPlatformUpdateDomain;

        $result = Repair-AzureRmVmssServiceFabricUD -ResourceId $vmss.Id -PlatformUpdateDomain 2;
        Assert-True {$result.WalkPerformed};
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Redeploy and PerformMaintenance
#>
function Test-VirtualMachineScaleSetRedeploy
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines" "East US 2";
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Automatic' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.ToLowerInvariant().Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A1_v2' $result.Sku.Name;
        Assert-AreEqual 'Automatic' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $vhdContainer $result.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers[0];
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $id = $vmssVMs[0].InstanceId;

        # Redeploy operation
        Set-AzureRmVmss -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        Set-AzureRmVmss -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id;
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        Set-AzureRmVmssVM -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id;
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        # PerformMaintenance operation
        # Note that PerformMaintenace operation can only be performed when VMSS requires a maintenance  
        # and after the given subscription gets a permission for the operation due to the required maintenance.
        Assert-ThrowsContains { Set-AzureRmVmss -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName; } `
            "since the Subscription of this VM is not eligible";

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-ThrowsContains { Set-AzureRmVmss -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id; } `
            "since the Subscription of this VM is not eligible";

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-ThrowsContains { Set-AzureRmVmssVM -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id; } `
            "since the Subscription of this VM is not eligible";
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set VM Update
#>
function Test-VirtualMachineScaleSetVMUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines" "East US 2";
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = Get-PasswordForVM;

        $imgRef = Get-DefaultCRPImage -loc $loc;

        # Create VMSS with managed disk
        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Automatic' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.ToLowerInvariant().Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A1_v2' $result.Sku.Name;
        Assert-AreEqual 'Automatic' $result.UpgradePolicy.Mode;

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
           $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'None' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Add a data disk to VMSS VM using VMSS VM object (with piping)
        $diskname0 = 'datadisk0';
        New-AzureRmDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname0;
        $disk0 = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname0;

        $vmssVM = Add-AzureRmVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVMs[0] -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id;
        $vmssVM = Add-AzureRmVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Caching 'ReadOnly' -DiskSizeInGB 100 -Lun 0 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id;
        Assert-AreEqual 2 $vmssVM.StorageProfile.DataDisks.Count;

        $vmssVM = Remove-AzureRmVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Lun 1;
        Assert-AreEqual 1 $vmssVM.StorageProfile.DataDisks.Count;

        $vmssVM = Remove-AzureRmVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Lun 0;
        Assert-Null $vmssVM.StorageProfile.DataDisks;

        $result = $vmssVMs[0] `
                  | Add-AzureRmVmssVMDataDisk -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id `
                  | Update-AzureRmVmssVM;

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual 1 $vmssVMs[0].StorageProfile.DataDisks[0].Lun;
        Assert-AreEqual $diskname0 $vmssVMs[0].StorageProfile.DataDisks[0].Name;
        Assert-AreEqual 10 $vmssVMs[0].StorageProfile.DataDisks[0].DiskSizeGB;
        Assert-AreEqual "Attach" $vmssVMs[0].StorageProfile.DataDisks[0].CreateOption;
        Assert-AreEqual "Standard_LRS" $vmssVMs[0].StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk0.Id $vmssVMs[0].StorageProfile.DataDisks[0].ManagedDisk.Id;

        # Adding a data disk to a VMSS VM using resource group name, VMSS name and instance ID..
        $instance_id = $vmssVMs[0].InstanceId;
        $diskname1 = 'datadisk1';
        New-AzureRmDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname1;
        $disk1 = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname1;

        $diskname2 = 'datadisk2';
        New-AzureRmDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname2;
        $disk2 = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname2;

        Assert-ThrowsContains { New-AzureRmVMDataDisk -Name 'wrongdiskname' -Caching 'ReadOnly' -Lun 2 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk1.Id; } `
            "does not match with given managed disk ID";

        $datadisk1 = New-AzureRmVMDataDisk -Caching 'ReadOnly' -Lun 2 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk1.Id;
        $datadisk2 = New-AzureRmVMDataDisk -Caching 'ReadOnly' -Lun 3 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk2.Id;
        $result = Update-AzureRmVmssVM -ResourceGroupName  $rgname -VMScaleSetName $vmssName -InstanceId $instance_id -DataDisk $datadisk1,$datadisk2 

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-AreEqual 2 $vmssVMs[0].StorageProfile.DataDisks[1].Lun;
        Assert-AreEqual $diskname1 $vmssVMs[0].StorageProfile.DataDisks[1].Name;
        Assert-AreEqual 5 $vmssVMs[0].StorageProfile.DataDisks[1].DiskSizeGB;
        Assert-AreEqual "Attach" $vmssVMs[0].StorageProfile.DataDisks[1].CreateOption;
        Assert-AreEqual "Standard_LRS" $vmssVMs[0].StorageProfile.DataDisks[1].ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk1.Id $vmssVMs[0].StorageProfile.DataDisks[1].ManagedDisk.Id;

        Assert-AreEqual 3 $vmssVMs[0].StorageProfile.DataDisks[2].Lun;
        Assert-AreEqual $diskname2 $vmssVMs[0].StorageProfile.DataDisks[2].Name;
        Assert-AreEqual 5 $vmssVMs[0].StorageProfile.DataDisks[2].DiskSizeGB;
        Assert-AreEqual "Attach" $vmssVMs[0].StorageProfile.DataDisks[2].CreateOption;
        Assert-AreEqual "Standard_LRS" $vmssVMs[0].StorageProfile.DataDisks[2].ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk2.Id $vmssVMs[0].StorageProfile.DataDisks[2].ManagedDisk.Id;

        # Adding a data disk to a VMSS VM using resource ID.
        $resource_id = $vmssVMs[0].Id;
        $diskname3 = 'datadisk3';
        $diskconfig = New-AzureRmDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty;
        New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname3 -Disk $diskconfig
        $disk3 = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname3;

        $datadisk3 = New-AzureRmVMDataDisk -Caching 'ReadOnly' -Lun 4 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk3.Id;
        $result = Update-AzureRmVmssVM -ResourceId $resource_id -DataDisk $datadisk3

        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzureRmVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual 4 $vmssVMs[0].StorageProfile.DataDisks[3].Lun;
        Assert-AreEqual $diskname3 $vmssVMs[0].StorageProfile.DataDisks[3].Name;
        Assert-AreEqual 5 $vmssVMs[0].StorageProfile.DataDisks[3].DiskSizeGB;
        Assert-AreEqual "Attach" $vmssVMs[0].StorageProfile.DataDisks[3].CreateOption;
        Assert-AreEqual "Standard_LRS" $vmssVMs[0].StorageProfile.DataDisks[3].ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk3.Id $vmssVMs[0].StorageProfile.DataDisks[3].ManagedDisk.Id;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Auto Rollback
#>
function Test-VirtualMachineScaleSetAutoRollback
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines";
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $false `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "").ToLowerInvariant() $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $result.Sku.Name;
        Assert-AreEqual 'Automatic' $result.UpgradePolicy.Mode;
        Assert-False { $result.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };

        # Validate Network Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $true $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Primary;
        Assert-AreEqual $subnetId `
            $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet.Id;

        # Validate OS Profile
        Assert-AreEqual 'test' $result.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        Assert-AreEqual $adminUsername $result.VirtualMachineProfile.OsProfile.AdminUsername;
        Assert-Null $result.VirtualMachineProfile.OsProfile.AdminPassword;

        # Validate Storage Profile
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        # Validate Extension Profile
        Assert-AreEqual $extname $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Name;
        Assert-AreEqual $publisher $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Publisher;
        Assert-AreEqual $exttype $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].Type;
        Assert-AreEqual $extver $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].TypeHandlerVersion;
        Assert-AreEqual $true $result.VirtualMachineProfile.ExtensionProfile.Extensions[0].AutoUpgradeMinorVersion;

        # Verify the result of VMSS
        $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        $vmss2 = $vmss | Update-AzureRmVmss -DisableAutoRollback $true;
        Assert-True { $vmss2.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };

        $result = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -OSUpgradeHistory;
        Assert-Null $result
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
