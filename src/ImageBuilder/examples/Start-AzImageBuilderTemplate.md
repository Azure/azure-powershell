### Example 1: Start an image template
```powershell
Start-AzImageBuilderTemplate -Name bez-test-img-temp12 -ResourceGroupName bez-rg
```

```output
Id     Name            PSJobTypeName   State         HasMoreData     Location             Command
--     ----            -------------   -----         -----------     --------             -------
1      Start-AzImageB…                 Running       True            localhost            Start-AzImageBuilderTemp…
```

This command starts an image template.

### Example 2: Start an image template
```powershell
Get-AzImageBuilderTemplate -Name bez-test-img-temp12 -ResourceGroupName bez-rg | Start-AzImageBuilderTemplate
```

This command starts an image template.

