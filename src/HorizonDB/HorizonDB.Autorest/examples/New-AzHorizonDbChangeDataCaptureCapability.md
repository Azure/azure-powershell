### Example 1: Enable change data capture with automatic extension upgrades
```powershell
New-AzHorizonDbChangeDataCaptureCapability -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DesiredState 'Enabled' -AutoUpgradeExtension | Format-List -Property Name, DesiredState, EffectiveState, AutoUpgradeExtension, ProvisioningState
```

```output
Name                 : default
DesiredState         : Enabled
EffectiveState       : Enabled
AutoUpgradeExtension : True
ProvisioningState    : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
