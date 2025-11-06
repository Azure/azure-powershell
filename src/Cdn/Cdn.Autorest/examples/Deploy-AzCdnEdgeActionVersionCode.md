### Example 1: Deploy Edge Action Version Code
```powershell
Deploy-AzCdnEdgeActionVersionCode -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Version "v1" -Content "console.log('Hello World');" -Name "main.js"
```

```output
DeploymentType        : zip
IsDefaultVersion      : True
ProvisioningState     : Succeeded
ValidationStatus      : Succeeded
LastPackageUpdateTime : 10/27/2025 10:30:45 AM
```

Deploy code for a specific Edge Action Version
