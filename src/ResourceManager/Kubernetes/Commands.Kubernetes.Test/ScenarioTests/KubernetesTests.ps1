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

		$cluster = New-AzureRmKubernetes -ResourceGroupName $resourceGroupName -Name $kubeClusterName
		$cluster | Set-AzureRmKubernetes -NodeCount 2
		$cluster | Import-AzureRmKubernetesCredential
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
    }
}