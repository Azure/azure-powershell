### Example 1: List the specified run output for the specified image template resource by ImageTemplateName.
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
runoutput-01 Succeeded         azps_test_group_imagebuilder
```

List the specified run output for the specified image template resource by ImageTemplateName.

### Example 2: Get the specified run output for the specified image template resource by Name.
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name runoutput-01
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
runoutput-01 Succeeded         azps_test_group_imagebuilder
```

Get the specified run output for the specified image template resource by Name.