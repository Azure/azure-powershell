---
external help file:
Module Name: Az.Attestation
online version: https://learn.microsoft.com/powershell/module/az.attestation/get-azattestationdefaultprovider
schema: 2.0.0
---

# Get-AzAttestationDefaultProvider

## SYNOPSIS
Get the default provider by location.

## SYNTAX

### List (Default)
```
Get-AzAttestationDefaultProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAttestationDefaultProvider -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAttestationDefaultProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the default provider by location.

## EXAMPLES

### Example 1: Get the default provider by location
```powershell
Get-AzAttestationDefaultProvider -Location "East US"
```

```output
Get-AzAttestationDefaultProvider -Location "East US"

Location Name      ResourceGroupName
-------- ----      -----------------
east us  sharedeus
```

This command gets the default provider in "East US".

### Example 2: List default providers
```powershell
Get-AzAttestationDefaultProvider
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedeus2",
                                 "name": "sharedeus2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "East US 2",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedeus2.eus2.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedcus",
                                 "name": "sharedcus",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "Central US",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedcus.cus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/shareduks",
                                 "name": "shareduks",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "UK South",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://shareduks.uks.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedeus",
                                 "name": "sharedeus",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "east us",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedeus.eus.attest.azure.net"
                                 }
                               }…}
```

This commands lists default providers.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IAttestationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the default provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IAttestationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProviderListResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAttestationIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the default provider.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ProviderName <String>]`: Name of the attestation provider.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

