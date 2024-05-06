### Example 1: Delete HealthBot by ResourceGroupName and Name
```powershell
Remove-AzHealthBot -Name yourihealthbot -ResourceGroupName youriTest
```

Delete HealthBot by ResourceGroupName and Name

### Example 2: Delete HealthBot by InputObject
```powershell
$gethealthbot = Get-AzHealthBot -Name yourihealthbot1 -ResourceGroupName youriTest
Remove-AzHealthBot -InputObject $gethealthbot
```

Delete HealthBot by InputObject
