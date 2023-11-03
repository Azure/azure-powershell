### Example 1: List the specified trigger for the specified image template resource by ImageTemplateName.
```powershell
Get-AzImageBuilderTrigger -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder
```

```output
Kind        Name                ProvisioningState ResourceGroupName
----        ----                ----------------- -----------------
SourceImage azps-buildertrigger Succeeded         azps_test_group_imagebuilder
```

List the specified trigger for the specified image template resource by ImageTemplateName.

### Example 2: Get the specified trigger for the specified image template resource by Name.
```powershell
Get-AzImageBuilderTrigger -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name azps-buildertrigger
```

```output
Kind        Name                ProvisioningState ResourceGroupName
----        ----                ----------------- -----------------
SourceImage azps-buildertrigger Succeeded         azps_test_group_imagebuilder
```

Get the specified trigger for the specified image template resource by Name.