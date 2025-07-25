### Example 1: Update Application Gateway for Containers resource with tag
```powershell
Update-AzAlb -Name test-alb -ResourceGroupName test-rg -Tag @{TestTag="Test tag value"}
```

This command updates tag values for an Application Gateway for Containers resource.
