### Example 1: Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction
```powershell
$originGroupId = "xxxx"
New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name RouteConfigurationOverride -OriginGroupOverrideForwardingProtocol HttpOnly -OriginGroupId $originGroupId
```

```output
Name
----
RouteConfigurationOverride
```

Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction
