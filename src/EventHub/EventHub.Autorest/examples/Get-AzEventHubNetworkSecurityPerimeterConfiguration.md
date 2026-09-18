### Example 1: Gets list of NSP configurations an EventHub namespace.
```powershell
Get-AzEventHubNetworkSecurityPerimeterConfiguration -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
ApplicableFeature                :
Id                               : /subscriptions/subscriptionid/resourceGroups/myresourcegroup/providers/Microsoft.EventHub/namespaces/mynamespaceName
                                    /networkSecurityPerimeterConfigurations/subscriptionid.testPranjitEH1-4263ede0-d5e1-4166-9694-2f0
                                   7739397aa
IsBackingResource                : False
Location                         : eastus2euap
Name                             : subscriptionid.testPranjitEH1-4263ede0-d5e1-4166-9694-2f07739397aa
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
ResourceAssociationName          : myResourceAssociationName
ResourceGroupName                : myresourcegroup
SourceResourceId                 :
Type                             : Microsoft.EventHub/Namespaces/networkSecurityPerimeterConfigurations
```

Gets tets list of NSP configurations an EventHub namespace.

