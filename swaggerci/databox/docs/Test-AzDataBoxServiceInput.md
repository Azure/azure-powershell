---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/test-azdataboxserviceinput
schema: 2.0.0
---

# Test-AzDataBoxServiceInput

## SYNOPSIS
This method does all necessary pre-job creation validation under resource group.

## SYNTAX

### Validate1 (Default)
```
Test-AzDataBoxServiceInput -Location <String> -ValidationRequest <IValidationRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzDataBoxServiceInput -Location <String> -ResourceGroupName <String>
 -ValidationRequest <IValidationRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded
```
Test-AzDataBoxServiceInput -Location <String> -ResourceGroupName <String>
 -IndividualRequestDetail <IValidationInputRequest[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded1
```
Test-AzDataBoxServiceInput -Location <String> -IndividualRequestDetail <IValidationInputRequest[]>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzDataBoxServiceInput -InputObject <IDataBoxIdentity> -ValidationRequest <IValidationRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity1
```
Test-AzDataBoxServiceInput -InputObject <IDataBoxIdentity> -ValidationRequest <IValidationRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDataBoxServiceInput -InputObject <IDataBoxIdentity>
 -IndividualRequestDetail <IValidationInputRequest[]> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded1
```
Test-AzDataBoxServiceInput -InputObject <IDataBoxIdentity>
 -IndividualRequestDetail <IValidationInputRequest[]> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This method does all necessary pre-job creation validation under resource group.

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

### -IndividualRequestDetail
List of request details contain validationType and its request as key and value respectively.
To construct, see NOTES section for INDIVIDUALREQUESTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidationInputRequest[]
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
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
Parameter Sets: ValidateViaIdentity, ValidateViaIdentity1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
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
Parameter Sets: Validate, Validate1, ValidateExpanded, ValidateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name

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

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: Validate, Validate1, ValidateExpanded, ValidateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationRequest
Minimum request requirement of any validation category.
To construct, see NOTES section for VALIDATIONREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidationRequest
Parameter Sets: Validate, Validate1, ValidateViaIdentity, ValidateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidationRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IValidationResponseProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INDIVIDUALREQUESTDETAIL <IValidationInputRequest[]>: List of request details contain validationType and its request as key and value respectively.
  - `ValidationType <ValidationInputDiscriminator>`: Identifies the type of validation request.

INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

VALIDATIONREQUEST <IValidationRequest>: Minimum request requirement of any validation category.
  - `IndividualRequestDetail <IValidationInputRequest[]>`: List of request details contain validationType and its request as key and value respectively.
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

