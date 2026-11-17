### Example 1: Disable automatic change data capture extension upgrades
```powershell
Update-AzHorizonDbChangeDataCaptureCapability -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -AutoUpgradeExtension:$false | Format-List -Property Name, DesiredState, EffectiveState, AutoUpgradeExtension, ProvisioningState
```

```output
Name                 : default
DesiredState         : Enabled
EffectiveState       : Enabled
AutoUpgradeExtension : False
ProvisioningState    : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
