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
Add-AzVmssAdditionalUnattendContent           1.1.0      Az.Compute
Add-AzVmssExtension                           1.1.0      Az.Compute
Add-AzVMSshPublicKey                          1.1.0      Az.Compute
Add-AzVmssNetworkInterfaceConfiguration       1.1.0      Az.Compute
Add-AzVmssSecret                              1.1.0      Az.Compute
Add-AzVmssSshPublicKey                        1.1.0      Az.Compute
Add-AzVmssWinRMListener                       1.1.0      Az.Compute
Get-AzVmss                                    1.1.0      Az.Compute
Get-AzVmssSku                                 1.1.0      Az.Compute
Get-AzVmssVM                                  1.1.0      Az.Compute
New-AzVmss                                    1.1.0      Az.Compute
New-AzVmssConfig                              1.1.0      Az.Compute
New-AzVmssIpConfig                            1.1.0      Az.Compute
New-AzVmssVaultCertificateConfig              1.1.0      Az.Compute
Remove-AzVmss                                 1.1.0      Az.Compute
Remove-AzVmssExtension                        1.1.0      Az.Compute
Remove-AzVmssNetworkInterfaceConfiguration    1.1.0      Az.Compute
Restart-AzVmss                                1.1.0      Az.Compute
Set-AzVmss                                    1.1.0      Az.Compute
Set-AzVmssOsProfile                           1.1.0      Az.Compute
Set-AzVmssStorageProfile                      1.1.0      Az.Compute
Set-AzVmssVM                                  1.1.0      Az.Compute
Start-AzVmss                                  1.1.0      Az.Compute
Stop-AzVmss                                   1.1.0      Az.Compute
Update-AzVmss                                 1.1.0      Az.Compute
Update-AzVmssInstance                         1.1.0      Az.Compute
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
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
        $stnd = "Standard";

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

        $vmss = New-AzVmssConfig -Location $loc -Zone "1" -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -Overprovision $false -SecurityType $stnd `
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
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($vmssName -replace ".$") + "*"

        Write-Verbose ('Running Command : ' + 'Get-AzVmss ListAll');
        $vmssList = Get-AzVmss;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        $vmssList = Get-AzVmss -ResourceGroupName $wildcardRgQuery;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        $vmssList = Get-AzVmss -VMScaleSetName $wildcardNameQuery;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        $vmssList = Get-AzVmss -VMScaleSetName $vmssName;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        $vmssList = Get-AzVmss -ResourceGroupName $wildcardRgQuery -VMScaleSetName $vmssName;
        Assert-True { ($vmssList | select -ExpandProperty Name) -contains $vmssName };
        $output = $vmssList | Out-String;
        Write-Verbose ($output);
        Assert-False { $output.Contains("VirtualMachineProfile") };

        $vmssList = Get-AzVmss -ResourceGroupName $wildcardRgQuery -VMScaleSetName $wildcardNameQuery;
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

        Write-Verbose ('Running Command : ' + 'Get-AzVmss List');
        $vmssList = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $wildcardNameQuery;
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
        Verify-PSOperationStatusResponse $st;

        $job = $vmssResult | Stop-AzVmss -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        $job = $vmssResult | Start-AzVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;

        $job = $vmssResult | Restart-AzVmss -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        if ($IsManaged -eq $true)
        {
            $job = $vmssResult | Set-AzVmss -ReimageAll -AsJob;
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

        $st = $vmssResult | Stop-AzVmss -StayProvision -InstanceId $instanceListParam -Force;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Stop-AzVmss -InstanceId $instanceListParam -Force;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Start-AzVmss -InstanceId $instanceListParam;
        Verify-PSOperationStatusResponse $st;

        $st = $vmssResult | Restart-AzVmss -InstanceId $instanceListParam;
        Verify-PSOperationStatusResponse $st;

        if ($IsManaged -eq $true)
        {
            for ($j = 0; $j -lt 2; $j++)
            {
                $job = Set-AzVmssVM -ReimageAll -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $j -AsJob;
                $result = $job | Wait-Job;
                Assert-AreEqual "Completed" $result.State;
                $st = $job | Receive-Job;
                Verify-PSOperationStatusResponse $st;
            }
        }

        # Remove
        $st = Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1 -Force;
        Verify-PSOperationStatusResponse $st;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-VirtualMachineScaleSetInEdgeZone
{
    $ResourceGroupName = Get-ComputeTestResourceName;
    $Location = "westus";
    $EdgeZone = "microsoftlosangeles1";
    $ScaleSetName = "scalesetinedgezone";
    $stnd = "Standard";
    try
    {
        $config = New-AzVmssConfig -Location $Location -EdgeZone $EdgeZone;
        Assert-AreEqual $config.ExtendedLocation.Name $EdgeZone

        New-AzResourceGroup -ResourceGroupName $ResourceGroupName -Location $Location;

        $VMLocalAdminUser = "LocalAdminUser";
        $VMLocalAdminSecurePassword = ConvertTo-SecureString $PLACEHOLDER -AsPlainText -Force;

        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

        New-AzVmss `
          -SecurityType $stnd `
          -ResourceGroupName $ResourceGroupName `
          -Location $Location `
          -EdgeZone $EdgeZone `
          -VMScaleSetName $ScaleSetName `
          -VirtualNetworkName "myVnet" `
          -SubnetName "mySubnet" `
          -PublicIpAddressName "myPublicIPAddress" `
          -LoadBalancerName "myLoadBalancer" `
          -UpgradePolicyMode "Automatic" `
          -Credential $Credential `
          -DomainNameLabel "scalesetinedgezone-70f698"

        $vmss = Get-AzVmss -ResourceGroupName $ResourceGroupName -VMScaleSetName $ScaleSetName

        Assert-AreEqual $vmss.ExtendedLocation.Name $EdgeZone
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $ResourceGroupName
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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

        $imgRef = Get-DefaultCRPImage -loc $loc -New $True;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A1_v2' $result.Sku.Name;
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
        # Assert-AreEqual 0 $vmss.Tags.Count; commenting out because there are default tags being placed by internal policy
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
        Assert-True { $returned_tags.Count -ge 2 }
        Assert-AreEqual $tags["test1"] $returned_tags["test1"];
        Assert-AreEqual $tags["test2"] $returned_tags["test2"];
        Assert-AreEqual 3 $vmss.Sku.Capacity;

        $vmss2 = $vmss | Update-AzVmss -SkuCapacity 4;
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
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
        Assert-AreEqual 'Standard_A1_v2' $result.Sku.Name;
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
Test Virtual Machine Scale Set Reimage with tempDisk
#>
function Test-VirtualMachineScaleSetReimageTempDisk
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_DS1_v2' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -DiffDiskSetting 'Local';

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_DS1_v2' $result.Sku.Name;
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
        Assert-AreEqual 'FromImage' $result.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption;
        Assert-AreEqual 'ReadOnly' $result.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
        Assert-AreEqual $imgRef.Offer $result.VirtualMachineProfile.StorageProfile.ImageReference.Offer;
        Assert-AreEqual $imgRef.Skus $result.VirtualMachineProfile.StorageProfile.ImageReference.Sku;
        Assert-AreEqual $imgRef.Version $result.VirtualMachineProfile.StorageProfile.ImageReference.Version;
        Assert-AreEqual $imgRef.PublisherName $result.VirtualMachineProfile.StorageProfile.ImageReference.Publisher;

        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName
        $id = $vmssVMs[0].InstanceId

        # Reimage operation
        Set-AzVmss -Reimage -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id -TempDisk;
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'automatic' -SecurityType $stnd `
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
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -Overprovision $false -SinglePlacementGroup $false -SecurityType $stnd `
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
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
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
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Manual' -IdentityType "SystemAssigned" -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.sku.capacity;
        Assert-AreEqual 'Standard_A1_v2' $result.sku.name;
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

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Validate VMSS Identity
        Assert-AreEqual "SystemAssigned" $vmssResult.Identity.Type;
        Assert-NotNull $vmssResult.Identity.PrincipalId;
        Assert-NotNull $vmssResult.Identity.TenantId;
        Assert-Null $vmssResult.Identity.UserAssignedIdentities;

        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;
        $output = $vmssInstanceViewResult | Out-String

        Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmssResult;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

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
    $stnd = "Standard";

    # To record this test run these commands first:
    #
    # New-AzResourceGroup -Name $rgname -Location 'Central US'
    # New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name $identityname
    #
    # Now get the identity :
    #
    # $newUserIdentity = Get-AzUserAssignedIdentity -ResourceGroupName $rgname -Name $identityname
    # $newUserId = $newUserIdentity.Id
    $newUserId = "/subscriptions/${subid}/resourcegroups/${rgname}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/${identityname}";

    try
    {
        # SRP
        $stoname = 'sto' + $rgname.ToLowerInvariant();
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
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName.ToLowerInvariant();

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
            -IdentityType UserAssigned -IdentityId $newUserId `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;

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
    $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type};
    $loc = "";
    $stnd = "Standard";
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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -PublicIPAddressConfigurationName $ipName -PublicIPAddressConfigurationIdleTimeoutInMinutes 10 -DnsSetting "testvmssdnscom" -PublicIPAddressVersion "IPv4";
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity $vmss_number -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -Overprovision $false -SinglePlacementGroup $false -SecurityType $stnd `
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
        Assert-AreEqual "IPv4" $result.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.PublicIPAddressVersion;
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
        [string]$loc = "westus2";
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Static -DomainNameLabel ('pubip' + $rgname);
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

        $imgRef = Get-DefaultCRPImage -loc $loc -New $True;
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

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_DS1_v2' -UpgradePolicyMode 'Rolling' -HealthProbeId $expectedLb.Probes[0].Id -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true `
            | Set-AzVmssRollingUpgradePolicy -MaxBatchInstancePercent 50 -MaxUnhealthyInstancePercent 90 -MaxUnhealthyUpgradedInstancePercent 80 -PauseTimeBetweenBatches PT60S;

        Assert-AreEqual 50 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent;
        Assert-AreEqual 90 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent;
        Assert-AreEqual 80 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent;
        Assert-AreEqual PT60S $vmss.UpgradePolicy.RollingUpgradePolicy.PauseTimeBetweenBatches;
        New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual 'Rolling' $vmssResult.UpgradePolicy.Mode;
        Assert-AreEqual 50 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent;
        Assert-AreEqual 90 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent;
        Assert-AreEqual 80 $vmss.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent;
        Assert-AreEqual PT60S $vmss.UpgradePolicy.RollingUpgradePolicy.PauseTimeBetweenBatches;

        $job = Start-AzVmssRollingOSUpgrade -ResourceGroupName $rgname -VMScaleSetName $vmssName -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Failed" $result.State;
        Write-Debug $result;
        Write-Debug $result.Error[0].ToString();
        Assert-True { $result.Error[0].ToString().Contains("failed due to exceeding the MaxUnhealthyInstancePercent value ")};

        $job = Stop-AzVmssRollingUpgrade -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force -AsJob;
        $result = $job | Wait-Job;
        Write-Debug $result;
        Write-Debug $result.Error[0].ToString();
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
        $loc = 'eastus';
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_DS2_v2' -UpgradePolicyMode 'Manual' -Priority 'Low' -EvictionPolicy 'Delete' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Low" $vmssResult.VirtualMachineProfile.Priority;
        Assert-AreEqual "Delete" $vmssResult.VirtualMachineProfile.EvictionPolicy;
        $output = $vmssResult | Out-String;
        Assert-True {$output.Contains("Priority")};
        Assert-True {$output.Contains("EvictionPolicy")};

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssResult;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Low" $vmssResult.VirtualMachineProfile.Priority;
        Assert-AreEqual "Delete" $vmssResult.VirtualMachineProfile.EvictionPolicy;

        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName
        $id = $vmssVMs[0].InstanceId

        Set-AzVmssVM -ResourceGroupName $rgname -Name $vmssName -InstanceId $id -SimulateEviction;
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Low" $vmssResult.VirtualMachineProfile.Priority;
        Assert-AreEqual "Delete" $vmssResult.VirtualMachineProfile.EvictionPolicy;

        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssInstanceViewResult.VirtualMachine.StatusesSummary[0].Code;

        $vmssvmResult = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id;
        Assert-AreEqual "Succeeded" $vmssvmResult.ProvisioningState;

        $vmssResult.VirtualMachineProfile.Priority = "Regular";
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
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_DS1_v2' -UpgradePolicyMode 'Manual' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' -ManagedDisk 'Premium_LRS' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_DS1_v2' $result.Sku.Name;
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
        # Assert-AreEqual 0 $vmss.Tags.Count; commenting out because there are default tags being placed by internal policy
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        Assert-ThrowsContains {
            $vmss | Update-AzVmss -OsDiskWriteAccelerator $true; } `
            "not supported";

        $vmss2 = $vmss | Update-AzVmss -OsDiskWriteAccelerator $false;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $testMode = Get-ComputeTestMode;
        $stnd = "Standard";

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
            New-AzServiceFabricCluster -ResourceGroupName $rgname -Location $loc -VmPassword $password;
            $sf_cluster = Get-AzServiceFabricCluster -ResourceGroupName $rgname -Name $rgname;
            $sf_endpoint = $sf_cluster.ClusterEndpoint;
            $sf_nodename = $sf_cluster.NodeTypes[0].Name;
            $sf_durability = $sf_cluster.NodeTypes[0].DurabilityLevel;
        }

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $imgRef = Get-DefaultCRPImage -loc $loc;

        $extname = 'udwalktest';
        $publisher = 'Microsoft.Azure.ServiceFabric';
        $exttype = 'ServiceFabricNode';
        $extver = '1.0';
        $settings = @{"clusterEndpoint"=${sf_endpoint};"nodeTypeRef"=${sf_nodename};"durabilityLevel"=${sf_durability};"enableParallelJobs"="true";"dataPath"="D:\\\\SvcFab"};

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -Setting $settings -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        Assert-AreEqual 0 $vmss.Tags.Count;
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        $job = Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss -SkuName 'Standard_A1' -AsJob;

        Wait-Seconds 300;
        $vmss_view = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName -InstanceView;
        $output = $vmss_view | Out-String

        $result = Repair-AzVmssServiceFabricUpdateDomain -ResourceGroupName $rgname -VMScaleSetName $vmssName -PlatformUpdateDomain 0;
        Assert-True {$result.WalkPerformed};
        Assert-AreEqual 1 $result.NextPlatformUpdateDomain;

        $result = $vmss | Repair-AzVmssServiceFabricUD -PlatformUpdateDomain 1;
        Assert-True {$result.WalkPerformed};
        Assert-AreEqual 2 $result.NextPlatformUpdateDomain;

        $result = Repair-AzVmssServiceFabricUD -ResourceId $vmss.Id -PlatformUpdateDomain 2;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Automatic' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

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

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $id = $vmssVMs[0].InstanceId;

        # Redeploy operation
        Set-AzVmss -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        Set-AzVmss -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        Set-AzVmssVM -Redeploy -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmss.ProvisioningState;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "Succeeded" $vmssVMs[0].ProvisioningState;
        Assert-AreEqual "Succeeded" $vmssVMs[1].ProvisioningState;

        # PerformMaintenance operation
        # Note that PerformMaintenace operation can only be performed when VMSS requires a maintenance
        # and after the given subscription gets a permission for the operation due to the required maintenance.
        Assert-ThrowsContains { Set-AzVmss -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName; } `
            "since the Subscription of this VM is not eligible";

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-ThrowsContains { Set-AzVmss -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id; } `
            "since the Subscription of this VM is not eligible";

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-ThrowsContains { Set-AzVmssVM -PerformMaintenance -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $id; } `
            "since the Subscription of this VM is not eligible";
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
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
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $adminPassword = Get-PasswordForVM;

        $imgRef = Get-DefaultCRPImage -loc $loc;

        # Create VMSS with managed disk
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A2_v2' -UpgradePolicyMode 'Automatic' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.ToLowerInvariant().Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A2_v2' $result.Sku.Name;
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

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        $result = $vmssVMs[0]  | Update-AzVmssVM -ProtectFromScaleIn $true -ProtectFromScaleSetAction $true;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssVMs[0].ProtectionPolicy.ProtectFromScaleIn };
        Assert-True { $vmssVMs[0].ProtectionPolicy.ProtectFromScaleSetActions };

        # Add a data disk to VMSS VM using VMSS VM object (with piping)
        $diskname0 = 'datadisk0';
        New-AzDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;
        $disk0 = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;

        $vmssVM = Add-AzVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVMs[0] -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id;
        $vmssVM = Add-AzVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Caching 'ReadOnly' -DiskSizeInGB 100 -Lun 0 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id;
        Assert-AreEqual 2 $vmssVM.StorageProfile.DataDisks.Count;

        $vmssVM = Remove-AzVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Lun 1;
        Assert-AreEqual 1 $vmssVM.StorageProfile.DataDisks.Count;

        $vmssVM = Remove-AzVmssVMDataDisk -VirtualMachineScaleSetVM $vmssVM -Lun 0;
        Assert-NotNull $vmssVM.StorageProfile.DataDisks;
        Assert-AreEqual 0 $vmssVM.StorageProfile.DataDisks.Count;

        $result = $vmssVMs[0] `
                  | Add-AzVmssVMDataDisk -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk0.Id `
                  | Update-AzVmssVM;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual 1 $vmssVMs[0].StorageProfile.DataDisks[0].Lun;
        Assert-AreEqual $diskname0 $vmssVMs[0].StorageProfile.DataDisks[0].Name;
        Assert-AreEqual 10 $vmssVMs[0].StorageProfile.DataDisks[0].DiskSizeGB;
        Assert-AreEqual "Attach" $vmssVMs[0].StorageProfile.DataDisks[0].CreateOption;
        Assert-AreEqual "Standard_LRS" $vmssVMs[0].StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk0.Id $vmssVMs[0].StorageProfile.DataDisks[0].ManagedDisk.Id;

        # Adding a data disk to a VMSS VM using resource group name, VMSS name and instance ID..
        $instance_id = $vmssVMs[0].InstanceId;
        $diskname1 = 'datadisk1';
        New-AzDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzDisk -ResourceGroupName $rgname -DiskName $diskname1;
        $disk1 = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname1;

        $diskname2 = 'datadisk2';
        New-AzDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
        | New-AzDisk -ResourceGroupName $rgname -DiskName $diskname2;
        $disk2 = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname2;

        Assert-ThrowsContains { New-AzVMDataDisk -Name 'wrongdiskname' -Caching 'ReadOnly' -Lun 2 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk1.Id; } `
            "does not match with given managed disk ID";

        $datadisk1 = New-AzVMDataDisk -Caching 'ReadOnly' -Lun 2 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk1.Id;
        $datadisk2 = New-AzVMDataDisk -Caching 'ReadOnly' -Lun 3 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk2.Id;
        $result = Update-AzVmssVM -ResourceGroupName  $rgname -VMScaleSetName $vmssName -InstanceId $instance_id -DataDisk $datadisk1,$datadisk2

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;

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
        $diskconfig = New-AzDiskConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty;
        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname3 -Disk $diskconfig
        $disk3 = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname3;

        $datadisk3 = New-AzVMDataDisk -Caching 'ReadOnly' -Lun 4 -CreateOption Attach -StorageAccountType Standard_LRS -ManagedDiskId $disk3.Id;
        $result = Update-AzVmssVM -ResourceId $resource_id -DataDisk $datadisk3;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $vmssVMs = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $imgRef = Get-DefaultCRPImage -loc $loc -New $True;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1_v2' -UpgradePolicyMode 'Automatic' -DisableAutoRollback $false -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName `
            | Add-AzVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "").ToLowerInvariant() $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A1_v2' $result.Sku.Name;
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
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $null $vmss.Zones;
        # Assert-AreEqual 0 $vmss.Tags.Count;  commenting out because there are default tags being placed by internal policy
        Assert-AreEqual 2 $vmss.Sku.Capacity;
        Assert-AreEqual $false $vmss.VirtualMachineProfile.StorageProfile.OsDisk.WriteAcceleratorEnabled;

        $vmssVMsStatus = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        $vmssVMsStatusFullOutput = $vmssVMsStatus | fc | Out-String;
        Assert-True { $vmssVMsStatusFullOutput.Contains("InstanceView") };

        $vmss2 = $vmss | Update-AzVmss -DisableAutoRollback $true;
        Assert-True { $vmss2.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback };

        $result = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -OSUpgradeHistory;
        Assert-Null $result

        $vmssVMsStatus = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        $vmssVMsStatusFullOutput = $vmssVMsStatus | fc | Out-String;
        Assert-True { $vmssVMsStatusFullOutput.Contains("InstanceView") };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set with ScaleInPolicy
#>
function Test-VirtualMachineScaleSetScaleInPolicy
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Automatic' -ScaleInPolicy 'OldestVM' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "").ToLowerInvariant() $result.Location;
        Assert-AreEqual 2 $result.Sku.Capacity;
        Assert-AreEqual 'Standard_A0' $result.Sku.Name;
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

        # Validate ScaleInPolicy
        Assert-AreEqual "OldestVM" $result.ScaleInPolicy.Rules;

        Wait-Seconds 600;

        # Verify the result of VMSS
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "OldestVM" $vmss.ScaleInPolicy.Rules;

        $vmssVMsStatus = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "ProvisioningState/succeeded" $vmssVMsStatus.Statuses[0].Code;

        # Update VMSS with ScaleInPolicy
        Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -ScaleInPolicy 'NewestVM';
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual "NewestVM" $vmss.ScaleInPolicy.Rules;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Automatic Repairs Policy
#>
function Test-VirtualMachineScaleSetAutoRepair
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
        $stnd = "Standard";

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
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $ipCfg = New-AzVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' -HealthProbeId $expectedLb.Probes[0].Id `
                                 -EnableAutomaticRepair -AutomaticRepairGracePeriod "PT10S" -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer;

        Assert-True { $vmss.AutomaticRepairsPolicy.Enabled };
        Assert-AreEqual "PT10S" $vmss.AutomaticRepairsPolicy.GracePeriod;
        New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssResult.AutomaticRepairsPolicy.Enabled };
        Assert-AreEqual "PT10S" $vmssResult.AutomaticRepairsPolicy.GracePeriod;
        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "AutomaticRepairs" $vmssInstanceViewResult.OrchestrationServices[0].ServiceName;
        Assert-AreEqual "Running" $vmssInstanceViewResult.OrchestrationServices[0].ServiceState;

        Set-AzVmssOrchestrationServiceState -ResourceGroupName $rgname -VMScaleSetName $vmssName -ServiceName "AutomaticRepairs" -Action "Suspend";
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssResult.AutomaticRepairsPolicy.Enabled };
        Assert-AreEqual "PT10S" $vmssResult.AutomaticRepairsPolicy.GracePeriod;
        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "AutomaticRepairs" $vmssInstanceViewResult.OrchestrationServices[0].ServiceName;
        Assert-AreEqual "Suspended" $vmssInstanceViewResult.OrchestrationServices[0].ServiceState;

        $vmssResult | Set-AzVmssOrchestrationServiceState -ServiceName "AutomaticRepairs" -Action "Resume";
        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True { $vmssResult.AutomaticRepairsPolicy.Enabled };
        Assert-AreEqual "PT10S" $vmssResult.AutomaticRepairsPolicy.GracePeriod;
        $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        Assert-AreEqual "AutomaticRepairs" $vmssInstanceViewResult.OrchestrationServices[0].ServiceName;
        Assert-AreEqual "Running" $vmssInstanceViewResult.OrchestrationServices[0].ServiceState;

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -EnableAutomaticRepair $false;

        $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-False { $vmssResult.AutomaticRepairsPolicy.Enabled };
        Assert-AreEqual "PT10S" $vmssResult.AutomaticRepairsPolicy.GracePeriod;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

}

<#
.SYNOPSIS
Test Virtual Machine Scale Set warning if not using latest image version
#>
function Test-VirtualMachineScaleSetImageVersion
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = "westus" ;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;

        # Create LoadBalancer
        $frontendName = Get-ResourceName
        $backendAddressPoolName = Get-ResourceName
        $probeName = Get-ResourceName
        $inboundNatPoolName = Get-ResourceName
        $lbruleName = Get-ResourceName
        $lbName = Get-ResourceName

        $frontend = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $pubip
        $backendAddressPool = New-AzLoadBalancerBackendAddressPoolConfig -Name $backendAddressPoolName
        $probe = New-AzLoadBalancerProbeConfig -Name $probeName -RequestPath healthcheck.aspx -Protocol http -Port 80 -IntervalInSeconds 15 -ProbeCount 2
        $inboundNatPool = New-AzLoadBalancerInboundNatPoolConfig -Name $inboundNatPoolName -FrontendIPConfigurationId `
            $frontend.Id -Protocol Tcp -FrontendPortRangeStart 3360 -FrontendPortRangeEnd 3368 -BackendPort 3370;
        $lbrule = New-AzLoadBalancerRuleConfig -Name $lbruleName `
            -FrontendIPConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -Protocol Tcp -FrontendPort 80 -BackendPort 80 `
            -IdleTimeoutInMinutes 15 -EnableFloatingIP -LoadDistribution SourceIP;
        $actualLb = New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $loc `
            -FrontendIpConfiguration $frontend -BackendAddressPool $backendAddressPool `
            -Probe $probe -LoadBalancingRule $lbrule -InboundNatPool $inboundNatPool;
        $expectedLb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $ExtName = "CSETest";
        $Publisher = "Microsoft.Compute";
        $ExtType = "BGInfo";
        $ExtVer = "2.1";

        $ipCfg = New-AzVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_E4-2ds_v4' -UpgradePolicyMode 'Automatic' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test2' -IPConfiguration $IPCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzVmssExtension -Name $ExtName -Publisher $Publisher -Type $ExtType -TypeHandlerVersion $ExtVer -AutoUpgradeMinorVersion $True

        Start-Transcript -Path "transcript.txt"
        #create the vmss 
        New-AzVmss -ResourceGroup $rgname -Name $vmssName -VirtualMachineScaleSet $vmss
        Stop-Transcript

        $wordToFind="You are deploying VMSS pinned to a specific image version from Azure Marketplace.";
        $file = (Get-Content -path "transcript.txt") -join ' ';
        Assert-True { $file -match $wordToFind } ;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
    testing encryptionAtHost cmdlet for
    new-azvmss - create vmss using simple parameter set and hostencryption tag.
    update-azvmss test boolean parameter
    new-azvmssconfig
#>
function Test-VirtualMachineScaleSetEncryptionAtHost
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-Location "Microsoft.Compute" "virtualMachines";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $vmssName = 'vmsswithconfig';
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $securePassword = ConvertTo-SecureString $adminPassword -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $securePassword);


        $imgRef = Get-DefaultCRPImage -loc $loc -New $True;
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_E4-2ds_v4' -UpgradePolicyMode 'Manual' -EncryptionAtHost -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName ;

        #creating vmss using new-azvmss default parameter set which uses New-VmssConfig with -EncryptionAtHost parameter
        $vmssResult1 = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss
        #creating vmss using New-azvmss simple parameter set
        $vmssResult2 = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName "newvmss" -Credential $cred -EncryptionAtHost -DomainNameLabel "domainlabel" -SecurityType $stnd

        Assert-AreEqual $vmssResult1.VirtualMachineProfile.SecurityProfile.EncryptionAtHost True;
        Assert-AreEqual $vmssResult2.VirtualMachineProfile.SecurityProfile.EncryptionAtHost True;

        #using Update-azvmss to turn off encryptionAtHost
        $updatedVM = Update-azvmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmssResult1 -EncryptionAtHost $false

        Assert-False { $updatedVM.VirtualMachineProfile.SecurityProfile.EncryptionAtHost };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
    create a VMSS in orchestration mode then add a vm to it
#>
function Test-VirtualMachineScaleSetOrchestrationVM
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = "eastus"
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # New VMSS Parameters
        $vmssName = 'vmssOrchestrationMode' + $rgname;
        $vmName = 'vm' + $rgname;
        $domainName = 'domain' + $rgname;
        $stnd = "Standard";

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $adminPassword -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $securePassword);

        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $vneid = $vnet.Id
        $subnetId = $vnet.Subnets[0].Id;

        $ipConfig = New-AzVmssIpConfig -Name 'test' -SubnetId $subnetId

        $vmssConfig = New-AzVmssConfig `
            -Location $loc `
            -SkuCapacity 2 `
            -SkuName "Standard_DS1_v2" `
            -OrchestrationMode 'Flexible' `
            -PlatformFaultDomainCount 2 `
            -SecurityType $stnd;

        Set-AzVmssStorageProfile $vmssConfig `
          -OsDiskCreateOption "FromImage" `
          -ImageReferencePublisher "Canonical" `
          -ImageReferenceOffer "UbuntuServer" `
          -ImageReferenceSku "18.04-LTS" `
          -ImageReferenceVersion "latest"

        Set-AzVmssOsProfile $vmssConfig `
          -AdminUsername $cred.UserName `
          -AdminPassword $cred.Password `
          -ComputerNamePrefix $vmname

        Add-AzVmssNetworkInterfaceConfiguration `
          -VirtualMachineScaleSet $vmssConfig `
          -Name 'test' `
          -Primary $true `
          -IPConfiguration $ipConfig `
          -networkApiVersion "2020-11-01"

        $VmssFlex = New-AzVmss `
          -ResourceGroupName $rgname `
          -Name $vmssName `
          -VirtualMachineScaleSet $vmssConfig

        $vm = new-azvm -resourcegroupname $rgname -location $loc -name $vmname -credential $cred -domainnamelabel $domainName -vmssid $VmssFlex.id -SecurityType $stnd;

        Assert-AreEqual $VmssFlex.id $vm.virtualmachinescaleset.id;
        Assert-AreEqual $VmssFlex.orchestrationMode "Flexible";

        # Test PlatformFaultDomainCount parameter
        $vmssNameSimple = $vmssname + "Simple";
        $vmssNameDefault = $vmssname + "Default";
        $platformFaultDomainCount = 5;
        $platformFaultDomainCountConfig = 3;
        $zone = "2";
        $domainNameLabel = $rgname + "domainlabel";
        $VmSku = "Standard_D2s_v3";


        $vmssConfigFaultDomain = New-AzVmssConfig -Location $loc -PlatformFaultDomainCount $platformFaultDomainCountConfig -SecurityType $stnd;
        Assert-NotNull $vmssConfigFaultDomain;
        Assert-AreEqual $vmssConfigFaultDomain.PlatformFaultDomainCount $platformFaultDomainCountConfig;

        # PlatformFaultDomainCount in New-AzVmss DefaultParameterSet
        $vmssDefault = New-AzVmss -Name $vmssNameDefault -ResourceGroup $rgname -VirtualMachineScaleSet $vmssConfigFaultDomain;
        Assert-NotNull $vmssDefault;
        Assert-AreEqual $vmssDefault.PlatformFaultDomainCount $platformFaultDomainCountConfig;

        # PlatformFaultDomainCount in New-AzVmss SimpleParameterSet
        $vmssSimple = New-AzVmss -Name $vmssNameSimple -ResourceGroup $rgname -Credential $cred -Zone $zone -VmSize $VmSku -DomainNameLabel $domainNameLabel -PlatformFaultDomainCount $platformFaultDomainCount -SecurityType $stnd;
        Assert-NotNull $vmssSimple;
        Assert-AreEqual $vmssSimple.PlatformFaultDomainCount $platformFaultDomainCount;



    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
    testing encryptionAtHost cmdlet for
    new-azvmss - create vmss using simple parameter set and hostencryption tag.
    update-azvmss test boolean parameter
    new-azvmssconfig
#>
function Test-VirtualMachineScaleSetAssignedHost
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $zone = "2"
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

        # Hostgroup and Host
        $hostGroupName = $rgname + "HostGroup"
        $hostGroup = New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 2 -Zone $zone -SupportAutomaticPlacement $true -Tag @{key1 = "val1"};

        $Sku = "Esv3-Type1"
        $hostName = $rgname + "Host"
        $host_ = New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku $Sku -PlatformFaultDomain 1 -Tag @{test = "true"}

        # Creating a new vmss
        $VmSku = "Standard_E2s_v3"
        $domainNameLabel = "domainlabel"
        $vmssname = "MyVmss"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $vmss = New-AzVmss -Name $vmssname -ResourceGroup $rgname -Credential $cred -HostGroupId $hostGroup.Id -Zone $zone -VmSize $VmSku -DomainNameLabel $domainNameLabel -SecurityType $stnd

        $vmssResult = Get-AzVmssVM -InstanceView -ResourceGroupName $rgname -VMScaleSetName $vmssname;

        Assert-AreEqual $host_.Id $vmssResult[0].InstanceView.AssignedHost;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test the VMSS Extension rolling upgrade cmdlet.
This is a LiveOnly test and requires some manual setup.
#>
function Test-VirtualMachineScaleSetExtRollingUpgrade
{
    # create a VM scale set manually in Azure Portal, use its default values.
    # Provide the Location, ResourceGroupName, and VM scale set name below.

    try
    {

        # Common
        [string]$loc = "eastus";

        $rgname = "adamvmssupdate";
        $vmssname = "windowsvmss";
        $vmss = Get-Azvmss -ResourceGroupName $rgname -VMScaleSetName $vmssname;

        Add-AzVmssExtension -VirtualMachineScaleSet $vmss -Name "testExtension" -Publisher Microsoft.CPlat.Core -Type "NullWindows" -TypeHandlerVersion "3.0" -AutoUpgradeMinorVersion $True -Setting "";

        $job = Start-AzVmssRollingExtensionUpgrade -ResourceGroupName $rgname -VMScaleSetName $vmssname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

    }
    finally
    {

    }
}

<#
.SYNOPSIS
Test the VMSS spot restore policy
#>
function Test-VirtualMachineScaleSetSpotRestorePolicy
{

    # Setup
    $rgname = Get-ComputeTestResourceName
    try
    {
        # Common
        [string]$loc = "eastus";

        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $adminPassword = Get-PasswordForVM;

        $imgRef = Get-DefaultCRPImage -loc $loc;

        # Create VMSS with managed disk
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A2_v2' -UpgradePolicyMode 'Automatic' -EnableSpotRestore -SpotRestoreTimeout 'PT35M' -PlatformFaultDomainCount 1 -Priority 'Spot' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual True $vmss.SpotRestorePolicy.Enabled;
        Assert-AreEqual 'PT35M' $vmss.SpotRestorePolicy.RestoreTimeout;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test the VMSS Flexible orchestration mode defaulting.
#>
function Test-VirtualMachineScaleSetFlexibleOModeDefaulting
{

    # Setup
    $rgname = Get-ComputeTestResourceName;
    $networkAPIVersionFlexible = "2020-11-01";
    $flexiblePFDC = 1;
    $flexibleSinglePlacementGroup = $false;
    $stnd = "Standard";
    
    try
    {
        # Common
        $loc = "eastus";

        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Setup variables
        $vmssname = "vmss" + $rgname;
        $domainNameLabel = "dnl" + $rgname;
        $omode = "Flexible";
        $username = "admin01"
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force

        $credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

        # Create VMSS with minimal inputs to allow defaulting
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -Credential $credential -OrchestrationMode $omode -DomainNameLabel $domainNameLabel -SecurityType $stnd;
        Assert-NotNull $vmss;
        Assert-AreEqual $vmss.OrchestrationMode $omode;
        Assert-AreEqual $vmss.SinglePlacementGroup $flexibleSinglePlacementGroup;
        Assert-AreEqual $vmss.PlatformFaultDomainCount $flexiblePFDC;
        Assert-AreEqual $vmss.VirtualMachineProfile.NetworkProfile.NetworkAPIVersion $networkAPIVersionFlexible;

        Assert-ThrowsContains { $vmssError = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -Credential $credential -OrchestrationMode $omode -SinglePlacementGroup; } ` 
            "The value provided for SinglePlacementGroup cannot be used for a VMSS with OrchestrationMode set to Flexible. Please use SinglePlacementGroup 'false' instead.";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set OrchestrationMode NetworkAPIVersion null checks work
#>
function Test-VirtualMachineScaleSetOrchestrationModeNullChecks
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = "eastus";

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $VMSSName = "sap-flex";
        $omode = "Flexible";
        $stnd = "Standard";

        # Create Vmss
        $vmssConfig = New-AzVmssConfig -Location $loc -PlatformFaultDomainCount 3 -OrchestrationMode $omode -SecurityType $stnd;
        $vmss = New-AzVmss -ResourceGroupName $rgname -Name $VMSSName -VirtualMachineScaleSet $vmssConfig;
        Assert-AreEqual $omode $vmss.OrchestrationMode;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Add and remove Vmss Run Command.
#>
function Test-AddAndRemoveAzVmssRunCommand
{

    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = "eastus";

        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Setup variables
        $vmssname = "vmss" + $rgname;
        $domainNameLabel = "dnl" + $rgname;
        $username = "admin01"
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force

        $credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

        # Create VMSS with minimal inputs to allow defaulting
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname  -ImageName 'Win2016Datacenter' -Credential $credential -InstanceCount 1 -DomainNameLabel $domainNameLabel
        #$vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -Credential $credential -OrchestrationMode $omode -DomainNameLabel $domainNameLabel;

        $runcmds = Add-AzVmssRunCommand -ResourceGroupName $rgname -VMScaleSetName $vmssname -Location eastus -Name myruncommand -Script "Write-Host Hello World" -TimeOutInSeconds 3600 -RunAsUser "admin01"
        Assert-AreEqual $runcmds.RunAsUser "admin01";
        Assert-AreEqual $runcmds.TimeOutInSeconds "3600";
        Remove-AzVmssRunCommand -ResourceGroupName $rgname -VMScaleSetName $vmssname -Name myruncommand

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test the VMSS UserData feature, specifically the Base64 encoding functionality.
#>
function Test-VirtualMachineScaleSetUserdata
{

    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;
    try
    {

        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssName = 'vmss' + $rgname;
        $domainNameLabel = "dnl" + $rgname;
        $stnd = "Standard";

        $text = "new vmss";
        $bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
        $encodedText = [Convert]::ToBase64String($bytes);
        $userData = $encodedText;

        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $user = "admin01";
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        # Create Vmss with UserData.
        $vmss = New-AzVmss -ResourceGroupName $rgname -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -Userdata $userData -SecurityType $stnd;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -InstanceView:$false -Userdata;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.UserData $userData;

        # Update UserData property on Vmss.
        $text2 = "update vmss";
        $bytes2 = [System.Text.Encoding]::Unicode.GetBytes($text2);
        $encodedText2 = [Convert]::ToBase64String($bytes2);
        $userData2 = $encodedText2;

        $vmssUp = Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmssGet -Userdata $userData2;
        $vmssGet2 = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName -Userdata -InstanceView:$false;
        Assert-AreEqual $vmssGet2.VirtualMachineProfile.UserData $userData2;

        # Update VmssVm UserData property.
        $text3 = "vm update vmss vm";
        $bytes3 = [System.Text.Encoding]::Unicode.GetBytes($text3);
        $encodedText3 = [Convert]::ToBase64String($bytes3);
        $userData3 = $encodedText3;
        $vmssvm = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -UserData;
        Assert-AreNotEqual $vmssvm.UserData $userData3;
        $vmssvmUp = Update-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1 -UserData $userData3;

        $vmssvm2 = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 1 -UserData;
        Assert-AreEqual $vmssvm2.UserData $userData3;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set DiffDiskPlacement feature.
#>
function Test-VirtualMachineScaleSetDiffDiskPlacement
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        ## Cache Disk Test ##
        # Common
        $loc = Get-ComputeVMLocation;
        $vmssSize = 'Standard_DS3_v2';
        $stnd = "Standard";

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';
        $diffDiskPlacement = "CacheDisk";

        $adminUsername = 'Foo12';
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -DiffDiskSetting 'Local' -DiffDiskPlacement $diffDiskPlacement;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Validate DiffDiskPlacement value
        Assert-AreEqual $result.VirtualMachineProfile.StorageProfile.OsDisk.DiffDiskSettings.Placement $diffDiskPlacement;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set EnableHotPatching feature.
#>
function Test-VirtualMachineScaleSetEnableHotPatching
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        $loc = "eastus";
        $vmssName = "myVmssSlb";
        $vmNamePrefix = "vmSlb";
        $vmssInstanceCount = 5;
        $vmssSku = "Standard_DS1_v2";
        $stnd = "Standard";

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ("azureuser", $securePassword);

        $vnetname = "myVnet";
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "default-slb";
        $subnetAddress = "10.0.2.0/24";

        # set up networking
        # VMSS Flex requires explicit outbound access
        # Create a virtual network
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;
        $virtualNetwork = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

        # # Create a public IP address
        $publicIP = New-AzPublicIpAddress `
            -ResourceGroupName $rgname `
            -Location $loc `
            -AllocationMethod Static `
            -Sku "Standard" `
            -IpAddressVersion "IPv4" `
            -Name "myLBPublicIP";

        # # Create a frontend and backend IP pool
        $frontendIP = New-AzLoadBalancerFrontendIpConfig `
            -Name "myFrontEndPool" `
            -PublicIpAddress $publicIP;

        $backendPool = New-AzLoadBalancerBackendAddressPoolConfig `
            -Name "myBackEndPool" ;

        # # Create the load balancer
        $lb = New-AzLoadBalancer `
            -ResourceGroupName $rgname `
            -Name "myLoadBalancer" `
            -Sku "Standard" `
            -Tier "Regional" `
            -Location $loc `
            -FrontendIpConfiguration $frontendIP `
            -BackendAddressPool $backendPool ;

        # # Create a load balancer health probe for TCP port 80
        Add-AzLoadBalancerProbeConfig -Name "myHealthProbe" `
            -LoadBalancer $lb `
            -Protocol TCP `
            -Port 80 `
            -IntervalInSeconds 15 `
            -ProbeCount 2;

        # # Create a load balancer rule to distribute traffic on port TCP 80
        # # The health probe from the previous step is used to make sure that traffic is
        # # only directed to healthy VM instances
        Add-AzLoadBalancerRuleConfig `
            -Name "myLoadBalancerRule" `
            -LoadBalancer $lb `
            -FrontendIpConfiguration $lb.FrontendIpConfigurations[0] `
            -BackendAddressPool $lb.BackendAddressPools[0] `
            -Protocol TCP `
            -FrontendPort 80 `
            -BackendPort 80 `
            -DisableOutboundSNAT `
            -Probe (Get-AzLoadBalancerProbeConfig -Name "myHealthProbe" -LoadBalancer $lb);

        # # Add outbound connectivity rule
        Add-AzLoadBalancerOutboundRuleConfig `
            -Name "outboundrule" `
            -LoadBalancer $lb `
            -AllocatedOutboundPort '10000' `
            -Protocol 'All' `
            -IdleTimeoutInMinutes '15' `
            -FrontendIpConfiguration $lb.FrontendIpConfigurations[0] `
            -BackendAddressPool $lb.BackendAddressPools[0] ;

        # # Update the load balancer configuration
        Set-AzLoadBalancer -LoadBalancer $lb;

        # # Create IP address configurations
        # # Instances will require explicit outbound connectivity, for example
        # #   - NAT Gateway on the subnet (recommended)
        # #   - Instances in backend pool of Standard LB with outbound connectivity rules
        # #   - Public IP address on each instance
        # # See aka.ms/defaultoutboundaccess for more info
        $ipConfig = New-AzVmssIpConfig `
            -Name "myIPConfig" `
            -SubnetId $virtualNetwork.Subnets[0].Id `
            -LoadBalancerBackendAddressPoolsId $lb.BackendAddressPools[0].Id `
            -Primary;

        # Create a config object
        # The VMSS config object stores the core information for creating a scale set
        $vmssConfig = New-AzVmssConfig `
            -Location $loc `
            -SkuCapacity $vmssInstanceCount `
            -SkuName $vmssSku `
            -OrchestrationMode 'Flexible' `
            -PlatformFaultDomainCount 1 `
            -SecurityType $stnd;

        # Reference a virtual machine image from the gallery
        Set-AzVmssStorageProfile $vmssConfig `
            -OsDiskCreateOption "FromImage" `
            -ImageReferencePublisher "MicrosoftWindowsServer" `
            -ImageReferenceOffer "WindowsServer" `
            -ImageReferenceSku "2022-datacenter-azure-edition-core-smalldisk" `
            -ImageReferenceVersion "latest";

        # Set up information for authenticating with the virtual machine
        Set-AzVmssOsProfile $vmssConfig `
            -AdminUsername $cred.UserName `
            -AdminPassword $cred.Password `
            -ComputerNamePrefix $vmNamePrefix `
            -WindowsConfigurationProvisionVMAgent $true `
            -WindowsConfigurationPatchMode "AutomaticByPlatform" `
            -EnableHotpatching;

        # Attach the virtual network to the config object
        Add-AzVmssNetworkInterfaceConfiguration `
            -VirtualMachineScaleSet $vmssConfig `
            -Name "network-config" `
            -Primary $true `
            -IPConfiguration $ipConfig `
            -NetworkApiVersion '2020-11-01' ;

        # Health extension attempt
        # Define the Application Health extension properties
        $publicConfig = @{"protocol" = "http"; "port" = 80; "requestPath" = "/healthEndpoint"};
        $extensionName = "myHealthExtension";
        $extensionType = "ApplicationHealthWindows";
        $publisher = "Microsoft.ManagedServices";
        # Add the Application Health extension to the scale set model
        Add-AzVmssExtension -VirtualMachineScaleSet $vmssConfig `
            -Name $extensionName `
            -Publisher $publisher `
            -Setting $publicConfig `
            -Type $extensionType `
            -TypeHandlerVersion "1.0" `
            -AutoUpgradeMinorVersion $True;

        # Test updating the value. Updating after the Vmss is created is not supported.
        Set-AzVmssOsProfile $vmssConfig -EnableHotPatching:$false;
        Assert-AreEqual $false $vmssConfig.VirtualMachineProfile.OsProfile.WindowsConfiguration.PatchSettings.EnableHotPatching;
        Set-AzVmssOsProfile $vmssConfig -EnableHotPatching:$true;
        Assert-AreEqual $true $vmssConfig.VirtualMachineProfile.OsProfile.WindowsConfiguration.PatchSettings.EnableHotPatching;

        # Create the scale set with the config object (this step might take a few minutes)
        New-AzVmss `
            -ResourceGroupName $rgname `
            -Name $vmssName `
            -VirtualMachineScaleSet $vmssConfig;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $true $vmss.VirtualMachineProfile.OsProfile.WindowsConfiguration.PatchSettings.EnableHotPatching;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Force Deletion of VMSS.
#>
function Test-RemoveVmssForceDeletion
{

    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = "eastus";

        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Setup variables
        $vmssname = "vmss" + $rgname;
        $domainNameLabel = "dnl" + $rgname;
        $username = "admin01"
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force

        $credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

        # Create VMSS with minimal inputs to allow defaulting
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname  -ImageName 'Win2016Datacenter' -Credential $credential -InstanceCount 1 -DomainNameLabel $domainNameLabel
        #$vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -Credential $credential -OrchestrationMode $omode -DomainNameLabel $domainNameLabel;

        Remove-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -ForceDeletion $true -Force

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set test AutomaticRepairsAction feature.
#>
function Test-VirtualMachineScaleSetRepairsAction
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = "eastus";

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $stnd = "Standard";

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
        $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Static -DomainNameLabel ('pubip' + $rgname);
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
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $vmssSize = 'Standard_B1s';
        $repairAction1 = "Replace";
        $repairAction2 = "Restart";

        $imgRef = Create-ComputeVMImageObject -loc "eastus" -publisherName "MicrosoftWindowsServerHPCPack" -offer "WindowsServerHPCPack" -skus "2012R2" -version "4.5.5198";
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $ipCfg = New-AzVmssIPConfig -Name 'test' `
            -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id `
            -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id `
            -SubnetId $subnetId;

        # New-AzVmssConfig and New-AzVmss test
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -HealthProbeId $expectedLb.Probes[0].Id -SecurityType $stnd `
            -EnableAutomaticRepair -AutomaticRepairGracePeriod "PT30M" -AutomaticRepairAction $repairAction1 `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion 'latest' `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer;

        $vmss = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmssNew = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $repairAction1 $vmssNew.AutomaticRepairsPolicy.RepairAction;

        # Update Vmss test
        Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmss -EnableAutomaticRepair $false -AutomaticRepairAction $repairAction2;

        $vmssUp = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $repairAction2 $vmssUp.AutomaticRepairsPolicy.RepairAction;
        Assert-AreEqual $false $vmssUp.AutomaticRepairsPolicy.Enabled;

        # Update back to True
        Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmss -EnableAutomaticRepair $true -AutomaticRepairAction $repairAction1;

        $vmssUp = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-AreEqual $repairAction1 $vmssUp.AutomaticRepairsPolicy.RepairAction;
        Assert-AreEqual $true $vmssUp.AutomaticRepairsPolicy.Enabled;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Guest Attestation and Identity SystemAssigned
for the certain Trusted Launch feature setup.
This test has been moved to LiveOnly as this logic has been removed as per request of the feature team.
This test will remain here as the logic may be asked to be reimplemented in the future.
#>
function Test-VirtualMachineScaleSetGuestAttestation
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_DS3_v2';
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2019-DATACENTER-GENSECOND";
        $securityType = "TrustedLaunch";
        $secureboot = $true;
        $vtpm = $true;
        $extDefaultName = "GuestAttestation";
        $vmGADefaultIDentity = "SystemAssigned";

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'usertest';
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
        $imgRef.PublisherName = $PublisherName;
        $imgRef.Offer = $Offer;
        $imgRef.Skus = $SKU;
        $imgRef.Version = "latest";


        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName ;

        # Requirements for the Guest Attestation defaulting behavior.
        $vmss = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $securityType;
        $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        # Create Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Validate
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $vmGADefaultIDentity $vmssGet.Identity.Type;

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $extDefaultName $vmssvm.Resources[2].Name;

        # Simple param Set
        $username = Get-ComputeTestResourceName;
        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

        $vmssname2 = "vmss2" + $rgname;
        $domainNameLabel2 = "dnl" + $rgname;
        $vmss2 = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname2  -ImageName 'Win2019DatacenterGen2' `
          -Credential $credential -InstanceCount 1 -DomainNameLabel $domainNameLabel2 -SecurityType "TrustedLaunch" `
          -EnableSecureBoot $true -EnableVtpm $true;

        $vmssGet2 = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName2;
        $output2 = $vmssGet2 | Out-String;
        Assert-True { $output2.Contains($vmGADefaultIDentity) };

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName2;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName2 -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $extDefaultName $vmssvm.Resources[2].Name;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
A helper function to validate the PriorityMix split between Spot and Regular priority VMs in a VMSS with Flexible OrchestrationMode
#>
function ValidatePriorityMixSplit($vmssVMList, $expectedRegularPriorityCount, $expectedSpotPriorityCount)
{
    $regularCountActual = 0;
    $spotCountActual = 0;

    # we need to do an individual call on each vm since the Get-AzVmssVM cmdlet returns a limited list of VM properties
    Foreach($vm in $vmssVMList)
    {
        $vmName = $vm.Name;
        $vmResponse = Get-AzVM -ResourceGroupName $rgname -Name $vmName;

        Assert-NotNull $vmResponse;

        $vmPriority = $vmResponse.Priority;

        if($vmPriority -eq "Regular"){ $regularCountActual += 1 }
        elseif($vmPriority -eq "Spot"){ $spotCountActual += 1 }
    }

    Assert-AreEqual $expectedRegularPriorityCount $regularCountActual;
    Assert-AreEqual $expectedSpotPriorityCount $spotCountActual;
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set PriorityMixPolicy for VMSS with Flexible OrchestrationMode
#>
function Test-VirtualMachineScaleSetPriorityMixPolicy
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        $loc = "eastus";
        $vmssName = "PriMixPol";
        $vmNamePrefix = "VMPriMix";
        $vmssInstanceCount = 2;
        $vmssSku = "Standard_DS1_v2";
        $stnd = "Standard";

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $securePassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ("azureuser", $securePassword);

        $vnetname = "myVnet";
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "default-slb";
        $subnetAddress = "10.0.2.0/24";

        # set up networking
        # VMSS Flex requires explicit outbound access
        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;
        $virtualNetwork = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

        # # Create a public IP address
        $publicIP = New-AzPublicIpAddress `
            -ResourceGroupName $rgname `
            -Location $loc `
            -AllocationMethod Static `
            -Sku "Standard" `
            -IpAddressVersion "IPv4" `
            -Name "myLBPublicIP";

        # Create a frontend and backend IP pool
        $frontendIP = New-AzLoadBalancerFrontendIpConfig `
            -Name "myFrontEndPool" `
            -PublicIpAddress $publicIP;

        $backendPool = New-AzLoadBalancerBackendAddressPoolConfig `
            -Name "myBackEndPool" ;

        # Create the load balancer
        $lb = New-AzLoadBalancer `
            -ResourceGroupName $rgname `
            -Name "myLoadBalancer" `
            -Sku "Standard" `
            -Tier "Regional" `
            -Location $loc `
            -FrontendIpConfiguration $frontendIP `
            -BackendAddressPool $backendPool ;

        # # Create a load balancer health probe for TCP port 80
        Add-AzLoadBalancerProbeConfig -Name "myHealthProbe" `
            -LoadBalancer $lb `
            -Protocol TCP `
            -Port 80 `
            -IntervalInSeconds 15 `
            -ProbeCount 2;

        # # Create a load balancer rule to distribute traffic on port TCP 80
        # # The health probe from the previous step is used to make sure that traffic is
        # # only directed to healthy VM instances
        Add-AzLoadBalancerRuleConfig `
            -Name "myLoadBalancerRule" `
            -LoadBalancer $lb `
            -FrontendIpConfiguration $lb.FrontendIpConfigurations[0] `
            -BackendAddressPool $lb.BackendAddressPools[0] `
            -Protocol TCP `
            -FrontendPort 80 `
            -BackendPort 80 `
            -DisableOutboundSNAT `
            -Probe (Get-AzLoadBalancerProbeConfig -Name "myHealthProbe" -LoadBalancer $lb);

        # Add outbound connectivity rule
        Add-AzLoadBalancerOutboundRuleConfig `
            -Name "outboundrule" `
            -LoadBalancer $lb `
            -AllocatedOutboundPort '9000' `
            -Protocol 'All' `
            -IdleTimeoutInMinutes '15' `
            -FrontendIpConfiguration $lb.FrontendIpConfigurations[0] `
            -BackendAddressPool $lb.BackendAddressPools[0] ;

        # Update the load balancer configuration
        Set-AzLoadBalancer -LoadBalancer $lb;

        # Create IP address configurations
        # Instances will require explicit outbound connectivity, for example
        # - NAT Gateway on the subnet (recommended)
        # - Instances in backend pool of Standard LB with outbound connectivity rules
        # - Public IP address on each instance
        # See aka.ms/defaultoutboundaccess for more info
        $ipConfig = New-AzVmssIpConfig `
            -Name "myIPConfig" `
            -SubnetId $virtualNetwork.Subnets[0].Id `
            -LoadBalancerBackendAddressPoolsId $lb.BackendAddressPools[0].Id `
            -Primary;

        $baseRegularPriorityVMCount = 0;
        $regularPriorityVMPercentage = 50;

        # Create a config object
        # The VMSS config object stores the core information for creating a scale set
        $vmssConfig = New-AzVmssConfig `
            -Location $loc `
            -SkuCapacity $vmssInstanceCount `
            -SkuName $vmssSku `
            -OrchestrationMode 'Flexible' `
            -EvictionPolicy 'Delete' `
            -PlatformFaultDomainCount 1 `
            -Priority 'Spot' `
            -BaseRegularPriorityCount $baseRegularPriorityVMCount `
            -RegularPriorityPercentage $regularPriorityVMPercentage `
            -SecurityType $stnd;

        # Reference a virtual machine image from the gallery
        Set-AzVmssStorageProfile $vmssConfig `
            -OsDiskCreateOption "FromImage" `
            -ImageReferencePublisher "MicrosoftWindowsServer" `
            -ImageReferenceOffer "WindowsServer" `
            -ImageReferenceSku "2022-datacenter-azure-edition-core-smalldisk" `
            -ImageReferenceVersion "latest";

        # Set up information for authenticating with the virtual machine
        Set-AzVmssOsProfile $vmssConfig `
            -AdminUsername $cred.UserName `
            -AdminPassword $cred.Password `
            -ComputerNamePrefix $vmNamePrefix `
            -WindowsConfigurationProvisionVMAgent $true `
            -WindowsConfigurationPatchMode "AutomaticByPlatform" `
            -EnableHotpatching;

        # Attach the virtual network to the config object
        Add-AzVmssNetworkInterfaceConfiguration `
            -VirtualMachineScaleSet $vmssConfig `
            -Name "network-config" `
            -Primary $true `
            -IPConfiguration $ipConfig `
            -NetworkApiVersion '2020-11-01' ;

        # Define the Application Health extension properties
        $publicConfig = @{"protocol" = "http"; "port" = 80; "requestPath" = "/healthEndpoint"};
        $extensionName = "myHealthExtension";
        $extensionType = "ApplicationHealthWindows";
        $publisher = "Microsoft.ManagedServices";

        # Add the Application Health extension to the scale set model
        Add-AzVmssExtension -VirtualMachineScaleSet $vmssConfig `
            -Name $extensionName `
            -Publisher $publisher `
            -Setting $publicConfig `
            -Type $extensionType `
            -TypeHandlerVersion "1.0" `
            -AutoUpgradeMinorVersion $True;

        # Create the scale set with the config object
        New-AzVmss `
            -ResourceGroupName $rgname `
            -Name $vmssName `
            -VirtualMachineScaleSet $vmssConfig;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;

        Assert-AreEqual $baseRegularPriorityVMCount $vmss.PriorityMixPolicy.BaseRegularPriorityCount;
        Assert-AreEqual $regularPriorityVMPercentage $vmss.PriorityMixPolicy.RegularPriorityPercentageAboveBase;

        # validate priority mix split after create
        $vmssVMsAfterCreate = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName
        $expectedRegularCount = 1;
        $expectedSpotCount = 1;

        ValidatePriorityMixSplit $vmssVMsAfterCreate $expectedRegularCount $expectedSpotCount;

        # perform a scale out with updated priority mix policy
        $scaleOutCapacity = $vmssInstanceCount + 4;
        $updatedRegularPriorityCount = 2;
        $updatedRegularPriorityPercentage = 33;

        $vmss.sku.Capacity = $scaleOutCapacity;
        $vmss.PriorityMixPolicy.BaseRegularPriorityCount = $updatedRegularPriorityCount;
        $vmss.PriorityMixPolicy.RegularPriorityPercentageAboveBase = $updatedRegularPriorityPercentage;

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;

        # validate the vmss with updated priority mix parameters
        Assert-AreEqual $updatedRegularPriorityCount $vmss.PriorityMixPolicy.BaseRegularPriorityCount;
        Assert-AreEqual $updatedRegularPriorityPercentage $vmss.PriorityMixPolicy.RegularPriorityPercentageAboveBase;

        $vmssVMsAfterScaleOut = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $expectedRegularCount = 3;
        $expectedSpotCount = 3;

        ValidatePriorityMixSplit $vmssVMsAfterScaleOut $expectedRegularCount $expectedSpotCount;

        # perform a scale in while keeping priority mix policy the same
        $scaleInCapacity = $scaleOutCapacity - 4
        $vmss.sku.capacity = $scaleInCapacity;

        Update-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;

        # validate the VMSS after scale in
        $vmssVMsAfterScaleIn = Get-AzVmssVM -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $expectedRegularCount = 2;
        $expectedSpotCount = 0;

        ValidatePriorityMixSplit $vmssVMsAfterScaleIn $expectedRegularCount $expectedSpotCount;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Confidential vmss testing securityType set to ConfidentialVM and securityEncryptionType VMGuestStateOnly.
Testing Set-AzVmssSecurityType.
#>
function Test-VirtualMachineScaleSetConfidentialVMSSSecurityType
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "northeurope";

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = "Standard_DC2as_v5";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = '2022-datacenter-smalldisk-g2';
        $version = "latest";
        $securityType = "ConfidentialVM";
        $securityEncryptionType = "VMGuestStateOnly";
        $secureboot = $true;
        $vtpm = $true;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
        $imgRef.PublisherName = $PublisherName;
        $imgRef.Offer = $Offer;
        $imgRef.Skus = $SKU;
        $imgRef.Version = $version;


        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' -SecurityEncryptionType $securityEncryptionType `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName;

        # Confidential Vmss required parameters
        $vmss = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $securityType;
        $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        # Create Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Validate
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $securityType $vmssGet.VirtualMAchineProfile.SecurityProfile.SecurityType;

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $securityEncryptionType $vmssvm.StorageProfile.OsDIsk.ManagedDisk.SecurityProfile.SecurityEncryptionType;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Confidential vmss testing securityType set to ConfidentialVM and securityEncryptionType DiskWithVMGuestState
and Confidential VM reference image OS Disk security set to EncryptedWithPmk.
#>
function Test-VirtualMachineScaleSetConfidentialVMDiskWithVMGuestStatePMK
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "northeurope";

    try
    {
        # Common variables
        $secureBoot = $true;
        $vtpm = $true;
        $vmssName = "vmss" + $rgname;

        # VM variables
        $vmName = "vmnam";
        $vmSize = "Standard_DC2as_v5";
        $vmssSize = "Standard_DC2as_v5";

        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $username = Get-ComputeTestResourceName;
        $vmCred = New-Object System.Management.Automation.PSCredential ($username, $securePassword);


        $imagePublisher = "MicrosoftWindowsServer";
        $imageOffer = "windowsserver";
        $imageSku = "2022-datacenter-smalldisk-g2";
        $imageVersion = "latest";
        $osDiskSecurityType = "DiskwithVMGuestState";
        $vmSecurityType = "ConfidentialVM";

        # Network variables
        $NetworkName = [system.string]::concat($vmName, '-vnet');
        $NICName = [system.string]::concat($vmName, '-nic');
        $SubnetName = [system.string]::concat($vmName, '-subnet');
        $SubnetAddressPrefix = "10.0.0.0/24";
        $VnetAddressPrefix = "10.0.0.0/16";

        # Setup resource group
        New-AzResourceGroup -ResourceGroupName $rgName -Location $loc -Force;

        # Setup Network
        $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
        $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $rgName `
            -Location $loc -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet;
        $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgName `
            -Location $loc -SubnetId $Vnet.Subnets[0].Id;

        # Setup CVM
        $virtualMachine = New-AzVMConfig -VMName $vmName -VMSize $vmSize;
        $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $vmName `
                    -Credential $vmCred -ProvisionVMAgent -EnableAutoUpdate;
        $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id;
        $VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName $imagePublisher `
                    -Offer $imageOffer -Skus $imageSku -Version $imageVersion;
        $VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -StorageAccountType "StandardSSD_LRS" `
                    -CreateOption "FromImage" -SecurityEncryptionType $osDiskSecurityType;
        $VirtualMachine = Set-AzVmSecurityProfile -VM $VirtualMachine -SecurityType $vmSecurityType;
        $VirtualMachine = Set-AzVmUefi -VM $VirtualMachine -EnableVtpm $true -EnableSecureBoot $true;

        New-AzVM -ResourceGroupName $rgName -Location $loc -VM $VirtualMachine;

        $cvm = Get-AzVM -VMName $vmName -ResourceGroupName $rgName;

        # Image Gallery variables
        $galleryName = "rg" + $rgname;
        $definitionName = "def"+$rgname;
        $publisherName = "cvm01";
        $versionName = "1.0.0";
        $cvmEncryptionType = "EncryptedWithPmk";
        $replicaCount = 1;
        $storageAccountType = "Standard_LRS";
        $osState = "Specialized";
        $osType = "Windows";
        $sourceImageId = $cvm.Id;

        # Setup Image Gallery
        New-AzGallery -ResourceGroupName $rgName -Name $galleryName -location $loc;

        $imagePublisher = "MicrosoftWindowsServer";
        $imageOffer = "windowsserver";
        $imageSku = "2022-datacenter-smalldisk-g2";
        $vmSecurityType = "ConfidentialVM";

        # Setup Image Definition
        $SecurityTypeTable = @{Name='SecurityType';Value='ConfidentialVM'};
        $features = @($SecurityTypeTable);
        New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $definitionName `
            -Feature $features -Publisher $imagePublisher -Offer $imageOffer -Sku $imageSku -location $loc `
            -OsState $osState -OsType $osType -HyperVGeneration 'V2';

        $galDefinition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $definitionName;

        # Setup Image Version
        $cvmOsDiskEncryption = @{CVMEncryptionType=$cvmEncryptionType};
        $cvmEncryption = @{OSDiskImage = $cvmOsDiskEncryption};
        $region = @{Name = $loc; ReplicaCount = $replicaCount; StorageAccountType = $storageAccountType; Encryption = $cvmEncryption};
        $targetRegions = @($region);
        Start-TestSleep -Seconds 360;
        New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $definitionName `
            -Name $versionName -Location $loc -SourceImageId $sourceImageId -ReplicaCount $replicaCount `
            -StorageAccountType $storageAccountType -TargetRegion $targetRegions;

        $galVersion = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $definitionName;

        $securityEncryptionType = "DiskWithVMGuestState";


        # NRP vmss
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix $SubnetAddressPrefix;
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix $VnetAddressPrefix -Subnet $subnet;
        $subnetId = $vnet.Subnets[0].Id;

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        # Vmss setup
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -ImageReferenceId $galDefinition.Id`
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' -SecurityEncryptionType $securityEncryptionType;

        # Confidential Vmss required parameters
        $vmss = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $vmSecurityType;
        $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        # Create Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Validate
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $vmSecurityType $vmssGet.VirtualMAchineProfile.SecurityProfile.SecurityType;

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $securityEncryptionType $vmssvm.StorageProfile.OsDIsk.ManagedDisk.SecurityProfile.SecurityEncryptionType;

        Assert-AreEqual $cvmEncryptionType $galVersion.PublishingProfile.TargetRegions.Encryption.OSDiskImage.SecurityProfile.ConfidentialVMEncryptionType;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Confidential vmss testing securityType set to ConfidentialVM and securityEncryptionType VMGuestStateOnly
and Confidential VM image reference OS Disk security set to VMGuestStateOnly.
#>
function Test-VirtualMachineScaleSetConfidentialVMVMGuestStateOnlyPMK
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "NorthEurope";

    try
    {
        # Common variables
        $secureBoot = $true;
        $vtpm = $true;
        $vmssName = "vmss" + $rgname;

        # VM variables
        $vmName = "v" + $rgname;
        $vmSize = "Standard_DC2as_v5";
        $vmssSize = "Standard_DC2as_v5";

        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $username = Get-ComputeTestResourceName;
        $vmCred = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

        $imagePublisher = "MicrosoftWindowsServer";
        $imageOffer = "windowsserver";
        $imageSku = "2022-datacenter-smalldisk-g2";
        $osDiskSecurityEncryptionType = "VMGuestStateOnly";
        $osDiskSecurityType = $osDiskSecurityEncryptionType;
        $vmSecurityType = "ConfidentialVM";
        $storageType = "StandardSSD_LRS";


        # Network variables
        $NetworkName = [system.string]::concat($vmName, '-vnet');
        $NICName = [system.string]::concat($vmName, '-nic');
        $SubnetName = [system.string]::concat($vmName, '-subnet');
        $SubnetAddressPrefix = "10.0.0.0/24";
        $VnetAddressPrefix = "10.0.0.0/16";

        # Setup resource group
        New-AzResourceGroup -ResourceGroupName $rgName -Location $loc -Force -ErrorAction 'Stop' | Out-Null;

        # Setup Network
        $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
        $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $rgName `
            -Location $loc -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
        $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgName `
            -Location $loc -SubnetId $Vnet.Subnets[0].Id;

        # Setup CVM
        $virtualMachine = New-AzVMConfig -VMName $vmName -VMSize $vmSize
        $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $vmName `
                    -Credential $vmCred -ProvisionVMAgent -EnableAutoUpdate
        $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
        $VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName $imagePublisher `
                    -Offer $imageOffer -Skus $imageSku -Version "latest"
        $paramSetAzVmOsDisk = @{
            VM = $virtualMachine
            StorageAccountType = $storageType
            CreateOption = "FromImage"
            SecurityEncryptionType = $osDiskSecurityType
            ErrorAction = 'Stop'
        };
        $VirtualMachine = Set-AzVMOSDisk @paramSetAzVmOsDisk;
        $VirtualMachine = Set-AzVmSecurityProfile -VM $VirtualMachine -SecurityType $vmSecurityType;
        $VirtualMachine = Set-AzVmUefi -VM $VirtualMachine -EnableVtpm $true -EnableSecureBoot $true;

        # Create CVM to be used as an Image reference
        New-AzVM -ResourceGroupName $rgName -Location $loc -VM $VirtualMachine | Out-Null;

        $cvm = Get-AzVM -VMName $vmName -ResourceGroupName $rgName -ErrorAction 'Stop';

        # Image Gallery variables
        $galleryName = "rg" + $rgname;
        $definitionName = "def"+$rgname;
        $publisherName = "cvm01";
        $versionName = "1.0.0";
        $cvmEncryptionType = "EncryptedVMGuestStateOnlyWithPmk";
        $replicaCount = 1;
        $storageAccountType = "Standard_LRS";
        $osState = "Specialized";
        $osType = "Windows";
        $sourceImageId = $cvm.Id;

        # Setup Image Gallery
        New-AzGallery -ResourceGroupName $rgName -Name $galleryName -location $loc -ErrorAction 'Stop' | Out-Null;

        $imagePublisher = "MicrosoftWindowsServer";
        $imageOffer = "windowsserver";
        $imageSku = "2022-datacenter-smalldisk-g2";
        $osDiskSecurityType = "VMGuestStateOnly";
        $vmSecurityType = "ConfidentialVM";

        # Setup Image Definition
        $SecurityTypeTable = @{Name='SecurityType';Value='ConfidentialVM'};
        $features = @($SecurityTypeTable);
        New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $definitionName `
            -Feature $features -Publisher $imagePublisher -Offer $imageOffer -Sku $imageSku -location $loc `
            -OsState $osState -OsType $osType -HyperVGeneration 'V2' | Out-Null;

        $galDefinition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $definitionName;

        # Setup Image Version
        $cvmOsDiskEncryption = @{CVMEncryptionType=$cvmEncryptionType};
        $cvmEncryption = @{OSDiskImage = $cvmOsDiskEncryption};
        $region = @{Name = $loc; ReplicaCount = $replicaCount; StorageAccountType = $storageAccountType; Encryption = $cvmEncryption};
        $targetRegions = @($region);
        New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $definitionName `
            -Name $versionName -Location $loc -SourceImageId $sourceImageId -ReplicaCount $replicaCount `
            -StorageAccountType $storageAccountType -TargetRegion $targetRegions | Out-Null;

        $galVersion = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $definitionName;

        $securityEncryptionType = "VMGuestStateOnly";

        # NRP Vmss Setup
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        # Vmss Setup
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -ImageReferenceId $galDefinition.Id`
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' -SecurityEncryptionType $securityEncryptionType;

        # Confidential Vmss required parameters
        $vmss = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $vmSecurityType;
        $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        # Create Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;


        # Validate
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $vmSecurityType $vmssGet.VirtualMAchineProfile.SecurityProfile.SecurityType;

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $securityEncryptionType $vmssvm.StorageProfile.OsDIsk.ManagedDisk.SecurityProfile.SecurityEncryptionType;

        Assert-AreEqual $cvmEncryptionType $galVersion.PublishingProfile.TargetRegions.Encryption.OSDiskImage.SecurityProfile.ConfidentialVMEncryptionType;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Confidential vmss testing securityType set to ConfidentialVM and securityEncryptionType DiskWithVMGuestState
and Confidential VM image reference OS Disk security type set to EncryptedWithCmk.
#>
function Test-VirtualMachineScaleSetConfidentialVMDiskWithVMGuestStateCMK
{
    # Setup
    $rgname = "adsandcfvmss4";#Get-ComputeTestResourceName;
    $loc = "northeurope";

    try
    {
        # CMK Key Vault Setup (Manual)
        # This needs to be manually run for the test to be recorded.
        <#
        $rgname = "adsandcfvmss4";
        $loc = "northeurope";

        # Setup resource group
        New-AzResourceGroup -ResourceGroupName $rgName -Location $loc -Force;

        $keyVaultName = "kv" + $rgname;
        $keyName = "k" + $rgname;
        $desName = "des" + $rgname;
        $cvmAgent = Get-AzADServicePrincipal -ApplicationId "bf7b6499-ff71-4aa2-97a4-f372087be7f0";
        $kv = New-AzKeyVault -Name $keyVaultName -ResourceGroupName $rgName -Location $loc -Sku "Premium" -EnablePurgeProtection -SoftDeleteRetentionInDays 7;
        Set-AzKeyVaultAccessPolicy -ObjectId $cvmAgent.Id -VaultName $keyVaultName -ResourceGroupName $rgName -PermissionsToKeys "get","release";
        Start-BitsTransfer -Source https://cvmprivatepreviewsa.blob.core.windows.net/cvmpublicpreviewcontainer/skr-policy.json -Destination ".\skr-policy.json";
        $desKey = Add-AzKeyVaultKey -Name $keyName -VaultName $keyVaultName -KeyOps "wrapKey","unwrapKey" -KeyType "RSA-HSM" -Size 3072 `
                        -Exportable -ReleasePolicyPath ".\skr-policy.json" -Destination "HSM";

        $desConfig = New-AzDiskEncryptionSetConfig -Location $loc -KeyUrl $desKey.Id -SourceVaultId $kv.ResourceId -IdentityType "SystemAssigned" `
            -EncryptionType "ConfidentialVmEncryptedWithCustomerKey";
        $des = New-AzDiskEncryptionSet -DiskEncryptionSet $desConfig -DiskEncryptionSetName $desName -ResourceGroupName $rgName;
        $desIdentity = Get-AzADServicePrincipal -ObjectId $des.Identity.PrincipalId -ErrorAction 'SilentlyContinue';
        Set-AzKeyVaultAccessPolicy -ObjectId $des.Identity.PrincipalId -ResourceGroupName $rgName -VaultName $keyVaultName -PermissionsToKeys "wrapKey","unwrapKey","get";
        #>
        # End CMK Key Vault Setup (Manual).

        # Common variables
        $secureBoot = $true;
        $vtpm = $true;
        $vmssName = "vmss" + $rgname;

        # VM variables
        $vmName = "v" + $rgname;
        $vmSize = "Standard_DC2as_v5";
        $vmssSize = "Standard_DC2as_v5";
        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $username = Get-ComputeTestResourceName;
        $vmCred = New-Object System.Management.Automation.PSCredential ($username, $securePassword);
        $imagePublisher = "MicrosoftWindowsServer";
        $imageOffer = "windowsserver";
        $imageSku = "2022-datacenter-smalldisk-g2";
        $imageVersion = "latest";
        $osDiskSecurityType = "DiskwithVMGuestState";
        $vmSecurityType = "ConfidentialVM";
        $deployCMK = $true;
        $storageType = "StandardSSD_LRS";

        # Network variables
        $NetworkName = $vmname + "-vnet";
        $NICName = $vmName + "-nic";
        $SubnetName = $vmName + "-subnet";
        $SubnetAddressPrefix = "10.0.0.0/24";
        $VnetAddressPrefix = "10.0.0.0/16";

        # CMK Key Vault Setup
        $keyName = "k" + $rgName;
        $desName = "des" + $rgname;
        # The Disk Encryption Set was created in the manual steps and is queried for here.
        $des = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $desName;

        # Setup Network
        $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
        $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $rgName `
            -Location $loc -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
        $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgName `
            -Location $loc -SubnetId $Vnet.Subnets[0].Id;

        # Setup CVM
        $virtualMachine = New-AzVMConfig -VMName $vmName -VMSize $vmSize;
        $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $vmName `
                    -Credential $vmCred -ProvisionVMAgent -EnableAutoUpdate;
        $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id;
        $VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName $imagePublisher `
                    -Offer $imageOffer -Skus $imageSku -Version $imageVersion;

        $paramSetAzVmOsDisk = @{
        VM = $virtualMachine
        StorageAccountType = $storageType
        CreateOption = "FromImage"
        SecurityEncryptionType = $osDiskSecurityType
        ErrorAction = 'Stop'
        SecureVMDiskEncryptionSet = $des.Id
        };
        $VirtualMachine = Set-AzVMOSDisk @paramSetAzVmOsDisk;


        $VirtualMachine = Set-AzVmSecurityProfile -VM $VirtualMachine -SecurityType $vmSecurityType;
        $VirtualMachine = Set-AzVmUefi -VM $VirtualMachine -EnableVtpm $true -EnableSecureBoot $true;

        # Create CVM to be used as Image reference
        New-AzVM -ResourceGroupName $rgName -Location $loc -VM $VirtualMachine;

        $cvm = Get-AzVM -VMName $vmName -ResourceGroupName $rgName;

        # Image Gallery variables
        $galleryName = "rg" + $rgname;
        $definitionName = "def"+$rgname;
        $publisherName = "cvm01";
        $versionName = "1.0.0";
        $cvmEncryptionType = "EncryptedWithCmk";
        $replicaCount = 1;
        $storageAccountType = "Standard_LRS";
        $osState = "Specialized";
        $osType = "Windows";
        $sourceImageId = $cvm.Id;

        # Setup Image Gallery
        New-AzGallery -ResourceGroupName $rgName -Name $galleryName -location $loc;

        # Setup Image Definition
        $SecurityTypeTable = @{Name='SecurityType';Value='ConfidentialVM'};
        $features = @($SecurityTypeTable);
        New-AzGalleryImageDefinition -ResourceGroupName $rgName -GalleryName $galleryName -Name $definitionName `
            -Feature $features -Publisher $imagePublisher -Offer $imageOffer -Sku $imageSku -location $loc `
            -OsState $osState -OsType $osType -HyperVGeneration 'V2';

        $galDefinition = Get-AzGalleryImageDefinition -ResourceGroupName $rgname -GalleryName $galleryName -Name $definitionName;

        # Setup Image Version
        $cvmOsDiskEncryption = @{CVMEncryptionType=$cvmEncryptionType; };
        $cvmOsDiskEncryption.Add('CVMDiskEncryptionSetID', $des.Id);
        $cvmEncryption = @{OSDiskImage = $cvmOsDiskEncryption};
        $region = @{Name = $loc; ReplicaCount = $replicaCount; StorageAccountType = $storageAccountType; Encryption = $cvmEncryption};
        $targetRegions = @($region);
        Start-TestSleep -Seconds 360;
        New-AzGalleryImageVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryImageDefinitionName $definitionName `
            -Name $versionName -Location $loc -SourceImageId $sourceImageId -ReplicaCount $replicaCount `
            -StorageAccountType $storageAccountType -TargetRegion $targetRegions;

        $galVersion = Get-AzGalleryImageVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryImageDefinitionName $definitionName;

        $securityEncryptionType = "DiskWithVMGuestState";

        # NRP vmss
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet2' + $rgname) -AddressPrefix $SubnetAddressPrefix;
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet2' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix $VnetAddressPrefix -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ('vnet2' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        $ipCfg = New-AzVmssIPConfig -Name 'test2' -SubnetId $subnetId;

        # Vmss setup
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -ImageReferenceId $galDefinition.Id`
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test2' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' -SecurityEncryptionType $securityEncryptionType -SecureVMDiskEncryptionSet $des.Id;

        # Confidential Vmss required parameters
        $vmss = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $vmSecurityType;
        $vmss = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $vtpm -EnableSecureBoot $secureboot;

        # Create Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Validate
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName;
        Assert-AreEqual $vmSecurityType $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType;

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $securityEncryptionType $vmssvm.StorageProfile.OsDIsk.ManagedDisk.SecurityProfile.SecurityEncryptionType;

        Assert-AreEqual $galVersion.PublishingProfile.TargetRegions.Encryption.OSDiskImage.SecurityProfile.ConfidentialVMEncryptionType $cvmEncryptionType;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Vmss Os Image Scheduled Events tests
#>
function Test-VirtualMachineScaleSetOSImageScheduledEvents
{

    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Setup variables
        $publisher = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $imgSku = "2019-Datacenter";
        $version = "latest";
        $vmssName = 'vmss' + $rgname;
        $vmssSku = "Standard_D2s_v3";
        $vmssname = "vmss" + $rgname;
        $domainNameLabel = "d" + $rgname;
        $stnd = "Standard";
        $username = "admin01";
        $password = Get-PasswordForVM;
        $securePassword = $password | ConvertTo-SecureString -AsPlainText -Force

        $credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

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

        # Create VMSS with managed disk
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSku -OSImageScheduledEventEnabled -OSImageScheduledEventNotBeforeTimeoutInMinutes "PT15M" -UpgradePolicy "Automatic" -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $username -AdminPassword $password `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $offer -ImageReferenceSku $imgSku -ImageReferenceVersion $version `
            -ImageReferencePublisher $publisher;

        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        Assert-True {$vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.Enable};
        Assert-AreEqual 'PT15M' $vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.NotBeforeTimeout;


        # Update-AzVmss test
        $vmssName2 = 'vs2' + $rgname;
        $vmss2 = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSku -UpgradePolicyMode "Automatic" -SecurityType $stnd `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test2' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test2' -AdminUsername $username -AdminPassword $password `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $offer -ImageReferenceSku $imgSku -ImageReferenceVersion $version `
            -ImageReferencePublisher $publisher;
        $result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName2 -VirtualMachineScaleSet $vmss2;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2;
        Assert-False {$vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.Enable};
        Assert-Null $vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.NotBeforeTimeout;

        Update-AzVmss -VMScaleSetName $vmssName2 -ResourceGroupName $rgname -OSImageScheduledEventEnabled -OSImageScheduledEventNotBeforeTimeoutInMinutes "PT15M";
        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2;
        Assert-True {$vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.Enable};
        Assert-AreEqual 'PT15M' $vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.NotBeforeTimeout;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test the Get-AzVmss ResourceId parameter set.
This uses an ARM Resource Id to get an existing Vmss.
#>
function Test-VirtualMachineScaleSetGetById
{

    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $imageName = "Win2019Datacenter";
        $domainNameLabel = "d1" + $rgname;
        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential($adminUsername, $adminPassword);

        $result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel ;

        $vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;
        $vmssId = $vmss.Id;
        $vmssGet = Get-AzVmss -ResourceId $vmssId;

        Assert-AreEqual $vmss.Id $vmssGet.Id;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set VtpmEabled and SecureBootEnabled
for the certain Trusted Launch feature setup.
#>
function Test-VirtualMachineScaleSetSecurityType
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $securityType = "TrustedLaunch";
        $enable = $true;
        $disable = $false;

        # NRP
        $vnetworkName = 'vnet' + $rgname;
        $subnetName = 'subnet' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName1 = 'vmss1' + $rgname;
        $vmssName2 = 'vmss2' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
        $imgRef.PublisherName = $PublisherName;
        $imgRef.Offer = $Offer;
        $imgRef.Skus = $SKU;
        $imgRef.Version = "latest";


        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName ;

        # Requirements for the TrustedLaunch default behavior.
        #Case 1: -SecurityType = TrustedLaunch || ConfidentialVM
        # validate that for -SecurityType "TrustedLaunch" "-Vtpm" and -"SecureBoot" are "Enabled/true"
        $vmss1 = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $securityType;
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmss1;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;

        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;

        #Case 2: -SecurityType = "TrustedLaunch" || "ConfidentialVM" -EnableVtpm $false -EnableSecureBoot $true
        $vmss2 = Set-AzVmssUefi -VirtualMachineScaleSet $VMSS -EnableVtpm $disable -EnableSecureBoot $enable;
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2 -VirtualMachineScaleSet $vmss2;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2;

        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $false;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
        # Vmss Identity is now in fact only UserAssigned as expected.

        # Guest Attestation extension defaulting test
        # Removed this portion as this logic was removed as per feature team request. 
        <#
        $vmGADefaultIdentity = "SystemAssigned"; # New defaulting behavior that was unexpected but feature team says go with it.
        $extDefaultName = "GuestAttestation";
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName1;
        # Assert-AreEqual $vmGADefaultIDentity $vmssGet.Identity.Type;

        $output = $vmssGet | Out-String;
        # Write-Verbose ($output);
        Assert-True { $output.Contains($vmGADefaultIdentity) };

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName1;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $extDefaultName $vmssvm.Resources[2].Name;
        Assert-True {$vmssvm.Resources[2].EnableAutomaticUpgrade};
        #>
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set VtpmEabled and SecureBootEnabled
for the Trusted Launch feature setup.
Tests that GuestAttestation extension is also installed.
#>
function Test-VirtualMachineScaleSetSecurityTypeWithoutConfig
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $vmssName2 = 'vmss2' + $rgname;
        $imageName = "Win2016DataCenterGenSecond";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $domainNameLabel1 = "d1" + $rgname;
        $domainNameLabel2 = "d2" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        # Requirements for the TrustedLaunch default behavior.
        #Case 1: -SecurityType = TrustedLaunch || ConfidentialVM
        # validate that for -SecurityType "TrustedLaunch" "-Vtpm" and -"SecureBoot" are "Enabled/true"
        $res = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel1 -SecurityType $securityType ;

        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;

        #Case 2: -SecurityType = "TrustedLaunch" || "ConfidentialVM" -EnableVtpm $false -EnableSecureBoot $true
        $result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName2 -ImageName $imageName -DomainNameLabel $domainNameLabel2 -SecurityType $securityType -EnableVtpm $disable;

        Assert-AreEqual $result.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $result.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $false;
        Assert-AreEqual $result.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;

        # Update-AzVmss EnableVtpm
        $vmssUp = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2 -EnableVtpm $true;
        $vmssGet2 = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName2;
        Assert-AreEqual $vmssGet2.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;

        # Guest Attestation extension defaulting test
        # Removing this portion as this logic was removed as per feature team request (ajay.kundnani@microsoft.com)
        <#
        $vmGADefaultIdentity = "SystemAssigned"; # New defaulting behavior that was unexpected but feature team says go with it.
        $extDefaultName = "GuestAttestation";
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName1;
        # Assert-AreEqual $vmGADefaultIDentity $vmssGet.Identity.Type;

        $output = $vmssGet | Out-String;
        # Write-Verbose ($output);
        Assert-True { $output.Contains($vmGADefaultIdentity) };

        $vmssvms = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName1;
        Assert-NotNull $vmssvms;
        $vmssvm = Get-AzVmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -InstanceId $vmssvms[0].InstanceId;
        Assert-AreEqual $extDefaultName $vmssvm.Resources[2].Name;
        Assert-True {$vmssvm.Resources[2].EnableAutomaticUpgrade};
        #>
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set with SecurityType of Standard.
#>
function Test-VirtualMachineScaleSetSecurityTypeStandard
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $imageName = "Win2016DataCenterGenSecond";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $domainNameLabel1 = "d1" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityTypeStnd = "Standard";
        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        # Create Vmss
        $vmss = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel1 -SecurityType $securityTypeStnd;

        Assert-Null $vmss.VirtualMachineProfile.SecurityProfile;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set with SecurityType of Standard with Config.
No SecurityPRofile should be made for now in this scenario. 
#>
function Test-VirtualMachineScaleSetSecurityTypeStandardWithConfig
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $securityTypeStnd = "Standard";
        $enable = $true;
        $disable = $false;

        # NRP
        $vnetworkName = 'vnet' + $rgname;
        $subnetName = 'subnet' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName1 = 'vmss1' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
        $imgRef.PublisherName = $PublisherName;
        $imgRef.Offer = $Offer;
        $imgRef.Skus = $SKU;
        $imgRef.Version = "latest";
        
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName ;

        # Create Vmss
        $vmss1 = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $securityTypeStnd;
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmss1;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;

        # Verify security value
        Assert-Null $vmssGet.VirtualMachineProfile.SecurityProfile;

        
        # 2nd Scenario, SecurityType passed into only New-AzVmssConfig and not Set-AzVmssSecurityProfile.
        $vmssName2 = 'vmss2' + $rgname;
        $nameprefix = "test2";
        # NRP
        $vnetworkName = 'vnet2' + $rgname;
        $subnetName = 'subnet2' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $ipCfg = New-AzVmssIPConfig -Name $nameprefix -SubnetId $subnetId;
        
        $vmss2 = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' -SecurityType $securityTypeStnd `
			| Add-AzVmssNetworkInterfaceConfiguration -Name $nameprefix -Primary $true -IPConfiguration $ipCfg `
			| Set-AzVmssOSProfile -ComputerNamePrefix $nameprefix -AdminUsername $adminUsername -AdminPassword $adminPassword `
			| Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
			-ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
			-ImageReferencePublisher $imgRef.PublisherName ;
        # Create Vmss
        $result2 = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2 -VirtualMachineScaleSet $vmss2;
        $vmssGet2 = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2;

        # Verify security value
        Assert-Null $vmssGet2.VirtualMachineProfile.SecurityProfile;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}


<#
.SYNOPSIS
Test Virtual Machine Scale ImageReferenceSku Update
using Update-Azvmss
#>
function Test-VirtualMachineScaleSetImageReferenceSkuUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $imageName = "Win2016DataCenter";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $domainNameLabel1 = "d1" + $rgname;
        $domainNameLabel2 = "d2" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        $res = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel1 ;
        $vmss = Get-AzVmss -ResourceGroupName $rgname -Name $vmssName1;
        Assert-AreEqual $vmss.VirtualMachineProfile.StorageProfile.ImageReference.SKU "2016-datacenter";

        Update-AzVmss -ResourceGroupName $rgname  -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmss -ImageReferenceSku 2019-datacenter
        Assert-AreEqual $vmss.VirtualMachineProfile.StorageProfile.ImageReference.SKU "2019-datacenter";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set VtpmEabled and SecureBootEnabled
for the Trusted Launch feature setup.
#>
function Test-VirtualMachineScaleSetSecurityTypeWithoutConfigUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $vmssName2 = 'vmss2' + $rgname;
        $imageName = "Win2016DataCenterGenSecond";
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $domainNameLabel1 = "d1" + $rgname;
        $domainNameLabel2 = "d2" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        # Create TL vmss
        $res = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel1 ;
        Assert-Null $res.VirtualMachineProfile.SecurityProfile;

        # Test update functionality
        $vmssUp = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -SecurityType $securityType -EnableSecureBoot $disable -EnableVtpm $disable;
        $vmssGet = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;

        $vmssUp1 = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -EnableVtpm $true;
        $vmssGet1 = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet1.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;

        $vmssUp2 = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -EnableSecureBoot $true;
        $vmssGet2 = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet2.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set TL update and the EnableVtpm and EnableSecureBoot values.
#>
function Test-VirtualMachineScaleSetSecurityTypeUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $PublisherName = "MicrosoftWindowsServer";
        $Offer = "WindowsServer";
        $SKU = "2016-datacenter-gensecond";
        $securityType = "TrustedLaunch";
        $enable = $true;
        $disable = $false;

        # NRP
        $vnetworkName = 'vnet' + $rgname;
        $subnetName = 'subnet' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName1 = 'vmss1' + $rgname;
        $vmssName2 = 'vmss2' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = Get-ComputeTestResourceName;
        $adminPassword = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;

        $imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
        $imgRef.PublisherName = $PublisherName;
        $imgRef.Offer = $Offer;
        $imgRef.Skus = $SKU;
        $imgRef.Version = "latest";
        
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName ;

        # Create TL Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmss;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1; 
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;

        # Test update functionality
        Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmssGet -SecurityType $securityType -EnableSecureBoot $disable -EnableVtpm $disable;

        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;

        $vmssUp1 = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmssGet -EnableVtpm $true;
        $vmssGet1 = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet1.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;

        $vmssUp2 = Update-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmssGet1 -EnableSecureBoot $true;
        $vmssGet2 = Get-AzVmss -ResourcegroupName $rgname -VMScaleSetName $vmssName1;
        Assert-AreEqual $vmssGet2.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set securityType TrustedLaunch is default.
Defaults in the New-AzVmssConfig cmdlet and New-AzVmss.
#>
function Test-VirtualMachineScaleSetSecurityTypeDefaulting 
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName1 = 'vmss1' + $rgname;
        $imageName = "Win2022AzureEdition";
        $sku = "2022-Datacenter-Azure-Edition";
        
        $domainNameLabel1 = "d1" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        # Requirements for the TrustedLaunch default behavior.
        $res = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -DomainNameLabel $domainNameLabel1;

        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
        Assert-AreEqual $res.VirtualMachineProfile.StorageProfile.ImageReference.Sku $sku;
        
        # With Config scenario:
        $vmssName2 = 'vmss2' + $rgname;
        $imageName = "Win2022AzureEdition";
        $publisherName = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $sku = "2022-Datacenter-Azure-Edition";#"2022-datacenter-azure-edition-core";
        $version = "latest";

        # NRP
        $vnetworkName = 'vnet' + $rgname;
        $subnetName = 'subnet' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        
        
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $password;
            

        # Create TL Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2 -VirtualMachineScaleSet $vmss;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName2;
        
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.StorageProfile.ImageReference.Sku $sku;
    
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set securityType TrustedLaunch is default.
Defaults in the New-AzVmssConfig cmdlet and New-AzVmss.
#>
function Test-VirtualMachineScaleSetSecurityTypeDefaultingFromImage
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssSize = 'Standard_D4s_v3';
        $vmssName = 'vmss' + $rgname;
        $imageName = "Win2022AzureEdition";
        $sku = "2022-Datacenter-Azure-Edition";
        
        $domainNameLabel1 = "d1" + $rgname;
        $disable = $false;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $vmCred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);
        
        # With Config scenario:
        $imageName = "Win2022AzureEdition";
        $publisherName = "MicrosoftWindowsServer";
        $offer = "WindowsServer";
        $sku = "2022-Datacenter-Azure-Edition";#"2022-datacenter-azure-edition-core";
        $version = "latest";

        # NRP
        $vnetworkName = 'vnet' + $rgname;
        $subnetName = 'subnet' + $rgname;
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetworkName -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        
        
        $ipCfg = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId;

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $password `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
            -ImageReferenceOffer $offer -ImageReferenceSku $sku -ImageReferenceVersion $version `
            -ImageReferencePublisher $publisherName ;

        # Create TL Vmss
        $result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmss;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
        Assert-AreEqual $vmssGet.VirtualMachineProfile.StorageProfile.ImageReference.Sku $sku;
    
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set defaulting to OrchestrationMode: Flexible when property is not provided.
#>
function Test-VirtualMachineScaleSetDefaultToFlexibleOrchestrationMode
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # New VMSS Parameters
        $vmssName1 = 'vmss1' + $rgname;

        $vmssConfig = New-AzVmssConfig -Location $loc -UpgradePolicyMode 'Manual' -SinglePlacementGroup $true;
        $vmss = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmssConfig;

        # Asserts 
        # check flexmode
        Assert-AreEqual $vmss.OrchestrationMode "Flexible";
        # check SinglePlacementGroup
        Assert-AreEqual $vmss.SinglePlacementGroup $true;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
    create a VMSS in flexible mode 
    Test Attach scenario of adding a vmss
    Test Detach scenario of removing the VMSS
#>
function Test-VirtualMachineScaleSetAttachAndDetach
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # New VMSS Parameters
        $vmssName = 'vmssAttachAndDetach' + $rgname;
        $vmName = 'vm' + $rgname;

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $adminPassword -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $securePassword);

        $VmssFlex = New-AzVmss `
          -ResourceGroupName $rgname `
          -Name $vmssName `
          -OrchestrationMode 'Flexible' `
          -Location 'eastus' `
          -Credential $cred `
          -DomainNameLabel "scaleset-70f699" `
          -SecurityType "Standard"

        $vm = new-azvm -resourcegroupname $rgname -location $loc -name $vmname -credential $cred -DomainNameLabel "scaleset-70f699"

        # attach
        Update-Azvm -resourcegroupname $rgname -VM $vm -VirtualMachineScaleSetId $VmssFlex.id
        $updatedVmWithVmss = get-azvm -resourcegroupname $rgname -Name $vmname 
        Assert-AreEqual $VmssFlex.id $updatedVmWithVmss.VirtualMachineScaleSet.Id

        # detach
        Update-Azvm -resourcegroupname $rgname -VM $updatedVmWithVmss -VirtualMachineScaleSetId $null
        $updatedVm = get-azvm -resourcegroupname $rgname -Name $vmname 
        Assert-Null $updatedVm.VirtualMachineScaleSet.Id


    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set securityType TrustedLaunch is default.
TL can only be used when a VMProfile is provided.
This would require a lot of other vmConfig setup. 
#>
function Test-VirtualMachineScaleSetSecurityTypeNoVMProfile
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $vmssName = 'vmss' + $rgname;

        # Create TL Vmss
        $vmssConfig = New-AzVmssConfig -loc $loc;
        New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -VirtualMachineScaleSet $vmssConfig;
        $vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        Assert-Null $vmssGet.VirtualMachineProfile;
        Assert-AreEqual $vmssGet.OrchestrationMode "Flexible"; 
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set securityType TrustedLaunch is default
and also defaults in Vmss Flex.
#>
function Test-VirtualMachineScaleSetSecurityTypeAndFlexDefaults
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmssName1 = 'vmss1' + $rgname;

        $domainNameLabel1 = "d1" + $rgname;
        $enable = $true;
        $securityType = "TrustedLaunch";
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        # Requirements for the TrustedLaunch default behavior.
        $res = New-AzVmss -ResourceGroupName $rgname -Credential $cred -VMScaleSetName $vmssName1 -DomainNameLabel $domainNameLabel1;

        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.SecurityType $securityType;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $enable;
        Assert-AreEqual $res.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $enable;
        Assert-AreEqual $res.OrchestrationMode "Flexible";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}