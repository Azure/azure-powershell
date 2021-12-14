---
external help file:
Module Name: Az.Quota
online version: https://docs.microsoft.com/powershell/module/az.quota/set-azquota
schema: 2.0.0
---

# Set-AzQuota

## SYNOPSIS
Create or update the quota limit for the specified resource to the requested value.
To update the quota, follow these steps:\n1.
Use the GET operation to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzQuota -ResourceName <String> -Scope <String> [-AnyProperty <IAny>] [-Limit <Int32>]
 [-NameValue <String>] [-ResourceType <ResourceType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzQuota -ResourceName <String> -Scope <String> -CreateQuotaRequest <ICurrentQuotaLimitBase>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update the quota limit for the specified resource to the requested value.
To update the quota, follow these steps:\n1.
Use the GET operation to determine how much quota remains for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.

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

### -AnyProperty
Additional properties for the specific resource provider.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IAny
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -CreateQuotaRequest
Quota limit.
To construct, see NOTES section for CREATEQUOTAREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.Api20210315.ICurrentQuotaLimitBase
Parameter Sets: Update
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

### -Limit
Quota limit.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameValue
Resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceName
Resource name for a given resource provider.
For example:
- SKU name for Microsoft.Compute
- Sku or TotalLowPriorityCores for Microsoft.MachineLearningServices

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

### -ResourceType
Resource type name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Support.ResourceType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The target Azure resource URI.
For example, `/subscriptions/9f6cce51-6baf-4de5-a3c4-6f58b85315b9/resourceGroups/qms-test/providers/Microsoft.Batch/batchAccounts/testAccount/`.
This is the target Azure resource URI for the List GET operation.
If a `{resourceName}` is added after `/quotaLimits`, then it's the target Azure resource URI in the GET operation for the specific resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.Api20210315.ICurrentQuotaLimitBase

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.Api20210315.ICurrentQuotaLimitBase

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CREATEQUOTAREQUEST <ICurrentQuotaLimitBase>: Quota limit.
  - `[AnyProperty <IAny>]`: Additional properties for the specific resource provider.
  - `[ETag <String>]`: 
  - `[Limit <Int32?>]`: Quota limit.
  - `[NameValue <String>]`: Resource name.
  - `[ResourceType <ResourceType?>]`: Resource type name.

## RELATED LINKS

