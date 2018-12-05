<#
.SYNOPSIS
Tests Kusto cluster lifecycle (Create, Get, List, Delete).
#>
function Test-KustoClusterLifecycle
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = "KustoPSClientTestRG"
		$clusterName = "psclusterclienttest"
		$sku = "D13_v2"
		$updatedSku = "D14_v2"
		$resourceType =  "Microsoft.Kusto/Clusters"
		$expectedException = $expectedException = "The Resource 'Microsoft.Kusto/clusters/$clusterName' under resource group '$resourceGroupName' was not found."
		$resourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName"

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$clusterCreated = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Validate_Cluster $clusterCreated $clusterName $resourceGroupName  $location  "Running" "Succeeded" $resourceType $sku $resourceId;
	
		[array]$clusterGet = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName
		$clusterGetItem = $clusterGet[0]
		Validate_Cluster $clusterGetItem $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $resourceId;

		$updatedCluster = Update-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -SkuName $sku -Tier "standard"
		Validate_Cluster $updatedCluster $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $resourceId;

		Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Ensure_Cluster_Exists $resourceGroupName $clusterName $expectedException
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}
function Test-KustoClusterRemove
{
		$location = Get-Location
		$resourceGroupName = "KustoPSClientTest"
		$clusterName = "psclienttestdelete"
		$sku = "D13_v2"
		$resourceType =  "Microsoft.Kusto/Clusters"
		$resourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName"
		$expectedException = "The Resource 'Microsoft.Kusto/clusters/$clusterName' under resource group '$resourceGroupName' was not found."

		
		#create and remove cluster using parameters
		New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Ensure_Cluster_Exists $resourceGroupName $clusterName $expectedException

		#create and remove cluster using ResourceId
		New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -ResourceId $resourceId
		Ensure_Cluster_Exists $resourceGroupName $clusterName $expectedException

		#create and remove cluster using InputObject
		$createdCluster = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
		Remove-AzureRmKustoCluster -InputObject $createdCluster
		Ensure_Cluster_Exists $resourceGroupName $clusterName $expectedException
}

function Test-KustoClusterName
{
		# Creating capacity
		$location = Get-Location
		$validClusterName = "newpsclienttest"
		$takenClusterName = "psclienttest"
		$failureMessage = "Name '$takenClusterName' with type Engine is already taken. Please specify a different name"

		$takenNameResult = Test-AzureRmKustoClusterName -Name $takenClusterName -Location $location
		Assert-False{$takenNameResult.NameAvailable}
		Assert-AreEqual $failureMessage $takenNameResult.Message

		$validNameResult = Test-AzureRmKustoClusterName -Name $validClusterName -Location $location
		Assert-True{$validNameResult.NameAvailable}
}

function Test-KustoClusterUpdate{
	# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = "KustoClientTest"
		$clusterName = "kustopsclienttest"
		$sku = "D13_v2"
		$updatedSku = "D14_v2"
		$resourceType =  "Microsoft.Kusto/Clusters"
		$resourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName"
		
		#Test update with parameters
		$updatedClusterWithParameters = Update-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedClusterWithParameters $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku $resourceId;

		#Test update with ResourceId
		$updatedWithResourceId = Update-AzureRmKustoCluster -ResourceId $resourceId -SkuName $sku -Tier "standard"
		Validate_Cluster $updatedWithResourceId $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $sku $resourceId;
		
		#Test update with InputObject
		$updatedClusterWithInputObject = Update-AzureRmKustoCluster -InputObject $updatedWithResourceId -SkuName $updatedSku -Tier "standard"
		Validate_Cluster $updatedClusterWithInputObject $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSku $resourceId;
}

function Test-KustoClusterSuspendResume{
		$resourceGroupName = "KustoClientTest"
		$clusterName = "kustopsclienttest"
		$resourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/$resourceGroupName/providers/Microsoft.Kusto/clusters/$clusterName"

		#Suspend and resume cluster using parameters
		Suspend-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$suspendedClusterWithParameters  = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithParameters $clusterName $resourceGroupName  $suspendedClusterWithParameters.Location "Stopped" "Succeeded" $suspendedClusterWithParameters.Type $suspendedClusterWithParameters.Sku $resourceId;

		Resume-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName 
		$runningClusterWithParameters = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithParameters $clusterName $resourceGroupName  $runningClusterWithParameters.Location "Running" "Succeeded" $runningClusterWithParameters.Type $runningClusterWithParameters.Sku $resourceId;

		#Suspend and resume cluster using ResourceId
		Suspend-AzureRmKustoCluster -ResourceId $resourceId
		$suspendedClusterWithResourceId = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithResourceId $clusterName $resourceGroupName  $suspendedClusterWithResourceId.Location "Stopped" "Succeeded" $suspendedClusterWithResourceId.Type $suspendedClusterWithResourceId.Sku $resourceId;

		Resume-AzureRmKustoCluster -ResourceId $resourceId
		$runningClusterWithResourceId = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithResourceId $clusterName $resourceGroupName  $runningClusterWithResourceId.Location "Running" "Succeeded" $suspendedClusterWithResourceId.Type $runningClusterWithResourceId.Sku $resourceId;

		#Suspend and resume cluster using InputObject
		Suspend-AzureRmKustoCluster -InputObject $runningClusterWithResourceId
		$suspendedClusterWithInputObject = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $suspendedClusterWithInputObject $clusterName $resourceGroupName  $suspendedClusterWithInputObject.Location "Stopped" "Succeeded" $suspendedClusterWithInputObject.Type $suspendedClusterWithInputObject.Sku $resourceId;

		Resume-AzureRmKustoCluster -InputObject $runningClusterWithResourceId
		$runningClusterWithInputObject = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		Validate_Cluster $runningClusterWithInputObject $clusterName $resourceGroupName  $runningClusterWithInputObject.Location "Running" "Succeeded" $runningClusterWithInputObject.Type $runningClusterWithInputObject.Sku $resourceId;

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
		[string]$ClusterId)
	Assert-AreEqual $ClusterName $Cluster.Name
	Assert-AreEqual $ResourceGroup $Cluster.ResourceGroup
	Assert-AreEqual $Location $Cluster.Location
	Assert-AreEqual $State $Cluster.State
	Assert-AreEqual $ProvisioningState $Cluster.ProvisioningState
	Assert-AreEqual $ResourceType $Cluster.Type
	Assert-AreEqual $Sku $Cluster.Sku 
	Assert-AreEqual $ClusterId $Cluster.Id
}

function Ensure_Cluster_Exists {
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