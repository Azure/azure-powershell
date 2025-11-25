### Example 1: Get a specific frontend endpoint by name
```powershell
Get-AzFrontDoorFrontendEndpoint -ResourceGroupName "myResourceGroup" -FrontDoorName "myFrontDoor" -Name "myFrontDoor-azurefd-net"
```

```output
HostName                         : myFrontDoor-azurefd.net
SessionAffinityEnabledState      : Disabled
SessionAffinityTtlSeconds        : 0
WebApplicationFirewallPolicyLink : 
CustomHttpsProvisioningState     : Enabled
CustomHttpsProvisioningSubstate  : CertificateProvisioned
CertificateSource                : FrontDoor
MinimumTlsVersion                : 1.2
ResourceState                    : Enabled
Id                               : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/frontendEndpoints/myFrontDoor-azurefd-net
Name                             : myFrontDoor-azurefd-net
Type                             : Microsoft.Network/frontDoors/frontendEndpoints
```

Get details of a specific frontend endpoint from the Front Door configuration.
