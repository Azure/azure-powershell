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

# Location to use for provisioning test managed instances
$instanceLocation = "eastus"

<#
	.SYNOPSIS
	Tests creating a managed instance
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateManagedInstance
{
	$rg = Create-ResourceGroupForTest

	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedInstanceName = Get-ManagedInstanceName

 	$version = "12.0"
 	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 4
 	$skuName = "GP_Gen5"
	$collation = "Serbian_Cyrillic_100_CS_AS"
	$timezoneId = "Central Europe Standard Time"
	$proxyOverride = "Proxy"
	$backupStorageRedundancy = "Local"
	$authenticationMetadata = "Paired"
	$defaultAuthenticationMetadata = "AzureAD"

 	try
 	{
 		# With SKU name specified
 		$job = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -Collation $collation `
			-TimezoneId $timezoneId -PublicDataEndpointEnabled -ProxyOverride $proxyOverride -BackupStorageRedundancy $backupStorageRedundancy -AuthenticationMetadata $authenticationMetadata  -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $credentials.Username
		Assert-AreEqual $managedInstance1.SubnetId $defaultParams.subnet
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-AreEqual $managedInstance1.Collation $collation
		Assert-AreEqual $managedInstance1.TimezoneId $timezoneId
		Assert-AreEqual $managedInstance1.PublicDataEndpointEnabled $true
		Assert-AreEqual $managedInstance1.ProxyOverride $proxyOverride
		Assert-AreEqual $managedInstance1.RequestedBackupStorageRedundancy $backupStorageRedundancy
		Assert-AreEqual $managedInstance1.CurrentBackupStorageRedundancy $backupStorageRedundancy
		Assert-AreEqual $managedInstance1.BackupStorageRedundancy $backupStorageRedundancy
 		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		Assert-NotNull $managedInstance1.DnsZone
		Assert-AreEqual $managedInstance1.AuthenticationMetadata $authenticationMetadata

		$edition = "GeneralPurpose"
		$computeGeneration = "Gen5"
		$managedInstanceName = Get-ManagedInstanceName
		$dnsZonePartner = $managedInstance1.ResourceId
        $originalDnsZone = $managedInstance1.DnsZone

		# With edition and computeGeneration specified
 		$job = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -Edition $edition -ComputeGeneration $computeGeneration  -DnsZonePartner $dnsZonePartner  -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.Location $rg.Location
		Assert-AreEqual $managedInstance1.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $managedInstance1.Sku.Name $skuName
 		Assert-AreEqual $managedInstance1.AdministratorLogin $credentials.Username
		Assert-AreEqual $managedInstance1.SubnetId $defaultParams.subnet
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $vCore
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance1.DnsZone $originalDnsZone

		## Get-AzSqlInstance test ##
		############################

		# Test using all parameters
		$resp1 = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.ManagedInstanceName $resp1.ManagedInstanceName
		Assert-AreEqual $managedInstance1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $resp1.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance1.AdministratorLogin $resp1.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $resp1.LicenseType
		Assert-AreEqual $managedInstance1.VCores $resp1.VCores
		Assert-AreEqual $managedInstance1.StorageSizeInGB $resp1.StorageSizeInGB
		Assert-AreEqual $false $managedInstance1.ZoneRedundant
		Assert-AreEqual $managedInstance1.AuthenticationMetadata $defaultAuthenticationMetadata

		$all = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name *
		Assert-AreEqual 2 $all.Count
 	}
 	finally
 	{
		Remove-ResourceGroupForTest $rg -AsJob
 	}
}

<#
	.SYNOPSIS
	Tests creating a managed instance while using Hermes related parameters
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateManagedInstance-HermesTesting
{
	$defaultParams = Get-DefaultManagedInstanceParametersHermesTesting
	$credentials = Get-ServerCredential
	$vCore = 8
	$storageSizeInGB = 32

	# Tests with SKU name specified and with true IsGeneralPurposeV2 specified
	$managedInstanceName = "createmanagedinstance-hermestesting-he"
	$skuName = "GP_Gen5"
	$isGeneralPurposeV2 = $true
	$storageIOps = 2000

	$job = New-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-Location $defaultParams.location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
		-StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName `
		-IsGeneralPurposeV2 $isGeneralPurposeV2 -StorageIOps $storageIOps -AsJob
	$job | Wait-Job
	$managedInstance = $job.Output

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps

	# Tests with SKU name specified and without IsGeneralPurposeV2 specified
	$managedInstanceName = "createmanagedinstance-hermestesting-gp-noflag"
	$skuName = "GP_Gen5"
	$isGeneralPurposeV2 = $false
	$storageIOps = $null

	$job = New-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-Location $defaultParams.location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
		-StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -AsJob
	$job | Wait-Job
	$managedInstance = $job.Output

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps

	# Tests with SKU name specified and with false IsGeneralPurposeV2 specified
	$managedInstanceName = "createmanagedinstance-hermestesting-gp-falseflag"
	$skuName = "GP_Gen5"
	$isGeneralPurposeV2 = $false
	$storageIOps = $null

	$job = New-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-Location $defaultParams.location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
		-StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName `
		-IsGeneralPurposeV2 $isGeneralPurposeV2 -AsJob
	$job | Wait-Job
	$managedInstance = $job.Output

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps
}

<#
	.SYNOPSIS
	Tests setting a Managed Instance while using Hermes related parameters
	.DESCRIPTION
	SmokeTest
#>
function Test-SetManagedInstance-HermesTesting
{
	$defaultParams = Get-DefaultManagedInstanceParametersHermesTesting
	$credentials = Get-ServerCredential
	$managedInstanceName = "setmanagedinstance-hermestesting"
	$vCore = 8

	# Create GP MI
	$skuName = "GP_Gen5"
	$isGeneralPurposeV2 = $false
	$storageSizeInGB = 32
	$storageIOps = $null

	$job = New-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-Location $defaultParams.location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
		-StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -AsJob
	$job | Wait-Job
	$managedInstance = $job.Output

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps

	# Update to HE MI
	$edition = "GeneralPurpose"
	$computeGeneration = "Gen5"
	$isGeneralPurposeV2 = $true
	$storageSizeInGB = 64
	$storageIOps = 2000

	$managedInstance = Set-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-StorageSizeInGB $storageSizeInGB -Edition $edition -ComputeGeneration $computeGeneration `
		-IsGeneralPurposeV2 $isGeneralPurposeV2 -StorageIOps $storageIOps -Force

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps

	# Update to GP MI
	$edition = "GeneralPurpose"
	$computeGeneration = "Gen5"
	$isGeneralPurposeV2 = $false
	$storageSizeInGB = 64
	$storageIOps = $null

	$managedInstance = Set-AzSqlInstance -ResourceGroupName $defaultParams.rg -Name $managedInstanceName `
		-StorageSizeInGB $storageSizeInGB -Edition $edition -ComputeGeneration $computeGeneration `
		-IsGeneralPurposeV2 $isGeneralPurposeV2 -Force

	Assert-AreEqual $managedInstance.ManagedInstanceName $managedInstanceName
	Assert-AreEqual $managedInstance.Sku.Name $skuName
	Assert-AreEqual $managedInstance.IsGeneralPurposeV2 $isGeneralPurposeV2
	Assert-AreEqual $managedInstance.VCores $vCore
	Assert-AreEqual $managedInstance.StorageSizeInGB $storageSizeInGB
	Assert-AreEqual $managedInstance.StorageIOps $storageIOps
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
	$vCore = 4

	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Test using parameters
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 64
		$targetSubnetResourceId = "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG/providers/Microsoft.Network/virtualNetworks/vnet-mi-tooling/subnets/ManagedInstance2"
		$generalPurpose = "GeneralPurpose"
		$businessCritical = "BusinessCritical"
		$authenticationMetadata = "Windows"

		$managedInstance1 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Force -AuthenticationMetadata $authenticationMetadata

		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance1.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance1.LicenseType $licenseType
		Assert-AreEqual $managedInstance1.VCores $managedInstance.VCores
		Assert-AreEqual $managedInstance1.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance1.ManagedInstanceName + ".") $managedInstance1.FullyQualifiedDomainName]
		Assert-AreEqual $managedInstance1.AuthenticationMetadata $authenticationMetadata

		# Test using piping
		$credentials = Get-ServerCredential

		$licenseType = "LicenseIncluded"
		$storageSizeInGB = 96

		$managedInstance2 = $managedInstance | Set-AzSqlInstance -AdministratorPassword $credentials.Password `
			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Force

		Assert-AreEqual $managedInstance2.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance2.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance2.LicenseType $licenseType
		Assert-AreEqual $managedInstance2.VCores $managedInstance.VCores
		Assert-AreEqual $managedInstance2.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance2.ManagedInstanceName + ".") $managedInstance2.FullyQualifiedDomainName

		# Test Set using InputObject
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 64

		$managedInstance3 = Set-AzSqlInstance -InputObject $managedInstance `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Force

		Assert-AreEqual $managedInstance3.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance3.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance3.LicenseType $licenseType
		Assert-AreEqual $managedInstance3.VCores $managedInstance.VCores
		Assert-AreEqual $managedInstance3.StorageSizeInGB $storageSizeInGB
		Assert-StartsWith ($managedInstance3.ManagedInstanceName + ".") $managedInstance3.FullyQualifiedDomainName

		# Test Set using ResourceId
		$credentials = Get-ServerCredential
		$licenseType = "BasePrice"
		$storageSizeInGB = 96
		$publicDataEndpointEnabled = $true
		$proxyOverride = "Proxy"

		$managedInstance4 = Set-AzSqlInstance -ResourceId $managedInstance.Id `
			-AdministratorPassword $credentials.Password -LicenseType $licenseType -StorageSizeInGB $storageSizeInGB `
			-PublicDataEndpointEnabled $publicDataEndpointEnabled -ProxyOverride $proxyOverride -Force

		Assert-AreEqual $managedInstance4.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance4.AdministratorLogin $managedInstance.AdministratorLogin
		Assert-AreEqual $managedInstance4.LicenseType $licenseType
		Assert-AreEqual $managedInstance4.VCores $managedInstance.VCores
		Assert-AreEqual $managedInstance4.StorageSizeInGB $storageSizeInGB
		Assert-AreEqual $managedInstance4.PublicDataEndpointEnabled $publicDataEndpointEnabled
		Assert-StartsWith ($managedInstance4.ManagedInstanceName + ".") $managedInstance4.FullyQualifiedDomainName

		# Test edition change using Edition
		$credentials = Get-ServerCredential

		$managedInstance6 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -Edition $businessCritical -Force

		Assert-AreEqual $managedInstance6.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance6.AdministratorLogin $managedInstance4.AdministratorLogin
		Assert-AreEqual $managedInstance6.VCores $vCore
		Assert-AreEqual $managedInstance6.StorageSizeInGB $managedInstance4.StorageSizeInGB
		Assert-AreEqual $managedInstance6.Sku.Tier $businessCritical
		Assert-AreEqual $managedInstance6.Sku.Family $managedInstance4.Sku.Family
		Assert-StartsWith ($managedInstance6.ManagedInstanceName + ".") $managedInstance6.FullyQualifiedDomainName

		# Test cross-subnet update SLO using subnetId
		$managedInstance7 = Set-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName -Edition $generalPurpose -SubnetId $targetSubnetResourceId -Force

		Assert-AreEqual $managedInstance7.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance7.AdministratorLogin $managedInstance6.AdministratorLogin
		Assert-AreEqual $managedInstance7.VCores $vCore
		Assert-AreEqual $managedInstance7.StorageSizeInGB $managedInstance6.StorageSizeInGB
		Assert-AreEqual $managedInstance7.Sku.Tier $generalPurpose
		Assert-AreEqual $managedInstance7.Sku.Family $managedInstance6.Sku.Family
		Assert-StartsWith ($managedInstance7.ManagedInstanceName + ".") $managedInstance6.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance7.SubnetId $targetSubnetResourceId

		# Test service principal update
		$servicePrincipalType = "SystemAssigned"

		$managedInstance8 = Set-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName -ServicePrincipalType $servicePrincipalType -Force

		Assert-AreEqual $managedInstance8.ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual $managedInstance8.AdministratorLogin $managedInstance6.AdministratorLogin
		Assert-AreEqual $managedInstance8.VCores $vCore
		Assert-AreEqual $managedInstance8.StorageSizeInGB $managedInstance6.StorageSizeInGB
		Assert-AreEqual $managedInstance8.Sku.Tier $generalPurpose
		Assert-AreEqual $managedInstance8.Sku.Family $managedInstance6.Sku.Family
		Assert-StartsWith ($managedInstance8.ManagedInstanceName + ".") $managedInstance6.FullyQualifiedDomainName
		Assert-AreEqual $managedInstance8.SubnetId $targetSubnetResourceId
		Assert-AreEqual $managedInstance8.ServicePrincipal.Type $servicePrincipalType
		Assert-AreEqual $managedInstance8.Identity.Type $managedInstance6.Identity.Type

		# Test zone redundant update SLO. Since the feature is still not rolled-out, the operation should fail.
		try
		{
			Set-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName -ZoneRedundant -Force
		}
		catch
		{
			$ErrorMsg = $_.Exception.Message
			Assert-AreEqual True $ErrorMsg.Contains("The managed instance cannot be updated to a multi-availability zone")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg -AsJob
	}
}

function Test-SetRedundancy
{
	# Setup
	$rg = Create-ResourceGroupForTest

	try
	{
		$bsr = "Geo"

		# Test using parameters
		$managedInstance1 = Create-ManagedInstanceForTest $rg
		Assert-AreEqual $managedInstance1.CurrentBackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance1.BackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance1.RequestedBackupStorageRedundancy $bsr
		
		$bsr = "Local"
		$managedInstance2 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -BackupStorageRedundancy $bsr -Force

		Assert-AreEqual $managedInstance2.CurrentBackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance2.BackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance2.RequestedBackupStorageRedundancy $bsr

		$bsr = "Geo"
		$managedInstance3 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -BackupStorageRedundancy $bsr -Force

		Assert-AreEqual $managedInstance3.CurrentBackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance3.BackupStorageRedundancy $bsr
		Assert-AreEqual $managedInstance3.RequestedBackupStorageRedundancy $bsr
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
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
	$vCore = 4

	try
	{
		# Test using parameters
		$managedInstance1 = Create-ManagedInstanceForTest $rg
		Remove-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -Force

		# Test using InputObject
		$managedInstance2 = Create-ManagedInstanceForTest $rg
		Remove-AzSqlInstance -InputObject $managedInstance2 -Force

		# Test using ResourceId
		$managedInstance3 = Create-ManagedInstanceForTest $rg
		Remove-AzSqlInstance -ResourceId $managedInstance3.Id -Force

		# Test piping
		$managedInstance4 = Create-ManagedInstanceForTest $rg
		$managedInstance4 | Remove-AzSqlInstance -Force

		# Test -AsJob
		$managedInstance5 = Create-ManagedInstanceForTest $rg
		$job = Remove-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance5.ManagedInstanceName -Force -AsJob
		$job | Wait-Job

		Assert-AreEqual "Completed" $job.State
		Assert-AreEqual "Remove-AzSqlInstance" $job.Command

		$all = Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-CreateManagedInstanceWithIdentity
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedInstanceName = Get-ManagedInstanceName
	$credentials = Get-ServerCredential

	try
	{
		$managedInstance1 = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
  			-StorageSizeInGB $defaultParams.storageSizeInGb -Vcore $defaultParams.vCore `
			-SkuName $defaultParams.sku -AssignIdentity

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
	Tests creating a managed instance with MinimalTlsVersion
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateUpdateManagedInstanceWithMinimalTlsVersion
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedInstanceName = Get-ManagedInstanceName
 	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 64
 	$vCore = 4
 	$skuName = "GP_Gen5"
	$collation = "Serbian_Cyrillic_100_CS_AS"
	$timezoneId = "Central Europe Standard Time"
	$proxyOverride = "Proxy"
	$tls1_2 = "1.2"
	$tls1_1 = "1.1"

 	try
 	{
 		# With SKU name specified
 		$job = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
 			-Location $defaultParams.location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -Collation $collation `
			-TimezoneId $timezoneId -PublicDataEndpointEnabled -ProxyOverride $proxyOverride -MinimalTlsVersion $tls1_2 -AsJob
 		$job | Wait-Job
 		$managedInstance1 = $job.Output

 		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.MinimalTlsVersion $tls1_2

		# Wait until create managed instance operation is completed.
		Wait-Seconds 30

		$managedInstance2 = Set-AzSqlInstance -MinimalTlsVersion $tls1_1 -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName -Force

		Assert-AreEqual $managedInstance2.MinimalTlsVersion $tls1_1
	}
	finally
	{
		Remove-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName -Force
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a managed instance with MaintenanceConfigurationId
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateManagedInstanceWithMaintenanceConfigurationId
{
	# Setup
	$location = "westeurope"
	$rgName = "fmwtestweu"
	$subnetId = "/subscriptions/a295933f-f7f5-4994-a109-8fa51241a5d6/resourceGroups/fmwtestweu/providers/Microsoft.Network/virtualNetworks/vnet-fmwnopolicy/subnets/ManagedInstance"

	$managedInstanceName = Get-ManagedInstanceName
	$credentials = Get-ServerCredential
	$licenseType = "BasePrice"
	$storageSizeInGB = 32
	$vCore = 8
	$skuName = "GP_Gen5"
	$maintenanceConfigurationId = Get-PublicMaintenanceConfigurationName $location "MI_1"
	$expectedMaintenanceConfigurationValue = Get-PublicMaintenanceConfigurationId $location "MI_1"


	try
	{
		$managedInstance1 = New-AzSqlInstance -ResourceGroupName $rgName -Name $managedInstanceName `
			-Location $location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName -AssignIdentity `
			-MaintenanceConfigurationId $maintenanceConfigurationId

		Assert-AreEqual $managedInstance1.ManagedInstanceName $managedInstanceName
		Assert-AreEqual $managedInstance1.MaintenanceConfigurationId $expectedMaintenanceConfigurationValue
	}
	finally
	{
		Remove-AzSqlInstance -ResourceGroupName $rgName -Name $managedInstanceName -Force
	}
}

<#
	.SYNOPSIS
	Tests creating a managed instance with MultiAz enabled
	.DESCRIPTION
	SmokeTest
#>
function Test-CreateManagedInstanceWithMultiAzEnabled
{
# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "vnet-portal-testing"
	$subnetName = "ManagedInstance"
	$vnetRgName = "portalrg"
	$vCore = 4
	$managedInstanceName = Get-ManagedInstanceName
	$credentials = Get-ServerCredential
	$skuName = "GP_Gen5"
	$defaultParams = Get-DefaultManagedInstanceParameters

	try
	{
		$managedInstance1 = New-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstanceName `
			-Location $rg.Location -AdministratorCredential $credentials -SubnetId $defaultParams.subnet `
			-Vcore $vCore -SkuName $skuName -ZoneRedundant -AssignIdentity
	}
	catch
	{
		$ErrorMsg = $_.Exception.Message
		Assert-AreEqual True $ErrorMsg.Contains("ZoneRedundant feature is not supported for the selected service tier.")
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Assert-ManagedInstanceCreationStarted($rg, $mi)
{
		# Get all operations on managed instance.
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg -ManagedInstanceName $mi
		
		while($all.Count -eq 0) {
			Wait-Seconds 2
			$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg -ManagedInstanceName $mi
		}
		# Verify that create operation has finished.
		$firstOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg -ManagedInstanceName $mi -Name ($all | Select-Object -index 0).Name
		Assert-AreEqual $firstOperation.OperationFriendlyName "CREATE MANAGED SERVER"
}

function CancelOperation($rg, $miName)
{
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg -ManagedInstanceName $miName

		$operation = $all | Select-Object -index 0
		while($operation.IsCancellable -eq $false) {
			Wait-Seconds 2
			$operation = Get-AzSqlInstanceOperation -ResourceGroupName $rg -ManagedInstanceName $miName -Name $operation.Name 
		}

		Stop-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name $operation.Name -Force
}