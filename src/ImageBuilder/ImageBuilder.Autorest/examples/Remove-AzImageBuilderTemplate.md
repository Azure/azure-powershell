### Example 1: Delete a virtual machine image template.
```powershell
Remove-AzImageBuilderTemplate -Name azps-ibt-2 -ResourceGroupName azps_test_group_imagebuilder
```

Delete a virtual machine image template.

### Example 2: Delete a virtual machine image template.
```powershell
Get-AzImageBuilderTemplate -Name azps-ibt-3 -ResourceGroupName azps_test_group_imagebuilder | Remove-AzImageBuilderTemplate
```

Delete a virtual machine image template.