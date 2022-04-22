---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorder/invoke-azedgeorderreturnorderitem
schema: 2.0.0
---

# Invoke-AzEdgeOrderReturnOrderItem

## SYNOPSIS
Return order item.

## SYNTAX

### ReturnExpanded (Default)
```
Invoke-AzEdgeOrderReturnOrderItem -OrderItemName <String> -ResourceGroupName <String> -ReturnReason <String>
 [-SubscriptionId <String>] [-ContactDetailContactName <String>] [-ContactDetailEmailList <String[]>]
 [-ContactDetailMobile <String>] [-ContactDetailPhone <String>] [-ContactDetailPhoneExtension <String>]
 [-ServiceTag <String>] [-ShippingAddressCity <String>] [-ShippingAddressCompanyName <String>]
 [-ShippingAddressCountry <String>] [-ShippingAddressPostalCode <String>]
 [-ShippingAddressStateOrProvince <String>] [-ShippingAddressStreetAddress1 <String>]
 [-ShippingAddressStreetAddress2 <String>] [-ShippingAddressStreetAddress3 <String>]
 [-ShippingAddressType <AddressType>] [-ShippingAddressZipExtendedCode <String>] [-ShippingBoxRequired]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Return
```
Invoke-AzEdgeOrderReturnOrderItem -OrderItemName <String> -ResourceGroupName <String>
 -ReturnOrderItemDetail <IReturnOrderItemDetails> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReturnViaIdentity
```
Invoke-AzEdgeOrderReturnOrderItem -InputObject <IEdgeOrderIdentity>
 -ReturnOrderItemDetail <IReturnOrderItemDetails> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReturnViaIdentityExpanded
```
Invoke-AzEdgeOrderReturnOrderItem -InputObject <IEdgeOrderIdentity> -ReturnReason <String>
 [-ContactDetailContactName <String>] [-ContactDetailEmailList <String[]>] [-ContactDetailMobile <String>]
 [-ContactDetailPhone <String>] [-ContactDetailPhoneExtension <String>] [-ServiceTag <String>]
 [-ShippingAddressCity <String>] [-ShippingAddressCompanyName <String>] [-ShippingAddressCountry <String>]
 [-ShippingAddressPostalCode <String>] [-ShippingAddressStateOrProvince <String>]
 [-ShippingAddressStreetAddress1 <String>] [-ShippingAddressStreetAddress2 <String>]
 [-ShippingAddressStreetAddress3 <String>] [-ShippingAddressType <AddressType>]
 [-ShippingAddressZipExtendedCode <String>] [-ShippingBoxRequired] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Return order item.

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

### -ContactDetailContactName
Contact name of the person.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailEmailList
List of Email-ids to be notified about job progress.

```yaml
Type: System.String[]
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailMobile
Mobile number of the contact person.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailPhone
Phone number of the contact person.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailPhoneExtension
Phone extension number of the contact person.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity
Parameter Sets: ReturnViaIdentity, ReturnViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -OrderItemName
The name of the order item

```yaml
Type: System.String
Parameter Sets: Return, ReturnExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Return, ReturnExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnOrderItemDetail
Return order item request body
To construct, see NOTES section for RETURNORDERITEMDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IReturnOrderItemDetails
Parameter Sets: Return, ReturnViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReturnReason
Return Reason.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTag
Service tag (located on the bottom-right corner of the device)

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressCity
Name of the City.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressCompanyName
Name of the company.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressCountry
Name of the Country.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressPostalCode
Postal code.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressStateOrProvince
Name of the State or Province.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressStreetAddress1
Street Address line 1.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressStreetAddress2
Street Address line 2.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressStreetAddress3
Street Address line 3.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressType
Type of address.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.AddressType
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressZipExtendedCode
Extended Zip Code.

```yaml
Type: System.String
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingBoxRequired
Shipping Box required

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ReturnExpanded, ReturnViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Return, ReturnExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IReturnOrderItemDetails

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEdgeOrderIdentity>: Identity Parameter
  - `[AddressName <String>]`: The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OrderItemName <String>]`: The name of the order item
  - `[OrderName <String>]`: The name of the order
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

RETURNORDERITEMDETAIL <IReturnOrderItemDetails>: Return order item request body
  - `ReturnReason <String>`: Return Reason.
  - `[ContactDetailContactName <String>]`: Contact name of the person.
  - `[ContactDetailEmailList <String[]>]`: List of Email-ids to be notified about job progress.
  - `[ContactDetailMobile <String>]`: Mobile number of the contact person.
  - `[ContactDetailPhone <String>]`: Phone number of the contact person.
  - `[ContactDetailPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[ServiceTag <String>]`: Service tag (located on the bottom-right corner of the device)
  - `[ShippingAddressCity <String>]`: Name of the City.
  - `[ShippingAddressCompanyName <String>]`: Name of the company.
  - `[ShippingAddressCountry <String>]`: Name of the Country.
  - `[ShippingAddressPostalCode <String>]`: Postal code.
  - `[ShippingAddressStateOrProvince <String>]`: Name of the State or Province.
  - `[ShippingAddressStreetAddress1 <String>]`: Street Address line 1.
  - `[ShippingAddressStreetAddress2 <String>]`: Street Address line 2.
  - `[ShippingAddressStreetAddress3 <String>]`: Street Address line 3.
  - `[ShippingAddressType <AddressType?>]`: Type of address.
  - `[ShippingAddressZipExtendedCode <String>]`: Extended Zip Code.
  - `[ShippingBoxRequired <Boolean?>]`: Shipping Box required

## RELATED LINKS

