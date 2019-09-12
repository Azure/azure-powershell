### Issues! applicationGateways
- An incredible amount of required parameters/properties that aren't set as required
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -Debug
Body:
{
  "error": {
    "code": "InternalServerError",
    "message": "An error occurred.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy' } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy' } -GatewayIPConfiguration @{ Name = 'gicmy' } -HttpListener @{ Name = 'hlmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "SubnetIsRequired",
    "message": "Subnet reference is required for ipconfiguration /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/gatewayIPConfigurations/gicmy.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy' } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy' } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayFrontendPortInvalidPortNumber",
    "message": "Port specified for FrontendPort /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy is not valid. Supported range is [1, 65502].",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy' } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayBackendHttpSettingsPortIsInvalid",
    "message": "Port specified for BackendHttpSettings /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendHttpSettingsCollection/bhsmy is not valid. Supported range is [1, 65535].",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80 } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayConnectionDrainingTimeoutInvalid",
    "message": "Backend Http Settings /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendHttpSettingsCollection/bhsmy connection draining timeout is invalid. The current value is 0. Supported range is [1, 3600].",
    "details": []
  }
}
New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayHttpListenerMustReference",
    "message": "Http Listener /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy must reference a FrontendIpConfiguration.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayHttpListenerMustReference",
    "message": "Http Listener /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy must reference a FrontendPort.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy'; FrontendPortId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy' } -RequestRoutingRule @{ Name = 'rrrmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayRequestRoutingRuleMustReference",
    "message": "Request Routing Rule /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/requestRoutingRules/rrrmy must reference a HttpListener.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy'; FrontendPortId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy' } -RequestRoutingRule @{ Name = 'rrrmy'; HttpListenerId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayRequestRoutingRuleMustReference",
    "message": "Request Routing Rule /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/requestRoutingRules/rrrmy must reference a BackendAddressPool.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy'; FrontendPortId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy' } -RequestRoutingRule @{ Name = 'rrrmy'; HttpListenerId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy'; BackendAddressPoolId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendAddressPools/bapmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayRequestRoutingRuleMustReference",
    "message": "Request Routing Rule /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/requestRoutingRules/rrrmy must reference a BackendHttpSettings.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy' } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy'; FrontendPortId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy' } -RequestRoutingRule @{ Name = 'rrrmy'; HttpListenerId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy'; BackendAddressPoolId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendAddressPools/bapmy'; BackendHttpSettingId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendHttpSettingsCollection/bhsmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2 -Debug
Body:
{
  "error": {
    "code": "ApplicationGatewayFrontendIpBothPublicIpAddressAndSubnetCannotBeNull",
    "message": "FrontendIpConfiguration /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIPConfigurations/ficmy cannot have both subnet and publicIp as null. Either publicIp or subnet should be specified.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzApplicationGateway -Name agmy -ResourceGroupName rgmy -Location centralus -BackendAddressPool @{ Name = 'bapmy' } -BackendHttpSetting @{ Name = 'bhsmy'; Port = 80; ConnectionDrainingDrainTimeoutInSec = 1; ConnectionDrainingEnabled = $false } -FrontendIPConfiguration @{ Name = 'ficmy'; PublicIPAddressId = $pia.Id } -FrontendPort @{ Name = 'fpmy'; Port = 80 } -GatewayIPConfiguration @{ Name = 'gicmy'; SubnetId = $subnet.Id } -HttpListener @{ Name = 'hlmy'; FrontendIPConfigurationId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendIpConfigurations/ficmy'; FrontendPortId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/frontendPorts/fpmy' } -RequestRoutingRule @{ Name = 'rrrmy'; HttpListenerId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/httpListeners/hlmy'; BackendAddressPoolId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendAddressPools/bapmy'; BackendHttpSettingId = '/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/applicationGateways/agmy/backendHttpSettingsCollection/bhsmy' } -SkuName Standard_Small -SkuTier Standard -SkuCapacity 2

GUID                                 Name Location  SKU Name       Policy Name HTTP2 Enabled FIPS Enabled Operational State Provisioning State
----                                 ---- --------  --------       ----------- ------------- ------------ ----------------- ------------------
caf31968-5ea3-4cea-8991-a90fc80a7d1f agmy centralus Standard_Small                                        Stopped           Updating
```

### DONE applicationSecurityGroups

### DONE azureFirewalls

### FATAL! ddosCustomPolicies
```
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzDdosCustomPolicy -Name dcpmy -ResourceGroupName rgmy -Location centralus
New-AzDdosCustomPolicy : Region centralus is not enabled for DdosCustomPolicy feature.
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzDdosCustomPolicy -Name dcpmy -ResourceGroupName rgmy -Location global
New-AzDdosCustomPolicy : The provided location 'global' is not available for resource type 'Microsoft.Network/ddosCustomPolicies'. List of available regions for the resource type is 'westus,eastus,northeurope,westeurope,eastasia,southeastasia,northcentralus,southcentralus,centralus,eastus2,japaneast,japanwest,brazilsouth,australiaeast,australiasoutheast,centralindia,southindia,westindia,canadacentral,canadaeast,westcentralus,westus2,ukwest,uksouth,koreacentral,koreasouth,francecentral,australiacentral,southafricanorth,uaenorth'.
```

### Changes? ddosProtectionPlans
- Change name to Register/Unregister?
```
Body:
{
  "error": {
    "code": "DdosProtectionPlanCountLimitReached",
    "message": "Cannot create more than 1 DDoS Protection Plans for this subscription in this region.",
    "details": []
  }
}
```

### Issues! expressRouteCircuits
- Needs custom parameter sets
```
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -Debug
Body:
{
  "error": {
    "code": "ExpressRouteCircuitCreateMissingPortProvisioningProperties",
    "message": "ExpressRouteCircuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy:\\nserviceProviderProperties or ExpressRoutePorts/BandwidthInGbps properties must be present in create operation.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -BandwidthInGbps 1 -Debug
Body:
{
  "location": "centralus",
  "properties": {
    "bandwidthInGbps": 1
  }
}
Body:
{
  "error": {
    "code": "ExpressRouteCircuitCreateMissingPortProvisioningProperties",
    "message": "ExpressRouteCircuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy:\\nserviceProviderProperties or ExpressRoutePorts/BandwidthInGbps properties must be present in create operation.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -ServiceProviderBandwidthInMbps 200 -Debug
Body:
{
  "location": "centralus",
  "properties": {
    "serviceProviderProperties": {
      "bandwidthInMbps": 200
    }
  }
}
Body:
{
  "error": {
    "code": "ExpressRouteCircuitServiceProviderPeeringLocationNotSpecified",
    "message": "The Express Route service provider peering location has not been specified for Express Route Circuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -ServiceProviderBandwidthInMbps 200 -ServiceProviderPeeringLocation centralus -Debug
Body:
{
  "location": "centralus",
  "properties": {
    "serviceProviderProperties": {
      "bandwidthInMbps": 200,
      "peeringLocation": "centralus"
    }
  }
}
Body:
{
  "error": {
    "code": "ExpressRouteCircuitServiceProviderNameNotSpecified",
    "message": "The Express Route service provider name has not been specified for Express Route Circuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -ServiceProviderBandwidthInMbps 200 -ServiceProviderPeeringLocation centralus -ServiceProviderName ercspmy -Debug
Body:
{
  "location": "centralus",
  "properties": {
    "serviceProviderProperties": {
      "bandwidthInMbps": 200,
      "peeringLocation": "centralus",
      "serviceProviderName": "ercspmy"
    }
  }
}
Body:
{
  "error": {
    "code": "ExpressRouteCircuitServiceProviderDoesNotExist",
    "message": "The Service Provider ercspmy specified for Express Route Circuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy does not exist.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -ServiceProviderBandwidthInMbps 200 -ServiceProviderPeeringLocation centralus -ServiceProviderName Orange -Debug
Body:
{
  "location": "centralus",
  "properties": {
    "serviceProviderProperties": {
      "bandwidthInMbps": 200,
      "peeringLocation": "centralus",
      "serviceProviderName": "Orange"
    }
  }
}
Body:
{
  "error": {
    "code": "ExpressRouteCircuitLocationDoesNotExistForServiceProvider",
    "message": "The Location centralus specified in Express Route Circuit /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteCircuits/ercmy does not exist for Service Provider Orange.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> ($providers | Where-Object { $_.Name -eq 'Orange' } | Select-Object -First 1).PeeringLocation
Amsterdam
Dallas
Frankfurt
Hong Kong
Johannesburg
London
Melbourne
Paris
Sao Paulo
Silicon Valley
Singapore
Sydney
Tokyo
Washington DC
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCircuit -Name ercmy -ResourceGroupName rgmy -Location centralus -ServiceProviderBandwidthInMbps 200 -ServiceProviderPeeringLocation London -ServiceProviderName Orange

Name  Location  Classic Operations Allowed Circuit Provisioning State Service Provider Provisioning State Notes Provisioning State SKU Name Service Provider Name
----  --------  -------------------------- -------------------------- ----------------------------------- ----- ------------------ -------- ---------------------
ercmy centralus False                      Disabled                   NotProvisioned                            Failed                      Orange
```

### FATAL! expressRouteCrossConnections
```
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteCrossConnection -Name erccmy -ResourceGroupName rgmy -Debug
Body:
{
  "error": {
    "code": "InvalidResourceType",
    "message": "The resource type could not be found in the namespace 'Microsoft.Network' for api version '2019-02-01'."
  }
}
```

### Issues! expressRouteGateways
- Make required: MinimumScaleUnit, VirtualHubId
- Issue with returning before Succeeded (takes about 30 minutes)
```
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy -Location centralus -Debug
Body:
{
  "error": {
    "code": "InternalServerError",
    "message": "An error occurred.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy -Location centralus -MinimumScaleUnit 2 -VirtualHubId $virtualHub.Id

Name  Location  Min Scale Unit Max Scale Unit Provisioning State
----  --------  -------------- -------------- ------------------
ergmy centralus 2                             Updating

PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRouteGateway -Name erg3my -ResourceGroupName rgmy -Location westus -VirtualHubId $virtualHub2.Id -Debug
Body:
{
  "error": {
    "code": "ExpressRouteGatewayAutoscaleMinBoundsNotValid",
    "message": "ExpressRoute Gateway /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/expressRouteGateways/erg3my does not have valid Autoscale Min Bounds. Valid Range is [2-6].",
    "details": []
  }
}
```

### FATAL! ExpressRoutePorts
```
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzExpressRoutePort -Name erpmy -ResourceGroupName rgmy -Debug
Body:
{
  "error": {
    "code": "InvalidResourceType",
    "message": "The resource type could not be found in the namespace 'Microsoft.Network' for api version '2019-02-01'."
  }
}
```

### interfaceEndpoints
### loadBalancers
### localNetworkGateways
### natGateways

### networkInterfaces
- Make required: [Name, Subnet (Id in SUBNET)] INSIDE IPConfiguration
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzNetworkInterface -Name nimy -ResourceGroupName rgmy -Location centralus
Body:
{
  "error": {
    "code": "InvalidIPConfigCount",
    "message": "Network interface nimy must have one or more IP configurations.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzNetworkInterface -Name nimy -ResourceGroupName rgmy -Location centralus -IPConfiguration @{ Name = 'icmy'; Subnet = @{ Id = $subnet.Id } }

GUID                                 Name Location  MAC Address Primary Accelerated Networking Enabled IP Forwarding Enabled Provisioning State
----                                 ---- --------  ----------- ------- ------------------------------ --------------------- ------------------
b2650fff-785a-4bdf-9873-7735ec297066 nimy centralus                     False                          False                 Succeeded
```

### networkProfiles

### DONE networkSecurityGroups

### networkWatchers
### p2svpnGateways

### DONE publicIPAddresses

### publicIPPrefixes
### routeFilters

### DONE routeTables

### serviceEndpointPolicies

### Issues! virtualHubs
- Make required: AddressPrefix, VirtualWanId
- Issue with returning before Succeeded (takes about 5 minutes)
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVirtualHub -Name vhmy -ResourceGroupName rgmy -Location centralus -Debug
Body:
{
  "error": {
    "code": "AddressPrefixStringCannotBeNullOrEmpty",
    "message": "Address prefix string for resource /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/virtualHubs/vhmy cannot be null or empty.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVirtualHub -Name vhmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24' -Debug
Body:
{
  "error": {
    "code": "VirtualHubCannotBeCreatedOrUpdatedWithoutVirtualWan",
    "message": "Virtual Hub /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/rgmy/providers/Microsoft.Network/virtualHubs/vhmy cannot be created or updated without a Virtual WAN.",
    "details": []
  }
}
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVirtualWan -Name vwmy -ResourceGroupName rgmy -Location centralus
PS C:\Code\azps-generation\src\Network [Az.Network]> $virtualWanId = (Get-AzVirtualWan)[0].Id
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVirtualHub -Name vhmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24' -VirtualWanId $virtualWanId

Name Location  Address Prefix Provisioning State
---- --------  -------------- ------------------
vhmy centralus 10.0.1.0/24    Updating


PS C:\Code\azps-generation\src\Network [Az.Network]> Get-AzVirtualHub

Name Location  Address Prefix Provisioning State
---- --------  -------------- ------------------
vhmy centralus 10.0.1.0/24    Updating


PS C:\Code\azps-generation\src\Network [Az.Network]> Get-AzVirtualHub

Name Location  Address Prefix Provisioning State
---- --------  -------------- ------------------
vhmy centralus 10.0.1.0/24    Succeeded
```

### Issues! virtualNetworkGateways
- Make required: [Name, SubnetId, PublicIPAddressId] INSIDE IPConfiguration
- Name of subnet MUST BE GatewaySubnet
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVnet -Name vnmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24'
PS C:\Code\azps-generation\src\Network [Az.Network]> $subnet = New-AzVnetSubnet -Name GatewaySubnet -ResourceGroupName rgmy -VnetName vnmy -AddressPrefix '10.0.1.0/24'
PS C:\Code\azps-generation\src\Network [Az.Network]> $pia = New-AzPublicIPAddress -Name piamy -ResourceGroupName rgmy -Location centralus
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVnetGateway -Name vngmy -ResourceGroupName rgmy -Location centralus -IPConfiguration @{ Name = 'ipcmy'; SubnetId = $subnet.Id; PublicIPAddressId = $pia.Id }

GUID                                 Name  Location  Gateway Type VPN Type    BGP Enabled Active-Active Enabled SKU Name Provisioning State
----                                 ----  --------  ------------ --------    ----------- --------------------- -------- ------------------
e099b7f2-b515-447f-91b0-a010c9feb240 vngmy centralus Vpn          PolicyBased False       False                 Basic    Updating
```

### virtualNetworkGatewayConnections [connections]
### Issues! virtualNetworks
- Make required: AddressPrefix
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVnet -Name vnmy -ResourceGroupName rgmy -Location centralus -AddressPrefix '10.0.1.0/24'

GUID                                 Name Location  DDOS Protection Enabled VM Protection Enabled Provisioning State
----                                 ---- --------  ----------------------- --------------------- ------------------
4355e34d-a276-4be0-ab2f-de9afe8a83d0 vnmy centralus False                   False                 Succeeded
```

#### Issues! virtualNetworks (Subnet)
- Make required: AddressPrefix
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVnetSubnet -Name vnsmy -ResourceGroupName rgmy -VnetName vnmy -AddressPrefix '10.0.1.0/24'

Etag                                     Name
----                                     ----
W/"fb35d334-4b72-42dd-8bb3-56b6f8fd5312" vnsmy
```

### virtualNetworkTaps

### DONE virtualWans
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> New-AzVirtualWan -Name vwmy -ResourceGroupName rgmy -Location centralus
```

### vpnGateways
### vpnSites