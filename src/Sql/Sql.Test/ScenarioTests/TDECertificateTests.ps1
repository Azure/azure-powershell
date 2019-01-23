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
	Tests adding TDE certificates to sql server with default parameter set and no password
#>

<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
$samplePrivateBlobNoPassword = "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"
<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
$samplePrivateBlobWithPassword = "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"
<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
$password = "pGFD4bb925DGvbd2439587y"
$securePrivateBlobNoPassword = $samplePrivateBlobNoPassword | ConvertTo-SecureString -AsPlainText -Force
$securePrivateBlobWithPassword = $samplePrivateBlobWithPassword | ConvertTo-SecureString -AsPlainText -Force
$securePassword = $password | ConvertTo-SecureString -AsPlainText -Force
$secureEmptyPassword = (new-object System.Security.SecureString)
$location = "WestEurope"
$exceptionHeader = "##### Following exception occurred causing test failure #####"
$mangedInstanceRg = "MlAndzic_RG"
$managedInstanceName = "midemoinstancebc"

function Test-AddTdeCertificateForSqlServerDefaultParameterSetNoPassword
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	try
	{
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		Add-AzSqlManagedInstanceTransparentDataEncryptionCertificate `
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
		Add-AzSqlManagedInstanceTransparentDataEncryptionCertificate `
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
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		Add-AzSqlServerTransparentDataEncryptionCertificate `
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
		$server | Add-AzSqlServerTransparentDataEncryptionCertificate `
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