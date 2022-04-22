---
external help file:
Module Name: Az.Advisor
online version: https://docs.microsoft.com/en-us/powershell/module/az.advisor/new-azadvisorconfiguration
schema: 2.0.0
---

# New-AzAdvisorConfiguration

## SYNOPSIS
Create/Overwrite Azure Advisor configuration.

## SYNTAX

### CreateExpanded (Default)
```
New-AzAdvisorConfiguration [-SubscriptionId <String>] [-Digest <IDigestConfig[]>] [-Exclude]
 [-LowCpuThreshold <CpuThreshold>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzAdvisorConfiguration -ResourceGroup <String> -ConfigContract <IConfigData> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzAdvisorConfiguration -ResourceGroup <String> [-SubscriptionId <String>] [-Digest <IDigestConfig[]>]
 [-Exclude] [-LowCpuThreshold <CpuThreshold>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzAdvisorConfiguration -InputObject <IAdvisorIdentity> -ConfigContract <IConfigData>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzAdvisorConfiguration -InputObject <IAdvisorIdentity> [-Digest <IDigestConfig[]>] [-Exclude]
 [-LowCpuThreshold <CpuThreshold>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create/Overwrite Azure Advisor configuration.

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

### -ConfigContract
The Advisor configuration data structure.
To construct, see NOTES section for CONFIGCONTRACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Digest
Advisor digest configuration.
Valid only for subscriptions
To construct, see NOTES section for DIGEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IDigestConfig[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclude
Exclude the resource from Advisor evaluations.
Valid values: False (default) or True.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity
Parameter Sets: CreateViaIdentity1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LowCpuThreshold
Minimum percentage threshold for Advisor low CPU utilization evaluation.
Valid only for subscriptions.
Valid values: 5 (default), 10, 15 or 20.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Support.CpuThreshold
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
The name of the Azure resource group.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGCONTRACT <IConfigData>: The Advisor configuration data structure.
  - `[Digest <IDigestConfig[]>]`: Advisor digest configuration. Valid only for subscriptions
    - `[ActionGroupResourceId <String>]`: Action group resource id used by digest.
    - `[Category <Category[]>]`: Categories to send digest for. If categories are not provided, then digest will be sent for all categories.
    - `[Frequency <Int32?>]`: Frequency that digest will be triggered, in days. Value must be between 7 and 30 days inclusive.
    - `[Language <String>]`: Language for digest content body. Value must be ISO 639-1 code for one of Azure portal supported languages. Otherwise, it will be converted into one. Default value is English (en).
    - `[Name <String>]`: Name of digest configuration. Value is case-insensitive and must be unique within a subscription.
    - `[State <DigestConfigState?>]`: State of digest configuration.
  - `[Exclude <Boolean?>]`: Exclude the resource from Advisor evaluations. Valid values: False (default) or True.
  - `[LowCpuThreshold <CpuThreshold?>]`: Minimum percentage threshold for Advisor low CPU utilization evaluation. Valid only for subscriptions. Valid values: 5 (default), 10, 15 or 20.

DIGEST <IDigestConfig[]>: Advisor digest configuration. Valid only for subscriptions
  - `[ActionGroupResourceId <String>]`: Action group resource id used by digest.
  - `[Category <Category[]>]`: Categories to send digest for. If categories are not provided, then digest will be sent for all categories.
  - `[Frequency <Int32?>]`: Frequency that digest will be triggered, in days. Value must be between 7 and 30 days inclusive.
  - `[Language <String>]`: Language for digest content body. Value must be ISO 639-1 code for one of Azure portal supported languages. Otherwise, it will be converted into one. Default value is English (en).
  - `[Name <String>]`: Name of digest configuration. Value is case-insensitive and must be unique within a subscription.
  - `[State <DigestConfigState?>]`: State of digest configuration.

INPUTOBJECT <IAdvisorIdentity>: Identity Parameter
  - `[ConfigurationName <ConfigurationName?>]`: Advisor configuration name. Value must be 'default'
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: Name of metadata entity.
  - `[OperationId <String>]`: The operation ID, which can be found from the Location field in the generate recommendation response header.
  - `[RecommendationId <String>]`: The recommendation ID.
  - `[ResourceGroup <String>]`: The name of the Azure resource group.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource Manager identifier of the resource to which the recommendation applies.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

## RELATED LINKS

