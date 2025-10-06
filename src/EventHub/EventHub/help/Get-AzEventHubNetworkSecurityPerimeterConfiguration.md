---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubnetworksecurityperimeterconfiguration
schema: 2.0.0
---

# Get-AzEventHubNetworkSecurityPerimeterConfiguration

## SYNOPSIS
Gets list of current NetworkSecurityPerimeterConfiguration for Namespace

## SYNTAX

```
Get-AzEventHubNetworkSecurityPerimeterConfiguration -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets list of current NetworkSecurityPerimeterConfiguration for Namespace

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.INetworkSecurityPerimeterConfigurationList

## NOTES

## RELATED LINKS

