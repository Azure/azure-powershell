﻿# ----------------------------------------------------------------------------------
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
	Tests adding TDE certificates to sql server with default parameter set and no password
#>

$samplePrivateBlobNoPassword = "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"
$samplePrivateBlobWithPassword = "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"
$password = "AE"
$securePrivateBlobNoPassword = $samplePrivateBlobNoPassword | ConvertTo-SecureString -AsPlainText -Force
$securePrivateBlobWithPassword = $samplePrivateBlobWithPassword | ConvertTo-SecureString -AsPlainText -Force
$securePassword = $password | ConvertTo-SecureString -AsPlainText -Force
$secureEmptyPassword = (new-object System.Security.SecureString)
$location = "WestCentralUS"
$exceptionHeader = "##### Following exception occurred causing test failure #####"
$mangedInstanceRg = "MlAndzic_RG"
$managedInstanceName = "midemoinstance"

function Test-AddTdeCertificateForSqlServerDefaultParameterSetNoPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName `
			-PrivateBlob $securePrivateBlobNoPassword `
			-Password $secureEmptyPassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with default parameter set and password
#>
function Test-AddTdeCertificateForSqlServerDefaultParameterSetWithPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName `
			-PrivateBlob $securePrivateBlobWithPassword `
			-Password $securePassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to managed instance with default parameter set and no password
#>
function Test-AddTdeCertificateForManagedInstanceDefaultParameterSetNoPassword
{
	try
	{
		Add-AzureRmSqlManagedInstanceTransparentDataEncryptionCertificate `
			-ResourceGroupName $mangedInstanceRg `
			-ManagedInstanceName $managedInstanceName `
			-PrivateBlob $securePrivateBlobNoPassword `
			-Password $secureEmptyPassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to managed instance with default parameter set and password
#>
function Test-AddTdeCertificateForManagedInstanceDefaultParameterSetWithPassword
{
	try
	{
		Add-AzureRmSqlManagedInstanceTransparentDataEncryptionCertificate `
			-ResourceGroupName $mangedInstanceRg `
			-ManagedInstanceName $managedInstanceName `
			-PrivateBlob $securePrivateBlobWithPassword `
			-Password $securePassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with InputObject parameter set and password
#>
function Test-AddTdeCertificateForSqlServerInputObjectParameterSetWithPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-SqlServer $server `
			-PrivateBlob $securePrivateBlobWithPassword `
			-Password $securePassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with ResourceId parameter set and password
#>
function Test-AddTdeCertificateForSqlServerResourceIdParameterSetWithPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-SqlServerResourceId $server.ResourceId `
			-PrivateBlob $securePrivateBlobWithPassword `
			-Password $securePassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with InputObject parameter set and no password
#>
function Test-AddTdeCertificateForSqlServerInputObjectParameterSetNoPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-SqlServer $server `
			-PrivateBlob $securePrivateBlobNoPassword `
			-Password $secureEmptyPassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with ResourceId parameter set and no password
#>
function Test-AddTdeCertificateForSqlServerResourceIdParameterSetNoPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-SqlServerResourceId $server.ResourceId `
			-PrivateBlob $securePrivateBlobNoPassword `
			-Password $secureEmptyPassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding TDE certificates to sql server with piping
#>
function Test-AddTdeCertificateForSqlServerWithPiping
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		$server | Add-AzureRmSqlServerTransparentDataEncryptionCertificate `
			-PrivateBlob $securePrivateBlobNoPassword `
			-Password $secureEmptyPassword
	}
	Catch{
		Write-Debug $exceptionHeader
		Write-Debug  $_.Exception.Message
		#throw if we catch an exception
		Assert-AreEqual $true $false
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}