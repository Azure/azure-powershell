---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.EdgeOrder/new-AzEdgeOrderOrderItemDetailsObject
schema: 2.0.0
---

# New-AzEdgeOrderOrderItemDetailsObject

## SYNOPSIS
Create an in-memory object for OrderItemDetails.

## SYNTAX

```
New-AzEdgeOrderOrderItemDetailsObject -OrderItemType <OrderItemType> -ProductDetail <IProductDetails>
 [-NotificationEmailList <String[]>] [-Preference <IPreferences>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for OrderItemDetails.

## EXAMPLES

### Example 1: Creates orderItemDetails object.
```powershell
$HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
$details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation}
```

Create an in-memory object for OrderItemDetails.

## PARAMETERS

### -NotificationEmailList
Additional notification email list.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderItemType
Order item type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.OrderItemType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Preference
Customer notification Preferences.
To construct, see NOTES section for PREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IPreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductDetail
Unique identifier for configuration.
To construct, see NOTES section for PRODUCTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductDetails
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.OrderItemDetails

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PREFERENCE `<IPreferences>`: Customer notification Preferences.
  - `[EncryptionPreference <IEncryptionPreferences>]`: Preferences related to the Encryption.
    - `[DoubleEncryptionStatus <DoubleEncryptionStatus?>]`: Double encryption status as entered by the customer. It is compulsory to give this parameter if the 'Deny' or 'Disabled' policy is configured.
  - `[ManagementResourcePreference <IManagementResourcePreferences>]`: Preferences related to the Management resource.
    - `[PreferredManagementResourceId <String>]`: Customer preferred Management resource ARM ID
  - `[NotificationPreference <INotificationPreference[]>]`: Notification preferences.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[TransportPreference <ITransportPreferences>]`: Preferences related to the shipment logistics of the order.
    - `PreferredShipmentType <TransportShipmentTypes>`: Indicates Shipment Logistics type that the customer preferred.

PRODUCTDETAIL `<IProductDetails>`: Unique identifier for configuration.
  - `HierarchyInformation <IHierarchyInformation>`: Hierarchy of the product which uniquely identifies the product
    - `[ConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration
    - `[ProductFamilyName <String>]`: Represents product family name that uniquely identifies product family
    - `[ProductLineName <String>]`: Represents product line name that uniquely identifies product line
    - `[ProductName <String>]`: Represents product name that uniquely identifies product

## RELATED LINKS

