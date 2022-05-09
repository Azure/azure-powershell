### Example 1: Create an application insights linked storage account
```powershell
PS C:\> $account = Get-AzStorageAccount -ResourceGroupName "rgName" -Name "accountName"
PS C:\> Get-AzApplicationInsights -ResourceGroupName "rgName" -Name "componentName" | New-AzApplicationInsightsLinkedStorageAccount -LinkedStorageAccountResourceId $account.Id
```

Create linked storage account $account under component "componentName"

