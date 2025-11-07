---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorforwardingconfigurationobject
schema: 2.0.0
---

# New-AzFrontDoorForwardingConfigurationObject

## SYNOPSIS
Create an in-memory object for ForwardingConfiguration.

## SYNTAX

```
New-AzFrontDoorForwardingConfigurationObject [-BackendPoolId <String>]
 [-CacheConfiguration <ICacheConfiguration>] [-CustomForwardingPath <String>] [-ForwardingProtocol <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ForwardingConfiguration.

## EXAMPLES

### Example 1: Create a basic forwarding configuration object
```powershell
New-AzFrontDoorForwardingConfigurationObject -BackendPoolId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool" -ForwardingProtocol "MatchRequest"
```

```output
BackendPoolId        : /subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool
CacheConfiguration   : {
                       }
CustomForwardingPath :
ForwardingProtocol   : MatchRequest
OdataType            : #Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration
```

Create a basic forwarding configuration object that forwards requests to a backend pool using the same protocol as the incoming request.

### Example 2: Create a forwarding configuration object with cache and custom path
```powershell
$cacheConfig = New-AzFrontDoorCacheConfigurationObject -CacheDuration "0.12:00:00" -DynamicCompression "Enabled"
New-AzFrontDoorForwardingConfigurationObject -BackendPoolId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool" -ForwardingProtocol "HttpsOnly" -CustomForwardingPath "/api/v2" -CacheConfiguration $cacheConfig
```

```output
BackendPoolId        : /subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool
CacheConfiguration   : {
                       }
CustomForwardingPath : /api/v2
ForwardingProtocol   : HttpsOnly
OdataType            : #Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration
```

Create a forwarding configuration object with caching enabled, custom forwarding path, and HTTPS-only forwarding protocol.

## PARAMETERS

### -BackendPoolId
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CacheConfiguration
The caching configuration associated with this rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICacheConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomForwardingPath
A custom path used to rewrite resource paths matched by this rule.
Leave empty to use incoming path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardingProtocol
Protocol this rule will use when forwarding traffic to backends.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ForwardingConfiguration

## NOTES

## RELATED LINKS
