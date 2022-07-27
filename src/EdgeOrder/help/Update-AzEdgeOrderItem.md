---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.edgeorder/update-azedgeorderitem
schema: 2.0.0
---

# Update-AzEdgeOrderItem

## SYNOPSIS
Updates the properties of an existing order item.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEdgeOrderItem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ForwardAddressContactDetail <IContactDetails>] [-ForwardAddressShippingAddress <IShippingAddress>]
 [-NotificationEmailList <String[]>] [-Preference <IPreferences>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEdgeOrderItem -InputObject <IEdgeOrderIdentity> [-ForwardAddressContactDetail <IContactDetails>]
 [-ForwardAddressShippingAddress <IShippingAddress>] [-NotificationEmailList <String[]>]
 [-Preference <IPreferences>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing order item.

## EXAMPLES

### Example 1: Update orderItem
```powershell
$contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "ContactName2" -EmailList @("emailId") -Phone Phone
$DebugPreference = "Continue"
# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when update command fails.
# {
#   "Error": {
#     "Code": "StaticValidationGenericCountryCodeHasInvalidLength",
#     "Message": "The attribute country code does not meet length constraints.\r\nEnter a value with 2 characters for country code.",
#     "Details": [
#       null
#     ],
#     "Target": null
#   }
# } 
$updatedOrderItem = Update-AzEdgeOrderItem -Name "examplePowershell" -ResourceGroupName "resourceGroupName" -SubscriptionId SubscriptionId -ForwardAddressContactDetail $contactDetail

$updatedOrderItem.ForwardAddressContactDetail | Format-List
```

```output
ContactName    : ContactName2
EmailList      : {useremailId}
Mobile         :
Phone          : 1234567891
PhoneExtension :
```

Update orderItem details.

## PARAMETERS

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

### -ForwardAddressContactDetail
Contact details for the address
To construct, see NOTES section for FORWARDADDRESSCONTACTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IContactDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardAddressShippingAddress
Shipping details for the address
To construct, see NOTES section for FORWARDADDRESSSHIPPINGADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IShippingAddress
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the order item

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: OrderItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Preference
Customer preference.
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The list of key value pairs that describe the resource.
These tags can be used in viewing and grouping this resource (across resource groups).

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IOrderItemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FORWARDADDRESSCONTACTDETAIL `<IContactDetails>`: Contact details for the address
  - `ContactName <String>`: Contact name of the person.
  - `EmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `Phone <String>`: Phone number of the contact person.
  - `[Mobile <String>]`: Mobile number of the contact person.
  - `[PhoneExtension <String>]`: Phone extension number of the contact person.

FORWARDADDRESSSHIPPINGADDRESS `<IShippingAddress>`: Shipping details for the address
  - `Country <String>`: Name of the Country.
  - `StreetAddress1 <String>`: Street Address line 1.
  - `[AddressType <AddressType?>]`: Type of address.
  - `[City <String>]`: Name of the City.
  - `[CompanyName <String>]`: Name of the company.
  - `[PostalCode <String>]`: Postal code.
  - `[StateOrProvince <String>]`: Name of the State or Province.
  - `[StreetAddress2 <String>]`: Street Address line 2.
  - `[StreetAddress3 <String>]`: Street Address line 3.
  - `[ZipExtendedCode <String>]`: Extended Zip Code.

INPUTOBJECT `<IEdgeOrderIdentity>`: Identity Parameter
  - `[AddressName <String>]`: The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OrderItemName <String>]`: The name of the order item
  - `[OrderName <String>]`: The name of the order
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

PREFERENCE `<IPreferences>`: Customer preference.
  - `[EncryptionPreference <IEncryptionPreferences>]`: Preferences related to the Encryption.
    - `[DoubleEncryptionStatus <DoubleEncryptionStatus?>]`: Double encryption status as entered by the customer. It is compulsory to give this parameter if the 'Deny' or 'Disabled' policy is configured.
  - `[ManagementResourcePreference <IManagementResourcePreferences>]`: Preferences related to the Management resource.
    - `[PreferredManagementResourceId <String>]`: Customer preferred Management resource ARM ID
  - `[NotificationPreference <INotificationPreference[]>]`: Notification preferences.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[TransportPreference <ITransportPreferences>]`: Preferences related to the shipment logistics of the order.
    - `PreferredShipmentType <TransportShipmentTypes>`: Indicates Shipment Logistics type that the customer preferred.

## RELATED LINKS

