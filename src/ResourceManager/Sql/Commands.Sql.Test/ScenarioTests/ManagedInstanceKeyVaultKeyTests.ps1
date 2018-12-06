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
		
# A managed instance can be provisioned using instructions here https://docs.microsoft.com/en-us/azure/sql-database/sql-database-managed-instance-get-started
# currently this takes about 2-3 hours
$mangedInstanceRg = "MlAndzic_RG"
$managedInstanceName = "midemoinstancebc"
$keyVaultName = "mitest-doNotDelete"
$keyName = "mitest-key"
$keyId = "https://mitest-donotdelete.vault.azure.net/keys/mitest-key/e97043455e14493ca05c3642549aedba"
$keyVersion = "e97043455e14493ca05c3642549aedba"
$tdeKeyName = $keyVaultName + "_" + $keyName + "_" + $keyVersion


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance for continuous validation
#>
function Test-ManagedInstanceKeyVaultKeyCI
{

	$managedInstance = Get-AzureRmSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg
	$managedInstanceResourceId = $managedInstance.ResourceId

	# Test Add
	$keyResult = Add-AzureRmSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = $managedInstance| Get-AzureRmSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
		
	# Test List
	$keyResults = Get-AzureRmSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlInstanceKeyVaultKey without KeyId"
}

<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance 
#>
function Test-ManagedInstanceKeyVaultKey
{
	# Test Add
	$keyResult = Add-AzureRmSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzureRmSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
		
	# Test List
	$keyResults = Get-AzureRmSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using input object parameter set
#>
function Test-ManagedInstanceKeyVaultKeyInputObject
{
	$managedInstance = Get-AzureRmSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg

	# Test Add
	$keyResult = Add-AzureRmSqlInstanceKeyVaultKey -Instance $managedInstance -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzureRmSqlInstanceKeyVaultKey -Instance $managedInstance -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = Get-AzureRmSqlInstanceKeyVaultKey -Instance $managedInstance 
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using resource id parameter set
#>
function Test-ManagedInstanceKeyVaultKeyResourceId
{
	$managedInstance = Get-AzureRmSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg
	$managedInstanceResourceId = $managedInstance.ResourceId

	# Test Add
	$keyResult = Add-AzureRmSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzureRmSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = Get-AzureRmSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId 
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using piping
#>
function Test-ManagedInstanceKeyVaultKeyPiping
{
	$managedInstance = Get-AzureRmSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg

	# Test Add
	$keyResult = $managedInstance | Add-AzureRmSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = $managedInstance | Get-AzureRmSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = $managedInstance | Get-AzureRmSqlInstanceKeyVaultKey
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlInstanceKeyVaultKey without KeyId"
}
