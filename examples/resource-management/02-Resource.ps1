Param(
  [string]$groupName,
  [string]$location,
  [string]$rName,
)

Write-Host "=== Managing Resources in Azure ==="

Write-Host "1. Creating a new resource group"
New-AzureRmResourceGroup -Name $groupName -Location $location
$destinationGroupName = $groupName + "Destination"

Write-Host "2. Registering Resource Provider Namespace."
$providerNamespace="Providers.Test"
Register-AzureRmResourceProvider -ProviderNamespace $providerNamespace -Force

Write-Host "3. Creating a new Resource"
$resourceType = $providerNamespace + "/statefulResources"
$apiversion="2014-04-01"
New-AzureRmResource -Name $rName -Location $location -Tags @{Name = "testtag"; Value = "testval"} -ResourceGroupName $groupName -ResourceType $resourceType -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion -Force

Write-Host "4. Get information about Resource"
$resourceInfo = Get-AzureRmResource -ResourceGroupName $groupName
Write-Host "Validating Resource name"
Assert-AreEqual $rName $resourceInfo.Name

Write-Host "5. Find Resource with name"
$foundResource = Find-AzureRmResource -ResourceType $resourceType -ResourceNameContains $rName
Write-Host "Validating Resource name"
Assert-AreEqual $rName $foundResource.Name

Write-Host "6. Update Resource" 
Set-AzureRmResource -ResourceGroupName $groupName -ResourceName $rName -ResourceType $resourceType -Tags @{Name = "testtagUpdated"; Value = "testvalueUpdated"} -Force

Write-Host "7. Move Resource to resource group"
New-AzureRmResourceGroup -Name $destinationGroupName -Location $location
Move-AzureRmResource -DestinationResourceGroupName  $destinationGroupName -ResourceId $resourceInfo.ResourceId  -Force

Write-Host "8. Removing resource"
$foundResource = Find-AzureRmResource -ResourceType $resourceType -ResourceNameContains $rName
Remove-AzureRmResource -ResourceId $foundResource.ResourceId -Force