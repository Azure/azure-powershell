Param(
  [string]$resourceGroupName,
  [string]$resourceGroupLocation
)

Write-Host "=== Managing Resource Groups in Azure ==="

Write-Host "1. Create a new resource group"
New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation

Write-Host "2. Update group tags"
Set-AzureRmResourceGroup -Name $resourceGroupName -Tags @{Name = "testtag"; Value = "testval"} 

Write-Host "3. Get information about resource group"
$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName
Write-Host $resourceGroup

Write-Host "4. List all resource groups in the subscription"
Get-AzureRmResourceGroup

Write-Host "5. Remove resource group"
Remove-AzureRmResourceGroup -Name $resourceGroupName -Force

Write-Host "6. Validations"
Assert-AreEqual $resourceGroup.ResourceGroupName $resourceGroupName