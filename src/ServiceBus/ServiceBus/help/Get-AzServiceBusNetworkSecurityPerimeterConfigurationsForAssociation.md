---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusnetworksecurityperimeterconfigurationsforassociation
schema: 2.0.0
---

# Get-AzServiceBusNetworkSecurityPerimeterConfigurationsForAssociation

## SYNOPSIS
Return a NetworkSecurityPerimeterConfigurations resourceAssociationName

## SYNTAX

### Get (Default)
```
Get-AzServiceBusNetworkSecurityPerimeterConfigurationsForAssociation -NamespaceName <String>
 -ResourceAssociationName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzServiceBusNetworkSecurityPerimeterConfigurationsForAssociation -ResourceAssociationName <String>
 -NamespaceInputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceBusNetworkSecurityPerimeterConfigurationsForAssociation -InputObject <IServiceBusIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Return a NetworkSecurityPerimeterConfigurations resourceAssociationName

## EXAMPLES

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceAssociationName
The ResourceAssociation Name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.INetworkSecurityPerimeterConfiguration

## NOTES

## RELATED LINKS
