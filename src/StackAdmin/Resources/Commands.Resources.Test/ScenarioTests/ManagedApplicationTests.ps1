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
Tests Managed Application CRUD operations
#>
function Test-ManagedApplicationCRUD
{
	# Setup
	$rgname = Get-ResourceGroupName
	$managedrgname = Get-ResourceGroupName
	$appDefName = Get-ResourceName
	$appName = Get-ResourceName
	$rglocation = "EastUS2EUAP"
	$display = "myAppDefPoSH"

	# Test
	New-AzureRmResourceGroup -Name $rgname -Location $rglocation

	$appDef = New-AzureRMManagedApplicationDefinition -Name $appDefName -ResourceGroupName $rgname -DisplayName $display -Description "Test" -Location $rglocation -LockLevel ReadOnly -PackageFileUri https://testclinew.blob.core.windows.net/files/vivekMAD.zip -Authorization 5e91139a-c94b-462e-a6ff-1ee95e8aac07:8e3af657-a8ff-443c-a75c-2fe8c4bcb635
	$actual = New-AzureRMManagedApplication -Name $appName -ResourceGroupName $rgname -ManagedResourceGroupName $managedrgname -ManagedApplicationDefinitionId $appDef.ResourceId -Location $rglocation -Kind ServiceCatalog -Parameter "$TestOutputRoot\SampleManagedApplicationParameters.json"
	$expected = Get-AzureRMManagedApplication -Name $appName -ResourceGroupName $rgname
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.ManagedApplicationId $actual.ManagedApplicationId
	Assert-AreEqual $expected.Properties.applicationDefinitionId $appDef.ResourceId
	Assert-NotNull($actual.Properties.parameters)

	$actual = Set-AzureRMManagedApplication -ResourceId $expected.ManagedApplicationId -Tags @{test="test"}
	$expected = Get-AzureRMManagedApplication -Name $appName -ResourceGroupName $rgname
	Assert-AreEqual 1 @($actual.Tags).Count

	$list = Get-AzureRMManagedApplication -ResourceGroupName $rgname
	Assert-AreEqual 1 @($list).Count
}