### Example 1: Add a new app setting in a function app.

```powershell
Update-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName -AppSetting @{"Name1" = "Value1"}
```

This command adds a new app setting in a function app.
