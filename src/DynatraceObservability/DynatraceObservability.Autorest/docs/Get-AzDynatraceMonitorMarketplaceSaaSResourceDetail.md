---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/get-azdynatracemonitormarketplacesaasresourcedetail
schema: 2.0.0
---

# Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail

## SYNOPSIS
Get Marketplace SaaS resource details

## SYNTAX

### GetExpanded (Default)
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -TenantId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -Request <IMarketplaceSaaSResourceDetailsRequest>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -JsonFilePath <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -JsonString <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get Marketplace SaaS resource details

## EXAMPLES

### Example 1: get Marketplace SaaS resource details
```powershell
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -TenantId 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
```

```output
MarketplaceSaaSResourceId            MarketplaceSubscriptionStatus PlanId
-------------------------            ----------------------------- ------
yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy Subscribed                    azureportalintegration_privatepreview
```

This command gets the Marketplace SaaS resource for a given tenant Id.

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

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
Request for getting Marketplace SaaS resource details for a tenant Id

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMarketplaceSaaSResourceDetailsRequest
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Tenant Id

```yaml
Type: System.String
Parameter Sets: GetExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMarketplaceSaaSResourceDetailsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMarketplaceSaaSResourceDetailsResponse

## NOTES

## RELATED LINKS

