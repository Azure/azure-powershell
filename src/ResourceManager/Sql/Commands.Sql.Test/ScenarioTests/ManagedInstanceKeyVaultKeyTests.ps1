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
		
$mangedInstanceRg = "MlAndzic_RG"
$managedInstanceName = "midemoinstancebc"
$keyVaultName = "mitest-doNotDelete"
$keyName = "mitest-key"
$keyId = "https://mitest-donotdelete.vault.azure.net/keys/mitest-key/e97043455e14493ca05c3642549aedba"
$keyVersion = "e97043455e14493ca05c3642549aedba"
$tdeKeyName = $keyVaultName + "_" + $keyName + "_" + $keyVersion

<#
	.SYNOPSIS
	Tests adding TDE keyVaultKey to managed instance
#>
function Test-ManagedInstanceKeyVaultKey
{
	# Test Add
	$keyResult = Add-AzureRmSqlManagedInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -ManagedInstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult.KeyId "KeyId mismatch after calling Add-AzureRmSqlManagedInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Add-AzureRmSqlManagedInstanceKeyVaultKey"

	
	# Test Get
	$keyResult2 = Get-AzureRmSqlManagedInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -ManagedInstanceName $managedInstanceName -KeyId $keyId

	Assert-AreEqual $keyId $keyResult2.KeyId "KeyId mismatch after calling Get-AzureRmSqlManagedInstanceKeyVaultKey"
	Assert-AreEqual $tdeKeyName $keyResult2.ManagedInstanceKeyName "ManagedInstanceKeyName mismatch after calling Get-AzureRmSqlManagedInstanceKeyVaultKey"

	
	# Test List
	$keyResults = Get-AzureRmSqlManagedInstanceKeyVaultKey -ResourceGroupName $mangedInstanceRg -ManagedInstanceName $managedInstanceName
	
	Assert-True {$keyResults.Count -gt 0} "List count <= 0 after calling (List) Get-AzureRmSqlManagedInstanceKeyVaultKey without KeyId"
}
