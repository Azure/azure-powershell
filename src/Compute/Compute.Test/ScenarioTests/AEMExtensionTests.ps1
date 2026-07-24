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
Test the basic usage of the Set/Get/Test/Remove virtual machine Azure Enhanced Monitoring extension command

Set Tests:
1. Install new extension with VM that has a user assigned VM identity and no extension installed
	Tested by: Test-WithUserAssignedIdentity

2. Install new extension with VM that has no VM identity and no extension installed
	Tested by: Test-WithoutIdentity

3. Install new extension with VM that has SystemAssigned VM Identity and no extension installed
	Tested by: Test-WithSystemAssignedIdentity

4. Let it run twice with no switch
	Tested by: Test-OldExtensionReinstall

4. Let it run twice with new switch
	Tested by: Test-ExtensionReinstall

5. Test with UltraSSD
	Tested by: 

6. Test with no Extension and no switch
	Tested by: Test-OldExtensionReinstall

7. Test with no Extension and new switch
	Tested by: Test-WithUserAssignedIdentity

7. Install new extension with VM that has old extension installed
	Tested by: Test-ExtensionUpgrade

8. Install new extension with VM that has old extension and WAD installed
	Tested by: 

9. Install new extension with individual scope (parameter SetAccessToIndividualResources)
	Tested by: Test-WithUserAssignedIdentity

10. Test with Resource Group Scope
	Tested by: Test-WithoutIdentity

11. Test with noWait
	Tested by: 

12. Test new Extension installation with Windows
	Tested by: Test-WithUserAssignedIdentity

13. Test new Extension installation with SLES 12
	Tested by: Test-ExtensionDowngrade

14. Test new Extension installation with SLES 15
	Tested by: Test-ExtensionReinstall

15. Test new Extension installation with RHEL 7
	Tested by: Test-WithSystemAssignedIdentity

16. Test new Extension installation with RHEL 8
	Tested by: Test-WithoutIdentity

17. Test with new extension and no switch
	Tested by: Test-ExtensionDowngrade

187. Test new extension with proxy and debug mode
	Tested by: Test-ExtensionProxyDebug

Remove Test:
	1. run with no extension
		tested by: Test-WithUserAssignedIdentity
#>

function Assert-NewExtension($ResourceGroupName, $VMName, $IdentityType) {
	
	$newPublisher = "Microsoft.AzureCAT.AzureEnhancedMonitoring"
	$newTypeWin = "MonitorX64Windows"
	$newTypeLnx = "MonitorX64Linux"

	$vm = Get-AzVM -ResourceGroupName $ResourceGroupName -Name $VMName
	$extension = Get-AzVMAEMExtension -ResourceGroupName $ResourceGroupName -VMName $vm.Name
	$nul = Assert-NotNull $extension "New extension is not installed"	
	$nul = Assert-AreEqual $vm.Identity.Type $IdentityType "VM does not have the expected identity. Expected: $($IdentityType) Actual: $($vm.Identity.Type)"
	$nul = Assert-AreEqual $extension.Publisher $newPublisher
	$newType = ($extension.ExtensionType -eq $newTypeWin) -or ($extension.ExtensionType -eq $newTypeLnx)
	$nul = Assert-True { $newType } "Extension is not of type $($newTypeWin) nor $($newTypeLnx)"
	$nul = Assert-AreEqual $vm.Extensions.Count 1 "VM Extensions count does not equal 1"
	
	$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
	Assert-True { $result.Result } "Test of extension failed"
}

function Assert-OldExtension($ResourceGroupName, $VMName) {
	$oldPublisherWin = "Microsoft.AzureCAT.AzureEnhancedMonitoring"
	$oldPublisherLnx = "Microsoft.OSTCExtensions"
	$oldTypeWin = "AzureCATExtensionHandler"
	$oldTypeLnx = "AzureEnhancedMonitorForLinux"	

	$vm = Get-AzVM -ResourceGroupName $ResourceGroupName -Name $VMName
	$extension = Get-AzVMAEMExtension -ResourceGroupName $ResourceGroupName -VMName $vm.Name
	$nul = Assert-NotNull $extension "New extension is not installed"	
	$oldType = ($extension.ExtensionType -eq $oldTypeWin) -or ($extension.ExtensionType -eq $oldTypeLnx)
	$oldPublisher = ($extension.Publisher -eq $oldPublisherWin) -or ($extension.Publisher -eq $oldPublisherLnx)
	$nul = Assert-True { $oldType } "Extension is not of type $($oldTypeWin) nor $($oldTypeLnx)"
	$nul = Assert-True { $oldPublisher } "Extension Publisher is not $($oldPublisherWin) nor $($oldPublisherLnx)"
	$nul = Assert-AreEqual $vm.Extensions.Count 1 "VM Extensions count does not equal 1"
}

function Test-WithUserAssignedIdentity() {
	InitTest "Test-WithUserAssignedIdentity"

	Write-Verbose "Test: Test with UserAssigned Identity -> Result must be SystemAssignedUserAssigned"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
		$ident = Create-IdentityForNewExtension -ResourceGroupName $rgname -TestName "Test-WithUserAssignedIdentity" -location $loc
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		$vmUpd = Update-AzVM -ResourceGroupName $rgname -VM $vm -IdentityType UserAssigned -IdentityID $ident.Id
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name	
		$nul = Assert-AreEqual $vm.Identity.Type 'UserAssigned'

		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -SetAccessToIndividualResources
	
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssignedUserAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-WithoutIdentity() {
	InitTest "Test-WithoutIdentity"

	Write-Verbose "Test: Test with No Identity -> Result must be SystemAssigned"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "RHEL 8"

		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		$vmUpd = Update-AzVM -ResourceGroupName $rgname -VM $vm -IdentityType None
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-Null $vm.Identity.Type "VM still has an identity"

		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-WithSystemAssignedIdentity() {
	InitTest "Test-WithSystemAssignedIdentity"
	
	Write-Verbose "Test: Test with SystemAssigned Identity -> Result must be SystemAssigned"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "RHEL 7"
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		if ( (-not $vm.Identity) -and (-not ($vm.Identity.Type -eq "SystemAssigned")) ) {
			$vmUpd = Update-AzVM -ResourceGroupName $rgname -VM $vm -IdentityType SystemAssigned
			$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		}
		$nul = Assert-AreEqual $vm.Identity.Type "SystemAssigned"
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-ExtensionReinstall() {
	InitTest "Test-ExtensionReinstall"

	Write-Verbose "Test: new Extension re-install -> must work"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "SLES 15"
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		Write-Verbose "`tInstalling new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'	

		Write-Verbose "`tRe-Installing new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-NewExtensionDiskAdd() {
	InitTest "Test-NewExtensionDiskAdd"

	Write-Verbose "Test: Add Data Disk after extension installation"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		Write-Verbose "`tInstalling new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -SetAccessToIndividualResources
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'

		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nextLun = (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1)
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun $nextLun -CreateOption Empty -DiskSizeInGB 32 | Update-AzVM

		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed because of missing permissions to the added data disk"

		Write-Verbose "`tUpdating new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -SetAccessToIndividualResources	
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-ExtensionProxyDebug
{
	InitTest "Test-ExtensionProxyDebug"
   
    Write-Verbose "Test: VM Extension with proxy and debug mode"
	$rgname = Get-CustomResourceGroupName
	try
    {
        $proxyURI = "https://proxyhost:8080"
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
	
		Write-Verbose "`tInstalling new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -SetAccessToIndividualResources -ProxyURI $proxyURI -DebugExtension
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'

        $extension = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vm.Name
        $nul = Assert-NotNull $extension
        $nul = Assert-NotNull $extension.PublicSettings

        $extensionSettings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $extensionSettings
        $nul = Assert-NotNull $extensionSettings.cfg

        $proxySetting = $extensionSettings.cfg | Where-Object { $_.key -eq "proxy"}
        $nul = Assert-NotNull $proxySetting
        $nul = Assert-AreEqual $proxySetting.value $proxyURI
        
        $debugSetting = $extensionSettings.cfg | Where-Object { $_.key -eq "debug"}
        $nul = Assert-NotNull $debugSetting
        $nul = Assert-AreEqual $debugSetting.value "1"

	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


function Get-CustomResourceGroupName {
	$rgname = Get-ComputeTestResourceName

	return $rgname
}

function Get-LocationForNewExtension {
	$loc = Get-ComputeVMLocation    
    $loc = "westcentralus"
	return $loc
}

function Create-IdentityForNewExtension($ResourceGroupName, $TestName, $location) {
    $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($TestName, "crptestps");
	$ident = New-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $assetName -Location $location

	return $ident
}

function Create-AdvancedVM($rgname, $vmname, $loc, $vmsize, $stotype, $nicCount, $imageType = "Windows", [Switch] $useMD, $zone)
{
    Write-Verbose "Start Create-AdvancedVM"

    # Initialize parameters
    $rgname = if ([string]::IsNullOrEmpty($rgname)) { Get-ComputeTestResourceName } else { $rgname }
    $vmname = if ([string]::IsNullOrEmpty($vmname)) { 'vm' + $rgname } else { $vmname }
    $loc = if ([string]::IsNullOrEmpty($loc)) { Get-ComputeVMLocation } else { $loc }
    $vmsize = if ([string]::IsNullOrEmpty($vmsize)) { 'Standard_A2' } else { $vmsize }
    $stotype = if ([string]::IsNullOrEmpty($stotype)) { 'Standard_LRS' } else { $stotype }
    $nicCount = if ([string]::IsNullOrEmpty($nicCount)) { 1 } else { [int]$nicCount }

    # Common
    $g = New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $zoneparams = @{}
    if ($zone) 
    {
        $zoneparams.Add("Zone", $zone)  
    }
    $stnd = "Standard";
    $p = New-AzVMConfig -SecurityType $stnd -VMName $vmname -VMSize $vmsize @zoneparams;
    $nul = Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    Write-Verbose "Start Create-AdvancedVM - Config done"

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Static -DomainNameLabel ('pubip' + $rgname) -Sku Standard;
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    
    Write-Verbose "Start Create-AdvancedVM - adding pip $($pubip.Id)"
    $pibparams = @{}
    $pibparams.Add("PublicIpAddressId", $pubip.Id)
    $nicPrimParams = @{}
    $nicPrimParams.Add("Primary", $true)
    for ($i = 0;$i -lt $nicCount;$i++)
    {
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $i + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId @pibparams
        $nic = Get-AzNetworkInterface -Name ('nic' + $i + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId @nicPrimParams;
        $nul = Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[$i].Id $nicId;

        $pibparams = @{}
        $nicPrimParams = @{}
    }
    $nul = Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count $nicCount;   
    Write-Verbose "Start Create-AdvancedVM 1"
    # Storage Account (SA)
    $stoname = 'sto' + $rgname;
    $s = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;
    $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname).Key1;

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
    $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
    $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

    $osURI = @{}
    $disk1Uri = @{}
    $disk2Uri = @{}
    $disk3Uri = @{}
    Write-Verbose "Start Create-AdvancedVM 2"
    if (-not $useMD)
    {
        $osURI = @{"VhdUri"=$osDiskVhdUri}
        $disk1Uri = @{"VhdUri"=$dataDiskVhdUri1}
        $disk2Uri = @{"VhdUri"=$dataDiskVhdUri2}
        $disk3Uri = @{"VhdUri"=$dataDiskVhdUri3}
    }

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName @osURI -Caching $osDiskCaching -CreateOption FromImage -DiskSizeInGB 128;
    Write-Verbose "Start Create-AdvancedVM 3"
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 @disk1Uri -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 @disk2Uri -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 @disk3Uri -CreateOption Empty;
    $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

    $nul = Assert-AreEqual $p.StorageProfile.OsDisk.Caching $osDiskCaching;
    $nul = Assert-AreEqual $p.StorageProfile.OsDisk.Name $osDiskName;
    if (-not $useMD)
    {
        $nul = Assert-AreEqual $p.StorageProfile.OsDisk.Vhd.Uri $osDiskVhdUri;
    }
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
    if (-not $useMD)
    {
        $nul = Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
    }
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    $nul = Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
    if (-not $useMD)
    {
        $nul = Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
    }
    Write-Verbose "Start Create-AdvancedVM 4"
    # OS & Image
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";
    Write-Verbose "Start Create-AdvancedVM 5"
    if (Is-LinuxImageType $imageType)
    {
        $p = Set-AzVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred;

        $imgRef = Get-LinuxImage $imageType;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
    }
    else
    {
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-WindowsImage $imageType;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
    }
    Write-Verbose "Start Create-AdvancedVM 6"
    $nul = Assert-AreEqual $p.OSProfile.AdminUsername $user;
    $nul = Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    $nul = Assert-AreEqual $p.OSProfile.AdminPassword $password;
    if (-not (Is-LinuxImageType $imageType))
    {
        $nul = Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;
    }

    $nul = Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    $nul = Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    $nul = Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    $nul = Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;
    Write-Verbose "Start Create-AdvancedVM 7"
    $vmConfig = $p | convertto-json
    Write-Verbose "Start Create-AdvancedVM 8 $vmConfig"
    # Virtual Machine
    $p = Set-AzVMBootDiagnostic -VM $p -Disable
    Write-Verbose "Start Create-AdvancedVM - creating VM $($vmConfig)"
    
    Write-Verbose "Start Create-AdvancedVM - creating VM $($vmConfig)"
    $v = New-AzVM -ResourceGroupName $rgname -Location $loc -DisableBginfoExtension -VM $p;

    $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname

	Write-Verbose "Create-AdvancedVM done"
    return $vm
}

function Is-LinuxImageType($imageType) {
	return $imageType -ne "Windows"
}

function Get-LinuxImage($imageType) {

    if ($imageType -eq "RHEL 7") {
        return Create-ComputeVMImageObject 'RedHat' 'rhel' '7.8' 'latest';
    } elseif ($imageType -eq "RHEL 8") {
        return Create-ComputeVMImageObject 'RedHat' 'rhel' '8_6' 'latest';
    } elseif ($imageType -eq "SLES 12") {
        return Create-ComputeVMImageObject 'SUSE' 'sles-12-sp5' 'gen1' 'latest';
    } elseif ($imageType -eq "SLES 15") {
        return Create-ComputeVMImageObject 'SUSE' 'sles-15-sp4' 'gen1' 'latest';
    } else {
        return Create-ComputeVMImageObject 'SUSE' 'sles-12-sp5' 'gen1' 'latest';
    }
}

function Get-WindowsImage($imageType) {
	
    return Create-ComputeVMImageObject 'MicrosoftWindowsServer' 'WindowsServer' '2019-Datacenter' 'latest';
	
}

function GetWrongTestResult($TestResult, $searchFor, $level)
{
    $result = ""

    if (-not $level) {$level = 0}

    if ($TestResult.Result -eq $searchFor)
    {
        $result += [String]::new("`t", $level) + $TestResult.TestName + " is not expected. Actual result is " +  $TestResult.Result + [Environment]::NewLine
    }
    foreach ($tmpRes in $TestResult.PartialResults) 
    {
        $result += GetWrongTestResult $tmpRes $searchFor ($level+1)
    }

    return $result
}


function InitTest($testName) 
{
    Start-Transcript -Path "$($testName).log"
}

function Test-SkipIdentity
{
    InitTest "Test-SkipIdentity"

    Write-Host "Starting Test"
	$rgname = Get-CustomResourceGroupName
	try
    {
		#$loc = Get-LocationForNewExtension
		$loc = "southcentralus"
        Write-Host "Creating VM...."
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
	    Write-Host "Creating VM done"

		Write-Host "`tInstalling new extension - skipping identity"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -IsTest -SkipIdentity
        $vm = Get-azvm -ResourceGroupName $rgname -Name $vm.Name
        # VM should not have a system managed Identity
        Write-Host "Testing if Identity is null"
        Assert-Null $vm.Identity

        # Extension should not work since it does not have read access to Azure resources
        Write-Host "Checking health status of extension"
        Write-Host "Waiting a bit before asking for extension status"
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(60000)
        $status = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vm.Name -Name MonitorX64Windows -Status
        $healthStatusNode = select-xml -XPath "/metrics/metric[@category='config' and name='Provider Health Status']/value" -Xml ([xml] $status.SubStatuses.Message)
        Write-Host "Health status of extension is $($healthStatusNode.Node.InnerText)"
        Assert-AreEqual $healthStatusNode.Node.InnerText 0
	}
    finally
    {
        # Cleanup
        Write-Host "Test done. Cleaning up. Test Error (if any): $($_.Exception)"
        Clean-ResourceGroup $rgname
    }
}

function Test-UserIdentityOnlyWin
{
    InitTest "Test-UserIdentityOnlyWin"

    Write-Host "Starting Test"
	$rgname = Get-CustomResourceGroupName
	try
    {
		#$loc = Get-LocationForNewExtension
		$loc = "southcentralus"
        Write-Host "Creating VM...."
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
	    Write-Host "Creating VM done"

        Write-Host "`tInstalling new extension"
        $userIdentity = New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name aemident -Location $loc
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -IsTest -PathUserIdentity $userIdentity.Id
        $vm = Get-azvm -ResourceGroupName $rgname -Name $vm.Name

        # verify that the user assigned Identity is attached to the VM
        Write-Host "Testing if Identity is user assigned - current type is $($vm.Identity.Type)"
        Assert-AreEqual $vm.Identity.Type "UserAssigned"
        Assert-NotNull $vm.Identity.UserAssignedIdentities[$userIdentity.Id]

        # verify the extension is working
        Write-Host "Waiting a bit before asking for extension status"
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(60000)
        $status = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vm.Name -Name MonitorX64Windows -Status
        $healthStatusNode = select-xml -XPath "/metrics/metric[@category='config' and name='Provider Health Status']/value" -Xml ([xml] $status.SubStatuses.Message)
        Write-Host "Health status of extension is $($healthStatusNode.Node.InnerText)"
        Assert-AreEqual $healthStatusNode.Node.InnerText 8
	}
    finally
    {
        # Cleanup
        Write-Host "Test done. Cleaning up. Test Error (if any): $($_.Exception)"
        Clean-ResourceGroup $rgname
    }
}

function Test-UserIdentityOnlyLnx
{
    InitTest "Test-UserIdentityOnlyLnx"

    Write-Host "Starting Test"
	$rgname = Get-CustomResourceGroupName
	try
    {
		#$loc = Get-LocationForNewExtension
		$loc = "southcentralus"
        Write-Host "Creating VM...."
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "SLES 15"
	    Write-Host "Creating VM done"

        Write-Host "`tInstalling new extension"
        $userIdentity = New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name aemident -Location $loc
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -IsTest -PathUserIdentity $userIdentity.Id
        $vm = Get-azvm -ResourceGroupName $rgname -Name $vm.Name

        # verify that the user assigned Identity is attached to the VM
        Write-Host "Testing if Identity is user assigned - current type is $($vm.Identity.Type)"
        Assert-AreEqual $vm.Identity.Type "UserAssigned"
        Assert-NotNull $vm.Identity.UserAssignedIdentities[$userIdentity.Id]

        # verify the extension is working
        Write-Host "Waiting a bit before asking for extension status"
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(60000)
        $status = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vm.Name -Name MonitorX64Linux -Status
        $healthStatusNode = select-xml -XPath "/metrics/metric[@category='config' and name='Provider Health Status']/value" -Xml ([xml] $status.SubStatuses.Message)
        Write-Host "Health status of extension is $($healthStatusNode.Node.InnerText)"
        Assert-AreEqual $healthStatusNode.Node.InnerText 8
	}
    finally
    {
        # Cleanup
        Write-Host "Test done. Cleaning up. Test Error (if any): $($_.Exception)"
        Clean-ResourceGroup $rgname
    }
}

function Test-UserIdentityWithSystemLnx
{
    InitTest "Test-UserIdentityWithSystemLnx"

    Write-Host "Starting Test"
	$rgname = Get-CustomResourceGroupName
	try
    {
		#$loc = Get-LocationForNewExtension
		$loc = "southcentralus"
        Write-Host "Creating VM...."
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "SLES 15"
	    
        Write-Host "Creating VM done - setting system assigned"
        $vmUpd = Update-AzVM -ResourceGroupName $rgname -VM $vm -IdentityType SystemAssigned

        Write-Host "`tInstalling new extension"
        $userIdentity = New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name aemident -Location $loc
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -IsTest -PathUserIdentity $userIdentity.Id
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name

        # verify that the user assigned Identity is attached to the VM
        Write-Host "Testing if Identity is SystemAssignedUserAssigned - current type is $($vm.Identity.Type)"
        Assert-AreEqual $vm.Identity.Type "SystemAssignedUserAssigned"
        Assert-NotNull $vm.Identity.UserAssignedIdentities[$userIdentity.Id]

        # verify the extension is working
        Write-Host "Waiting a bit before asking for extension status"
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(60000)
        $status = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vm.Name -Name MonitorX64Linux -Status
        $healthStatusNode = select-xml -XPath "/metrics/metric[@category='config' and name='Provider Health Status']/value" -Xml ([xml] $status.SubStatuses.Message)
        Write-Host "Health status of extension is $($healthStatusNode.Node.InnerText)"
        Assert-AreEqual $healthStatusNode.Node.InnerText 8
	}
    finally
    {
        # Cleanup
        Write-Host "Test done. Cleaning up. Test Error (if any): $($_.Exception)"
        Clean-ResourceGroup $rgname
    }
}