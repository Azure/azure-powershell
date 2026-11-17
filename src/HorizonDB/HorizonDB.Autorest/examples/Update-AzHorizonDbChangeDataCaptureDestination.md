### Example 1: Disable a change data capture destination
```powershell
Update-AzHorizonDbChangeDataCaptureDestination -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -DesiredState 'Disabled' | Format-List -Property Name, DestinationType, DestinationProtocol, DesiredState, EffectiveState, ProvisioningState
```

```output
Name                : fabric-mirroring
DestinationType     : Fabric
DestinationProtocol : Native
DesiredState        : Disabled
EffectiveState      : Disabled
ProvisioningState   : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
