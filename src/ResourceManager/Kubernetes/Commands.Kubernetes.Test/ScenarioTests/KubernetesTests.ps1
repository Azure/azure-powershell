<#
.SYNOPSIS
Test Kubernetes stuff
#>
function Test-AzureRmKubernetes
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		if (isLive) {
			$cred = $(createTestCredential "Unicorns" "Puppies")
			New-AzureRmKubernetes -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ClientIdAndSecret $cred
		} else {
			New-AzureRmKubernetes -ResourceGroupName $resourceGroupName -Name $kubeClusterName
		}
		$cluster = Get-AzureRmKubernetes -ResourceGroupName $resourceGroupName -Name $kubeClusterName
		$cluster | Set-AzureRmKubernetes -NodeCount 2
		$cluster | Import-AzureRmKubernetesCredential -Force
		$cluster | Remove-AzureRmKubernetes -Force
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
    }
}