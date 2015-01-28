<#
.SYNOPSIS
Tests API Management.
#>
function Test-ApiManagement
{
    # Setup
    # resource group should exists
    $resourceGroupName = "MyResourceGroup"
    $apiManagementName = "powershelltest"
    $location = "North Central US"

    # Add Azure Storage Context
    
    $azureStorageContext = New-AzureStorageContext -StorageAccountKey IvlL0RhwGDEY+EvGGIzXVYEdkoP2mexZsZbhsjjkg4InZDEVtmYAFVyUWP/fNjlWKyhRQBKje1eob4zWzV3Ezw== -Protocol https
	
    # Backuping APi Management
    $result = Backup-AzureApiManagement -Name $apiManagementName -StorageContext $azureStorageContext -Container backupContainer -Blob backup.apimbackup
}