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
    $poolSize = 4398046511104
    $serviceLevel = "Premium"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation

        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 
	    
        # create pool 1 and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1 -PoolSize $poolSize -ServiceLevel $serviceLevel -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name
        Assert-AreEqual $serviceLevel $retrievedPool.ServiceLevel
        Assert-AreEqual True $retrievedPool.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedPool.Tags[$newTagName].ToString()

        # create and check pool 2 using the confirm flag
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevel -Confirm:$false
        Assert-AreEqual "$accName/$poolName2" $retrievedPool.Name
		
        # create and check pool 3 using the WhatIf - it should not be created
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevel -WhatIf

        # get and check pools by group (list)
        $retrievedPool = Get-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName
        Assert-AreEqual "$accName/$poolName1" $retrievedPool[0].Name
        Assert-AreEqual "$accName/$poolName2" $retrievedPool[1].Name
        Assert-AreEqual 2 $retrievedPool.Length

        # get and check a pool by name
        $retrievedPool = Get-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1
        Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name

        # get and check the account again using the resource id just obtained
        $retrievedPoolById = Get-AzNetAppFilesPool -ResourceId $retrievedPool.Id
        Assert-AreEqual "$accName/$poolName1" $retrievedPoolById.Name

        # update (patch) and check the pool
        # only tags can currently be patched so there is no implemented cmdlet

        # Update and check the Pool
        $retrievedPool = Update-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1 -PoolSize $poolSize -ServiceLevel "Standard"
        Assert-AreEqual "$accName/$poolName1" $retrievedPool.Name
        Assert-AreEqual "Standard" $retrievedPool.ServiceLevel

        # delete one account retrieved by id and one by name and check removed
        Remove-AzNetAppFilesPool -ResourceId $retrievedPoolById.Id

        # but test the WhatIf first
        Remove-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2 -WhatIf
        $retrievedPool = Get-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName
        Assert-AreEqual 1 $retrievedPool.Length

        Remove-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2
        $retrievedPool = Get-AzNetAppFilesPool -ResourceGroupName $resourceGroup -AccountName $accName
        Assert-AreEqual 0 $retrievedPool.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}


<#
.SYNOPSIS
Test Pool Pipeline operations (using command aliases)
#>
function Test-PoolPipelines
{
    $resourceGroup = "pws-sdk-tests-rg-1"
    $accName = "pws-sdk-acc-1"
    $poolName1 = "pws-sdk-pool-1"
    $poolName2 = "pws-sdk-pool-2"
    $resourceLocation = "westus2"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation

        # create pool by piping from account
        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName | New-AnfPool -Name $poolName1 -PoolSize $poolSize -ServiceLevel $serviceLevel
		
        # modify pool by piping from Pool
        $retrievedPool = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -Name $poolName1 | Update-AnfPool -PoolSize $poolSize -ServiceLevel "Standard"
        Assert-AreEqual "Standard" $retrievedPool.ServiceLevel
		
        # and again modify pool this time by piping from account
        $retrievedPool = Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName | Update-AnfPool -Name $poolName1 -PoolSize $poolSize -ServiceLevel "Premium"
        Assert-AreEqual "Premium" $retrievedPool.ServiceLevel

        # delete a pool by piping from account
        Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName | Remove-AnfPool -Name $poolName1 

        # recreate two pools
        New-AnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -Name $PoolName1 -PoolSize $poolSize -ServiceLevel $serviceLevel

        New-AnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevel

        # delete one of the pools by piping from pool get
        Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -Name $poolName1 | Remove-AzNetAppFilesPool

        $retrievedPool = Get-AnfAccount -ResourceGroupName $resourceGroup -AccountName $accName | Get-AnfPool 
		Assert-AreEqual 1 $retrievedPool.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}