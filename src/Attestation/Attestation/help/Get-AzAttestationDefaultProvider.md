---
external help file: Az.Attestation-help.xml
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
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzAttestationDefaultProvider -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAttestationDefaultProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
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

## RELATED LINKS
