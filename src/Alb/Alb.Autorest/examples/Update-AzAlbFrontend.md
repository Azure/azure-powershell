### Example 1: Update Application Gateway for Containers frontend resource with tag
```powershell
Update-AzAlbFrontend -Name test-frontend -AlbName test-alb -ResourceGroupName test-rg -Tag @{TestTag="Test tag value"}
```

This command updates tag values for an Application Gateway for Containers frontend resource.
