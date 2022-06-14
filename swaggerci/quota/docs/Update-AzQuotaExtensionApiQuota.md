---
external help file:
Module Name: Az.QuotaExtensionApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.quotaextensionapi/update-azquotaextensionapiquota
schema: 2.0.0
---

# Update-AzQuotaExtensionApiQuota

## SYNOPSIS
Update the quota limit for a specific resource to the specified value:\n1.
Use the Usages-GET and Quota-GET operations to determine the remaining quota for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.
Please check the URI in location header for the detailed status of the request.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzQuotaExtensionApiQuota -ResourceName <String> -Scope <String> [-AnyProperty <IAny>]
 [-NameValue <String>] [-ResourceType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaExtensionApiQuota -InputObject <IQuotaExtensionApiIdentity> [-AnyProperty <IAny>]
 [-NameValue <String>] [-ResourceType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the quota limit for a specific resource to the specified value:\n1.
Use the Usages-GET and Quota-GET operations to determine the remaining quota for the specific resource and to calculate the new quota limit.
These steps are detailed in [this example](https://techcommunity.microsoft.com/t5/azure-governance-and-management/using-the-new-quota-rest-api/ba-p/2183670).\n2.
Use this PUT operation to update the quota limit.
Please check the URI in location header for the detailed status of the request.

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

### -AnyProperty
Additional properties for the specific resource provider.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.IAny
Parameter Sets: (All)
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.IQuotaExtensionApiIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NameValue
Resource name.

```yaml
Type: System.String
Parameter Sets: (All)
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
- SKU or TotalLowPriorityCores for Microsoft.MachineLearningServices
 For Microsoft.Network PublicIPAddresses.

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

### -ResourceType
Resource type name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The target Azure resource URI.
For example, `/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/qms-test/providers/Microsoft.Batch/batchAccounts/testAccount/`.
This is the target Azure resource URI for the List GET operation.
If a `{resourceName}` is added after `/quotas`, then it's the target Azure resource URI in the GET operation for the specific resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.IQuotaExtensionApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.Api20210315Preview.ICurrentQuotaLimitBase

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IQuotaExtensionApiIdentity>: Identity Parameter
  - `[Id <String>]`: Quota request ID.
  - `[Id1 <String>]`: Resource identity path
  - `[ResourceName <String>]`: Resource name for a given resource provider. For example:         - SKU name for Microsoft.Compute         - SKU or TotalLowPriorityCores for Microsoft.MachineLearningServices          For Microsoft.Network PublicIPAddresses.
  - `[Scope <String>]`: The target Azure resource URI. For example, `/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/qms-test/providers/Microsoft.Batch/batchAccounts/testAccount/`. This is the target Azure resource URI for the List GET operation. If a `{resourceName}` is added after `/quotas`, then it's the target Azure resource URI in the GET operation for the specific resource.

## RELATED LINKS

