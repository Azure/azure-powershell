---
external help file: Az.Marketplace-help.xml
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/get-azmarketplacebillingprivatestoreaccount
schema: 2.0.0
---

# Get-AzMarketplaceBillingPrivateStoreAccount

## SYNOPSIS
Tenant billing accounts names

## SYNTAX

### Billing (Default)
```
Get-AzMarketplaceBillingPrivateStoreAccount -PrivateStoreId <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BillingViaIdentity
```
Get-AzMarketplaceBillingPrivateStoreAccount -InputObject <IMarketplaceIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Tenant billing accounts names

## EXAMPLES

### Example 1: Returns the billing account of a private store
```powershell
Get-AzMarketplaceBillingPrivateStoreAccount -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a
```

```output
<billing account[string]>
```

This command returns the billing account of a private store.

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
Parameter Sets: BillingViaIdentity
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
Parameter Sets: Billing
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IBillingAccountsResponse

## NOTES

## RELATED LINKS
