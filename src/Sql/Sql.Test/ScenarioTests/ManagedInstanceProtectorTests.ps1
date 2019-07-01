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
	Tests setting and getting encryption protector to service managed key for CI
#>
function Test-SetGetManagedInstanceEncryptionProtectorCI
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	# ServiceManaged with ResourceGroupName and ManagedInstanceName & ResourceId
	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -Type ServiceManaged
	
	Assert-AreEqual ServiceManaged $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector  -InstanceResourceId $managedInstance.Id
	
	Assert-AreEqual ServiceManaged $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"

	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"
	
	# Byok with piping & inputobject

	$byokEncryptionProtector = $managedInstance | Set-AzSqlInstanceTransparentDataEncryptionProtector -Type AzureKeyVault -KeyId $keyResult.KeyId -Force
	
	Assert-AreEqual AzureKeyVault $byokEncryptionProtector.Type "BYOK: Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $byokEncryptionProtector.ManagedInstanceKeyVaultKeyName "BYOK:  mismatch after setting managed instance TDE protector"

	$byokEncryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector -Instance $managedInstance
	
	Assert-AreEqual AzureKeyVault $byokEncryptionProtector2.Type "BYOK: Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $byokEncryptionProtector2.ManagedInstanceKeyVaultKeyName "BYOK: ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to service managed key 
#>
function Test-SetGetManagedInstanceEncryptionProtectorServiceManaged
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -Type ServiceManaged
	
	Assert-AreEqual ServiceManaged $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName
	
	Assert-AreEqual ServiceManaged $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to service managed key for input object parameter set
#>
function Test-SetGetManagedInstanceEncryptionProtectorServiceManagedInputObject
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector -Instance $managedInstance -Type ServiceManaged
	
	Assert-AreEqual ServiceManaged $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector -Instance $managedInstance
	
	Assert-AreEqual ServiceManaged $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to service managed key for resource id parameter set
#>
function Test-SetGetManagedInstanceEncryptionProtectorServiceManagedResourceId
{

	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName
	$managedInstanceResourceId = $managedInstance.Id

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector -InstanceResourceId $managedInstanceResourceId -Type ServiceManaged
	
	Assert-AreEqual ServiceManaged $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector -InstanceResourceId $managedInstanceResourceId
	
	Assert-AreEqual ServiceManaged $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to service managed key using piping
#>
function Test-SetGetManagedInstanceEncryptionProtectorServiceManagedPiping
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$encryptionProtector = $managedInstance | Set-AzSqlInstanceTransparentDataEncryptionProtector -Type ServiceManaged
	
	Assert-AreEqual ServiceManaged $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = $managedInstance | Get-AzSqlInstanceTransparentDataEncryptionProtector
	
	Assert-AreEqual ServiceManaged $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual ServiceManaged $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}



<#
	.SYNOPSIS
	Tests setting and getting encryption protector to azure key vault key 
#>
function Test-SetGetManagedInstanceEncryptionProtectorByok
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName
	
	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -Type AzureKeyVault -KeyId $keyResult.KeyId -Force
	
	Assert-AreEqual AzureKeyVault $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName
	
	Assert-AreEqual AzureKeyVault $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to azure key vault key for input object parameter set
#>
function Test-SetGetManagedInstanceEncryptionProtectorByokInputObject
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector -Instance $managedInstance -Type AzureKeyVault -KeyId $keyResult.KeyId -Force
	
	Assert-AreEqual AzureKeyVault $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector -Instance $managedInstance
	
	Assert-AreEqual AzureKeyVault $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to azure key vault key for resource id parameter set
#>
function Test-SetGetManagedInstanceEncryptionProtectorByokResourceId
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName
	
	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"

	$managedInstanceResourceId = $managedInstance.Id

	$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector -InstanceResourceId $managedInstanceResourceId -Type AzureKeyVault -KeyId $keyResult.KeyId -Force
	
	Assert-AreEqual AzureKeyVault $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = Get-AzSqlInstanceTransparentDataEncryptionProtector -InstanceResourceId $managedInstanceResourceId
	
	Assert-AreEqual AzureKeyVault $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}

<#
	.SYNOPSIS
	Tests setting and getting encryption protector to azure key vault key using piping
#>
function Test-SetGetManagedInstanceEncryptionProtectorByokPiping
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"

	$encryptionProtector = $managedInstance | Set-AzSqlInstanceTransparentDataEncryptionProtector -Type AzureKeyVault -KeyId $keyResult.KeyId -Force
	
	Assert-AreEqual AzureKeyVault $encryptionProtector.Type "Protector type mismatch after setting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after setting managed instance TDE protector"

	$encryptionProtector2 = $managedInstance | Get-AzSqlInstanceTransparentDataEncryptionProtector
	
	Assert-AreEqual AzureKeyVault $encryptionProtector2.Type "Protector type mismatch after getting managed instance TDE protector"
	Assert-AreEqual $keyResult.ManagedInstanceKeyName $encryptionProtector2.ManagedInstanceKeyVaultKeyName "ManagedInstanceKeyVaultKeyName mismatch after getting managed instance TDE protector"
}


<#
	.SYNOPSIS
	Tests setting and getting encryption protector to azure key vault key 
#>
function Test-SetGetManagedInstanceEncryptionProtectorByokFailsWithoutKeyId
{
	$params = Get-SqlServerKeyVaultKeyTestEnvironmentParameters
	$managedInstance = Get-ManagedInstanceForTdeTest $params
	$mangedInstanceRg = $managedInstance.ResourceGroupName
	$managedInstanceName = $managedInstance.ManagedInstanceName

	$correctExceptionCaught = $false
	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $params.keyId

	Assert-AreEqual $params.keyId $keyResult.KeyId "KeyId mismatch after adding managed instance key vault key"
	Assert-AreEqual $params.serverKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyVaultKeyName mismatch after adding managed instance key vault key"
	
	try
	{
		$encryptionProtector = Set-AzSqlInstanceTransparentDataEncryptionProtector  -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -Type AzureKeyVault -Force
	}
	Catch
	{
		$isCorrectError =  $_.Exception.Message -like '*KeyId parameter is required for encryption protector type AzureKeyVault*'
		if(!$isCorrectError){
			throw $_.Exception
		}
		$correctExceptionCaught = $true
	}

	if(!$correctExceptionCaught){
		throw [System.Exception] "Expected exception not thrown for cmdlet Set-AzSqlInstanceTransparentDataEncryptionProtector when encryptor is AzureKeyVault and KeyId is not provided"
	}
}