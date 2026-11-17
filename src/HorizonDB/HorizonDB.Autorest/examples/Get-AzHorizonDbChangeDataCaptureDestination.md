### Example 1: List change data capture destinations
```powershell
Get-AzHorizonDbChangeDataCaptureDestination -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, DestinationType, DestinationProtocol, DesiredState, EffectiveState, ProvisioningState
```

```output
Name                : fabric-mirroring
DestinationType     : Fabric
DestinationProtocol : Native
DesiredState        : Enabled
EffectiveState      : Enabled
ProvisioningState   : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a Microsoft Fabric destination
```powershell
Get-AzHorizonDbChangeDataCaptureDestination -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' | Format-List -Property Name, DestinationType, DestinationProtocol, DesiredState, EffectiveState, ProvisioningState
```

```output
Name                : fabric-mirroring
DestinationType     : Fabric
DestinationProtocol : Native
DesiredState        : Enabled
EffectiveState      : Enabled
ProvisioningState   : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
