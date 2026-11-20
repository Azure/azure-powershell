### Example 1: Create a Microsoft Fabric change data capture destination
```powershell
$body = @{
    properties = @{
        destination = @{
            destinationType = 'Fabric'
            protocol = 'Native'
            workspaceId = 'aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee'
        }
        desiredState = 'Enabled'
    }
} | ConvertTo-Json -Depth 5

New-AzHorizonDbChangeDataCaptureDestination -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -JsonString $body | Format-List -Property Name, DestinationType, DestinationProtocol, DesiredState, EffectiveState, ProvisioningState
```

```output
Name                : fabric-mirroring
DestinationType     : Fabric
DestinationProtocol : Native
DesiredState        : Enabled
EffectiveState      : WaitingForIdentity
ProvisioningState   : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
