### Example 1: Delete linked storage account associated with application insights component "componentName"
```powershell
PS C:\> Get-AzApplicationInsights -ResourceGroupName "rgName" -Name "componentName" | Remove-AzApplicationInsightsLinkedStorageAccount
```

Delete linked storage account associated with application insights component "componentName"