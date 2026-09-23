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
Test Images
#>
function Test-Image
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
        $tags = @{test1 = "testval1"; test2 = "testval2" };
        $imageConfig = New-AzImageConfig -Location $loc -Tag $tags -HyperVGeneration "V1";
        Set-AzImageOsDisk -Image $imageConfig -OsType 'Windows' -OsState 'Generalized' -BlobUri $osDiskVhdUri;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 1 -BlobUri $dataDiskVhdUri1;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 2 -BlobUri $dataDiskVhdUri2;
        $imageConfig = Add-AzImageDataDisk -Image $imageConfig -Lun 3 -BlobUri $dataDiskVhdUri2;
        Assert-AreEqual 3 $imageConfig.StorageProfile.DataDisks.Count;
        $imageConfig = Remove-AzImageDataDisk -Image $imageConfig -Lun 3;
        Assert-AreEqual 2 $imageConfig.StorageProfile.DataDisks.Count;

        $job = New-AzImage -Image $imageConfig -ImageName $imageName -ResourceGroupName $rgname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $createdImage = $job | Receive-Job

        # Verify Image properties
        Assert-NotNull $createdImage.Id;
        Assert-AreEqual $imageName $createdImage.Name;
        Assert-AreEqual 2 $createdImage.StorageProfile.DataDisks.Count;

        Assert-AreEqual "Succeeded" $createdImage.ProvisioningState;
        Assert-AreEqual $osDiskVhdUri $createdImage.StorageProfile.OsDisk.BlobUri;
        Assert-AreEqual $dataDiskVhdUri1 $createdImage.StorageProfile.DataDisks[0].BlobUri;
        Assert-AreEqual $dataDiskVhdUri2 $createdImage.StorageProfile.DataDisks[1].BlobUri;

        Assert-True {$createdImage.Tags.ContainsKey("test1") }
        Assert-AreEqual "testval1" $createdImage.Tags["test1"]
        Assert-True {$createdImage.Tags.ContainsKey("test2") }
        Assert-AreEqual "testval2" $createdImage.Tags["test2"]

        # List and Delete Image
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($imageName -replace ".$") + "*"
        
        $images = Get-AzImage;
        Assert-True { $images.Count -ge 1 };
        
        $images = Get-AzImage -ResourceGroupName $wildcardRgQuery;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;

        $images = Get-AzImage -ResourceGroupName $rgname;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        
        $images = Get-AzImage -Name $wildcardNameQuery;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        Assert-AreEqual $imageName $images[0].Name;
        
        $images = Get-AzImage -Name $imageName;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        Assert-AreEqual $imageName $images[0].Name;
        
        $images = Get-AzImage -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        Assert-AreEqual $imageName $images[0].Name;
        
        $images = Get-AzImage -ResourceGroupName $rgname -Name $wildcardNameQuery;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        Assert-AreEqual $imageName $images[0].Name;
        
        $images = Get-AzImage -ResourceGroupName $wildcardRgQuery -Name $imageName;
        Assert-AreEqual 1 $images.Count;
        Assert-AreEqual $rgname $images[0].ResourceGroupName;
        Assert-AreEqual $imageName $images[0].Name;
        
        $image = Get-AzImage -ResourceGroupName $rgname -Name $imageName;
        Assert-AreEqual $rgname $image.ResourceGroupName;
        Assert-AreEqual $imageName $image.Name;
        Assert-AreEqual "V1" $image.HyperVGeneration;

        # Update Image Tag
        $image | Update-AzImage -Tag @{test1 = "testval3"; test2 = "testval4"};
        Update-AzImage -ResourceGroupName $rgname -ImageName $imageName -Tag @{test1 = "testval3"; test2 = "testval4"};
        Update-AzImage -Image $image -Tag @{test1 = "testval3"; test2 = "testval4"};
        Update-AzImage -ResourceId $image.Id -Tag @{test1 = "testval3"; test2 = "testval4"};

        $image = Get-AzImage -ResourceGroupName $rgname -ImageName $imageName;
        Assert-True {$image.Tags.ContainsKey("test1") }
        Assert-AreEqual "testval3" $image.Tags["test1"]
        Assert-True {$image.Tags.ContainsKey("test2") }
        Assert-AreEqual "testval4" $image.Tags["test2"]
        Assert-AreEqual "V1" $image.HyperVGeneration;

        $job = Remove-AzImage -ResourceGroupName $rgname -ImageName $imageName -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $images = Get-AzImage -ResourceGroupName $rgname;
        Assert-AreEqual 0 $images.Count;

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-ImageCapture
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

        # Get VM
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;

        Stop-AzVM -ResourceGroupName $rgname -Name $vmname -Force;
        Set-AzVM -ResourceGroupName $rgname -Name $vmname -Generalize;

        # Create Image through capture of the VM
        $imageName = 'image' + $rgname;
        $imageConfig = New-AzImageConfig -Location $loc -SourceVirtualMachineId $vm.Id;
        $createdImage = New-AzImage -Image $imageConfig -ImageName $imageName -ResourceGroupName $rgname;

        Assert-NotNull $createdImage.Id;
        Assert-AreEqual $imageName $createdImage.Name;
        Assert-AreEqual 2 $createdImage.StorageProfile.DataDisks.Count;
        
        Assert-AreEqual "Succeeded" $createdImage.ProvisioningState;
        Assert-AreEqual $osDiskVhdUri $createdImage.StorageProfile.OsDisk.BlobUri;
        Assert-AreEqual $dataDiskVhdUri1 $createdImage.StorageProfile.DataDisks[0].BlobUri;
        Assert-AreEqual $dataDiskVhdUri2 $createdImage.StorageProfile.DataDisks[1].BlobUri;

        # List and Delete Image
        $images = Get-AzImage -ResourceGroupName $rgname;
        Assert-AreEqual 1 $images.Count;

        Remove-AzImage -ResourceGroupName $rgname -ImageName $imageName -Force;
        $images = Get-AzImage -ResourceGroupName $rgname;
        Assert-AreEqual 0 $images.Count;

        # Remove All VMs
        Get-AzVM -ResourceGroupName $rgname | Remove-AzVM -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-DefaultImagesExistManual
{
    
    # Setup
    #$rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;
    $rgname = Get-ComputeTestResourceName;
    
    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        
        $user = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $domainNameLabel = "d" + $rgname;
        
        # assuming the below file path:
        # C:\repos\ps3\azure-powershell\src\Compute\Compute\Strategies\ComputeRp\Images.json
        #$imagesFile = Get-Content -Path "..\..\..\..\Compute\Compute\Strategies\ComputeRp\Images.json";
        $imagesFile = Get-Content -Path "..\..\..\..\Compute\Strategies\ComputeRp\Images.json";
        $images = $imagesFile | ConvertFrom-Json;
        
        # Linux
        # UbuntuLTS test
        
        # Ubuntu2204 test
        $vmname = "v1" + $rgname;
        $publisher = $images.Linux.Ubuntu2204.publisher;
        $offer = $images.Linux.Ubuntu2204.offer;
        $sku = $images.Linux.Ubuntu2204.sku;
        $version = $images.Linux.Ubuntu2204.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Ubuntu2204;
        
        # Ubuntu 2404 test
        $vmname = "v2" + $rgname;
        $publisher = $images.Linux.Ubuntu2404.publisher;
        $offer = $images.Linux.Ubuntu2404.offer;
        $sku = $images.Linux.Ubuntu2404.sku;
        $version = $images.Linux.Ubuntu2404.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Ubuntu2404;

        # Ubuntu 2404 Pro test
        $vmname = "v3" + $rgname;
        $publisher = $images.Linux.Ubuntu2404Pro.publisher;
        $offer = $images.Linux.Ubuntu2404Pro.offer;
        $sku = $images.Linux.Ubuntu2404Pro.sku;
        $version = $images.Linux.Ubuntu2404Pro.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        $vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Ubuntu2404Pro;

        # CentOS versioned test
        $vmname = "v4" + $rgname;
        $publisher = $images.Linux.CentOS85Gen2.publisher;
        $offer = $images.Linux.CentOS85Gen2.offer;
        $sku = $images.Linux.CentOS85Gen2.sku;
        $version = $images.Linux.CentOS85Gen2.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image CentOS85Gen2;
        
        # Debian versioned test
        $vmname = "v5" + $rgname;
        $publisher = $images.Linux.Debian11.publisher;
        $offer = $images.Linux.Debian11.offer;
        $sku = $images.Linux.Debian11.sku;
        $version = $images.Linux.Debian11.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Debian11;
        
        # OpenSuseLeap154Gen2 versioned test
        $vmname = "v6" + $rgname;
        $publisher = $images.Linux.OpenSuseLeap154Gen2.publisher;
        $offer = $images.Linux.OpenSuseLeap154Gen2.offer;
        $sku = $images.Linux.OpenSuseLeap154Gen2.sku;
        $version = $images.Linux.OpenSuseLeap154Gen2.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image OpenSuseLeap154Gen2;
        
        # RHELRaw8LVMGen2 test
        $vmname = "v7" + $rgname;
        $publisher = $images.Linux.RHELRaw8LVMGen2.publisher;
        $offer = $images.Linux.RHELRaw8LVMGen2.offer;
        $sku = $images.Linux.RHELRaw8LVMGen2.sku;
        $version = $images.Linux.RHELRaw8LVMGen2.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName MyResourceGroup -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image RHELRaw8LVMGen2;

        # SuseSles15SP5 versioned test
        $vmname = "v8" + $rgname;
        $publisher = $images.Linux.SuseSles15SP5.publisher;
        $offer = $images.Linux.SuseSles15SP5.offer;
        $sku = $images.Linux.SuseSles15SP5.sku;
        $version = $images.Linux.SuseSles15SP5.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image SuseSles15SP5;

        # FlatcarLinuxFreeGen2 versioned test
        $vmname = "v9" + $rgname;
        $computerName = "c" + $rgname;
        $publisher = $images.Linux.FlatcarLinuxFreeGen2.publisher;
        $offer = $images.Linux.FlatcarLinuxFreeGen2.offer;
        $sku = $images.Linux.FlatcarLinuxFreeGen2.sku;
        $version = $images.Linux.FlatcarLinuxFreeGen2.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;

        $vnetname = "vn" + $rgname;
        $vnetAddress = "10.0.0.0/16";
        $subnetname = "slb" + $rgname;
        $subnetAddress = "10.0.2.0/24";
        $NICName = $vmname+ "-nic";
        $NSGName = $vmname + "-NSG";


        $frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;

        $vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;
         
        $nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
        $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $RGName -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
        $nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $RGName -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;

        # VM
        $vmConfig = New-AzVMConfig -SecurityType "Standard" -VmSize "Standard_DS3_v2" -Name $vmname;
        Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmName -Credential $cred;
        Set-AzVMSourceImage -VM $vmConfig -PublisherName "kinvolk" -Offer "flatcar-container-linux-free" -Skus "stable-gen2" -Version "latest" ;
        Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;
        
        #New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $vmconfig;
        # New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image FlatcarLinuxFreeGen2;
        
        
        # Windows
        # Win2022AzureEditionCore test
        $vmname = "va" + $rgname;
        $publisher = $images.Windows.Win2022AzureEditionCore.publisher;
        $offer = $images.Windows.Win2022AzureEditionCore.offer;
        $sku = $images.Windows.Win2022AzureEditionCore.sku;
        $version = $images.Windows.Win2022AzureEditionCore.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win2022AzureEditionCore;

        # Win10 test
        $vmname = "vt" + $rgname;
        $publisher = $images.Windows.Win10.publisher;
        $offer = $images.Windows.Win10.offer;
        $sku = $images.Windows.Win10.sku;
        $version = $images.Windows.Win10.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win10;

        # Win2019Datacenter test
        $vmname = "vd" + $rgname;
        $publisher = $images.Windows.Win2019Datacenter.publisher;
        $offer = $images.Windows.Win2019Datacenter.offer;
        $sku = $images.Windows.Win2019Datacenter.sku;
        $version = $images.Windows.Win2019Datacenter.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win2019Datacenter;

        # Win2016Datacenter test
        $vmname = "vs" + $rgname;
        $publisher = $images.Windows.Win2016Datacenter.publisher;
        $offer = $images.Windows.Win2016Datacenter.offer;
        $sku = $images.Windows.Win2016Datacenter.sku;
        $version = $images.Windows.Win2016Datacenter.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win2016Datacenter;

        # Win2012R2Datacenter test
        $vmname = "vr" + $rgname;
        $publisher = $images.Windows.Win2012R2Datacenter.publisher;
        $offer = $images.Windows.Win2012R2Datacenter.offer;
        $sku = $images.Windows.Win2012R2Datacenter.sku;
        $version = $images.Windows.Win2012R2Datacenter.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win2012R2Datacenter;

        # Win2012Datacenter test
        $vmname = "va" + $rgname;
        $publisher = $images.Windows.Win2012Datacenter.publisher;
        $offer = $images.Windows.Win2012Datacenter.offer;
        $sku = $images.Windows.Win2012Datacenter.sku;
        $version = $images.Windows.Win2012Datacenter.version;
        $img = Get-AzVMImage -Location $loc -Publisher $publisher -Offer $offer -Sku $sku -Version $version;
        Assert-NotNull $img;
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Win2012Datacenter;

        
    }
    finally 
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}