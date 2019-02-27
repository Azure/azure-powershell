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
Test Account CRUD operations
#>
function Test-AccountCrud
{
	$resourceGroup = "pws-sdk-tests-rg-1"
	$accName1 = "pws-sdk-acc-1"
	$accName2 = "pws-sdk-acc-2"
    $resourceLocation = "westus2"

	try
    {
	    # create the resource group
		New-AzureRmResourceGroup -Name $resourceGroup -Location $resourceLocation

		# create and check account 1
		$retrievedAcc = New-AzureRmAnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1
	    Assert-AreEqual $accName1 $retrievedAcc.Name

		# create and check account 2
		$retrievedAcc = New-AzureRmAnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName2 
	    Assert-AreEqual $accName2 $retrievedAcc.Name
		
		# get and check accounts by group (list)
		$retrievedAcc = Get-AzureRmAnfAccount -ResourceGroupName $resourceGroup
		Assert-AreEqual $accName1 $retrievedAcc[0].Name
		Assert-AreEqual $accName2 $retrievedAcc[1].Name
	    Assert-AreEqual 2 $retrievedAcc.Length

		# get and check an account by name
		$retrievedAcc = Get-AzureRmAnfAccount -ResourceGroupName $resourceGroup -AccountName $accName1
		Assert-AreEqual $accName1 $retrievedAcc.Name

		# get and check the account again using the resource id just obtained
		$retrievedAccById = Get-AzureRmAnfAccount -ResourceId $retrievedAcc.Id
		Assert-AreEqual $accName1 $retrievedAccById.Name

		# update and check the account (tags)
		# since only tags can be patched and no other set or update is possible
		# there is no implemented cmdlet

		# delete one account retrieved by id and one by name and check removed
		Remove-AzureRmAnfAccount -ResourceId $retrievedAccById.Id
		Remove-AzureRmAnfAccount -ResourceGroupName $resourceGroup -AccountName $accName2
		$retrievedAcc = Get-AzureRmAnfAccount -ResourceGroupName $resourceGroup
		Assert-AreEqual 0 $retrievedAcc.Length
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
