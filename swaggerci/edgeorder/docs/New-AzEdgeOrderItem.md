---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorder/new-azedgeorderitem
schema: 2.0.0
---

# New-AzEdgeOrderItem

## SYNOPSIS
Creates an order item.
Existing order item cannot be updated with this api and should instead be updated with the Update order item API.

## SYNTAX

```
New-AzEdgeOrderItem -Name <String> -ResourceGroupName <String> -AddressDetail <IAddressDetails>
 -Location <String> -OrderId <String> -OrderItemDetail <IOrderItemDetails> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates an order item.
Existing order item cannot be updated with this api and should instead be updated with the Update order item API.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AddressDetail
Represents shipping and return address for order item
To construct, see NOTES section for ADDRESSDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IAddressDetails
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Location
The geo-location where the resource lives

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

### -Name
The name of the order item

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OrderItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderId
Id of the order to which order item belongs to

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

### -OrderItemDetail
Represents order item details.
To construct, see NOTES section for ORDERITEMDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IOrderItemDetails
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

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IOrderItemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ADDRESSDETAIL <IAddressDetails>: Represents shipping and return address for order item
  - `ForwardAddressContactDetailsContactName <String>`: Contact name of the person.
  - `ForwardAddressContactDetailsEmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `ForwardAddressContactDetailsPhone <String>`: Phone number of the contact person.
  - `[ForwardAddressContactDetailsMobile <String>]`: Mobile number of the contact person.
  - `[ForwardAddressContactDetailsPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[ForwardAddressShippingAddressCity <String>]`: Name of the City.
  - `[ForwardAddressShippingAddressCompanyName <String>]`: Name of the company.
  - `[ForwardAddressShippingAddressCountry <String>]`: Name of the Country.
  - `[ForwardAddressShippingAddressPostalCode <String>]`: Postal code.
  - `[ForwardAddressShippingAddressStateOrProvince <String>]`: Name of the State or Province.
  - `[ForwardAddressShippingAddressStreetAddress1 <String>]`: Street Address line 1.
  - `[ForwardAddressShippingAddressStreetAddress2 <String>]`: Street Address line 2.
  - `[ForwardAddressShippingAddressStreetAddress3 <String>]`: Street Address line 3.
  - `[ForwardAddressShippingAddressType <AddressType?>]`: Type of address.
  - `[ForwardAddressShippingAddressZipExtendedCode <String>]`: Extended Zip Code.
  - `[ReturnAddressContactDetailsContactName <String>]`: Contact name of the person.
  - `[ReturnAddressContactDetailsEmailList <String[]>]`: List of Email-ids to be notified about job progress.
  - `[ReturnAddressContactDetailsMobile <String>]`: Mobile number of the contact person.
  - `[ReturnAddressContactDetailsPhone <String>]`: Phone number of the contact person.
  - `[ReturnAddressContactDetailsPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[ReturnAddressShippingAddressCity <String>]`: Name of the City.
  - `[ReturnAddressShippingAddressCompanyName <String>]`: Name of the company.
  - `[ReturnAddressShippingAddressCountry <String>]`: Name of the Country.
  - `[ReturnAddressShippingAddressPostalCode <String>]`: Postal code.
  - `[ReturnAddressShippingAddressStateOrProvince <String>]`: Name of the State or Province.
  - `[ReturnAddressShippingAddressStreetAddress1 <String>]`: Street Address line 1.
  - `[ReturnAddressShippingAddressStreetAddress2 <String>]`: Street Address line 2.
  - `[ReturnAddressShippingAddressStreetAddress3 <String>]`: Street Address line 3.
  - `[ReturnAddressShippingAddressType <AddressType?>]`: Type of address.
  - `[ReturnAddressShippingAddressZipExtendedCode <String>]`: Extended Zip Code.

ORDERITEMDETAIL <IOrderItemDetails>: Represents order item details.
  - `OrderItemType <OrderItemType>`: Order item type.
  - `[EncryptionPreferenceDoubleEncryptionStatus <DoubleEncryptionStatus?>]`: Double encryption status as entered by the customer. It is compulsory to give this parameter if the 'Deny' or 'Disabled' policy is configured.
  - `[HierarchyInformationConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration
  - `[HierarchyInformationProductFamilyName <String>]`: Represents product family name that uniquely identifies product family
  - `[HierarchyInformationProductLineName <String>]`: Represents product line name that uniquely identifies product line
  - `[HierarchyInformationProductName <String>]`: Represents product name that uniquely identifies product
  - `[ManagementResourcePreferencePreferredManagementResourceId <String>]`: Customer preferred Management resource ARM ID
  - `[NotificationEmailList <String[]>]`: Additional notification email list
  - `[PreferenceNotificationPreference <INotificationPreference[]>]`: Notification preferences.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.

## RELATED LINKS

