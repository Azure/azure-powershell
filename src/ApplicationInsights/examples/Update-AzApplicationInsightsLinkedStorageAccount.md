### Example 1: Update linked storage account
```powershell
$account = Get-AzStorageAccount -ResourceGroupName "rgName" -Name "accountName"
Get-AzApplicationInsights -ResourceGroupName "rgName" -Name "componentName" | Update-AzApplicationInsightsLinkedStorageAccount -LinkedStorageAccountResourceId $account.Id
```

Update linked storage account under component "componentName" to associate with $account

