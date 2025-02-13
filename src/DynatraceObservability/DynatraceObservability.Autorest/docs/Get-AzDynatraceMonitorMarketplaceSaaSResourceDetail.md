---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/get-azdynatracemonitormarketplacesaasresourcedetail
schema: 2.0.0
---

# Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail

## SYNOPSIS
Get Marketplace SaaS resource details of a tenant under a specific subscription

## SYNTAX

### GetExpanded (Default)
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -TenantId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -Request <IMarketplaceSaaSResourceDetailsRequest>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -InputObject <IDynatraceObservabilityIdentity>
 -Request <IMarketplaceSaaSResourceDetailsRequest> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -InputObject <IDynatraceObservabilityIdentity>
 -TenantId <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get Marketplace SaaS resource details of a tenant under a specific subscription

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Request
Request for getting Marketplace SaaS resource details for a tenant Id
To construct, see NOTES section for REQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20230427.IMarketplaceSaaSResourceDetailsRequest
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, GetExpanded
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
Parameter Sets: GetExpanded, GetViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20230427.IMarketplaceSaaSResourceDetailsRequest

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20230427.IMarketplaceSaaSResourceDetailsResponse

## NOTES

## RELATED LINKS

