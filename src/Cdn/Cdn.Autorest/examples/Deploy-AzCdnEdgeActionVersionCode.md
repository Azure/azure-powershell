### Example 1: Deploy code to an EdgeAction version
```powershell
Deploy-AzCdnEdgeActionVersionCode -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Version v1 -Name edge_action.js -Content "Y29uc29sZS5sb2coJ0hlbGxvJyk7"
```

Deploys version code content to the specified EdgeAction version.
