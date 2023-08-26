### Example 1: Update Application Gateway for Containers association resource with tag
```powershell
Update-AzAlbAssociation -Name test-association -AlbName test-alb -ResourceGroupName test-rg -Tag @{TestTag="Test tag value"}
```

This command updates tag values for an Application Gateway for Containers association resource.
