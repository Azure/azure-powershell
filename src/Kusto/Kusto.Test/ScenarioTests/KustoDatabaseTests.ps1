<#
.SYNOPSIS
Tests Kusto cluster lifecycle (Create, Update, Get, List, Delete).
#>
function Test-KustoDatabaseLifecycle
{
	try
	{  
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$databaseName = Get-Database-Name
		$resourceType =  Get-Database-Type
		$softDeletePeriodInDays =  Get-Soft-Delete-Period-In-Days
		$hotCachePeriodInDays =  Get-Hot-Cache-Period-In-Days
		$databaseFullName = "$clusterName/$databaseName"
		$expectedException = Get-Database-Not-Exist-Message -DatabaseName $databaseName
		
		$softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
		$hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days

		#create cluster for the databases
		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku

		$databaseCreated = New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		$databaseGetItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDaysUpdated -HotCachePeriodInDays $hotCachePeriodInDaysUpdated
		Validate_Database $databaseUpdatedWithParameters $databaseFullName $location $type $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated;

		$databaseUpdatedWithResourceId = Update-AzKustoDatabase -ResourceId $databaseUpdatedWithParameters.Id -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseUpdatedWithResourceId $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		$databaseUpdatedObject = Update-AzKustoDatabase -InputObject $databaseUpdatedWithResourceId -SoftDeletePeriodInDays $softDeletePeriodInDaysUpdated -HotCachePeriodInDays $hotCachePeriodInDaysUpdated
		Validate_Database $databaseUpdatedObject $databaseFullName $location $type $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated;

		Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
		Ensure_Database_Not_Exist $resourceGroupName $clusterName $databaseName $expectedException
	}
	finally
	{
#		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests Kusto Add Get and Remove using resourceId and InputObject
#>
function Test-DatabaseAddRemoveGet {
	try
	{
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$databaseName = Get-Database-Name
		$resourceType =  Get-Database-Type
		$softDeletePeriodInDays =  Get-Soft-Delete-Period-In-Days
		$hotCachePeriodInDays =  Get-Hot-Cache-Period-In-Days
		$databaseFullName = "$clusterName/$databaseName"
		$expectedException = Get-Database-Not-Exist-Message -DatabaseName $databaseName

		#create cluster for the databases
		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku

		#create and remove using ResourceId
		$databaseCreated = New-AzKustoDatabase -ResourceId $clusterCreated.Id -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseGetItem = Get-AzKustoDatabase -ResourceId $clusterCreated.Id -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		Remove-AzKustoDatabase -ResourceId $databaseGetItem.Id
		Ensure_Database_Not_Exist $resourceGroupName $clusterName $databaseName $expectedException

		#create and remove using InputObject
		$cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

		$databaseCreated = New-AzKustoDatabase -InputObject $cluster -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseGetItem = Get-AzKustoDatabase -InputObject $cluster -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		Remove-AzKustoDatabase -InputObject $databaseCreated
		Ensure_Database_Not_Exist $resourceGroupName $clusterName $databaseName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
		
}

function Validate_Database {
	Param ([Object]$Database,
		[string]$DatabaseFullName,
		[string]$Location,
		[string]$Type,
		[int]$SoftDeletePeriodInDays,
		[int]$HotCachePeriodInDays)
		Assert-AreEqual $DatabaseFullName $Database.Name
		Assert-AreEqual $Location $Database.Location
		Assert-AreEqual $ResourceType $Database.Type
		Assert-AreEqual $SoftDeletePeriodInDays $Database.SoftDeletePeriodInDays 
		Assert-AreEqual $HotCachePeriodInDays $Database.HotCachePeriodInDays 
}

function Ensure_Database_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
			[string]$DatabaseName,
		[string]$ExpectedErrorMessage)
		$expectedException = $false;
		try
        {
			$databaseGetItemDeleted = Get-AzKustoDatabase -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -Name $DatabaseName
        }
        catch
        {
            if ($_ -Match $ExpectedErrorMessage)
            {
                $expectedException = $true;
            }
        }
        if (-not $expectedException)
        {
            throw "Expected exception from calling Get-AzKustoDatabase was not caught: '$expectedErrorMessage'.";
        }
}