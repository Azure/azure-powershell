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
	Tests creating a managed instance
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateManagedInstance
{
	# Setup
    $rgName = "ps2110"
	$rg = Create-ResourceGroupWithName($rgName)
    $vnetName1 = "ps2255"
 	$managedInstanceName = Get-ManagedInstanceName
 	$version = "12.0"
 	$managedInstanceLogin = "dummylogin"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
 	$managedInstancePassword = "Un53cuRE!"
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
 	$credentials = new-object System.Management.Automation.PSCredential($managedInstanceLogin, ($managedInstancePassword | ConvertTo-SecureString -asPlainText -Force)) 

 	try
 	{
		# Setup VNET 
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $rg $vnetName1 $rg.Location
		$subnetId = $virtualNetwork1.Subnets[0].Id
	
 		# With SKU name specified
 		$job = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -AsJob 
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstanceLogin
		Assert-AreEqual $managedInstance1.SubnetId $subnetId
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
 		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName

		$edition = "GeneralPurpose"
		$computeGeneration = "Gen4"
		$dnsZonePartner = $managedInstance1.ResourceId
		$managedInstanceName = Get-ManagedInstanceName

		# With edition and computeGeneration specified
 		$job = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Edition $edition -ComputeGeneration $computeGeneration  -DnsZonePartner $dnsZonePartner  -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstanceLogin
		Assert-AreEqual $managedInstance1.SubnetId $subnetId
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
 		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
 	}
 	finally
 	{
 		Remove-ResourceGroupForTest $rg
 	}
}

<#
	.SYNOPSIS
	Tests setting a Managed Instance
	.DESCRIPTION
	SmokeTest
#>
function Test-SetManagedInstance
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Test using parameters
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance1 = Set-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		
		# Test using piping
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd!!!"
		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$licenseType = "LicenseIncluded"
		$storageSizeInGB = 96
		$vCore = 16

		$managedInstance2 = $managedInstance | Set-AzureRmSqlManagedInstance -AdministratorPassword $secureString `
			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore

		Assert-AreEqual $managedInstance2.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance2.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance2.LicenseType $licenseType
		Assert-AreEqual $managedInstance2.VCores $vCore
		Assert-AreEqual $managedInstance2.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance2.ManagedInstanceName + ".") $managedInstance2.FullyQualifiedDomainName

		# Test Set using InputObject
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd4321"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance3 = Set-AzureRmSqlManagedInstance -InputObject $managedInstance `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance3.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance3.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance3.LicenseType $licenseType
		Assert-AreEqual $managedInstance3.VCores $vCore
		Assert-AreEqual $managedInstance3.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance3.ManagedInstanceName + ".") $managedInstance3.FullyQualifiedDomainName

		# Test Set using ResourceId
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd4321"
		$licenseType = "BasePrice"
		$storageSizeInGB = 32
		$vCore = 16

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance4 = Set-AzureRmSqlManagedInstance -ResourceId $managedInstance.Id `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance4.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance4.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance4.LicenseType $licenseType
		Assert-AreEqual $managedInstance4.VCores $vCore
		Assert-AreEqual $managedInstance4.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance4.ManagedInstanceName + ".") $managedInstance4.FullyQualifiedDomainName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a Managed Instance
	.DESCRIPTION
	SmokeTest
#>
function Test-UpdateManagedInstance
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Test update using all parameters
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance1 = Update-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName

		# Test update using piping
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd1234!!!"
		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$licenseType = "LicenseIncluded"
		$storageSizeInGB = 96
		$vCore = 16

		$managedInstance2 = $managedInstance | Update-AzureRmSqlManagedInstance -AdministratorPassword $secureString `
			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore

		Assert-AreEqual $managedInstance2.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance2.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance2.LicenseType $licenseType
		Assert-AreEqual $managedInstance2.VCores $vCore
		Assert-AreEqual $managedInstance2.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance2.ManagedInstanceName + ".") $managedInstance2.FullyQualifiedDomainName

		# Test update using InputObject
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd4321"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance3 = Update-AzureRmSqlManagedInstance -InputObject $managedInstance `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance3.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance3.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance3.LicenseType $licenseType
		Assert-AreEqual $managedInstance3.VCores $vCore
		Assert-AreEqual $managedInstance3.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance3.ManagedInstanceName + ".") $managedInstance3.FullyQualifiedDomainName

		# Test update using ResourceId
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
		$managedInstancePassword = "n3wc00lP@55w0rd4321"
		$licenseType = "BasePrice"
		$storageSizeInGB = 32
		$vCore = 16

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance4 = Update-AzureRmSqlManagedInstance -ResourceId $managedInstance.Id `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance4.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance4.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance4.LicenseType $licenseType
		Assert-AreEqual $managedInstance4.VCores $vCore
		Assert-AreEqual $managedInstance4.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance4.ManagedInstanceName + ".") $managedInstance4.FullyQualifiedDomainName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a managedInstance
	.DESCRIPTION
	SmokeTest
#>
function Test-GetManagedInstance
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$rg1 = Create-ResourceGroupForTest
	$managedInstance1 = Create-ManagedInstanceForTest $rg
	$managedInstance2 = Create-ManagedInstanceForTest $rg1

	try
	{
		# Test using all parameters
		$resp1 = Get-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.ManagedInstanceName $resp1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $resp1.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance1.AdministratorLogin $resp1.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $resp1.LicenseType
		Assert-AreEqual $managedInstance1.VCores $resp1.VCores
		Assert-AreEqual $managedInstance1.StorageSizeInGB $resp1.StorageSizeInGB
		
		$all = Get-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual 1 $all.Count

		# Test getting all managedInstances in all resource groups
		$all2 = Get-AzureRmSqlManagedInstance

		# It is possible that there were existing managedInstances in the subscription when the test was recorded, so make sure
		# that the managedInstances that we created are retrieved and ignore the other ones.
		($managedInstance1, $managedInstance2) | ForEach-Object { Assert-True {$_.ManagedInstanceName -in $all2.ManagedInstanceName} }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		Remove-ResourceGroupForTest $rg1
	}
}

<#
	.SYNOPSIS
	Tests Removing a managedInstance
	.DESCRIPTION
	SmokeTest
#>
function Test-RemoveManagedInstance
{
	# Setup
	$rg = Create-ResourceGroupForTest

	try
	{
		# Test using parameters
		$managedInstance1 = Create-ManagedInstanceForTest $rg
		Remove-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -Force
		
		# Test using InputObject
		$managedInstance2 = Create-ManagedInstanceForTest $rg
		Remove-AzureRmSqlManagedInstance -InputObject $managedInstance2 -Force

		# Test using ResourceId
		$managedInstance3 = Create-ManagedInstanceForTest $rg
		Remove-AzureRmSqlManagedInstance -ResourceId $managedInstance3.Id -Force

		# Test piping
		$managedInstance4 = Create-ManagedInstanceForTest $rg
		$managedInstance4 | Remove-AzureRmSqlManagedInstance -Force

		$all = Get-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a managedInstance with an identity
#>
function Test-CreateManagedInstanceWithIdentity
{
	# Setup
	$rg = Create-ResourceGroupForTest
	 	
 	$managedInstanceName = Get-ManagedInstanceName
 	$version = "12.0"
 	$managedInstanceLogin = "login"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
 	$managedInstancePassword = "Un5!"
 	$subnetId = "/subscriptions/ee5ea899-0791-418f-9270-77cd8273794b/resourceGroups/cl_one/providers/Microsoft.Network/virtualNetworks/cl_initial/subnets/CooL"
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
 	$credentials = new-object System.Management.Automation.PSCredential($managedInstanceLogin, ($managedInstancePassword | ConvertTo-SecureString -asPlainText -Force)) 

	try
	{
		$managedInstance1 = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -AssignIdentity

		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Identity.Type SystemAssigned
		Assert-NotNull $managedInstance1.Identity.PrincipalId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Create a virtual network
#>
function CreateAndGetVirtualNetworkForManagedInstance ($resourceGroup, $vnetName, $location = "westcentralus")
{
	$vNetAddressPrefix = "10.0.0.0/16"
	$defaultSubnetName = "default"
	$defaultSubnetAddressPrefix = "10.0.0.0/24"

	$virtualNetwork = New-AzureRmVirtualNetwork `
						  -ResourceGroupName $resourceGroup.ResourceGroupName `
						  -Location $location `
						  -Name $vNetName `
						  -AddressPrefix $vNetAddressPrefix

	$subnetConfig = Add-AzureRmVirtualNetworkSubnetConfig `
						  -Name $defaultSubnetName `
						  -AddressPrefix $defaultSubnetAddressPrefix `
						  -VirtualNetwork $virtualNetwork

	$virtualNetwork | Set-AzureRmVirtualNetwork

	$routeTableMiManagementService = New-AzureRmRouteTable `
						  -Name 'myRouteTableMiManagementService' `
						  -ResourceGroupName $resourceGroup.ResourceGroupName `
						  -location $location

	Set-AzureRmVirtualNetworkSubnetConfig `
						  -VirtualNetwork $virtualNetwork `
						  -Name $defaultSubnetName `
						  -AddressPrefix $defaultSubnetAddressPrefix `
						  -RouteTable $routeTableMiManagementService | `
						Set-AzureRmVirtualNetwork

	Get-AzureRmRouteTable `
						  -ResourceGroupName $resourceGroup.ResourceGroupName `
						  -Name "myRouteTableMiManagementService" `
						  | Add-AzureRmRouteConfig `
						  -Name "ToManagedInstanceManagementService" `
						  -AddressPrefix 0.0.0.0/0 `
						  -NextHopType "Internet" `
						 | Set-AzureRmRouteTable
				
	$getVnet = Get-AzureRmVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroup.ResourceGroupName
	
	return $getVnet
}