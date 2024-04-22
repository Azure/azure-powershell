---
external help file: Az.Attestation-help.xml
Module Name: Az.Attestation
online version: https://learn.microsoft.com/powershell/module/az.attestation/get-azattestationprovider
schema: 2.0.0
---

# Get-AzAttestationProvider

## SYNOPSIS
Get the status of Attestation Provider.

## SYNTAX

### List (Default)
```
Get-AzAttestationProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzAttestationProvider -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzAttestationProvider -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAttestationProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the status of Attestation Provider.

## EXAMPLES

### Example 1: Get the status of a specific Attestation Provider
```powershell
Get-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg | fl
```

```output
AttestUri                    : https://testprovider1.eus.attest.azure.net
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1
Location                     : eastus
Name                         : testprovider1
PrivateEndpointConnection    : 
ResourceGroupName            : test-rg
Status                       : Ready
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

This command gets the status of a specific Attestation Provider named `testprovider1`.

### Example 2: List statuses of all Attestation Providers in current subscription
```powershell
Get-AzAttestationProvider
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/test",
                                 "name": "test",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://test.eus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1",
                                 "name": "testprovider1",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider1.eus.attest.azure.net"
                                 }
                               },{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Att 
                               estation/attestationProviders/testprovider2",
                                 "name": "testprovider2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "eastus",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider2.eus.attest.azure.net"
                                 }
                               }}
```

This command lists statuses of all Attestation Providers in current subscription.

### Example 2: List statuses of all Attestation Providers in a resource group
```powershell
Get-AzAttestationProvider -ResourceGroupName test-rg
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/test",
                                 "name": "test",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://test.eus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1",
                                 "name": "testprovider1",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider1.eus.attest.azure.net"
                                 }
                               },{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider2",
                                 "name": "testprovider2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "eastus",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider2.eus.attest.azure.net"
                                 }
                               }}
```

This command lists statuses of all Attestation Providers in a resource group.

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

### -Name
Name of the attestation provider.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ProviderName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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
