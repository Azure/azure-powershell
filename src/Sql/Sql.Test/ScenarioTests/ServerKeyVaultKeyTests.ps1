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
		$job = Add-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId -AsJob
		$job | Wait-Job
		$keyResult = $job.Output

		# $keyResult = Add-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId

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
		$keyResult = Add-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyResult.Uri
		Assert-AreEqual $params.serverKeyName $keyResult.ServerKeyName 

		$keyGet = Get-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
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
		$keyResult = Add-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyResult.Uri 
		Assert-AreEqual $params.serverKeyName $keyResult.ServerKeyName 

		$keyGet = Get-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId
		Assert-AreEqual $params.keyId $keyGet.Uri
		Assert-AreEqual $params.serverKeyName $keyGet.ServerKeyName

		$job = Remove-AzSqlServerKeyVaultKey -ServerName $params.serverName -ResourceGroupName $params.rgName -KeyId $params.keyId -AsJob
		$job | Wait-Job
		$keyRemove = $job.Output
		
		Assert-AreEqual $params.serverKeyName $keyRemove.ServerKeyName
		Assert-AreEqual $params.keyId $keyRemove.Uri
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests adding a server key vault key without a version in the key id
#>
function Test-AddVersionlessServerKeyVaultKey
{
	# Create unique names for new resources
	$location = "eastus2euap"
	$keyVaultName = "akv+$Get-Random"
	$keyName = "serverkey+$Get-Random"

	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest
		$serverName = Get-ServerName
		$credentials = Get-ServerCredential

		$server = New-AzSqlServer -ResourceGroupName  $rg.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials -AssignIdentity
		$server | Wait-Job

		# Create Key Vault
		$keyVault = New-AzKeyVault -Name $keyVaultName `
			-ResourceGroupName $server.ResourceGroupName `
			-Location $location `
			-EnablePurgeProtection

		$objectIdOfUser=(Get-AzContext).Account.ExtendedProperties.HomeAccountId.Split('.')[0]
		Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ObjectId $objectIdOfUser -PermissionsToKeys All -BypassObjectIdValidation

		# Create a key in the Key Vault
		$akvKey = Add-AzKeyVaultKey -VaultName $keyVaultName -Name $keyName -Destination Software

		# Grant SQL Server access to Key Vault
		Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName `
			-ObjectId $server.Identity.PrincipalId `
			-PermissionsToKeys get, wrapKey, unwrapKey

		# Get the full key ID with version
		$keyId = $akvKey.Id

		# Remove version from the key ID to create a versionless key
		$versionlessKeyId = $keyId -replace '/[^/]+$', ''
		
		$job = Add-AzSqlServerKeyVaultKey -ServerName $serverName -ResourceGroupName $server.ResourceGroupName -KeyId $versionlessKeyId -AsJob
		$job | Wait-Job
		$keyResult = $job.Output

		Assert-NotNull $keyResult.Uri
		Assert-NotNull $keyResult.ServerKeyName
		Assert-True { $keyResult.Uri.StartsWith($versionlessKeyId) }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
