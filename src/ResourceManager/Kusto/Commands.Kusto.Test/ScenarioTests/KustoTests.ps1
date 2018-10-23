<#
.SYNOPSIS
Tests Kusto cluster lifecycle (Create, Update, Get, List, Delete).
#>
function Test-KustoClusterLifecycle
{
	try
	{  
		# Creating capacity
		$RGlocation = Get-RG-Location
		$location = Get-Location
		$resourceGroupName = "TestRg"
		$clusterName = "testCluster"
		$sku = "D13_v2"
		$resourceType =  "Microsoft.Kusto/clusters"

		New-AzureRmResourceGroup -Name $resourceGroupName -Location $RGlocation
		
		$clusterCreated = New-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Sku $sku
    
		Assert-AreEqual $clusterName $clusterCreated.Name
		Assert-AreEqual $location $clusterCreated.Location
		Assert-AreEqual resourceType $clusterCreated.Type
		Assert-AreEqual $sku $clusterCreated.Sku 
		Assert-True {$clusterCreated.Id -like "*$resourceGroupName*"}
	
		[array]$clusterGet = Get-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
		$clusterGetItem = $clusterGet[0]

		Assert-True {$clusterGetItem.State -like "Succeeded"}
		Assert-AreEqual $clusterName $clusterGetItem.Name
		Assert-AreEqual $location $clusterGetItem.Location
		Assert-AreEqual $resourceGroupName $clusterGetItem.ResourceGroup
		Assert-AreEqual $resourceType $clusterGetItem.Type
		Assert-AreEqual $sku $clusterGetItem.Sku 
		Assert-True {$clusterGetItem.Id -like "*$resourceGroupName*"}
	}
	finally
	{
		# cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
		Invoke-HandledCmdlet -Command {Remove-AzureRmKustoCluster -ResourceGroupName $resourceGroupName -Name $capacityName -ErrorAction SilentlyContinue} -IgnoreFailures
		Invoke-HandledCmdlet -Command {Remove-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
	}
}