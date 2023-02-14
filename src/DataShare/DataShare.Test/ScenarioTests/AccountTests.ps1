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
Full Account CRUD cycle
#>
function Test-AccountCrud
{
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try{
		$AccountName = getAssetName
		$tags = @{"tag1" = "value1"; "tag2" = "value2"}
		$AccountLocation = Get-Location "Microsoft.DataShare" "accounts" "WEST US"
		$createdAccount = New-AzDataShareAccount -Name $AccountName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $AccountLocation -Tag $tags

		Assert-NotNull $createdAccount
		Assert-AreEqual $AccountName $createdAccount.Name
		Assert-AreEqual $AccountLocation $createdAccount.location
		Assert-Tags $tags $createdAccount.tags
		Assert-AreEqual "Succeeded" $createdAccount.ProvisioningState

		$retrievedAccount = Get-AzDataShareAccount -Name $AccountName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-NotNull $retrievedAccount
		Assert-AreEqual $AccountName $retrievedAccount.Name
		Assert-AreEqual $AccountLocation $retrievedAccount.location
		Assert-AreEqual "Succeeded" $retrievedAccount.ProvisioningState

		$removed = Remove-AzDataShareAccount -Name $AccountName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force

		Assert-True { $removed }
		Assert-ThrowsContains { Get-AzDataShareAccount -Name $AccountName -ResourceGroupName $resourceGroup.ResourceGroupName } "Resource 'sdktestingshareaccount9776' does not exist"
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
	}
}