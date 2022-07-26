---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.EdgeOrder/new-AzEdgeOrderPreferencesObject
schema: 2.0.0
---

# New-AzEdgeOrderPreferencesObject

## SYNOPSIS
Create an in-memory object for Preferences.

## SYNTAX

```
New-AzEdgeOrderPreferencesObject [-EncryptionPreference <IEncryptionPreferences>]
 [-ManagementResourcePreference <IManagementResourcePreferences>]
 [-NotificationPreference <INotificationPreference[]>] [-TransportPreference <ITransportPreferences>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Preferences.

## EXAMPLES

### Example 1: Create a preference object
```powershell
$preference = New-AzEdgeOrderPreferencesObject -EncryptionPreference @{DoubleEncryptionStatus = "Disabled"} -TransportPreference @{PreferredShipmentType = "MicrosoftManaged"} -ManagementResourcePreference @{PreferredManagementResourceId = "/subscriptions/managementSubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/1GPUtest"}
```

Creates a in-memory preference object to set transport, encryption and management resource preference.

## PARAMETERS

### -EncryptionPreference
Preferences related to the Encryption.
To construct, see NOTES section for ENCRYPTIONPREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IEncryptionPreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementResourcePreference
Preferences related to the Management resource.
To construct, see NOTES section for MANAGEMENTRESOURCEPREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IManagementResourcePreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationPreference
Notification preferences.
To construct, see NOTES section for NOTIFICATIONPREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.INotificationPreference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransportPreference
Preferences related to the shipment logistics of the order.
To construct, see NOTES section for TRANSPORTPREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ITransportPreferences
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.Preferences

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ENCRYPTIONPREFERENCE `<IEncryptionPreferences>`: Preferences related to the Encryption.
  - `[DoubleEncryptionStatus <DoubleEncryptionStatus?>]`: Double encryption status as entered by the customer. It is compulsory to give this parameter if the 'Deny' or 'Disabled' policy is configured.

MANAGEMENTRESOURCEPREFERENCE `<IManagementResourcePreferences>`: Preferences related to the Management resource.
  - `[PreferredManagementResourceId <String>]`: Customer preferred Management resource ARM ID

NOTIFICATIONPREFERENCE <INotificationPreference[]>: Notification preferences.
  - `SendNotification <Boolean>`: Notification is required or not.
  - `StageName <NotificationStageName>`: Name of the stage.

TRANSPORTPREFERENCE `<ITransportPreferences>`: Preferences related to the shipment logistics of the order.
  - `PreferredShipmentType <TransportShipmentTypes>`: Indicates Shipment Logistics type that the customer preferred.

## RELATED LINKS

