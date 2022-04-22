---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/test-azdataboxserviceaddress
schema: 2.0.0
---

# Test-AzDataBoxServiceAddress

## SYNOPSIS
[DEPRECATED NOTICE: This operation will soon be removed].
This method validates the customer shipping address and provide alternate addresses if any.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzDataBoxServiceAddress -Location <String> -DeviceType <SkuName> -ShippingAddressCountry <String>
 -ShippingAddressStreetAddress1 <String> -ValidationType <ValidationInputDiscriminator>
 [-SubscriptionId <String>] [-ShippingAddressCity <String>] [-ShippingAddressCompanyName <String>]
 [-ShippingAddressPostalCode <String>] [-ShippingAddressStateOrProvince <String>]
 [-ShippingAddressStreetAddress2 <String>] [-ShippingAddressStreetAddress3 <String>]
 [-ShippingAddressType <AddressType>] [-ShippingAddressZipExtendedCode <String>]
 [-TransportPreferencePreferredShipmentType <TransportShipmentTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzDataBoxServiceAddress -Location <String> -ValidateAddress <IValidateAddress> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzDataBoxServiceAddress -InputObject <IDataBoxIdentity> -ValidateAddress <IValidateAddress>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDataBoxServiceAddress -InputObject <IDataBoxIdentity> -DeviceType <SkuName>
 -ShippingAddressCountry <String> -ShippingAddressStreetAddress1 <String>
 -ValidationType <ValidationInputDiscriminator> [-ShippingAddressCity <String>]
 [-ShippingAddressCompanyName <String>] [-ShippingAddressPostalCode <String>]
 [-ShippingAddressStateOrProvince <String>] [-ShippingAddressStreetAddress2 <String>]
 [-ShippingAddressStreetAddress3 <String>] [-ShippingAddressType <AddressType>]
 [-ShippingAddressZipExtendedCode <String>]
 [-TransportPreferencePreferredShipmentType <TransportShipmentTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
[DEPRECATED NOTICE: This operation will soon be removed].
This method validates the customer shipping address and provide alternate addresses if any.

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

### -DeviceType
Device type to be used for the job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.SkuName
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the resource

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressCity
Name of the City.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressPostalCode
Postal code.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddressStreetAddress2
Street Address line 2.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.AddressType
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransportPreferencePreferredShipmentType
Indicates Shipment Logistics type that the customer preferred.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransportShipmentTypes
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateAddress
The requirements to validate customer address where the device needs to be shipped.
To construct, see NOTES section for VALIDATEADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidateAddress
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ValidationType
Identifies the type of validation request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.ValidationInputDiscriminator
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidateAddress

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IAddressValidationProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

VALIDATEADDRESS <IValidateAddress>: The requirements to validate customer address where the device needs to be shipped.
  - `ValidationType <ValidationInputDiscriminator>`: Identifies the type of validation request.
  - `DeviceType <SkuName>`: Device type to be used for the job.
  - `ShippingAddressCountry <String>`: Name of the Country.
  - `ShippingAddressStreetAddress1 <String>`: Street Address line 1.
  - `[ShippingAddressCity <String>]`: Name of the City.
  - `[ShippingAddressCompanyName <String>]`: Name of the company.
  - `[ShippingAddressPostalCode <String>]`: Postal code.
  - `[ShippingAddressStateOrProvince <String>]`: Name of the State or Province.
  - `[ShippingAddressStreetAddress2 <String>]`: Street Address line 2.
  - `[ShippingAddressStreetAddress3 <String>]`: Street Address line 3.
  - `[ShippingAddressType <AddressType?>]`: Type of address.
  - `[ShippingAddressZipExtendedCode <String>]`: Extended Zip Code.
  - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.

## RELATED LINKS

