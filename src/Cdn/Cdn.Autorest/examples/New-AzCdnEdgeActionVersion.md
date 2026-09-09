### Example 1: Create an EdgeAction version
```powershell
New-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Version v1 -Location global -DeploymentType zip -IsDefaultVersion True
```

Creates a version for the specified EdgeAction.
