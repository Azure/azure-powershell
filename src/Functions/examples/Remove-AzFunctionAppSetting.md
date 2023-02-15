### Example 1: Remove app settings in a function app.

```powershell
Remove-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName -AppSettingName "MyAppSetting1", "MyAppSetting2"
```

This command removes app settings in a function app.