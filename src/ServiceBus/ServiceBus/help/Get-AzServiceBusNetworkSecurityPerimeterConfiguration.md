---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusnetworksecurityperimeterconfiguration
schema: 2.0.0
---

# Get-AzServiceBusNetworkSecurityPerimeterConfiguration

## SYNOPSIS
Gets list of current NetworkSecurityPerimeterConfiguration for Namespace

## SYNTAX

```
Get-AzServiceBusNetworkSecurityPerimeterConfiguration -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets list of current NetworkSecurityPerimeterConfiguration for Namespace

## EXAMPLES

### Example 1: Gets list of NSP configurations an ServiceBus namespace.
```powershell
Get-AzServiceBusNetworkSecurityPerimeterConfiguration -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
ApplicableFeature                :
Id                               : /subscriptions/subscriptionid/resourceGroups/myresourcegroup/providers/Microsoft.ServiceBus/namespaces/mynamespaceName
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
Type                             : Microsoft.ServiceBus/Namespaces/networkSecurityPerimeterConfigurations
```

Gets tets list of NSP configurations an ServiceBus namespace.

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
The namespace name

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
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.INetworkSecurityPerimeterConfiguration

## NOTES

## RELATED LINKS
