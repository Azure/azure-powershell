<#
.SYNOPSIS
Tests Kusto cluster lifecycle (Create, Get, List, Delete).
#>
function Test-KustoClusterLifecycle
{
	try
	{  
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$updatedSku = Get-Updated-Sku
		$resourceType =  Get-Cluster-Resource-Type
		$expectedException = Get-Cluster-Not-Exist-Message -ResourceGroupName $resourceGroupName -ClusterName $clusterName 
		$capacity = Get-Cluster-Default-Capacity

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation

		$clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Validate_Cluster $clusterCreated $clusterName $resourceGroupName  $location  "Running" "Succeeded" $resourceType $sku $capacity
	
		[array]$clusterGet = Get-AzKustoCluster -ResourceGroupName $resourceGroupName
		$clusterGetItem = $clusterGet[0]
		Validate_Cluster $clusterGetItem $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $capacity

		$updatedCluster = Update-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedCluster $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku $capacity

		Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-KustoClusterRemove
{
	try
	{ 
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$resourceType =  Get-Cluster-Resource-Type
		$expectedException = Get-Cluster-Not-Exist-Message -ResourceGroupName $resourceGroupName -ClusterName $clusterName 

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		#create and remove cluster using parameters
		New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName		
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException

		#create and remove cluster using ResourceId
		$createdCluster = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzKustoCluster -ResourceId $createdCluster.Id
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException

		#create and remove cluster using InputObject
		$createdCluster = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzKustoCluster -InputObject $createdCluster
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-KustoClusterName
{
	try
	{ 
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		
		$failureMessage = Get-Cluster-Name-Exists-Message -ClusterName $clusterName

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation

		$validNameResult = Test-AzKustoClusterName -Name $clusterName -Location $location
		Assert-True{$validNameResult.NameAvailable}

		New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku

		$takenNameResult = Test-AzKustoClusterName -Name $clusterName -Location $location
		Assert-False{$takenNameResult.NameAvailable}
		Assert-AreEqual $failureMessage $takenNameResult.Message
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-KustoClusterUpdate{
	try
	{	
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$updatedSku = Get-Updated-Sku
		$resourceType =  Get-Cluster-Resource-Type
		$capacity = Get-Cluster-Capacity
		$updatedCapacity = Get-Cluster-Updated-Capacity

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku -Capacity $capacity
		Validate_Cluster $clusterCreated $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $capacity


		#Test update with parameters
		$updatedClusterWithParameters = Update-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedClusterWithParameters $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku $capacity

		#Test update with ResourceId
		$updatedWithResourceId = Update-AzKustoCluster -ResourceId $updatedClusterWithParameters.Id -SkuName $sku -Tier "standard" -Capacity $updatedCapacity
		Validate_Cluster $updatedWithResourceId $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $updatedCapacity
		
		#Test update with InputObject
		$updatedClusterWithInputObject = Update-AzKustoCluster -InputObject $updatedWithResourceId -SkuName $updatedSku -Tier "standard" -Capacity $capacity
		Validate_Cluster $updatedClusterWithInputObject $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku $capacity
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}

}

function Test-KustoClusterSuspendResume{
	try
	{
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$capacity = Get-Cluster-Default-Capacity

		New-AzResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
	
		#Suspend and resume cluster using parameters
		Suspend-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$suspendedClusterWithParameters  = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithParameters $clusterName $resourceGroupName  $suspendedClusterWithParameters.Location "Stopped" "Succeeded" $suspendedClusterWithParameters.Type $suspendedClusterWithParameters.Sku $suspendedClusterWithParameters.Capacity

		Resume-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$runningClusterWithParameters = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithParameters $clusterName $resourceGroupName  $runningClusterWithParameters.Location "Running" "Succeeded" $runningClusterWithParameters.Type $runningClusterWithParameters.Sku $runningClusterWithParameters.Capacity

		#Suspend and resume cluster using ResourceId
		Suspend-AzKustoCluster -ResourceId $runningClusterWithParameters.Id
		$suspendedClusterWithResourceId = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithResourceId $clusterName $resourceGroupName  $suspendedClusterWithResourceId.Location "Stopped" "Succeeded" $suspendedClusterWithResourceId.Type $suspendedClusterWithResourceId.Sku $suspendedClusterWithResourceId.Capacity

		Resume-AzKustoCluster -ResourceId $suspendedClusterWithResourceId.Id
		$runningClusterWithResourceId = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithResourceId $clusterName $resourceGroupName  $runningClusterWithResourceId.Location "Running" "Succeeded" $suspendedClusterWithResourceId.Type $runningClusterWithResourceId.Sku $runningClusterWithResourceId.Capacity

		#Suspend and resume cluster using InputObject
		Suspend-AzKustoCluster -InputObject $runningClusterWithResourceId
		$suspendedClusterWithInputObject = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithInputObject $clusterName $resourceGroupName  $suspendedClusterWithInputObject.Location "Stopped" "Succeeded" $suspendedClusterWithInputObject.Type $suspendedClusterWithInputObject.Sku $suspendedClusterWithInputObject.Capacity

		Resume-AzKustoCluster -InputObject $runningClusterWithResourceId
		$runningClusterWithInputObject = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithInputObject $clusterName $resourceGroupName  $runningClusterWithInputObject.Location "Running" "Succeeded" $runningClusterWithInputObject.Type $runningClusterWithInputObject.Sku $runningClusterWithInputObject.Capacity
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Validate_Cluster{
	Param ([Object]$Cluster,
		[string]$ClusterName,
		[string]$ResourceGroup,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
		[string]$Sku,
		[int]$Capacity)
	Assert-AreEqual $ClusterName $Cluster.Name
	Assert-AreEqual $ResourceGroup $Cluster.ResourceGroup
	Assert-AreEqual $Location $Cluster.Location
	Assert-AreEqual $State $Cluster.State
	Assert-AreEqual $ProvisioningState $Cluster.ProvisioningState
	Assert-AreEqual $ResourceType $Cluster.Type
	Assert-AreEqual $Sku $Cluster.Sku 
	Assert-AreEqual $Capacity $Cluster.Capacity 
}

function Ensure_Cluster_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
		[string]$ExpectedErrorMessage)
		$expectedException = $false
		try
        {
			$databaseGetItemDeleted = Get-AzKustoCluster -ResourceGroupName $ResourceGroupName -Name $ClusterName
        }
        catch
        {
            if ($_ -Match $ExpectedErrorMessage)
            {
                $expectedException = $true
            }
        }
        if (-not $expectedException)
        {
            throw "Expected exception from calling Get-AzKustoCluster was not caught: '$expectedErrorMessage'."
        }
}