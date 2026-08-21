### Example 1: Gets the network security configuration of an ServiceBus namespace for a given ResourceAssociationName.
```powershell
Get-AzServiceBusNetworkSecurityPerimeterConfigurationsForAssociation -ResourceGroupName myResourceGroup -NamespaceName myNamespace  -ResourceAssociationName resourceAssociationName
```

```output
ApplicableFeature                :
Id                               : /subscriptions/subscriptionid/resourceGroups/myresourcegroup/providers/Microsoft.ServiceBus/namespaces/
                                    mynamespaceName/networkSecurityPerimeterConfigurations/subscriptionid.resourceAssociationName
IsBackingResource                : False
Location                         : eastus2euap
Name                             : subscriptionid.resourceAssociationName
NetworkSecurityPerimeterGuid     : subscriptionid
NetworkSecurityPerimeterId       : /subscriptions/subscriptionid/resourceGroups/myresourcegroup/providers/Microsoft.Network/networkSecurityPe
                                   rimeters/pranjit-nsp-ncus
NetworkSecurityPerimeterLocation : northcentralus
ParentAssociationName            :
ProfileAccessRule                : {{
                                     "properties": {
                                       "direction": "Inbound",
                                       "addressPrefixes": [ ],
                                       "subscriptions": [ ],
                                       "networkSecurityPerimeters": [ ],
                                       "fullyQualifiedDomainNames": [ ]
                                     },
                                     "name": "ingress2"
                                   }, {
                                     "properties": {
                                       "direction": "Inbound",
                                       "addressPrefixes": [ "198.166.98.0/24" ],
                                       "subscriptions": [ ],
                                       "networkSecurityPerimeters": [ ],
                                       "fullyQualifiedDomainNames": [ ]
                                     },
                                     "name": "ingress"
                                   }}
ProfileAccessRulesVersion        : 5
ProfileName                      : defaultProfile
ProvisioningIssue                :
ProvisioningState                : Succeeded
ResourceAssociationAccessMode    : Learning
ResourceAssociationName          : resourceAssociationName
ResourceGroupName                : myresourcegroup
SourceResourceId                 :
Type                             : Microsoft.ServiceBus/Namespaces/networkSecurityPerimeterConfigurations
```

Gets the network security perimeter configuration for ServiceBus namespace myNamespace and the specified ResourceAssociationName.

