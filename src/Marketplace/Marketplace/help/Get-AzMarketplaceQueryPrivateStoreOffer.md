---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplacequeryprivatestoreoffer
schema: 2.0.0
---

# Get-AzMarketplaceQueryPrivateStoreOffer

## SYNOPSIS
List of offers, regardless the collections

## SYNTAX

### Query (Default)
```
Get-AzMarketplaceQueryPrivateStoreOffer -PrivateStoreId <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### QueryViaIdentity
```
Get-AzMarketplaceQueryPrivateStoreOffer -InputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List of offers, regardless the collections

## EXAMPLES

### Example 1: Returns private store offer regardless of collections
```powershell
Get-AzMarketplaceQueryPrivateStoreOffer -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a
```

```output
CreatedAt ETag                                   ModifiedAt OfferDisplayName PrivateStoreId                       PublisherDisplayName SpecificPlanIdLimitation                                                     UniqueOfferId
--------- ----                                   ---------- ---------------- --------------                       -------------------- -------------------------                                                     -------------
          "ed0093ae-0000-0100-0000-61a4dab30000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {d3-azure-health-check, data3-azure-optimiser-plan, data3-managed-azure-plan} data3-limite…
          "750547d8-0000-0100-0000-61b752010000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {mgmt-limited-free, mgmt-assessment}                                          viacode_cons…
          "ef00ab05-0000-0100-0000-61a5f12f0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {RedHatEnterpriseLinux72-ARM}                                                 RedHat.RHEL_7
          "f300276b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_conductor_hourly_427, 128technology_conductor_hourly_452}      128technolog…
          "f300296b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_router_100_hourly_427, 128technology_router_100_hourly_452}    128technolog…
```

This command returns private store offer regardless of collections

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: QueryViaIdentity
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
Parameter Sets: Query
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IQueryOffers

## NOTES

## RELATED LINKS
