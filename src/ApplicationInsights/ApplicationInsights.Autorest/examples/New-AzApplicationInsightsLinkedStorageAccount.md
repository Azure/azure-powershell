### Example 1: Create an application insights linked storage account
```powershell
$account = Get-AzStorageAccount -ResourceGroupName "rgName" -Name "accountName"
New-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName "rgName" -Name "componentName" -LinkedStorageAccountResourceId $account.Id
```

Create linked storage account $account under component "componentName"

