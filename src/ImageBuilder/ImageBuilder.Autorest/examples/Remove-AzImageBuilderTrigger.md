### Example 1: Delete a trigger for the specified virtual machine image template.
```powershell
Remove-AzImageBuilderTrigger -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name azps-buildertrigger
```

Delete a trigger for the specified virtual machine image template.

### Example 2: Delete a trigger for the specified virtual machine image template.
```powershell
Get-AzImageBuilderTrigger -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name azps-buildertrigger | Remove-AzImageBuilderTrigger
```

Delete a trigger for the specified virtual machine image template.