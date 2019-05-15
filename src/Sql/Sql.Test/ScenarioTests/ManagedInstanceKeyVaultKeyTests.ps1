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
$mangedInstanceRg = "BenjinResourceGroup"
$managedInstanceName = "benjinmitest"
$keyVaultName = "mitest-eus-doNotDelete"
$keyName = "mitest-key"
$keyId = "https://mitest-eus-donotdelete.vault.azure.net/keys/mitest-key/6dc78e98a3274d87bd847436dd34045e"
$keyVersion = "6dc78e98a3274d87bd847436dd34045e"
$tdeKeyName = $keyVaultName + "_" + $keyName + "_" + $keyVersion


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance for continuous validation
#>
function Test-ManagedInstanceKeyVaultKeyCI
{

	$managedInstance = Get-AzSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg
	$managedInstanceResourceId = $managedInstance.Id

	# Test Add
	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = $managedInstance | Get-AzSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzSqlInstanceKeyVaultKey"
		
	# Test List
	$keyResults = Get-AzSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzSqlInstanceKeyVaultKey without KeyId"
}

<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance 
#>
function Test-ManagedInstanceKeyVaultKey
{
	# Test Add
	$keyResult = Add-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzSqlInstanceKeyVaultKey"
		
	# Test List
	$keyResults = Get-AzSqlInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -InstanceName $managedInstanceName
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using input object parameter set
#>
function Test-ManagedInstanceKeyVaultKeyInputObject
{
	$managedInstance = Get-AzSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg

	# Test Add
	$keyResult = Add-AzSqlInstanceKeyVaultKey -Instance $managedInstance -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzSqlInstanceKeyVaultKey -Instance $managedInstance -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = Get-AzSqlInstanceKeyVaultKey -Instance $managedInstance 
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using resource id parameter set
#>
function Test-ManagedInstanceKeyVaultKeyResourceId
{
	$managedInstance = Get-AzSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg
	$managedInstanceResourceId = $managedInstance.Id

	# Test Add
	$keyResult = Add-AzSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = Get-AzSqlInstanceKeyVaultKey -InstanceResourceId $managedInstanceResourceId 
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzSqlInstanceKeyVaultKey without KeyId"
}


<#
	.SYNOPSIS
	Tests for managing TDE keyVaultKey in managed instance using piping
#>
function Test-ManagedInstanceKeyVaultKeyPiping
{
	$managedInstance = Get-AzSqlInstance -Name $managedInstanceName -ResourceGroupName $mangedInstanceRg

	# Test Add
	$keyResult = $managedInstance | Add-AzSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzSqlInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = $managedInstance | Get-AzSqlInstanceKeyVaultKey -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzSqlInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzSqlInstanceKeyVaultKey"

	
	# Test List
	$keyResults = $managedInstance | Get-AzSqlInstanceKeyVaultKey
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzSqlInstanceKeyVaultKey without KeyId"
}
