---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/get-azcdnloganalyticwafloganalyticmetric
schema: 2.0.0
---

# Get-AzCdnLogAnalyticWafLogAnalyticMetric

## SYNOPSIS
Get Waf related log analytics report for AFD profile.

## SYNTAX

### Get (Default)
```
Get-AzCdnLogAnalyticWafLogAnalyticMetric -ProfileName <String> -ResourceGroupName <String>
 -DateTimeBegin <DateTime> -DateTimeEnd <DateTime> -Granularity <WafGranularity> -Metric <WafMetric[]>
 [-SubscriptionId <String[]>] [-Action <WafAction[]>] [-GroupBy <WafRankingGroupBy[]>]
 [-RuleType <WafRuleType[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCdnLogAnalyticWafLogAnalyticMetric -InputObject <ICdnIdentity> -DateTimeBegin <DateTime>
 -DateTimeEnd <DateTime> -Granularity <WafGranularity> -Metric <WafMetric[]> [-Action <WafAction[]>]
 [-GroupBy <WafRankingGroupBy[]>] [-RuleType <WafRuleType[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Waf related log analytics report for AFD profile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Action
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.WafAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DateTimeBegin
.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DateTimeEnd
.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
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

### -Granularity
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.WafGranularity
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupBy
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.WafRankingGroupBy[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metric
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.WafMetric[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.
which is unique within the resource group.

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### -RuleType
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.WafRuleType[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICdnIdentity>: Identity Parameter
  - `[CustomDomainName <String>]`: Name of the domain under the profile which is unique globally.
  - `[EndpointName <String>]`: Name of the endpoint under the profile which is unique globally.
  - `[Id <String>]`: Resource identity path
  - `[OriginGroupName <String>]`: Name of the origin group which is unique within the endpoint.
  - `[OriginName <String>]`: Name of the origin which is unique within the profile.
  - `[PolicyName <String>]`: The name of the CdnWebApplicationFirewallPolicy.
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

