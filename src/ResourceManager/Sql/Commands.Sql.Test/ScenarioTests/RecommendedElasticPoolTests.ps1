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
    Tests listing all recommended elastic pools for server
#>
function Test-ListRecommendedElasticPools
{
    # Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"

    try
    {
        $response = Get-AzureSqlElasticPoolRecommendation -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-NotNull $response
        Assert-AreEqual 2 $response.Count

        Assert-AreEqual "ElasticPool1" $response[0].RecommendedElasticPoolName
		Assert-AreEqual "Standard" $response[0].DatabaseEdition
		Assert-AreEqual 1000 $response[0].Dtu
		Assert-AreEqual 100.6 $response[0].DatabaseDtuMin
		Assert-AreEqual 200.5 $response[0].DatabaseDtuMax
		Assert-AreEqual 1000.3 $response[0].StorageMB
		Assert-AreEqual '11/01/2014 00:00:00' $response[0].ObservationPeriodStart
		Assert-AreEqual '11/15/2014 00:00:00' $response[0].ObservationPeriodEnd
		Assert-AreEqual 900.2 $response[0].MaxObservedDtu
		Assert-AreEqual 350 $response[0].MaxObservedStorageMB
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests getting recommended elastic pool by name
#>
function Test-GetRecommendedElasticPool 
{
	# Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"

    try
    {
        $response = Get-AzureSqlElasticPoolRecommendation -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolRecommendation "ElasticPool1"
		Assert-NotNull $response

        Assert-AreEqual "ElasticPool1" $response.RecommendedElasticPoolName
		Assert-AreEqual "Standard" $response.DatabaseEdition
		Assert-AreEqual 1000 $response.Dtu
		Assert-AreEqual 100.6 $response.DatabaseDtuMin
		Assert-AreEqual 200.5 $response.DatabaseDtuMax
		Assert-AreEqual 1000.3 $response.StorageMB
		Assert-AreEqual '11/01/2014 00:00:00' $response.ObservationPeriodStart
		Assert-AreEqual '11/15/2014 00:00:00' $response.ObservationPeriodEnd
		Assert-AreEqual 900.2 $response.MaxObservedDtu
		Assert-AreEqual 350 $response.MaxObservedStorageMB
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests listing all databases in recommended elastic pool
#>
function Test-ListRecommendedElasticPoolDatabases 
{
	# Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"

    try
    {
        $response = Get-AzureSqlElasticPoolRecommendationDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName  -ElasticPoolRecommendation "ElasticPool1"
		Assert-NotNull $response
		Assert-AreEqual 1 $response.Count

		Assert-AreEqual 'TestDb1' $response[0].DatabaseName
		Assert-AreEqual '28acaef5-d228-4660-bb67-546ec8482496' $response[0].DatabaseId
		Assert-AreEqual 'Online' $response[0].Status
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests getting database by name for specific recommended elastic pool
#>
function Test-GetRecommendedElasticPoolDatabase 
{
	# Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"

    try
    {
        $response = Get-AzureSqlElasticPoolRecommendationDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName  -ElasticPoolRecommendation "ElasticPool1" -DatabaseName "TestDb1"
		Assert-NotNull $response

		Assert-AreEqual 'TestDb1' $response.DatabaseName
		Assert-AreEqual '28acaef5-d228-4660-bb67-546ec8482496' $response.DatabaseId
		Assert-AreEqual 'Online' $response.Status
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests listing metrics for specific recommended elastic pool
#>
function Test-GetRecommendedElasticPoolMetrics
{
	# Setup 
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"

    try
    {
        $response = Get-AzureSqlElasticPoolRecommendationMetrics -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolRecommendation "ElasticPool1"
		Assert-NotNull $response
		Assert-AreEqual 3 $response.Count

		Assert-AreEqual '04/01/2015 00:00:00' $response[0].DateTime
		Assert-AreEqual 100.5 $response[0].Dtu
		Assert-AreEqual 15.4 $response[0].SizeGB
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}