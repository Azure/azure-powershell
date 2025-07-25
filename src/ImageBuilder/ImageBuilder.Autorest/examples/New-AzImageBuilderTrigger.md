### Example 1: Create or update a trigger for the specified virtual machine image template.
```powershell
New-AzImageBuilderTrigger -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name azps-buildertrigger -Kind "SourceImage"
```

```output
Kind        Name                ProvisioningState ResourceGroupName
----        ----                ----------------- -----------------
SourceImage azps-buildertrigger Succeeded         azps_test_group_imagebuilder
```

Create or update a trigger for the specified virtual machine image template.