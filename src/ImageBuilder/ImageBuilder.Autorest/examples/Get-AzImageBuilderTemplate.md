### Example 1: List information about virtual machine image template by SubscriptionId.
```powershell
Get-AzImageBuilderTemplate
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
eastus   azps-ibt-2 azps_test_group_imagebuilder
eastus   azps-ibt-3 azps_test_group_imagebuilder
```

List information about virtual machine image template by SubscriptionId.

### Example 2: List information about virtual machine image template by ResourceGroupName.
```powershell
Get-AzImageBuilderTemplate -resourceGroupName azps_test_group_imagebuilder
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
eastus   azps-ibt-2 azps_test_group_imagebuilder
eastus   azps-ibt-3 azps_test_group_imagebuilder
```

List information about virtual machine image template by ResourceGroupName.

### Example 3: Get information about a virtual machine image template by Name.
```powershell
Get-AzImageBuilderTemplate -resourceGroupName azps_test_group_imagebuilder -Name azps-ibt-1
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
```

Get information about a virtual machine image template by Name.