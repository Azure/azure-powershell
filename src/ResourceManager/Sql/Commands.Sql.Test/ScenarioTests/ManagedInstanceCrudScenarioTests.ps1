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
	 	
 	$managedInstanceName = Get-ManagedInstanceName
 	$version = "12.0"
 	$managedInstanceLogin = "dummylogin"
 	$managedInstancePassword = "Un53cuRE!"
 	$subnetId = "/subscriptions/ee5ea899-0791-418f-9270-77cd8273794b/resourceGroups/cl_pilot/providers/Microsoft.Network/virtualNetworks/cl_pilot/subnets/CLean"
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
 	$credentials = new-object System.Management.Automation.PSCredential($managedInstanceLogin, ($managedInstancePassword | ConvertTo-SecureString -asPlainText -Force)) 

 	try
 	{
 		# With SKU name specified
 		$job = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstanceName `
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

		# With edition and computeGeneration specified
 		$job = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Edition $edition -ComputeGeneration $computeGeneration  -AsJob
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
		$managedInstancePassword = "n3wc00lP@55w0rd"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 32

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance1 = Set-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		
		# Test piping
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
		# Test using parameters
		$managedInstancePassword = "n3wc00lP@55w0rd"
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$vCore = 32

		$secureString = ConvertTo-SecureString $managedInstancePassword -AsPlainText -Force

		$managedInstance1 = Update-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName `
			-AdministratorPassword $secureString -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore
		
		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		
		# Test piping
		$managedInstancePassword = "n3wc00lP@55w0rd!!!"
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
	$managedInstance2 = Create-ManagedInstanceForTest $rg
	$managedInstance3 = Create-ManagedInstanceForTest $rg1

	try
	{
		# Test using parameters
		$resp1 = Get-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.ManagedInstanceName $resp1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $resp1.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance1.AdministratorLogin $resp1.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $resp1.LicenseType
		Assert-AreEqual $managedInstance1.VCores $resp1.VCores
		Assert-AreEqual $managedInstance1.StorageSizeInGB $resp1.StorageSizeInGB
		
		# Test piping
		$resp2 = $managedInstance2 | Get-AzureRmSqlManagedInstance
		Assert-AreEqual $managedInstance2.ManagedInstanceName $resp2.ManagedInstanceName
		Assert-AreEqual $managedInstance2.SqlAdministratorLogin $resp2.SqlAdministratorLogin
		Assert-StartsWith ($managedInstance2.ManagedInstanceName + ".") $resp2.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance2.AdministratorLogin $resp2.AdministratorLogin
		Assert-AreEqual $managedInstance2.LicenseType $resp2.LicenseType
		Assert-AreEqual $managedInstance2.VCores $resp2.VCores
		Assert-AreEqual $managedInstance2.StorageSizeInGB $resp2.StorageSizeInGB
		
		$all = Get-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual 2 $all.Count

		# Test getting all managedInstances in all resource groups
		$all2 = Get-AzureRmSqlManagedInstance

		# It is possible that there were existing managedInstances in the subscription when the test was recorded, so make sure
		# that the managedInstances that we created are retrieved and ignore the other ones.
		($managedInstance1, $managedInstance2, $managedInstance3) | ForEach-Object { Assert-True {$_.ManagedInstanceName -in $all2.ManagedInstanceName} }
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
	$managedInstance1 = Create-ManagedInstanceForTest $rg
	$managedInstance2 = Create-ManagedInstanceForTest $rg

	try
	{
		# Test using parameters
		Remove-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance1.ManagedInstanceName -Force
		
		# Test piping
		$managedInstance2 | Remove-AzureRmSqlManagedInstance -Force

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
 	$managedInstanceLogin = "dummylogin"
 	$managedInstancePassword = "Un53cuRE!"
 	$subnetId = "/subscriptions/ee5ea899-0791-418f-9270-77cd8273794b/resourceGroups/cl_pilot/providers/Microsoft.Network/virtualNetworks/cl_pilot/subnets/CLean"
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
 	$credentials = new-object System.Management.Automation.PSCredential($managedInstanceLogin, ($managedInstancePassword | ConvertTo-SecureString -asPlainText -Force)) 

	try
	{
		$managedInstance1 = New-AzureRmSqlManagedInstance -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstanceName `
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