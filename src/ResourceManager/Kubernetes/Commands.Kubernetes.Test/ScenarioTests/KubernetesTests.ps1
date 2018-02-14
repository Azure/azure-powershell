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
		Assert-NotNull $cluster.Fqdn
		Assert-NotNull $cluster.DnsPrefix
		Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
		Assert-AreEqual "1.8.1" $cluster.KubernetesVersion
		Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
		$cluster = $cluster | Set-AzureRmKubernetes -NodeCount 2
		Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].Count;
		$cluster | Import-AzureRmKubernetesCredential -Force
		$cluster | Remove-AzureRmKubernetes -Force
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
    }
}