<#
.SYNOPSIS
	1) Installs the SqlIaaS extension by calling Set-AzureRmVMSqlServerExtension cmdlet on a VM.
	2) Calls Get-AzureRmVMSqlServerExtension cmdlet to check the status of the extension installation.
	3) Verifies settings are correct given input
	4) Update extension values
	5) Verify changes
	6) Test with correct Name and Version
	7) Test with correct Name and incorrect Version
	8) Test with incorrect Name and crrect Version
	9) Test with incorrect Name and incorrect Version
#>

function Test-SetAzureRmVMSqlServerAKVExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Common
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
        $vmname = 'vm' + $rgname;
        $p = New-AzureRmVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRmVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRmVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRmPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRmPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureRmNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureRmNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureRmVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

        $p = Set-AzureRmVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

        # OS & Image
        $user = "localadmin";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzureRmVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
        $p = Set-AzureRmVMSourceImage -VM $p -PublisherName MicrosoftSQLServer -Offer SQL2014SP1-WS2012R2 -Skus Enterprise -Version "latest"

        # Virtual Machine
        New-AzureRmVM -ResourceGroupName $rgname -Location $loc -VM $p;

        #Do actual changes and work here

        $extensionName = "Microsoft.SqlServer.Management.SqlIaaSAgent";

        # 1) Installs the SqlIaaS extension by calling Set-AzureRmVMSqlServerExtension cmdlet on a VM.

        $securepfxpwd = ConvertTo-SecureString –String "Amu6y/RzJcc7JBzdAdRVv6mk=" –AsPlainText –Force;
        $aps_akv = New-AzureVMSqlServerKeyVaultCredentialConfig -ResourceGroupName $rgname -Enable -CredentialName "CredentialTesting" -AzureKeyVaultUrl "https://Testkeyvault.vault.azure.net/" -ServicePrincipalName "0326921f-bf005595337c" -ServicePrincipalSecret $securepfxpwd;
        Set-AzureRmVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv -ResourceGroupName $rgname -VMName $vmname -Version "1.2" -Verbose; 

        # 2) Calls Get-AzureRmVMSqlServerExtension cmdlet to check the status of the extension installation.
        $extension = Get-AzureRmVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

        # 3) Verifies settings are correct given input

        Assert-AreEqual $extension.KeyVaultCredentialSettings.CredentialName "CredentialTesting";

        # 4) Update extension values

        $aps_akv = New-AzureVMSqlServerKeyVaultCredentialConfig -ResourceGroupName $rgname -Enable -CredentialName "CredentialTest" -AzureKeyVaultUrl "https://Testkeyvault.vault.azure.net/" -ServicePrincipalName "0326921f-82af-4ab3-9d46-bf005595337c" -ServicePrincipalSecret $securepfxpwd;
        Set-AzureRmVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv -ResourceGroupName $rgname -VMName $vmname -Version "1.2" -Verbose; 

        # 5) Verify changes
        $extension = Get-AzureRmVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

        Assert-AreEqual $extension.KeyVaultCredentialSettings.CredentialName "CredentialTest"

        # 6) Test with correct Name and Version

        Set-AzureRmVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "1.2"

        # 7) Test with correct Name and incorrect Version
        Set-AzureRmVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "1.*"
    }
    finally
    {
        # Cleanup
        if(Get-AzureRmResourceGroup -Name $rgname -Location $loc)
        {
             #Remove-AzureRmResourceGroup -Name $rgname -Force;
        }
    }
}

function Test-SetAzureRmVMSqlServerExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Common
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_A2';
        $vmname = 'vm' + $rgname;
        $p = New-AzureRmVMConfig -VMName $vmname -VMSize $vmsize;
        Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

        # NRP
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRmVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRmVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;
        $pubip = New-AzureRmPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
        $pubip = Get-AzureRmPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
        $pubipId = $pubip.Id;
        $nic = New-AzureRmNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
        $nic = Get-AzureRmNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzureRmVMNetworkInterface -VM $p -Id $nicId;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

        # Storage Account
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Retry-IfException { $global:stoaccount = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }

        $osDiskName = 'osDisk';
        $osDiskCaching = 'ReadWrite';
        $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
        $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

        $p = Set-AzureRmVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
        $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

        # OS & Image
        $user = "localadmin";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        $computerName = 'test';
        $vhdContainer = "https://$stoname.blob.core.windows.net/test";

        $p = Set-AzureRmVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
        $p = Set-AzureRmVMSourceImage -VM $p -PublisherName MicrosoftSQLServer -Offer SQL2014SP1-WS2012R2 -Skus Enterprise -Version "latest"

        # Virtual Machine
        New-AzureRmVM -ResourceGroupName $rgname -Location $loc -VM $p;

        #Do actual changes and work here

        $extensionName = "Microsoft.SqlServer.Management.SqlIaaSAgent";

        # 1) Installs the SqlIaaS extension by calling Set-AzureRmVMSqlServerExtension cmdlet on a VM.
        $aps = New-AzureVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Thursday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
        Set-AzureRmVMSqlServerExtension -AutoPatchingSettings $aps  -ResourceGroupName $rgname -VMName $vmname -Version "1.2" -Verbose -Name $extensionName;

        # 2) Calls Get-AzureRmVMSqlServerExtension cmdlet to check the status of the extension installation.
        $extension = Get-AzureRmVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

        # 3) Verifies settings are correct given input
        Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Thursday"
        Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowStartingHour 20
        Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowDuration 120
        Assert-AreEqual $extension.AutoPatchingSettings.PatchCategory "Important"

        # 4) Update extension values
        $aps = New-AzureVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Monday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
        Set-AzureRmVMSqlServerExtension -AutoPatchingSettings $aps  -ResourceGroupName $rgname -VMName $vmname -Version "1.2" -Verbose -Name $extensionName;

        # 5) Verify changes
        $extension = Get-AzureRmVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;
        Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Monday"

        # 6) Test with correct Name and Version
        Set-AzureRmVMSqlServerExtension -AutoPatchingSettings $aps  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "1.2"

        # 7) Test with correct Name and incorrect Version
        Set-AzureRmVMSqlServerExtension -AutoPatchingSettings $aps  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "1.*"
    }
    finally
    {
        # Cleanup
        if(Get-AzureRmResourceGroup -Name $rgname -Location $loc)
        {
            #Remove-AzureRmResourceGroup -Name $rgname -Force;
        }
    }
}

#helper methods for ARM
function Get-DefaultResourceGroupLocation
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = "Microsoft.Resources"
        $type = "resourceGroups"
        $location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

        if ($location -eq $null)
        {
            return "West US"
        } else
        {
            return $location.Locations[0]
        }
    }
    return "West US"
}
