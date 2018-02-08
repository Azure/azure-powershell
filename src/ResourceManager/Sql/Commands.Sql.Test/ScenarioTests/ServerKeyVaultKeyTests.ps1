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
	Tests creating a server key vault key
#>
function Test-AddServerKeyVaultKey
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$rg = Create-ServerKeyVaultKeyTestEnvironment $params

	try
	{
		$job = Add-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId -AsJob
		$job | Wait-Job
		$keyResult = $job.Output

		# $keyResult = Add-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId

		Assert-AreEqual $params.keyId $keyResult.Uri 
		Assert-AreEqual $params.serverKeyName $keyResult.ServerKeyName 
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting a server key vault key
#>
function Test-GetServerKeyVaultKey
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$rg = Create-ServerKeyVaultKeyTestEnvironment $params

	try
	{
		$keyResult = Add-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyResult.Uri
		Assert-AreEqual $params.serverKeyName $keyResult.ServerKeyName 

		$keyGet = Get-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyGet.Uri
		Assert-AreEqual $params.serverKeyName $keyGet.ServerKeyName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests removing a server key vault key
#>
function Test-RemoveServerKeyVaultKey
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$rg = Create-ServerKeyVaultKeyTestEnvironment $params

	try
	{
		$keyResult = Add-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyResult.Uri 
		Assert-AreEqual $params.serverKeyName $keyResult.ServerKeyName 

		$keyGet = Get-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyGet.Uri
		Assert-AreEqual $params.serverKeyName $keyGet.ServerKeyName

		$job = Remove-AzureRmSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId -AsJob
		$job | Wait-Job
		$keyRemove = $job.Output

		Assert-AreEqual $params.keyId $keyRemove.Uri
		Assert-AreEqual $params.serverKeyName $keyRemove.ServerKeyName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
