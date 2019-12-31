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
Test Virtual Machine Scalet Set

PS C:\> Get-Command *VMSS* | ft Name,Version,ModuleName

Name                                            Version ModuleName
----                                            ------- ----------
Add-AzVmssAdditionalUnattendContent           1.2.4      AzureRM.Compute
Add-AzVmssExtension                           1.2.4      AzureRM.Compute
Add-AzVMSshPublicKey                          1.2.4      AzureRM.Compute
Add-AzVmssNetworkInterfaceConfiguration       1.2.4      AzureRM.Compute
Add-AzVmssSecret                              1.2.4      AzureRM.Compute
Add-AzVmssSshPublicKey                        1.2.4      AzureRM.Compute
Add-AzVmssWinRMListener                       1.2.4      AzureRM.Compute
Get-AzVmss                                    1.2.4      AzureRM.Compute
Get-AzVmssSku                                 1.2.4      AzureRM.Compute
Get-AzVmssVM                                  1.2.4      AzureRM.Compute
New-AzVmss                                    1.2.4      AzureRM.Compute
New-AzVmssConfig                              1.2.4      AzureRM.Compute
New-AzVmssIpConfig                            1.2.4      AzureRM.Compute
New-AzVmssVaultCertificateConfig              1.2.4      AzureRM.Compute
Remove-AzVmss                                 1.2.4      AzureRM.Compute
Remove-AzVmssExtension                        1.2.4      AzureRM.Compute
Remove-AzVmssNetworkInterfaceConfiguration    1.2.4      AzureRM.Compute
Restart-AzVmss                                1.2.4      AzureRM.Compute
Set-AzVmss                                    1.2.4      AzureRM.Compute
Set-AzVmssOsProfile                           1.2.4      AzureRM.Compute
Set-AzVmssStorageProfile                      1.2.4      AzureRM.Compute
Set-AzVmssVM                                  1.2.4      AzureRM.Compute
Start-AzVmss                                  1.2.4      AzureRM.Compute
Stop-AzVmss                                   1.2.4      AzureRM.Compute
Update-AzVmss                                 1.2.4      AzureRM.Compute
Update-AzVmssInstance                         1.2.4      AzureRM.Compute
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -Primary;
        Assert-True { $ipCfg.Primary };

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        Assert-False { $ipCfg.Primary };

        $vmss = New-AzVmssConfig -Location $loc -Zone "1" -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Remove-AzVmssExtension -Name $extname `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $ipCfg `
            | Remove-AzVmssNetworkInterfaceConfiguration -Name 'test2'

        $vmss | Add-AzVmssNetworkInterfaceConfiguration -Name 'test3' -IPConfiguration $ipCfg -EnableAcceleratedNetworking;
        Assert-True { $vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[1].EnableAcceleratedNetworking };
        $vmss | Remove-AzVmssNetworkInterfaceConfiguration -Name 'test3'

        if ($IsManaged -eq $true)
        {
            $vmss = $vmss | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                    -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
                    -ImageReferencePublisher $imgRef.PublisherName -OsDiskWriteAccelerator `
                    | Add-AzVmssDataDisk -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeGB  20 -Lun 1 -CreateOption Empty `
                    -StorageAccountType StandardLRS -WriteAccelerator;

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
            Assert-AreEqual 'StandardLRS' $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType;
            Assert-AreEqual $true $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].WriteAcceleratorEnabled;
            $vmss.VirtualMachineProfile.StorageProfile.DataDisks[0].WriteAcceleratorEnabled = $false;

            $vmss = $vmss | Remove-AzVmssDataDisk -Lun 1;
            Assert-AreEqual 0 $vmss.VirtualMachineProfile.StorageProfile.DataDisks.Count;
        }
        else
        {
            $vmss = $vmss| Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
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

        $job = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss -AsJob;
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

        Write-Verbose ('Running Command : ' + 'Get-AzVmss');
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $vmssName $vmssResult.Name;
        Assert-True { $vmssName -eq $vmssResult.Name };
        $output = $vmssResult | Out-String;
        Write-Verbose ($output);
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List All
        Write-Verbose ('Running Command : ' + 'Get-AzVmss ListAll');
        $vmssList = Get-AzVmss;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List from RG
        Write-Verbose ('Running Command : ' + 'Get-AzVmss List');
        $vmssList = Get-AzVmss -ResourceGroupName $rgname;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List Skus
        Write-Verbose ('Running Command : ' + 'Get-AzVmssSku');
        $skuList = Get-AzVmssSku -ResourceGroupName $rgname  -VMScaleSetName $vmssName;
        $output = $skuList | Out-String;
        Write-Verbose ($output);
        Write-Verbose ('Running Command : ' + 'Get-AzVmssSku | Format-Custom');
        $output = $skuList | Format-Custom | Out-String;
        Write-Verbose ($output);
        #Assert-True { $output.Contains("Sku") };

        # List All VMs
        Write-Verbose ('Running Command : ' + 'Get-AzVmssVM List');
        $vmListResult = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $output = $vmListResult | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("StorageProfile") };

        # List each VM
        for ($i = 0; $i -lt 2; $i++)
        {
            Write-Verbose ('Running Command : ' + 'Get-AzVmssVM');
            $vm = Get-AzVmssVM -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vm;
            $output = $vm | Out-String;
            Write-Verbose ($output);
            Assert-True { $output.Contains("StorageProfile") };

            Write-Verbose ('Running Command : ' + 'Get-AzVmssVM -InstanceView');
            $vmInstance = Get-AzVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vmInstance;
            $output = $vmInstance | Out-String;

            Write-Verbose($output);
            Assert-True { $output.Contains("PlatformUpdateDomain") };
        }

        $st = $vmssResult | Stop-AzVmss -StayProvision -Force;
        $job = $vmssResult | Stop-AzVmss -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job
        $job = $vmssResult | Start-AzVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job
        $job = $vmssResult | Restart-AzVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job

        if ($IsManaged -eq $true)
        {
            $job = $vmssResult | Set-AzVmss -ReimageAll -AsJob;
            $job | Wait-Job;
            $result = $job | Wait-Job;
            Assert-AreEqual "Completed" $result.State;
        }
        $instanceListParam = @();
        for ($i = 0; $i -lt 2; $i++)
        {
            $instanceListParam += $i.ToString();
        }

        $st = $vmssResult | Stop-AzVmss -StayProvision -InstanceId $instanceListParam -Force;
        $st = $vmssResult | Stop-AzVmss -InstanceId $instanceListParam -Force;
        $st = $vmssResult | Start-AzVmss -InstanceId $instanceListParam;
        $st = $vmssResult | Restart-AzVmss -InstanceId $instanceListParam;
        if ($IsManaged -eq $true)
        {
            for ($j = 0; $j -lt 2; $j++)
            {
                $job = Set-AzVmssVM -ReimageAll -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $j -AsJob;
                $result = $job | Wait-Job;
                Assert-AreEqual "Completed" $result.State;
                $st = $job | Receive-Job
            }
        }

        # Remove
        $st = Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1 -Force;
        $job = $vmssResult | Remove-AzVmss -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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
        
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;

        Assert-ThrowsContains {
            Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -DisablePasswordAuthentication $true -EnableAutomaticUpdate $true; } `
            "Cannot specify both Windows and Linux configurations.";

        $tags = @{test1 = "testval1"; test2 = "testval2" };
        $job = Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -Tag $tags -SkuCapacity 3 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $returned_tags = $vmss.Tags;
        Assert-AreEqual 2 $returned_tags.Count;
        Assert-AreEqual $tags["test1"] $returned_tags["test1"];
        Assert-AreEqual $tags["test2"] $returned_tags["test2"];
        Assert-AreEqual 3 $vmss.Sku.Capacity;

        $vmss2 = $vmss | Update-AzVmss -SkuCapacity 4;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssAdditionalUnattendContent -ComponentName  $aucComponentName -Content  $aucContent -PassName  $aucPassName -SettingName  $aucSetting `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $vmss.VirtualMachineProfile.OsProfile.WindowsConfiguration.AdditionalUnattendContent = $null;
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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

        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Manual Upgrade operation
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName
        $id = $vmssVMs[0].InstanceId

        $job = Update-AzVmssInstance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        # Reimage operation
        Set-AzVmss -Reimage -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Remove
        $st = Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id -Force;
        $st = Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;

        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3364 -BackendPort 3370;
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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

        $ipCfg = New-AzVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;
        Assert-AreEqual $expectedLb.InboundNatPools[0].Id $ipCfg.LoadBalancerInboundNatPools[0].Id;
        Assert-AreEqual $expectedLb.BackendAddressPools[0].Id $ipCfg.LoadBalancerBackendAddressPools[0].Id;
        Assert-AreEqual $subnetId $ipCfg.Subnet.Id;

        $settingString = ‘{ “AntimalwareEnabled”: true}’;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true -Setting $settingString `
            | Remove-AzVmssExtension -Name $extname `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $ipCfg `
            | Remove-AzVmssNetworkInterfaceConfiguration -Name 'test2' `
            | New-AzVmss -ResourceGroupName $rgname -Name $vmssName;

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

        Write-Verbose ('Running Command : ' + 'Get-AzVmss');
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssName -eq $vmssResult.Name };
        $output = $vmssResult | Out-String;
        Write-Verbose ($output);
        Write-Output $output;
        Assert-True { $output.Contains("VirtualMachineProfile") };

        # List All
        Write-Verbose ('Running Command : ' + 'Get-AzVmss ListAll');
        $vmssList = Get-AzVmss | ? Name -like 'vmsscrptestps*';
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Assert-True { $vmssList.Count -ge 0 }
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List from RG
        Write-Verbose ('Running Command : ' + 'Get-AzVmss List');
        $vmssList = Get-AzVmss -ResourceGroupName $rgname;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        # List Skus
        Write-Verbose ('Running Command : ' + 'Get-AzVmssSku');
        $skuList = Get-AzVmssSku -ResourceGroupName $rgname  -VMScaleSetName $vmssName;
        $output = $skuList | Out-String;
        Write-Verbose ($output);

        # List All VMs
        Write-Verbose ('Running Command : ' + 'Get-AzVmssVM List');
        $vmListResult = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName; # -Select $null;
        $output = $vmListResult | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("StorageProfile") };

        # List each VM
        for ($i = 0; $i -lt 2; $i++)
        {
            Write-Verbose ('Running Command : ' + 'Get-AzVmssVM');
            $vm = Get-AzVmssVM -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vm;
            $output = $vm | Out-String;
            Write-Verbose ($output);
            Assert-True { $output.Contains("StorageProfile") };

            Write-Verbose ('Running Command : ' + 'Get-AzVmssVM -InstanceView');
            $vmInstance = Get-AzVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $i;
            Assert-NotNull $vmInstance;
            $output = $vmInstance | Out-String;
            Write-Verbose($output);
            Assert-True { $output.Contains("PlatformUpdateDomain") };
        }

        $st = Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vmss_number = 180;

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false -SinglePlacementGroup $false `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssVmResult = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName | ? Name -like 'vmsscrptestps*';
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Set-AzVmssBootDiagnostic -Enabled $true -StorageUri $storageUri;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Boot Diagnostics Profile
        Assert-True {$vmssResult.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.Enabled};
        Assert-AreEqual $storageUri $vmssResult.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.StorageUri;

        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg -AssignIdentity `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.sku.capacity;
        Assert-AreEqual 'standard_a0' $result.sku.name;
        Assert-AreEqual 'manual' $result.upgradepolicy.mode;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $result.Identity.Type;
        Assert-NotNull $result.Identity.PrincipalId;
        Assert-NotNull $result.Identity.TenantId;

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

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $vmssResult.Identity.Type;
        Assert-NotNull $vmssResult.Identity.PrincipalId;
        Assert-NotNull $vmssResult.Identity.TenantId;

        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;
        $output = $vmssInstanceViewResult | Out-String
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
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        # MSI cmdlets are not ready yet.  Use a fake identity to test new paramters.
        $userIdentity = 'fakeidentity';

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg `
            -IdentityType UserAssigned -IdentityId "/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/resourceGroups/${rgname}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/${userIdentity}" `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        Assert-ThrowsContains { New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss; } `
             "it does not have permission to perform action 'Microsoft.ManagedIdentity";
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
    $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type};
    $loc = "";
    if($location) { $loc = $location.Locations[0] } else { $loc = "southeastasia" };

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vmss_number = 2;

        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgname -Name $nsgName -Location $loc;
        $nsgId = $nsg.Id;
        $dns = '10.11.12.13';

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -PublicIPAddressConfigurationName $ipName -PublicIPAddressConfigurationIdleTimeoutInMinutes 10 -DnsSetting "testvmssdnscom";
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -NetworkInterfaceConfiguration $netCfg -Overprovision $false -SinglePlacementGroup $false `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg -DnsSettingsDnsServer $dns -NetworkSecurityGroupId $nsg.Id -EnableIPForwarding `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;


        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3368 -BackendPort 3370;
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

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

        $ipCfg = New-AzVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Rolling' -NetworkInterfaceConfiguration $netCfg -HealthProbeId $expectedLb.Probes[0].Id `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Set-AzVmssRollingUpgradePolicy -MaxBatchInstancePercent 90 -MaxUnhealthyInstancePercent 50 -MaxUnhealthyUpgradedInstancePercent 30 -PauseTimeBetweenBatches 10 `

        Assert-AreEqual 90 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent;
        Assert-AreEqual 50 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent;
        Assert-AreEqual 30 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent;
        Assert-AreEqual 10 $vmss.UpgradePolicy.RollingUpgradePolicy.PauseTimeBetweenBatches;
        $vmss.UpgradePolicy.RollingUpgradePolicy = $null;

        New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss; 
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -NetworkInterfaceConfiguration $netCfg -Priority 'Regular' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Regular" $vmssResult.VirtualMachineProfile.Priority;
        $output = $vmssResult | Out-String;
        Assert-True {$output.Contains("Priority")};

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssResult;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Regular" $vmssResult.VirtualMachineProfile.Priority;

        $vmssResult.VirtualMachineProfile.Priority = "Low";
        Assert-ThrowsContains { Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssResult; } `
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        Assert-ThrowsContains {
            $vmss | Update-AzVmss -OsDiskWriteAccelerator $true; } `
            "Write Accelerator is supported with Premium_LRS storage account type only";

        $vmss2 = $vmss | Update-AzVmss -OsDiskWriteAccelerator $false;
        Assert-AreEqual $false $vmss2.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
