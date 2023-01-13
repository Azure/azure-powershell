### Example 1: Stop image template creation
```powershell
Stop-AzImageBuilderTemplate -Name bez-test-img-temp12 -ResourceGroupName bez-rg
```

This command stops image template creation.

### Example 2: Stop image template creation
```powershell
Get-AzImageBuilderTemplate -Name bez-test-img-temp12 -ResourceGroupName bez-rg | Stop-AzImageBuilderTemplate
```

This command stops image template creation.


