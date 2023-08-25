### Example 1: Cancel the long running image build based on the image template.
```powershell
Stop-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder
```

Cancel the long running image build based on the image template.

### Example 2: Cancel the long running image build based on the image template.
```powershell
Get-AzImageBuilderTemplate -Name azps-ibt-2 -ResourceGroupName azps_test_group_imagebuilder | Stop-AzImageBuilderTemplate
```

Cancel the long running image build based on the image template.