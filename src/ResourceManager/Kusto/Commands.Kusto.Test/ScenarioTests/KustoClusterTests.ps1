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

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$clusterCreated = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Validate_Cluster $clusterCreated $clusterName $resourceGroupName  $location  "Running" "Succeeded" $resourceType $sku;
	
		[array]$clusterGet = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName
		$clusterGetItem = $clusterGet[0]
		Validate_Cluster $clusterGetItem $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku;

		$updatedCluster = Update-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedCluster $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku;

		Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
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

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		#create and remove cluster using parameters
		New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException

		#create and remove cluster using ResourceId
		$createdCluster = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -ResourceId $createdCluster.Id
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException

		#create and remove cluster using InputObject
		$createdCluster = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -InputObject $createdCluster
		Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
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

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation

		$validNameResult = Test-AzureRmKustoClusterName -Name $clusterName -Location $location
		Assert-True{$validNameResult.NameAvailable}

		New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku

		$takenNameResult = Test-AzureRmKustoClusterName -Name $clusterName -Location $location
		Assert-False{$takenNameResult.NameAvailable}
		Assert-AreEqual $failureMessage $takenNameResult.Message
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}

function Test-KustoClusterUpdate{
	
	try
	{	
		$subscription = Get-Subscription
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku
		$updatedSku = Get-Updated-Sku
		$resourceType =  Get-Cluster-Resource-Type

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku

		#Test update with parameters
		$updatedClusterWithParameters = Update-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedClusterWithParameters $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku;

		#Test update with ResourceId
		$updatedWithResourceId = Update-AzureRmKustoCluster -ResourceId $updatedClusterWithParameters.Id -SkuName $sku -Tier "standard"
		Validate_Cluster $updatedWithResourceId $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku ;
		
		#Test update with InputObject
		$updatedClusterWithInputObject = Update-AzureRmKustoCluster -InputObject $updatedWithResourceId -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedClusterWithInputObject $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku;
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}

}

function Test-KustoClusterSuspendResume{
	try
	{
		$subscription = Get-Subscription
		$RGlocation = Get-RG-Location
		$location = Get-Cluster-Location
		$resourceGroupName = Get-RG-Name
		$clusterName = Get-Cluster-Name
		$sku = Get-Sku

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		$clusterCreated = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
	
		#Suspend and resume cluster using parameters
		Suspend-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$suspendedClusterWithParameters  = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithParameters $clusterName $resourceGroupName  $suspendedClusterWithParameters.Location "Stopped" "Succeeded" $suspendedClusterWithParameters.Type $suspendedClusterWithParameters.Sku;

		Resume-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$runningClusterWithParameters = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithParameters $clusterName $resourceGroupName  $runningClusterWithParameters.Location "Running" "Succeeded" $runningClusterWithParameters.Type $runningClusterWithParameters.Sku;

		#Suspend and resume cluster using ResourceId
		Suspend-AzureRmKustoCluster -ResourceId $runningClusterWithParameters.Id
		$suspendedClusterWithResourceId = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithResourceId $clusterName $resourceGroupName  $suspendedClusterWithResourceId.Location "Stopped" "Succeeded" $suspendedClusterWithResourceId.Type $suspendedClusterWithResourceId.Sku;

		Resume-AzureRmKustoCluster -ResourceId $suspendedClusterWithResourceId.Id
		$runningClusterWithResourceId = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithResourceId $clusterName $resourceGroupName  $runningClusterWithResourceId.Location "Running" "Succeeded" $suspendedClusterWithResourceId.Type $runningClusterWithResourceId.Sku;

		#Suspend and resume cluster using InputObject
		Suspend-AzureRmKustoCluster -InputObject $runningClusterWithResourceId
		$suspendedClusterWithInputObject = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithInputObject $clusterName $resourceGroupName  $suspendedClusterWithInputObject.Location "Stopped" "Succeeded" $suspendedClusterWithInputObject.Type $suspendedClusterWithInputObject.Sku;

		Resume-AzureRmKustoCluster -InputObject $runningClusterWithResourceId
		$runningClusterWithInputObject = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithInputObject $clusterName $resourceGroupName  $runningClusterWithInputObject.Location "Running" "Succeeded" $runningClusterWithInputObject.Type $runningClusterWithInputObject.Sku;
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
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
		[string]$Sku)
	Assert-AreEqual $ClusterName $Cluster.Name
	Assert-AreEqual $ResourceGroup $Cluster.ResourceGroup
	Assert-AreEqual $Location $Cluster.Location
	Assert-AreEqual $State $Cluster.State
	Assert-AreEqual $ProvisioningState $Cluster.ProvisioningState
	Assert-AreEqual $ResourceType $Cluster.Type
	Assert-AreEqual $Sku $Cluster.Sku 
}

function Ensure_Cluster_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
		[string]$ExpectedErrorMessage)
		$expectedException = $false;
		try
        {
			$databaseGetItemDeleted = Get-AzureRmKustoCluster -ResourceGroupName $ResourceGroupName -Name $ClusterName
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
            throw "Expected exception from calling Get-AzureRmKustoCluster was not caught: '$expectedErrorMessage'.";
        }
}