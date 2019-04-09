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
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "CooL"

	$managedInstanceName = Get-ManagedInstanceName
 	$version = "12.0"
 	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
	$collation = "Serbian_Cyrillic_100_CS_AS"
	$proxyOverride = "Proxy"

 	try
 	{
		# Setup VNET 
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

 		# With SKU name specified
 		$job = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -Collation $collation `
			-PublicDataEndpointEnabled -ProxyOverride $proxyOverride -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $credentials.Username
		Assert-AreEqual $managedInstance1.SubnetId $subnetId
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-AreEqual $managedInstance1.Collation $collation
		Assert-AreEqual $managedInstance1.PublicDataEndpointEnabled $true
		Assert-AreEqual $managedInstance1.ProxyOverride $proxyOverride
 		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName

		$edition = "GeneralPurpose"
		$computeGeneration = "Gen4"
		$managedInstanceName = Get-ManagedInstanceName

		# With edition and computeGeneration specified
 		$job = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Edition $edition -ComputeGeneration $computeGeneration  -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $credentials.Username
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
	$vnetName = "cl_initial"
	$subnetName = "CooL"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	try
	{
		# Test using parameters
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$managedInstance1 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Force
		
		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		
		# Test using piping
		$credentials = Get-ServerCredential

		$licenseType = "LicenseIncluded"
		$storageSizeInGB = 96
		$vCore = 16

		$managedInstance2 = $managedInstance | Set-AzSqlInstance -AdministratorPassword $credentials.Password `
			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Force

		Assert-AreEqual $managedInstance2.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance2.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance2.LicenseType $licenseType
		Assert-AreEqual $managedInstance2.VCores $vCore
		Assert-AreEqual $managedInstance2.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance2.ManagedInstanceName + ".") $managedInstance2.FullyQualifiedDomainName

		# Test Set using InputObject
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 8

		$managedInstance3 = Set-AzSqlInstance -InputObject $managedInstance `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Force
		
		Assert-AreEqual $managedInstance3.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance3.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance3.LicenseType $licenseType
		Assert-AreEqual $managedInstance3.VCores $vCore
		Assert-AreEqual $managedInstance3.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance3.ManagedInstanceName + ".") $managedInstance3.FullyQualifiedDomainName

		# Test Set using ResourceId
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 32
		$vCore = 16
		$publicDataEndpointEnabled = $true
		$proxyOverride = "Proxy"

		$managedInstance4 = Set-AzSqlInstance -ResourceId $managedInstance.Id `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore `
			-PublicDataEndpointEnabled $publicDataEndpointEnabled -ProxyOverride $proxyOverride -Force
		
		Assert-AreEqual $managedInstance4.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance4.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance4.LicenseType $licenseType
		Assert-AreEqual $managedInstance4.VCores $vCore
		Assert-AreEqual $managedInstance4.StorageSizeInGB $storageSizeInGB
		Assert-AreEqual $managedInstance4.PublicDataEndpointEnabled $publicDataEndpointEnabled
		Assert-AreEqual $managedInstance4.ProxyOverride $proxyOverride
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
	$vnetName = "cl_initial"
	$subnetName = "CooL"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	$managedInstance1 = Create-ManagedInstanceForTest $rg $subnetId
	$managedInstance2 = Create-ManagedInstanceForTest $rg1 $subnetId

	try
	{
		# Test using all parameters
		$resp1 = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.ManagedInstanceName $resp1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $resp1.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance1.AdministratorLogin $resp1.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $resp1.LicenseType
		Assert-AreEqual $managedInstance1.VCores $resp1.VCores
		Assert-AreEqual $managedInstance1.StorageSizeInGB $resp1.StorageSizeInGB
		
		$all = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name *
		Assert-AreEqual 1 $all.Count

		# Test getting all managedInstances in all resource groups
		$all2 = Get-AzSqlInstance -ResourceGroupName *

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
	$vnetName = "cl_initial"
	$subnetName = "CooL"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

	try
	{
		# Test using parameters
		$managedInstance1 = Create-ManagedInstanceForTest $rg $subnetId
		Remove-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -Force
		
		# Test using InputObject
		$managedInstance2 = Create-ManagedInstanceForTest $rg $subnetId
		Remove-AzSqlInstance -InputObject $managedInstance2 -Force

		# Test using ResourceId
		$managedInstance3 = Create-ManagedInstanceForTest $rg $subnetId
		Remove-AzSqlInstance -ResourceId $managedInstance3.Id -Force

		# Test piping
		$managedInstance4 = Create-ManagedInstanceForTest $rg $subnetId
		$managedInstance4 | Remove-AzSqlInstance -Force

		$all = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName
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
	$vnetName = "cl_initial"
	$subnetName = "CooL"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

 	$managedInstanceName = Get-ManagedInstanceName
 	$version = "12.0"
 	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"

	try
	{
		$managedInstance1 = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
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