[Quickstart: Upload, download, and list blobs by using Azure PowerShell](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-powershell)

# Quickstart: Upload, download, and list blobs by using Azure PowerShell

You will find all the code snippets from the quick start in this Document by section. You should change the names of all resources to avoid conflicts. 

## Sign In To Azure
``` PowerShell
Connect-AzAccount

Get-AzLocation | Select Name
$location = "eastus"

```

## Create a resource group
```PowerShell
$resourceGroup = "myResourceGroup"
New-AzResourceGroup -Name $resourceGroup -Location $location
```

## Create a storage account
```PowerShell
$storageAccount = New-AzStorageAccount -ResourceGroupName $resourceGroup `
  -Name "mystorageaccount" `
  -SkuName Standard_LRS `
  -Location $location `
  -Kind BlobStorage `
  -AccessTier Hot

$stkey = Get-AzStorageAccountKey -Name $storageAccount.Name -ResourceGroupName $resourcegroup 
$ctx = New-AzStorageContext -StorageAccountName $storageAccount.Name -StorageAccountKey $stkey[0].Value

$containerName = "quickstartblobs"
New-AzStorageContainer -Name $containername -Context $ctx -Permission blob

```

## Upload blobs to the container
```PowerShell
# upload a file
Set-AzStorageBlobContent -File "D:\_TestImages\Image001.jpg" `
  -Container $containerName `
  -Blob "Image001.jpg" `
  -Context $ctx 

# upload another file
Set-AzStorageBlobContent -File "D:\_TestImages\Image002.png" `
  -Container $containerName `
  -Blob "Image002.png" `
  -Context $ctx
  ```

## List the blobs in a container
```PowerShell
Get-AzStorageBlob -Container $ContainerName -Context $ctx | select Name
```

## Download blobs
```PowerShell
# download first blob
Get-AzStorageBlobContent -Blob "Image001.jpg" `
  -Container $containerName `
  -Destination "D:\_TestImages\Downloads\" `
  -Context $ctx 

# download another blob
Get-AzStorageBlobContent -Blob "Image002.png" `
  -Container $containerName `
  -Destination "D:\_TestImages\Downloads\" `
  -Context $ctx
```

## Clean up resouorces
```PowerShell
Remove-AzResourceGroup -Name $resourceGroup
```