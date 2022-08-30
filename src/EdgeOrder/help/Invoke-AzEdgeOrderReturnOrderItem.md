---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.edgeorder/invoke-azedgeorderreturnorderitem
schema: 2.0.0
---

# Invoke-AzEdgeOrderReturnOrderItem

## SYNOPSIS
Return order item.

## SYNTAX

### ReturnExpanded (Default)
```
Invoke-AzEdgeOrderReturnOrderItem -OrderItemName <String> -ResourceGroupName <String> -ReturnReason <String>
 [-SubscriptionId <String>] [-ReturnAddressContactDetail <IContactDetails>]
 [-ReturnAddressShippingAddress <IShippingAddress>] [-ServiceTag <String>] [-ShippingBoxRequired]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReturnViaIdentityExpanded
```
Invoke-AzEdgeOrderReturnOrderItem -InputObject <IEdgeOrderIdentity> -ReturnReason <String>
 [-ReturnAddressContactDetail <IContactDetails>] [-ReturnAddressShippingAddress <IShippingAddress>]
 [-ServiceTag <String>] [-ShippingBoxRequired] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Return order item.

## EXAMPLES

### Example 1: Command to initiate orderItem return
```powershell
Invoke-AzEdgeOrderReturnOrderItem -OrderItemName "OrderItem-211115074927900249117427" -ResourceGroupName "resourceGroupName" -ReturnReason "Test Order Return" -SubscriptionId "SubscriptionId"
```

Invoke orderItem return

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity
Parameter Sets: ReturnViaIdentityExpanded
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
Parameter Sets: ReturnExpanded
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
Parameter Sets: ReturnExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnAddressContactDetail
Contact details for the address
To construct, see NOTES section for RETURNADDRESSCONTACTDETAIL properties and create a hash table.

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

### -ReturnAddressShippingAddress
Shipping details for the address
To construct, see NOTES section for RETURNADDRESSSHIPPINGADDRESS properties and create a hash table.

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

### -ReturnReason
Return Reason.

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

### -ServiceTag
Service tag (located on the bottom-right corner of the device)

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: ReturnExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.IEdgeOrderIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IEdgeOrderIdentity>`: Identity Parameter
  - `[AddressName <String>]`: The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OrderItemName <String>]`: The name of the order item
  - `[OrderName <String>]`: The name of the order
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

RETURNADDRESSCONTACTDETAIL `<IContactDetails>`: Contact details for the address
  - `ContactName <String>`: Contact name of the person.
  - `EmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `Phone <String>`: Phone number of the contact person.
  - `[Mobile <String>]`: Mobile number of the contact person.
  - `[PhoneExtension <String>]`: Phone extension number of the contact person.

RETURNADDRESSSHIPPINGADDRESS `<IShippingAddress>`: Shipping details for the address
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

## RELATED LINKS

