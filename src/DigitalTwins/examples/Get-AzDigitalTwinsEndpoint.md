### Example 1: List AzDigitalTwinsEndpoint in ResourceGroup
```powershell
Get-AzDigitalTwinsEndpoint -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest
```

```output
Name                     Type
----                     ----
youriDigitalTwinEndpoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

List all AzDigitalTwinsEndpoints by ResourceGroupName

### Example 2: Get AzDigitalTwinsEndpoint by EndpointName
```powershell
Get-AzDigitalTwinsEndpoint -EndpointName youriDigitalTwinEndpoint -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest
```

```output
Name                     Type
----                     ----
youriDigitalTwinEndpoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Get AzDigitalTwinsEndpoint by EndpointName in ResourceGroup

### Example 3: Get AzDigitalTwinsEndpoint by 'AzDigitalTwinsEndpoint' Object
```powershell
$GetAzDigitalTwinsEndpoint = Get-AzDigitalTwinsEndpoint -EndpointName youriDigitalTwinEndpoint -ResourceGroupName youritemp -ResourceName youriDigitalTwinsTest
Get-AzDigitalTwinsEndpoint -InputObject $GetAzDigitalTwinsEndpoint
```

```output
Name                     Type
----                     ----
youriDigitalTwinEndpoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Get AzDigitalTwinsEndpoint by 'AzDigitalTwinsEndpoint' Object