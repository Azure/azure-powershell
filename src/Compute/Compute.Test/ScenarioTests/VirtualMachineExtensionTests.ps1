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
Test Virtual Machine Extensions
#>
function Test-VirtualMachineExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

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

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $extver = '1.1';

        # Set extension settings by raw strings
        $settingstr = '{"fileUris":[],"commandToExecute":"powershell Get-Process"}';
        $protectedsettingstr = '{"storageAccountName":"' + $stoname + '","storageAccountKey":"' + $stokey + '"}';
        $job = Set-AzVMExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname -Publisher $publisher -ExtensionType $exttype -TypeHandlerVersion $extver -SettingString $settingstr -ProtectedSettingString $protectedsettingstr -AsJob
        $job | Wait-Job

        # Get VM Extension
        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;
        Assert-NotNull $ext.SubStatuses;

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-True { $ext.Count -ge 1 }
        Assert-Null $ext[0].Statuses

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Status
        Assert-NotNull $ext.Statuses

        # Remove Extension
        $ext | Remove-AzVMExtension -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Virtual Machine Extensions
#>
function Test-VirtualMachineExtensionUsingHashTable
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

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

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine Create
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $extver = '1.1';

        # Set extension settings by hash table
        $settings = @{"fileUris" = @(); "commandToExecute" = "powershell Get-Process"};
        $protectedsettings = @{"storageAccountName" = $stoname; "storageAccountKey" = $stokey};
        Set-AzVMExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname -Publisher $publisher -ExtensionType $exttype -TypeHandlerVersion $extver -Settings $settings -ProtectedSettings $protectedsettings;

        # Get VM Extension
        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Write-Verbose("Get-AzVM: ");
        $a = $vm1 | Out-String;
        Write-Verbose($a);

        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $vm1.StorageProfile.ImageReference.Version $imgRef.Version;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;

        # Remove Extension
        Remove-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions
#>
function Test-VirtualMachineCustomScriptExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $extver = '1.1';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $fileToExecute = 'a.exe';
        $containerName = 'script';

        # Set custom script extension
        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname `
            -Name $extname -TypeHandlerVersion $extver -StorageAccountName $stoname -StorageAccountKey $stokey `
            -FileName $fileToExecute -ContainerName $containerName; } `
            "Failed to download all specified files";

        # Get VM Extension
        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;

        $expCommand = 'powershell -ExecutionPolicy Unrestricted -file ' + $fileToExecute + ' ';
        $expUri = $stoname + '.blob.core.windows.net/' + $containerName + '/' + $fileToExecute;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;

        # *** TODO: The removal call did not return. 12/12/2014
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-VirtualMachineCustomScriptExtensionPiping
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmname = 'vm' + $rgname;
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();
        $vmobject = New-AzVm -Name $vmname -ResourceGroupName $rgname -Credential $cred -DomainNameLabel $domainNameLabel;

        $csename = "myCustomExtension";
        $fileUri = "https://raw.githubusercontent.com/neilpeterson/nepeters-azure-templates/master/windows-custom-script-simple/support-scripts/Create-File.ps1";
        $runname = "Create-File.ps1";

        # Parameter set interactive
        Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename `
            -Location $loc -FileUri $fileUri -Run $runname;
        $cseobject = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename;

        Assert-NotNull $cseobject;
        Assert-Match $runname $cseobject.CommandToExecute;

        # Parameter set InputObject
        $argument = "-NonInteractive";
        $cseobject | Set-AzVMCustomScriptExtension -Argument $argument;
        $cseobject = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename;

        Assert-NotNull $cseobject;
        Assert-Match $runname $cseobject.CommandToExecute;
        Assert-Match $argument $cseobject.CommandToExecute;

        # Parameter set ResourceId
        Set-AzVMCustomScriptExtension -ResourceId $cseobject.Id -Location $loc `
            -FileUri $fileUri -Run $runname;
        $cseobject = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename;

        Assert-NotNull $cseobject;
        Assert-Match $runname $cseobject.CommandToExecute;
        Assert-NotMatch $argument $cseobject.CommandToExecute;


        # Parameter set TopLevelResourceObject
        $vmobject | Set-AzVMCustomScriptExtension -Name $csename -Location $loc `
            -FileUri $fileUri -Run $runname -Argument $argument;
        $cseobject = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename;

        Assert-NotNull $cseobject;
        Assert-Match $runname $cseobject.CommandToExecute;
        Assert-Match $argument $cseobject.CommandToExecute;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions with wrong storage account name
#>
function Test-VirtualMachineCustomScriptExtensionWrongStorage
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $extver = '1.1';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $fileToExecute = 'a.exe';
        $containerName = 'script';

        # Set custom script extension
        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname `
            -Name $extname -TypeHandlerVersion $extver -StorageAccountName "abc" `
            -FileName $fileToExecute -ContainerName $containerName; } `
            "not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions with Secure Execution
#>
function Test-VirtualMachineCustomScriptExtensionSecureExecution
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $extver = '1.1';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $fileToExecute = 'a.exe';
        $containerName = 'script';

        # Set custom script extension
        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname `
                -Name $extname -TypeHandlerVersion $extver `
                -StorageAccountName $stoname -StorageAccountKey $stokey `
                -FileName $fileToExecute -ContainerName $containerName -SecureExecution; } `
            "Failed to download all specified files";

        # Get VM Extension
        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;

        $expCommand = 'powershell -ExecutionPolicy Unrestricted -file ' + $fileToExecute + ' ';
        $expUri = $stoname + '.blob.core.windows.net/' + $containerName + '/' + $fileToExecute;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-Null $ext.CommandToExecute;
        Assert-NotNull $ext.ProvisioningState;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions using FileUri
#>
function Test-VirtualMachineCustomScriptExtensionFileUri
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $extver = '1.1';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $containerName = 'scripts';
        $fileToExecute = 'test1.ps1';
        $duration = New-Object -TypeName TimeSpan(2,0,0);
        $type = [Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions]::Read;

        $sasFile1 = Get-SasUri $stoname $stokey $containerName $fileToExecute $duration $type;
        $sasFile2 = Get-SasUri $stoname $stokey $containerName $fileToExecute $duration $type;

        # Set custom script extension
        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname `
            -Name $extname -TypeHandlerVersion $extver -Run $fileToExecute -FileUri $sasFile1, $sasFile2; } `
            "Failed to download all specified files";

        # Get VM Extension
        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;

        $expCommand = 'powershell -ExecutionPolicy Unrestricted -file ' + $fileToExecute+ ' ';
        $expUri = $stoname + '.blob.core.windows.net/' + $containerName + '/' + $fileToExecute;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions on Linux VM
#>
function Test-VirtualMachineCustomScriptExtensionLinuxVM
{
    $testMode = Get-ComputeTestMode
    $rgname = Get-ComputeTestResourceName
    try
    {
        # create virtual machine
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmsize = 'Standard_D2S_V3';
        $vmname = 'vm' + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "7.5";
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'linuxOsDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/linuxos.vhd";
        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -Caching $osDiskCaching -CreateOption FromImage -Linux;
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred;
        $p = Set-AzVMSourceImage -VM $p -PublisherName $imagePublisher -Offer $imageOffer -Skus $imageSku -Version "latest"
        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imageOffer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imagePublisher;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imageSku;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        $csename = "myCustomExtension";
        $fileUri = "https://raw.githubusercontent.com/neilpeterson/nepeters-azure-templates/master/windows-custom-script-simple/support-scripts/Create-File.ps1";
        $runname = "Create-File.ps1";

        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename -Location $loc -FileUri $fileUri -Run $runname; } `
            "The current VM is a Linux VM.  Custom script extension can be set only to Windows VM.";
    }
    finally
    {
        Clean-ResourceGroup($rgname)
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions with Managed Disk VM
#>
function Test-VirtualMachineCustomScriptExtensionManagedDisk
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = (Get-ComputeVMLocation).ToLower().Replace(" ", "");
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Create a VM with managed disk
        $vmname0 = $rgname + "v0";        
        $username = "admin01";
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password;
        [string]$domainNameLabel = "$vmname0-$vmname0".tolower();

        $imgversion = Get-VMImageVersion -Publisher "MicrosoftWindowsServer" -Offer "WindowsServer" -Sku "2016-Datacenter";
        $x = New-AzVM `
            -ResourceGroupName $rgname `
            -Name $vmname0 `
            -Location $loc `
            -Credential $cred `
            -DomainNameLabel $domainNameLabel `
            -ImageName ("MicrosoftWindowsServer:WindowsServer:2016-Datacenter:" + $imgversion);

        # Get a managed disk from the stopped VM.
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname0;
        Stop-AzVM -ResourceGroupName $rgname -Name $vmname0 -Force;
        $managedDisk = Get-AzDisk -ResourceGroupName $rgname -DiskName $vm.StorageProfile.OsDisk.Name;

        # Create a managed OS disk by copying the OS disk of the stopped VM.
        $diskname = $rgname + "disk";        
        $diskConfig = New-AzDiskConfig -SourceResourceId $managedDisk.Id -Location $loc -CreateOption Copy;
        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskConfig;
        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname;

        Assert-AreEqual $diskname $disk.Name;
        Assert-AreEqual $managedDisk.DiskSizeGB $disk.DiskSizeGB;
        Assert-AreEqual $managedDisk.OsType $disk.OsType;

        # VM Profile & Hardware
        $vmsize = 'Standard_D2s_v3';
        $vmname1 = $rgname + "v1";
        $p = New-AzVMConfig -VMName $vmname1 -VMSize $vmsize;

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

        # Set the OS disk from the managed OS disk.
        $osDiskCaching = 'ReadWrite';
        $osDiskType = 'Premium_LRS';
        $p = Set-AzVMOSDisk -VM $p -Windows -Name $disk.Name -Caching $osDiskCaching -CreateOption Attach -StorageAccountType $osDiskType -ManagedDiskId $disk.Id -DiskSizeInGB $disk.DiskSizeGB;

        Assert-AreEqual $osDiskCaching $p.StorageProfile.OSDisk.Caching;
        Assert-AreEqual $osDiskType $p.StorageProfile.OSDisk.ManagedDisk.StorageAccountType;
        Assert-AreEqual $disk.Name $p.StorageProfile.OSDisk.Name;
        Assert-AreEqual $disk.Id $p.StorageProfile.OSDisk.ManagedDisk.Id;
        Assert-AreEqual $disk.DiskSizeGB $p.StorageProfile.OSDisk.DiskSizeGB;
        Assert-AreEqual $disk.OsType $p.StorageProfile.OSDisk.OsType;

        # Create a VM using the managed OS disk.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;       
        Assert-Null $vm.OSProfile;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; };
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        # Virtual Machine Extension
        $extname = $rgname + 'ext';
        $extver = '1.1';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $fileToExecute = 'a.exe';
        $containerName = 'script';

        # Set custom script extension
        Assert-ThrowsContains { `
            Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname1 `
            -Name $extname -TypeHandlerVersion $extver -StorageAccountName $stoname -StorageAccountKey $stokey `
            -FileName $fileToExecute -ContainerName $containerName; } `
            "Failed to download all specified files";

        # Get VM Extension
        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname1 -Name $extname;

        $expCommand = 'powershell -ExecutionPolicy Unrestricted -file ' + $fileToExecute + ' ';
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname1 -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.CommandToExecute $expCommand;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Get VM
        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;
        Assert-AreEqual $vm1.Name $vmname1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Custom Script Extensions return Substatuses
#>
function Test-VirtualMachineCustomScriptExtensionSubstatuses
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmname = 'vm' + $rgname;
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();
        $vmobject = New-AzVm -Name $vmname -ResourceGroupName $rgname -Credential $cred -DomainNameLabel $domainNameLabel;

        $csename = "myCustomExtension";
        $fileUri = "https://raw.githubusercontent.com/neilpeterson/nepeters-azure-templates/master/windows-custom-script-simple/support-scripts/Create-File.ps1";
        $runname = "Create-File.ps1";

        # Parameter set interactive
        Set-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename `
            -Location $loc -FileUri $fileUri -Run $runname;
        $cseobject = Get-AzVMCustomScriptExtension -ResourceGroupName $rgname -VMName $vmname -Name $csename -Status;

        Assert-NotNull $cseobject;
        Assert-NotNull $cseobject.SubStatuses;
        Assert-Match $runname $cseobject.CommandToExecute;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Test Virtual Machine Access Extensions
#>
function Test-VirtualMachineAccessExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force; <#[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        <#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        # TODO: Still need to do retry for New-AzVM for SA, even it's returned in Get-.
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = 'csetest';
        $extver = '2.0';
        $user2 = "Bar12";
        $password2 = 'FoO@123' + $rgname;
        $securePassword2 = ConvertTo-SecureString $password2 -AsPlainText -Force;

        # Set custom script extension
        $cred2 = New-Object System.Management.Automation.PSCredential ($user2, $securePassword2);
        Set-AzVMAccessExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname -TypeHandlerVersion $extver -Credential $cred2

        $publisher = 'Microsoft.Compute';
        $exttype = 'VMAccessAgent';

        # Get VM Extension
        $ext = Get-AzVMAccessExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.UserName $user2;
        Assert-NotNull $ext.ProvisioningState;
        Assert-True {$ext.PublicSettings.Contains("UserName")};

        $ext = Get-AzVMAccessExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;
        Assert-True {$ext.PublicSettings.Contains("UserName")};

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;

        # *** TODO: The removal call did not return. 12/12/2014
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test the Set-AzVMDiskEncryptionExtension single pass scenario
#>
function Test-AzureDiskEncryptionExtensionSinglePass
{
    $resourceGroupName = Get-ComputeTestResourceName
    try
    {
        # create virtual machine and key vault prerequisites
        $vm = Create-VirtualMachine $resourceGroupName
        $kv = Create-KeyVault $vm.ResourceGroupName $vm.Location

        # enable encryption with single pass syntax (omits AD parameters)
        Set-AzVMDiskEncryptionExtension `
            -ResourceGroupName $vm.ResourceGroupName `
            -VMName $vm.Name `
            -DiskEncryptionKeyVaultUrl $kv.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $kv.DiskEncryptionKeyVaultId `
            -Force

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted Encrypted
        # For Native disks we expect the cmdlet to show the data disks as encrypted.
        Assert-AreEqual $status.DataVolumesEncrypted Encrypted

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-NotNull $settings
        Assert-NotNull $settings.DiskEncryptionKey.SecretUrl
        Assert-AreEqual $settings.DiskEncryptionKey.SourceVault.Id $kv.DiskEncryptionKeyVaultId
    }
    finally
    {
        Clean-ResourceGroup($resourceGroupName)
    }
}

<#
.SYNOPSIS
Test the Get-AzVmDiskEncryptionStatus single pass remove scenario
#>
function Test-AzureDiskEncryptionExtensionSinglePassRemove
{
    $resourceGroupName = Get-ComputeTestResourceName
    try
    {
        # create virtual machine and key vault prerequisites
        $vm = Create-VirtualMachineNoDataDisks $resourceGroupName
        $kv = Create-KeyVault $vm.ResourceGroupName $vm.Location

        # enable encryption with single pass syntax (omits AD parameters)
        Set-AzVMDiskEncryptionExtension `
            -ResourceGroupName $vm.ResourceGroupName `
            -VMName $vm.Name `
            -DiskEncryptionKeyVaultUrl $kv.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $kv.DiskEncryptionKeyVaultId `
            -Force

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted Encrypted
        Assert-AreEqual $status.DataVolumesEncrypted NoDiskFound

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-NotNull $settings
        Assert-NotNull $settings.DiskEncryptionKey.SecretUrl
        Assert-AreEqual $settings.DiskEncryptionKey.SourceVault.Id $kv.DiskEncryptionKeyVaultId

        # remove extension
        Remove-AzVmDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -Force
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted Encrypted
        Assert-AreEqual $status.DataVolumesEncrypted NoDiskFound

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-NotNull $settings
        Assert-NotNull $settings.DiskEncryptionKey.SecretUrl
        Assert-AreEqual $settings.DiskEncryptionKey.SourceVault.Id $kv.DiskEncryptionKeyVaultId

    }
    finally
    {
        Clean-ResourceGroup($resourceGroupName)
    }
}

<#
.SYNOPSIS
Test the Set-AzVMDiskEncryptionExtension single pass disable and remove scenario
#>
function Test-AzureDiskEncryptionExtensionSinglePassDisableAndRemove
{
    $resourceGroupName = Get-ComputeTestResourceName
    try
    {
        # create virtual machine and key vault prerequisites
        $vm = Create-VirtualMachine $resourceGroupName
        $kv = Create-KeyVault $vm.ResourceGroupName $vm.Location

        # enable encryption with single pass syntax (omits AD parameters)
        Set-AzVMDiskEncryptionExtension `
            -ResourceGroupName $vm.ResourceGroupName `
            -VMName $vm.Name `
            -DiskEncryptionKeyVaultUrl $kv.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $kv.DiskEncryptionKeyVaultId `
            -Force

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted Encrypted
        Assert-AreEqual $status.DataVolumesEncrypted Encrypted

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-NotNull $settings
        Assert-NotNull $settings.DiskEncryptionKey.SecretUrl
        Assert-AreEqual $settings.DiskEncryptionKey.SourceVault.Id $kv.DiskEncryptionKeyVaultId

        # disable encryption
        $status = Disable-AzVmDiskEncryption -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -Force
        Assert-NotNull $status

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted NotEncrypted
        Assert-AreEqual $status.DataVolumesEncrypted NotEncrypted

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-Null $settings

        # remove extension
        $status = Remove-AzVmDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -Force
        Assert-NotNull $status
    }
    finally
    {
        Clean-ResourceGroup($resourceGroupName)
    }
}

<#
.SYNOPSIS
Test the Set-AzVMDiskEncryptionExtension single pass enable and disable scenario with non default parameters
#>
function Test-AzureDiskEncryptionExtensionNonDefaultParams
{
    $resourceGroupName = Get-ComputeTestResourceName
    try
    {
        # create virtual machine and key vault prerequisites
        $vm = Create-VirtualMachine $resourceGroupName
        $kv = Create-KeyVault $vm.ResourceGroupName $vm.Location

        $extensionPublisher = "Microsoft.Azure.Security.Edp";
        $extensionName = "MyExtension";

        # enable encryption with single pass syntax (omits AD parameters)
        Set-AzVMDiskEncryptionExtension `
            -ResourceGroupName $vm.ResourceGroupName `
            -VMName $vm.Name `
            -DiskEncryptionKeyVaultUrl $kv.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $kv.DiskEncryptionKeyVaultId `
            -ExtensionPublisherName $extensionPublisher `
            -ExtensionName $extensionName `
            -Force

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -ExtensionPublisherName $extensionPublisher -ExtensionName $extensionName
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted Encrypted
        Assert-AreEqual $status.DataVolumesEncrypted Encrypted

        # verify encryption settings
        $settings = $status.OsVolumeEncryptionSettings
        Assert-NotNull $settings
        Assert-NotNull $settings.DiskEncryptionKey.SecretUrl
        Assert-AreEqual $settings.DiskEncryptionKey.SourceVault.Id $kv.DiskEncryptionKeyVaultId

        # disable encryption
        $status = Disable-AzVmDiskEncryption -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -ExtensionPublisherName $extensionPublisher -ExtensionName $extensionName -Force
        Assert-NotNull $status

        # verify encryption state
        $status = Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -ExtensionPublisherName $extensionPublisher -ExtensionName $extensionName
        Assert-NotNull $status
        Assert-AreEqual $status.OsVolumeEncrypted NotEncrypted
        Assert-AreEqual $status.DataVolumesEncrypted NotEncrypted
    }
    finally
    {
        Clean-ResourceGroup($resourceGroupName)
    }
}

<#
.SYNOPSIS
Test the Set-AzVMDiskEncryptionExtension single pass enable for Linux managed disk VMs
#>
function Test-AzureDiskEncryptionLnxManagedDisk
{
    $testMode = Get-ComputeTestMode
    $rgname = Get-ComputeTestResourceName
    try
    {
        # create virtual machine
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmsize = 'Standard_D2S_V3';
        $vmname = 'vm' + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "7.5";
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'linuxOsDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/linuxos.vhd";
        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -Caching $osDiskCaching -CreateOption FromImage -Linux;
        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force; <#[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        <#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred;
        $p = Set-AzVMSourceImage -VM $p -PublisherName $imagePublisher -Offer $imageOffer -Skus $imageSku -Version "latest"
        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imageOffer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imagePublisher;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imageSku;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
        $kv = Create-KeyVault $rgname $loc;
        # Enable single pass encryption without -skipVmBackup on Linux VM managed disk and verify exception is thrown
        Assert-ThrowsContains { Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmname -DiskEncryptionKeyVaultUrl $kv.DiskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $kv.DiskEncryptionKeyVaultId -VolumeType "OS" -Force; } `
            "skipVmBackup parameter is a required parameter for encrypting Linux VMs with managed disks"; #>
    }
    finally
    {
        Clean-ResourceGroup($rgname)
    }
}

<#
.SYNOPSIS
Test AzureDiskEncryption extension
#>
function Test-AzureDiskEncryptionExtension
{
    # This test should be run in Live mode only not in Playback mode
    #Pre-requisites to be filled in before running this test. The AAD app should belong to the directory as the user running the test.
    $aadAppName = "detestaadapp";

    #Resource group variables
    $rgName = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    #Fill in VM admin user and password
    $adminUser = "Foo12";
    $adminPassword = $PLACEHOLDER;

    #KeyVault config variables
    $vaultName = "detestvault";
    $vault2Name = "detestvault2";
    $kekName = "dstestkek";

    #VM config variables
    $vmName = "detestvm";
    $vmsize = 'Standard_DS2';
    $imagePublisher = "MicrosoftWindowsServer";
    $imageOffer = "WindowsServer";
    $imageSku ="2012-R2-Datacenter";

    #Storage config variables
    $storageAccountName = "deteststore";
    $stotype = 'Premium_LRS';
    $vhdContainerName = "vhds";
    $osDiskName = 'osdisk' + $vmName;
    $dataDiskName = 'datadisk' + $vmName;
    $osDiskCaching = 'ReadWrite';
    $extraDataDiskName1 = $dataDiskName + '1';
    $extraDataDiskName2 = $dataDiskName + '2';

    #Network config variables
    $vnetName = "detestvnet";
    $subnetName = "detestsubnet";
    $publicIpName = 'pubip' + $vmName;
    $nicName = 'nic' + $vmName;

    #Disk encryption variables
    $keyEncryptionAlgorithm = "RSA-OAEP";
    $volumeType = "All";

    try
    {
        # Create new resource group
        New-AzResourceGroup -Name $rgName -Location $loc -Force;

        #Check if AAD app was already created
        $SvcPrincipals = (Get-AzADServicePrincipal -SearchString $aadAppName);
        if(-not $SvcPrincipals)
        {
            # Create a new AD application if not created before
            $identifierUri = [string]::Format("http://localhost:8080/{0}", $rgname);
            $defaultHomePage = 'http://contoso.com';
            $now = [System.DateTime]::Now;
            $oneYearFromNow = $now.AddYears(1);
            $aadClientSecret = Get-ResourceName;
            $ADApp = New-AzADApplication -DisplayName $aadAppName -HomePage $defaultHomePage -IdentifierUris $identifierUri  -StartDate $now -EndDate $oneYearFromNow -Password $aadClientSecret;
            Assert-NotNull $ADApp;
            $servicePrincipal = New-AzADServicePrincipal -ApplicationId $ADApp.ApplicationId;
            $SvcPrincipals = (Get-AzADServicePrincipal -SearchString $aadAppName);
            # Was AAD app created?
            Assert-NotNull $SvcPrincipals;
            $aadClientID = $servicePrincipal.ApplicationId;
        }
        else
        {
            # Was AAD app already created?
            Assert-NotNull $aadClientSecret;
            $aadClientID = $SvcPrincipals[0].ApplicationId;
        }

        # Create new KeyVault
        $keyVault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $loc -Sku standard;
        $keyVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname
        #set enabledForDiskEncryption
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -EnabledForDiskEncryption;
        #set permissions to AAD app to write secrets and keys
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ServicePrincipalName $aadClientID -PermissionsToKeys all -PermissionsToSecrets all
        #create a key in KeyVault to use as Kek
        $kek = Add-AzKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software"

        $diskEncryptionKeyVaultUrl = $keyVault.VaultUri;
        $keyVaultResourceId = $keyVault.ResourceId;
        $keyEncryptionKeyUrl = $kek.Key.kid;

        # Create the 2nd key vault
        $keyVault2 = New-AzKeyVault -VaultName $vault2Name -ResourceGroupName $rgname -Location $loc -Sku standard;
        $keyVault2 = Get-AzKeyVault -VaultName $vault2Name -ResourceGroupName $rgname
        #set enabledForDiskEncryption
        Set-AzKeyVaultAccessPolicy -VaultName $vault2Name -ResourceGroupName $rgname -EnabledForDiskEncryption;
        #set permissions to AAD app to write secrets and keys
        Set-AzKeyVaultAccessPolicy -VaultName $vault2Name -ServicePrincipalName $aadClientID -PermissionsToKeys all -PermissionsToSecrets all

        $diskEncryptionKeyVaultUrl2 = $keyVault2.VaultUri;
        $keyVaultResourceId2 = $keyVault2.ResourceId;

        # VM Profile & Hardware
        $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ($subnetName) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzVirtualNetwork -Force -Name ($vnetName) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name ($vnetName) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzPublicIpAddress -Force -Name ($publicIpName) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ($publicIpName);
        $pubip = Get-AzPublicIpAddress -Name ($publicIpName) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzNetworkInterface -Force -Name ($nicName) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzNetworkInterface -Name ($nicName) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;

        # Storage Account (SA)
        New-AzStorageAccount -ResourceGroupName $rgname -Name $storageAccountName -Location $loc -Type $stotype;
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storageAccountName)[0].Value;

        $osDiskVhdUri = "https://$storageAccountName.blob.core.windows.net/$vhdContainerName/$osDiskName.vhd";
        $dataDiskVhdUri = "https://$storageAccountName.blob.core.windows.net/$vhdContainerName/$dataDiskName.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name $dataDiskName -Caching 'ReadOnly' -DiskSizeInGB 2 -Lun 1 -VhdUri $dataDiskVhdUri -CreateOption Empty;

        # OS & Image
        $securePassword = ConvertTo-SecureString $adminPassword -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUser, $securePassword);
        $computerName = $vmName;
        $vhdContainer = "https://$storageAccountName.blob.core.windows.net/$vhdContainerName";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
        $p = Set-AzVMSourceImage -VM $p -PublisherName $imagePublisher -Offer $imageOffer -Skus $imageSku -Version "latest";

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        #Enable encryption on the VM
        Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -Force;
        #Get encryption status
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $vmName;
        #Verify encryption is enabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $true;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $true;
        #verify diskencryption keyvault url & kek url are not null
        Assert-NotNull $OsVolumeEncryptionSettings;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SourceVault;

        # Change settings on the VM
        Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl2 -DiskEncryptionKeyVaultId $keyVaultResourceId2 -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -Force;

        #Add a couple of data volumes to encrypt them
        $p = Add-AzVMDataDisk -VM $p -Name $extraDataDiskName1 -Caching 'ReadOnly' -DiskSizeInGB 2 -Lun 1 -VhdUri $dataDiskVhdUri -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name $extraDataDiskName2 -Caching 'ReadOnly' -DiskSizeInGB 2 -Lun 1 -VhdUri $dataDiskVhdUri -CreateOption Empty;
        #Enable encryption on the VM
        Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -Force;
        #Get encryption status
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $vmName;
        #Verify encryption is enabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $true;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $true;
        #verify diskencryption keyvault url & kek url are not null
        Assert-NotNull $OsVolumeEncryptionSettings;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SourceVault;

        #Disable encryption on the VM
        Disable-AzVMDiskEncryption -ResourceGroupName $rgname -VMName $vmName;
        #Get encryption status
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $p.StorageProfile.OSDisk.Name;
        #Verify encryption is disabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $false;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $false;

        #Remove AzureDiskEncryption extension
        Remove-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName;
        #Get encryption status again to make sure it's the same as before when the extension was installed
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $vmName;
        #Verify encryption is disabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $false;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $false;

        #Enable encryption on the VM
        Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -Force;
        #Get encryption status
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $vmName;
        #Verify encryption is enabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $true;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $true;
        #verify diskencryption keyvault url & kek url are not null
        Assert-NotNull $OsVolumeEncryptionSettings;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SourceVault;

        #Update encryption settings on the VM from KEK to No KEK
        Set-AzVMDiskEncryptionExtension -ResourceGroupName $rgname -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -Force;
        #Get encryption status
        $encryptionStatus = Get-AzVmDiskEncryptionStatus -ResourceGroupName $rgname -VMName $vmName;
        #Verify encryption is enabled on OS volume and data volumes
        $OsVolumeEncryptionSettings = $encryptionStatus.OsVolumeEncryptionSettings;
        Assert-AreEqual $encryptionStatus.OsVolumeEncrypted $true;
        Assert-AreEqual $encryptionStatus.DataVolumesEncrypted $true;
        #verify diskencryption keyvault url & secret url are not null
        Assert-NotNull $OsVolumeEncryptionSettings;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-NotNull $OsVolumeEncryptionSettings.DiskEncryptionKey.SourceVault;
        #verify key encryption key keyvault url & secret url are null after the update
        Assert-Null $OsVolumeEncryptionSettings.KeyEncryptionKey.SecretUrl;
        Assert-Null $OsVolumeEncryptionSettings.KeyEncryptionKey.SourceVault;

        #Remove the VM
        Remove-AzVm -ResourceGroupName $rgname -Name $vmName -Force;

        #Create a brand new VM using the same OS vhd encrypted above
        $p.StorageProfile.ImageReference = $null;
        $p.OSProfile = $null;
        $p.StorageProfile.DataDisks = $null;
        $p = Set-AzVMOSDisk -VM $p -Name $p.StorageProfile.OSDisk.Name -VhdUri $p.StorageProfile.OSDisk.Vhd.Uri -Caching ReadWrite -CreateOption attach -DiskEncryptionKeyUrl $encryptionStatus.OsVolumeEncryptionSettings.DiskEncryptionKey.SecretUrl -DiskEncryptionKeyVaultId $encryptionStatus.OsVolumeEncryptionSettings.DiskEncryptionKey.SourceVault.Id -Windows;

        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
        #Remove-AzADApplication -ApplicationObjectId $ADApp.ApplicationId -Force;
    }
}

<#
.SYNOPSIS
Test Virtual Machine BGInfo Extensions
#>
function Test-VirtualMachineBginfoExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force; <#[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        <#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Credentials are used only for the duration of test. Resources are deleted at the end of the test.")]#>
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p -DisableBginfoExtension;

        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Virtual Machine Extension
        $extname = 'csetest';
        $extver = '2.1';

        # Set custom script extension
        Set-AzVMBginfoExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -TypeHandlerVersion $extver;

        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';

        # Get VM Extension
        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.UserName $user2;
        Assert-NotNull $ext.ProvisioningState;

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Get VM
        $vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 1;
        Assert-AreEqual $vm1.Extensions[0].Name $extname;
        Assert-AreEqual $vm1.Extensions[0].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[0].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[0].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[0].TypeHandlerVersion $extver;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Extensions
#>
function Test-VirtualMachineExtensionWithSwitch
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
        Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
        Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
        Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $extver = '1.1';

        # Set extension settings by raw strings
        $settingstr = '{"fileUris":[],"commandToExecute":""}';
        $protectedsettingstr = '{"storageAccountName":"' + $stoname + '","storageAccountKey":"' + $stokey + '"}';
        Set-AzVMExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname `
            -Name $extname -Publisher $publisher `
            -ExtensionType $exttype -TypeHandlerVersion $extver -SettingString $settingstr -ProtectedSettingString $protectedsettingstr `
            -DisableAutoUpgradeMinorVersion -ForceRerun "RerunExtension";

        # Get VM Extension
        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;
        Assert-False{$ext.AutoUpgradeMinorVersion};
        Assert-AreEqual $ext.ForceUpdateTag "RerunExtension";

        $ext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;
        Assert-NotNull $ext.SubStatuses;

        # Remove Extension
        Remove-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine ADDomain Extensions
#>
function Test-VirtualMachineADDomainExtension
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = 'csetest';
        $extver = '1.3';
        $domainName = "Workgroup2"

        # Set ADDomain extension
        Set-AzVMADDomainExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname -DomainName $domainName;

        $publisher = 'Microsoft.Compute';
        $exttype = 'JsonADDomainExtension';

        # Get VM Extension
        $ext = Get-AzVMADDomainExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;

        # Validate Domain Join parameters.
        Assert-AreEqual $domainName $ext.DomainName;
        Assert-Null $ext.OUPath;
        Assert-Null $ext.User;
        Assert-AreEqual 0 $ext.JoinOption;
        Assert-False {$ext.Restart};

        $ext = Get-AzVMADDomainExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Validate Domain Join parameters.
        Assert-AreEqual $domainName $ext.DomainName;
        Assert-Null $ext.OUPath;
        Assert-Null $ext.User;
        Assert-AreEqual 0 $ext.JoinOption;
        Assert-False {$ext.Restart};

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;

        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine ADDomain Extensions with Domain Join
#>
function Test-VirtualMachineADDomainExtensionDomainJoin
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
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
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account (SA)
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
        $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";

        $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
        $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

        Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
        Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
        Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
        Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
        Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
        Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
        Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);

        Assert-AreEqual $p.OSProfile.AdminUsername $user;
        Assert-AreEqual $p.OSProfile.ComputerName $computerName;
        Assert-AreEqual $p.OSProfile.AdminPassword $password;
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

        # Virtual Machine
        New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Virtual Machine Extension
        $extname = 'csetest';
        $extver = '1.3';
        $domainName = "dom123.com";
        $user2 = 'dom123.com\Bar12';
        $password2 = $PLACEHOLDER;
        $securePassword2 = ConvertTo-SecureString $password2 -AsPlainText -Force;
        $cred2 = New-Object System.Management.Automation.PSCredential ($user2, $securePassword2);
        $ouPath = "OU=testOU,DC=domain,DC=Domain,DC=com";

        # Set ADDomain extension
        Assert-ThrowsContains { Set-AzVMADDomainExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname `
            -DomainName $domainName -Credential $cred2 -OUPath $ouPath -JoinOption 3 -Restart; } `
            "occured while joining Domain";
        $publisher = 'Microsoft.Compute';
        $exttype = 'JsonADDomainExtension';

        # Get VM Extension
        $ext = Get-AzVMADDomainExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;

        # Validate Domain Join parameters.
        Assert-AreEqual $domainName $ext.DomainName;
        Assert-AreEqual $ouPath $ext.OUPath;
        Assert-AreEqual $user2 $ext.User;
        Assert-AreEqual 3 $ext.JoinOption;
        Assert-True {$ext.Restart};

        $ext = Get-AzVMADDomainExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname -Status;
        Assert-AreEqual $ext.ResourceGroupName $rgname;
        Assert-AreEqual $ext.Name $extname;
        Assert-AreEqual $ext.Publisher $publisher;
        Assert-AreEqual $ext.ExtensionType $exttype;
        Assert-AreEqual $ext.TypeHandlerVersion $extver;
        Assert-NotNull $ext.ProvisioningState;
        Assert-NotNull $ext.Statuses;

        # Validate Domain Join parameters.
        Assert-AreEqual $domainName $ext.DomainName;
        Assert-AreEqual $ouPath $ext.OUPath;
        Assert-AreEqual $user2 $ext.User;
        Assert-AreEqual 3 $ext.JoinOption;
        Assert-True {$ext.Restart};

        # Get VM
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-AreEqual $vm1.Name $vmname;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $vm1.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        Assert-AreEqual $vm1.OSProfile.AdminUsername $user;
        Assert-AreEqual $vm1.OSProfile.ComputerName $computerName;
        Assert-AreEqual $vm1.HardwareProfile.VmSize $vmsize;

        # Check Extensions in VM
        Assert-AreEqual $vm1.Extensions.Count 2;
        Assert-AreEqual $vm1.Extensions[1].Name $extname;
        Assert-AreEqual $vm1.Extensions[1].Type 'Microsoft.Compute/virtualMachines/extensions';
        Assert-AreEqual $vm1.Extensions[1].Publisher $publisher;
        Assert-AreEqual $vm1.Extensions[1].VirtualMachineExtensionType $exttype;
        Assert-AreEqual $vm1.Extensions[1].TypeHandlerVersion $extver;
        Assert-NotNull $vm1.Extensions[1].Settings;

        Remove-AzVM -Name $vmname -ResourceGroupName $rgname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Extensions EnableAutomaticUpgrade
#>
function Test-VirtualMachineExtensionEnableAutomaticUpgrade
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $user = "Foo2";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        $vmname = "extensionTestVM"
        $vmssname = "extensionTestVmss"
        $domainNameLabel = 'pubip'+$rgname;
        $domainNameLabel2 = $domainNameLabel + '2'


        # create vm/vmss
        New-AzVM -ResourceGroupName $rgname -Location $loc -name $vmname -credential $cred -domainNameLabel $domainNameLabel
        New-AzVmss -ResourceGroupName $rgname -Location $loc -VMScalesetName $vmssname -credential $cred -domainNameLabel $domainNameLabel2

        # check vm/vmss
        $vm = Get-AzVM -Name $vmname -ResourceGroupName $rgname;
        Assert-NotNull $vm;
        $vmss = Get-AzVmss -Name $vmssname -ResourceGroupName $rgname;
        Assert-NotNull $vmss;
        
        # Extension
        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'CustomScriptExtension';
        $extver = '1.1';
        
        # Set extension settings by raw strings
        $settingstr = '{"fileUris":[],"commandToExecute":"powershell Get-Process"}';
        $protectedsettingstr = '{"storageAccountName":"somename","storageAccountKey":"somekey"}';

        Set-AzVMExtension -ResourceGroupName $rgname -Location $loc -VMName $vmname -Name $extname -Publisher $publisher -ExtensionType $exttype -TypeHandlerVersion $extver -SettingString $settingstr -ProtectedSettingString $protectedsettingstr -enableAutomaticUpgrade $False; 
        $VMSSext = Add-AzVmssExtension -VirtualMachineScaleSet $vmss -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -enableAutomaticUpgrade $False; 
        
        $VMext = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname -Name $extname;

        # check enableAutomaticUpgrade property
        Assert-False { $VMext.EnableAutomaticUpgrade };
        Assert-False { $VMSSext.VirtualMachineProfile.ExtensionProfile.Extensions[-1].EnableAutomaticUpgrade };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}