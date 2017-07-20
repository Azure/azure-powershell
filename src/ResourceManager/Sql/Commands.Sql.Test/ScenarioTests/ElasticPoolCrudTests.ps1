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
    Tests creating an elastic pool
#>
function Test-CreateElasticPool
{
    # Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg

    try
    {
        # Create a pool with all values
        $poolName = Get-ElasticPoolName
        $ep1 = New-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
            -ElasticPoolName $poolName -Edition Standard -Dtu 200 -DatabaseDtuMin 10 -DatabaseDtuMax 100 -StorageMB 204800
        Assert-NotNull $ep1
        Assert-AreEqual 200 $ep1.Dtu 
        Assert-AreEqual 204800 $ep1.StorageMB
        Assert-AreEqual Standard $ep1.Edition
        Assert-AreEqual 10 $ep1.DatabaseDtuMin
        Assert-AreEqual 100 $ep1.DatabaseDtuMax

        # Create a pool using piping and default values
        $poolName = Get-ElasticPoolName
        $ep2 = $server | New-AzureRmSqlElasticPool -ElasticPoolName $poolName
        Assert-NotNull $ep2
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests updating an elastic pool
#>
function Test-UpdateElasticPool
{
    # Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg

    $poolName = Get-ElasticPoolName
    $ep1 = New-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -ElasticPoolName $poolName -Edition Standard -Dtu 200 -DatabaseDtuMin 10 -DatabaseDtuMax 100
    Assert-NotNull $ep1
    
    $poolName = Get-ElasticPoolName
    $ep2 = $server | New-AzureRmSqlElasticPool -ElasticPoolName $poolName -Edition Standard -Dtu 400 -DatabaseDtuMin 10 `
         -DatabaseDtuMax 100
    Assert-NotNull $ep2


    try
    {
        # Create a pool with all values
        $sep1 = Set-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
            -ElasticPoolName $ep1.ElasticPoolName -Dtu 400 -DatabaseDtuMin 0 -DatabaseDtuMax 50 -Edition Standard -StorageMB 409600
        Assert-NotNull $sep1
        Assert-AreEqual 400 $sep1.Dtu 
        Assert-AreEqual 409600 $sep1.StorageMB
        Assert-AreEqual Standard $sep1.Edition
        Assert-AreEqual 0 $sep1.DatabaseDtuMin
        Assert-AreEqual 50 $sep1.DatabaseDtuMax

        # Create a pool using piping
        $sep2 = $server | Set-AzureRmSqlElasticPool -ElasticPoolName $ep2.ElasticPoolName -Dtu 200 `
            -DatabaseDtuMin 10 -DatabaseDtuMax 50  -Edition Standard -StorageMB 204800
        Assert-NotNull $sep2
        Assert-AreEqual 200 $sep2.Dtu 
        Assert-AreEqual 204800 $sep2.StorageMB
        Assert-AreEqual Standard $sep2.Edition
        Assert-AreEqual 10 $sep2.DatabaseDtuMin
        Assert-AreEqual 50 $sep2.DatabaseDtuMax
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}


<# 
    .SYNOPSIS
    Tests getting an elastic pool
#>
function Test-GetElasticPool
{
    # Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg

    $poolName = Get-ElasticPoolName
    $ep1 = New-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -ElasticPoolName $poolName -Edition Standard -Dtu 200 -DatabaseDtuMin 10 -DatabaseDtuMax 100
    Assert-NotNull $ep1
    
    $poolName = Get-ElasticPoolName
    $ep2 = $server | New-AzureRmSqlElasticPool -ElasticPoolName $poolName -Edition Standard -Dtu 400 -DatabaseDtuMin 0 `
         -DatabaseDtuMax 100
    Assert-NotNull $ep2

    try
    {
        # Create a pool with all values
        $gep1 = Get-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
            -ElasticPoolName $ep1.ElasticPoolName 
        Assert-NotNull $ep1
        Assert-AreEqual 200 $ep1.Dtu 
        Assert-AreEqual 204800 $ep1.StorageMB
        Assert-AreEqual Standard $ep1.Edition
        Assert-AreEqual 10 $ep1.DatabaseDtuMin
        Assert-AreEqual 100 $ep1.DatabaseDtuMax

        # Create a pool using piping
        $gep2 = $ep2 | Get-AzureRmSqlElasticPool
        Assert-NotNull $ep2
        Assert-AreEqual 400 $ep2.Dtu 
        Assert-AreEqual 409600 $ep2.StorageMB
        Assert-AreEqual Standard $ep2.Edition
        Assert-AreEqual 0 $ep2.DatabaseDtuMin
        Assert-AreEqual 100 $ep2.DatabaseDtuMax

        $all = $server | Get-AzureRmSqlElasticPool
        Assert-AreEqual $all.Count 2
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests removing an elastic pool
#>
function Test-RemoveElasticPool
{
    # Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg

    $poolName = Get-ElasticPoolName
    $ep1 = New-AzureRmSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -ElasticPoolName $poolName -Edition Standard -Dtu 200 -DatabaseDtuMin 10 -DatabaseDtuMax 100
    Assert-NotNull $ep1
    
    $poolName = Get-ElasticPoolName
    $ep2 = $server | New-AzureRmSqlElasticPool -ElasticPoolName $poolName -Edition Standard -Dtu 400 -DatabaseDtuMin 0 `
         -DatabaseDtuMax 100
    Assert-NotNull $ep2

    try
    {
        # Create a pool with all values
        Remove-AzureRmSqlElasticPool -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -ElasticPoolName $ep1.ElasticPoolName –Confirm:$false
        
        # Create a pool using piping
        $ep2 | Remove-AzureRmSqlElasticPool -Force

        $all = $server | Get-AzureRmSqlElasticPool
        Assert-AreEqual $all.Count 0
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}