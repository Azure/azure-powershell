<#
.SYNOPSIS
Tests API Management.
#>
function Test-NewApiManagement
{
    # Setup
    # resource group should exists
    $resourceGroupName = "Api-Default-North-East"
    $apiManagementName = "apimpowershelltest"
    $location = "North East"
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Standard"

    # Create API Management service
    $result = New-AzureApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku

    Assert-AreEqual $resourceGroupName $result.ResourceGroupName
    Assert-AreEqual $apiManagementName $result.Name
    Assert-AreEqual $location $result.Location
    Assert-AreEqual $organization $result.Organization
    Assert-AreEqual $adminEmail $result.AdminEmail
    Assert-AreEqual $sku $result.Sku
    Assert-AreEqual 1 $result.Capacity

    # List 
}