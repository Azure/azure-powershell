<#
.SYNOPSIS
Tests Kusto cluster lifecycle (Create, Update, Get, List, Delete).
#>
function Test-KustoDatabaseLifecycle
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = "KustoClientTest"
		$clusterName = "kustopsclienttest"
		$databaseName = "dbTest"
		$resourceType =  "Microsoft.Kusto/Clusters/Databases"
		$softDeletePeriodInDays = 4
		$hotCachePeriodInDays = 2
		$resourceId =   "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName/databases/$databaseName"
		$databaseFullName = "$clusterName/$databaseName"
		
		$softDeletePeriodInDaysUpdated = 6
		$hotCachePeriodInDaysUpdated = 3

		$expectedException = "The Resource 'Microsoft.Kusto/clusters/$clusterName/databases/$databaseName' under resource group '$clusterName' was not found."

		$databaseCreated = New-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		$databaseGetItem = Get-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseUpdatedWithParameters = Update-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDaysUpdated -HotCachePeriodInDays $hotCachePeriodInDaysUpdated
		Validate_Database $databaseUpdatedWithParameters $databaseFullName $location $type $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated;

		$databaseUpdatedWithResourceId = Update-AzureRmKustoDatabase -ResourceId $resourceId -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseUpdatedWithResourceId $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		$databaseUpdatedObject = Update-AzureRmKustoDatabase -InputObject $databaseUpdatedWithResourceId -SoftDeletePeriodInDays $softDeletePeriodInDaysUpdated -HotCachePeriodInDays $hotCachePeriodInDaysUpdated
		Validate_Database $databaseUpdatedObject $databaseFullName $location $type $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated;

		Remove-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName

		try
        {
			$databaseGetItemDeleted = Get-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        }
        catch
        {
            if ($_ -like $expectedErrorMessage)
            {
                $expectedException = $true;
            }
        }
        
        if (-not $expectedException)
        {
            throw "Expected exception from calling Get-AzureRmKustoCluster was not caught: '$expectedErrorMessage'.";
        }
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

<#
.SYNOPSIS
Tests Kusto Add Get and Remove using resourceId and InputObject
#>
function Test-DatabaseAddRemoveGet {
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = "KustoClientTest"
		$clusterName = "kustopsclienttest"
		$databaseName = "dbTest"
		$resourceType =  "Microsoft.Kusto/Clusters/Databases"
		$softDeletePeriodInDays = 4
		$hotCachePeriodInDays = 2
		$clusterResourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName"
		$databaseResourceId = "$clusterResourceId/databases/$databaseName"
		$databaseFullName = "$clusterName/$databaseName"
		$expectedException = "The Resource 'Microsoft.Kusto/clusters/$clusterName/databases/$databaseName' under resource group '$resourceGroupName' was not found."

		#create and remove using ResourceId
		$databaseCreated = New-AzureRmKustoDatabase -ResourceId $clusterResourceId -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseGetItem = Get-AzureRmKustoDatabase -ResourceId $clusterResourceId -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		Remove-AzureRmKustoDatabase -ResourceId $databaseCreated.Id
		Ensure_Database_Exists $resourceGroupName $clusterName $databaseName $expectedException

		#create and remove using InputObject
		$cluster = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

		$databaseCreated = New-AzureRmKustoDatabase -InputObject $cluster -Name $databaseName -SoftDeletePeriodInDays $softDeletePeriodInDays -HotCachePeriodInDays $hotCachePeriodInDays
		Validate_Database $databaseCreated $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;
		
		$databaseGetItem = Get-AzureRmKustoDatabase -InputObject $cluster -Name $databaseName
		Validate_Database $databaseGetItem $databaseFullName $location $type $softDeletePeriodInDays $hotCachePeriodInDays;

		Remove-AzureRmKustoDatabase -InputObject $databaseCreated
		Ensure_Database_Exists $resourceGroupName $clusterName $databaseName $expectedException
		
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

function Ensure_Database_Exists {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
			[string]$DatabaseName,
		[string]$ExpectedErrorMessage)
		$expectedException = $false;
		try
        {
			$databaseGetItemDeleted = Get-AzureRmKustoDatabase -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -Name $DatabaseName
        }
        catch
        {
            if ($_ -like $ExpectedErrorMessage)
            {
                $expectedException = $true;
            }
        }
        if (-not $expectedException)
        {
            throw "Expected exception from calling Get-AzureRmKustoDatabase was not caught: '$expectedErrorMessage'.";
        }

}