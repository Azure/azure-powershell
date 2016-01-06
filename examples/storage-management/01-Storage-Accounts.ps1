Param(
  [string]$rgname,
  [string]$resourceGroupLocation
)
Write-Host "=== Managing Storage Accounts Resources in Azure ==="

$stoname = 'sto' + $rgname;
$stotype = 'Standard_GRS';
$loc = 'West US';

New-AzureRmResourceGroup -Name $rgname -Location $resourceGroupLocation;

Write-Host "1. Create a new storage account"
New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

Write-Host "2. Get info of a storage account"
$stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

Write-Host "3. Update storage account type"
$stotype = 'Standard_RAGRS';
Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

Write-Host "4. Get account key of a storage account"
$stokeys=Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

Write-Host "5. Renew key1 of a storage account"
New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;

Write-Host "6. Renew key2 of a storage account"        
New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

Write-Host "7. Remove storage account"
Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;