---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustosku
schema: 2.0.0
---

# Get-AzKustoSku

## SYNOPSIS
Lists eligible region SKUs for Kusto resource provider by Azure region.

## SYNTAX

```
Get-AzKustoSku -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists eligible region SKUs for Kusto resource provider by Azure region.

## EXAMPLES

### Example 1: Lists eligible SKUs for Kusto resource provider by Azure region 
```powershell
Get-AzKustoSku -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Location "East US"
```

```output
Location Name                        ResourceType Tier
-------- ----                        ------------ ----
         Dev(No SLA)_Standard_D11_v2 clusters     Basic
         Dev(No SLA)_Standard_E2a_v4 clusters     Basic
         Standard_D11_v2             clusters     Standard
         Standard_D12_v2             clusters     Standard
         Standard_D13_v2             clusters     Standard
         Standard_D14_v2             clusters     Standard
         Standard_D32d_v4            clusters     Standard
         Standard_DS13_v2+1TB_PS     clusters     Standard
         Standard_DS13_v2+2TB_PS     clusters     Standard
         Standard_DS14_v2+3TB_PS     clusters     Standard
         Standard_DS14_v2+4TB_PS     clusters     Standard
         Standard_L8s_v2             clusters     Standard
         Standard_L16s_v2            clusters     Standard
         Standard_E64i_v3            clusters     Standard
         Standard_E80ids_v4          clusters     Standard
         Standard_E2a_v4             clusters     Standard
         Standard_E4a_v4             clusters     Standard
         Standard_E8a_v4             clusters     Standard
         Standard_E16a_v4            clusters     Standard
         Standard_E8as_v4+1TB_PS     clusters     Standard
         Standard_E8as_v4+2TB_PS     clusters     Standard
         Standard_E16as_v4+3TB_PS    clusters     Standard
         Standard_E16as_v4+4TB_PS    clusters     Standard
         Standard_E8as_v5+1TB_PS     clusters     Standard
         Standard_E8as_v5+2TB_PS     clusters     Standard
         Standard_E16as_v5+3TB_PS    clusters     Standard
         Standard_E16as_v5+4TB_PS    clusters     Standard
         Standard_E2ads_v5           clusters     Standard
         Standard_E4ads_v5           clusters     Standard
         Standard_E8ads_v5           clusters     Standard
         Standard_E16ads_v5          clusters     Standard
         Standard_E8s_v4+1TB_PS      clusters     Standard
         Standard_E8s_v4+2TB_PS      clusters     Standard
         Standard_E16s_v4+3TB_PS     clusters     Standard
         Standard_E16s_v4+4TB_PS     clusters     Standard
         Standard_E2d_v4             clusters     Standard
         Standard_E4d_v4             clusters     Standard
         Standard_E8d_v4             clusters     Standard
         Standard_E16d_v4            clusters     Standard
         Standard_E2d_v5             clusters     Standard
         Standard_E4d_v5             clusters     Standard
         Standard_E8d_v5             clusters     Standard
         Standard_E16d_v5            clusters     Standard
```

Lists eligible SKUs for Kusto resource provider by Azure region

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

### -Location
Azure location (region) name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.ISkuDescription

## NOTES

ALIASES

## RELATED LINKS

