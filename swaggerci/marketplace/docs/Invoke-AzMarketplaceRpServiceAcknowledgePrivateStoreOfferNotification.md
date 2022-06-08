---
external help file:
Module Name: Az.MarketplaceRpService
online version: https://docs.microsoft.com/en-us/powershell/module/az.marketplacerpservice/invoke-azmarketplacerpserviceacknowledgeprivatestoreoffernotification
schema: 2.0.0
---

# Invoke-AzMarketplaceRpServiceAcknowledgePrivateStoreOfferNotification

## SYNOPSIS
Acknowledge notification for offer

## SYNTAX

### AcknowledgeExpanded (Default)
```
Invoke-AzMarketplaceRpServiceAcknowledgePrivateStoreOfferNotification -OfferId <String>
 -PrivateStoreId <String> [-Acknowledge] [-AddPlan <String[]>] [-Dismiss] [-RemoveOffer]
 [-RemovePlan <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Acknowledge
```
Invoke-AzMarketplaceRpServiceAcknowledgePrivateStoreOfferNotification -OfferId <String>
 -PrivateStoreId <String> -Payload <IAcknowledgeOfferNotificationProperties> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AcknowledgeViaIdentity
```
Invoke-AzMarketplaceRpServiceAcknowledgePrivateStoreOfferNotification
 -InputObject <IMarketplaceRpServiceIdentity> -Payload <IAcknowledgeOfferNotificationProperties>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AcknowledgeViaIdentityExpanded
```
Invoke-AzMarketplaceRpServiceAcknowledgePrivateStoreOfferNotification
 -InputObject <IMarketplaceRpServiceIdentity> [-Acknowledge] [-AddPlan <String[]>] [-Dismiss] [-RemoveOffer]
 [-RemovePlan <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Acknowledge notification for offer

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

### -Acknowledge
Gets or sets a value indicating whether acknowledge action flag is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AcknowledgeExpanded, AcknowledgeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddPlan
Gets or sets added plans

```yaml
Type: System.String[]
Parameter Sets: AcknowledgeExpanded, AcknowledgeViaIdentityExpanded
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

### -Dismiss
Gets or sets a value indicating whether dismiss action flag is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AcknowledgeExpanded, AcknowledgeViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.IMarketplaceRpServiceIdentity
Parameter Sets: AcknowledgeViaIdentity, AcknowledgeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OfferId
The offer ID to update or delete

```yaml
Type: System.String
Parameter Sets: Acknowledge, AcknowledgeExpanded
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

### -Payload
Notification update request payload
To construct, see NOTES section for PAYLOAD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IAcknowledgeOfferNotificationProperties
Parameter Sets: Acknowledge, AcknowledgeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateStoreId
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: Acknowledge, AcknowledgeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveOffer
Gets or sets a value indicating whether remove offer action flag is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AcknowledgeExpanded, AcknowledgeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemovePlan
Gets or sets remove plans

```yaml
Type: System.String[]
Parameter Sets: AcknowledgeExpanded, AcknowledgeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.Api20220301.IAcknowledgeOfferNotificationProperties

### Microsoft.Azure.PowerShell.Cmdlets.MarketplaceRpService.Models.IMarketplaceRpServiceIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMarketplaceRpServiceIdentity>: Identity Parameter
  - `[AdminRequestApprovalId <String>]`: The admin request approval ID to get create or update
  - `[CollectionId <String>]`: The collection ID
  - `[Id <String>]`: Resource identity path
  - `[OfferId <String>]`: The offer ID to update or delete
  - `[PrivateStoreId <String>]`: The store ID - must use the tenant ID
  - `[RequestApprovalId <String>]`: The request approval ID to get create or update

PAYLOAD <IAcknowledgeOfferNotificationProperties>: Notification update request payload
  - `[Acknowledge <Boolean?>]`: Gets or sets a value indicating whether acknowledge action flag is enabled
  - `[AddPlan <String[]>]`: Gets or sets added plans
  - `[Dismiss <Boolean?>]`: Gets or sets a value indicating whether dismiss action flag is enabled
  - `[RemoveOffer <Boolean?>]`: Gets or sets a value indicating whether remove offer action flag is enabled
  - `[RemovePlan <String[]>]`: Gets or sets remove plans

## RELATED LINKS

