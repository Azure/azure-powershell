---
external help file:
Module Name: Az.VoiceServices
online version: https://learn.microsoft.com/powershell/module/az.voiceservices/get-azvoiceservicescommunicationscontact
schema: 2.0.0
---

# Get-AzVoiceServicesCommunicationsContact

## SYNOPSIS
Get a Contact

## SYNTAX

### List (Default)
```
Get-AzVoiceServicesCommunicationsContact -CommunicationsGatewayName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVoiceServicesCommunicationsContact -CommunicationsGatewayName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVoiceServicesCommunicationsContact -InputObject <IVoiceServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Contact

## EXAMPLES

### Example 1: List all contacts under the communications gateway
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

List all contacts under the communications gateway.

### Example 2: Get a contact
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a contact.

### Example 3: Get a contact by pipeline
```powershell
New-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01 -Location 'westcentralus' -PhoneNumber "+1-555-1234" -FullContactName "John Smith" -Email "johnsmith@example.com" -Role "Network Manager" | Get-AzVoiceServicesCommunicationsContact
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a contact by pipeline.

## PARAMETERS

### -CommunicationsGatewayName
Unique identifier for this deployment

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.IVoiceServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Unique identifier for this contact

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ContactName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.IVoiceServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.Api20221201Preview.IContact

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IVoiceServicesIdentity>`: Identity Parameter
  - `[CommunicationsGatewayName <String>]`: Unique identifier for this deployment
  - `[ContactName <String>]`: Unique identifier for this contact
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TestLineName <String>]`: Unique identifier for this test line

## RELATED LINKS

