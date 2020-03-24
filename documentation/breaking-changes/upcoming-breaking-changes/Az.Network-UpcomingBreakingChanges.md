## Breaking changes in module Microsoft.Azure.PowerShell.Cmdlets.Network.dll

 The following cmdlets were affected this release:




### **Add-AzApplicationGatewayBackendHttpSetting**
 - Cmdlet : 'Add-AzApplicationGatewayBackendHttpSetting'
 - Add-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Get-AzApplicationGatewayBackendHttpSetting**
 - Cmdlet : 'Get-AzApplicationGatewayBackendHttpSetting'
 - Get-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **New-AzApplicationGatewayBackendHttpSetting**
 - Cmdlet : 'New-AzApplicationGatewayBackendHttpSetting'
 - New-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Remove-AzApplicationGatewayBackendHttpSetting**
 - Cmdlet : 'Remove-AzApplicationGatewayBackendHttpSetting'
 - Remove-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Set-AzApplicationGatewayBackendHttpSetting**
 - Cmdlet : 'Set-AzApplicationGatewayBackendHttpSetting'
 - Set-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Get-AzApplicationGatewayAvailableSslOption**
 - Cmdlet : 'Get-AzApplicationGatewayAvailableSslOption'
 - Get-AzApplicationGatewayAvailableSslOptions alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Get-AzApplicationGatewayAvailableWafRuleSet**
 - Cmdlet : 'Get-AzApplicationGatewayAvailableWafRuleSet'
 - Get-AzApplicationGatewayAvailableWafRuleSets alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **New-AzApplicationGateway**
The following parameters were affected this release:
#### **UserAssignedIdentityId**
 - Cmdlet : 'New-AzApplicationGateway'
 - The parameter : 'UserAssignedIdentityId' is being replaced by parameter : 'Identity'.





### **New-AzFirewall**
The following parameters were affected this release:
#### **VirtualNetworkName**
 - Cmdlet : 'New-AzFirewall'
 - The parameter : 'VirtualNetworkName' is being replaced by parameter : 'VirtualNetwork'.
	The type of the parameter is changing from 'System.String' to 'PSVirtualNetwork'.
	Change description : This parameter will be removed in an upcoming breaking change release. After this point the Virtual Network will be provided as an object instead of a string.
Note :The change is expected to take effect from the version :  '2.0.0'

```powershell
# Old
New-AzFirewall -VirtualNetworkName "vnet-name"

# New
New-AzFirewall -VirtualNetwork $vnet
```



#### **PublicIpName**
 - Cmdlet : 'New-AzFirewall'
 - The parameter : 'PublicIpName' is being replaced by parameter : 'PublicIpAddress'.
	The type of the parameter is changing from 'System.String' to 'List<PSPublicIpAddress>'.
	Change description : This parameter will be removed in an upcoming breaking change release. After this point the Public IP Address will be provided as a list of one or more objects instead of a string.
Note :The change is expected to take effect from the version :  '2.0.0'

```powershell
# Old
New-AzFirewall -PublicIpName "public-ip-name"

# New
New-AzFirewall -PublicIpAddress @($publicip1, $publicip2)
```






### **New-AzVirtualHubRoute**
 - Cmdlet : 'New-AzVirtualHubRoute'
 - The cmdlet 'Add-AzVirtualHubRoute' is replacing this cmdlet.


BreakingChangesAttributesCmdLetDeprecationMessageWithReplacement: Add-AzVirtualHubRoute





### **New-AzVirtualHubRouteTable**
 - Cmdlet : 'New-AzVirtualHubRouteTable'
 - The cmdlet 'Add-AzVirtualHubRouteTable' is replacing this cmdlet.


BreakingChangesAttributesCmdLetDeprecationMessageWithReplacement: Add-AzVirtualHubRouteTable





### **Add-AzExpressRouteCircuitAuthorization**
 - Cmdlet : 'Add-AzExpressRouteCircuitAuthorization'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Get-AzExpressRouteCircuitAuthorization**
 - Cmdlet : 'Get-AzExpressRouteCircuitAuthorization'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Remove-AzExpressRouteCircuitAuthorization**
 - Cmdlet : 'Remove-AzExpressRouteCircuitAuthorization'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Get-AzExpressRouteCircuit**
 - Cmdlet : 'Get-AzExpressRouteCircuit'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Move-AzExpressRouteCircuit**
 - Cmdlet : 'Move-AzExpressRouteCircuit'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **New-AzExpressRouteCircuit**
 - Cmdlet : 'New-AzExpressRouteCircuit'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Add-AzExpressRouteCircuitPeeringConfig**
 - Cmdlet : 'Add-AzExpressRouteCircuitPeeringConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Add-AzExpressRouteCircuitConnectionConfig**
 - Cmdlet : 'Add-AzExpressRouteCircuitConnectionConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Remove-AzExpressRouteCircuitConnectionConfig**
 - Cmdlet : 'Remove-AzExpressRouteCircuitConnectionConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Get-AzExpressRouteCircuitPeeringConfig**
 - Cmdlet : 'Get-AzExpressRouteCircuitPeeringConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Remove-AzExpressRouteCircuitPeeringConfig**
 - Cmdlet : 'Remove-AzExpressRouteCircuitPeeringConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Set-AzExpressRouteCircuitPeeringConfig**
 - Cmdlet : 'Set-AzExpressRouteCircuitPeeringConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Set-AzExpressRouteCircuit**
 - Cmdlet : 'Set-AzExpressRouteCircuit'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing"
 - The following properties in the output type are being deprecated :
 'AllowGlobalReach'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'AllowGlobalReach'





### **Get-AzExpressRouteCircuitStat**
 - Cmdlet : 'Get-AzExpressRouteCircuitStat'
 - Get-AzExpressRouteCircuitStats alias will be removed in an upcoming breaking change release
Note :The change is expected to take effect from the version :  '2.0.0'






### **Get-AzPrivateEndpointConnection**
The following parameters were affected this release:
#### **Description**
 - Cmdlet : 'Get-AzPrivateEndpointConnection'
 - The parameter : 'Description' is changing.
	Change description : Parameter is being deprecated without being replaced





### **Remove-AzPrivateEndpointConnection**
The following parameters were affected this release:
#### **Description**
 - Cmdlet : 'Remove-AzPrivateEndpointConnection'
 - The parameter : 'Description' is changing.
	Change description : Parameter is being deprecated without being replaced





### **New-AzPrivateLinkServiceIpConfig**
 - Cmdlet : 'New-AzPrivateLinkServiceIpConfig'
 - "The output type 'Microsoft.Azure.Commands.Network.Models.PSPrivateLinkServiceIpConfiguration' is changing"
 - The following properties in the output type are being deprecated :
 'PublicIPAddress'
- The following properties are being added to the output type :
 'Primary'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.Network.Models.PSPrivateLinkServiceIpConfiguration
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'PublicIPAddress'
BreakingChangesAttributesCmdLetOutputPropertiesAdded:  'Primary'


The following parameters were affected this release:
#### **PublicIpAddress**
 - Cmdlet : 'New-AzPrivateLinkServiceIpConfig'
 - The parameter : 'PublicIpAddress' is changing.
	Change description : Parameter is being deprecated without being replaced




