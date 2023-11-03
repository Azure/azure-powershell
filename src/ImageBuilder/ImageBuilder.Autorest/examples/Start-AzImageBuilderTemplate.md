### Example 1: Create artifacts from a existing image template.
```powershell
Start-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder
```

Create artifacts from a existing image template.

### Example 2: Create artifacts from a existing image template.
```powershell
Get-AzImageBuilderTemplate -Name azps-ibt-2 -ResourceGroupName azps_test_group_imagebuilder | Start-AzImageBuilderTemplate
```

Create artifacts from a existing image template.