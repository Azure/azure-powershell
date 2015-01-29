<#
.SYNOPSIS
Tests API Management.
#>
function Test-NewApiManagement
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $apiManagementName = "apimpowershelltest"
    $location = "North Central US"
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

    $azureStorageContext = New-AzureStorageContext -StorageAccountKey IvlL0RhwGDEY+EvGGIzXVYEdkoP2mexZsZbhsjjkg4InZDEVtmYAFVyUWP/fNjlWKyhRQBKje1eob4zWzV3Ezw== -Protocol https
	
    # Backuping APi Management
    $result = Backup-AzureApiManagement -Name $apiManagementName -StorageContext $azureStorageContext -Container backupContainer -Blob backup.apimbackup