---
external help file: Az.Attestation-help.xml
Module Name: Az.Attestation
online version: https://learn.microsoft.com/powershell/module/az.attestation/update-azattestationprovider
schema: 2.0.0
---

# Update-AzAttestationProvider

## SYNOPSIS
Updates the Attestation Provider.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAttestationProvider -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAttestationProvider -InputObject <IAttestationIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the Attestation Provider.

## EXAMPLES

### Example 1: Update a specific Attestation Provider.
```powershell
Update-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg -Tag @{"k"="v"} | fl
```

```output
AttestUri                    : https://testprovider.eus.attest.azure.net
Id                           : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/ 
                               attestationProviders/testprovider
Location                     : eastus
Name                         : testprovider
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
                                 "k": "v"
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

This command updates a specific Attestation Provider.

### Example 2: Update a specific Attestation Provider by piping
```powershell
Get-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg | Update-AzAttestationProvider -Tag @{"k"="v"} | fl
```

```output
AttestUri                    : https://testprovider.eus.attest.azure.net
Id                           : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/ 
                               attestationProviders/testprovider
Location                     : eastus
Name                         : testprovider
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
                                 "k": "v"
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

These commands update a specific Attestation Provider by piping.

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
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
Aliases: ProviderName

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
The tags that will be assigned to the attestation provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IAttestationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider

## NOTES

## RELATED LINKS
