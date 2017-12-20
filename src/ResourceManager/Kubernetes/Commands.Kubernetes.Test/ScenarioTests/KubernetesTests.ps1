<#
.SYNOPSIS
Test Kubernetes stuff
#>
function Test-AzureRmKubernetes
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $registryName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"

    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
    }
}