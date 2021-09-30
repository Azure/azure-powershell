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

function Log($test, $message)
{
    Out-File -FilePath "$test.log" -Append -InputObject $message
}

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
	
	Write-Verbose "Test: Test with UserAssigned Identity -> Result must be SystemAssignedUserAssigned"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
		$ident = Create-IdentityForNewExtension -ResourceGroupName $rgname -TestName "Test-WithUserAssignedIdentity"
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		$vmUpd = Update-AzVM -ResourceGroupName $rgname -VM $vm -IdentityType UserAssigned -IdentityID $ident.Id
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name	
		$nul = Assert-AreEqual $vm.Identity.Type 'UserAssigned'

		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension -SetAccessToIndividualResources
	
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssignedUserAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-WithoutIdentity() {

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

		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension
		
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-WithSystemAssignedIdentity() {
	
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

		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-ExtensionReinstall() {

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
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'	

		Write-Verbose "`tRe-Installing new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-OldExtensionReinstall() {

	Write-Verbose "Test: old Extension re-install -> must work"
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

		Write-Verbose "`tInstalling old extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		Assert-OldExtension -ResourceGroupName $rgname -VMName $vm.Name

		Write-Verbose "`tRe-Installing old extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		Assert-OldExtension -ResourceGroupName $rgname -VMName $vm.Name
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-ExtensionDowngrade() {

	Write-Verbose "Test: Extension downgrade should still install the new extension"
	$rgname = Get-CustomResourceGroupName
	try
    {
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS -imageType "SLES 12"
	
		Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nul = Assert-AreEqual $vm.Extensions.Count 0 "VM Extensions count does not equal 0"
		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed"

		Write-Verbose "`tInstalling new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension

		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'

		Write-Verbose "`tInstalling without new parameter- should install new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
	
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'

        Write-Verbose "Test-ExtensionDowngrade test done"
	}
    finally
    {
        Write-Verbose "Test-ExtensionDowngrade cleaning resources"
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    Write-Verbose "Test-ExtensionDowngrade all done"
}

function Test-ExtensionUpgrade() {

	Write-Verbose "Test: Extension upgrade should fail"
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

		Write-Verbose "`tInstalling old extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name

		Assert-OldExtension -ResourceGroupName $rgname -VMName $vm.Name

		Write-Verbose "`tInstalling with new parameter- should fail"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension -ErrorVariable downgradeError -ErrorAction "SilentlyContinue"
        if ($downgradeError -and $downgradeError.Count -gt 0)
        {
		    Write-Verbose $downgradeError[0]
        }
		$nul = Assert-NotNull $downgradeError "Downgrade of extension should have failed!"
	
		Assert-OldExtension -ResourceGroupName $rgname -VMName $vm.Name
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-NewExtensionDiskAdd() {

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
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension -SetAccessToIndividualResources
		Assert-NewExtension -ResourceGroupName $rgname -VMName $vm.Name -IdentityType 'SystemAssigned'

		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vm.Name
		$nextLun = (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1)
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun $nextLun -CreateOption Empty -DiskSizeInGB 32 | Update-AzVM

		$result = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name
		Assert-True {-not $result.Result } "Test of extension was positiv but should have failed because of missing permissions to the added data disk"

		Write-Verbose "`tUpdating new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension -SetAccessToIndividualResources	
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
    Write-Verbose "Test: VM Extension with proxy and debug mode"
	$rgname = Get-CustomResourceGroupName
	try
    {
        $proxyURI = "https://proxyhost:8080"
		$loc = Get-LocationForNewExtension
		$vm = Create-AdvancedVM -rgname $rgname -loc $loc -useMD -vmsize Standard_E4s_v3 -stotype Premium_LRS
	
		Write-Verbose "`tInstalling new extension"
		Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vm.Name -InstallNewExtension -SetAccessToIndividualResources -ProxyURI $proxyURI -DebugExtension
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

function Test-AEMExtensionBasicWindowsWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $testResult.Result } (GetWrongTestResult $testResult $true)

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage -EnableWAD
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        $nul = Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        $nul = Assert-True { $testResult.Result }  (GetWrongTestResult $testResult $false)
        $nul = Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicWindows
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        $nul = Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        $nul = Assert-True { $testResult.Result }
        $nul = Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindowsWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedWindows"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2
        $vmname = $vm.Name
        Write-Verbose "Test-AEMExtensionAdvancedWindows: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $res.Result } (GetWrongTestResult $res $true)
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage -EnableWAD
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        $nul = Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-True { $res.Result } (GetWrongTestResult $res $false)
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindows
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedWindows"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2
        $vmname = $vm.Name
        Write-Verbose "Test-AEMExtensionAdvancedWindows: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $res.Result }
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        $nul = Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-True { $res.Result }
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedWindows: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindowsMD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedWindowsMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -useMD
        $vmname = $vm.Name
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $res.Result }
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        $nul = Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        $nul = Assert-True { ($extension.PublicSettings.Contains("osdisk.caching")) }
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-True { $res.Result }
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedWindowsMD: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedLinuxMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -useMD -imageType "SLES"
        $vmname = $vm.Name
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
        Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
        
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-False { $res.Result } "Test result is not false $out"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-True { $res.Result } "Test result is not false $out"
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicLinuxWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
       # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -imageType "SLES"
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage -EnableWAD
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        $nul = Assert-True { $testResult.Result }
        $nul = Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicLinux
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
       # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -imageType "SLES"
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        $nul = Assert-True { $testResult.Result }
        $nul = Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedLinux"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -imageType "SLES"
        $vmname = $vm.Name
        Write-Verbose "Test-AEMExtensionAdvancedLinux: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Write-Verbose ("Test-AEMExtensionAdvancedLinux: Test result " + $res.Result)
        $nul = Assert-False { $res.Result } (GetWrongTestResult $res $true)
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage -EnableWAD
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-True { $res.Result } (GetWrongTestResult $res $false)
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinux
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedLinux"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -imageType "SLES"
        $vmname = $vm.Name
        Write-Verbose "Test-AEMExtensionAdvancedLinux: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Write-Verbose ("Test-AEMExtensionAdvancedLinux: Test result " + $res.Result)
        $nul = Assert-False { $res.Result }
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $nul = Assert-True { $res.Result }
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedLinux: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD_E
{
    $rgname = Get-ComputeTestResourceName
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');

    try
    {
        Write-Verbose "Start the test Test-AEMExtensionAdvancedLinuxMD_E"
        # Setup

        $ultraSSDInfo = Get-AzComputeResourceSku | where { $_.LocationInfo.Location -eq $loc -and $_.Name -eq "UltraSSD_LRS" };
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD_E: Got UltraSSD info $($ultraSSDInfo)"

        $zoneparams = @{}
        if ($ultraSSDInfo) 
        {
            $zoneparams.Add("zone", $ultraSSDInfo.LocationInfo.Zones[0])    
        }

        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_E4s_v3' -stotype 'Premium_LRS' -nicCount 2 -useMD -imageType "SLES" @zoneparams
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD_E: VM created"
        $vmname = $vm.Name
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
        Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
        Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 16000 | Update-AzVM
        Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 32000 | Update-AzVM

        if ($ultraSSDInfo) 
        {
    
            $nul = Stop-AzVm -ResourceGroupName $rgname -Name $vmname -Force
            $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname
            $vm | update-azvm -UltraSSDEnabled $true
            $nul = Start-AzVm -ResourceGroupName $rgname -Name $vmname
            
            $ultraDisk = New-AzDiskConfig -SkuName UltraSSD_LRS -DiskSizeGB 512 -DiskIOPSReadWrite 5000 -DiskMBpsReadWrite 20 -CreateOption Empty -Location $loc -Zone $ultraSSDInfo.LocationInfo.Zones[0] `
                | New-AzDisk -ResourceGroupName $rgname -DiskName "ultrassd"
            
            Add-AzVMDataDisk -VM $vm  -ManagedDiskId $ultraDisk.Id -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Attach `
                | Update-AzVM
        }
        else 
        {
            Write-Verbose "Test-AEMExtensionAdvancedLinuxMD_E: not testing UltraSSD because the resource sku is not available"
        }
        
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-False { $res.Result } "Test result is not false $out"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-True { $res.Result } "Test result is not false $out"
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Write-Verbose "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
    }
    catch 
    {
        Write-Verbose "Exception while running test: $($_)"
        throw
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD_D
{
    $rgname = Get-ComputeTestResourceName
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');

    try
    {
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Start the test Test-AEMExtensionAdvancedLinuxMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_D2s_v3' -stotype 'Premium_LRS' -nicCount 2 -useMD -imageType "SLES"

        Log "Test-AEMExtensionAdvancedLinuxMD_D" "VM created"
        $vmname = $vm.Name
        $vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
        Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
        
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-False { $res.Result } "Test result is not false $out"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        $nul = Assert-NotNull $extension
        $nul = Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        $nul = Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        $nul = Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        $nul = Assert-NotNull $settings.cfg
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        $tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        $nul = Assert-True { $res.Result } "Test result is not false $out"
        $nul = Assert-True { ($res.PartialResults.Count -gt 0) }
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $nul = Assert-Null $extension "Extension is not null"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
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

function Create-IdentityForNewExtension($ResourceGroupName, $TestName) {
    $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($TestName, "crptestps");
	$ident = New-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $assetName

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
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize @zoneparams;
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
		return Create-ComputeVMImageObject 'RedHat' 'RHEL' '7.7' 'latest';
	} elseif ($imageType -eq "RHEL 8") {
		return Create-ComputeVMImageObject 'RedHat' 'RHEL' '8' 'latest';
	} elseif ($imageType -eq "SLES 12") {
		return Create-ComputeVMImageObject 'SUSE' 'SLES' '12-SP4' 'latest';
	} elseif ($imageType -eq "SLES 15") {
		return Create-ComputeVMImageObject 'SUSE' 'sles-15-sp1' 'gen1' 'latest';
	} else {
		return Create-ComputeVMImageObject 'SUSE' 'SLES' '12-SP4' 'latest';
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
