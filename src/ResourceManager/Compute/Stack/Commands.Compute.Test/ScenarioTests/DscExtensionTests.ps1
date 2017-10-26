<#
.SYNOPSIS
End to end DSC test that tests Get-AzureRmVMDscExtension cmdlet. It does the following:
	1) Publishes a configuration to the default storage account using Publish-AzureRmVMDscConfiguration cmdlet
	2) Installs the extension by calling Set-AzureRmVMDscExtension cmdlet on a VM.
	3) Calls Get-AzureRmVMDscExtensionStatus cmdlet to check the status of the extension installation.
	4) Calls Get-AzureRmVMDscExtension cmdlet to get extension details post installation.
#>
function Test-GetAzureRmVMDscExtension
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
        $p = Set-AzureRmVMSourceImage -VM $p -PublisherName MicrosoftWindowsServer -Offer WindowsServer -Skus 2012-R2-Datacenter -Version "latest"
        
        # Virtual Machine
        New-AzureRmVM -ResourceGroupName $rgname -Location $loc -VM $p;

        # Test DSC Extension
        $version = '2.19';

		# Publish DSC Configuration
		#TODO: Find a way to mock calls with storage
		#$configPath = '.\ScenarioTests\DummyConfig.ps1'
		#Publish-AzureRmVMDscConfiguration -ConfigurationPath $configPath -ResourceGroupName $rgname -StorageAccountName $stoname -Force -Verbose

		#Install DSC Extension handler
		Set-AzureRmVMDscExtension -ResourceGroupName $rgname -VMName $vmname -ArchiveBlobName $null -ArchiveStorageAccountName $stoname -Version $version -Force -Location $loc

        $extension = Get-AzureRmVMDscExtension -ResourceGroupName $rgname -VMName $vmname 
		Assert-NotNull $extension
		Assert-AreEqual $extension.ResourceGroupName $rgname
		Assert-AreEqual $extension.Name "Microsoft.Powershell.DSC"
		Assert-AreEqual $extension.Publisher "Microsoft.Powershell"
		Assert-AreEqual $extension.ExtensionType "DSC"
		Assert-AreEqual $extension.TypeHandlerVersion $version
		Assert-NotNull $extension.ProvisioningState

		$status = Get-AzureRmVMDscExtensionStatus -ResourceGroupName $rgname -VMName $vmname 
		Assert-NotNull $status
		Assert-AreEqual $status.ResourceGroupName $rgname
		Assert-AreEqual $status.VmName $vmname 
		Assert-AreEqual $status.Version $version
		Assert-NotNull $status.Status 
		Assert-NotNull $status.Timestamp 
		
        # Remove Extension
        Remove-AzureRmVMDscExtension -ResourceGroupName $rgname -VMName $vmname
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
