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
Test Pool CRUD operations
#>
function Test-PoolCrud
{
	$resourceGroup = "pws-sdk-tests-rg-1"
	$accName = "pws-sdk-acc-1"
	$poolName1 = "pws-sdk-pool-1" 
	$poolName2 = "pws-sdk-pool-2" 
    $resourceLocation = "westus2"
	$standardPoolSize = 4398046511104
	$serviceLevel = "Premium"

	try
    {
	    # create the resource group
		New-AzureRmResourceGroup -Name $resourceGroup -Location $resourceLocation

		# create account
		$retrievedAcc = New-AzureRmAnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 
	    
		# create pool 1 and check
		$retrievedPool = New-AzureRmAnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1 -PoolSize $standardPoolSize -ServiceLevel $serviceLevel
        Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name
		Assert-AreEqual $serviceLevel $retrievedPool.ServiceLevel

		# create and check pool 2
		$retrievedPool = New-AzureRmAnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $standardPoolSize -ServiceLevel $serviceLevel 
        Assert-AreEqual "$accName/$poolName2" $retrievedPool.Name
		
		# get and check pools by group (list)
	    $retrievedPool = Get-AzureRmAnfPool -ResourceGroupName $resourceGroup -AccountName $accName
		Assert-AreEqual "$accName/$poolName1" $retrievedPool[0].Name
		Assert-AreEqual "$accName/$poolName2" $retrievedPool[1].Name
	    Assert-AreEqual 2 $retrievedPool.Length

		# get and check a pool by name
		$retrievedPool = Get-AzureRmAnfPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1
		Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name

		# get and check the account again using the resource id just obtained
	    $retrievedPoolById = Get-AzureRmAnfPool -ResourceId $retrievedPool.Id
		Assert-AreEqual "$accName/$poolName1" $retrievedPoolById.Name

		# update (patch) and check the pool
		# only tags can currently be patched so there is no implemented cmdlet

		# set (put) and check the Pool
		$retrievedPool = Set-AzureRmAnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1 -PoolSize $standardPoolSize -ServiceLevel "Standard"
        Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name
        Assert-AreEqual "Standard" $retrievedPool.ServiceLevel

		# delete one account retrieved by id and one by name and check removed
		Remove-AzureRmAnfPool -ResourceId $retrievedPoolById.Id
		Remove-AzureRmAnfPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2
		$retrievedPool = Get-AzureRmAnfPool -ResourceGroupName $resourceGroup -AccountName $accName
		Assert-AreEqual 0 $retrievedPool.Length
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
