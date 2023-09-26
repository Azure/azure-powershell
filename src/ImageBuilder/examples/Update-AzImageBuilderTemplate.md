### Example 1: Update the tags for this Virtual Machine Image Template.
```powershell
Update-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Tag @{"123"="abc"}
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
```

Update the tags for this Virtual Machine Image Template.

### Example 2: Update the tags for this Virtual Machine Image Template.
```powershell
Get-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder | Update-AzImageBuilderTemplate -Tag @{"123"="abc"}
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
```

Update the tags for this Virtual Machine Image Template.